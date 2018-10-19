using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ImageSaver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path, filename, name, url;

        private void button1_Click(object sender, EventArgs e)
        {
            //Запоминаем путь для сохранения изображений
            if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            path = folderBrowserDialog1.SelectedPath;
            MessageBox.Show("Путь для сохранения выбран");
            label1.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Открываем файл с адресами
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            filename = openFileDialog1.FileName;
            MessageBox.Show("Файл с адресами открыт");
            label2.Text = filename;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Считываем файл
            StreamReader data = new StreamReader(filename);
            List<string> vs = new List<string>();
            while(!data.EndOfStream)
            {
                vs.Add(data.ReadLine());
            }
            data.Close();
            
            //Сохраняем изображения
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), path + @"\" + name + ".svg");
            }
        }
    }
}
