using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLib
{
    public class Fish : BaseProduct
    {
        // fields
        private const int defaultFishStorageTerms = 5;

        //constructors
        public Fish(string prName, double prPrice, DateTime delivData, int storTime = defaultFishStorageTerms) : base(prName, prPrice, delivData, storTime)
        {

        }
    }
}
