using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class  Hop : RawMaterial
    {
        public string Alpha { get; set; }

        public Hop (string name, string quantity, string rawMaterialID, string threshold, string alpha) 
        {
            Name = name;
            Quantity = quantity;
            RawMaterialID = rawMaterialID;
            Threshold = threshold;
            Alpha = alpha;

        }
    }
}
        