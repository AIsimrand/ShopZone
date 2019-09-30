using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity = ShopZone.Entity;
using Model = ShopZone.Entity;


namespace ShopZone.Manager
{
    public class CategoryManager
    {
        public static Model.Category GetCategory(int id, bool? isActive = null, bool? isDeleted = null)
        {
            Model.Category category = new Model.Category();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var categoryList = entity.Categories.Where(i => i.Id == id).AsQueryable();
                if (isActive != null)
                {
                    categoryList = categoryList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    categoryList = categoryList.Where(i => i.IsDeleted == isDeleted);
                }
                category = categoryList.Select(cat => cat).FirstOrDefault();
            }
            if (category != null && category.ParentId != null && category.ParentId > 0)
            {
                category.SubCategories = GetSubCategories(category.Id, isActive, isDeleted);
            }

            return category;

        }

        public static List<Model.Category> GetCategories(bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.Category> categories = new List<Model.Category>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var categoryList = entity.Categories.AsQueryable();
                if (isActive != null)
                {
                    categoryList = categoryList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    categoryList = categoryList.Where(i => i.IsDeleted == isDeleted);
                }
                categories = categoryList.Select(cat => cat).ToList();
            }
            List<Model.Category> finalCategories = new List<Model.Category>();
            if (categories.Any())
            {
                finalCategories = categories.Where(i => i.ParentId == null).ToList();
                finalCategories.ForEach(item => item.SubCategories = categories.Where(i => i.ParentId == item.Id).ToList());
            }
            return finalCategories;

        }

        public static List<Model.Category> GetSubCategories(int parentCategoryId, bool? isActive = null, bool? isDeleted = null)
        {
            List<Model.Category> categories = new List<Model.Category>();
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                var categoryList = entity.Categories.Where(i => i.ParentId == parentCategoryId).AsQueryable();
                if (isActive != null)
                {
                    categoryList = categoryList.Where(i => i.IsActive == isActive);
                }
                if (isDeleted != null)
                {
                    categoryList = categoryList.Where(i => i.IsDeleted == isDeleted);
                }
                categories = categoryList.Select(cat => cat).ToList();
            }
            return categories;

        }

        //public static List<Model.Category> GetCategoryTree(bool? isActive = true, bool? isDeleted = false)
        //{
        //    List<Model.Category> categories = GetCategories(isActive, isDeleted);
        //    List<Model.Category> finalCategories = categories.Where(i => i.ParentId == null).ToList();
        //    foreach (var item in finalCategories)
        //    {
        //        List<Model.Category> subCategories = categories.Where(i => i.ParentId == item.Id).ToList();
        //        item.SubCategories = subCategories;
        //    }
        //    return finalCategories;

        //}



        public static Model.Category SaveCategory(Model.Category category)
        {
            using (ShopZone.Entity.ShopZoneEntities entity = new Entity.ShopZoneEntities())
            {
                if (category.Id <= 0)
                {
                    var existCategory = entity.Categories.Where(i => i.IsDeleted == false && i.Name == category.Name).FirstOrDefault();
                    if (existCategory != null)
                    {
                        throw new ArgumentException(string.Format("Category with name '{0}' already exists!!!", category.Name));
                    }

                    var newCategory = new Entity.Category
                    {
                        Name = category.Name,
                        Description = category.Description,
                        ParentId = category.ParentId,
                        IsTopBrand = category.IsTopBrand,
                        CreatedBy = category.CreatedBy,
                        CreatedOn = DateTime.Now,
                        IsDeleted = false,
                        IsActive = true,
                    };
                    entity.AddToCategories(newCategory);
                    entity.SaveChanges();

                    category.Id = newCategory.Id;
                }
                else
                {
                    var existCategory = entity.Categories.Where(i => i.IsDeleted == false && i.Id == category.Id).FirstOrDefault();
                    if (existCategory != null)
                    {
                        existCategory.Name = category.Name;
                        existCategory.Description = category.Description;
                        existCategory.ParentId = category.ParentId;
                        existCategory.IsTopBrand = category.IsTopBrand;
                        existCategory.LastUpdatedOn = DateTime.Now;
                        existCategory.LastUpdatedBy = category.LastUpdatedBy;
                        existCategory.IsDeleted = category.IsDeleted;
                        existCategory.IsActive = category.IsActive;

                        entity.SaveChanges();
                    }

                }
            }
            category = GetCategory(category.Id);
            return category;

        }
    }
}