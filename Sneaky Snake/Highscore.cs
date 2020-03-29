using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Adele
{
    class Highscore
    {
        public List<Player> TopTen;

        public Highscore()
        {
            TopTen = new List<Player>();
        }

        public void ShowHighscore()
        {
            TopTen = TopTen.OrderByDescending(b => b.Score).ToList();
            if (TopTen.Count == 0) Console.WriteLine("No highscore available.");
            else
            {
                Console.WriteLine("HIGHSCORE:");
                for (int i = 0; i < 10 && i < TopTen.Count; i++)
                {
                    Console.WriteLine("{0} - {1}", TopTen[i].Name, TopTen[i].Score);
                }
            }

            Console.WriteLine("\n\n\nPress ENTER to return.");
            Console.Read();
            Console.Clear();
        }
    }
}
