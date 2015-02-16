using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    public class FacadeController
    {
        public void CreateRecipe(Recipe recipe)
        {
           int recipeID = DatabaseController.CreateRecipe(recipe);
           foreach (Malt malt in recipe.Malts)
           {
               DatabaseController.CreateRecipeMalt(malt, recipeID);
           }
           foreach (Hop hop in recipe.Hops)
           {
               DatabaseController.CreateRecipeHop(hop, recipeID);
           }


        }
    }
}
