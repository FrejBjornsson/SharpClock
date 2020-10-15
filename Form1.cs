using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpClock
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void clock_Click(object sender, EventArgs e)
        {

        }

        private void Clock_Click(object sender, EventArgs e)
        {

        }
    }
}
