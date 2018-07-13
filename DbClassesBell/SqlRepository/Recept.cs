using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Recept> Recepts
        {
            get
            {
                return Db.Recepts;
            }
        }

        public bool CreateRecept(Recept instance)
        {
            if (instance.ReceptId == 0)
            {
                Db.Recepts.InsertOnSubmit(instance);
                Db.Recepts.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRecept(Recept instance)
        {
            Recept cache = Db.Recepts.FirstOrDefault(p => p.ReceptId == instance.ReceptId);
            if (instance.ReceptId != 0)
            {
                cache.DishId = instance.DishId;
                cache.Specific = instance.Specific;
                Db.Recepts.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRecept(int ReceptId)
        {
            Recept instance = Db.Recepts.FirstOrDefault(p => p.ReceptId == ReceptId);
            if (instance != null)
            {
                Db.Recepts.DeleteOnSubmit(instance);
                Db.Recepts.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
