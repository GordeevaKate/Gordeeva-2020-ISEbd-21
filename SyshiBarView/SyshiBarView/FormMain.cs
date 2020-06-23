using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.BusinessLogics;
using AbstractSyshiBarBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace View
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly WorkModeling work;
        private readonly ReportLogic report;
        private readonly BackUpAbstractLogic backUpAbstractLogic;
        public FormMain( WorkModeling work, ReportLogic report, BackUpAbstractLogic backUpAbstractLogic)
        {
            InitializeComponent();
            this.report = report;
            this.work = work;
            this.backUpAbstractLogic = backUpAbstractLogic;
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


        private void списокАвторовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    report.SaveSushisToWordFile(new ReportBindingModel
                    {
                        FileName =
                   dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
        }
 
        private void АвторыиСтатьиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportАвторыСтатьи>();
            form.ShowDialog();
        }


        private void создатьБэкапToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Бекап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}