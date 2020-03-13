using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class StorageSushiViewModel
    { 
            public int Id { get; set; }
            public int StorageId { get; set; }
            public int SushiId { get; set; }
            [DisplayName("Название суши")]
            public string SushiName { get; set; }
            [DisplayName("Количество")]
            public int Count { get; set; }
        
    }
}
