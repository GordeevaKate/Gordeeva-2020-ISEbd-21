using System.ComponentModel;
namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class SeafoodViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string SeafoodName { get; set; }
    }
}
