using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public partial class SqlRepository
    {
        public IQueryable<Product> Products
        {
            get
            {
                return Db.Products;
            }
        }

        public bool CreateProduct(Product instance)
        {
            if (instance.ProductId == 0)
            {
                Db.Products.InsertOnSubmit(instance);
                Db.Products.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product instance)
        {
            Product cache = Db.Products.FirstOrDefault(p => p.ProductId == instance.ProductId);
            if (instance.ProductId != 0)
            {
                cache.Name = instance.Name;
                cache.Calories = instance.Calories;
                cache.Price = instance.Price;
                cache.Proteins = instance.Proteins;
                cache.Fats = instance.Fats;
                cache.Ca = instance.Ca;
                Db.Products.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveProduct(int ProductId)
        {
            Product instance = Db.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (instance != null)
            {
                Db.Products.DeleteOnSubmit(instance);
                Db.Products.Context.SubmitChanges();
                return true;
            }

            return false;
        }

    }
}
