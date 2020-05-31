using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SushiBarFileImplement.Models;
namespace SushiBarFileImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly FileDataListSingleton source;
        public StorageLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            return source.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageSeafoods = source.StorageSeafoods.Where(z => z.StorageId == rec.Id).Select(x => new StorageSeafoodViewModel
                {
                    Id = x.Id,
                    StorageId = x.StorageId,
                    SeafoodId = x.SeafoodId,
                    SeafoodName = source.Seafoods.FirstOrDefault(y => y.Id == x.SeafoodId)?.SeafoodName,
                    Count = x.Count
                }).ToList()
            })
                .ToList();
        }
        public StorageViewModel GetElement(int id)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            else
            {
                return new StorageViewModel
                {
                    Id = id,
                    StorageName = elem.StorageName,
                    StorageSeafoods = source.StorageSeafoods.Where(z => z.StorageId == elem.Id).Select(x => new StorageSeafoodViewModel
                    {
                        Id = x.Id,
                        StorageId = x.StorageId,
                        SeafoodId = x.SeafoodId,
                        SeafoodName = source.Seafoods.FirstOrDefault(y => y.Id == x.SeafoodId)?.SeafoodName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }

        public void AddElement(StorageBindingModel model)
        {

            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Storages.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.StorageName = model.StorageName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(int id)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == id);
            if (elem != null)
            {
                source.Storages.Remove(elem);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public void FillStorage(StorageSeafoodBindingModel model)
        {
            var item = source.StorageSeafoods.FirstOrDefault(x => x.SeafoodId == model.SeafoodId
                    && x.StorageId == model.StorageId);

            if (item != null)
            {
                item.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageSeafoods.Count > 0 ? source.StorageSeafoods.Max(rec => rec.Id) : 0;
                source.StorageSeafoods.Add(new StorageSeafood
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    SeafoodId = model.SeafoodId,
                    Count = model.Count
                });
            }
        }

        public bool CheckFoodsAvailability(int SushiId, int SushisCount)
        { 
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
            return true;
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
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
    }
}