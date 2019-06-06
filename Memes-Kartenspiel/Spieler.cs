using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes_Kartenspiel
{
    class Spieler
    {
        public int Spielerleben { get; set; }
        public List<Karten> Deck { get; set; }
        public List<Karten> Hand { get; set; }
        public string Name { get; set; }
        public string NameRegex { get; set; }

    }
}
