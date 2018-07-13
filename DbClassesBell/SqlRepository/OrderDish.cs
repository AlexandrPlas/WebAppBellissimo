using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<OrderDish> OrderDishs
        {
            get
            {
                return Db.OrderDishs;
            }
        }

        public bool CreateOrderDish(OrderDish instance)
        {
            if (instance.OrderDishId == 0)
            {
                Db.OrderDishs.InsertOnSubmit(instance);
                Db.OrderDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateOrderDish(OrderDish instance)
        {
            OrderDish cache = Db.OrderDishs.FirstOrDefault(p => p.OrderDishId == instance.OrderDishId);
            if (instance.OrderDishId != 0)
            {
                cache.DishId = instance.DishId;
                cache.OrderId = instance.OrderId;
                cache.Count = instance.Count;
                Db.OrderDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveOrderDish(int OrderDishId)
        {
            OrderDish instance = Db.OrderDishs.FirstOrDefault(p => p.OrderDishId == OrderDishId);
            if (instance != null)
            {
                Db.OrderDishs.DeleteOnSubmit(instance);
                Db.OrderDishs.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
