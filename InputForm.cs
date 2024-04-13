using MetroFramework.Forms;
using System;

namespace OLYMPUS
{
    public partial class InputForm : MetroForm
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DECLARE.R = double.Parse(textBox1.Text);
            DECLARE.Lambda = double.Parse(textBox2.Text);
            DECLARE.Ro = double.Parse(textBox3.Text);
            DECLARE.Cv = double.Parse(textBox4.Text);
            DECLARE.T0 = double.Parse(textBox5.Text);
            DECLARE.Tz = double.Parse(textBox6.Text);
            DECLARE.Eps = double.Parse(textBox7.Text);
            DECLARE.Nr = Int16.Parse(textBox8.Text);
            DECLARE.Nt = Int16.Parse(textBox8.Text);
            DECLARE.MaxIter = Int16.Parse(textBox8.Text);
            DECLARE.PrintStep = Int16.Parse(textBox8.Text);

        }
    }
}
