using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class Yeast : RawMaterial
    {
        public string Attenuation { get; set; }

        public Yeast (string name, string quantity, string rawMaterialID, string threshold, string attenuation) 
        {
            Name = name;
            Quantity = quantity;
            RawMaterialID = rawMaterialID;
            Threshold = threshold;
            Attenuation = attenuation;

        }
    }
}
