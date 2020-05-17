using System.Collections.Generic;
using System.Linq;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic;
using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using SushiBarRestApi.Models;
using AbstractSyshiBarBusinessLogic.BusinessLogics;

namespace SyshiBarRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ISushiLogic _sushi;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, ISushiLogic sushi, MainLogic main)
        {
            _order = order;
            _sushi = sushi;
            _main = main;
        }
        [HttpGet]
        public List<SushiModel>  GetSushiList() => _sushi.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public SushiModel GetSushi(int SushiId) => Convert(_sushi.Read(new
       SushiBindingModel
        { Id = SushiId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private SushiModel Convert(SushiViewModel model)
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