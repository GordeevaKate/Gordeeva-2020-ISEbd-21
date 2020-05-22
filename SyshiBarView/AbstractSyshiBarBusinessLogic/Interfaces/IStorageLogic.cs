﻿using System;
using System.Collections.Generic;
using System.Text;
using AbstractSyshiBarBusinessLogic.BindingModels;
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
        void RemoveFromStorage(int sushiId, int sushisCount);
    }
}