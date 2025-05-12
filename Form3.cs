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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadBolechkiDataIntoTextBoxes(listBox1);
        }
        db db = new db();
        public void LoadBolechkiDataIntoTextBoxes( ListBox listBox2)
        {
            db.con.Open();

            string query = "SELECT * FROM Данные";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox2.Items.Add($"{reader["id"]}>{reader["ФИО"]} > {reader["Пол"]} > {reader["Возраст"]} лет > Снилс: {reader["Снилс"]} > ИНН: {reader["ИНН"]} > Полис: {reader["Полис"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
            }
            db.con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = listBox1.SelectedItem;

            if (selectedItem != null)
            {
                var selectedItemText = selectedItem.ToString();

                var lines = selectedItemText.Split('>');

                
                db.id = lines[1];
                db.idp = lines[0];
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
