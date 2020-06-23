using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.Interfaces;
using ЭкзаменBusinessLogic.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseImplement.Implements
{
    public class СтатьяLogic  : IСтатьяLogic
    {
        public void CreateOrUpdate(СтатьяBindingModel model)
        {
            using (var context = new Database())
            {
                Статья element = context.Статьи.FirstOrDefault(rec =>
               rec.Name == model.Name && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Статьи.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                   
                if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Статья();
                    context.Статьи.Add(element);
                }
                element.Name = model.Name;
                element.Tema = model.Tema;
                element.DateCreate = model.DateCreate;
                context.SaveChanges();
            }
        }
        public void Delete(СтатьяBindingModel model)
        {
            using (var context = new Database())
            {
                Статья element = context.Статьи.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Статьи.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<СтатьяViewModel> Read(СтатьяBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Статьи
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new СтатьяViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    DateCreate = rec.DateCreate,
                    Tema = rec.Tema
                })
                .ToList();
            }
        }
    }
}
