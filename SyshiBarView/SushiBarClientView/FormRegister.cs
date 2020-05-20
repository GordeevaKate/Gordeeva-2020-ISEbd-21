using System;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Windows.Forms;
using AbstractSyshiBarBusinessLogic.BindingModels;

namespace SushiBarClientView
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text) &&
           !string.IsNullOrEmpty(textBoxClientFIO.Text))
            {
               string Pass = textBoxPassword.Text;
                try
                {
                    APIClient.PostRequest("api/client/register", new ClientBindingModel
                    {
                        ClientFIO = textBoxClientFIO.Text,
                        Email = textBoxEmail.Text,
                        Password = textBoxPassword.Text
                    });
                    MessageBox.Show("Регистрация прошла успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
