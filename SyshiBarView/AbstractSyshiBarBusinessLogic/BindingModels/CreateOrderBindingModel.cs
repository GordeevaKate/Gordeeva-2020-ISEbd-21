using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int SushiId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
