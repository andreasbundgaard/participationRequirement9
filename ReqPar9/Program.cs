using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    class Program
    {
        static void Main(string[] args)
        {
            FacadeController _facadeController = new FacadeController();
            List<Hop> hops = DatabaseController.GetHop();
            List<Malt> malts = DatabaseController.GetMalt();
            List<Yeast> yeasts = DatabaseController.GetYeast();
            Recipe recipe = new Recipe("TBA", int.Parse(yeasts[0].RawMaterialID), 10, 10, 10, 10, 10, 10);
            recipe.Hops.Add(hops[0]);
            recipe.Malts.Add(malts[0]);
            recipe.Hops[0].BoilTime = "10";
            _facadeController.CreateRecipe(recipe);
        }
    }
}
