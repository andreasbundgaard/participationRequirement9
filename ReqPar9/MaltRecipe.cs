using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class MaltRecipe
    {
        public int RawMaterialID { get; set; }
        public int Quantity { get; set; }

        public MaltRecipe(int rawMaterialID, int quantity)
        {
            RawMaterialID = rawMaterialID;
            Quantity = quantity;
        }
    }
}
