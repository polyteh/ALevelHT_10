using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib
{
    public abstract  class BaseProduct
    {
        private DateTime expiratioDate;

        // constructors
        /// <summary>
        /// abstract class for any kind of products
        /// </summary>
        /// <param name="prName">product name</param>
        /// <param name="prPrice">product price</param>
        /// <param name="delivData">product delivery data</param>
        /// <param name="storTime">product terms of storage</param>
        public BaseProduct(string prName, double prPrice, DateTime delivData, int storTime)
        {
            this.Name = prName;
            this.Price = prPrice;
            this.DeliveryTime = delivData;
            this.StorageTerms = storTime;
            expiratioDate = this.DeliveryTime.AddDays(this.StorageTerms);
        }

        // properties
        /// <summary>
        /// product name
        /// </summary>
        public string Name { get; set; }
        public double Price { get; set; }

        public DateTime DeliveryTime { get; private set; }

        public int StorageTerms { get; private set; }

        // methods
        /// <summary>
        /// return product Expiration date
        /// </summary>
        /// <returns>Expiration date in DataTime format</returns>
        public DateTime ExpirationDate()
        {
            return expiratioDate;
        }
        /// <summary>
        /// return number of days product can be store more starting from check day
        /// </summary>
        /// <param name="dayToCheck">return number of days, int</param>
        /// <returns></returns>
        public int DaysToExpirationFrom(DateTime dayToCheck)
        {
            if (expiratioDate>dayToCheck)
            {
                return (expiratioDate - dayToCheck).Days;
            }
            else
            {
                return -1;
            }
        }
        


    }
}
