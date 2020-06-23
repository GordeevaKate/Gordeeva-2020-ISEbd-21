using System.ComponentModel;
using System;
using System.Collections.Generic;
using ЭкзаменBusinessLogic.Attributes;

namespace ЭкзаменBusinessLogic.ViewModels
{
    public class СтатьяViewModel : BaseViewModel
    {
        [Column(title: "Статья", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string Name { get; set; }
        public string Tema { get; set; }
        public DateTime DateCreate { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "Tema",
            "DateCreate",
            "Name"
        };
    }
}
