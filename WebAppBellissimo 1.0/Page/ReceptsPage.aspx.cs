﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DbClassesBell;

namespace WebAppBellissimo_1._0.Page
{
    public partial class ReceptsPage : System.Web.UI.Page
    {

        SqlRepository Repository = new SqlRepository();
        private int pageSize = 20;

        protected String GetImageUrl (int DishId)
        {
            ImageForDish re = Repository.ImageForDishs.Where(p => p.DishId == DishId).FirstOrDefault();
            if (re!=null)
               return Repository.ImageForDishs.Where(p => p.DishId == DishId).FirstOrDefault().Image;
            else
                return "~/PictureDish/null_image.png";
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

        protected String GetKind(int Id)
        {
            var asd = Repository.Kinds.Where(p => p.KindId == Id);
            String res = "";
            foreach(Kind aw in asd)
                res= aw.Name;
            return res;
        }

        IQueryable<Dish> SortView(IQueryable<Dish> dishs)
        {
            IQueryable<Dish> dish2 = dishs;
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
                        dish2 = dishs.OrderBy(p => p.DishId);
                    else dish2 = dishs.OrderByDescending(p => p.DishId);
                    break;

                default:

                    break;
            }
            return dish2;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IQueryable<Dish> dishs = Repository.Dishs;
            IQueryable<Dish> dishs2 = SortView(dishs);



            Repeater1.DataSource = dishs2.Skip((CurrentPage - 1) * pageSize).Take(pageSize);
            Repeater1.DataBind();
            if (IsPostBack == false) 
            {
                
            }
        }
    }
}