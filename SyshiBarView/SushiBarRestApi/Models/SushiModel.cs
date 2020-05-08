using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiBarRestApi.Models
{
    public class SushiModel
    {
        public int Id { get; set; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
    }
}
