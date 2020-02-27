using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface ISushiLogic
    {
        List<SushiViewModel> Read(SushiBindingModel model);
        void CreateOrUpdate(SushiBindingModel model);
        void Delete(SushiBindingModel model);

    }
}
