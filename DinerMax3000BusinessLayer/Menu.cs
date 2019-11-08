using DinerMax3000BusinessLayer;
using DinerMax3000BusinessLayer.dsDinerMax3000TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerMax3000.Business
{
    public class Menu
    {
        public string Name { get; set; }
        public List<MenuItem> Items { get; set; }

        private string _menuType = "Menu";
        public string MenuType
        {
            get
            {
                return _menuType;
            }
            set
            {
                _menuType = value;
            }
        }
        private int _databaseId;

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public static List<Menu> GetAllMenus()
        {
            MenuTableAdapter menuTableAdapter = new MenuTableAdapter();
            var dtMenu = menuTableAdapter.GetData();
            return (from dsDinerMax3000.MenuRow menuRow in dtMenu.Rows
                    select new Menu
                    {
                        _databaseId = menuRow.Id,
                        Name = menuRow.Name,
                        MenuType = menuRow.MenuType,
                        Items = GetMenuItemsByMenuId(menuRow.Id)
                    }).ToList();
        }

        public static List<MenuItem> GetMenuItemsByMenuId(int menuId)
        {
            MenuItemTableAdapter menuItemTableAdapter = new MenuItemTableAdapter();
            List<MenuItem> menuItems = new List<MenuItem>();
            var dtMenuItem = menuItemTableAdapter.GetMenuItemsByMenuId(menuId);
            menuItems.AddRange(from dsDinerMax3000.MenuItemRow menuItemRow in dtMenuItem
                               select new MenuItem
                               {
                                   Title = menuItemRow.Name,
                                   Description = menuItemRow.Description,
                                   Price = menuItemRow.Price
                               });
            return menuItems;
        }

        public void SaveNewMenuItem(string Name, string Description, double Price)
        {
            MenuItemTableAdapter menuItemTableAdapter = new MenuItemTableAdapter();
            menuItemTableAdapter.InsertNewMenuItem(Name, Description, Price, _databaseId);
        }

        public void SaveNewMenu()
        {
            MenuTableAdapter menuTableAdapter = new MenuTableAdapter();
            if (this is FoodMenu)
            {
                FoodMenu foodMenu = (FoodMenu)this;
                menuTableAdapter.InsertMenu(foodMenu.Name, foodMenu.MenuType, "", foodMenu.HospitalDirections);
            }
            else
            {
                DrinkMenu drinkMenu = (DrinkMenu)this;
                menuTableAdapter.InsertMenu(drinkMenu.Name, drinkMenu.MenuType, drinkMenu.Disclaimer, "");
            }
        }


        public void AddMenuItem(string Title, string Description, double Price)
        {
            MenuItem item = new MenuItem
            {
                Title = Title,
                Description = Description,
                Price = Price
            };
            Items.Add(item);
        }
    }
}
