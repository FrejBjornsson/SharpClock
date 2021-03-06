﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SharpClock
{
    public partial class ClockForm : Form
    {
        readonly Timer t = new Timer();
        private readonly int WIDTH = 300;
        private readonly int HEIGHT = 300;
        private readonly int secHAND = 140;
        private readonly int minHAND = 110;
        private readonly int hrHAND = 80;

        // in center   
        int cy, cx;
                        
        public Bitmap bmp;
        public Graphics cg;
        public string timeZone;
        public ComboBox timeZonePicker;

        public ClockForm()
        {
            InitializeComponent();
        }
        public void ClockTimer_Tick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(timeZone))
            {
                Clock.Text = FetchTimeZoneInfo().ToString("T");
            }
            else
            {
                Clock.Text = DateTime.Now.ToString("T");
            }
        }
        public void DateTimer_Tick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(timeZone))
            {
                Date.Text = FetchTimeZoneInfo().Date.ToString("d");
            }
            else
            {
                Date.Text = DateTime.Now.ToString("d");
            }
        }
        public void ClockForm_Load(object sender, EventArgs e)
        {
            // create a new bitmap   
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);
            // placing in center   
            cx = WIDTH / 2;
            cy = HEIGHT / 2;
            //backcolor   
            this.BackColor = Color.Black;
            // TimeZonePicker Dropdown
            TimeZonePicker();
            //timer   
            t.Interval = 1; // i.e. tick in milisecond   
            t.Tick += new EventHandler(this.Tick);
            t.Start();
        }

        public void TimeZonePicker()
        {
            Label label = new Label
            {
                Text = "Select Time Zone",
                ForeColor = Color.White,
                BackColor = Color.Red,
                Location = new Point(250, 480),
                Size = new Size(250, 20)
            };
            this.Controls.Add(label);
            timeZonePicker = new ComboBox();
            string[] timeZones = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).ToArray();
            timeZonePicker.Items.AddRange(timeZones);
            timeZonePicker.Location = new Point(250, 500);
            timeZonePicker.IntegralHeight = false;
            timeZonePicker.MaxDropDownItems = 5;
            timeZonePicker.DropDownStyle = ComboBoxStyle.DropDownList;
            timeZonePicker.Name = "ComboBox1";
            timeZonePicker.Size = new Size(250, 0);
            timeZonePicker.TabIndex = 0;
            this.Controls.Add(timeZonePicker);
            timeZonePicker.SelectedIndexChanged += new EventHandler(TimeZonePicker_SelectedIndexChanged);
        }

        public void TimeZonePicker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            timeZone = (string)timeZonePicker.SelectedItem;
        }

        public DateTime FetchTimeZoneInfo()
        {
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            DateTime timeZoneInfoTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, timeZoneInfo);

            return timeZoneInfoTime;
        }

        public void Tick(object sender, EventArgs e)
        {
            // create an image   
            cg = Graphics.FromImage(bmp);
            int ss;
            int mm;
            int hh;

            //get time 
            if (!String.IsNullOrEmpty(timeZone))
            {
                var timeZoneInfo = FetchTimeZoneInfo();
                ss = timeZoneInfo.Second;
                mm = timeZoneInfo.Minute;
                hh = timeZoneInfo.Hour;

                Text = "SharpClock | " + timeZone + " | " + timeZoneInfo.ToString("HH:mm:ss " + "| h:mm:ss tt");
            }
            else
            {
                ss = DateTime.Now.Second;
                mm = DateTime.Now.Minute;
                hh = DateTime.Now.Hour;

                Text = "SharpClock | " + "Central European Standard Time | " + DateTime.Now.ToString(" HH:mm:ss " + " | h:mm:ss tt");

                    

            }
            _ = new int[2];
            //get time   
            cg.Clear(Color.Black);
            //draw a circle   
            cg.DrawEllipse(new Pen(Color.Black, 6f), 0, 0, WIDTH, HEIGHT);
            //draw clock numbers   
            cg.DrawString("12", new Font("Ariel", 12), Brushes.Red, new PointF(140, 3));
            cg.DrawString("1", new Font("Ariel", 12), Brushes.Red, new PointF(218, 22));
            cg.DrawString("2", new Font("Ariel", 12), Brushes.Red, new PointF(263, 70));
            cg.DrawString("3", new Font("Ariel", 12), Brushes.Red, new PointF(285, 140));
            cg.DrawString("4", new Font("Ariel", 12), Brushes.Red, new PointF(263, 212));
            cg.DrawString("5", new Font("Ariel", 12), Brushes.Red, new PointF(218, 259));
            cg.DrawString("6", new Font("Ariel", 12), Brushes.Red, new PointF(142, 279));
            cg.DrawString("7", new Font("Ariel", 12), Brushes.Red, new PointF(70, 259));
            cg.DrawString("8", new Font("Ariel", 12), Brushes.Red, new PointF(22, 212));
            cg.DrawString("9", new Font("Ariel", 12), Brushes.Red, new PointF(1, 140));
            cg.DrawString("10", new Font("Ariel", 12), Brushes.Red, new PointF(22, 70));
            cg.DrawString("11", new Font("Ariel", 12), Brushes.Red, new PointF(70, 22));
            //draw seconds hand   
            int[] handCoord = MsCoord(ss, secHAND);
            cg.DrawLine(new Pen(Color.Red, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            //draw minutes hand   
            handCoord = MsCoord(mm, minHAND);
            cg.DrawLine(new Pen(Color.Red, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            //draw hours hand   
            handCoord = HrCoord(hh % 12, mm, hrHAND);
            cg.DrawLine(new Pen(Color.Red, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));
            //load the bitmap image   
            AnalogClockBox.Image = bmp;
            //display time in the heading   
            
          
                
           
           
            
            cg.Dispose();
        }
        //coord for minute and second   
        public int[] MsCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6; // note: each minute and seconds make a 6 degree   
            if (val >= 0 && val <= 100)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        public void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        //coord for hour   
        public int[] HrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
            //each hour makes 60 degree with min making 0.5 degree   
            int val = (int)((hval * 30) + (mval * 0.5));
            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }
    }
}
