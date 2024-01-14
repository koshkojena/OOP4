using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace лабораторная_4
{
    public partial class Form1 : Form
    {
        private Chart chart;
        public Form1()
        {
            InitializeComponent();
            Form1_Load(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x0, xk, dx, a, b, c;
            if (!double.TryParse(textBox1.Text, out x0) || !double.TryParse(textBox2.Text, out xk) || !double.TryParse(textBox3.Text, out dx)
                 || !double.TryParse(textBox4.Text, out a) || !double.TryParse(textBox6.Text, out b) || !double.TryParse(textBox7.Text, out c))
            {
                MessageBox.Show("Ошибка ввода чисел");
                return;
            }
            if (dx > Math.Abs(xk - x0))
            {
                MessageBox.Show("Ошибка ввода чисел! Значение dx больше разности между xk и x0.");
                return;
            }
            if (x0 > xk || dx <= 0 || dx > Math.Abs(xk - x0) || Math.Abs(x0) > 11111111111111)
            {
                MessageBox.Show("Ошибка ввода чисел!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            double x = x0;
            while (x <= xk)
            {
                double y1 = ((Math.Pow(10, -2) * b * c) / x) + Math.Cos(Math.Pow(x, a));
                double y2 = Math.Pow(x/2,2);
                chart1.Series[0].Points.AddXY(x, y1);
                chart1.Series[1].Points.AddXY(x, y2);
                x += dx;
            }

        }

        // Обработчик загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Устанавливаем значения по умолчанию для текстовых полей
            textBox1.Text = "-1,5";
            textBox2.Text = "3,5";
            textBox3.Text = "0,5";
            textBox4.Text = "-1,25";
            textBox6.Text = "-1,5";
            textBox7.Text = "0,75";

            // Устанавливаем названия меток и кнопок
            label1.Text = "X0 = ";
            label2.Text = "Xk = ";
            label3.Text = "Dx = ";
            label4.Text = "A = ";
            label5.Text = "B = ";
            label6.Text = "C = ";
            button1.Text = "Начертить";
            button2.Text = "Очистить";

            // Привязываем обработчики событий к кнопкам
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        // Обработчик нажатия кнопки "Очистить"
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

            if (chart != null)
            {
                Controls.Remove(chart);
                chart.Dispose();
                chart = null;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}