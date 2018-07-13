using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClassesBell
{
    public interface IRepository
    {

        #region Dish
        IQueryable<Dish> Dishs { get; }

        bool CreateDish(Dish Instance);

        bool UpdateDish(Dish Instance);

        bool RemoveDish(int DishId);
        #endregion

        #region ImageForDish
        IQueryable<ImageForDish> ImageForDishs { get; }

        bool CreateImageForDish(ImageForDish Instance);

        bool UpdateImageForDish(ImageForDish Instance);

        bool RemoveImageForDish(int ImageForDishId);
        #endregion

        #region Kind
        IQueryable<Kind> Kinds { get; }

        bool CreateKind(Kind Instance);

        bool UpdateKind(Kind Instance);

        bool RemoveKind(int KindId);
        #endregion

        #region Menu
        IQueryable<Menu> Menus { get; }

        bool CreateMenu(Menu Instance);

        bool UpdateMenu(Menu Instance);

        bool RemoveMenu(int MenuId);
        #endregion

        #region Order
        IQueryable<Order> Orders { get; }

        bool CreateOrder(Order Instance);

        bool UpdateOrder(Order Instance);

        bool RemoveOrder(int OrderId);
        #endregion

        #region OrderDish
        IQueryable<OrderDish> OrderDishs { get; }

        bool CreateOrderDish(OrderDish Instance);

        bool UpdateOrderDish(OrderDish Instance);

        bool RemoveOrderDish(int OrderDishId);
        #endregion

        #region Portion
        IQueryable<Portion> Portions { get; }

        bool CreatePortion(Portion Instance);

        bool UpdatePortion(Portion Instance);

        bool RemovePortion(int PortionId);
        #endregion

        #region Product
        IQueryable<Product> Products { get; }

        bool CreateProduct(Product Instance);

        bool UpdateProduct(Product Instance);

        bool RemoveProduct(int ProductId);
        #endregion
        
        #region Recall
        IQueryable<Recall> Recalls { get; }

        bool CreateRecall(Recall Instance);

        bool UpdateRecall(Recall Instance);

        bool RemoveRecall(int RecallId);
        #endregion

        #region Recept
        IQueryable<Recept> Recepts { get; }

        bool CreateRecept(Recept Instance);

        bool UpdateRecept(Recept Instance);

        bool RemoveRecept(int ReceptId);
        #endregion

        #region Repast
        IQueryable<Repast> Repasts { get; }

        bool CreateRepast(Repast Instance);

        bool UpdateRepast(Repast Instance);

        bool RemoveRepast(int RepastId);
        #endregion

        #region User
        IQueryable<User> Users { get; }

        bool CreateUser(User Instance);

        bool UpdateUser(User Instance);

        bool RemoveUser(int UserId);
        #endregion

    }
}
