/*Márki Zoltán feladat:
 A feladat kiszűri a bizonyos percnél hosszabb számokat és azt listázza
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{

    public class Filter2
    {
        public Filter2(List<Song>[] radioListArray)
        {
            TimeSpan ido;
            int perc = 0;
            bool hiba = false;
            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Hány percnél hosszabb számokra kiváncsi?");
                    perc = int.Parse(Console.ReadLine()) ;
                    if (perc < 0 || perc > 30)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    hiba = true;
                    Console.WriteLine("Hibás adat!");
                }
            } while (hiba);
            for (int i =0 ; i < radioListArray.Length; i++)
            { 
                Console.WriteLine("{0}. állomáson a {1} percnél hosszabb számok: ", i + 1, perc);
                
                    IEnumerable<Song> query = radioListArray[i].Where(list => list.Length >= perc * 60);
                    foreach (Song list in query)
                    {
                        ido = TimeSpan.FromMilliseconds(list.Length * 1000);
                        Console.WriteLine("     {0}:{1} - {2}", list.Band, list.Title, ido.ToString(@"mm\:ss"));
                    }
                       

                
            }
            Console.WriteLine("Visszalépés a menübe: Press Enter");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
