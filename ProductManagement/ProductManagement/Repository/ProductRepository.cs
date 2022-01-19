using ProductManagement.Helper;
using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Repository
{
    public class ProductRepository
    {
        private readonly string connStr;
        public ProductRepository(string connStr)
        {
            this.connStr = connStr;
        }
        public Tuple<List<ProductCategoryModel>, string> GetProductCategoryList()
        {
            List<ProductCategoryModel> ProductCategoryList = null;
            string responsemessage = string.Empty;

            var db = new DapperHelper(connStr);
            var result = db.QueryMultiple("SP_GetProductCategory", null, reader =>
            {
                ProductCategoryList = reader.Read<ProductCategoryModel>().ToList();
                responsemessage = "success";
            });
            responsemessage = string.IsNullOrEmpty(result.Success) ? responsemessage : result.Success;
            return Tuple.Create(
                ProductCategoryList,
                responsemessage
            );
        }
        public Tuple<List<ProductModel>, string> GetProductList()
        {
            List<ProductModel> ProductList = null;
            string responsemessage = string.Empty;

            var db = new DapperHelper(connStr);
            var result = db.QueryMultiple("SP_GetProducts", null, reader =>
            {
                ProductList = reader.Read<ProductModel>().ToList();
                responsemessage = "success";
            });
            responsemessage = string.IsNullOrEmpty(result.Success) ? responsemessage : result.Success;
            return Tuple.Create(
                ProductList,
                responsemessage
            );
        }

         public string InsertUpdateProduct(ProductModel obj)
          {
              var db = new DapperHelper(connStr);
              var result = db.Execute("SP_InUPProduct", new { obj.Product_ID,obj.Product_Name,obj.Product_Price,obj.Product_SKU,obj.Product_Description,obj.Is_Active,obj.Product_Category_ID });
              return result.Success;
          }

        public string DeleteProduct(int Product_ID)
        {
            var db = new DapperHelper(connStr);
            var result = db.Execute("SP_DeleteProduct", new { Product_ID });
            return result.Success;
        }

    }
}
