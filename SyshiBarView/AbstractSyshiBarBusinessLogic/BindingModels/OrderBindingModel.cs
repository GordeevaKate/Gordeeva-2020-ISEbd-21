
namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class OrderBindingModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
