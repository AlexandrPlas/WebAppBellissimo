using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<OrderMenu> OrderMenus
        {
            get
            {
                return Db.OrderMenus;
            }
        }

        public bool CreateOrderMenu(OrderMenu instance)
        {
            if (instance.OrderMenuId == 0)
            {
                Db.OrderMenus.InsertOnSubmit(instance);
                Db.OrderMenus.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateOrderMenu(OrderMenu instance)
        {
            OrderMenu cache = Db.OrderMenus.FirstOrDefault(p => p.OrderMenuId == instance.OrderMenuId);
            if (instance.OrderMenuId != 0)
            {
                cache.MenuId = instance.MenuId;
                cache.OrderId = instance.OrderId;
                cache.Count = instance.Count;
                Db.OrderMenus.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveOrderMenu(int OrderMenuId)
        {
            OrderMenu instance = Db.OrderMenus.FirstOrDefault(p => p.OrderMenuId == OrderMenuId);
            if (instance != null)
            {
                Db.OrderMenus.DeleteOnSubmit(instance);
                Db.OrderMenus.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
