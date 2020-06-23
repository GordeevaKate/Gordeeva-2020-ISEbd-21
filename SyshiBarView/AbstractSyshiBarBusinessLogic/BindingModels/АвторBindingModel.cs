using System.Collections.Generic;
using System;
namespace Экзамен.BindingModels
{
    public class АвторBindingModel
    {
        public int? Id { get; set; }
        public string FIO { get; set; }
        public string Rabota { get; set; }
        public string Email { get; set; }
        public DateTime DateR { get; set; }

        public Dictionary<int, string> AvtorStatias { get; set; }
    }
}
