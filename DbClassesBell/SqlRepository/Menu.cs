using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Menu> Menus
        {
            get
            {
                return Db.Menus;
            }
        }

        public bool CreateMenu(Menu instance)
        {
            if (instance.MenuId == 0)
            {
                Db.Menus.InsertOnSubmit(instance);
                Db.Menus.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMenu(Menu instance)
        {
            Menu cache = Db.Menus.FirstOrDefault(p => p.MenuId == instance.MenuId);
            if (instance.MenuId != 0)
            {
                cache.Name = instance.Name;
                cache.Text = instance.Text;
                cache.Price = instance.Price;
                Db.Menus.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveMenu(int MenuId)
        {
            Menu instance = Db.Menus.FirstOrDefault(p => p.MenuId == MenuId);
            if (instance != null)
            {
                Db.Menus.DeleteOnSubmit(instance);
                Db.Menus.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
