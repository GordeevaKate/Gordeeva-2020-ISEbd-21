using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using SushiBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarDatabaseImplement.Implements
{
    public class SushiLogic : ISushiLogic
    {
        public void CreateOrUpdate(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Sushi element = context.Sushis.FirstOrDefault(rec =>
                       rec.SushiName == model.SushiName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Sushis.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                            
                    {
                            element = new Sushi();
                            context.Sushis.Add(element);
                        }
                        element.SushiName = model.SushiName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var sushiSeafoods = context.SushiSeafoods.Where(rec
                           => rec.SushiId == model.Id.Value).ToList();
                            context.SushiSeafoods.RemoveRange(sushiSeafoods.Where(rec =>
                            !model.SushiSeafoods.ContainsKey(rec.SeafoodId)).ToList());
                            context.SaveChanges();
                   
                            foreach (var updateSeafood in sushiSeafoods)
                            {
                                updateSeafood.Count =
                               model.SushiSeafoods[updateSeafood.SeafoodId].Item2;

                                model.SushiSeafoods.Remove(updateSeafood.SeafoodId);
                            }
                            context.SaveChanges();
                        }                
                        foreach (var pc in model.SushiSeafoods)
                        {
                            context.SushiSeafoods.Add(new SushiSeafood
                            {
                                SushiId = element.Id,
                                SeafoodId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SushiSeafoods.RemoveRange(context.SushiSeafoods.Where(rec =>
                        rec.SushiId == model.Id));
                        Sushi element = context.Sushis.FirstOrDefault(rec => rec.Id                  
                       == model.Id);
                        if (element != null)
                        {
                            context.Sushis.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Sushis
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new SushiViewModel
               {
                   Id = rec.Id,
                   SushiName = rec.SushiName,
                   Price = rec.Price,
                   SushiSeafoods = context.SushiSeafoods
                .Include(recPC => recPC.Seafood)
               .Where(recPC => recPC.SushiId == rec.Id)
               .ToDictionary(recPC => recPC.SeafoodId, recPC =>
                (recPC.Seafood?.SeafoodName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}
