using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.BindingModels
{
    public class SushiSeafoodBindingModel
    {
        public int Id { get; set; }
        public int SushiId { get; set; }
        public int SeafoodId { get; set; }
        public int Count { get; set; }
    }
}
