using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SyshiBarListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SyshiBarListImplement.Implements
{
    public class SushiLogic : ISushiLogic
    {
        private readonly DataListSingleton source;
        public SushiLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SushiBindingModel model)
        {
            Sushi tempSushi = model.Id.HasValue ? null : new Sushi { Id = 1 };
            foreach (var sushi in source.Sushis)
            {
                if (sushi.SushiName == model.SushiName && sushi.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && sushi.Id >= tempSushi.Id)
                {
                    tempSushi.Id = sushi.Id + 1;
                }
                else if (model.Id.HasValue && sushi.Id == model.Id)
                {
                    tempSushi = sushi;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempSushi == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempSushi);
            }
            else
            {
                source.Sushis.Add(CreateModel(model, tempSushi));
            }
        }
        public void Delete(SushiBindingModel model)
        {
            for (int i = 0; i < source.SushiSeafoods.Count; ++i)
            {
                if (source.SushiSeafoods[i].SushiId == model.Id)
                {
                    source.SushiSeafoods.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Sushis.Count; ++i)
            {
                if (source.Sushis[i].Id == model.Id)
                {
                    source.Sushis.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Sushi CreateModel(SushiBindingModel model, Sushi sushi)
        {
            sushi.SushiName = model.SushiName;
            sushi.Price = model.Price;
            int maxSFId = 0;
            for (int i = 0; i < source.SushiSeafoods.Count; ++i)
            {
                if (source.SushiSeafoods[i].Id > maxSFId)
                {
                    maxSFId = source.SushiSeafoods[i].Id;
                }
                if (source.SushiSeafoods[i].SushiId == sushi.Id)
                {
                    if
                    (model.SushiSeafoods.ContainsKey(source.SushiSeafoods[i].SeafoodId))
                    {
                        source.SushiSeafoods[i].Count =
                        model.SushiSeafoods[source.SushiSeafoods[i].SeafoodId].Item2;
                        model.SushiSeafoods.Remove(source.SushiSeafoods[i].SeafoodId);
                    }
                    else
                    {
                        source.SushiSeafoods.RemoveAt(i--);
                    }
                }
            }
            foreach (var sf in model.SushiSeafoods)
            {
                source.SushiSeafoods.Add(new SushiSeafood
                {
                    Id = ++maxSFId,
                    SushiId = sushi.Id,
                    SeafoodId = sf.Key,
                    Count = sf.Value.Item2
                });
            }
            return sushi;
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            List<SushiViewModel> result = new List<SushiViewModel>();
            foreach (var seafood in source.Sushis)
            {
                if (model != null)
                {
                    if (seafood.Id == model.Id)
                    {
                        result.Add(CreateViewModel(seafood));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(seafood));
            }
            return result;
        }
        private SushiViewModel CreateViewModel(Sushi Sushi)
        {
            Dictionary<int, (string, int)> SushiSeafoods = new Dictionary<int, (string, int)>();
            foreach (var sf in source.SushiSeafoods)
            {
                if (sf.SushiId == Sushi.Id)
                {
                    string SeafoodName = string.Empty;
                    foreach (var Seafood in source.Seafoods)
                    {
                        if (sf.SeafoodId == Seafood.Id)
                        {
                            SeafoodName = Seafood.SeafoodName;
                            break;
                        }
                    }
                    SushiSeafoods.Add(sf.SeafoodId, (SeafoodName, sf.Count));
                }
            }
            return new SushiViewModel
            {
                Id = Sushi.Id,
                SushiName = Sushi.SushiName,
                Price = Sushi.Price,
                SushiSeafoods = SushiSeafoods
            };
        }
    }
}
