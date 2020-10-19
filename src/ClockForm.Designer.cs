using System;

namespace SharpClock
{
    partial class ClockForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockForm));
            this.Clock = new System.Windows.Forms.Label();
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.DateTimer = new System.Windows.Forms.Timer(this.components);
            this.Date = new System.Windows.Forms.Label();
            this.AnalogClockBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.AnalogClockBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Clock
            // 
            resources.ApplyResources(this.Clock, "Clock");
            this.Clock.BackColor = System.Drawing.Color.Transparent;
            this.Clock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clock.ForeColor = System.Drawing.Color.ForestGreen;
            this.Clock.Name = "Clock";
            // 
            // ClockTimer
            // 
            this.ClockTimer.Enabled = true;
            this.ClockTimer.Interval = 1;
            this.ClockTimer.Tick += new System.EventHandler(this.ClockTimer_Tick);
            // 
            // DateTimer
            // 
            this.DateTimer.Enabled = true;
            this.DateTimer.Interval = 1;
            this.DateTimer.Tick += new System.EventHandler(this.DateTimer_Tick);
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            this.Date.BackColor = System.Drawing.Color.Transparent;
            this.Date.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Date.ForeColor = System.Drawing.Color.ForestGreen;
            this.Date.Name = "Date";
            this.Date.UseCompatibleTextRendering = true;
            this.Date.UseMnemonic = false;
            // 
            // AnalogClockBox
            // 
            resources.ApplyResources(this.AnalogClockBox, "AnalogClockBox");
            this.AnalogClockBox.Name = "AnalogClockBox";
            this.AnalogClockBox.TabStop = false;
            this.AnalogClockBox.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // ClockForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.AnalogClockBox);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Clock);
            this.ForeColor = System.Drawing.Color.ForestGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClockForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ClockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AnalogClockBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label Clock;
        public System.Windows.Forms.Timer ClockTimer;
        public System.Windows.Forms.Label Date;
        public System.Windows.Forms.Timer DateTimer;
        private System.Windows.Forms.PictureBox AnalogClockBox;
    }
}

