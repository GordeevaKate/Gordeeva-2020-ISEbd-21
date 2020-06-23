using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace SushiBarDatabaseImplement.Models
{
    public class Storage
    {
        public int Id { get; set; }
        [Required]
        public string StorageName { get; set; }
        public virtual List<StorageSeafood> StorageSeafoods { get; set; }
    }
}
