using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.Interfaces;
using ЭкзаменBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseImplement.Implements
{
    public class АвторLogic : IАвторLogic
    {
        public void CreateOrUpdate(АвторBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Автор element = context.Авторы.FirstOrDefault(rec =>
                       rec.FIO == model.FIO && rec.Id != model.Id);
                       
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.Авторы.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                            
                    {
                            element = new Автор();
                            context.Авторы.Add(element);
                        }
                        element.FIO = model.FIO;
                        element.Email = model.Email;
                        element.DateR = model.DateR;
                        element.Rabota = model.Rabota;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var sushiSeafoods = context.AvtorStatias.Where(rec
                           => rec.AId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.AvtorStatias.RemoveRange(sushiSeafoods.Where(rec =>
                            !model.AvtorStatias.ContainsKey(rec.AId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateSeafood in sushiSeafoods)
                            {
                              

                                model.AvtorStatias.Remove(updateSeafood.AId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.AvtorStatias)
                        {
                            context.AvtorStatias.Add(new АвторСтатья
                            {
                               
                                AId = element.Id,
                                SId = pc.Key,
                             
                            }) ;
                            context.SaveChanges();
                          
                        }
                        transaction.Commit();
                    }
                    catch (Exception mx)
                    {
                       
                        if (mx.InnerException != null)
                            Console.WriteLine("Inner exception: {0}", mx.InnerException);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(АвторBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                         context.AvtorStatias.RemoveRange(context.AvtorStatias.Where(rec =>
                        rec.AId == model.Id));
                        Автор element = context.Авторы.FirstOrDefault(rec => rec.Id                  
                       == model.Id);
                        if (element != null)
                        {
                            context.Авторы.Remove(element);
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
                        throw new Exception("Элемент ошибочен");
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<АвторViewModel> Read(АвторBindingModel model)
        {
            using (var context = new Database())
            {
                return context.Авторы
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new АвторViewModel
               {
                   Id = rec.Id,
                   FIO = rec.FIO,
                  Email = rec.Email,
               DateR = rec.DateR,
               Rabota = rec.Rabota,

                   AvtorStatias = context.AvtorStatias
                .Include(recPC => recPC.Статья)
               .Where(recPC => recPC.AId == rec.Id)
               .ToDictionary(recPC => recPC.SId, recPC =>
                (recPC.Статья?.Name))
               })
               .ToList();
            }
        }
    }
}