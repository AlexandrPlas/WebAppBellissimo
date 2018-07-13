using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<Recall> Recalls
        {
            get
            {
                return Db.Recalls;
            }
        }

        public bool CreateRecall(Recall instance)
        {
            if (instance.RecallId == 0)
            {
                Db.Recalls.InsertOnSubmit(instance);
                Db.Recalls.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRecall(Recall instance)
        {
            Recall cache = Db.Recalls.FirstOrDefault(p => p.RecallId == instance.RecallId);
            if (instance.RecallId != 0)
            {
                cache.UserId = instance.UserId;
                cache.DishId = instance.DishId;
                cache.Text = instance.Text;
                Db.Recalls.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRecall(int RecallId)
        {
            Recall instance = Db.Recalls.FirstOrDefault(p => p.RecallId == RecallId);
            if (instance != null)
            {
                Db.Recalls.DeleteOnSubmit(instance);
                Db.Recalls.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
