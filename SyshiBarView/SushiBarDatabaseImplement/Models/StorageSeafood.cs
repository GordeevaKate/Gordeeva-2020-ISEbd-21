using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace SushiBarDatabaseImplement.Models
{
    public class StorageSeafood
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int SeafoodId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Seafood Seafood { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual StorageSeafood storageSeafood { get; set; }
    }
}
