using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuList = new List<MenuItem>();
        private int _count;

        //Create
        public bool AddComboToRepo(MenuItem menuItem)
        {
            if (menuItem == null)
            {
                return false;
            }
            else
            {
                _count++;
                menuItem.ComboNumber = _count;
                _menuList.Add(menuItem);
                return true;
            }
        }
        //Read
        public List<MenuRepository> GetMenuMainList()
        {
            return _menuList;
        }
        public MenuRepository GetMenuItemsByCombo(int combo)
        {
            foreach (MenuItem menu in _menuList)
            {
                if (menu.ComboNumber == combo)
                { return menu; }
            }
            return null;
        }
        //No Update Needed As Of Now
        //Delete
        public bool DeleteCombo(MenuRepository menu)
        {
            bool deleted = _menuList.Remove(menu);
            return deleted;
        }
    }
}
