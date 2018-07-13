using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DbClassesBell;
using Ninject;

namespace WebAppBellissimo_1._0
{
    public partial class Default : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            var kinds = Repository.Kinds.ToList();
            foreach (var kind in kinds)
            {
                test1.Text += "Блюдо" +kind.Name;
                test1.Text += "<br />";
            }
       */

        }


    }
}