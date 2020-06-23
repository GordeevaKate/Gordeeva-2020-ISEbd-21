using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
namespace AbstractSyshiBarBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportSushiSeafoodViewModel> SushiSeafoods { get; set; }
        public List<ReportStorageSeafoodViewModel> StorageSeafoods { get; set; }
    }
}
