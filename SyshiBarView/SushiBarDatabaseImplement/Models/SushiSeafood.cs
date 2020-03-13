using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SushiBarDatabaseImplement.Models
{
    public class SushiSeafood
    {
 public int Id { get; set; }
        public int SushiId { get; set; }
        public int SeafoodId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Seafood Seafood { get; set; }
        public virtual Sushi Sushi { get; set; }
    }
}
