using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    class Program : MenuDialog.selectionListener
    {
        private readonly MenuDialog dialog;

        private readonly List<Song>[] radioSongsArray;
        public Program()
        {
            //Beolvassuk a fájlt
            FileProcesser processer = new FileProcesser("zenemusor.txt");

            //Beolvassuk a rádiók lejátszási listáit
            radioSongsArray = processer.getRadioSongsArray();

            //Megnyitjuk a menüválasztót
            dialog = new MenuDialog();
            dialog.setSelectionListener(this);
            dialog.runMenu();
            Console.Clear();
            Console.WriteLine("Köszönjük hogy használta a programunkat!");
            Console.ReadLine();
        }

        private int selectedIndex;
        public void selectedItem(int index)
        {
            selectedIndex = index;
            switch (index)
            {
                case 11:
                    //  Console.Clear();
                    new Filter1(radioSongsArray);
                    // Console.ReadLine();
                    break;
                case 12:
                    new Filter2(radioSongsArray);
                    break;
                case 21:
                    new Search1(radioSongsArray);
                    break;
                case 22:
                    new Search2(radioSongsArray);
                    break;
                case 31:
                    new Sort1(radioSongsArray);
                    break;
                case 32:
                    new Sort2(radioSongsArray);
                    break;
            }
            dialog.runMenu();
        }
    }
}

