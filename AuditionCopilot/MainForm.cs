using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AuditionCopilot.Properties;
using App_csharp;



namespace AuditionCopilot
{
    
    public partial class MainForm : Form
    {
        
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        List<Keys> lastKeys = new List<Keys>();
        private object syncLock = new object();
        private CDD dd;
        int newX;
        private bool prepare = true;
        private Bitmap bmp;
        private int left = 0;
        private int lineX = 118; 
        public static bool open = false;
        [DllImport("User32.dll")]
        private extern static IntPtr GetDC(IntPtr hWnd);


        private HSLFiltering hslFilter = new HSLFiltering(new AForge.IntRange(0, 18), new AForge.Range(0.2f, 1), new AForge.Range(0.2f, 1));
        private Grayscale grayscale = Grayscale.CommonAlgorithms.BT709;
        private Threshold threshold = new Threshold(60);
        private BlobCounter blobCounter = new BlobCounter()
        {
            FilterBlobs = true,
            MinWidth = 10,
            MinHeight = 10,
            MaxWidth = 20,
            MaxHeight = 20
        };


        Rectangle rectKeys, rectBall;

        int currX, minX, maxX;

        Dictionary<Keys, Bitmap> dicTemplate = new Dictionary<Keys, Bitmap>();
        bool inputAvailable = false;



