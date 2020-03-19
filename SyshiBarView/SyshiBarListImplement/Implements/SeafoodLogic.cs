using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SyshiBarListImplement.Models;
using System;
using System.Collections.Generic;
namespace SyshiBarListImplement.Implements
{
    public class SeafoodLogic : ISeafoodLogic
    {
        private readonly DataListSingleton source;
        public SeafoodLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(SeafoodBindingModel model)
        {
            Seafood tempSeafood = model.Id.HasValue ? null : new Seafood
            {
                Id = 1
            };
            foreach (var seafood in source.Seafoods)
            {
                if (seafood.SeafoodName == model.SeafoodName && seafood.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && seafood.Id >= tempSeafood.Id)
                {
                    tempSeafood.Id = seafood.Id + 1;
                }
                else if (model.Id.HasValue && seafood.Id == model.Id)
  
            {
                    tempSeafood = seafood;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempSeafood == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempSeafood);
            }
            else
            {
                source.Seafoods.Add(CreateModel(model, tempSeafood));
            }
        }
        public void Delete(SeafoodBindingModel model)
        {
            for (int i = 0; i < source.Seafoods.Count; ++i)
            {
                if (source.Seafoods[i].Id == model.Id.Value)
                {
                    source.Seafoods.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<SeafoodViewModel> Read(SeafoodBindingModel model)
        {
            List<SeafoodViewModel> result = new List<SeafoodViewModel>();
            foreach (var seafood in source.Seafoods)
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
        private Seafood CreateModel(SeafoodBindingModel model, Seafood seafood)
        {
            seafood.SeafoodName = model.SeafoodName;
            return seafood;
        }
        private SeafoodViewModel CreateViewModel(Seafood seafood)
        {
            return new SeafoodViewModel
            {

 Id = seafood.Id,
                SeafoodName = seafood.SeafoodName
            };
        }
    } }