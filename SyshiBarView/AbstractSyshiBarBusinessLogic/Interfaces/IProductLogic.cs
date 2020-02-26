using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> GetList();
        ProductViewModel GetElement(int id);
        void AddElement(ProductBindingModel model);
        void UpdElement(ProductBindingModel model);
        void DelElement(int id);
    }
}