        public MainForm()
        {

            InitializeComponent();
        }
        static Point? GetWindowPosition(string windowTitle)
        {
           
            IntPtr hWnd = FindWindow(null, windowTitle);

            if (hWnd == IntPtr.Zero)
            {
                return null;
            }

          
            if (GetWindowRect(hWnd, out RECT rect))
            {
                int windowX = rect.Left;
                int windowY = rect.Top;

                return new Point(windowX, windowY);
            }
            else
            {
                return null; 
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

            dd = new CDD();
            label2.Text = left.ToString(); 


            UpdateLinePosition();

           // Point? windowPosition = GetWindowPosition("DjDjau.com");






            Point? windowPosition = GetWindowPosition("DjDjau.com");

            rectKeys = new Rectangle(windowPosition.Value.X+275, windowPosition.Value.Y+587, this.picKey1.Width, this.picKey1.Height); //275  560
            rectBall = new Rectangle(windowPosition.Value.X+515, windowPosition.Value.Y+566, this.picBall1.Width, this.picBall1.Height);//由于私服公告栏的原因,官方用户如果不能正确识别按键，适当将566的值改小,例如536
            bmp = new Bitmap(rectBall.Width, rectBall.Height, PixelFormat.Format32bppArgb);
            var unit = GraphicsUnit.Pixel;
            dicTemplate[Keys.NumPad4] = Resources.numpad_4.Clone(Resources.numpad_4.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad6] = Resources.numpad_6.Clone(Resources.numpad_6.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad8] = Resources.numpad_8.Clone(Resources.numpad_8.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad2] = Resources.numpad_2.Clone(Resources.numpad_2.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad1] = Resources.numpad_1.Clone(Resources.numpad_1.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad9] = Resources.numpad_9.Clone(Resources.numpad_9.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad3] = Resources.numpad_3.Clone(Resources.numpad_3.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            dicTemplate[Keys.NumPad7] = Resources.numpad_7.Clone(Resources.numpad_7.GetBounds(ref unit), PixelFormat.Format8bppIndexed);
            



            Task.Factory.StartNew(() =>
            {

                while (true)
                {

                    newX = GetBallX();
                   

                }
            });
            Task.Factory.StartNew(() =>
            {

                while (true)
                {
                    

                    if (newX < 0)
                    {
                        minX = 999;
                        maxX = 0;
                        
                        continue;
                    }
                    var percent = 0;

                    if (Math.Abs(newX - currX) > 5)
                    {
                        currX = newX;
                        continue;
                    }
                    if (newX > currX)
                    {
                        if (newX < minX)
                            minX = newX;
                        if (newX > maxX)
                            maxX = newX;
                        if (minX == maxX)
                            maxX = minX + 1;
                        percent = (currX - minX) * 100 / (maxX - minX);


                    }
                    currX = newX;

                    if (this.inputAvailable && prepare==true && percent > 80 && checkBox1.Checked && newX > lineX + 6 )
                    {
                        this.Invoke(new Action( () =>
                        {
                            
                            DanceWithKeys();
                            prepare = false;
                        }));
                    }


                    if (prepare == false && percent >75 && percent < 80)
                    {

                        this.Invoke(new Action(() =>
                        {

                            prepare = true;
                        }));
                    }
                    Thread.Sleep(1);
                }
            });


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           
        }




        private int GetBallX()
        {
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(rectBall.Location, Point.Empty, rectBall.Size);
            }
           

            hslFilter.ApplyInPlace(bmp);
            var bmpGray = grayscale.Apply(bmp);
            threshold.ApplyInPlace(bmpGray);

            blobCounter.ProcessImage(bmpGray);
            var blobs = blobCounter.GetObjectsInformation();


            foreach (var blob in blobs)
            {
                var p = blob.CenterOfGravity;
                int x = Convert.ToInt32(p.X - 4);
                int y = Convert.ToInt32(p.Y);
                if (x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height)
                {
                    Color c = bmp.GetPixel(x, y);
                    inputAvailable = c.R - c.G > 160;
                }
            }

            if (blobs.Length == 1)
            {

                if (this.radioButton1.Checked && blobs[0].CenterOfGravity.X >= lineX + Convert.ToDouble(textBox2.Text) && blobs[0].CenterOfGravity.X <= lineX + 5)
                {
                    Task.Run(() => PressKey()); 
                    Console.WriteLine(blobs[0].CenterOfGravity.X);                        
                }


                return Convert.ToInt32(blobs[0].CenterOfGravity.X);
            }
            else
            {
                return -1;
            }

        }

        private void PressKey()
        {
            lock (syncLock)
            {
                DateTime t = DateTime.Now; 

                dd.key(603, 1);
                Delay(20);
                dd.key(603, 2);

                return;
            }
        }







        private List<Keys> Image2Keys()
        {
            var dicKeys = new Dictionary<Rectangle, Keys>();

            var bmp = new Bitmap(rectKeys.Width, rectKeys.Height);
            var g = Graphics.FromImage(bmp as Bitmap);
            g.CopyFromScreen(rectKeys.Location, Point.Empty, rectKeys.Size);
            this.picKey1.Image = bmp.Clone() as Bitmap;
            var bmpShow = bmp.Clone() as Bitmap;
            g = Graphics.FromImage(bmpShow);
            bmp = Grayscale.CommonAlgorithms.BT709.Apply(bmp);
            new Threshold(200).ApplyInPlace(bmp);

            var matching = new ExhaustiveTemplateMatching(0.85f);
           
            foreach (var template in dicTemplate)
            {
                var rects = matching.ProcessImage(bmp, template.Value).Select(s => s.Rectangle).ToList();

                for (int i = 0; i < rects.Count; i++)
                    rects.RemoveAll(p => p != rects[i] && p.IntersectsWith(rects[i]));
                
                foreach (var rect in rects)
                {

                    Bitmap bmpcolor = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(bmpcolor, new Rectangle(0, 0, bmpcolor.Width, bmpcolor.Height));


                    int x = rect.X+20; 
                    int y = rect.Y+40; 
                    int width = rect.Width;
                    int height = rect.Height; 
                    Bitmap image = bmpcolor.Clone(new Rectangle(x, y, width, height), bmpcolor.PixelFormat);


                    int add = 0;

                    for (int xx = 0; xx < image.Width; xx++)
                    {
                        for (int yy = 0; yy < image.Height-15; yy++)
                        {
                            Color pixelColor = image.GetPixel(xx, yy);

                            add = add + Convert.ToInt32(pixelColor.R);

                        }
                    }

                    
                    if (add >= 70000)
                    {
                        g.FillRectangle(Brushes.Red, rect);

                        switch (template.Key.ToString())
                        {

                            case "NumPad8":

                                g.DrawString("NumPad2", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad2");

                                break;

                            case "NumPad2":
 
                                g.DrawString("NumPad8", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad8");

                                break;

                            case "NumPad4":
                                g.DrawString("NumPad6", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad6");
                                break;
                            case "NumPad6":
                                g.DrawString("NumPad4", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad4");
                                break;

                            case "NumPad1":
                                g.DrawString("NumPad9", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad9");
                               
                                break;
                            case "NumPad3":
                                g.DrawString("NumPad7", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad7");
                               
                                break;
                            case "NumPad7":
                              
                                g.DrawString("NumPad3", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad3");
                                
                                break;
                            case "NumPad9":
                              
                                g.DrawString("NumPad1", this.Font, Brushes.Black, rect);
                                dicKeys[rect] = keyvalue("NumPad1");
                                break;
                        }

                    }
                    else
                    {
                        g.FillRectangle(Brushes.Green, rect);
                        g.DrawString(template.Key.ToString(), this.Font, Brushes.Black, rect);
                        dicKeys[rect] = template.Key;

                    }

                }
               
            }
            this.picKey2.Image = bmpShow;
            return dicKeys.OrderBy(k => k.Key.X).Select(s => s.Value).ToList();
        }
        

        private void DanceWithKeys()
        {
            lock (syncLock)
            {
                var keys = Image2Keys();

                bool duplicateKeys = keys.SequenceEqual(lastKeys);

                if (duplicateKeys)
                    return;

                lastKeys = keys.ToList();

                var serialDataMapping = new Dictionary<Keys, int>
            {
                { Keys.NumPad8, 808 },
                { Keys.NumPad2, 802 },
                { Keys.NumPad4, 804 },
                { Keys.NumPad6, 806 },
                { Keys.NumPad1, 801 },
                { Keys.NumPad3, 803 },
                { Keys.NumPad7, 807 },
                { Keys.NumPad9, 809 }
            };

                foreach (var key in keys)
                {


                    if (serialDataMapping.ContainsKey(key))
                    {
                        int serialData = serialDataMapping[key];

                        dd.key(serialData, 1);
                        Delay(20); 
                        dd.key(serialData, 2);
                        Delay(20); 
                    }
                }

            }

        }
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            return;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "DD|*.DLL";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }


            LoadDllFile(ofd.FileName);
        }


        private void LoadDllFile(string dllfile)
        {




            int ret = dd.Load(dllfile);

            if (ret != 1) { MessageBox.Show("Load Error"); return; }


            ret = dd.btn(0); 
            if (ret != 1) { MessageBox.Show("Initialize Error"); return; }



            textBox1.Text = dllfile;

            return;
        }




        private void button3_Click(object sender, EventArgs e)
        {

            left = left - 1;
            label2.Text = left.ToString();
            lineX -= 1;
            UpdateLinePosition();

        }




        private void button4_Click(object sender, EventArgs e)
        {
            left = left + 1;
            label2.Text = left.ToString();
            lineX += 1; 
            UpdateLinePosition();
        }
        private void UpdateLinePosition()
        {
            linePanel.Refresh();
        }

        private void linePanel_Paint(object sender, PaintEventArgs e)
        {


            using (var pen = new Pen(Color.Red, 1))
            {
                int yPos = linePanel.Height / 2; 
                e.Graphics.DrawLine(pen, lineX, 0, lineX, linePanel.Height);
            }

        }





        public static Keys keyvalue(string mm)
        {
            Keys key = (Keys)Enum.Parse(typeof(Keys), mm);

            return key;
        }



    }

}

