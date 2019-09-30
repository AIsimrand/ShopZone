using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopZone.Entity
{




    public partial class LoginUser
    {



        public Role UserRole { get; set; }

    }
    public partial class Category
    {

        public List<Category> SubCategories { get; set; }

        public bool HasSubCategories { get { return (this.SubCategories != null && this.SubCategories.Any()); } }

    }
    public partial class Customer
    {

        public LoginUser LoginInfo { get; set; }
    }
    public partial class Product
    {


        public string ImageUrl { get { 
            Random rnd = new Random();
            int randomNo = rnd.Next(1, 100000000);
            return "/Content/ProductImage/" + this.Id.ToString() + ".jpg?rand=" + randomNo.ToString();
        }
        }


        public Category Category { get; set; }

    }


    public partial class CustomerOrder
    {

        public decimal TotalAmount { get { return this.UnitAmount * this.Unit; } }
        public Customer Customer { get; set; }
        public Product OrderProduct { get; set; }
        public List<OrderTracking> OrderTrackingStatus { get; set; }
        public string TransitStatus { get; set; }

    }
    public class ShippingAddress
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }



    }
    public class ShopzoneCart
    {
        public int ProductId { get; set; }
        public Product ProductInfo { get; set; }
        public string CartGUID { get; set; }
        public int Unit { get; set; }
        public LoginUser Customer { get { return (LoginUser)HttpContext.Current.Session["UserInfo"]; } }
        public ShippingAddress ShippingDetails { get; set; }
        public string CouponCode { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount
        {
            get
            {
                var finalPrice = this.ProductInfo.Price * this.Unit;

                if (this.Discount > 0)
                {

                    finalPrice = finalPrice - (finalPrice * (this.Discount / 100));
                }
                return Math.Round(finalPrice, 2);

            }
        }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }


    }

}