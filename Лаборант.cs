using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace Медицинская_карта
{
    public partial class Лаборант : Form
    {
        public Лаборант()
        {
            InitializeComponent();
            Vivod(comboBox1);
            Vivod(comboBox2);
        }
        db db = new db();
        public void Vivod(ComboBox combo)
        {
            db.con.Open();

            string query = $"SELECT * From Данные";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        combo.Items.Add(reader["ФИО"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        public void DoubleID(ComboBox combo)
        {
            db.con.Open();

            string query = $"SELECT * From Данные Where ФИО = '{combo.Text}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        linkLabel1.Text = reader["id"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoubleID(comboBox1);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoubleID(comboBox2);
        }




        public void AddS()
        {
            string query = $"insert into Лаборант([id больного],Назначение,ДатаНазначения,Статус,Результат,ДатаРезультата) values ('{linkLabel1.Text}','{textBox16.Text}','{textBox9.Text}','Не готово','-','-')";
            SqlCommand command = new SqlCommand(query, db.con);
            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Данные занесены.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
                db.con.Close();
            }
        }


        public void StatusFalse()
        {
            string query = $"update Лаборант set Статус = '{comboBox3.Text}', Результат = '{textBox2.Text}', ДатаРезультата='{textBox1.Text}' where [id больного] = '{linkLabel1.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();

                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Обновлено успешно.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox16.Text == "" || textBox9.Text == "")
            {

            }
            else
            {
                AddS();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || comboBox3.Text == "")
            {

            }
            else
            {
                StatusFalse();
            }
        }

        private void Лаборант_Load(object sender, EventArgs e)
        {

        }
    }
}
