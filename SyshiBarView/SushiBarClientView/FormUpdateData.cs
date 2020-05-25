﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using AbstractSyshiBarBusinessLogic.ViewModels;
using System.Windows.Forms;

namespace SushiBarClientView
{
    public partial class FormUpdateData : Form
    {
        public FormUpdateData()
        {
            InitializeComponent();
            textBoxClientFIO.Text = Program.Client.ClientFIO;
            textBoxEmail.Text = Program.Client.Email;
            textBoxPassword.Text = Program.Client.Password;
        }
        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmail.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text) &&
           !string.IsNullOrEmpty(textBoxClientFIO.Text))
            {
                try
                {
                    //прописать запрос;
                    MessageBox.Show("Обновление прошло успешно", "Сообщение",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.Client.ClientFIO = textBoxClientFIO.Text;
                    Program.Client.Email = textBoxEmail.Text;
                    Program.Client.Password = textBoxPassword.Text;
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