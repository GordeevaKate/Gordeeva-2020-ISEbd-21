using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractSyshiBarBusinessLogic.Attributes;
using System;
namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    [DataContract]
    public class SushiViewModel : BaseViewModel
    {
        [Column(title: "Название суши", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string SushiName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> SushiSeafoods { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "SushiName",
            "Price"
        };
    }
}
