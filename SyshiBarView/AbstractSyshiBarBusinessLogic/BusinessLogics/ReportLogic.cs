using System;
using System.Collections.Generic;
using System.Linq;using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.HelperModels;
using ЭкзаменBusinessLogic.Interfaces;
using ЭкзаменBusinessLogic.ViewModels;using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace ЭкзаменBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IСтатьяLogic SeafoodLogic;
        private readonly IАвторLogic SushiLogic;

        public ReportLogic(IАвторLogic SushiLogic, IСтатьяLogic SeafoodLogic)
        {
            this.SushiLogic = SushiLogic;
            this.SeafoodLogic = SeafoodLogic;
           
        }
        public List<ReportViewModel> GetSushiSeafood()
        {
            var Seafoods = SeafoodLogic.Read(null);
            var Sushis = SushiLogic.Read(null);
            var list = new List<ReportViewModel>();
            foreach (var seafood in Seafoods)
            {
                foreach (var sushi in Sushis)
                {
                    if (sushi.AvtorStatias.ContainsKey(seafood.Id))
                    {
                        var record = new ReportViewModel
                        {
                            FIO = sushi.FIO,
                            Name = seafood.Name,
                            DateCreate = seafood.DateCreate,
                            DateR = sushi.DateR,
                            Rabota = sushi.Rabota
                        };
                        Console.WriteLine(record);
                        list.Add(record);
                    }
                }
            }
            return list;
        }
     

        public void SaveSushisToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список авторов статей",
                AvtorStatias = GetSushiSeafood(),
            });
        }
    }
}