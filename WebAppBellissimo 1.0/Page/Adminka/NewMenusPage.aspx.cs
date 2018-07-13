using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.Adminka
{
    public partial class NewMenusPage : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        int stage = 0;


        private class DMclass
        {
            public String Dish { get; set; }
            public String Repast { get; set; }
            public DMclass() { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            stage = Convert.ToInt32(Request.QueryString["stage"]);

            switch (stage)
            {
                case 0:
                    Name.Visible = true; MText.Visible = true; 
                    Recept.Visible = false; Repast.Visible = false; Button2.Visible = false;
                    price.Visible = false; 
                    break;
                case 1:
                    Name.Visible = false; MText.Visible = false; 
                    Recept.Visible = true; Repast.Visible = true; Button2.Visible = true;
                    price.Visible = false; 
                    break;
                case 2:
                    Name.Visible = false; MText.Visible = false; 
                    Recept.Visible = false; Repast.Visible = false; Button2.Visible = false;
                    price.Visible = true; 
                    break;
                case 3:
                    Name.Visible = false; MText.Visible = false; 
                    Recept.Visible = false; Repast.Visible = false; Button2.Visible = false;
                    price.Visible = false; 
                    break;

                default:

                    break;
            }

            List<MenuDish> pAdd = new List<MenuDish>();
            List<DMclass> pAddd = new List<DMclass>();
            pAdd = (List<MenuDish>)Session["ListMenuDish"];
            if (pAdd != null)
                foreach (MenuDish asd in pAdd)
                {
                    DMclass assf = new DMclass();
                    assf.Dish = Repository.Dishs.Where(p => p.DishId == asd.DishId).FirstOrDefault().Name;
                    assf.Repast = Repository.Repasts.Where(p=> p.RepastId == asd.RepastId).FirstOrDefault().Name;
                    pAddd.Add(assf);
                }

            decimal priceAdd = 0;
            if (Session["MenusAdd"] != null)
            priceAdd = ((DbClassesBell.Menu)Session["MenusAdd"]).Price > 0 ? (decimal)((DbClassesBell.Menu)Session["MenusAdd"]).Price : priceAdd;
            if (stage == 2 && price.Text == "")
            {
                if (pAdd != null)
                    foreach (MenuDish asd in pAdd)
                    {
                        priceAdd += (decimal)Repository.Dishs.Where(p => p.DishId == asd.DishId).FirstOrDefault().Price;
                    }
                price.Text = Convert.ToString(Math.Round(priceAdd, 2));
            }

            DbClassesBell.Menu dAdd = (DbClassesBell.Menu)Session["MenusAdd"];
            if (dAdd != null)
            {
                MenuLabel.Text = "Наименование меню: " + dAdd.Name + "<br/>" +
                                  "Описание: " + dAdd.Text + "<br/>" +
                                  "Стоимость: " + priceAdd;
            }

            List<String> ListMenq = new List<string>();
            foreach(Repast sd in Repository.Repasts)
                ListMenq.Add(sd.Name);

            List<String> ListDish = new List<string>();
            foreach (Dish sd in Repository.Dishs)
                ListDish.Add(sd.Name);

            Recept.DataSource = ListDish.OrderBy(p => p);
            Recept.DataBind();

            Repast.DataSource = ListMenq;
            Repast.DataBind();

            Repeater1.DataSource = pAddd;
            Repeater1.DataBind();
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string url;
            url = "/Page/Adminka/NewMenusPage.aspx";
            if (stage == 0)
            {
                url = "/Page/Adminka/NewMenusPage.aspx?stage=1";
                DbClassesBell.Menu tempd = new DbClassesBell.Menu();
                tempd.Name = Name.Text;
                tempd.Text = MText.Text;
                Session["MenusAdd"] = tempd;
            }
            if (stage == 1)
            {
                url = "/Page/Adminka/NewMenusPage.aspx?stage=2";
                MenuDish tempP = new MenuDish();
                tempP.DishId = Repository.Dishs.Where(p => p.Name == Recept.Text).FirstOrDefault().DishId;
                tempP.RepastId = Repository.Repasts.Where(p => p.Name == Repast.Text).FirstOrDefault().RepastId;
                List<MenuDish> tempLP = new List<MenuDish>();
                if (Session["ListMenuDish"] != null) tempLP = (List<MenuDish>)Session["ListMenuDish"];
                tempLP.Add(tempP);
                Session["ListMenuDish"] = tempLP;
            }
            if (stage == 2)
            {
                url = "/Page/Adminka/NewMenusPage.aspx?stage=3";
                if (Session["MenusAdd"] != null)
                {
                    DbClassesBell.Menu temp = (DbClassesBell.Menu)Session["MenusAdd"];
                    temp.Price = Convert.ToDecimal(price.Text);
                    Session["MenusAdd"] = temp;
                }
            }
            if (stage == 3)
            {
                url = "/Page/Adminka/MenusAd.aspx";
                List<MenuDish> pAdd = (List<MenuDish>)Session["ListMenuDish"];
                if (Session["MenusAdd"] != null && pAdd != null)
                {
                    DbClassesBell.Menu temp = (DbClassesBell.Menu)Session["MenusAdd"];
                    Repository.CreateMenu(temp);
                    int id = Repository.Menus.Where(p => p.Name == temp.Name).FirstOrDefault().MenuId;
                    foreach (MenuDish asd in pAdd)
                    {
                        MenuDish tempp = asd;
                        tempp.MenuId = id;
                        Repository.CreateMenuDish(tempp);
                    }
                }
                Session.Remove("ListMenuDish");
                Session.Remove("MenusAdd");   
            }




            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url;
            url = "/Page/Adminka/NewMenusPage.aspx?stage=1";
            if (stage == 1)
            {
                MenuDish tempP = new MenuDish();
                tempP.DishId = Repository.Dishs.Where(p => p.Name == Recept.Text).FirstOrDefault().DishId;
                tempP.RepastId = Repository.Repasts.Where(p => p.Name == Repast.Text).FirstOrDefault().RepastId;
                List<MenuDish> tempLP = new List<MenuDish>();
                if (Session["ListMenuDish"] != null) tempLP = (List<MenuDish>)Session["ListMenuDish"];
                tempLP.Add(tempP);
                Session["ListMenuDish"] = tempLP;
            }

            Response.Redirect(url);

        }

    }
}