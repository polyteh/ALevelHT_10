using ProductLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLib
{
    public class Warehouse
    {
        // fieds
        /// <summary>
        /// place to save all our stuff
        /// </summary>
        private List<BaseProduct> warehouseList = new List<BaseProduct>();
        private DateTime currentDate=new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        // constructors
        /// <summary>
        /// make a new warehouse
        /// </summary>
        /// <param name="warName">warehouse name</param>
        /// <param name="warCap">warehouse capacity</param>
        public Warehouse(string warName, int warCap)
        {
            this.Name = warName;
            this.Capacity = warCap;
        }

        // properties
        public string Name { get; set; }
        public int Capacity { get; private set; }

        // methods
        /// <summary>
        /// add product to the warehouse
        /// </summary>
        /// <param name="newProductItem"></param>
        public void AddProduct(BaseProduct newProductItem)
        {
            warehouseList.Add(newProductItem);
        }
        /// <summary>
        /// return all products in the warehouse
        /// </summary>
        /// <returns>array [] of BaseProducts</returns>
        public BaseProduct[] GetProduct()
        {
            return warehouseList.ToArray();
        }
        /// <summary>
        /// return current Time in the warehouse (simulation mode)
        /// </summary>
        /// <returns></returns>
        public DateTime GetCurTime()
        {
            return currentDate;
        }
        /// <summary>
        /// update warehouse list, remove expired items with Update method
        /// </summary>
        /// <param name="dateToUpdate"></param>
        public void UpdateToDate(DateTime dateToUpdate)
        {
            currentDate = dateToUpdate;
            this.UpdateList();
        }
        /// <summary>
        /// 
        /// </summary>
        private void UpdateList()
        {
            warehouseList.RemoveAll(item =>item.DaysToExpirationFrom(currentDate) ==-1);
        }
        public int GetNumberOfProducts()
        {
            return warehouseList.Count();
        }


    }
}
