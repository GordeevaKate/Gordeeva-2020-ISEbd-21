using System.ComponentModel;
using System;
using AbstractSyshiBarBusinessLogic.Attributes;
using System.Collections.Generic;

namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class SeafoodViewModel : BaseViewModel
    {
        [Column(title: "Продукт", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SeafoodName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "SeafoodName"
        };
    }
}
