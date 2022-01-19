using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ProductManagement.Models;
using ProductManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration config;
        private readonly string connStr;

        public ProductController(IConfiguration config)
        {
            this.config = config;
            connStr = config.GetConnectionString("DatabaseConnection");
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetProductList()
        {
            var ProRepo = new ProductRepository(connStr);

            var result = ProRepo.GetProductList();

            if (result.Item1.Count > 0)
            {
                var ResultArra = from x in result.Item1
                                 select new[]
                                 {
                                Convert.ToString(x.Product_ID),
                                Convert.ToString(x.Product_Name),
                                Convert.ToString(x.Product_Category),
                                Convert.ToString(x.Product_SKU),
                                Convert.ToString(x.Product_Price),
                                Convert.ToString(x.Is_Active),
                                string.Format("{0:MM/dd/yyyy hh:mm:ss tt}", x.Created_Date),
                                Convert.ToString(x.Product_Description),
                         };

                return Json(ResultArra);
            }
            else
            {
                string[] ResultArrNull = new string[0];
                return Json(ResultArrNull);
            }
        }

        public JsonResult GetCategoryList()
        {
            var ProRepo = new ProductRepository(connStr);

            var result = ProRepo.GetProductCategoryList();

            if (result.Item1.Count > 0)
            {
                List<SelectListItem> CategoryList = new List<SelectListItem>();
                for (int i = 0; i < result.Item1.Count; i++)
                {
                    CategoryList.Add(new SelectListItem
                    {
                        Value = result.Item1[i].Product_Category_ID.ToString(),
                        Text = result.Item1[i].Product_Category,
                    });
                }
                return Json(CategoryList);
            }
            else
            {
                return Json("0");
            }
        }

        public JsonResult InUpProduct(ProductModel obj)
        {
            var ProRepo = new ProductRepository(connStr);
            var result=ProRepo.InsertUpdateProduct(obj);
            return Json("1");
        }

        public JsonResult DeleteProduct(string ID)
        {
            var ProRepo = new ProductRepository(connStr);
            var result = ProRepo.DeleteProduct(Convert.ToInt32(ID));
            return Json("1");
        }

    }
}
