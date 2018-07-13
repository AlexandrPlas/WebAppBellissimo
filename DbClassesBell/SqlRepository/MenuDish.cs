using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<MenuDish> MenuDishs
        {
            get
            {
                return Db.MenuDishs;
            }
        }

        public bool CreateMenuDish(MenuDish instance)
        {
            if (instance.MenuDishId == 0)
            {
                Db.MenuDishs.InsertOnSubmit(instance);
                Db.MenuDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMenuDish(MenuDish instance)
        {
            MenuDish cache = Db.MenuDishs.FirstOrDefault(p => p.MenuDishId == instance.MenuDishId);
            if (instance.MenuDishId != 0)
            {
                cache.DishId = instance.DishId;
                cache.MenuId = instance.MenuId;
                cache.RepastId = instance.RepastId;
                Db.MenuDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveMenuDish(int MenuDishId)
        {
            MenuDish instance = Db.MenuDishs.FirstOrDefault(p => p.MenuDishId == MenuDishId);
            if (instance != null)
            {
                Db.MenuDishs.DeleteOnSubmit(instance);
                Db.MenuDishs.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
