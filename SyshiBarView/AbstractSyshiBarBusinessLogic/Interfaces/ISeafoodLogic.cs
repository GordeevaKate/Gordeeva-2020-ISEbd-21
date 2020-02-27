using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface ISeafoodLogic
    {
        List<SeafoodViewModel> Read(SeafoodBindingModel model);
        void CreateOrUpdate(SeafoodBindingModel model);
        void Delete(SeafoodBindingModel model);
    }
}
