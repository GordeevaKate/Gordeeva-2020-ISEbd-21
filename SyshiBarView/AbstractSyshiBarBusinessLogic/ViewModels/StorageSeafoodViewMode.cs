using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class StorageSeafoodViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SeafoodId { get; set; }
        [DisplayName("Название склада")]
        public string StorageName { get; set; }
        [DisplayName("Название продукта")]
        public string SeafoodName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
