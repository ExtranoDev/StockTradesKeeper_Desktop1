using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class ProductDAO : StockContext, IDAO<PRODUCT, ProductDetailDTO>
    {
        public bool Delete(PRODUCT entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PRODUCT entity)
        {
            try
            {
                db.PRODUCTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCTs
                            join c in db.CATEGORies on p.CategoryID equals c.ID
                            select new
                            {
                                productName = p.ProductName,
                                categoryName = c.CategoryName,
                                stockAmount = p.StockAmount,
                                price = p.Price,
                                productID = p.ID,
                                categoryID = c.ID
                            }).OrderBy(x => x.productName).ToList();

                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.categoryName;
                    dto.StockAmount = item.stockAmount;
                    dto.Price = item.price;
                    dto.ProductID = item.productID;
                    dto.CategoryID = item.categoryID;
                    products.Add(dto);
                }
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCTs.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                {
                    product.StockAmount = entity.StockAmount;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
