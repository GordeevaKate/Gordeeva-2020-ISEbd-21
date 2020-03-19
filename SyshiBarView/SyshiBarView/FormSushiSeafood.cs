using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
namespace SyshiBarView
{
    public partial class FormSushiSeafood : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSeafood.SelectedValue); }
            set { comboBoxSeafood.SelectedValue = value; }
        }
        public string SeafoodName { get { return comboBoxSeafood.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormSushiSeafood(ISeafoodLogic logic)
        {
            InitializeComponent();
            List<SeafoodViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSeafood.DisplayMember = "SeafoodName";
                comboBoxSeafood.ValueMember = "Id";
                comboBoxSeafood.DataSource = list;
                comboBoxSeafood.SelectedItem = null;
            }


        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
