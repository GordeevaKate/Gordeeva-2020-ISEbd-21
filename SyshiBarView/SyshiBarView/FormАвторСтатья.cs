using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using ЭкзаменBusinessLogic.ViewModels;
using ЭкзаменBusinessLogic.Interfaces;

namespace View
{
    public partial class FormАвторСтатья : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSeafood.SelectedValue); }
            set { comboBoxSeafood.SelectedValue = value; }
        }
        public string Name { get { return comboBoxSeafood.Text; } }


        public FormАвторСтатья(IСтатьяLogic logic)
        {
            InitializeComponent();
            List<СтатьяViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSeafood.DisplayMember = "Name";
                comboBoxSeafood.ValueMember = "Id";
                comboBoxSeafood.DataSource = list;
                comboBoxSeafood.SelectedItem = null;
            }


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSeafood.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
