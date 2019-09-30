using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;


namespace ShopZone.Manager
{
    public class OrderManager
    {
        public static Model.CustomerOrder GetOrder(int id, bool? isActive = null, bool? isDeleted = null)
        {
            Model.CustomerOrder customerOrder = new Model.CustomerOrder();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var orders = (from io in entity.CustomerOrders
                              join c in entity.Customers on io.CustomerId equals c.Id

                              join p in entity.Products on io.ProductId equals p.Id
                              join l in entity.LoginUsers on c.UserId equals l.Id
                              join r in entity.Roles on l.RoleId equals r.Id
                              select new { Order = io, Product = p, User = l, Customer = c, Role = r }
                    ).AsQueryable();


                if (isActive != null)
                {
                    orders = orders.Where(i => i.Order.IsActive == isActive && i.Product.IsActive == isActive && i.Customer.IsActive == isActive && i.User.IsActive == isActive && i.Role.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    orders = orders.Where(i => i.Order.IsDeleted == isDeleted && i.Product.IsDeleted == isDeleted && i.Customer.IsDeleted == isDeleted && i.User.IsDeleted == isDeleted && i.Role.IsDeleted == isDeleted);

                }
                var reqOrder = orders.Where(i => i.Order.Id == id).Select(o => o).FirstOrDefault();
                customerOrder = reqOrder.Order;
                customerOrder.OrderProduct = reqOrder.Product;
                customerOrder.Customer = reqOrder.Customer;
                customerOrder.Customer.LoginInfo = reqOrder.User;
                customerOrder.Customer.LoginInfo.UserRole = reqOrder.Role;



                customerOrder.OrderTrackingStatus = entity.OrderTrackings.Where(i => i.CartGUID == customerOrder.CartGUID).ToList();
                if (customerOrder.OrderTrackingStatus.Any())
                {
                    customerOrder.TransitStatus = customerOrder.OrderTrackingStatus.OrderByDescending(i => i.Id).FirstOrDefault().TransitStatus;
                }


            }
            return customerOrder;

        }

        public static List<Model.CustomerOrder> GetOrders(string transactionId, bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.CustomerOrder> invoiceOrders = new List<Model.CustomerOrder>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var orderListQry = (from io in entity.CustomerOrders
                                    join p in entity.Products on io.ProductId equals p.Id
                                    join c in entity.Customers on io.CustomerId equals c.Id
                                    join l in entity.LoginUsers on c.UserId equals l.Id
                                    join r in entity.Roles on l.RoleId equals r.Id
                                    select new { Order = io, Product = p, User = l, Customer = c, Role = r, LoginInfo = l }
                    ).AsQueryable();


                if (isActive != null)
                {
                    orderListQry = orderListQry.Where(i => i.Order.IsActive == isActive && i.Product.IsActive == isActive && i.LoginInfo.IsActive == isActive && i.Customer.IsActive == isActive && i.User.IsActive == isActive && i.Role.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    orderListQry = orderListQry.Where(i => i.Order.IsDeleted == isDeleted && i.Product.IsDeleted == isDeleted && i.LoginInfo.IsDeleted == isDeleted && i.Customer.IsDeleted == isDeleted && i.User.IsDeleted == isDeleted && i.Role.IsDeleted == isDeleted);

                }
                if (!string.IsNullOrEmpty(transactionId))
                {
                    orderListQry = orderListQry.Where(i => i.Order.CartGUID == transactionId);

                }
                var orderList = orderListQry.ToList();
                invoiceOrders = orderList.Select(i => i.Order).ToList();
                foreach (var o in invoiceOrders)
                {
                    o.OrderProduct = orderList.Where(i => i.Order.Id == o.Id).Select(i => i.Product).FirstOrDefault();
                    o.Customer = orderList.Where(i => i.Order.Id == o.Id).Select(i => i.Customer).FirstOrDefault();
                    o.Customer.LoginInfo = orderList.Where(i => i.Order.Id == o.Id).Select(i => i.LoginInfo).FirstOrDefault();
                    o.Customer.LoginInfo.UserRole = orderList.Where(i => i.Order.Id == o.Id).Select(i => i.Role).FirstOrDefault();

                    o.OrderTrackingStatus = entity.OrderTrackings.Where(i => i.CartGUID == o.CartGUID).ToList();
                    if (o.OrderTrackingStatus.Any())
                    {
                        o.TransitStatus = o.OrderTrackingStatus.OrderByDescending(i => i.Id).FirstOrDefault().TransitStatus;
                    }
                }


            }
            return invoiceOrders;

        }

