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
        public ConsoleColor RarityColor { get; set; }
        public int Strength { get; set; }

        public string A1Description { get; set; }
        public string A2Description { get; set; }
        public int attack1 { get; set; }
        public int attack2 { get; set; }

        //Fighter
        public int Lebenspunkte { get; set; }
        

        //Magic

        //Trap
    }
}
