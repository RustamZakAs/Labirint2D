using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Labirint2D
{
    public partial class FormMenyu : Form
    {
        public int level { get; set; }
        public int maxLevel { get; set; }

        public FormMenyu()
        {
            InitializeComponent();
            maxLevel = 2;
            //https://www.youtube.com/watch?v=0YTLPPn-yCY
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
            if (dr == DialogResult.OK)
            {
                if (++this.level > maxLevel)
                    this.level = 1;
            }
            else if (dr == DialogResult.Abort) level = 1;
            labelLevel.Text = "Level  " + level + "/" + maxLevel;

            var MyIni = new IniFile("Settings.ini");
            MyIni.Write("Level", level.ToString());
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

            var MyIni = new IniFile("Settings.ini");
            level = int.Parse(MyIni.Read("Level"));

            checkBoxSound_Click(sender, null);
            labelLevel.Text = "Level  " + level + "/" + maxLevel;
        }
    }
}
