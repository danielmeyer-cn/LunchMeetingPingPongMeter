using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongMeter
{
    public partial class Form1 : Form
    {
        private int _prevPosX, _prevPosY;
        private readonly Stopwatch _watch;
        public Form1()
        {
            _prevPosX = 0;
            _prevPosY = 0;
            _watch = new Stopwatch();
            
            InitializeComponent();
            label10.Text = "Under 10 min har gått";
            Timer timer = new Timer {Interval = 1000};
            timer.Tick += new EventHandler(TimerEvent);
            timer.Start();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            if (_prevPosX == Cursor.Position.X && _prevPosY == Cursor.Position.Y)
            {
                if (!_watch.IsRunning)
                {
                    _watch.Start();
                }
            }
            else
            {
                if (_watch.IsRunning)
                {

                    _watch.Stop();
                    if (_watch.ElapsedMilliseconds > 10 * 1000 * 60)
                    {
                        TimeSpan timeSpan = _watch.Elapsed.Add(new TimeSpan(0, 10, 0));
                        

                        label10.Text = "Tid som gått: " + timeSpan.ToString("hh\\:mm\\:ss");
                        //label10.Text = "Tid som gått:" + hours +":" + minutes +":" + seconds;
                        //MessageBox.Show("Time:" + watch.ElapsedMilliseconds / 1000 / 60);
                    }
                    _watch.Reset();
                    
                }
                _prevPosX = Cursor.Position.X;
                _prevPosY = Cursor.Position.Y;
                
            }
            
        }

       
    }

}


