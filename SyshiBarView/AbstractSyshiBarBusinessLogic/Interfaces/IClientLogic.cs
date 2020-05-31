using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
