/*Márki Zoltán része:
    Bekérünk egy idöpontot és megkeressük hogy az egyes csatornákon akkor melyik zene szólt!
    */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Search2
    {
       
        public Search2 (List<Song>[] radioListArray)
        {
            int ido=0;
            bool error = false;
            Console.Clear();
            do
            {
                try
                {
                    Console.Write("Melyik óra: ");
                    ido = int.Parse(Console.ReadLine()) * 3600;
                    Console.Write("Melyik percben: ");
                    ido += int.Parse(Console.ReadLine()) * 60;
                    Console.Write("Hanyadik másodpecben: ");
                    ido += int.Parse(Console.ReadLine());
                    
                    if (ido < 0 || ido>86399)
                    {
                        throw new FormatException();
                    }

                }
                catch (FormatException)
                {
                    error = true;
                    Console.WriteLine("Rossz adatok");
                }
            } while (error);

            for (int i=0; i < radioListArray.Length; i++)
            {
                int j = 0;
                int sumtime = 0;
                while (sumtime<ido)
                {
                    sumtime += radioListArray[i][j].Length;
                    j++;
                }
                Console.WriteLine("A megadott idöbem az {0}. csatornán ez a szám ment:", i+1);
                Console.WriteLine("{0}:{1}", radioListArray[i][j].Band, radioListArray[i][j].Title);
                

                
            }
            Console.WriteLine("Visszalépés a menübe: Press Enter");
            Console.ReadLine();
            Console.Clear();


        }
        

    }
}
