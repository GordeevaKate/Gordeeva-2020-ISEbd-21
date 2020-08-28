using System.Collections.Generic;
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
