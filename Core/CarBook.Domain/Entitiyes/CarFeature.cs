using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entitiyes
{
    public class CarFeature
    {
        public int CarFeatureId { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public int FeatureID { get; set; }
        public Feature feature { get; set; }
        public bool Available { get; set; }
    }
}
