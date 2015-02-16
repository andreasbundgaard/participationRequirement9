using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class HopRecipe
    {
        public int RawMaterialID { get; set; }
        public int Quantity {get; set;}
        public int BoilTime { get; set; }

        public HopRecipe(int rawMaterialID, int quantity, int boilTime)
        {
            RawMaterialID = rawMaterialID;
            Quantity = quantity;
            BoilTime = boilTime;
        }
    }
}
