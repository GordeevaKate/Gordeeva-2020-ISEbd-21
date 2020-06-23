using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SushiBarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SushiBarFileImplement.Implements
{
    public class SeafoodLogic : ISeafoodLogic
    {
        private readonly FileDataListSingleton source;
        public SeafoodLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(СтатьяBindingModel model)
        {
            Seafood element = source.Seafoods.FirstOrDefault(rec => rec.SeafoodName
           == model.SeafoodName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть продукт с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Seafoods.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Seafoods.Count > 0 ? source.Seafoods.Max(rec =>
               rec.Id) : 0;
                element = new Seafood { Id = maxId + 1 };
                source.Seafoods.Add(element);
            }
            element.SeafoodName = model.SeafoodName;
        }
        public void Delete(СтатьяBindingModel model)
        {
            Seafood element = source.Seafoods.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Seafoods.Remove(element);
            }
            else
            { }
        }
        public List<SeafoodViewModel> Read(СтатьяBindingModel model)
        {
            return source.Seafoods
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
