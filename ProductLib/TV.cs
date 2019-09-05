using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib
{
    public class TV : BaseProduct
    {
        // fields
        private const int defaultTVStorageTerms = 365*4;

        // constructors
        public TV(string prName, double prPrice, DateTime delivData, int storTime = defaultTVStorageTerms) : base(prName, prPrice, delivData, storTime)
        {

        }

        // properties
        public int SizeInInches { get; set; }
    }
}
