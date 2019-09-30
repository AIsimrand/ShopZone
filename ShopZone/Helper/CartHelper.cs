using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ShopZone.Helper
{
    public class CartHelper
    {
        public static List<ShopzoneCart> CurrentCart
        {
            get
            {
                List<ShopzoneCart> cart = new List<ShopzoneCart>();
                if (HttpContext.Current.Session["UserShopzoneCart"] != null)
                {
                    cart = (List<ShopzoneCart>)HttpContext.Current.Session["UserShopzoneCart"];
                }
                return cart;
            }
            set
            {
                List<ShopzoneCart> cart = new List<ShopzoneCart>();
                if (value == null)
                {
                    value = new List<ShopzoneCart>();

                }
                HttpContext.Current.Session["UserShopzoneCart"] = value;
            }
        }
        public static List<ShopzoneCart> AddToCart(int productId)
        {
            var cart = CurrentCart;

            Guid cartGUID = new Guid(HttpContext.Current.Session.SessionID);
            if (cart.Any(i => i.ProductId == productId))
            {

                var products = cart.Select(i => new ShopzoneCart
                {
                    ProductId = i.ProductId,
                    ProductInfo = i.ProductInfo,
                    Unit = i.Unit,
                    CartGUID = cartGUID.ToString()
                }).ToList();

                foreach (var item in products)
                {
                    if (item.ProductId == productId)
                    {
                        item.Unit = item.Unit + 1;
                    }

                }

                cart = products;
            }
            else
            {

                var product = ProductManager.GetProduct(productId, true, false);

                var cartItemDetail = new ShopzoneCart
                {
                    ProductId = product.Id,
                    ProductInfo = product,
                    Unit = 1,
                    CartGUID = cartGUID.ToString()
                };
                cart.Add(cartItemDetail);
            }

            CurrentCart = cart;

            return CurrentCart;
        }

        public static List<ShopzoneCart> RemoveFromCart(int productId)
        {
            var cart = CurrentCart;
            if (cart.Any(i => i.ProductId == productId))
            {
                var cartItem = cart.Where(i => i.ProductId == productId).FirstOrDefault();
                cart.Remove(cartItem);
            }
            CurrentCart = cart;
            return CurrentCart;

        }

        public static List<ShopzoneCart> ApplyDiscount(string couponCode, decimal discount)
        {
            var cart = CurrentCart;
            if (cart.Any())
            {
                cart.ForEach(i =>
                {
                    i.Discount = discount;
                    i.CouponCode = couponCode;
                });
            }
            CurrentCart = cart;
            return CurrentCart;

        }

        public static List<CustomerOrder> PlaceOrder(List<ShopzoneCart> cartOrder)
        {
            List<CustomerOrder> order = new List<CustomerOrder>();

            order = OrderManager.PlaceOrder(cartOrder);
            return order;
        }

        public static List<ShopzoneCart> ClearCart()
        {
            var cart = CurrentCart;
            cart.Clear();
            CurrentCart = cart;
            return CurrentCart;
        }

    }
}