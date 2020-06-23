using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.BusinessLogics;
using ЭкзаменBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
 private readonly ReportLogic report;
   
        public FormMain( ReportLogic report)
        {
            InitializeComponent();
            this.report = report;
         
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
           
        }

        private void статьиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormСтатьи>();
            form.ShowDialog();
        }
        private void авторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormАвторы>();
            form.ShowDialog();
        }



 
        private void АвторыиСтатьиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormАвторСтатья>();
            form.ShowDialog();
        }


      
    }
}