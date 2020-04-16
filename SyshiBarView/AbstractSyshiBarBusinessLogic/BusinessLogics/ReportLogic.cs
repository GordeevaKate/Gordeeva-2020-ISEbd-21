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
        private readonly ISeafoodLogic seafoodLogic;
        private readonly ISushiLogic sushiLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(ISushiLogic sushiLogic, ISeafoodLogic seafoodLogic,
       IOrderLogic orderLLogic)
        {
        this.seafoodLogic = seafoodLogic;
            this.sushiLogic = sushiLogic;
            this.orderLogic = orderLLogic;
        }
        public List<ReportSushiSeafoodViewModel> GetSushiSeafood()
        {
            var seafoods = seafoodLogic.Read(null);
            var sushis = sushiLogic.Read(null);
            var list = new List<ReportSushiSeafoodViewModel>();
            foreach (var seafood in seafoods)
            {
                var record = new ReportSushiSeafoodViewModel
                {
                    SeafoodName = seafood.SeafoodName,
                    Sushis = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var sushi in sushis)
                {
                    if (sushi.SushiSeafoods.ContainsKey(seafood.Id))
                    {
                        record.Sushis.Add(new Tuple<string, int>(sushi.SushiName,
                       sushi.SushiSeafoods[seafood.Id].Item2));
                        record.TotalCount +=
                       sushi.SushiSeafoods[seafood.Id].Item2;
                    }
                }
                list.Add(record);
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

 public void SaveSeafoodsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список морепродуктов",
                Seafoods = seafoodLogic.Read(null)
            });
        }
        public void SaveSushiSeafoodToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список морепродуктов",
                SushiSeafoods = GetSushiSeafood()
            });
        }
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}