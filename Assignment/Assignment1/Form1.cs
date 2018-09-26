using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        Map map = new Map();
        GameEngine engine = new GameEngine();

        public int tick;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = false;

            //lblMap.Text = map.initialiseMap();
            map.mapGenerate();
            lblMap.Text = map.redraw();
        }

        private void lblMap_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            lblTime.Text = tick.ToString();
            lblMap.Text = map.redraw();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
