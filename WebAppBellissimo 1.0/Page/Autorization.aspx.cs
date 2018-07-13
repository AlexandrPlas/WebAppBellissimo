using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class Autorization : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OkButton_Click(object sender, EventArgs e)
        {
            AutoOut.Text = "Пользователь не найден";
            
            var AutoUsers = Repository.Users.Where(p => (p.email == email.Text && p.password == password.Text));
            if (AutoUsers==null)
                AutoOut.Text = "Пользователь не найден";
            else
                foreach (User user in AutoUsers){
                    Session["ActiveUser"] = user;
                    AutoOut.Text = "Вы успешно вошли";
                }
           Session.Remove("OrderDishUser");
           Session.Remove("OrderUser");
        }
    }
}