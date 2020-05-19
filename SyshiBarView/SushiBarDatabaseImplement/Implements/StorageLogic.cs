using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SushiBarDatabaseImplement.Models;
using AbstractSyshiBarBusinessLogic.BindingModels;
using Microsoft.EntityFrameworkCore;

namespace SushiBarDatabaseImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        public List<StorageViewModel> GetList()
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Storages
                .ToList()
               .Select(rec => new StorageViewModel
               {
                   Id = rec.Id,
                   StorageName = rec.StorageName,
                   StorageSeafoods = context.StorageSeafoods
                .Include(recSF => recSF.Seafood)
               .Where(recSF => recSF.StorageId == rec.Id).
               Select(x => new StorageSeafoodViewModel
               {
                   Id = x.Id,
                   StorageId = x.StorageId,
                   SeafoodId = x.SeafoodId,
                   SeafoodName = context.Seafoods.FirstOrDefault(y => y.Id == x.SeafoodId).SeafoodName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }
        public StorageViewModel GetElement(int id)
        {
            using (var context = new SushiBarDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.Id == id);
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
                        StorageSeafoods = context.StorageSeafoods
                .Include(recSF => recSF.Seafood)
               .Where(recSF => recSF.StorageId == elem.Id)
                        .Select(x => new StorageSeafoodViewModel
                        {
                            Id = x.Id,
                            StorageId = x.StorageId,
                            SeafoodId = x.SeafoodId,
                            SeafoodName = context.Seafoods.FirstOrDefault(y => y.Id == x.SeafoodId).SeafoodName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }
        public void AddElement(StorageBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var storage = new Storage();
                context.Storages.Add(storage);
                storage.StorageName = model.StorageName;
                context.SaveChanges();
            }
        }
        public void UpdElement(StorageBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Storages.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.StorageName = model.StorageName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void DelElement(int id)
        {
            using (var context = new SushiBarDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Storages.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void FillStorage(StorageSeafoodBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                var item = context.StorageSeafoods.FirstOrDefault(x => x.SeafoodId == model.SeafoodId
    && x.StorageId == model.StorageId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new StorageSeafood();
                    context.StorageSeafoods.Add(elem);
                    elem.StorageId = model.StorageId;
                    elem.SeafoodId = model.SeafoodId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }
        public void RemoveFromStorage(int sushiId, int sushisCount)
        {
            using (var context = new SushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var sushiSeafoods = context.SushiSeafoods.Where(x => x.SushiId == sushiId);
                        if (sushiSeafoods.Count() == 0) return;
                        foreach (var elem in sushiSeafoods)
                        {
                            int left = elem.Count * sushisCount;
                            var StorageSeafoods = context.StorageSeafoods.Where(x => x.SeafoodId == elem.SeafoodId);
                            int available = StorageSeafoods.Sum(x => x.Count);
                            if (available < left) throw new Exception("Недостаточно продуктов на складе");
                            foreach (var rec in StorageSeafoods)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0) break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}