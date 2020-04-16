using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.Interfaces
{
    public interface IStorageLogic
    {
        List<StorageViewModel> GetList();
        StorageViewModel GetElement(int id);
        void AddElement(StorageBindingModel model);
        void UpdElement(StorageBindingModel model);
        void DelElement(int id);
        void FillStorage(StorageSeafoodBindingModel model);
        bool CheckSeafoodsAvailability(int snackId, int snacksCount);
        void RemoveFromStorage(int snackId, int snacksCount);
    }
}
