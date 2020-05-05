/*Márki Zoltán Felada:
    Vállaszton melyik rádio számait listáza hossz szerint növekvő sorrendben?
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Sort2
    {
        
       

        public Sort2(List<Song>[] radioListArray)
        {
            TimeSpan ido;
            int i = 0;
            bool hiba = false;
            Console.Clear();
            do
            {
                try
                {
                    Console.WriteLine("Melyik rádiora végezzük el a feladatot?");
                    i = int.Parse(Console.ReadLine());
                    if (i < 1 || i > 3)
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    hiba = true;
                    Console.WriteLine("Nincs ilyen rádio állomás vállasz 1-3 között");
                }

            } while (hiba);

                Console.WriteLine("Az {0}. rádió Top 3 leghosszabb számai:", i);
                IEnumerable<Song> query = radioListArray[i-1].OrderBy(tmb => tmb.Length);
                foreach (Song tmb in query)
                {
                    ido = TimeSpan.FromMilliseconds(tmb.Length * 1000);
                    Console.WriteLine("     {0}:{1} - {2}", tmb.Band, tmb.Title, ido.ToString(@"mm\:ss"));
                }
            Console.WriteLine("Nyomj meg egy gombot a folytatáshoz!");
            Console.ReadKey();
            Console.Clear();

        }
           
    }
}
