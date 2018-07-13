using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Repast> Repasts
        {
            get
            {
                return Db.Repasts;
            }
        }

        public bool CreateRepast(Repast instance)
        {
            if (instance.RepastId == 0)
            {
                Db.Repasts.InsertOnSubmit(instance);
                Db.Repasts.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRepast(Repast instance)
        {
            Repast cache = Db.Repasts.FirstOrDefault(p => p.RepastId == instance.RepastId);
            if (instance.RepastId != 0)
            {
                cache.Name = instance.Name;
                Db.Repasts.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRepast(int RepastId)
        {
            Repast instance = Db.Repasts.FirstOrDefault(p => p.RepastId == RepastId);
            if (instance != null)
            {
                Db.Repasts.DeleteOnSubmit(instance);
                Db.Repasts.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
