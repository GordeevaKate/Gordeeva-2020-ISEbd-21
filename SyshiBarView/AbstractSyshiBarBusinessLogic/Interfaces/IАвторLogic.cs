using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.ViewModels;
using System.Collections.Generic;
using Экзамен.BindingModels;

namespace ЭкзаменBusinessLogic.Interfaces
{
    public interface IАвторLogic
    {
        List<АвторViewModel> Read(АвторBindingModel model);
        void CreateOrUpdate(АвторBindingModel model);
        void Delete(АвторBindingModel model);

    }
}
