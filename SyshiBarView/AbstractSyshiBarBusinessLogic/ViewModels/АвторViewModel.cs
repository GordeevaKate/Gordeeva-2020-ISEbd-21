using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using ЭкзаменBusinessLogic.Attributes;
using System;
using ЭкзаменBusinessLogic.ViewModels;

namespace ЭкзаменBusinessLogic.ViewModels
{
    [DataContract]
    public class АвторViewModel : BaseViewModel
    {


        [Column(title: "Название суши", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string FIO { get; set; }
        [Column(title: "Мето работы", width: 50)]
        [DataMember]
        public string Rabota { get; set; }
        [Column(title: "Емайл", width: 50)]
        [DataMember]
        public string Email { get; set; }
        [Column(title: "Дата рождения", width: 50)]
        [DataMember]
        public DateTime DateR { get; set; }
        [DataMember]
        public Dictionary<int, string> AvtorStatias { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "FIO",
               "Email",
                  "DateR",
                     "Rabota"
        };
    }
}
