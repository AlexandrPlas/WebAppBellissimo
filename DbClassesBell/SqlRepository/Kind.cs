using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Kind> Kinds
        {
            get
            {
                return Db.Kinds;
            }
        }

        public bool CreateKind(Kind instance)
        {
            if (instance.KindId == 0)
            {
                Db.Kinds.InsertOnSubmit(instance);
                Db.Kinds.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateKind(Kind instance)
        {
            Kind cache = Db.Kinds.FirstOrDefault(p => p.KindId == instance.KindId);
            if (instance.KindId != 0)
            {
                cache.Name = instance.Name;
                Db.Kinds.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveKind(int KindId)
        {
            Kind instance = Db.Kinds.FirstOrDefault(p => p.KindId == KindId);
            if (instance != null)
            {
                Db.Kinds.DeleteOnSubmit(instance);
                Db.Kinds.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
