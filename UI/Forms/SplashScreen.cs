using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Susie
{
    public partial class SplashScreen : Form
    {
        int Angle = 0;
        int x = 30;
        int y = 30;
        int r = 60;

        public SplashScreen()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.Gray;
            this.TransparencyKey = this.BackColor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void Loading1(Graphics g)
        {
            Point pt = new Point(x, y);
            int n = 285;
            Rectangle rect = new Rectangle(pt, new Size(r << 2, r << 1));
            g.DrawArc(new Pen(Color.GreenYellow, r), rect, ++Angle, 30);
            g.DrawArc(new Pen(Color.Aqua, r / 2), rect, Angle + 60, 30);
            g.DrawArc(new Pen(Color.CadetBlue, r), rect, Angle + 120, 30);
            g.DrawArc(new Pen(Color.GreenYellow, r / 2), rect, Angle + 180, 30);
            g.DrawArc(new Pen(Color.Aqua, r), rect, Angle + 240, 30);
            g.DrawArc(new Pen(Color.CadetBlue, r / 2), rect, Angle + 300, 30);
            Angle += n;
            g.DrawArc(new Pen(Color.GreenYellow, r), rect, Angle, 30);
            g.DrawArc(new Pen(Color.Aqua, r / 2), rect, Angle + 60, 30);
            g.DrawArc(new Pen(Color.CadetBlue, r), rect, Angle + 120, 30);
            g.DrawArc(new Pen(Color.GreenYellow, r / 2), rect, Angle + 180, 30);
            g.DrawArc(new Pen(Color.Aqua, r), rect, Angle + 240, 30);
            g.DrawArc(new Pen(Color.CadetBlue, r / 2), rect, Angle + 300, 30);
            Angle -= n;
            g.DrawString("Зачекайте, будь ласка..", SystemFonts.DefaultFont, Brushes.Black, new PointF((ClientSize.Width >> 1) - r - 65, (ClientSize.Height >> 1) - r+50));
        }
        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality; 
                this.Loading1(e.Graphics);
        }
    }
}
