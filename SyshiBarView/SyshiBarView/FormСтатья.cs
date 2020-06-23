using Экзамен.BindingModels;
using ЭкзаменBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
namespace SyshiBarView
{
    public partial class FormСтатья : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IСтатьяLogic logic;
        private int? id;
        public FormСтатья(IСтатьяLogic logic)
        {
            InitializeComponent();
            this.logic = logic;

        }
        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new СтатьяBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.Name;
                        textBoxТема.Text = view.Tema;
                        dateTimePicker1.Value = view.DateCreate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text)|| string.IsNullOrEmpty(textBoxТема.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new СтатьяBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,
                    Tema = textBoxТема.Text,
                    DateCreate = dateTimePicker1.Value
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
