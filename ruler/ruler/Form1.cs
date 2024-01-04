using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Threading;
using System.IO;
using System.Net;
namespace ruler
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        const int MYACTION_HOTKEY_ID = 1;
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(IntPtr ZeroOnyly, string IpWindowName);

        [DllImport("user32.dll")]

        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData,
  int dwExtraInfo);
        private static readonly int VK_SNAPSHOT = 0x2C;

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;
        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_RCONTROL = 0xA3; //Right Control key code
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public Color startingColor;
        public Color GetPixelColor(int x, int y)
    {
        using (Bitmap snapshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
        using (Graphics gph = Graphics.FromImage(snapshot))
        {
            gph.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            return snapshot.GetPixel(x, y);
        }
    }
       int hptownvalue = 0;
       int mptownvalue = 0;
       int mppercent = 0;
       private void hpbox_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (hpbox.SelectedText == "75")
           {
               hppercent = 160;
           }
           else if (hpbox.SelectedText == "90")
           {
               hppercent = 190;
           }
           else if (hpbox.SelectedText == "50")
           {
               hppercent = 95;
               durum1.Text = "%50 HP pot basma özelliği beta aşamasındadır. Önerilmez.";
           }
           else if (hpbox.SelectedText == "35")
           {
               durum1.Text = "%50 HP pot basma özelliği beta aşamasındadır. Önerilmez.";

               hppercent = 75;
           }
       }
        IInputSimulator hppot = new InputSimulator();
       IInputSimulator mppot = new InputSimulator();
         public void checkForColorDifference(Color start)
         {
             Color starting = start;
             if (hpbox.Text == "75")
             {
                 hppercent = 160;
             }
             else if (hpbox.Text == "90")
             {
                 hppercent = 194;
             }
             else if (hpbox.Text == "50")
             {
                 hppercent = 143;
             }
             else if (hpbox.Text == "35")
             {
                 hppercent = 95;
             }
             Color currentColor = GetPixelColor(Screen.PrimaryScreen.WorkingArea.Left + hppercent, Screen.PrimaryScreen.WorkingArea.Top + 40);
             int renkkodu = (currentColor.R + currentColor.G + currentColor.B);
             
             kordinat.Text = durum1.BackColor.ToString();
                 if (currentColor.R >= 45 && currentColor.G <= 30 && currentColor.B <= 30 )
             {
             }
                 else
                 {
                     if (hpCheck.CheckState == CheckState.Checked)
                     {
                         hpTownText.Text = hptownvalue.ToString();
                         if (hptownvalue == 0)
                         {
                             if (checkBox7.CheckState == CheckState.Checked)
                             {

                                 for (int i = 0; i < 30; i++)
                                 {
                                 hppot.Keyboard.Sleep(10);
                                 hppot.Keyboard.KeyUp(VirtualKeyCode.VK_0);
                                 hppot.Keyboard.Sleep(10);
                                 hppot.Keyboard.KeyDown(VirtualKeyCode.VK_0);
                                 hppot.Keyboard.Sleep(10);
                                 }
                             }
                             else
                             {
                                 hppot.Keyboard.Sleep(200);
                                 hppot.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                                 hppot.Keyboard.Sleep(100);
                                 hppot.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                                 hppot.Keyboard.Sleep(200);
                                 hppot.Keyboard.TextEntry("/town");
                                 hppot.Keyboard.Sleep(200);
                                 hppot.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                                 hppot.Keyboard.Sleep(100);
                                 hppot.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                                 hptownvalue = 0;

                                 close();
                             }
                         }
                         else
                         {
                             hptownvalue--;
                         }
                         hpTownText.Text = hptownvalue.ToString();
                     }
                     hppot.Keyboard.Sleep(200);
                     hppot.Keyboard.KeyUp(VirtualKeyCode.VK_3);
                     hppot.Keyboard.Sleep(200);
                     hppot.Keyboard.KeyDown(VirtualKeyCode.VK_3);
                     hppot.Keyboard.Sleep(200);
                     if (checkBox11.CheckState == CheckState.Checked)
                     {
                         hprnwsayi--;
                         hprnwTxt.Text = hprnwsayi.ToString();
                     }
                 }
         }
        void foreground()
        {
            IntPtr _pointer = FindWindow(new IntPtr(0), "Knight OnLine Client");
            SetForegroundWindow(_pointer);
        }
        int calismadurumu = 0;
        void start()
        {

            foreground();

            calismadurumu = 1;
                ztimer.Enabled = true;
                if (checkBox3.CheckState == CheckState.Checked)
                {
                    timer1.Enabled = true;
                }
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    manatimer.Enabled = true;
                }
                if (safety2Check.CheckState == CheckState.Checked && safetyCheck.CheckState == CheckState.Checked)
                {
                    wolf.Keyboard.Sleep(200);
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                    wolf.Keyboard.Sleep(100);
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                    doublesafetytimer.Enabled = true;
                    safetysekil++;
                }
                else if (safety2Check.CheckState == CheckState.Checked)
                {
                    wolf.Keyboard.Sleep(200);
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                    wolf.Keyboard.Sleep(100);
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                    safety2timer.Enabled = true;
                }
                else if (safetyCheck.CheckState == CheckState.Checked)
                {
                    wolf.Keyboard.Sleep(200);
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                    wolf.Keyboard.Sleep(100);
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                    safetytimer.Enabled = true;
                }
                if (WolfTownCheck.CheckState == CheckState.Checked)
                {
                    wolftownvalue = Convert.ToInt32(wolfTownText.Text);
                    wolftownvalue = wolftownvalue - 1;
                    wolfTownText.Text = wolftownvalue.ToString();
                }
                if (checkBox8.CheckState == CheckState.Checked)
                {
                    if (tssayac1 == 0)
                    {
                        attack1timer.Enabled = false;
                        attack2timer.Enabled = false;
                        ts.Keyboard.KeyDown(VirtualKeyCode.F2);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.F2);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.VK_9);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.VK_9);
                        ts.Keyboard.Sleep(350);
                        ts.Keyboard.KeyDown(VirtualKeyCode.TAB);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.TAB);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(350);
                        ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.F1);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.F1);
                        ts.Keyboard.Sleep(150);
                        if (attack1check.CheckState == CheckState.Checked)
                        {
                            attack1timer.Enabled = true;
                        }
                        if (attack2check.CheckState == CheckState.Checked)
                        {
                            attack2timer.Enabled = true;
                        }
                    }

                    tstimer.Enabled = true;
                }

                if (wolfCheck.CheckState == CheckState.Checked)
                {
                    if (wolflabel < 3 || wolflabel == 120)
                    {
                        wolf.Keyboard.Sleep(200);
                        wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                        wolf.Keyboard.Sleep(100);
                        wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                        wolfsayac.Enabled = true;
                        wolflabel = 120;
                        label26.Text = wolflabel.ToString();
                        wolftimer.Enabled = true;
                    }
                }

                if (HammerTownCheck.CheckState == CheckState.Checked)
                {
                    hammertownvalue = Convert.ToInt32(hammerTownText.Text);
                    hammertownvalue = hammertownvalue - 1;
                    hammerTownText.Text = hammertownvalue.ToString();
                }
                if (hammercheck.CheckState == CheckState.Checked)
                {
                    hammertimer.Enabled = true;
                }

                if (attack1check.CheckState == CheckState.Checked)
                {
                    attack1timer.Enabled = true;
                }
                if (attack2check.CheckState == CheckState.Checked)
                {
                    attack2timer.Enabled = true;
                }
                if (checkBox6.CheckState == CheckState.Checked)
                {
                    petfeed.Interval = (Convert.ToInt32(petfeedcombo.Text) * 60) * 1000;
                    petfeed.Enabled = true;
                }
           
            this.Cursor = Cursors.AppStarting;
            durum1.Text = "Bot çalışıyor...";
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "YENİLE")
            {
                getknight();
            }
            else
            {
                //if (pedalcheck == 1)
                //{
                //    pedalbuton();
                //}
                //else
                //{
                    //if (kucultmecheck == 1)
                    //{
                    //    groupBox1.Visible = true;
                    //    this.Size = new Size(205, 72);
                    //    ReallyCenterToScreen2();
                    //    textBox2.Text = durum1.Text;
                    //    button8.Enabled = true;
                    //    button7.Enabled = false;
                    //}
                    comboBox1.Enabled = false;
                    hpbox.Enabled = false;
                    comboBox2.Enabled = false;
                    button1.Enabled = false;
                    button1.BackColor = Color.DarkGray;
                    button2.Enabled = true;
                    button2.BackColor = Color.SaddleBrown;
                    start();
                //}
            }
         
        }
        IInputSimulator pedal = new InputSimulator();
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyUp(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyDown(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyUp(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyDown(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyUp(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            pedal.Keyboard.KeyDown(VirtualKeyCode.VK_0);
            pedal.Keyboard.Sleep(10);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void close()      
            {
            calismadurumu = 0;
                durum1.Text = "Durduruldu!";
                   
                ztimer.Enabled = false;            
                wolftimer.Enabled = false;         
                safetytimer.Enabled = false;          
                safety2timer.Enabled = false;         
                hammertimer.Enabled = false;
                doublesafetytimer.Enabled = false;
                comboBox1.Enabled = true;
                hpbox.Enabled = true;
                comboBox2.Enabled = true;
                minortimer.Enabled = false;
                minormana.Enabled = false;
                this.Cursor = Cursors.Arrow;
                timer1.Enabled = false;
                manatimer.Enabled = false;
                button2.Enabled = false;
                button2.BackColor = Color.DarkGray;
                button1.Enabled = true;
                button1.BackColor = Color.SaddleBrown;
                petfeed.Enabled = false;

                warriortimer.Enabled = false;
                warriortaunttimer.Enabled = false;
            attack1timer.Enabled = false;
            //    wolflabel = 0;
            //label26.Text = wolflabel.ToString();
            attack2timer.Enabled = false;
            asastimer.Enabled = false;
                rtimer.Enabled = false;
                
            }
        private void button2_Click(object sender, EventArgs e)
        {
            close();  
            
        }
        public void getknight()
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains("Knight"))
                {
                    hWnd = pList.MainWindowHandle;
                    durum1.Text = "Oyun açık, Bot çaışmaya hazır!";
                    button1.Text = "BAŞLAT";
                   
                }
                if (hWnd == IntPtr.Zero)
                {
                    durum1.Text = "Oyun Bulunamadı! Oyunu açtıktan sonra Yenile tuşuna basın.";
                    button1.Text = "YENİLE";
                    
                    button7.Enabled = false;
                }
            }
         }
        string checkstatus = "";
        string folder = "\\Vader\\Settings.txt";
        String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


       private void saveall()
        {
            if (File.Exists(path + folder))
            {
                using (StreamReader read = new StreamReader(path + folder))
                {
                    checkstatus = read.ReadLine();
                    if (checkstatus != "Checked")
                    {
                        durum1.Text = "Yükleniyor...";
                    }
                    else
                    {
                        checkBox9.CheckState = CheckState.Checked;
                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
	                        {
		                 checkBox5.CheckState = CheckState.Checked;
                            }

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnattack1chk.ForeColor = Color.Red;
                            attack1check.CheckState = CheckState.Checked;
                        }

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnattackchck.ForeColor = Color.Red;
                            attack2check.CheckState = CheckState.Checked;
                        }

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnsafety2chck.ForeColor = Color.Red;
                            safety2Check.CheckState = CheckState.Checked;
                        }

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnsafetychck.ForeColor = Color.Red;
                            safetyCheck.CheckState = CheckState.Checked;
                        }

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnhpchck.ForeColor = Color.Red;
                            hpbox.Enabled = false;
                            checkBox3.CheckState = CheckState.Checked;
                        }
                        checkstatus = read.ReadLine();
                        hpbox.Text = checkstatus;

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnmanachck.ForeColor = Color.Red;
                            comboBox2.Enabled = false;
                            checkBox2.CheckState = CheckState.Checked;
                        }
                        checkstatus = read.ReadLine();
                        comboBox2.Text = checkstatus;

                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnwolfchck.ForeColor = Color.Red;
                            wolfCheck.CheckState = CheckState.Checked;
                        }
                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            btnhammerchck.ForeColor = Color.Red;
                            comboBox1.Enabled = false;
                            hammercheck.CheckState = CheckState.Checked;
                        }
                        checkstatus = read.ReadLine();
                        comboBox1.Text = checkstatus;
                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            
                            checkBox6.CheckState = CheckState.Checked;
                        }
                        checkstatus = read.ReadLine();
                        petfeedcombo.Text = checkstatus;
                        checkstatus = read.ReadLine();
                        if (checkstatus == "Checked")
                        {
                            checkBox8.CheckState = CheckState.Checked;
                        }

                        read.Close();
                        // }

                    }
                }
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Vader"));

                using (StreamWriter ayarlarilkkayit = new StreamWriter(path + folder))
            {
                ayarlarilkkayit.WriteLine(checkBox9.CheckState);
                ayarlarilkkayit.WriteLine(checkBox5.CheckState);
                ayarlarilkkayit.WriteLine(attack1check.CheckState);
                ayarlarilkkayit.WriteLine(attack2check.CheckState);
                ayarlarilkkayit.WriteLine(safety2Check.CheckState);
                ayarlarilkkayit.WriteLine(safetyCheck.CheckState);
                ayarlarilkkayit.WriteLine(checkBox3.CheckState);
                ayarlarilkkayit.WriteLine(hpbox.Text);

                ayarlarilkkayit.WriteLine(checkBox2.CheckState);
                ayarlarilkkayit.WriteLine(comboBox2.Text);

                ayarlarilkkayit.WriteLine(wolfCheck.CheckState);
                ayarlarilkkayit.WriteLine(hammercheck.CheckState);
                ayarlarilkkayit.WriteLine(comboBox1.Text);

                ayarlarilkkayit.WriteLine(checkBox6.CheckState);
                ayarlarilkkayit.WriteLine(petfeedcombo.Text);

                ayarlarilkkayit.WriteLine(checkBox8.CheckState);
                ayarlarilkkayit.Close();
            } 
            }
           
        }
       public void checkforupdate()
       {
           try
           {
               durum1.Text = "Güncelleştirmeler kontrol ediliyor Lütfen bekleyin...";
               WebRequest wrs = WebRequest.Create(new Uri("http://up-to-the-minute-al.000webhostapp.com/version/version.php"));
               wrs.Timeout = 10000;
               
               WebResponse ws = wrs.GetResponse();
               
               StreamReader sr = new StreamReader(ws.GetResponseStream());
               string newversion = sr.ReadToEnd();
               if (newversion == version.Text)
               {
                   durum1.Text = "Güncelleştirme kontrolü yapıldı.";
               }
               else
               {
                   durum1.Text = "Yeni bir Güncelleştirme mevcut! İndirmek için tıklayın.";
               }
           }
           catch (Exception)
           {
               durum1.Text = "Güncellemeleri kontrol ederken hata oluştu lütfen tekrar deneyin.";
               
           }
           
         }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            saveall();
            
            this.TransparencyKey = Color.DimGray;
            startingColor = GetPixelColor(Screen.PrimaryScreen.WorkingArea.Left + 190 , Screen.PrimaryScreen.WorkingArea.Top + 60);
            getknight();
            //checkforupdate();
        }
      
        private void wolfText_TextChanged(object sender, EventArgs e)
        {

        }

        private void safetyCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            wolftimer.Enabled = true;
        }

        private void mpCheck_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void hpCheck_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void WolfTownCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (WolfTownCheck.Checked == true)
            {
                wolfTownText.Enabled = true;
            }
            else
            {
                wolfTownText.Enabled = false;
            }
        }
        private void HammerTownCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (HammerTownCheck.Checked == true)
            {
                hammerTownText.Enabled = true;
            }
            else
            {
                hammerTownText.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (checkBox9.CheckState == CheckState.Checked)
            {
                using (StreamWriter ayarlarilkkayit = new StreamWriter(path + folder))
                {
                    ayarlarilkkayit.WriteLine(checkBox9.CheckState);
                    ayarlarilkkayit.WriteLine(checkBox5.CheckState);
                    ayarlarilkkayit.WriteLine(attack1check.CheckState);
                    ayarlarilkkayit.WriteLine(attack2check.CheckState);
                    ayarlarilkkayit.WriteLine(safety2Check.CheckState);
                    ayarlarilkkayit.WriteLine(safetyCheck.CheckState);
                    ayarlarilkkayit.WriteLine(checkBox3.CheckState);
                    ayarlarilkkayit.WriteLine(hpbox.Text);

                    ayarlarilkkayit.WriteLine(checkBox2.CheckState);
                    ayarlarilkkayit.WriteLine(comboBox2.Text);

                    ayarlarilkkayit.WriteLine(wolfCheck.CheckState);
                    ayarlarilkkayit.WriteLine(hammercheck.CheckState);
                    ayarlarilkkayit.WriteLine(comboBox1.Text);

                    ayarlarilkkayit.WriteLine(checkBox6.CheckState);
                    ayarlarilkkayit.WriteLine(petfeedcombo.Text);

                    ayarlarilkkayit.WriteLine(checkBox8.CheckState);
                }
            }
           
            Close();
            closing.Enabled = true;
        }

        private void mpCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (mpCheck.Checked == true)
            {
                mpTownText.Enabled = true;
                mpTownText.Text = "0";
            }
            else
            {
                mpTownText.Enabled = false;
                mpTownText.Text = "0";
            }
        }
        private void hpCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (hpCheck.Checked == true)
            {
                
                hpTownText.Enabled = true;
                hptownvalue = Convert.ToInt32(hpTownText.Text);
                checkBox7.Enabled = true;
                label22.ForeColor = Color.Gold;
            }
            else
            {
                checkBox7.CheckState = CheckState.Unchecked;
                checkBox7.Enabled = false;
                hpTownText.Enabled = false;
                hpTownText.Text = "0";
                label22.ForeColor = Color.DarkGoldenrod;
            }
        }
        int wolftownvalue = 0;
        private void WolfTownCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (WolfTownCheck.Checked == true)
            {
                
                wolfTownText.Enabled = true;
               
            }
            else
            {
                wolfTownText.Enabled = false;
                wolfTownText.Text = "0";
            }
        }
        int hammertownvalue = 0;
        private void HammerTownCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (HammerTownCheck.Checked == true)
            {
                hammerTownText.Enabled = true;
                
            }
            else
            {
                hammerTownText.Enabled = false;
                hammerTownText.Text = "0";
            }
        }
        IInputSimulator wolf = new InputSimulator();
        int wolflabel = 120;
        private void wolftimer_Tick(object sender, EventArgs e)
        {
            
            if (wolflabel <= 3)
            {
                if (calismadurumu == 1)
                {
                    attack2timer.Enabled = false;
                    attack1timer.Enabled = false;
                    wolf.Keyboard.Sleep(new Random().Next(900, 1000));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_S);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_S);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_W);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolflabel = 120;
                    label26.Text = wolflabel.ToString();
                    if (WolfTownCheck.CheckState == CheckState.Checked)
                    {

                        if (wolftownvalue == 0)
                        {
                            wolf.Keyboard.Sleep(new Random().Next(150, 280));
                            wolf.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                            wolf.Keyboard.Sleep(new Random().Next(50, 80));
                            wolf.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                            wolf.Keyboard.Sleep(new Random().Next(50, 80));
                            wolf.Keyboard.TextEntry("/town");
                            wolf.Keyboard.Sleep(new Random().Next(50, 80));
                            wolf.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                            wolf.Keyboard.Sleep(new Random().Next(50, 80));
                            wolf.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                            wolftownvalue = 0;
                            wolfTownText.Text = wolftownvalue.ToString();
                            close();
                        }
                        else
                        {
                            wolftownvalue--;
                        }

                        wolfTownText.Text = wolftownvalue.ToString();
                    }


                    if (attack1check.CheckState == CheckState.Checked)
                    {
                        attack1timer.Enabled = true;
                    }
                    if (attack2check.CheckState == CheckState.Checked)
                    {
                        attack2timer.Enabled = true;
                    }
                }
                else
                {
                    if (wolflabel == 0)
                    {
                        wolflabel = 0;
                        label26.Text = wolflabel.ToString();
                        wolftimer.Stop();
                        
                    }
                }
               
                
            
            }
            
        }
        IInputSimulator at1 = new InputSimulator();
        private void attack1_Tick(object sender, EventArgs e)
        {

           at1.Keyboard.Sleep(200);
           at1.Keyboard.KeyUp(VirtualKeyCode.VK_1);
           at1.Keyboard.Sleep(100);
            at1.Keyboard.KeyDown(VirtualKeyCode.VK_1);
        }
        IInputSimulator at2 = new InputSimulator();
        private void attack2_Tick(object sender, EventArgs e)
        {
            at2.Keyboard.Sleep(200);
            at2.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            at2.Keyboard.Sleep(100);
            at2.Keyboard.KeyDown(VirtualKeyCode.VK_2);
           
        }
        InputSimulator z = new InputSimulator();
        private void ztimer_Tick(object sender, EventArgs e)
        {
            IntPtr _pointer = FindWindow(new IntPtr(0), "Knight OnLine Client");
            SetForegroundWindow(_pointer);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
        }
        InputSimulator safety = new InputSimulator();
        private void safetytimer_Tick(object sender, EventArgs e)
        {
            safety.Keyboard.Sleep(new Random().Next(150, 200));
            safety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
            safety.Keyboard.Sleep(new Random().Next(60, 80));
            safety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
       }
        InputSimulator safety2 = new InputSimulator();
        private void safety2timer_Tick(object sender, EventArgs e)
        {
            safety2.Keyboard.Sleep(new Random().Next(150, 200));
            safety2.Keyboard.KeyUp(VirtualKeyCode.VK_7);
            safety2.Keyboard.Sleep(new Random().Next(50, 80));
            safety2.Keyboard.KeyDown(VirtualKeyCode.VK_7);
            if (safetyCheck.CheckState == CheckState.Checked)
            {
                safetytimer.Enabled = true; 
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (attack1check.CheckState == CheckState.Unchecked)
            {
                durum1.Text = "Otomatik Attack etkin.";
                btnattack1chk.ForeColor = Color.Red;
                attack1check.CheckState = CheckState.Checked;

            }
            else
            {
                durum1.Text = "Otomatik Attack devre dışı.";
                btnattack1chk.ForeColor = Color.Blue; ;
                attack1check.CheckState = CheckState.Unchecked;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (attack2check.CheckState == CheckState.Unchecked)
            {
                durum1.Text = "Otomatik Attack II etkin.";
                btnattackchck.ForeColor = Color.Red;
                attack2check.CheckState = CheckState.Checked;

            }
            else
            {
                durum1.Text = "Otomatik Attack II devre dışı.";
                btnattackchck.ForeColor = Color.Blue;
                attack2check.CheckState = CheckState.Unchecked;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (safety2Check.CheckState == CheckState.Unchecked)
            {
                

                btnsafety2chck.ForeColor = Color.Red;
                safety2Check.CheckState = CheckState.Checked;
                durum1.Text = "Otomatik Safety II kullanımı etkin.";
            }
            else
            {
                btnsafety2chck.ForeColor = Color.Blue;
                safety2Check.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik Safety II kullanımı devre dışı.";
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (safetyCheck.CheckState == CheckState.Unchecked)
            {
                btnsafetychck.ForeColor = Color.Red;
                safetyCheck.CheckState = CheckState.Checked;
                durum1.Text = "Otomatik Safety kullanımı etkin.";

            }
            else
            {
                btnsafetychck.ForeColor = Color.Blue;
                safetyCheck.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik Safety II kullanımı devre dışı.";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (wolfCheck.CheckState == CheckState.Unchecked)
            {
                durum1.Text = "Otomatik Wolf kullanımı etkin.";
                btnwolfchck.ForeColor = Color.Red;
                wolfCheck.CheckState = CheckState.Checked;

            }
            else
            {
                durum1.Text = "Otomatik Wolf kullanımı devre dışı.";

                btnwolfchck.ForeColor = Color.Blue;
                wolfCheck.CheckState = CheckState.Unchecked;
            }
        }
        
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(comboBox1.Text);
            int Sontime = (time * 100 * 60);
            hammertimer.Interval = Sontime;
        }
        InputSimulator hammer = new InputSimulator();
        private void hammertimer_Tick(object sender, EventArgs e)
        {
            if (HammerTownCheck.CheckState == CheckState.Checked)
            { 
                if (hammertownvalue == 0)
                {
                    hammer.Keyboard.Sleep(new Random().Next(50, 80));
                    hammer.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    hammer.Keyboard.Sleep(new Random().Next(50, 80));
                    hammer.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    hammer.Keyboard.Sleep(new Random().Next(50, 80));
                    hammer.Keyboard.TextEntry("/town");
                    hammer.Keyboard.Sleep(new Random().Next(50, 80));
                    hammer.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    hammer.Keyboard.Sleep(new Random().Next(50, 80));
                    hammer.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    hammertownvalue = 0;
                    hammerTownText.Text = hammertownvalue.ToString();
                    close();
                    hammertimer.Enabled = false;
                }
                else
                {
                    hammertownvalue--;
                }
                
                hammerTownText.Text = hammertownvalue.ToString();
            }
            hammer.Keyboard.Sleep(new Random().Next(50, 80));
            hammer.Keyboard.KeyUp(VirtualKeyCode.VK_9);
            hammer.Keyboard.Sleep(new Random().Next(50, 80));
            hammer.Keyboard.KeyDown(VirtualKeyCode.VK_9); 
        }

        private void safety2Check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void wolfCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        void pedalbuton()
        {
            
            minortimer.Enabled = true;
            minormana.Enabled = true;

        }
        int pedalcheck = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (pedalcheck == 0)
            {
                durum1.Text = "Pedal moduna alındı, hazır...";
                pedalcheck++;
            }
            else
            {
                durum1.Text = "Pedal modu kapatıldı. Hazır...";
                pedalcheck--;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (hammercheck.CheckState == CheckState.Unchecked)
            {
                btnhammerchck.ForeColor = Color.Red;
                int time = Convert.ToInt32(comboBox1.Text);
                int Sontime = (time * 1000 * 60);
                hammertimer.Interval = Sontime;
                comboBox1.Enabled = false;
                hammercheck.CheckState = CheckState.Checked;
                hammercheck.BackColor = Color.Green;
                durum1.Text = "Otomatik Hammer kullanımı etkin, "+comboBox1.Text +" dakikada bir.";
               
            }
            else
            {
                comboBox1.Enabled = true;
                btnhammerchck.ForeColor = Color.Blue;
                hammercheck.BackColor = Color.Red;
                hammercheck.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik Hammer kullanımı devre dışı.";
            }
        }
        private void hammercheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (hammercheck.CheckState == CheckState.Unchecked)
            {
                int time = Convert.ToInt32(comboBox1.Text);
                int Sontime = (time * 100 * 60);
                hammertimer.Interval = Sontime;
                hammercheck.BackColor = Color.Red;
               

            }
            else
            {
                hammercheck.BackColor = Color.Green;
               
             
            }
        }

        private void wolfCheck_CheckStateChanged(object sender, EventArgs e)
        {
            if (wolfCheck.CheckState == CheckState.Unchecked)
            {

                wolfCheck.BackColor = Color.Red;


            }
            else
            {
                wolfCheck.BackColor = Color.Green;


            }
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Unchecked)
            {

                checkBox3.BackColor = Color.Red;
            }
            else
            {
                checkBox3.BackColor = Color.Green;


            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Unchecked)
            {

                checkBox2.BackColor = Color.Red;


            }
            else
            {
                checkBox2.BackColor = Color.Green;


            }
        }

        private void attack1check_CheckStateChanged(object sender, EventArgs e)
        {
          
        }

        private void attack2check_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void safety2Check_CheckStateChanged(object sender, EventArgs e)
        {
            if (safety2Check.CheckState == CheckState.Unchecked)
            {

                safety2Check.BackColor = Color.Red;


            }
            else
            {
                safety2Check.BackColor = Color.Green;


            }
        }

        private void safetyCheck_CheckStateChanged(object sender, EventArgs e)
        {
          
        }

        private void safetyCheck_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (safetyCheck.CheckState == CheckState.Unchecked)
            {

                safetyCheck.BackColor = Color.Red;


            }
            else
            {
                safetyCheck.BackColor = Color.Green;


            }
        }

        private void safety2Check_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (safety2Check.CheckState == CheckState.Unchecked)
            {

                safety2Check.BackColor = Color.Red;


            }
            else
            {
                safety2Check.BackColor = Color.Green;


            }
        }

        private void attack2check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void attack2check_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (attack2check.CheckState == CheckState.Unchecked)
            {

                attack2check.BackColor = Color.Red;


            }
            else
            {
                attack2check.BackColor = Color.Green;


            }
        }

        private void attack1check_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (attack1check.CheckState == CheckState.Unchecked)
            {

                attack1check.BackColor = Color.Red;


            }
            else
            {
                attack1check.BackColor = Color.Green;


            }
        }
        IInputSimulator doublesafety = new InputSimulator();
        int safetysekil = 2;
        private void doublesafetytimer_Tick(object sender, EventArgs e)
        {
            
            attack2timer.Enabled = false;
            attack1timer.Enabled = false;
            
            if (safetysekil % 2 ==0)
            {
                Thread.Sleep(20);

                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);

                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);

                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_7);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80)); ;
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_7);
            }
            else
            {
                Thread.Sleep(20);
                
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);

                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);

                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.KeyUp(VirtualKeyCode.VK_8);
                doublesafety.Keyboard.Sleep(new Random().Next(50, 80));
                doublesafety.Keyboard.KeyDown(VirtualKeyCode.VK_8);


            }

            if (attack1check.CheckState == CheckState.Checked)
            {
                attack1timer.Enabled = true;
            }
            if (attack2check.CheckState == CheckState.Checked)
            {
                attack2timer.Enabled = true;
            }
            safetysekil++;
        }
        IInputSimulator pedalmana = new InputSimulator();
        private void minortimer2_Tick(object sender, EventArgs e)
        {
            pedalmana.Keyboard.Sleep(new Random().Next(50, 80));
            pedalmana.Keyboard.KeyUp(VirtualKeyCode.VK_9);
            pedalmana.Keyboard.Sleep(new Random().Next(50, 80));
            pedalmana.Keyboard.KeyDown(VirtualKeyCode.VK_9);
        }
        int hppercent = 160;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            checkForColorDifference(startingColor);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            kordinat.Text = " "+Cursor.Position.X+" , "+Cursor.Position.Y+" ";
        }

     
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            hptownvalue = Convert.ToInt32(hpTownText.Text);
        }
        IInputSimulator lgft = new InputSimulator();
        private void lighttimer_Tick(object sender, EventArgs e)
        {
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyUp(VirtualKeyCode.VK_5);
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyDown(VirtualKeyCode.VK_5);
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyUp(VirtualKeyCode.VK_5);
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyDown(VirtualKeyCode.VK_5);
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyUp(VirtualKeyCode.VK_5);
            lgft.Keyboard.Sleep(new Random().Next(50, 80));
            lgft.Keyboard.KeyDown(VirtualKeyCode.VK_5);
        }
        IInputSimulator lgft1 = new InputSimulator();
        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Checked)
            {
                lighttimer.Enabled = true;
                lgft1.Keyboard.Sleep(new Random().Next(50, 80));
                lgft1.Keyboard.KeyUp(VirtualKeyCode.VK_5);
                lgft1.Keyboard.Sleep(new Random().Next(50, 80));
                lgft1.Keyboard.KeyDown(VirtualKeyCode.VK_5);
            }
            else
            {
                lighttimer.Enabled = false;
            }
        }

        private void hpTownText_TextChanged(object sender, EventArgs e)
        {
            if (hpTownText.Text == "")
            {
                
            }
            else
            {
                hptownvalue = Convert.ToInt32(hpTownText.Text);
                if (hptownvalue < 10)
                {
                    textBox2.Text = "\r\n" + hptownvalue.ToString() + "adet HP potu kaldı.";
                }
            }
        }

        private void hammerTownText_TextChanged(object sender, EventArgs e)
        {
            if (hammerTownText.Text == "")
            {
                
            }
            else
            {
                hammertownvalue = Convert.ToInt32(hammerTownText.Text);
                if (hammertownvalue <= 3)
                {
                    textBox2.Text = "\r\n" + hammertownvalue.ToString() + " adet Hammer kaldı.";
                }
            }
           
        }

        private void hpbox_TextChanged(object sender, EventArgs e)
        {
            if (hpbox.SelectedText == "75")
            {
                hppercent = 160;
            }
            else if (hpbox.SelectedText == "90")
            {
                hppercent = 190;
            }
            else if (hpbox.SelectedText == "50")
            {
                hppercent = 120;
            }
            else if (hpbox.SelectedText == "35")
            {
                hppercent = 90;
            }
        }

        public void checkForColorDifference2(Color start)
        {

            Color starting = start;
            if (comboBox2.Text == "75")
            {
                //WORKS
                mppercent = 160;
            }
            else if (comboBox2.Text == "90")
            {
                mppercent = 194;
            }
            else if (comboBox2.Text == "50")
            {
                mppercent = 145;
            }
            else if (comboBox2.Text == "35")
            {
                mppercent = 95;
                //WORKS
            }
            Color currentColor2 = GetPixelColor(Screen.PrimaryScreen.WorkingArea.Left + mppercent, Screen.PrimaryScreen.WorkingArea.Top + 57);
            int renkkodu = (currentColor2.R + currentColor2.G + currentColor2.B);
            if (currentColor2.R <= 70 && currentColor2.G <= 95 && currentColor2.B >= 70)
            {
            }
            else
            {
                if (mpCheck.CheckState == CheckState.Checked)
                {
                    if (mptownvalue == 0)
                    {
                        mppot.Keyboard.Sleep(new Random().Next(50, 80));
                        mppot.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        mppot.Keyboard.Sleep(new Random().Next(50, 80));
                        mppot.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        mppot.Keyboard.Sleep(new Random().Next(50, 80));
                        mppot.Keyboard.TextEntry("/town");
                        mppot.Keyboard.Sleep(new Random().Next(50, 80));
                        mppot.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        mppot.Keyboard.Sleep(new Random().Next(50, 80));
                        mppot.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        mptownvalue = 0;
                        mpTownText.Text = mptownvalue.ToString();
                        close();
                    }
                    else
                    {
                        mptownvalue--;
                    }
                   
                    mpTownText.Text = mptownvalue.ToString();
                }
                mppot.Keyboard.Sleep(new Random().Next(50, 80));
                mppot.Keyboard.KeyUp(VirtualKeyCode.VK_4);
                mppot.Keyboard.Sleep(new Random().Next(50, 80));
                mppot.Keyboard.KeyDown(VirtualKeyCode.VK_4);
                mppot.Keyboard.Sleep(new Random().Next(50, 80));
                if (checkBox12.CheckState == CheckState.Checked)
                {
                    mprnwsayi--;
                    mprnwTxt.Text = mprnwsayi.ToString();
                }
            }
        }
        private void manatimer_Tick(object sender, EventArgs e)
        {
            checkForColorDifference2(startingColor);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            mptownvalue = Convert.ToInt32(mpTownText.Text);
        }

        private void mpTownText_TextChanged(object sender, EventArgs e)
        {
            if (mpTownText.Text == "")
            {
                
            }
            else
            {

                mptownvalue = Convert.ToInt32(mpTownText.Text);
                if (mptownvalue < 10)
                {
                    textBox2.Text = "\r\n" + mptownvalue.ToString() + " mana kaldı.";

                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Unchecked)
            {
                hpbox.Enabled = false;
                btnhpchck.ForeColor = Color.Red;
                checkBox3.CheckState = CheckState.Checked;
                durum1.Text = "Otomatik HP Pot kullanımı etkin. %"+hpbox.Text+"'e ayarlandı";
            }
            else
            {
                hpbox.Enabled = true;
                btnhpchck.ForeColor = Color.Blue;
                checkBox3.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik HP Pot kullanımı devre dışı.";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "75")
            {
                //WORKS
                mppercent = 160;
            }
            else if (comboBox2.Text == "90")
            {
                mppercent = 194;
            }
            else if (comboBox2.Text == "45")
            {
                mppercent = 133;
            }
            else if (comboBox2.Text == "30")
            {
                mppercent = 95;
                //WORKS
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(comboBox1.Text);
            int Sontime = (time * 1000 * 60);
            hammertimer.Interval = Sontime;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
           
   
        }

        private void button5_Click(object sender, EventArgs e)
        {



            if (this.Size.Height ==72)
            {
                groupBox1.Visible = false;

                 this.Size = new Size(421, 557);
                 ReallyCenterToScreen();
                 textBox2.Text = durum1.Text;
                if (button1.Text == "YENİLE")
                {
                    getknight();
                }
                else
                {
                    if (pedalcheck == 1)
                    {
                        pedalbuton();
                    }
                    else
                    {
                        if (kucultmecheck == 1)
                        {
                            groupBox1.Visible = true;
                            this.Size = new Size(205, 72);
                            ReallyCenterToScreen2();
                            textBox2.Text = durum1.Text;
                            button8.Enabled = true;
                            button7.Enabled = false;
                        }
                        comboBox1.Enabled = false;
                        hpbox.Enabled = false;
                        comboBox2.Enabled = false;
                        button1.Enabled = false;
                        button1.BackColor = Color.DarkGray;
                        button2.Enabled = true;
                        button2.BackColor = Color.SaddleBrown;
                        
                    }
                }
            }
            else
            {
                groupBox1.Visible = true;
                this.Size = new Size(205, 72);
                ReallyCenterToScreen2();
                textBox2.Text = durum1.Text;
            }
            start();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            skillbar f2 = new skillbar();
            f2.ShowDialog(); // Shows Form2
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pedalcheck == 1)
            {
                pedalbuton();
            }
            else
            {
                comboBox1.Enabled = false;
                hpbox.Enabled = false;
                comboBox2.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = true;
                start();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = true;
            close();
        }

        private void S(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            Close();
            closing.Enabled = true;
        }
        protected void ReallyCenterToScreen()
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            this.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Width - this.Width) / 2),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this.Height) / 2)
            };
        }
        protected void ReallyCenterToScreen2()
        {
            Screen screen = Screen.FromControl(this);

            Rectangle workingArea = screen.WorkingArea;
            this.Location = new Point()
            {
                X = Math.Max(workingArea.X, workingArea.X + (workingArea.Left)),
                Y = Math.Max(workingArea.Y, workingArea.Y + (workingArea.Height - this .Height*4))
            };
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (this.Size.Height == 72)
            {
                button5.Visible = true;  
                this.Size = new Size(421, 557);
                ReallyCenterToScreen();
                groupBox1.Visible = false;
            }
            else
            {
                button5.Visible = false;
                this.Size = new Size(205, 72);
                ReallyCenterToScreen2();
                groupBox1.Visible = true;
                
            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (checkBox2.CheckState == CheckState.Unchecked)
            {
                comboBox2.Enabled = false;
               btnmanachck.ForeColor = Color.Red;
                checkBox2.CheckState = CheckState.Checked;
                durum1.Text = "Otomatik MP Pot kullanımı etkin. % " + comboBox2.Text + "'e ayarlandı";
            }
            else
            {
                comboBox2.Enabled = true;
                btnmanachck.ForeColor = Color.Blue;
                checkBox2.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik MP Pot kullanımı devre dışı.";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Unchecked)
            {
             
                button11.ForeColor = Color.Red;
                IntPtr _pointer = FindWindow(new IntPtr(0), "Knight OnLine Client");
                SetForegroundWindow(_pointer);
                checkBox4.CheckState = CheckState.Checked;
                durum1.Text = "Otomatik Light Feet kullanımı etkin.";

            }
            else
            {
               

                button11.ForeColor = Color.Blue;
                checkBox4.CheckState = CheckState.Unchecked;
                durum1.Text = "Otomatik Light Feet kullanımı devre dışı.";
            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void durum1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = durum1.Text;
            durum1.Cursor = Cursors.Arrow;
            if (durum1.Text == "Yeni bir güncelleme mevcut. İndirmek için tıklayın.")
            {
                
                durum1.Cursor = Cursors.Hand;

            }
         
        }
        InputSimulator mouseclick = new InputSimulator();
        private void MouseClick2()
        {

          
            Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 90);
            mouseclick.Mouse.Sleep(400);

            mouseclick.Mouse.LeftButtonUp();
            
        }
       
       
        public void itemtik()
        {
           

           
            MouseClick2();
        }
        private Bitmap Screenshot()
        {
            // this is where we will store a snapshot of the screen
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //this.BackgroundImage = bmpScreenshot;
            // creates a graphics object so we can draw the screen in the bitmap (bmpScreenshot)
            Graphics g = Graphics.FromImage(bmpScreenshot);

            // copy from screen into the bitmap we created
            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);

            // return the screenshot
            return bmpScreenshot;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            mouseclick.Keyboard.Sleep(300);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
            mouseclick.Keyboard.Sleep(100);

            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_P);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_P);
            Thread.Sleep(100);
            Bitmap bmpScreenshot = Screenshot();
            Point location;
            bool success = FindBitmap(Properties.Resources.petfeedson2, bmpScreenshot, out location);
            if (success == false)
            {
                durum1.Text = "item Slotu bulunamadı";
            }
            else
            {
                Cursor.Position = location;
                mouseclick.Mouse.Sleep(120);
                mouseclick.Mouse.LeftButtonDown();
                mouseclick.Mouse.Sleep(110);
                mouseclick.Mouse.LeftButtonUp();
                Thread.Sleep(30);
            }
           
                Bitmap bmpScreenshot2 = Screenshot();
                Point Location2;
                bool success2 = FindBitmap2(Properties.Resources.petkemik, bmpScreenshot2, out Location2);
                if (success2 == false)
                {
                    durum1.Text = "kemik bulunamadı";
                }
                else
                {
                    Bitmap bmpScreenshot6 = Screenshot();
                    Point Location6;
                    bool success6 = FindBitmap2(petresource, bmpScreenshot6, out Location6);
                    if (success6 == false)
                    {
                        durum1.Text = "Inventory'de "+comboBox5.Text + " bulunamadı.";
                    }
                    else
                    {
                        Cursor.Position = Location6;
                        mouseclick.Mouse.Sleep(100);
                        mouseclick.Mouse.LeftButtonDown();
                        mouseclick.Mouse.Sleep(120);


                        Cursor.Position = Location2;
                        mouseclick.Mouse.Sleep(80);
                        mouseclick.Mouse.LeftButtonUp();
                        mouseclick.Mouse.Sleep(100);
                        Thread.Sleep(50);
                    }
                    //Cursor.Position = new Point((Screen.PrimaryScreen.WorkingArea.Right - 50), (Screen.PrimaryScreen.WorkingArea.Height / 2) - 90);
                   
                }
               
                Bitmap bmpScreenshot3 = Screenshot();
                Point Location3;
                bool success3 = FindBitmap3(Properties.Resources.petfeedyes, bmpScreenshot3, out Location3);
                if (success3 == false)
                {
                    durum1.Text = "Köpek besleme başarısız.";
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_P);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_P);
                    mouseclick.Keyboard.Sleep(300);

                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);

                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);

                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                }
                else
                {
                    Cursor.Position = Location3;
                    mouseclick.Mouse.LeftButtonDown();
                    mouseclick.Mouse.Sleep(150);
                    mouseclick.Mouse.LeftButtonUp();
                    mouseclick.Mouse.Sleep(200);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_P);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_P);
                    mouseclick.Keyboard.Sleep(300);

                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);

                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);

                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.F9);
                    mouseclick.Keyboard.Sleep(100);
                    

                }
                    

           
        }
       
        private bool FindBitmap(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location = Point.Empty;
            return false;
        }
        private bool FindBitmap2(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location = Point.Empty;
            return false;
        }
        private bool FindBitmap3(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location = Point.Empty;
            return false;
        }
        private bool FindBitmap4(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location4)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location4 = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location4 = Point.Empty;
            return false;
        }
        private bool FindBitmap5(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location5)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location5 = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location5 = Point.Empty;
            return false;
        }
        private bool FindBitmap6(Bitmap bmpNeedle, Bitmap bmpHaystack, out Point location6)
        {
            for (int outerX = 0; outerX < bmpHaystack.Width - bmpNeedle.Width; outerX++)
            {
                for (int outerY = 0; outerY < bmpHaystack.Height - bmpNeedle.Height; outerY++)
                {
                    for (int innerX = 0; innerX < bmpNeedle.Width; innerX++)
                    {
                        for (int innerY = 0; innerY < bmpNeedle.Height; innerY++)
                        {
                            Color cNeedle = bmpNeedle.GetPixel(innerX, innerY);
                            Color cHaystack = bmpHaystack.GetPixel(innerX + outerX, innerY + outerY);

                            if (cNeedle.R != cHaystack.R || cNeedle.G != cHaystack.G || cNeedle.B != cHaystack.B)
                            {
                                goto notFound;
                            }
                        }
                    }
                    location6 = new Point(outerX, outerY);
                    return true;
                notFound:
                    continue;
                }
            }
            location6 = Point.Empty;
            return false;
        }
        int kucultmecheck = 1;
        private void checkBox5_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == CheckState.Checked)
            {
                kucultmecheck = 1;
            }
            else
            {
                kucultmecheck = 0;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
         
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("You pressed the enter key");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void wolfTownText_TextChanged(object sender, EventArgs e)
        {
            if (wolfTownText.Text == "")
            {
                
            }
            else
            {
                wolftownvalue = Convert.ToInt32(wolfTownText.Text);
                if (wolftownvalue <= 40)
                {
                     textBox2.Text =   "\r\n"+ wolftownvalue +  "adet wolf kaldı.";
                }

            }
        }

        private void mpTownText_Leave(object sender, EventArgs e)
        {
            if (mpTownText.Text == "")
            {
                mpCheck.CheckState = CheckState.Unchecked;
                mptownvalue = 0;
            }
        }

        private void hpTownText_Leave(object sender, EventArgs e)
        {
            if (hpTownText.Text == "")
            {
                hpCheck.CheckState = CheckState.Unchecked;
                hptownvalue = 0;
            }
        }

        private void hammerTownText_Leave(object sender, EventArgs e)
        {
            if (hammerTownText.Text== "")
            {
               HammerTownCheck.CheckState = CheckState.Unchecked;
                hammertownvalue = 0;
            }
        }

        private void wolfTownText_Leave(object sender, EventArgs e)
        {
            if (wolfTownText.Text == "")
            {
                WolfTownCheck.CheckState = CheckState.Unchecked;
                wolftownvalue = 0; 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            durum1.Text = textBox2.Text;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                getknight();
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == CheckState.Checked)
            {
                durum1.Text = "Otomatik küçültme etkinleştirildi.";
            }
            else
            {
                durum1.Text = "Otomatik küçültme devre dışı bırakıldı.";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            durum1.Text = "Peti besleyeceğiniz itemi Inventory'nizin en sağ ve üstten 2. Slotuna yerleştirin.";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            durum1.Text = "HP Potunuz bittiğinde minor basmasını istiyorsanız seçin.";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == CheckState.Checked)
            {
                if (comboBox5.Text == "Leaf")
                {
                    petresource = Properties.Resources.petleaf;
                }
                else if (comboBox5.Text == "Bread")
                {
                    petresource = Properties.Resources.petbread;

                }
                else if (comboBox5.Text == "Milk")
                {
                    petresource = Properties.Resources.petmilk;

                }
                comboBox5.Enabled = false;
                petfeedcombo.Enabled = false;
                petfeed.Interval = ((Convert.ToInt32(petfeedcombo.Text) * 60) * 1000);
                
                durum1.Text = "Otomatik Pet besleme etkinleştirildi.";
            }
            else
            {
                comboBox5.Enabled = true;
                petfeedcombo.Enabled = true;
                petfeed.Interval = (10000);
                petfeed.Enabled = false;
                durum1.Text = "Otomatik Pet besleme devre dışı bırakıldı.";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.CheckState == CheckState.Checked)
            {
              
                durum1.Text = "Oto Minor'e geçiş etkinleştirildi.";
            }
            else
            {
              
                durum1.Text = "Oto Minör'e geçiş devre dışı bırakıldı";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void opening_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                this.TopMost = true;
                opening.Enabled = false;
            }
            else
            {
                this.Opacity = this.Opacity + 0.05;
            }
            
        }

        private void closing_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 0.03)
            {
                Application.Exit();
            }
            else
            {
                this.Opacity = this.Opacity - 0.01;
            }
        }

        private void TimeInterval_Tick(object sender, EventArgs e)
        {
           
            if (wolflabel == 0)
            {
                if (wolfCheck.CheckState == CheckState.Checked)
                {
                     attack2timer.Enabled = false;
                attack1timer.Enabled = false;
                wolf.Keyboard.Sleep(new Random().Next(900, 1000));
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyDown(VirtualKeyCode.VK_S);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyUp(VirtualKeyCode.VK_S);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyDown(VirtualKeyCode.VK_W);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_W);
                    wolf.Keyboard.Sleep(new Random().Next(50, 80));
                    wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6); 

                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                wolf.Keyboard.Sleep(new Random().Next(50, 80));
                wolflabel = 120;
                label26.Text = wolflabel.ToString();
                if (WolfTownCheck.CheckState == CheckState.Checked)
                {

                    if (wolftownvalue == 0)
                    {
                        wolf.Keyboard.Sleep(new Random().Next(150, 280));
                        wolf.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        wolf.Keyboard.Sleep(new Random().Next(50, 80));
                        wolf.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        wolf.Keyboard.Sleep(new Random().Next(50, 80));
                        wolf.Keyboard.TextEntry("/town");
                        wolf.Keyboard.Sleep(new Random().Next(50, 80));
                        wolf.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        wolf.Keyboard.Sleep(new Random().Next(50, 80));
                        wolf.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        wolftownvalue = 0;
                        wolfTownText.Text = wolftownvalue.ToString();
                        close();
                    }
                    else
                    {
                        wolftownvalue--;
                    }

                    wolfTownText.Text = wolftownvalue.ToString();
                }


                if (attack1check.CheckState == CheckState.Checked)
                {
                    attack1timer.Enabled = true;
                }
                if (attack2check.CheckState == CheckState.Checked)
                {
                    attack2timer.Enabled = true;
                }
                }
                else
                {
                    wolfsayac.Enabled = false;
                    wolflabel = 120;
                }
              
              

            }
            else
            {
                wolflabel--;
                label26.Text = wolflabel.ToString();
            }
           
        }

        private void petfeedcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == CheckState.Checked)
            {
                petfeed.Interval = ((Convert.ToInt32(petfeedcombo.Text) * 60) * 1000);
            }
            else
            {

            }
            
        }

        private void petfeedcombo_TextChanged(object sender, EventArgs e)
        {
            if (checkBox6.CheckState == CheckState.Checked)
            {
                petfeed.Interval = ((Convert.ToInt32(petfeedcombo.Text) * 60) * 1000);
            }
            else
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            durum1.Text = "Transformation Scroll'unuzu Skill tablonuzun 2. Sayfasında '9'.cu tuşa yerleştirin. (60 Dakikada bir basılır)";
        }
        InputSimulator ts = new InputSimulator();
        private void tstimer_Tick(object sender, EventArgs e)
        {
            attack1timer.Enabled = false;
            attack2timer.Enabled = false;
            ts.Keyboard.KeyDown(VirtualKeyCode.F2);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.F2);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyDown(VirtualKeyCode.VK_9);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.VK_9);
            ts.Keyboard.Sleep(350);
            ts.Keyboard.KeyDown(VirtualKeyCode.TAB);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.TAB);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
            ts.Keyboard.Sleep(350);
            ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyDown(VirtualKeyCode.F1);
            ts.Keyboard.Sleep(150);
            ts.Keyboard.KeyUp(VirtualKeyCode.F1);
            ts.Keyboard.Sleep(150);
            tssayac.Enabled = true;
            if (attack1check.CheckState == CheckState.Checked)
            {
                attack1timer.Enabled = true;
            }
            if (attack2check.CheckState == CheckState.Checked)
            {
                attack2timer.Enabled = true;
            }
        }
        int tssayac1 = 0;
        private void tssayac_Tick(object sender, EventArgs e)
        {
            if (tssayac1 == 0 )
            {
                if (tstimer.Enabled == true)
                {
                    tssayac1 = 60;
                    label27.Text = tssayac1.ToString();

                }
                else
                {
                    tssayac.Enabled = false;
                    tssayac1 = 60;
                    label27.Text = tssayac1.ToString();
                }
            }
            else
            {
                tssayac1--;
                label27.Text = tssayac1.ToString();
            }
           
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            int time = Convert.ToInt32(comboBox1.Text);
            int Sontime = (time * 1000 * 60);
            hammertimer.Interval = Sontime;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            durum1.Text = "Botu her başlattığınızda Botu otomatik olarak mini haline alır. ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
           
        }

        private void attack1check_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {
            checkforupdate();
        }

        private void durum1_Click(object sender, EventArgs e)
        {
            if (durum1.Text == "Yeni bir güncelleştirme mevcut. İndirmek için tıklayın.")
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri("www.mabracelet.com/Vader-Setup.rar"), path
                    );
                }

            }

        }
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            durum1.Text = "İndirme = %"+(e.ProgressPercentage).ToString();
        }
        private void hpbox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (hpbox.SelectedText == "75")
            {
                hppercent = 160;
            }
            else if (hpbox.SelectedText == "90")
            {
                hppercent = 190;
            }
            else if (hpbox.SelectedText == "50")
            {
                hppercent = 120;
                durum1.Text = "%50 HP pot basma özelliği beta aşamasındadır. Önerilmez.";
            }
            else if (hpbox.SelectedText == "35")
            {
                durum1.Text = "%50 HP pot basma özelliği beta aşamasındadır. Önerilmez.";

                hppercent = 100;
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            
        }
        private void label29_Click(object sender, EventArgs e)
        {
            if ( groupBox2.Visible == false)
            {
                label29.Font = new Font("Perpetua Titling MT", 13, FontStyle.Underline);
                label14.Font = new Font("Perpetua Titling MT", 11, FontStyle.Underline);
                label29.ForeColor = Color.Gold;
                label14.ForeColor = Color.DarkGoldenrod;
                groupBox2.Visible = true;
            }
            
        }

        private void label14_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == true)
            {
                label14.Font = new Font("Perpetua Titling MT", 13, FontStyle.Underline);
                label29.Font = new Font("Perpetua Titling MT", 11, FontStyle.Underline);
                label29.ForeColor = Color.DarkGoldenrod;
                label14.ForeColor = Color.Gold;
                groupBox2.Visible = false;
            }
            
        }

        private void label30_Click(object sender, EventArgs e)
        {
            
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            durum1.Text = "İnventory'nizde seçili item bittiğinde Magic Bag'den inventory'nize itemleri otomatik çeker.";
        }

        private void extratimer_Tick(object sender, EventArgs e)
        {
            
        }
        int hprnwsayi,mprnwsayi = 0;
        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.CheckState == CheckState.Checked)
            {
                arrowtimer.Interval = (((Convert.ToInt32(comboBox3.Text) * 60)*60)*1000); 
                arrowtimer.Enabled = true;
            }
            else
            {
                arrowtimer.Interval = (((Convert.ToInt32(comboBox3.Text) * 60) * 60) * 1000); 
                arrowtimer.Enabled = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.CheckState == CheckState.Checked)
            {
                hpCheck.CheckState = CheckState.Unchecked;
                hpCheck.Enabled = false;
                hprnwsayi = Convert.ToInt32(hprnwTxt.Text);
                hprnwTxt.Enabled = false;
            }
            else
            {
                hpCheck.Enabled = true;
                hprnwTxt.Enabled = true;
            }
        }

        private void hprnwTxt_TextChanged(object sender, EventArgs e)
        {
            if (hprnwTxt.Text == "0" && checkBox11.CheckState == CheckState.Checked)
            {
                mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                Thread.Sleep(500);
                Bitmap bmpScreenshot5 = Screenshot();
                Point Location5;
                bool success5 = FindBitmap3(Properties.Resources.hppotrnw3, bmpScreenshot5, out Location5);
                if (success5 == false)
                {
                    durum1.Text = "Magic Bag'de HP Potu bulunamadı.";
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                }
                else
                {
                    Cursor.Position = Location5;
                    mouseclick.Mouse.RightButtonDown();
                    mouseclick.Mouse.Sleep(90);
                    mouseclick.Mouse.RightButtonUp();
                    mouseclick.Mouse.Sleep(90);
                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    durum1.Text = "HP Potu başarıyla Inventory'ye taşındı.";
                }
            }
           
        }

        private void arrowtimer_Tick(object sender, EventArgs e)
        {
            mouseclick.Keyboard.Sleep(300);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
            mouseclick.Keyboard.Sleep(100);
            Thread.Sleep(500);
            Bitmap bmpScreenshot4 = Screenshot();

            Point Location4;
            bool success4 = FindBitmap4(Properties.Resources.arrow1, bmpScreenshot4, out Location4);
            if (success4 == false)
            {
                durum1.Text = "720'lik Kırmızı Pot bulunamadı.";
                mouseclick.Keyboard.Sleep(300);
                mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
            }
            else
            {
                durum1.Text = "HP Pot Magic Bag'den alındı.";
                Cursor.Position = Location4;
                mouseclick.Mouse.RightButtonDown();
                mouseclick.Mouse.Sleep(90);
                mouseclick.Mouse.RightButtonUp();
                mouseclick.Mouse.Sleep(90);
                mouseclick.Keyboard.Sleep(300);
                mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);

            }
        }

        private void mprnwTxt_TextChanged(object sender, EventArgs e)
        {
            if (mprnwTxt.Text == "0" && checkBox12.CheckState == CheckState.Checked)
            {
                mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                mouseclick.Keyboard.Sleep(100);
                Thread.Sleep(500);
                Bitmap bmpScreenshot5 = Screenshot();
                Point Location5;
                
                bool success5 = FindBitmap3(mpresource, bmpScreenshot5, out Location5);
                if (success5 == false)
                {
                    durum1.Text = "Magic Bag'de 1920 MP Potu bulunamadı.";
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                }
                else
                {
                    Cursor.Position = Location5;
                    mouseclick.Mouse.RightButtonDown();
                    mouseclick.Mouse.Sleep(90);
                    mouseclick.Mouse.RightButtonUp();
                    mouseclick.Mouse.Sleep(90);
                    mouseclick.Keyboard.Sleep(300);
                    mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_I);
                    mouseclick.Keyboard.Sleep(100);
                    durum1.Text = "MP Potu başarıyla Inventory'ye taşındı.";
                }
            }
        }

        Bitmap mpresource, petresource;
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.CheckState == CheckState.Checked)
            {
                mpCheck.Enabled = false;
                mpCheck.CheckState = CheckState.Unchecked;
                mprnwsayi = Convert.ToInt32(mprnwTxt.Text);
                mprnwTxt.Enabled = false;
                comboBox4.Enabled = false;
                if (comboBox4.Text == "1920")
                {
                   mpresource = Properties.Resources.mprnwpic;
                }
                else
                {
                   mpresource = Properties.Resources.mp960;
                }
            }
            else
            {
                mpCheck.Enabled = true;
                mpCheck.CheckState = CheckState.Unchecked;
                mprnwTxt.Enabled = true;
                comboBox4.Enabled = true;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            durum1.Text = "Ortalama 9995 Ok'un bitme süresi 5 saattir.";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            durum1.Text = "720'lik Kırmızı HP Potu kullanıyor olmalısınız.";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            durum1.Text = "1920'lik Mavi MP Potu (Büyük) kullanıyor olmalısınız.";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            durum1.Text = "Yazılı Pot sayısı bittiğinde Magic Bag'den 1920 MP Pot çeker.";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            durum1.Text = "Yazılı Pot sayısı bittiğinde Magic Bag'den 720 HP Pot çeker.";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            durum1.Text = "Magic Bag'e koyduğunuz Arrowları belirttiğiniz süreye göre Inventory'ye çeker.";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "1920")
            {
                mpresource = Properties.Resources.mprnwpic;
            }
            else
            {
                mpresource = Properties.Resources.mp960;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skill sayfanızda seri Attack skilinizi 1'e Taunt'u ise 2'ye yerleştirin.","Bilgilendirme!");
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
            {
                close();
            IntPtr _pointer = FindWindow(new IntPtr(0), "Knight OnLine Client");
            SetForegroundWindow(_pointer);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_E);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_E);
            mouseclick.Keyboard.Sleep(100);
            followtimer.Enabled = true;
            button11.ForeColor = Color.Red;
            checkBox4.CheckState = CheckState.Checked;
            }
            else
            {
                button11.ForeColor = Color.Blue;
                checkBox4.CheckState = CheckState.Unchecked;
                followtimer.Enabled = false;
            }
       

            
        }

        private void followtimer_Tick(object sender, EventArgs e)
        {
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(100);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Leaf")
            {
                  petresource = Properties.Resources.petleaf;
            }
            else if (comboBox5.Text == "Bread")
            {
                petresource = Properties.Resources.petbread;

            }
            else if (comboBox5.Text == "Milk")
            {
                petresource = Properties.Resources.petmilk;

            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.CheckState == CheckState.Checked) 
            {
                start();
                ztimer.Enabled = false;
                attack1timer.Enabled = false;
                attack2timer.Enabled = false;
            }
            else
            {
                close();   
            }
        
        }
        
        private void keypresstimer_Tick(object sender, EventArgs e)
        {
            short keyState = GetAsyncKeyState(VK_SNAPSHOT);

            //Check if the MSB is set. If so, then the key is pressed.
            bool prntScrnIsPressed = ((keyState >> 15) & 0x0001) == 0x0001;

            //Check if the LSB is set. If so, then the key was pressed since
            //the last call to GetAsyncKeyState
            bool unprocessedPress = ((keyState >> 0) & 0x0001) == 0x0001;

            if (prntScrnIsPressed)
            {
                if (minortimer.Enabled == false)
                
               {
                   durum1.Text = "Pedal Açık";
                    minortimer.Enabled = true;
                    minormana.Enabled = true;
                    manatimer.Enabled = true;
                }
                else
                {
                    durum1.Text = "Pedal Kapalı";
                   minortimer.Enabled = false;
                    minormana.Enabled = false;
                    manatimer.Enabled = false;
                }
            }

            if (unprocessedPress)
            {
                if (minortimer.Enabled == false)
                {
                    durum1.Text = "Pedal Açık";
                    minortimer.Enabled = true;
                    minormana.Enabled = true;
                    manatimer.Enabled = true;
                }
                else
                {
                    durum1.Text = "Pedal Kapalı";
                    minortimer.Enabled = false;
                    minormana.Enabled = false;
                    manatimer.Enabled = false;
                }
            }
        }
        int skill = 0;
        private void timer2_Tick_1(object sender, EventArgs e)
        {
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_0);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_0);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_9);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_9);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_8);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_8);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_7);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_7);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_6);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_6);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            mouseclick.Keyboard.Sleep(100);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
          
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_Z);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_Z);
            r();
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_2);
            mouseclick.Keyboard.Sleep(100);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            mouseclick.Keyboard.Sleep(100);

        }
        void r()
        {
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(300);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(300);
            mouseclick.Keyboard.KeyDown(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(300);
            mouseclick.Keyboard.KeyUp(VirtualKeyCode.VK_R);
            mouseclick.Keyboard.Sleep(300);
        }
        private void rtimer_Tick(object sender, EventArgs e)
        {
            r();
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                rtimer.Enabled = true ;
                warriortaunttimer.Enabled = false;
            }
            else if (radioButton2.Checked == true)
            {
                rtimer.Enabled = false;
                warriortaunttimer.Enabled = true;
            }
            durum1.Text = "Bot çalışıyor...";
            ztimer.Enabled = true;
            if (checkBox3.CheckState == CheckState.Checked)
            {
                timer1.Enabled = true;
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                manatimer.Enabled = true;
            }
            warriortimer.Enabled = true;
            if (checkBox8.CheckState == CheckState.Checked)
            {
                if (tssayac1 == 0)
                {
                    rtimer.Enabled = false;
                    asastimer.Enabled = false;
                    ts.Keyboard.KeyDown(VirtualKeyCode.F2);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.F2);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyDown(VirtualKeyCode.VK_9);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.VK_9);
                    ts.Keyboard.Sleep(350);
                    ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyDown(VirtualKeyCode.TAB);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.TAB);
                    ts.Keyboard.Sleep(150);

                    ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    ts.Keyboard.Sleep(350);
                    ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyDown(VirtualKeyCode.F6);
                    ts.Keyboard.Sleep(150);
                    ts.Keyboard.KeyUp(VirtualKeyCode.F6);
                    ts.Keyboard.Sleep(150);
                    rtimer.Enabled = true;
                    asastimer.Enabled = true;
                }

                tstimer.Enabled = true;
            }
            if (kucultmecheck == 1)
            {
                groupBox1.Visible = true;
                this.Size = new Size(205, 72);
                ReallyCenterToScreen2();
                textBox2.Text = durum1.Text;
                button8.Enabled = true;
                button7.Enabled = false;
            }
            comboBox1.Enabled = false;
            hpbox.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
            button1.BackColor = Color.DarkGray;
            button2.Enabled = true;
            button2.BackColor = Color.SaddleBrown;
        }

        private void warriortimer_Tick(object sender, EventArgs e)
        {
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_1);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_1);
            if (radioButton1.Checked == true)
            {
                r();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
            }

        }

        private void warriortaunttimer_Tick(object sender, EventArgs e)
        {
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyUp(VirtualKeyCode.VK_2);
            z.Keyboard.Sleep(new Random().Next(50, 80));
            z.Keyboard.KeyDown(VirtualKeyCode.VK_2);
        }

        private void button26_Click(object sender, EventArgs e)
        {
           
                if (checkBox8.CheckState == CheckState.Checked)
                {
                    if (tssayac1 == 0)
                    {
                        rtimer.Enabled = false;
                        asastimer.Enabled = false;
                        ts.Keyboard.KeyDown(VirtualKeyCode.F2);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.F2);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.VK_9);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.VK_9);
                        ts.Keyboard.Sleep(350);
                        ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.DOWN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.TAB);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.TAB);
                        ts.Keyboard.Sleep(150);

                        ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(350);
                        ts.Keyboard.KeyDown(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.RETURN);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyDown(VirtualKeyCode.F6);
                        ts.Keyboard.Sleep(150);
                        ts.Keyboard.KeyUp(VirtualKeyCode.F6);
                        ts.Keyboard.Sleep(150);
                        rtimer.Enabled = true;
                        asastimer.Enabled = true;
                    }

                    tstimer.Enabled = true;
                }
                ztimer.Enabled = true;
                rtimer.Enabled = true;
                asastimer.Enabled = true;
                if (checkBox3.CheckState == CheckState.Checked)
                {
                    timer1.Enabled = true;
                }
                if (checkBox2.CheckState == CheckState.Checked)
                {
                    manatimer.Enabled = true;
                }
                if (wolfCheck.CheckState == CheckState.Checked)
                {
                    if (wolflabel < 3 || wolflabel == 120)
                    {
                        wolf.Keyboard.Sleep(200);
                        wolf.Keyboard.KeyUp(VirtualKeyCode.F3);
                        wolf.Keyboard.Sleep(100);
                        wolf.Keyboard.KeyDown(VirtualKeyCode.F3);
                        wolf.Keyboard.Sleep(200);
                        wolf.Keyboard.KeyUp(VirtualKeyCode.VK_6);
                        wolf.Keyboard.Sleep(100);
                        wolf.Keyboard.KeyDown(VirtualKeyCode.VK_6);
                        wolf.Keyboard.Sleep(200);
                        wolf.Keyboard.KeyUp(VirtualKeyCode.F6);
                        wolf.Keyboard.Sleep(100);
                        wolf.Keyboard.KeyDown(VirtualKeyCode.F6);
                        wolfsayac.Enabled = true;
                        wolflabel = 120;
                        label26.Text = wolflabel.ToString();
                        wolftimer.Enabled = true;
                    }
                }
                if (kucultmecheck == 1)
                {
                    groupBox1.Visible = true;
                    this.Size = new Size(205, 72);
                    ReallyCenterToScreen2();
                    textBox2.Text = durum1.Text;
                    button8.Enabled = true;
                    button7.Enabled = false;
                }
                comboBox1.Enabled = false;
                hpbox.Enabled = false;
                comboBox2.Enabled = false;
                button1.Enabled = false;
                button1.BackColor = Color.DarkGray;
                button2.Enabled = true;
                button2.BackColor = Color.SaddleBrown;
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            labelkucukduraklat1.Visible = true;
        }

        private void labelkucukduraklat_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            labelkucukduraklat1.Visible = true;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            labelkucukduraklat1.Visible = false;
        }

        private void labelkucukduraklat_MouseClick_1(object sender, MouseEventArgs e)
        {
            

        }

        private void labelkucukduraklat_Click(object sender, EventArgs e)
        {
            close();
            labelkucukduraklat1.Visible = false;
            button5.Visible = true;
            this.Size = new Size(421, 557);
            ReallyCenterToScreen();
            groupBox1.Visible = false;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox10_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {
            close();
            labelkucukduraklat1.Visible = false;
            button5.Visible = true;
            this.Size = new Size(421, 557);
            ReallyCenterToScreen();
            groupBox1.Visible = false;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int Sontime = (35 * 1000 * 60);
            GenieTimer.Interval = Sontime;
            GenieTimer.Enabled = true;
            if (kucultmecheck == 1)
            {
                groupBox1.Visible = true;
                this.Size = new Size(205, 72);
                ReallyCenterToScreen2();
                textBox2.Text = durum1.Text;
                button8.Enabled = true;
                button7.Enabled = false;
            }
        }

        private void GenieTimer_Tick(object sender, EventArgs e)
        {

            IntPtr _pointer = FindWindow(new IntPtr(0), "Knight OnLine Client");
            SetForegroundWindow(_pointer);
            hammer.Keyboard.Sleep(new Random().Next(350, 480));
            hammer.Keyboard.KeyUp(VirtualKeyCode.VK_9);
            hammer.Keyboard.Sleep(new Random().Next(50, 80));
            hammer.Keyboard.KeyDown(VirtualKeyCode.VK_9);  
        }
    }
}

