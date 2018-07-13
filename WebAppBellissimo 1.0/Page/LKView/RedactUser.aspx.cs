using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.LKView
{
    public partial class RedactUser : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }
        protected User UserAct
        {
            get
            {
                return (User)Session["ActiveUser"];
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            User reg = Repository.Users.Where(p => p.UserId == UserAct.UserId).Single();
            if (FirstName.Text != "") reg.FirstName = FirstName.Text;
            if (LastName.Text != "") reg.LastName = LastName.Text;
            if (email.Text != "") reg.email = email.Text;
            if (Adress.Text != "") reg.Adress = Adress.Text;
            if (Telephone.Text != "") reg.Telephone = Telephone.Text;
            if (password.Text != "" && password.Text == pass2.Text) reg.password = password.Text;

            Repository.UpdateUser(reg);
            
        }
    }
}