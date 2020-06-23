using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseImplement.Models
{
    public class АвторСтатья
    {
 public int Id { get; set; }
        public int AId { get; set; }
        public int SId { get; set; }
        [Required]

        public virtual Автор Автор { get; set; }
        public virtual Статья Статья { get; set; }
    }
}
