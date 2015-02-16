using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqPar9
{
    class Recipe
    {
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public int YeastID { get; set; }
        public int Efficiency { get; set; }
        public int Attnuation { get; set; }
        public int FinalGravity { get; set; }
        public int BoilVolume { get; set; }
        public int Contents { get; set; }
        public int Volume { get; set; }
        List<Malt> Malts { get; set; }
        List<Hop> Hops { get; set; }

        public Recipe(string name, int yeastID, int efficiency, int attnuation, int finalGravity, int boilVolume, int contents, int volume)
        {
            Name = name;
            YeastID = yeastID;
            Efficiency = efficiency;
            Attnuation = attnuation;
            FinalGravity = finalGravity;
            BoilVolume = boilVolume;
            Contents = contents;
            Volume = volume;
            Malts = new List<Malt>();
            Hops = new List<Hop>();
        }
    }
}
