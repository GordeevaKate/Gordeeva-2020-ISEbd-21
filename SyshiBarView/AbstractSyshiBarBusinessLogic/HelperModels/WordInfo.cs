using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<SushiViewModel> Sushis { get; set; }
        public List<StorageViewModel> Storages { get; set; }
    
    }
}
