using ShopZone.Manager;
using ShopZone.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model = ShopZone.Entity;

namespace ShopZone.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
                BindCategories();
                if (id > 0)
                {
                    BindProductDetails(id);
                }
            }
        }
        private void BindCategories()
        {
            var categories = CategoryManager.GetCategories(isActive: true, isDeleted: false);
            if (categories != null)
            {
                ddlCategory.DataSource = categories;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataBind();
            }

        }

        private void BindProductDetails(int id)
        {
            var product = ProductManager.GetProduct(id, isActive: null, isDeleted: false);
            if (product != null)
            {
                txtName.Text = product.Name;
                txtDescription.Text = product.Description;
                ddlCategory.SelectedValue = product.CategoryId.ToString();
                BindSubCategories(product.CategoryId);
                ddlSubCategory.SelectedValue = product.SubCategoryId.ToString();
                txtPrice.Text = product.Price.ToString();
                txtNoOfStock.Text = product.NoOfStock.ToString();
                chkIsFeaturedProduct.Checked = product.IsFeaturedProduct;
                chkHasOffer.Checked = product.HasOffer;
                chkIsActive.Checked = product.IsActive;


            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedValue== string.Empty && ddlSubCategory.SelectedValue == string.Empty )
            {
                throw new ArgumentException("Please select valid category.");
            }

            int id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            var product = new Model.Product();
            if (id > 0)
            {
                product = ProductManager.GetProduct(id, isActive: null, isDeleted: false);

            }

            product.Name = txtName.Text;
            product.Description = txtDescription.Text;
            product.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
           
            product.SubCategoryId = Convert.ToInt32(ddlSubCategory.SelectedValue);

            product.Price = Convert.ToDecimal(txtPrice.Text);
            product.NoOfStock = Convert.ToInt32(txtNoOfStock.Text);
            product.IsFeaturedProduct = chkIsFeaturedProduct.Checked;
            product.IsActive = chkIsActive.Checked;
            product.HasOffer = chkHasOffer.Checked;
            product = ProductManager.SaveProduct(product);
            UploadFile(product.Id);
            Response.Redirect("~/Admin/Products.aspx", false);
        }

        private void UploadFile(int id)
        {
            if (fuProductImage.HasFile)
            {
                try
                {
                    string ext = System.IO.Path.GetExtension(this.fuProductImage.PostedFile.FileName);
                    if ((fuProductImage.PostedFile.ContentType == "image/jpeg" || fuProductImage.PostedFile.ContentType == "image/jpg") && (ext.ToLower() == ".jpg"))
                    {
                        if (fuProductImage.PostedFile.ContentLength < 102400)
                        {
                            string filename = Path.GetFileName(fuProductImage.FileName);

                            fuProductImage.SaveAs(Server.MapPath("~/Content/ProductImage/") + id.ToString() + ext);
                            lblMessage.Text = "Upload status: File uploaded!";
                        }
                        else
                            lblMessage.Text = "Upload status: The file has to be less than 100 kb!";
                    }
                    else
                        lblMessage.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSubCategories(int.Parse(ddlCategory.SelectedValue));
           
        }

        private void BindSubCategories(int catId)
        {
            var categories = CategoryManager.GetSubCategories(catId, isActive: true, isDeleted: false);
            if (categories != null)
            {
                ddlSubCategory.DataSource = categories;
                ddlSubCategory.DataValueField = "Id";
                ddlSubCategory.DataTextField = "Name";
                ddlSubCategory.DataBind();
            }
        }
    }
}