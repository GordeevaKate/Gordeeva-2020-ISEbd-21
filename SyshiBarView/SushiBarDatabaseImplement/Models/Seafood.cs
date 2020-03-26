using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SushiBarDatabaseImplement.Models
{
    public class Seafood
    {

            public int Id { get; set; }
            [Required]
            public string SeafoodName { get; set; }
            [ForeignKey("SeafoodId")]
            public virtual List<SushiSeafood> SushiSeafoods { get; set; }
    }
}
