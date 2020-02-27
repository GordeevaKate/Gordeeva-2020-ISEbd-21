using AbstractSyshiBarBusinessLogic.BindingModels;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
namespace SyshiBarView
{
    public partial class FormSushi : Form
    {
    
            [Dependency]
            public new IUnityContainer Container { get; set; }
            public int Id { set { id = value; } }
            private readonly ISushiLogic logic;
            private int? id;
            private Dictionary<int, (string, int)> sushiSeafoods;
            public FormSushi(ISushiLogic service)
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
                    SushiViewModel view = logic.Read(new SushiBindingModel
                    {
                            Id =
                       id.Value
                        })?[0];
                        if (view != null)
                        {
                            textBoxName.Text = view.SushiName;
                            textBoxPrice.Text = view.Price.ToString();
                        sushiSeafoods = view.SushiSeafoods;
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
                var form = Container.Resolve<FormSushiSeafood>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (sushiSeafoods.ContainsKey(form.Id))
                    {
                    sushiSeafoods[form.Id] = (form.SeafoodName, form.Count);
                    }
                    else
                    {
                    sushiSeafoods.Add(form.Id, (form.SeafoodName, form.Count));
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
                    sushiSeafoods[form.Id] = (form.SeafoodName, form.Count);
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
            if (sushiSeafoods == null || sushiSeafoods.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new SushiBindingModel
                {
                    Id = id,
                    SushiName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    SushiSeafoods = sushiSeafoods
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
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
