using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace DatabaseImplement.Models
{
    public class Автор
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Rabota { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateR { get; set; }
        public virtual List<АвторСтатья> AvtorStatias { get; set; }

    }
}
