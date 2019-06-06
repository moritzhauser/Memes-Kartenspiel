using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Memes_Kartenspiel
{
    class Program
    {
        static void Main(string[] args)

        {
            int currentplayer = 1;

            List<Karten> SpielfeldP1 = new List<Karten>();
            List<Karten> SpielfeldP2 = new List<Karten>();

            //nameneingabe fuer spieler
            Console.WriteLine("Spieler 1 Name:");
            string Name1 = Console.ReadLine();
            Console.WriteLine("Spieler 2 Name:");
            string Name2 = Console.ReadLine();
            Spieler Spieler1 = new Spieler() { Spielerleben = 50, Name = Name1 };
            Spieler Spieler2 = new Spieler() { Spielerleben = 50, Name = Name1 };

            //regex einbauen
            string input1 = Name1;
            string input2 = Name2; ;
            //if name = beginnt mit a = 1
            string pattern1 = @"([a-iA-I]*)";
            string pattern2 = @"([i-rA-R]*)";
            string pattern3 = @"([r-zR-Z]*)";

           
            Match S1match1 = Regex.Match(input1, pattern1);
            Match S1match2 = Regex.Match(input1, pattern2);
            Match S1match3 = Regex.Match(input1, pattern3);
            Match S2match1 = Regex.Match(input2, pattern1);
            Match S2match2 = Regex.Match(input2, pattern2);
            Match S2match3 = Regex.Match(input2, pattern3);


            //realtext erstellen der 3 Teile vom Alphabet und den Namen ausgiebt
            string realtext1;
            string S1text1 = S1match1 + "a";
            if (S1text1.Length != 1)
            {
                realtext1 = S1text1;
            }
            string S1text2 = S1match2 + "b";
            if (S1text1.Length != 1)
            {
                realtext1 = S1text2;
            }
            string S1text3 = S1match3 + "c";
            if (S1text1.Length != 1)
            {
                realtext1 = S1text3;
            }
            else
                throw new System.ArgumentException("Falsche Zeichen eingegeben");


            string realtext2;
            string S2text1 = S2match1 + "a";
            if (S2text1.Length != 1)
            {
                realtext2 = S2text1;
            }
            string S2text2 = S2match2 + "b";
            if (S2text1.Length != 1)
            {
                realtext2 = S2text2;
            }
            string S2text3 = S2match3 + "c";
            if (S2text1.Length != 1)
            {
                realtext2 = S2text3;
            }
            else
                throw new System.ArgumentException("Falsche Zeichen eingegeben");




            //Karten erstellen machen wir dann aus Dateien
            string path = @"../../../Memes/Karten.txt";



            //Karten zum Spieldeck
            List<Karten> Spieldeck = new List<Karten>();




            //Karten Thanos = new Karten() { Lebenspunkte = 50, Attack1 = 20, Attack2 = 20 };//prozent von Gegner leben zb
            string allesdatei = System.IO.File.ReadAllText(path);     
            string[] Splitlist = allesdatei.Split(';');
            foreach (string item in Splitlist)
            {
                string[] Splittmp = item.Split(',');//cardtype,Name,Rarity,RarityColor,Strength,Description,A1Description,A2Description,Attack1,Attack2,Lebenspunkte,FighterSkill,MagicSkill,TrapSkill
                Console.WriteLine(item.Split(',')[1]);
                Console.ReadLine();
                //index Fehler
                Console.WriteLine(Splittmp.Length);
                int strength = Convert.ToInt32(Splittmp[4]);
                int attack1 = Convert.ToInt32(Splittmp[8]);
                int attack2 = Convert.ToInt32(Splittmp[9]);
                int lebenspunkte = Int32.Parse(Splittmp[10]);
                //Convert RarityColor string to ConsoleColor
                Karten abc = new Karten() { cardtype = Splittmp[0], Name = Splittmp[1], Rarity = Splittmp[2], RarityColor = Splittmp[3], Strength = strength, Description = Splittmp[5], A1Description = Splittmp[6], A2Description = Splittmp[7], Attack1 = attack1, Attack2 = attack2, Lebenspunkte = lebenspunkte, Photopath = "x" };
                Spieldeck.Add(abc);

                //Kartennamen und Skillwert ausgeben
                if (Splittmp[0] == "Fighter")
                {
                    Fighter Fightera = new Fighter() { Name = Splittmp[1], FighterSkill = Splittmp[11] };
                    Console.WriteLine(Fightera.Name + Fightera.FighterSkill);
                }

                else if (Splittmp[0] == "Magic")
                {
                    Magic Magica = new Magic() { Name = Splittmp[1], MagicSkill = Splittmp[12] };
                    Console.WriteLine(Magica.Name + Magica.MagicSkill);
                }
                else if (Splittmp[0] == "Trap")
                {
                    Trap Trapa = new Trap() { Name = Splittmp[1], TrapSkill = Splittmp[13] };
                    Console.WriteLine(Trapa.Name + Trapa.TrapSkill);
                }
                else
                    throw new Exception("Falscher oder kein Kartentyp angegeben");
                

            }

           

            Console.WriteLine(Spieldeck.Count);


            

            
 

            //Zahl berechnen wieviele Karten insgesamt für Spieler, immer gerade 
            //int forInt = 0;                                 nur mit dem geht ungerade Kartenanzahl
            //if (Spieldeck.Count % 2 == 0) { }
            //else {forInt = Spieldeck.Count - 1; }


            List<Karten> Spieler1deck = new List<Karten>();
            List<Karten> Spieler2deck = new List<Karten>();
            List<Karten> Spieler1hand = new List<Karten>();
            List<Karten> Spieler2hand = new List<Karten>();

            //Karten verteilen an Decks
            Random rnd = new Random();
            int tmp = Spieldeck.Count;
            if (Spieldeck.Count % 2 == 1)
            {
                tmp -= 1;

            }
            tmp -= Spieldeck.Count / 2 ;
            int a = tmp;
            for (int i = 0; i < tmp; i++)
            {
                int random = rnd.Next(0, Spieldeck.Count);

             

                Spieler1deck.Add(Spieldeck[random]);
                Spieldeck.RemoveAt(random);
                tmp -= 1;
                i -= 1;
                        
            }

            for (int i = 0; i < a; i++)
            {
                int random = rnd.Next(0, Spieldeck.Count);

               

                Spieler2deck.Add(Spieldeck[random]);
                Spieldeck.RemoveAt(random);
                a -= 1;
                i -= 1;
                
            }
         


       


            //Karten vom Deck in die Hand wenn weniger als 5 Karten in der Hand sind //add ifs 
            void addcardstohand()
            {
                for (int i = 0; i < Spieler1deck.Count; i++)
                {
                    Spieler1hand.Add(Spieler1deck[i]);
                    Spieler1deck.RemoveAt(i);
                    Spieler2hand.Add(Spieler2deck[i]);
                    Spieler2deck.RemoveAt(i);
                }
            }
            addcardstohand();
            
            
            void Kartenlegen()
            {
                if (currentplayer  != 0)
                {
                    Console.WriteLine("Spieler 1 welche Karte auf das Spielfeld legen? (0-4)");
                    int wahlp1 = Convert.ToInt32(Console.ReadLine());
                    SpielfeldP1.Add(Spieler1hand[wahlp1]);
                }

                else if (currentplayer  == 0)
                {
                    Console.WriteLine("Spieler 2 welche Karte auf das Spielfeld legen? (0-4)");              
                    int wahlp2 = Convert.ToInt32(Console.ReadLine());
                    SpielfeldP2.Add(Spieler2hand[wahlp2]);
                }
            }


            void attack()
            {
                string x = "0";
                string y = "0";
                string z = "0";
                string k = "0";
                string l = "0";
                string m = "0";

                int x1 = 0;
                int y1 = 0;
                int z1 = 0;
                int k1 = 0;
                int l1 = 0;
                int m1 = 0;



                if (currentplayer != 0)
                {
                    Console.WriteLine("Spieler 1 Welche Karte zum Angreifen wählen?");
                    x = Console.ReadLine();
                    Console.WriteLine("Spieler 1 Welchen Angriff wählen?");
                    y = Console.ReadLine();
                    Console.WriteLine("Spieler 1 Welche Karte vom Gegner angreifen");
                    z = Console.ReadLine();
                    x1 = Int32.Parse(x);
                    y1 = Int32.Parse(y);
                    z1 = Int32.Parse(z);
                }
                
                

                else if (currentplayer == 0)
                {
                    Console.WriteLine("Spieler 2 Welche Karte zum Angreifen wählen?");
                    k = Console.ReadLine();
                    Console.WriteLine("Spieler 2 Welchen Angriff wählen?");
                    l = Console.ReadLine();
                    Console.WriteLine("Spieler 2 Welche Karte vom Gegner angreifen");
                    m = Console.ReadLine();
                    k1 = Int32.Parse(k);
                    l1 = Int32.Parse(l);
                    m1 = Int32.Parse(m);

                }
                
                




                //Leben werden von Spieler und Karte abgezogen
                if (currentplayer != 0)
                {

                    if (SpielfeldP1[x1].cardtype == "Fighter")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte -= SpielfeldP1[x1].Attack1;
                            if (SpielfeldP2[z1].Lebenspunkte > 0) { Console.WriteLine("Deine Karte lebt noch"); }
                            else if (SpielfeldP2[z1].Lebenspunkte < 0)
                            {
                                Console.WriteLine("Deine Karte ist tot");
                                Spieler2.Spielerleben -= SpielfeldP2[z1].Lebenspunkte;
                            }
                        }
                        else
                        {
                            SpielfeldP1[z1].Lebenspunkte -= SpielfeldP1[x1].Attack2;
                            if (SpielfeldP2[z1].Lebenspunkte > 0) { Console.WriteLine("Deine Karte lebt noch"); }
                            else if (SpielfeldP2[z1].Lebenspunkte < 0)
                            {
                                Console.WriteLine("Deine Karte ist tot");
                                Spieler2.Spielerleben -= SpielfeldP2[z1].Lebenspunkte;
                            }
                        }
                    }


                    if (SpielfeldP1[x1].cardtype == "Trap")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte *= SpielfeldP1[x1].Attack1;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geschaedigt");


                        }
                        else
                        {
                            SpielfeldP1[z1].Lebenspunkte *= SpielfeldP1[x1].Attack2;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geschaedigt");

                        }
                    }


                    if (SpielfeldP1[x1].cardtype == "Magic")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte *= SpielfeldP1[x1].Attack1;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geheilt");
                            //if xz1 = x1 return dazu geben

                        }
                        else
                        {
                            SpielfeldP1[x1].Lebenspunkte *= SpielfeldP1[x1].Attack2;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geheilt");

                        }
                    }
                }

                if (currentplayer == 0)
                {
                    if (SpielfeldP1[x1].cardtype == "Fighter")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte -= SpielfeldP1[x1].Attack1;
                            if (SpielfeldP2[z1].Lebenspunkte > 0) { Console.WriteLine("Deine Karte lebt noch"); }
                            else if (SpielfeldP2[z1].Lebenspunkte < 0)
                            {
                                Console.WriteLine("Deine Karte ist tot");
                                Spieler2.Spielerleben -= SpielfeldP2[z1].Lebenspunkte;
                            }
                        }
                        else
                        {
                            SpielfeldP1[z1].Lebenspunkte -= SpielfeldP1[x1].Attack2;
                            if (SpielfeldP2[z1].Lebenspunkte > 0) { Console.WriteLine("Deine Karte lebt noch"); }
                            else if (SpielfeldP2[z1].Lebenspunkte < 0)
                            {
                                Console.WriteLine("Deine Karte ist tot");
                                Spieler2.Spielerleben -= SpielfeldP2[z1].Lebenspunkte;
                            }
                        }
                    }


                    if (SpielfeldP1[x1].cardtype == "Trap")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte *= SpielfeldP1[x1].Attack1;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geschaedigt");


                        }
                        else
                        {
                            SpielfeldP1[z1].Lebenspunkte *= SpielfeldP1[x1].Attack2;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geschaedigt");

                        }
                    }


                    if (SpielfeldP1[x1].cardtype == "Magic")
                    {
                        if (y1 == 0)
                        {
                            SpielfeldP2[z1].Lebenspunkte *= SpielfeldP1[x1].Attack1;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geheilt");
                            //if xz1 = x1 return dazu geben

                        }
                        else
                        {
                            SpielfeldP1[x1].Lebenspunkte *= SpielfeldP1[x1].Attack2;
                            Console.WriteLine("Deine Karte wurde um"
                                + SpielfeldP1[x1].Attack1 * SpielfeldP2[z1].Lebenspunkte + "geheilt");

                        }
                    }
                }
            }


            

            void Zug()
            {
                addcardstohand();
                int attackpoint = 0;
                while (attackpoint < 1)
                {
                    
                    Console.WriteLine("Karten legen oder Angreifen K A N");
                    string choice = Console.ReadLine();

                    if (choice == "K") { Kartenlegen(); }
                    else if (choice == "A") { attack(); attackpoint += 1; }
                    else if (choice == "N") { attackpoint += 1; }

                }
                
                if (Spieler1.Spielerleben > 0)
                {
                    Console.WriteLine("Spieler 1 hat "+ Spieler1.Spielerleben+" leben");
                    if (Spieler2.Spielerleben > 0)
                    {
                        Console.WriteLine("Spieler 2 hat " + Spieler2.Spielerleben + " leben");
                        if (currentplayer == 1) { 
                        currentplayer = 0;
                        }
                        else currentplayer = 1; 


                        Zug();
                    }
                    else Console.WriteLine(Spieler2.Name + " keine Leben mehr "+ Spieler1.Name + " hat gewonnen");
               

                    System.IO.File.WriteAllText(@"../../../Memes/Gewinner.txt", realtext1);

                }
                else Console.WriteLine(Spieler1.Name + " keine Leben mehr " + Spieler2.Name + " hat gewonnen");
         

                System.IO.File.WriteAllText(@"../../../Memes/Karten.txt", realtext2);
            }




            addcardstohand();
            Console.WriteLine(Spieler1hand.Count);
            Console.ReadKey();


            Zug();







        }
    }









}



















