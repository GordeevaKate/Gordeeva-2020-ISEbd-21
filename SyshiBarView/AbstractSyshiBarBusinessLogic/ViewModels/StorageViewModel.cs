using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class StorageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StorageName { get; set; }
        public List<StorageSeafoodViewModel> StorageSeafoods { get; set; }
    }
}
