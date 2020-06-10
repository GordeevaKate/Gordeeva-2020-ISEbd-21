using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Enums;
using AbstractSyshiBarBusinessLogic.Interfaces;
using System;
namespace AbstractSyshiBarBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        public MainLogic(IOrderLogic orderLogic, IStorageLogic storageLogic)
        {
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                SushiId = model.SushiId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            try
            {
                storageLogic.RemoveFromStorage(order.SushiId, order.Count);
                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    SushiId = order.SushiId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void FillStorage(StorageSeafoodBindingModel model)
        {
            storageLogic.FillStorage(model);
        }
        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                SushiId = order.SushiId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                SushiId = order.SushiId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });
        }
    }
}
