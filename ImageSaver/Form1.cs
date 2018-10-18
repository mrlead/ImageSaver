using System;
using System.Windows.Forms;

namespace ImageSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path, filename;

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = folderBrowserDialog1.SelectedPath;
            MessageBox.Show("Путь для сохранения выбран");
            label1.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            MessageBox.Show("Файл с адресами открыт");
            label2.Text = filename;
        }
    }
}
