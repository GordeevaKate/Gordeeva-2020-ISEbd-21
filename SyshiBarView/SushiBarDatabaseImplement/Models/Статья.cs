using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseImplement.Models
{
    public class Статья
    {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
        [Required]
        public string Tema { get; set; }
        [Required]
        public DateTime DateCreate{ get; set; }
        [ForeignKey("СтатьяId")]
            public virtual List<АвторСтатья> AvtorStatias { get; set; }
    }
}
