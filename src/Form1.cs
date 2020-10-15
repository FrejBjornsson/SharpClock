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
        public void ClockTimer_Tick(object sender, EventArgs e)
        {
            Clock.Text = DateTime.Now.ToString("T");
        }
        public void DateTimer_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.ToString("d");
        }

        private void Clock_Click(object sender, EventArgs e)
        {

        }

        private void ClockForm_Load(object sender, EventArgs e)
        {

        }
    }
}
