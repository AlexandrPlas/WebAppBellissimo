using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<ImageForDish> ImageForDishs
        {
            get
            {
                return Db.ImageForDishs;
            }
        }

        public bool CreateImageForDish(ImageForDish instance)
        {
            if (instance.ImageId == 0)
            {
                Db.ImageForDishs.InsertOnSubmit(instance);
                Db.ImageForDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateImageForDish(ImageForDish instance)
        {
            ImageForDish cache = Db.ImageForDishs.FirstOrDefault(p => p.ImageId == instance.ImageId);
            if (instance.ImageId != 0)
            {
                cache.DishId = instance.DishId;
                cache.Image = instance.Image;
                Db.ImageForDishs.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveImageForDish(int ImageId)
        {
            ImageForDish instance = Db.ImageForDishs.FirstOrDefault(p => p.ImageId == ImageId);
            if (instance != null)
            {
                Db.ImageForDishs.DeleteOnSubmit(instance);
                Db.ImageForDishs.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
