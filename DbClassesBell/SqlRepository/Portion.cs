using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Portion> Portions
        {
            get
            {
                return Db.Portions;
            }
        }

        public bool CreatePortion(Portion instance)
        {
            if (instance.PortionId == 0)
            {
                Db.Portions.InsertOnSubmit(instance);
                Db.Portions.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdatePortion(Portion instance)
        {
            Portion cache = Db.Portions.FirstOrDefault(p => p.PortionId == instance.PortionId);
            if (instance.PortionId != 0)
            {
                cache.DishId = instance.DishId;
                cache.ProductId = instance.ProductId;
                cache.PrMass = instance.PrMass;
                Db.Portions.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemovePortion(int PortionId)
        {
            Portion instance = Db.Portions.FirstOrDefault(p => p.PortionId == PortionId);
            if (instance != null)
            {
                Db.Portions.DeleteOnSubmit(instance);
                Db.Portions.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
