using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Dish> Dishs
        {
            get
            {
                return Db.Dishs;
            }
        }

        public bool CreateDish(Dish instance)
        {
            if (instance.DishId == 0)
            {
                Db.Dishs.InsertOnSubmit(instance);
                Db.Dishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDish(Dish instance)
        {
            Dish cache = Db.Dishs.FirstOrDefault(p => p.DishId == instance.DishId);
            if (instance.DishId != 0)
            {
                cache.Name = instance.Name;
                cache.Base = instance.Base;
                cache.Difficult = instance.Difficult;
                cache.KindId = instance.KindId;
                Db.Dishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveDish(int DishId)
        {
            Dish instance = Db.Dishs.FirstOrDefault(p => p.DishId == DishId);
            if (instance != null)
            {
                Db.Dishs.DeleteOnSubmit(instance);
                Db.Dishs.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
