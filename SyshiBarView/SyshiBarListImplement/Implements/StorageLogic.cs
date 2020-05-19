using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SyshiBarListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AbstractSyshiBarBusinessLogic.BindingModels;
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
                List<StorageSeafoodViewModel> StorageSeafoods = new
    List<StorageSeafoodViewModel>();
                for (int j = 0; j < source.StorageSeafoods.Count; ++j)
                {
                    if (source.StorageSeafoods[j].StorageId == source.Storages[i].Id)
                    {
                        string SeafoodName = string.Empty;
                        for (int k = 0; k < source.Seafoods.Count; ++k)
                        {
                            if (source.StorageSeafoods[j].SeafoodId ==
                           source.Seafoods[k].Id)
                            {
                                SeafoodName = source.Seafoods[k].SeafoodName;
                                break;
                            }
                        }
                        StorageSeafoods.Add(new StorageSeafoodViewModel
                        {
                            Id = source.StorageSeafoods[j].Id,
                            StorageId = source.StorageSeafoods[j].StorageId,
                            SeafoodId = source.StorageSeafoods[j].SeafoodId,
                            SeafoodName = SeafoodName,
                            Count = source.StorageSeafoods[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageSeafoods = StorageSeafoods
                });
            }
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageSeafoodViewModel> StorageSeafoods = new
    List<StorageSeafoodViewModel>();
                for (int j = 0; j < source.StorageSeafoods.Count; ++j)
                {
                    if (source.StorageSeafoods[j].StorageId == source.Storages[i].Id)
                    {
                        string SeafoodName = string.Empty;
                        for (int k = 0; k < source.Seafoods.Count; ++k)
                        {
                            if (source.StorageSeafoods[j].SeafoodId ==
                           source.Seafoods[k].Id)
                            {
                                SeafoodName = source.Seafoods[k].SeafoodName;
                                break;
                            }
                        }
                        StorageSeafoods.Add(new StorageSeafoodViewModel
                        {
                            Id = source.StorageSeafoods[j].Id,
                            StorageId = source.StorageSeafoods[j].StorageId,
                            SeafoodId = source.StorageSeafoods[j].SeafoodId,
                            SeafoodName = SeafoodName,
                            Count = source.StorageSeafoods[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageSeafoods = StorageSeafoods
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
            for (int i = 0; i < source.StorageSeafoods.Count; ++i)
            {
                if (source.StorageSeafoods[i].StorageId == id)
                {
                    source.StorageSeafoods.RemoveAt(i--);
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
        public bool CheckSeafoodsAvailability(int SushiId, int SushisCount)
        {
            bool result = true;
            var SushiSeafoods = source.SushiSeafoods.Where(x => x.SushiId == SushiId);
            if (SushiSeafoods.Count() == 0) return false;
            foreach (var elem in SushiSeafoods)
            {
                int count = 0;
                var storageSeafoods = source.StorageSeafoods.FindAll(x => x.SeafoodId == elem.SeafoodId);           
                count = storageSeafoods.Sum(x => x.Count);
                if (count < elem.Count * SushisCount)
                    return false;
            }
            return result;
        }
        public void RemoveFromStorage(int SushiId, int SushisCount)
        {
            var SushiSeafoods = source.SushiSeafoods.Where(x => x.SushiId == SushiId);
            if (SushiSeafoods.Count() == 0) return;
            foreach (var elem in SushiSeafoods)
            {
                int left = elem.Count * SushisCount;
                var storageSeafoods = source.StorageSeafoods.FindAll(x => x.SeafoodId == elem.SeafoodId);
                foreach (var rec in storageSeafoods)
                {
                    int toRemove = left>rec.Count?rec.Count:left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
        public void FillStorage(StorageSeafoodBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.StorageSeafoods.Count; ++i)
            {
                if (source.StorageSeafoods[i].SeafoodId == model.SeafoodId
                    && source.StorageSeafoods[i].StorageId == model.StorageId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.StorageSeafoods[foundItemIndex].Count =
                    source.StorageSeafoods[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.StorageSeafoods.Count; ++i)
                {
                    if (source.StorageSeafoods[i].Id > maxId)
                    {
                        maxId = source.StorageSeafoods[i].Id;
                    }
                }
                source.StorageSeafoods.Add(new StorageSeafood
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    SeafoodId = model.SeafoodId,
                    Count = model.Count
                });
            }
        }
    }
}