        public static Model.CustomerOrder SaveOrder(Model.CustomerOrder order)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (order.Id <= 0)
                {

                    var newOrder = new Entity.CustomerOrder
                    {
                        CustomerId = order.CustomerId,
                        ProductId = order.ProductId,
                        UnitAmount = order.UnitAmount,
                        Unit = order.Unit,
                        CartGUID = order.CartGUID,
                        PaymodeMode = order.PaymodeMode,
                        PaymentStatus = order.PaymentStatus,
                        Discount = order.Discount,
                        AmountPaid = order.AmountPaid,
                        Description = order.Description,
                        CreatedOn = DateTime.Now,
                        CreatedBy = order.CreatedBy,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToCustomerOrders(newOrder);

                    var product = entity.Products.Where(i => i.Id == newOrder.ProductId).FirstOrDefault();
                    product.NoOfStock = product.NoOfStock - newOrder.Unit;


                    entity.SaveChanges();
                    order.Id = newOrder.Id;
                }
                else
                {
                    var existInvoice = entity.CustomerOrders.Where(i => i.IsDeleted == false && i.Id == order.Id).FirstOrDefault();
                    if (existInvoice != null)
                    {
                        existInvoice.CustomerId = order.CustomerId;
                        existInvoice.ProductId = order.ProductId;
                        existInvoice.CartGUID = order.CartGUID;
                        existInvoice.PaymodeMode = order.PaymodeMode;
                        existInvoice.PaymentStatus = order.PaymentStatus;
                        existInvoice.Unit = order.Unit;

                        existInvoice.Discount = order.Discount;
                        existInvoice.AmountPaid = order.AmountPaid;
                        existInvoice.UnitAmount = order.UnitAmount;
                        existInvoice.Description = order.Description;
                        existInvoice.LastUpdatedOn = DateTime.Now;
                        existInvoice.LastUpdatedBy = order.LastUpdatedBy;
                        existInvoice.IsDeleted = order.IsDeleted;
                        existInvoice.IsActive = order.IsActive;

                        var product = entity.Products.Where(i => i.Id == existInvoice.ProductId).FirstOrDefault();
                        product.NoOfStock = product.NoOfStock - existInvoice.Unit;


                        entity.SaveChanges();


                    }

                }

            }
            order = GetOrder(order.Id);
            return order;

        }
        public static Model.OrderTracking SaveOrderTracking(int id, string cartGUID, string transitStatus)
        {
            Model.OrderTracking orderTracking = new Model.OrderTracking();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (id <= 0)
                {

                    var newOrder = new Entity.OrderTracking
                    {
                        Id = id,
                        CartGUID = cartGUID,
                        TransitStatus = transitStatus,
                        Description = "",
                        CreatedOn = DateTime.Now,
                        CreatedBy = 0,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToOrderTrackings(newOrder);
                    entity.SaveChanges();
                    orderTracking = entity.OrderTrackings.Where(i => i.Id == newOrder.Id).FirstOrDefault();
                }
                else
                {
                    var existInvoice = entity.OrderTrackings.Where(i => i.Id == id).FirstOrDefault();
                    if (existInvoice != null)
                    {
                        existInvoice.CartGUID = cartGUID;
                        existInvoice.TransitStatus = transitStatus;
                        existInvoice.Description = "";
                        existInvoice.LastUpdatedOn = DateTime.Now;
                        existInvoice.LastUpdatedBy = 0;
                        existInvoice.IsDeleted = false;
                        existInvoice.IsActive = true;

                        entity.SaveChanges();

                        orderTracking = entity.OrderTrackings.Where(i => i.Id == id).FirstOrDefault();
                    }

                }

            }

            return orderTracking;

        }

        public static List<Model.CustomerOrder> PlaceOrder(List<Model.ShopzoneCart> orders)
        {

            List<Model.CustomerOrder> finalOrder = new List<Model.CustomerOrder>();

            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var transactionGuid = Guid.NewGuid();
                foreach (var order in orders)
                {
                    var newOrder = new Entity.CustomerOrder
                    {
                        Id = -1,
                        CustomerId = order.Customer.Id,
                        ProductId = order.ProductId,
                        UnitAmount = order.ProductInfo.Price,
                        Unit = order.Unit,
                        CouponCode = order.CouponCode,
                        Discount = order.Discount,
                        AmountPaid = order.TotalAmount,
                        CartGUID = transactionGuid.ToString(),
                        PaymodeMode = order.PaymentMode,
                        PaymentStatus = order.PaymentStatus,
                        Description = "",
                        CreatedOn = DateTime.Now,
                        CreatedBy = 0,
                        IsDeleted = false,
                        IsActive = true,
                    };


                    finalOrder.Add(SaveOrder(newOrder));
                }
                SaveOrderTracking(-1, orders.FirstOrDefault().CartGUID, "Order Placed");


            }

            return finalOrder;

        }


    }
}