using System;
using System.Windows.Forms;
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
            CONTROL.Contrl();
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
    }
}
