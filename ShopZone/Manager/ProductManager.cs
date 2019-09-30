using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;


namespace ShopZone.Manager
{
    public class ProductManager
    {
        public static Model.Product GetProduct(int id, bool? isActive = null, bool? isDeleted = null)
        {
            Model.Product product = new Model.Product();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var productList = entity.Products.Where(i => i.Id == id).AsQueryable();
                if (isActive != null)
                {
                    productList = productList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    productList = productList.Where(i => i.IsDeleted == isDeleted);
                }
                product = UpdateCommonData(entity, productList).FirstOrDefault();


            }
            return product;

        }
        private static List<Model.Product> UpdateCommonData(ShopZone.Entity.ShopZoneEntities entity, IQueryable<Model.Product> products)
        {
            List<Model.Product> productList = products.ToList();
            using (entity)
            {
                foreach (var product in productList)
                {
                    product.Category = entity.Categories.Where(i => i.Id == product.CategoryId).Select(i => i).FirstOrDefault();
                    //product.Name = (product.NoOfStock > 0) ? product.Name : product.Name + " (Out of Stock)";
                }

            }
            return productList.ToList();
        }
        public static List<Model.Product> GetProducts(bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.Product> products = new List<Model.Product>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var productList = entity.Products.AsQueryable();
                if (isActive != null)
                {
                    productList = productList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    productList = productList.Where(i => i.IsDeleted == isDeleted);
                }


                products = UpdateCommonData(entity, productList).ToList();

            }
            return products;

        }
        public static List<Model.Product> FilterProducts(string filterType, string filterValue, string sortOrder = "ASC")
        {
            List<Model.Product> products = new List<Model.Product>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                products = GetProducts(true, false).OrderBy(i => i.Price).ToList();
                int categoryId = 0;
                if (filterType.ToUpper() == "CATEGORY" && int.TryParse(filterValue, out categoryId))
                {
                    products = products.Where(i => i.CategoryId == categoryId).ToList();
                }
                if (filterType.ToUpper() == "SUBCATEGORY" && int.TryParse(filterValue, out categoryId))
                {
                    products = products.Where(i => i.SubCategoryId == categoryId).ToList();
                }


                if (filterType.ToUpper() == "SEARCH" && !string.IsNullOrEmpty(filterValue))
                {
                    products = products.Where(i => i.Name.ToLower().Contains(filterValue.ToLower())).ToList();
                }
                if (sortOrder == "DESC")
                {
                    products = products.OrderByDescending(i => i.Price).ToList();
                }


            }
            return products;

        }

        public static Model.Product SaveProduct(Model.Product product)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (product.Id <= 0)
                {
                    var existProduct = entity.Products.Where(i => i.IsDeleted == false && i.Name == product.Name).FirstOrDefault();
                    if (existProduct != null)
                    {
                        throw new ArgumentException(string.Format("Product with name '{0}' already exists!!!", product.Name));
                    }

                    var newProduct = new Entity.Product
                    {
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = product.CategoryId,
                        SubCategoryId = product.SubCategoryId,
                        Description = product.Description,
                        NoOfStock = product.NoOfStock,
                        IsFeaturedProduct = product.IsFeaturedProduct,
                        HasOffer = product.HasOffer,
                        CreatedOn = DateTime.Now,
                        CreatedBy = product.CreatedBy,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToProducts(newProduct);
                    entity.SaveChanges();
                    product.Id = newProduct.Id;
                }
                else
                {
                    var existProduct = entity.Products.Where(i => i.IsDeleted == false && i.Id == product.Id).FirstOrDefault();
                    if (existProduct != null)
                    {
                        existProduct.Name = product.Name;
                        existProduct.Price = product.Price;
                        existProduct.CategoryId = product.CategoryId;
                        existProduct.SubCategoryId = product.SubCategoryId;
                        existProduct.Description = product.Description;
                        existProduct.NoOfStock = product.NoOfStock;
                        existProduct.IsFeaturedProduct = product.IsFeaturedProduct;
                        existProduct.HasOffer = product.HasOffer;
                        existProduct.LastUpdatedOn = DateTime.Now;
                        existProduct.LastUpdatedBy = product.LastUpdatedBy;
                        existProduct.IsDeleted = product.IsDeleted;
                        existProduct.IsActive = product.IsActive;

                        entity.SaveChanges();


                    }

                }

            }
            product = GetProduct(product.Id);
            return product;

        }
    }
}