using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using WindowsFormsApp1;
using System.Data.SqlClient;

namespace Медицинская_карта
{
    public partial class Form1 : Form
    {
        db db = new db();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void logins(TextBox textBox, TextBox textBox1)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Врачи where логин='{textBox.Text}' and пароль='{textBox1.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            adapter.SelectCommand = command;

            adapter.Fill(Table);

            if (Table.Rows.Count == 1)
            {

                    MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form3 запрос = new Form3();
                    запрос.ShowDialog();

                // Открытие и закрытие соединения с базой данных
                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                db.con.Close();
            }
            else
            {
                // Отображение сообщения об ошибке
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loginss(TextBox textBox, TextBox textBox1)
        {

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();

            string query = $"select * from Врачи where логин='{textBox.Text}' and пароль='{textBox1.Text}' and Должность = 'Лаборант'";

            SqlCommand command = new SqlCommand(query, db.con);

            adapter.SelectCommand = command;

            adapter.Fill(Table);

            if (Table.Rows.Count == 1)
            {

                MessageBox.Show("Вы успешно вошли!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Лаборант запрос = new Лаборант();
                запрос.ShowDialog();

                // Открытие и закрытие соединения с базой данных
                db.con.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                db.con.Close();
            }
            else
            {
                // Отображение сообщения об ошибке
                MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" & textBox2.Text == "")
            {

            }
            else
            {
                logins(textBox1, textBox2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" & textBox4.Text == "")
            {

            }
            else
            {
                loginss(textBox3, textBox4);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
