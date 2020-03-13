using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
            public int Id { get; set; }
            public string StorageName { get; set; }
            public List<StorageSushiBindingModel> StorageFlowers { get; set; }
        }
}
