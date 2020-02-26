using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> GetList();
        ComponentViewModel GetElement(int id);
        void AddElement(ComponentBindingModel model);
        void UpdElement(ComponentBindingModel model);
        void DelElement(int id);
    }
}
