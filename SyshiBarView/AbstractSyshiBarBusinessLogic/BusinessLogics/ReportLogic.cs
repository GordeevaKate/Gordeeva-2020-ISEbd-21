using System;
using System.Collections.Generic;
using System.Linq;using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.HelperModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;using AbstractSyshiBarBusinessLogic.Enums;using DocumentFormat.OpenXml.Office2010.ExcelAc;

namespace AbstractSyshiBarBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly ISeafoodLogic SeafoodLogic;
        private readonly ISushiLogic SushiLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IStorageLogic storageLogic;
        public ReportLogic(IStorageLogic storageLogic,ISushiLogic SushiLogic, ISeafoodLogic SeafoodLogic,
       IOrderLogic orderLogic)
        {
            this.SushiLogic = SushiLogic;
            this.SeafoodLogic = SeafoodLogic;
            this.orderLogic = orderLogic;
            this.storageLogic = storageLogic;
        }
        public List<ReportStorageSeafoodViewModel> GetStorageSeafoods()
        {
            var list = new List<ReportStorageSeafoodViewModel>();
            var storages = storageLogic.GetList();
            foreach (var storage in storages)
            {
                foreach (var sf in storage.StorageSeafoods)
                {
                    var record = new ReportStorageSeafoodViewModel
                    {
                        StorageName = storage.StorageName,
                        SeafoodName = sf.SeafoodName,
                        Count = sf.Count
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Storages = storageLogic.GetList()
            });
        }
        public void SaveStorageSeafoodsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов в складах",
                Storages = storageLogic.GetList()
            });
        }
        public void SaveStorageSeafoodsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список продуктов",
                StorageSeafoods = GetStorageSeafoods()
            });
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
                        Console.WriteLine(record);
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
              .Read(new OrderBindingModel
              {
                  DateFrom = model.DateFrom,
                  DateTo = model.DateTo
              })
              .GroupBy(rec => rec.DateCreate.Date)
              .OrderBy(recG => recG.Key)
              .ToList();
     
            return list;
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