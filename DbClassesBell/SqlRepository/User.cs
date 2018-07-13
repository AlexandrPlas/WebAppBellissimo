using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DbClassesBell
{
    public partial class SqlRepository
    {

        public IQueryable<User> Users
        {
            get
            {
                return Db.Users;
            }
        }

        public bool CreateUser(User instance)
        {
            if (instance.UserId == 0)
            {
                Db.Users.InsertOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(User instance)
        {
            User cache = Db.Users.FirstOrDefault(p => p.UserId == instance.UserId);
            if (instance.UserId != 0)
            {
                cache.FirstName = instance.FirstName;
                cache.LastName = instance.LastName;
                cache.email = instance.email;
                cache.password = instance.password;
                cache.Adress = instance.Adress;
                cache.Telephone = instance.Telephone;
                cache.Status = instance.Status;
                Db.Users.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveUser(int UserId)
        {
            User instance = Db.Users.FirstOrDefault(p => p.UserId == UserId);
            if (instance != null)
            {
                Db.Users.DeleteOnSubmit(instance);
                Db.Users.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
