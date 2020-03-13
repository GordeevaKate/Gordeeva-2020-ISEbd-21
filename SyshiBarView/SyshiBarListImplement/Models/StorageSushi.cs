using System;
using System.Collections.Generic;
using System.Text;

namespace SyshiBarListImplement.Models
{
    public class StorageSushi
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SushiId { get; set; }
        public int Count { get; set; }
    }
}
