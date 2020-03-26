using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class SushiBindingModel
    {
        public int? Id { get; set; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SushiSeafoods { get; set; }
    }
}
