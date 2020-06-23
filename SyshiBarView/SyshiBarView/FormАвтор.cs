using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.Interfaces;
using ЭкзаменBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using System.Text.RegularExpressions;

namespace SyshiBarView
{
    public partial class FormАвтор : Form
    {

        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IАвторLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> sushiSeafoods;
        public FormАвтор(IАвторLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    АвторViewModel view = logic.Read(new АвторBindingModel
                    {
                        Id =
                       id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.FIO;
                        textBoxPrice.Text = view.Rabota;
                        textBoxE.Text = view.Email;
                        dateTimePicker1.Value = view.DateR;
                        sushiSeafoods = view.AvtorStatias;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                sushiSeafoods = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (sushiSeafoods != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in sushiSeafoods)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormАвторСтатья>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (sushiSeafoods.ContainsKey(form.Id))
                {
                    sushiSeafoods[form.Id] = (form.Name, form.Count);
                }
                else
                {
                    sushiSeafoods.Add(form.Id, (form.Name, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSushiSeafood>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = sushiSeafoods[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    sushiSeafoods[form.Id] = (form.Name, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        sushiSeafoods.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxE.Text))
            {
                MessageBox.Show("Заполните email", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxE.Text,@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Заполните email корректно", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (sushiSeafoods == null || sushiSeafoods.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }

            try
            {
                logic.CreateOrUpdate(new АвторBindingModel
                {

                    Id = id,
                    FIO = textBoxName.Text,
                    Rabota = textBoxPrice.Text,
                    Email = textBoxE.Text,
                    DateR= dateTimePicker1.Value,
                    AvtorStatias = sushiSeafoods
                }
                );
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОшибкаsushiSeafoods ", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
