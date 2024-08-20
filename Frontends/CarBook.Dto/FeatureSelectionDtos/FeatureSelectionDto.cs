using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.FeatureSelectionDto
{
    public class FeatureSelectionDto
    {
        public int FeatureID { get; set; }
        public bool IsSelected { get; set; }
        public int CarID { get; set; }
    }
}
