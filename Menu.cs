using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    public class Menu
    {
        public List<string> menuItems { get; set; }

        //Menüpontok nélkül hozza létre a menüt, késöbb bövithető pontokkal
        public Menu()
        {
            menuItems = new List<string>();
            menuItems.Insert(0, "Exit");
        }
        
        //Ugy hozhatunk létre menüt hogy elölre megadjuk a menüpontokat, késöbb bövíthető
        public Menu(List<string> menuitems)
        {
            this.menuItems = menuitems;
            menuItems.Insert(0, "Exit");
        }
        public Menu(string[] menuitems)
        {
            this.menuItems = new List<string>(menuitems);
            menuItems.Insert(0, "Exit");
        }

        //Menü bövitésére
        public void plusMenu(params string[] addmenu)
        {
            for (int i = 0; i < addmenu.Length; i++)
            {
                menuItems.Add(addmenu[i]);
            }

        }
        //Menü kiíratása
        public void showMenu()
        {
            Console.Clear();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == (menuItems.Count - 1)) { Console.WriteLine("{0}. {1}", 0, menuItems[0]); }

                else { Console.WriteLine("{0}. {1}", i + 1, menuItems[i + 1]); }
            }
        }
        
    }
    
}
