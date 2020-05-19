using System.ComponentModel;

namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class SushiSeafoodViewModel
    {
        public int Id { get; set; }
        public int SushiId { get; set; }
        public int SeafoodId { get; set; }
        [DisplayName("Название продукта")]
        public string SeafoodName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
