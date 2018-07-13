using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.Adminka
{
    public partial class NewProdPage : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Product reg = new Product();
            if (Name.Text != "") reg.Name = Name.Text;
            if (Kal.Text != "") reg.Calories = Convert.ToInt32(Kal.Text);
            if (Fat.Text != "") reg.Fats = Convert.ToInt32(Fat.Text);
            if (Bel.Text != "") reg.Proteins = Convert.ToInt32(Bel.Text);
            if (Ca.Text != "") reg.Ca = Convert.ToInt32(Ca.Text);
            if (price.Text != "") reg.Price = Convert.ToDecimal(price.Text);

            Repository.CreateProduct(reg);

        }
    }
}