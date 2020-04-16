using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSyshiBarBusinessLogic.ViewModels
{
    public class ReportSushiSeafoodViewModel
    {
        public string SeafoodName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Sushis { get; set; }
    }
}
