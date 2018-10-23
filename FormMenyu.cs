using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormMenyu : Form
    {
        public int level { get; set; }

        public FormMenyu()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Sound.Play(Sound.sound_start);
            Levels formLevels = new Levels()
            {
                level = this.level,
                Size = new Size(459, 324)
            };
            DialogResult dr = formLevels.ShowDialog();
            if (dr == DialogResult.OK) this.level++;
            else if (dr == DialogResult.Abort) level = 1;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Sound.Play(Sound.sound_youwin);
            //this.Close();
            Environment.Exit(0);
        }

        private void checkBoxSound_Click(object sender, EventArgs e)
        {
            if (checkBoxSound.Checked)
            {
                checkBoxSound.Text = "Sound on";
                Sound.Play(Sound.sound_key);
            }
            else
            {
                checkBoxSound.Text = "Sound off";
            }
            Sound.OnOff(checkBoxSound.Checked);
        }

        private void FormMenyu_Load(object sender, EventArgs e)
        {
            level = 1;
            checkBoxSound_Click(sender, null);
        }
    }
}
