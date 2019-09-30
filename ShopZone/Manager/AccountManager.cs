using ShopZone.Entity;
using ShopZone.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;

namespace ShopZone.Manager
{
    public class AccountManager
    {
        public static bool RegisterUser(Model.Customer user)
        {
            var result = false;

            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var userExist = entity.LoginUsers.Where(i => i.EmailId.ToLower() == user.LoginInfo.EmailId.ToLower() &&
                    i.IsActive == true && i.IsDeleted == false
                     ).Select(i => i).FirstOrDefault();

                if (userExist == null)
                {
                    var newUser = new Entity.LoginUser
                    {
                        RoleId = 2,
                        EmailId = user.LoginInfo.EmailId,
                        Password = user.LoginInfo.Password,
                        SecurityQuestion = user.LoginInfo.SecurityQuestion,
                        SecurityAnswer = user.LoginInfo.SecurityAnswer,
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        IsDeleted = false,
                        IsActive = true,


                    };
                    var customer = new Entity.Customer
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Address1 = user.Address1,
                        Address2 = user.Address2,
                        Address3 = user.Address3,
                        City = user.City,
                        Pincode = user.Pincode,
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        LastUpdatedOn = DateTime.Now,
                        LastUpdatedBy = 1,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToLoginUsers(newUser);

                    entity.SaveChanges();


                    customer.UserId = newUser.Id;
                    entity.AddToCustomers(customer);
                    entity.SaveChanges();

                    result = true;

                }



            }

            // EmailHelper.SendMail(user.UserId,  "admin@shopzone.com", "", "Shopezone Registration", "You have resistered successfuly!!!");
            EmailHelper.SendMail("rahulapandey95@gmail.com", "admin@shopzone.com", "", "Shopezone Registration", "You have resistered successfuly!!!");

            return result;
        }
        public static bool SubscribeNewsletter(string emailId)
        {
            var result = false;

            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var userExist = entity.Newsletters.Where(i => i.EmailId.ToLower() == emailId.ToLower() &&
                    i.IsActive == true && i.IsDeleted == false
                     ).Select(i => i).FirstOrDefault();

                if (userExist == null)
                {
                    var newUser = new Entity.Newsletter
                    {

                        EmailId = emailId.Trim(),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        IsDeleted = false,
                        IsActive = true,


                    };
                    entity.AddToNewsletters(newUser);

                    entity.SaveChanges();




                    result = true;

                }
                else
                {
                    throw new ArgumentException("Email Id already subscriibed for Newsletters. Thank you for your interest.");
                }



            }

