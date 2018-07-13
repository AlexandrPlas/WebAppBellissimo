using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Ninject;

namespace DbClassesBell
{
    public partial class SqlRepository : IRepository
    {
        public BellaDBDataContext Db { get; set; }

        public SqlRepository()
        {
            Db = new BellaDBDataContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

    }
}
