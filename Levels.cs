using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labirint2D
{
    public partial class Levels : Form
    {
        public int level { get; set; }
        public bool keyDoor { get; set; }

        public Levels()
        {
            InitializeComponent();
        }

        private void Levels_Shown(object sender, EventArgs e)
        {
            Point point;
            point = labelStart.Location;
            point.Offset(labelStart.Width/2, labelStart.Height/2);
            Cursor.Position = PointToScreen(point);
        }

        private void labelFinish_MouseEnter(object sender, EventArgs e)
        {
            Sound.Play(Sound.sound_youwin);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void labels_MouseEnter(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("You lost!","Messages",MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                Sound.Play(Sound.sound_fail);
                Levels_Shown(sender, e);
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void Levels_Load(object sender, EventArgs e)
        {
            switch (level)
            {
                case 1:
                    panel1.Location = new Point(0,0);
                    panel1.Visible = true;
                    break;
                case 2:
                    panel2.Location = new Point(0, 0);
                    labelKey.Visible = true;
                    labelDoor.Visible = true;
                    panel2.Visible = true;
                    timer2.Enabled = true;
                    labelT1.Visible = true;
                    labelT2.Visible = false;
                    break;
                case 3:
                    //goto case 1;
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    break;
                default:
                    break;
            }
        }

        private void labelKey_MouseEnter(object sender, EventArgs e)
        {
            this.keyDoor = true;
            Sound.Play(Sound.sound_start);
            //OpenCloseDoor();
            labelKey.Visible = false;
        }

        private void OpenCloseDoor(object ocd = null)
        {
            bool openClose;
            if(ocd != null) openClose = (bool)ocd;
            else
            {
                openClose = this.keyDoor;
            }
            if (openClose)
            {
                labelDoor.Visible = false;
            } else labelDoor.Visible = false;
        }

        private void labelDoor_MouseEnter(object sender, EventArgs e)
        {
            if (keyDoor) OpenCloseDoor();
            else MessageBox.Show("Fined key!");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                labelT1.Visible = !labelT1.Visible;
                labelT2.Visible = !labelT2.Visible;
            }
        }
    }
}
