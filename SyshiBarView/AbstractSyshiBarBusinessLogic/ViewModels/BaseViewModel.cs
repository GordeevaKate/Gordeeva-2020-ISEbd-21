using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ЭкзаменBusinessLogic.Attributes;
namespace ЭкзаменBusinessLogic.ViewModels
{
    [DataContract]
    public abstract class BaseViewModel
    {
        [Column(visible: false)]
        [DataMember]
        public int Id { get; set; }
        public abstract List<string> Properties();
    }
}