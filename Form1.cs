using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OLYMPUS
{
    public partial class OLYMPUS : MetroForm
	{
        private InputForm inputForm; // Объявляем переменную для хранения экземпляра InputForm
        public OLYMPUS()
        {
            InitializeComponent();
            //SoundPlayer sndPlayer = new SoundPlayer("D://Repos//OLYMPUS//pl.wav");
            //sndPlayer.Play();
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
			textBox1.Text = "Расчёт данных...\n";
			CONTROL.Contrl();
			textBox1.Text = "Расчёт данных закончен\n";
		}

       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*
            Назначение: Вызов формы чтения входных данных
            Автор: Землянухин Роман Михайлович, КБХА, 106 отдел
            Версия: 01.01
            Дата: 12.03.2024
        */
            // Устанавливаем текст в textBox1
            textBox1.Text = "Ввод данных...\n";
            Update();

            // Создаем экземпляр InputForm
            inputForm = new InputForm();

            // Отображаем форму
            inputForm.Show();
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Устанавливаем текст в textBox1
            textBox1.Text = "Выбор файла...\n";
            Update();

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            int pos = baseDirectory.LastIndexOf("\\");
            string way = baseDirectory.Substring(0, pos - 5) + "OLYMPUS\\InputData\\";

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = way;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DECLARE.wayIn = openFileDialog1.FileName;
                PROLOG.Preset();
                inputForm = new InputForm();
                inputForm.SetInputData();
                inputForm.Show();
                textBox1.Text = "Файл успешно открыт!\n";
            }
            else
                textBox1.Text = "Не удалось открыть файл!\n";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Выбор файла...\n";
            Update();
            string baseDirectory = Application.StartupPath;
            int pos = baseDirectory.LastIndexOf("\\");
            string way = baseDirectory.Substring(0, pos - 5) + "OLYMPUS\\OutputData\\";
            //string baseDirectory = Application.StartupPath;
            //int pos = baseDirectory.LastIndexOf("\\");
            //string way = baseDirectory.Substring(0, pos - 5) + "OLYMPUS\\OutputData\\";
            //string baseDirectory = Directory.GetCurrentDirectory();
            //int pos = baseDirectory.LastIndexOf("\\");
            //string way = baseDirectory.Substring(0, pos - 5) + "OLYMPUS\\OutputData\\";
            //string way = @"D:\Repos\OLYMPUS\OLYMPUS\OutputData\output_system.txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = "";
            saveFileDialog1.InitialDirectory = way;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DECLARE.wayOut = saveFileDialog1.FileName;
                textBox1.Text = "Файл успешно выбран!\n";
            }
            else
                textBox1.Text = "Не удалось выбрать файл. Результаты будут записаны в служебный файл!\n";

        }

        private void ViewTemperature_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Визуализация результатов\n";
            Update();
			var graph = new Graph();
            if (/*sender == this.menuViewTemperatureCenter ||*/ sender == toolStripTemperatureCenter)
                graph.modification = 1;
            else
                graph.modification = 2;
            graph.Show();
        }

		private void editClick(object sender, EventArgs e)
		{
			textBox1.Text = "Редактирование данных...\n";
			DECLARE.wayIn = openFileDialog1.FileName;
			PROLOG.Preset();
			inputForm = new InputForm();
			inputForm.SetInputData();
			inputForm.Show();

		}
	}
}
