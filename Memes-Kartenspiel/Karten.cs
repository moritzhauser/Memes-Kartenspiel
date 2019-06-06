using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes_Kartenspiel
{
    class Karten
    {
        //Karten
        public string cardtype { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
        public string RarityColor { get; set; }
        public int Strength { get; set; }

        public string A1Description { get; set; }
        public string A2Description { get; set; }
        public int Attack1 { get; set; }
        public int Attack2 { get; set; }

        //Fighter
        public int Lebenspunkte { get; set; }
        

        //Magic

        //Trap
    }
}
