using ЭкзаменBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
namespace ЭкзаменBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportViewModel> AvtorStatias { get; set; }
    }
}
