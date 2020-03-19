using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class StorageSeafoodBindingModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SeafoodId { get; set; }
        public int Count { get; set; }
    }
}
