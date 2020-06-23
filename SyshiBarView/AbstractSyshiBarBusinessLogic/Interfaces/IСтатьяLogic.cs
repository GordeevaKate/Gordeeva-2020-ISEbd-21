using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace ЭкзаменBusinessLogic.Interfaces
{
    public interface IСтатьяLogic
    {
        List<СтатьяViewModel> Read(СтатьяBindingModel model);
        void CreateOrUpdate(СтатьяBindingModel model);
        void Delete(СтатьяBindingModel model);
    }
}
