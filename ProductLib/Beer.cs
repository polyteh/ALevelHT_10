using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib
{
    public class Beer: BaseProduct
    {
        // fields
        private const int defaultBeerStorageTerms = 60;

        // constructors 
        public Beer(string prName, double prPrice, DateTime delivData, int storTime= defaultBeerStorageTerms) :base(prName, prPrice, delivData, storTime)
        {
            
        }

        // properties
        public double BottleVolume { get; set; }
    }
}
