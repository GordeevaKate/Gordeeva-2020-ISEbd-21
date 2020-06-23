using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbstractSyshiBarBusinessLogic.BusinessLogics;
using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using SushiBarRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SushiBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IАвторLogic _sushi;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IАвторLogic sushi, MainLogic main)
        {
            _order = order;
            _sushi = sushi;
            _main = main;
        }
        [HttpGet]
        public List<SushiModel> GetSushiList() => _sushi.Read(null)?.Select(rec =>
      Convert(rec)).ToList();
        [HttpGet]
        public SushiModel GetSushi(int SushiId) => Convert(_sushi.Read(new
       СтатьяBindingModel
        { Id = SushiId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private SushiModel Convert(АвторViewModel model)
        {
            if (model == null) return null;
            return new SushiModel
            {
                Id = model.Id,
                SushiName = model.SushiName,
                Price = model.Price
            };
        }
    }
}

