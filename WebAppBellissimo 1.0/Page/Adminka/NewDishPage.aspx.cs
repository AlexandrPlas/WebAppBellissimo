using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page.Adminka
{
    public partial class NewDishPage : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        int stage = 0;

        private class Porca
        {
            public String Product { get; set;}
            public int PrMass { get;set;}
            public Porca() { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            stage = Convert.ToInt32(Request.QueryString["stage"]);

        switch (stage){
            case 0:
                Name.Visible=true; Base.Visible = true; Difficult.Visible = true; Kind.Visible=true; MText.Visible = true;
                Product.Visible=false; gramm.Visible = false; price.Visible = false; Button2.Visible = false;
                File1.Visible = false;
                break;
            case 1:
                Name.Visible=false; Base.Visible = false; Difficult.Visible = false; Kind.Visible=false; MText.Visible = false;
                Product.Visible=true; gramm.Visible = true;  price.Visible = false; Button2.Visible = true;
                File1.Visible = false;
                break;
            case 2:
                Name.Visible=false; Base.Visible = false; Difficult.Visible = false; Kind.Visible=false; MText.Visible = false;
                Product.Visible=false; gramm.Visible = false; price.Visible = true; Button2.Visible = false;
                File1.Visible = false;
                break;
            case 3: 
                Name.Visible=false; Base.Visible = false; Difficult.Visible = false; Kind.Visible=false; MText.Visible = false;
                Product.Visible=false; gramm.Visible = false; price.Visible = false; Button2.Visible = false;
                File1.Visible = true;
                break;

            default:
                
                break;
        }
            List<Portion> pAdd = new List<Portion>();
            List<Porca> pAddd = new List<Porca>();
            pAdd = (List<Portion>)Session["ListPortion"];
            if (pAdd != null)
                foreach (Portion asd in pAdd)
                {
                    Porca assf = new Porca();
                    assf.Product = Repository.Products.Where(p => p.ProductId == asd.ProductId).FirstOrDefault().Name;
                    assf.PrMass = asd.PrMass;
                    pAddd.Add(assf);
                }

            decimal priceAdd = 0;
            if (Session["DishAdd"]!=null)
            priceAdd = ((Dish)Session["DishAdd"]).Price > 0 ? (decimal)((Dish)Session["DishAdd"]).Price : priceAdd;
            if (stage == 2 && price.Text == "")
            {
                if (pAdd != null)
                    foreach (Portion asd in pAdd)
                    {
                        priceAdd += Repository.Products.Where(p => p.ProductId == asd.ProductId).FirstOrDefault().Price*asd.PrMass/100;
                    }
                price.Text = Convert.ToString(Math.Round(priceAdd, 2));
            }

            Dish dAdd = (Dish)Session["DishAdd"];
            if (dAdd != null)
            {
                DishLabel.Text = "Наименование рецепта: "+dAdd.Name+"<br/>"+
                                  "Основа рецепта: "+dAdd.Base+"<br/>"+
                                  "Сложность: " + dAdd.Difficult + "<br/>"+
                                  "Тип рецепта: " + Repository.Kinds.Where(p=>p.KindId == dAdd.KindId).FirstOrDefault().Name + "<br/>"+
                                  "Стоимость: " +  Math.Round(priceAdd, 2)+ "<br/>"+
                                  "Описание: " + (String)Session["OpisDish"];
            }


            List<String> ListKind = new List<string>();
            foreach (Kind sd in Repository.Kinds)
                ListKind.Add(sd.Name);

            Kind.DataSource = ListKind.OrderBy(p => p);
            Kind.DataBind();

            List<String> ListProduct = new List<string>();
            foreach (Product sd in Repository.Products)
                ListProduct.Add(sd.Name);

            /*Product.DataSource = ListProduct.OrderBy(p => p);
            Product.DataBind();*/

            
            Repeater1.DataSource = pAddd;
            Repeater1.DataBind();

           

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string url;
            url = "/Page/Adminka/NewDishPage.aspx";
            if (stage == 0) { 
                url = "/Page/Adminka/NewDishPage.aspx?stage=1";
                Dish tempd = new Dish();
                tempd.Name = Name.Text;
                tempd.Base = Base.Text;
                tempd.KindId = Repository.Kinds.Where(p => p.Name == Kind.Text).FirstOrDefault().KindId;
                tempd.Difficult = Difficult.Text;
                Session["OpisDish"] = MText.Text;
                Session["DishAdd"] = tempd;
            }
            if (stage == 1)
            { 
                url = "/Page/Adminka/NewDishPage.aspx?stage=2";
            }
            if (stage == 2) {
                url = "/Page/Adminka/NewDishPage.aspx?stage=3";
                if (Session["DishAdd"] != null)
                {
                    Dish temp = (Dish)Session["DishAdd"];
                    temp.Price = Convert.ToDecimal(price.Text);
                    Session["DishAdd"] = temp;
                }
            }
            if (stage == 3)
            {
                url = "/Page/Adminka/DishsAd.aspx";
                List<Portion> pAdd = (List<Portion>)Session["ListPortion"];
                int dishid1 = 0;
                if (Session["DishAdd"] != null && pAdd != null)
                {
                    Dish temp = (Dish)Session["DishAdd"];
                    Repository.CreateDish(temp);
                    int id = Repository.Dishs.Where(p=>(p.Name == temp.Name && p.KindId == temp.KindId)).FirstOrDefault().DishId;
                    foreach (Portion asd in pAdd)
                    {
                        Portion tempp = asd;
                        tempp.DishId = id;
                        dishid1 = id;
                        Repository.CreatePortion(tempp);
                    }
                    Recept nrec = new Recept();
                    nrec.DishId = id;
                    nrec.Specific = (String)Session["OpisDish"];
                    Repository.CreateRecept(nrec);
                }
                Session.Remove("ListPortion");
                Session.Remove("DishAdd");
                Session.Remove("OpisDish");

                List<String> _extentions = new List<string>{".jpg",".bmp",".png"};

                if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("/PictureDish") +  "\\" + fn;
                    string SaveInDb = "~/PictureDish/" + fn;
                    ImageForDish img = new ImageForDish();
                    img.DishId = dishid1;
                    img.Image = SaveInDb;
                    try
                    {
                        File1.PostedFile.SaveAs(SaveLocation);
                        Repository.CreateImageForDish(img);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
                else
                {
                    Response.Write("Файл не загружен.");
                }
            }
            



            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string url;
            url = "/Page/Adminka/NewDishPage.aspx?stage=1";
            if (stage == 1 && Product.Text != "" && gramm.Text!="")
            {
                Portion tempP = new Portion();
                tempP.ProductId = Repository.Products.Where(p => p.Name == Product.Text).FirstOrDefault().ProductId;
                tempP.PrMass = Convert.ToInt32(gramm.Text);
                List<Portion> tempLP = new List<Portion>();
                if (Session["ListPortion"] != null) tempLP = (List<Portion>)Session["ListPortion"];
                tempLP.Add(tempP);
                Session["ListPortion"] = tempLP;
            }

            Response.Redirect(url);

        }
    }
}