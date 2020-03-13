using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class StorageSushiBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SushiId { get; set; }
        public int Count { get; set; }
    }
}
