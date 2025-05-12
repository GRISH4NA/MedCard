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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FIO();
            LoadBolechkiDataIntoComboBoxes();
            DoubleID();
            LoadBolechkiDataIntoTextBoxes2();
            LoadBolechkiDataIntoComboBoxes2();
            LoadList();
            dead();
            IdB();
        }
        db db = new db();
        public void LoadBolechkiDataIntoTextBoxes()
        {

            string query = $"SELECT * From Болячки Where id = '{comboBox1.Text}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    db.con.Open();
                   SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox13.Text = reader["ФИО"].ToString();

                        maskedTextBox1.Text = reader["На учете"].ToString();

                        comboBox2.Text = reader["Лечащий врач"].ToString();
                        textBox12.Text = reader["Диагноз"].ToString();
                        textBox7.Text = reader["Назначенное лечение"].ToString();
                    }
                    reader.Close();
                    db.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }

            }
        }

            public void LoadBolechkiDataIntoComboBoxes()
        {

            string query = $"SELECT * From Болячки Where ФИО = '{db.id}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    db.con.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["id"].ToString());
                    }

                    reader.Close();
                    db.con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
            }
        }

        public void LoadBolechkiDataIntoComboBoxes2()
        {
            db.con.Open();

            string query = $"SELECT * From Врачи Where Должность != 'Лаборант'";


            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["ФИО"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
            }
            db.con.Close();

        }

        public void FIO()
        {
            db.con.Open();

            string query = $"SELECT * From Данные Where ФИО = '{db.id}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        textBox13.Text = reader["ФИО"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }


        public void DoubleID()
        {
            db.con.Open();

            string query = $"SELECT * From Данные Where ФИО = '{db.id}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        linkLabel2.Text = reader["id"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        public void GGID()
        {
            db.con.Open();

            string query = $"SELECT * From Врачи Where ФИО = '{comboBox2.Text}'";

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

        public void LoadBolechkiDataIntoTextBoxes2()
        {
            db.con.Open();

            string query = $"SELECT * From Данные Where ФИО = '{db.id}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        label14.Text = reader["ФИО"].ToString();
                        textBox1.Text = reader["Пол"].ToString();
                        textBox2.Text = reader["Возраст"].ToString();
                        textBox3.Text = reader["Снилс"].ToString();
                        textBox4.Text = reader["ИНН"].ToString();
                        textBox5.Text = reader["Полис"].ToString();
                        textBox6.Text = reader["Дата рождения"].ToString();
                        textBox15.Text = reader["Домашний адрес"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        public void AddS()
        {
            string query = $"insert into Болячки(idВрача,idПациента,ФИО,[На учете],Диагноз,[История болезней],[Лечащий врач],[Назначенное лечение],[Был на приеме]) values ('{linkLabel1.Text}','{linkLabel2.Text}','{textBox13.Text}','{maskedTextBox1.Text}','{textBox12.Text}','{textBox12.Text}','{comboBox2.Text}','{textBox7.Text}','{dateTimePicker1.Text}')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == ""|| maskedTextBox1.Text == "" || textBox12.Text == "" || comboBox2.Text == "" || textBox7.Text == "")
            {

            }
            else
            {
                comboBox1.Items.Clear();
                AddS();
                LoadBolechkiDataIntoComboBoxes();
                listBox1.Items.Clear();
                dead();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            LoadBolechkiDataIntoTextBoxes();
            LoadBolechkiDataIntoComboBoxes2();
            Load2();
        }

        public void Load2()
        {
            db.con.Open();
            string query = $"SELECT * From Врачи where ФИО = '{comboBox2.Text}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                       textBox10.Text = reader["Должность"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
            }
            db.con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load2();
            GGID();
        }

        public void StatusFalse()
        {
            string query = $"update Болячки set idВрача = '{linkLabel1.Text}',idПациента = '{linkLabel2.Text}',[На учете] = '{maskedTextBox1.Text}', Диагноз = '{textBox12.Text}', [История болезней] = '{textBox12.Text}',[Лечащий врач] = '{comboBox2.Text}',[Назначенное лечение] = '{textBox7.Text}',[Был на приеме] = '{dateTimePicker1.Text}' where id = '{comboBox1.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();

                int rowsAffected = command.ExecuteNonQuery();

                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {

            }
            else
            {
                comboBox1.Items.Clear();
                StatusFalse();
                LoadBolechkiDataIntoComboBoxes();
                listBox1.Items.Clear();
                dead();
            }
        }

        private void Ps()
        {
            string query = $"Delete from Болячки where id = '{comboBox1.Text}'";

            SqlCommand command = new SqlCommand(query, db.con);

            try
            {
                db.con.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("История удалена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {

            }
            else
            {
                comboBox1.Items.Clear();
                Ps();
                LoadBolechkiDataIntoComboBoxes();
                listBox1.Items.Clear();
                dead();
            }
        }



        public void LoadList()
        {
            db.con.Open();

            string query = $"SELECT * FROM Болячки where ФИО = '{db.id}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox3.Items.Add($"{reader["id"]}>{reader["ФИО"]} > {reader["На учете"]} > {reader["История болезней"]} > {reader["Лечащий врач"]} > {reader["Назначенное лечение"]} > {reader["Был на приеме"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
            }
            db.con.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            var selectedItem = listBox3.SelectedItem;

            if (selectedItem != null)
            {
                var selectedItemText = selectedItem.ToString();

                var lines = selectedItemText.Split('>');

                db.ids = lines[1];
                MessageBox.Show("Выписка = Да; Больничный лист Нет","",MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                DialogResult result = DialogResult.None;
                if (result == DialogResult.Yes)
                {
                    Выписка form2 = new Выписка();
                    form2.r($"1. В Энгельсская городская клиническая больница № 1, по адресу  ул. Весенняя, 6, Энгельс, Саратовская обл., 413116\r\n2. Фамилия, имя, отчество больного {lines[1]}\r\n3. Даты: \r\nа) На учете {lines[2]}\r\nб) Выбыл {lines[6]}\r\n4. Полный диагноз (основное заболевание, сопутствующее заболевание) \r\n{lines[3]}\r\n\r\n\r\n\r\n\r\n\r\nМП");
                    form2.ShowDialog();
                }
                else
                {
                    Больничный_лист form3 = new Больничный_лист();
                    form3.r($"1. Номер ЛН: 123456789012 выдан 20.01.2021\r\n2. ФИО застрахованного: Петров П.П.{lines[1]}\r\n3. Наименование МО: поликлиника №33 \r\n4. СНИЛС: 123-456-789 01{lines[2]}\r\n5. Период нетрудоспособности: 21.01.2021 - 26.01.2021 {lines[6]}\r\n6. Статус: 030 закрыт \r\n{lines[3]}\r\n7. Место работы: ООО 'ППТ.ру'\r\n8. Тип ЭЛН: первичный");
                    form3.ShowDialog();
                }
            }
        }

        public void dead()
        {
            db.con.Open();

            using (var command = db.con.CreateCommand())
            {
                command.CommandText = $"SELECT [История болезней] From Болячки Where ФИО = '{textBox13.Text}'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["История болезней"].ToString());
                    }
                }
            }
            db.con.Close();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        //метод для отображения
        public void DoubleID1()
        {
            db.con.Open();

            string query = $"SELECT * From Лаборант Where id = '{comboBox3.Text}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        textBox16.Text = reader["Назначение"].ToString();
                        textBox9.Text = reader["ДатаНазначения"].ToString();
                        textBox11.Text = reader["Статус"].ToString();
                        textBox17.Text = reader["Результат"].ToString();
                        textBox14.Text = reader["ДатаРезультата"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        public void IdB()
        {
            db.con.Open();

            string query = $"SELECT id From Лаборант where [id больного] = '{db.idp}'";

            {
                SqlCommand command = new SqlCommand(query, db.con);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader["id"].ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных о болячках: " + ex.Message);
                }
                db.con.Close();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Обновить_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
            {

            }
            else
            {
                DoubleID1();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoubleID1();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


