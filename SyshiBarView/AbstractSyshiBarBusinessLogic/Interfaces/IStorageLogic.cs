using AbstractSyshiBarBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using AbstractSyshiBarBusinessLogic.ViewModels;
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
        bool CheckSeafoodsAvailability(int sushiId, int sushisCount);
        void RemoveFromStorage(int sushiId, int sushisCount);
    }
}
