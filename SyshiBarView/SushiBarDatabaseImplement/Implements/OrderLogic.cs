﻿using System;
using System.Collections.Generic;
using System.Text;
using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AbstractSyshiBarBusinessLogic.Interfaces;

namespace SushiBarDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.SushiId = model.SushiId == 0 ? element.SushiId : model.SushiId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new SushiBarDatabase())
            {
                return context.Orders.Where(rec => model == null || (rec.Id == model.Id && model.Id.HasValue)
                || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    SushiId = rec.SushiId,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    SushiName = rec.Sushi.SushiName
                })
                .ToList();
            }
        }
    }
}
