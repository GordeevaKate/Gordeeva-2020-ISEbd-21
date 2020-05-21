using AbstractSyshiBarBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using AbstractSyshiBarBusinessLogic.ViewModels;
namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}
