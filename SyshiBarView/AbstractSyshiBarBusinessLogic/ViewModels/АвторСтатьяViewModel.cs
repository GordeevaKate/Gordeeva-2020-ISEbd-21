using System.ComponentModel;

namespace ЭкзаменBusinessLogic.ViewModels
{
    public class АвторСтатьяViewModel
    {
        public int Id { get; set; }
        public int AId { get; set; }
        public int SId { get; set; }
        [DisplayName("Статья")]
        public string Name { get; set; }
    }
}
