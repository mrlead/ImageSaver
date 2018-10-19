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

        string path, filename;

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
            if (path == null || filename == null)
            {
                MessageBox.Show("Выберите путь сохранения и файл с ссылками");
                return;
            }
            else
            {
                List<string> vs = new List<string>();
                List<string> url = new List<string>(0);
                List<string> name = new List<string>(0);
                //Считываем файл
                StreamReader data = new StreamReader(filename);
                while (!data.EndOfStream)
                {
                    vs.Add(data.ReadLine());
                }
                data.Close();

                //Time to ficha
                for (int j = 0; j < vs.Count; j++)
                {
                    url.Add("l");
                    name.Add("k");
                }

                //Бъём по частям
                for (int i = 0; i < vs.Count; i++)
                {
                    vs[i] = vs[i].Substring(vs[i].IndexOf(',') + 1);
                    url[i] = vs[i].Substring(vs[i].IndexOf(',') + 1);
                    name[i] = vs[i].Remove(vs[i].IndexOf(','));
                }

                //Сохраняем изображения
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        for (int k = 0; k < vs.Count; k++)
                        {
                            client.DownloadFile(new Uri(url[k]), path + @"\" + name[k]);
                        }
                        MessageBox.Show("Изображения загружены");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка загрузки изображения");
                    }
                }
            }
        }
    }
}
