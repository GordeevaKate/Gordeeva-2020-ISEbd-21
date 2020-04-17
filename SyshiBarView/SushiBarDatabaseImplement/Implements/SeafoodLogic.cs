using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SushiBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarDatabaseImplement.Implements
{
    public class SeafoodLogic  : ISeafoodLogic
    {
        public void CreateOrUpdate(SeafoodBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Seafood element = context.Seafoods.FirstOrDefault(rec =>
               rec.SeafoodName == model.SeafoodName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Seafoods.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                   
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Seafood();
                    context.Seafoods.Add(element);
                }
                element.SeafoodName = model.SeafoodName;
                context.SaveChanges();
            }
        }
        public void Delete(SeafoodBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Seafood element = context.Seafoods.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Seafoods.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<SeafoodViewModel> Read(SeafoodBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Seafoods
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new SeafoodViewModel
                {
                    Id = rec.Id,
                    SeafoodName = rec.SeafoodName
                })
                .ToList();
            }
        }
    }
}
