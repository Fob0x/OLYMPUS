using System;
using MetroFramework.Forms;
namespace OLYMPUS
{
    public partial class OLYMPUS : MetroForm
    {
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
    }
}
