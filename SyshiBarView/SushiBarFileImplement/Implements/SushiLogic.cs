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
    public class SushiLogic : ISushiLogic
    {
        private readonly FileDataListSingleton source;
        public SushiLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SushiBindingModel model)
        {
            Sushi element = source.Sushis.FirstOrDefault(rec => rec.SushiName ==
           model.SushiName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть cyши с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Sushis.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Sushis.Count > 0 ? source.Seafoods.Max(rec =>
               rec.Id) : 0;
                element = new Sushi { Id = maxId + 1 };
                source.Sushis.Add(element);
            }
            element.SushiName = model.SushiName;
            element.Price = model.Price;
            source.SushiSeafoods.RemoveAll(rec => rec.SushiId == model.Id &&
           !model.SushiSeafoods.ContainsKey(rec.SeafoodId));
            var updateSeafoods = source.SushiSeafoods.Where(rec => rec.SushiId ==
           model.Id && model.SushiSeafoods.ContainsKey(rec.SeafoodId));
            foreach (var updateSeafood in updateSeafoods)
            {
                updateSeafood.Count =
               model.SushiSeafoods[updateSeafood.SeafoodId].Item2;
                model.SushiSeafoods.Remove(updateSeafood.SeafoodId);
            }
            int maxFSId = source.SushiSeafoods.Count > 0 ?
           source.SushiSeafoods.Max(rec => rec.Id) : 0;
            foreach (var pc in model.SushiSeafoods)
            {
                source.SushiSeafoods.Add(new SushiSeafood
                {
                    Id = ++maxFSId,
                    SushiId = element.Id,
                    SeafoodId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(SushiBindingModel model)
        {
            source.SushiSeafoods.RemoveAll(rec => rec.SushiId == model.Id);
            Sushi element = source.Sushis.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Sushis.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            return source.Sushis
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new SushiViewModel
            {
                Id = rec.Id,
                SushiName = rec.SushiName,
                Price = rec.Price,
                SushiSeafoods = source.SushiSeafoods
            .Where(recFS => recFS.SushiId == rec.Id)
           .ToDictionary(recFS => recFS.SeafoodId, recFS =>
            (source.Seafoods.FirstOrDefault(recC => recC.Id ==
           recFS.SeafoodId)?.SeafoodName, recFS.Count))
            })
            .ToList();
        }
    }
}
