using Google.Protobuf.Collections;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class CustomerDAO : StockContext, IDAO<CUSTOMER, CustomerDetailDTO>
    {
        public bool Delete(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == entity.ID);
                customer.isDeleted = true;
                customer.DeleteDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == ID);
                customer.isDeleted = false;
                customer.DeleteDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Insert(CUSTOMER entity)
        {
            try
            {
                db.CUSTOMERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<CustomerDetailDTO> Select(bool isDeleted = false)
        {
            try
            {
                List<CustomerDetailDTO> Customers = new List<CustomerDetailDTO>();
                var list = db.CUSTOMERs.Where(x => x.isDeleted == isDeleted).ToList();
                foreach ( var item in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.CustomerName = item.CustomerName;
                    dto.ID = item.ID;
                    Customers.Add(dto);
                }
                return Customers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
                customer.ID = entity.ID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
