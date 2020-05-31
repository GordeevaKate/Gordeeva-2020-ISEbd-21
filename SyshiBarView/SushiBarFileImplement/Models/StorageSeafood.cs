using System;
using System.Collections.Generic;
using System.Text;

namespace SushiBarFileImplement.Models
{
    public class StorageSeafood
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SeafoodId { get; set; }
        public int Count { get; set; }
    }
}
