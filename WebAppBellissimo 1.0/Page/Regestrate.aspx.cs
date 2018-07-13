using System;
using System.Collections.Generic;

using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class Regestrate : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OkButton_Click(object sender, EventArgs e)
        {

            if (password.Text == "" || email.Text == "") {
                RegOut.Text = "Введите данные";
            } else if (!Repository.Users.Where(p => p.email == email.Text).Any() && password.Text==pass2.Text) {
                User reg = new User();
                reg.FirstName=FirstName.Text;
                reg.LastName=LastName.Text;
                reg.email=email.Text;
                reg.Adress=Adress.Text;
                reg.Telephone=Telephone.Text;
                reg.password=password.Text;
                reg.Status = "user";

                Repository.CreateUser(reg);

                RegOut.Text = "Успешная регистрация";
            }
            else RegOut.Text = "Такой пользователь есть";
        }
    }
}