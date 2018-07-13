using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class MenuList : System.Web.UI.Page
    {
        SqlRepository Repository = new SqlRepository();
        private int pageSize = 4;

        protected String GetMenuDish(int Id)
        {
            var asd = Repository.MenuDishs.Where(p => p.MenuId == Id);
            List<MenuDish> res = new List<MenuDish>();
            foreach (MenuDish aw in asd)
                res.Add(aw);
            String Dishss = ""; int i = 0;
            foreach (var qw in res)
            {
                if (i < 4)
                {
                    Dishss += Repository.Dishs.Where(p => p.DishId == qw.DishId).Single().Name;
                    Dishss += "<br/>";
                    i++;
                }
            }

            return Dishss;
        }



        IQueryable<DbClassesBell.Menu> SortView(IQueryable<DbClassesBell.Menu> dishs)
        {
            IQueryable<DbClassesBell.Menu> dish2 = dishs;
            switch (DropDownListSort1.SelectedIndex)
            {
                case 0:
                    if (DropDownListSort2.SelectedIndex == 0)
                        dish2 = dishs.OrderBy(p => p.Name);
                    else dish2 = dishs.OrderByDescending(p => p.Name);
                    break;
                case 1:
                    if (DropDownListSort2.SelectedIndex == 0)
                        dish2 = dishs.OrderBy(p => p.Price);
                    else dish2 = dishs.OrderByDescending(p => p.Price);
                    break;
                case 2:
                    if (DropDownListSort2.SelectedIndex == 0)
                        dish2 = dishs.OrderBy(p => p.MenuId);
                    else dish2 = dishs.OrderByDescending(p => p.MenuId);
                    break;

                default:

                    break;
            }
            return dish2;
        }

        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)Repository.Dishs.Count() / pageSize);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IQueryable<DbClassesBell.Menu> menus = Repository.Menus;
            IQueryable<DbClassesBell.Menu> menus2 = SortView(menus);
            Repeater1.DataSource = menus2.Skip((CurrentPage - 1) * pageSize).Take(pageSize);
            Repeater1.DataBind();
        }
    }
}