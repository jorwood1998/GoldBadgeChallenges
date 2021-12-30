using MenuPocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuClass
{
   public class MenuRepository
    { 
    private readonly List<Menu> _menuList = new List<Menu>();
    private int _count;
    
        //Create
        public bool AddComboToRepo(Menu menuItem)
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
        public List<Menu> GetMenuMailList()
        {
            return _menuList;
        }
        public Menu GetMenuItemsByCombo(int combo)
        {
            foreach (Menu menu in _menuList)
            {
                if(menu.ComboNumber == combo)
                { return menu;}
            }
            return null;
        }
        //No Update Needed As Of Now
        //Delete
        public bool DeleteCombo(Menu menu)
        {
            bool deleted = _menuList.Remove(menu);
            return deleted;
        }
    }
}
