using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseImplement.Models
{
    public class АвторСтатья
    {
 public int Id { get; set; }
        [Required]
        public int AId { get; set; }
        [Required]
        public int SId { get; set; }
        [Required]

        public virtual Автор Автор { get; set; }
        [Required]
        public virtual Статья Статья { get; set; }
    }
}
