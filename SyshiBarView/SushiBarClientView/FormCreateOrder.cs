using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.ViewModels;

namespace SushiBarClientView
{
    public partial class FormCreateOrder : Form
    {
        public FormCreateOrder()
        {
            InitializeComponent();
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxSushi.DisplayMember = "SushiName";
                comboBoxSushi.ValueMember = "Id";
                comboBoxSushi.DataSource =
               APIClient.GetRequest<List<SushiViewModel>>("api/main/getSushilist");
                comboBoxSushi.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxSushi.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxSushi.SelectedValue);
                    SushiViewModel Sushi =
APIClient.GetRequest<SushiViewModel>($"api/main/getSushi?SushiId={id}");
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Sushi.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxSushi_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSushi.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
                {
                    ClientId = Program.Client.Id,
                    SushiId = Convert.ToInt32(comboBoxSushi.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Заказ создан", "Сообщение", MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}