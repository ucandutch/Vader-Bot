using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ruler
{
    public partial class loadingscreen : Form
    {
        public loadingscreen()
        {
            InitializeComponent();
        }
        Form1 bot = new Form1();
        private void loadingscreen_Load(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.DimGray;
            bot.Show();
            bot.Opacity = 0;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                
                if (this.Opacity == 1)
                {
                    timer2.Enabled = true;
                    timer1.Enabled = false;
                    
                }
                else
                {
                    
                    this.Opacity = this.Opacity + 0.01;
                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 0.02)
            {
                bot.Opacity = 1;
                
                bot.opening.Enabled = true;
               
                timer2.Enabled = false;
                this.Hide();
            }
            else
            {
                this.Opacity = this.Opacity - 0.01;

            }
        }
    }
}
