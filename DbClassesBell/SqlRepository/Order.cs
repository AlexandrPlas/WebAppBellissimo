using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Order> Orders
        {
            get
            {
                return Db.Orders;
            }
        }

        public bool CreateOrder(Order instance)
        {
            if (instance.OrderId == 0)
            {
                Db.Orders.InsertOnSubmit(instance);
                Db.Orders.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateOrder(Order instance)
        {
            Order cache = Db.Orders.FirstOrDefault(p => p.OrderId == instance.OrderId);
            if (instance.OrderId != 0)
            {
                cache.UserId = instance.UserId;
                cache.State = instance.State;
                cache.Price = instance.Price;
                Db.Orders.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveOrder(int OrderId)
        {
            Order instance = Db.Orders.FirstOrDefault(p => p.OrderId == OrderId);
            if (instance != null)
            {
                Db.Orders.DeleteOnSubmit(instance);
                Db.Orders.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
