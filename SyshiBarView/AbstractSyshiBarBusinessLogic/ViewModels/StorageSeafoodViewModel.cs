using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class StorageSeafoodViewModel
    { 
            public int Id { get; set; }
            public int StorageId { get; set; }
            public int SeafoodId { get; set; }
            [DisplayName("Название морепродукта")]
            public string SeafoodName { get; set; }
            [DisplayName("Количество")]
            public int Count { get; set; }
        
    }
}
