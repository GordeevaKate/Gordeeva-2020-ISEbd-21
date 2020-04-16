using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSyshiBarBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportSushiSeafoodViewModel> SushiSeafoods { get; set; }
    }
}
