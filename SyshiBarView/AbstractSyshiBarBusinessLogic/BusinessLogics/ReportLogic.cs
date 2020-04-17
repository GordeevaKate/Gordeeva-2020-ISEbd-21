using System;
using System.Collections.Generic;
using System.Linq;using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.HelperModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
namespace AbstractSyshiBarBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISeafoodLogic SeafoodLogic;
        private readonly ISushiLogic SushiLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(ISushiLogic SushiLogic, ISeafoodLogic SeafoodLogic,
       IOrderLogic orderLogic)
        {
            this.SushiLogic = SushiLogic;
            this.SeafoodLogic = SeafoodLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportSushiSeafoodViewModel> GetSushiSeafood()
        {
            var Seafoods = SeafoodLogic.Read(null);
            var Sushis = SushiLogic.Read(null);
            var list = new List<ReportSushiSeafoodViewModel>();
            foreach (var seafood in Seafoods)
            {
                foreach (var sushi in Sushis)
                {
                    if (sushi.SushiSeafoods.ContainsKey(seafood.Id))
                    {
                        var record = new ReportSushiSeafoodViewModel
                        {
                            SushiName = sushi.SushiName,
                            SeafoodName = seafood.SeafoodName,
                            Count = sushi.SushiSeafoods[seafood.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                SushiName = x.SushiName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
    
        public void SaveSushisToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список суши",
                Sushis = SushiLogic.Read(null)
            });
        }

        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        public void SaveSushisToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список закусок по продуктам",
                SushiSeafoods = GetSushiSeafood(),
            });
        }
    }
}