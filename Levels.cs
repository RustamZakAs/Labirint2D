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
            point = labelStart1.Location;
            switch (level)
            {
                case 1:
                    point = labelStart1.Location;
                    panel1.Location = new Point(0, 0);
                    panel1.Visible = true;
                    break;
                case 2:
                    point = labelStart2.Location;
                    panel2.Location = new Point(0, 0);
                    labelKey2.Visible = true;
                    labelDoor2.Visible = true;
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
            point.Offset(labelStart1.Width / 2, labelStart1.Height / 2);
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

        private void labelKey2_MouseEnter(object sender, EventArgs e)
        {
            this.keyDoor = true;
            Sound.Play(Sound.sound_start);
            //OpenCloseDoor();
            labelKey2.Visible = false;
        }

        private void OpenCloseDoor(Label door,/*bool*/object ocd = null)
        {
            bool openClose;
            if(ocd != null) openClose = (bool)ocd;
            else
            {
                openClose = this.keyDoor;
            }
            if (openClose)
            {
                door.Visible = false;
            } else door.Visible = false;
        }

        private void labelDoor_MouseEnter(object sender, EventArgs e)
        {
            if (keyDoor) OpenCloseDoor((Label)sender);
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
