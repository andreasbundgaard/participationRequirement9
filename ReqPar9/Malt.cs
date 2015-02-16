using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class Malt : RawMaterial
    {
        public string EBC { get; set; }
        public string Mash { get; set; }

        public Malt (string name, string quantity, string rawMaterialID, string threshold, string ebc, string mash) 
        {
            Name = name;
            Quantity = quantity;
            RawMaterialID = rawMaterialID;
            Threshold = threshold;
            EBC = ebc;
            Mash = mash;
        }
    }
}
