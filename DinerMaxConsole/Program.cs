using DinerMax3000.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMaxConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Summ().Execute();
            List<Menu> allMenus = Menu.GetAllMenus();
            allMenus.ForEach(menu =>
           {
               Console.WriteLine(menu.MenuType);
               if (menu.MenuType.Equals("DrinkMenu"))
               {
                   menu.SaveNewMenuItem("Virgin Cubana", "without Alcohol", 7.89);
                   menu.SaveNewMenuItem("B-52", "very strong alcohol", 12.39);
               }
               else
               {
                   menu.SaveNewMenuItem("Cordon Bleu", "mit Käse überbacken", 14.39);

               }
           });
            //DrinkMenu drinkMenu = new DrinkMenu
            //{
            //    Name = "Coctails",
            //    Disclaimer = "Dont drink and drive"
            //};
            //drinkMenu.SaveNewMenu();




            Order hungryGuestsOrder = new Order();
            allMenus.ForEach(menu => menu.Items.ForEach(item => hungryGuestsOrder.items.Add(item)));
            //summerMenu.items.ForEach(item => hungryGuestsOrder.items.Add(item));
            //foreach (MenuItem item in outsideDrinks.items)
            //{
            //    hungryGuestsOrder.items.Add(item);
            //}
            hungryGuestsOrder.items.ForEach(item => Console.WriteLine(item.Title + " " + item.Description));
            Console.WriteLine(hungryGuestsOrder.Total);
            Console.ReadKey();
            //try
            //{
            //    outsideDrinks.AddMenuItem("Free drink", "only for free", 0);

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}
        }
    }
}
