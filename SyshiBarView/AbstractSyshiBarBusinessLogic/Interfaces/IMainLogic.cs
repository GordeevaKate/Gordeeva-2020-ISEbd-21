using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IMainLogic
    {
        List<OrderViewModel> GetOrders();
        void CreateOrder(OrderBindingModel model);
        void TakeOrderInWork(OrderBindingModel model);
        void FinishOrder(OrderBindingModel model);
        void PayOrder(OrderBindingModel model);
    }
}
