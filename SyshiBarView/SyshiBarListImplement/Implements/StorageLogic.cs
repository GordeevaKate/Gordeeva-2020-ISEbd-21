using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using AbstractSyshiBarBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using SyshiBarListImplement.Models;

namespace SyshiBarListImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;
        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageSushiViewModel> StorageSushis = new List<StorageSushiViewModel>();
                for (int j = 0; j < source.StorageSushis.Count; ++j)
                {
                    if (source.StorageSushis[j].StorageId == source.Storages[i].Id)
                    {
                        string SushiName = string.Empty;
                        for (int k = 0; k < source.Sushis.Count; ++k)
                        {
                            if (source.StorageSushis[j].SushiId ==
                           source.Sushis[k].Id)
                            {
                                SushiName = source.Sushis[k].SushiName;
                                break;
                            }
                        }
                        StorageSushis.Add(new StorageSushiViewModel
                        {
                            Id = source.StorageSushis[j].Id,
                            StorageId = source.StorageSushis[j].StorageId,
                            SushiId = source.StorageSushis[j].SushiId,
                            SushiName = SushiName,
                            Count = source.StorageSushis[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageSushis = StorageSushis
                });
            }
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageSushiViewModel> StorageSushis = new
    List<StorageSushiViewModel>();
                for (int j = 0; j < source.StorageSushis.Count; ++j)
                {
                    if (source.StorageSushis[j].StorageId == source.Storages[i].Id)
                    {
                        string SushiName = string.Empty;
                        for (int k = 0; k < source.Sushis.Count; ++k)
                        {
                            if (source.StorageSushis[j].SushiId ==
                           source.Sushis[k].Id)
                            {
                                SushiName = source.Sushis[k].SushiName;
                                break;
                            }
                        }
                        StorageSushis.Add(new StorageSushiViewModel
                        {
                            Id = source.StorageSushis[j].Id,
                            StorageId = source.StorageSushis[j].StorageId,
                            SushiId = source.StorageSushis[j].SushiId,
                            SushiName = SushiName,
                            Count = source.StorageSushis[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageSushis = StorageSushis
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id > maxId)
                {
                    maxId = source.Storages[i].Id;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                source.Storages[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;

        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.StorageSushis.Count; ++i)
            {
                if (source.StorageSushis[i].StorageId == id)
                {
                    source.StorageSushis.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void FillStorage(StorageSushiBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.StorageSushis.Count; ++i)
            {
                if (source.StorageSushis[i].SushiId == model.SushiId
                    && source.StorageSushis[i].StorageId == model.StorageId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.StorageSushis[foundItemIndex].Count =
                    source.StorageSushis[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.StorageSushis.Count; ++i)
                {
                    if (source.StorageSushis[i].Id > maxId)
                    {
                        maxId = source.StorageSushis[i].Id;
                    }
                }
                source.StorageSushis.Add(new StorageSushi
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    SushiId = model.SushiId,
                    Count = model.Count
                });
            }
        }
    }
}