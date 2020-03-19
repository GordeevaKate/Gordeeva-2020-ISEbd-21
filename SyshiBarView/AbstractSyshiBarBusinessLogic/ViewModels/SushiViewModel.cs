using System.Collections.Generic;
using System.ComponentModel;
namespace AbstractSyshiBarBusinessLogic.ViewModels
{
   public class SushiViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название суши")]
        public string SushiName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SushiSeafoods { get; set; }
    }
}
