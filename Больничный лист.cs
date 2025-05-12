using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;


namespace Медицинская_карта
{
    public partial class Больничный_лист : Form
    {
        PrintDialog printDialog = new PrintDialog();
        PrintDocument printDocument = new PrintDocument();
        public Больничный_лист()
        {
            InitializeComponent();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;

            // Определение размеров листа A4
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            // Установка шрифта для печати
            Font font = new Font("Sans", 14);

            PrintTabControl(graphics, pageWidth, pageHeight);
        }

        private void PrintTabControl(Graphics graphics, float pageWidth, float pageHeight)
        {
            // Печать содержимого элементов на листе
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    PrintTextBox(control as TextBox, graphics, pageWidth, pageHeight);
                }
                else if (control is System.Windows.Forms.Label)
                {
                    PrintLabel(control as System.Windows.Forms.Label, graphics, pageWidth, pageHeight);
                }
            }
        }

        private void PrintTextBox(TextBox textBox, Graphics graphics, float pageWidth, float pageHeight)
        {
            // Получение положения и размеров TextBox на форме
            Rectangle textBoxBounds = textBox.Bounds;

            // Масштабирование положения и размеров TextBox для печати на листе A4
            float scaleX = pageWidth / this.Width;
            float scaleY = pageHeight / this.Height;
            float printX = textBoxBounds.X * scaleX;
            float printY = textBoxBounds.Y * scaleY;
            float printWidth = textBoxBounds.Width * scaleX;
            float printHeight = textBoxBounds.Height * scaleY;

            // Печать содержимого TextBox на листе
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            graphics.DrawString(textBox.Text, textBox.Font, Brushes.Black, new RectangleF(printX, printY, printWidth, printHeight), stringFormat);
        }

        private void PrintLabel(System.Windows.Forms.Label label, Graphics graphics, float pageWidth, float pageHeight)
        {
            // Получение положения и размеров Label на форме
            Rectangle labelBounds = label.Bounds;

            // Масштабирование положения и размеров Label для печати на листе A4
            float scaleX = pageWidth / this.Width;
            float scaleY = pageHeight / this.Height;
            float printX = labelBounds.X * scaleX;
            float printY = labelBounds.Y * scaleY;
            float printWidth = labelBounds.Width * scaleX;
            float printHeight = labelBounds.Height * scaleY;

            // Увеличение текста на несколько символов
            string text = label.Text;
            int increaseTextBy = 5; // Увеличение текста на 5 символов
            text += new string(' ', increaseTextBy);

            // Печать содержимого Label на листе
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            graphics.DrawString(text, label.Font, Brushes.Black, new RectangleF(printX, printY, printWidth, printHeight), stringFormat);
        }

        public void r(string a)
        {
            textBox12.Text = a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument.PrintPage += PrintDocument_PrintPage;

            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                printDocument.Print();
            }
        }
    }
}