            return result;
        }
        public static List<Newsletter> GetNewsletters(bool? isActive = true, bool? isDeleted = false)
        {
            List<Newsletter> newsletters = new List<Newsletter>();

            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var newsletterQry = entity.Newsletters.AsQueryable();

                if (isActive != null)
                {
                    newsletterQry = newsletterQry.Where(i => i.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    newsletterQry = newsletterQry.Where(i => i.IsDeleted == isDeleted);

                }
                newsletters = newsletterQry.ToList();


            }

            return newsletters;
        }

        public static Model.LoginUser ValidateCredentials(string emailId, string password)
        {
            Model.LoginUser user = new Model.LoginUser();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                user = entity.LoginUsers.Where(i => i.EmailId.ToLower() == emailId.ToLower() &&
                    i.Password == password && i.IsActive == true && i.IsDeleted == false
                    ).Select(i => i).FirstOrDefault();

                if (user != null)
                {
                    user.UserRole = entity.Roles.Where(i => i.Id == user.RoleId && i.IsActive == true && i.IsDeleted == false
                    ).Select(i => i).FirstOrDefault();
                }



            }
            return user;

        }

        public static Model.LoginUser AuthenticateUser(string emailId, string password, bool remmemberMe)
        {
            Model.LoginUser user = ValidateCredentials(emailId, password);
            // Success, create non-persistent authentication cookie.
            FormsAuthentication.SetAuthCookie(user.EmailId, remmemberMe);

            FormsAuthenticationTicket ticket1 =
               new FormsAuthenticationTicket(
                    1,                                   // version
                    user.EmailId,   // get username  from the form
                    DateTime.Now,                        // issue time is now
                    DateTime.Now.AddMinutes(10),         // expires in 10 minutes
                    remmemberMe,      // cookie is not persistent
                    user.UserRole.Name                              // role assignment is stored
                // in userData
                    );
            HttpCookie cookie1 = new HttpCookie(
              FormsAuthentication.FormsCookieName,
              FormsAuthentication.Encrypt(ticket1));
            HttpContext.Current.Response.Cookies.Add(cookie1);

            HttpContext.Current.Session["UserInfo"] = user;

            return user;
        }

        public static bool UpdatePassword(string emailId, string currentPassword, string newPassword)
        {
            var result = false;

            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var user = entity.LoginUsers.Where(i => i.EmailId.ToLower() == emailId.ToLower() &&
                     i.Password == currentPassword && i.IsActive == true && i.IsDeleted == false
                     ).Select(i => i).FirstOrDefault();

                if (user != null)
                {

                    user.Password = newPassword;
                    user.LastUpdatedBy = user.Id;
                    user.LastUpdatedOn = DateTime.Now;

                    entity.SaveChanges();

                    result = true;

                }



            }

            return result;
        }


        public static Model.Customer GetUser(string emailId, bool? isActive = true, bool? isDeleted = false)
        {
            Model.Customer customer = new Model.Customer();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var customersList = (from u in entity.LoginUsers
                                     join c in entity.Customers on u.Id equals c.UserId
                                     join r in entity.Roles on u.RoleId equals r.Id

                                     select new { L = u, C = c, R = r }
                     ).AsQueryable();
                if (isActive != null)
                {
                    customersList = customersList.Where(i => i.C.IsActive == isActive && i.L.IsActive == isActive && i.R.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    customersList = customersList.Where(i => i.C.IsDeleted == isDeleted && i.L.IsDeleted == isDeleted && i.R.IsDeleted == isDeleted);

                }

                customer = customersList.Where(u => u.L.EmailId == emailId).Select(cus => cus.C).FirstOrDefault();
                customer.LoginInfo = customersList.Where(l => l.L.EmailId == emailId).Select(cus => cus.L).FirstOrDefault();
                customer.LoginInfo.UserRole = customersList.Where(l => l.L.EmailId == emailId).Select(cus => cus.R).FirstOrDefault();



            }
            return customer;

        }


        public static Model.Customer GetUser(int id, bool? isActive = true, bool? isDeleted = false)
        {
            Model.Customer customer = new Model.Customer();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var customersList = (from u in entity.LoginUsers
                                     join c in entity.Customers on u.Id equals c.UserId
                                     join r in entity.Roles on u.RoleId equals r.Id

                                     select new { L = u, C = c, R = r }
                     ).AsQueryable();
                if (isActive != null)
                {
                    customersList = customersList.Where(i => i.C.IsActive == isActive && i.L.IsActive == isActive && i.R.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    customersList = customersList.Where(i => i.C.IsDeleted == isDeleted && i.L.IsDeleted == isDeleted && i.R.IsDeleted == isDeleted);

                }
                customer = customersList.Where(u => u.L.Id == id).Select(cus => cus.C).FirstOrDefault();
                customer.LoginInfo = customersList.Where(u => u.L.Id == id).Select(cus => cus.L).FirstOrDefault();
                customer.LoginInfo.UserRole = customersList.Where(u => u.L.Id == id).Select(cus => cus.R).FirstOrDefault();

            }
            return customer;

        }
        public static List<Model.Customer> GetUsers(bool? isActive = true, bool? isDeleted = false)
        {
            List<Model.Customer> customers = new List<Model.Customer>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {

                var customersList = (from u in entity.LoginUsers
                                     join c in entity.Customers on u.Id equals c.UserId
                                     join r in entity.Roles on u.RoleId equals r.Id

                                     select new { L = u, C = c, R = r }
                     ).AsQueryable();
                if (isActive != null)
                {
                    customersList = customersList.Where(i => i.C.IsActive == isActive && i.L.IsActive == isActive && i.R.IsActive == isActive);

                }
                if (isDeleted != null)
                {
                    customersList = customersList.Where(i => i.C.IsDeleted == isDeleted && i.L.IsDeleted == isDeleted && i.R.IsDeleted == isDeleted);

                }

                customers = customersList.Select(i => i.C).ToList();
                foreach (var c in customers)
                {
                    c.LoginInfo = customersList.Where(cus => cus.C.Id == c.Id).Select(cus => cus.L).FirstOrDefault();
                    c.LoginInfo.UserRole = customersList.Where(cus => cus.C.Id == c.Id).Select(cus => cus.R).FirstOrDefault();
                }

            }
            return customers;

        }


    }
}