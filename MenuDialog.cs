using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class MenuDialog
    {
        public int menuID;

        public interface selectionListener
        {
            void selectedItem(int index);
        }

        private selectionListener listener;
        public void setSelectionListener(selectionListener listener)
        {
            this.listener = listener;
        }



        Menu fmenu = new Menu(); //főmenü létrehozása
        List<SubMenu> almenu = new List<SubMenu>() {  //almenük a kulcsokkal
                new SubMenu() { key = 1 },
                new SubMenu() { key = 2 },
                new SubMenu() { key = 3 },
            };

        public void check(ref int selection, List<string> menu)
        {
            try
            {
                selection = int.Parse(Console.ReadLine());
                if (selection >= menu.Count)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Hibás érték!!!");
                selection = 0;
                Console.ReadLine();

            }


        }
        public void runMenu()  //jelenleg ugy müködik mint egy telefonos menü, azaz minden menü rész 1-9ig lehet
        {
            bool run = true;
            int selection = 0;
            int deep = 0;
            menuID = 0;
            while (run)
            {
                int i = 0;

                while (i < almenu.Count && almenu[i].key != menuID)
                {
                    i++;
                }
                if (i < almenu.Count)
                {
                    deep = almenu[i].key;    // a deep változo számolja hogy milyen mélységben vagyunk az almenüben
                    almenu[i].showMenu();
                    check(ref selection, almenu[i].menuItems);
                    if (selection == 0)
                    {
                        menuID = 0;
                    }
                    else
                    {
                        menuID = deep * 10 + selection;
                    }


                }
                else if (menuID > 0)  //még úgy müködik a program hogy csak almenüből lehet futtatni programot
                {

                    listener.selectedItem(menuID);

                }
                else
                {
                    menuID = 0;
                    deep = 0;
                    fmenu.showMenu();
                    check(ref selection, fmenu.menuItems);
                    if (selection == 0)
                    {
                        run = false;
                    }
                    else
                    {
                        menuID = deep * 10 + selection;
                    }

                }


            }


        }




        public MenuDialog()
        {


            fmenu.plusMenu("Filter", "Search", "Sort");
            almenu[0].plusMenu("Gábor1: Feladat megnevezése", "Zoltán: Egy adott idöpontnál hosszabb számok listázása");
            almenu[1].plusMenu("Gábor2: feladat", "Zoltán: Adott időben mit játszottak a rádiok?");
            almenu[2].plusMenu("Gábor3: feladat", "Zoltán: Egy adott állomás számainak hossza növekvő sorrendbe.");
            

            

            

        }
         
    }


 
}
