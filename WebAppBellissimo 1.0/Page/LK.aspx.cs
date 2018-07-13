using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class LK : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();

        protected User UserAct
        {   get{
            return (User)Session["ActiveUser"];}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }
    }
}