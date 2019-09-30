using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;


namespace ShopZone.Manager
{
    public class CouponManager
    {
        public static Model.Coupon GetCoupon(int id, bool? isActive = null, bool? isDeleted = null)
        {
            Model.Coupon coupon = new Model.Coupon();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var couponList = entity.Coupons.Where(i => i.Id == id).AsQueryable();
                if (isActive != null)
                {
                    couponList = couponList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    couponList = couponList.Where(i => i.IsDeleted == isDeleted);
                }
                coupon = couponList.Select(cat => cat).FirstOrDefault();
            }
           

            return coupon;

        }
        public static Model.Coupon GetCouponByCode(string code)
        {
            Model.Coupon coupon = new Model.Coupon();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var categoryList = entity.Coupons.Where(i => i.CouponCode == code).AsQueryable();
              
                coupon = categoryList.Select(cat => cat).FirstOrDefault();
            }


            return coupon;

        }
        public static List<Model.Coupon> GetCoupons(bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.Coupon> coupons = new List<Model.Coupon>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var CouponList = entity.Coupons.AsQueryable();
                if (isActive != null)
                {
                    CouponList = CouponList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    CouponList = CouponList.Where(i => i.IsDeleted == isDeleted);
                }
                coupons = CouponList.Select(cat => cat).ToList();
            }

            return coupons;

        }





        public static Model.Coupon SaveCoupon(Model.Coupon coupon)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (coupon.Id <= 0)
                {
                    var existCategory = entity.Coupons.Where(i => i.IsDeleted == false && i.Name == coupon.Name).FirstOrDefault();
                    if (existCategory != null)
                    {
                        throw new ArgumentException(string.Format("Coupon with name '{0}' already exists!!!", coupon.Name));
                    }
                   
                    var newCoupon = new Entity.Coupon
                    {
                        Name = coupon.Name,
                        Description = coupon.Description,
                        CouponCode = coupon.CouponCode,         
                        Discount = coupon.Discount,
                        CreatedBy = coupon.CreatedBy,
                        CreatedOn = DateTime.Now,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToCoupons(newCoupon);
                    entity.SaveChanges();

                    coupon.Id = newCoupon.Id;
                }
                else
                {
                    var existCoupon = entity.Coupons.Where(i => i.IsDeleted == false && i.Id == coupon.Id).FirstOrDefault();
                    if (existCoupon != null)
                    {
                        existCoupon.Name = coupon.Name;
                        existCoupon.Description = coupon.Description;
                        existCoupon.CouponCode = coupon.CouponCode;
                        existCoupon.Discount = coupon.Discount;
                        existCoupon.LastUpdatedOn = DateTime.Now;
                        existCoupon.LastUpdatedBy = coupon.LastUpdatedBy;
                        existCoupon.IsDeleted = coupon.IsDeleted;
                        existCoupon.IsActive = coupon.IsActive;

                        entity.SaveChanges();
                    }

                }
            }
            coupon = GetCoupon(coupon.Id);
            return coupon;

        }
    }
}