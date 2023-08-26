using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace LTSpiceThemer {
    public partial class Form1 : Form {

        List<Theme> theme_list = new List<Theme>();

        public Form1() {
            InitializeComponent();
            FindIniFile();
            PopulateComboBox();

            // Todo:
            // Read ini file and get specs
            // Create the themes (external txt file)
            // Pass font, size and line thicnkess to drawImage

            toolStripStatusLabel1.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;




            string themefile_str = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "LTspice-themes.txt");
            using (StringReader reader = new StringReader(themefile_str)) {
                string line = string.Empty;
                do {
                    line = reader.ReadLine();
                    if (line != null && line != "") {

                        if (line[0] == '[') {
                            comboBox1.Items.Add(line.Substring(1, line.Length - 2));
                            Theme theme = new Theme();
                            theme.Name = line.Substring(1, line.Length - 2);
                            theme_list.Add(theme);
                        }
                        else if (line.Contains("SchematicColor0=")) {
                            theme_list.Last().Code_Wires = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Wires = ColorCodeToRGB(theme_list.Last().Code_Wires);
                        }
                        else if (line.Contains("SchematicColor1=")) {
                            theme_list.Last().Code_Junctions = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Junctions = ColorCodeToRGB(theme_list.Last().Code_Junctions);
                        }
                        else if (line.Contains("SchematicColor2=")) {
                            theme_list.Last().Code_CmpBody = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().CmpBody = ColorCodeToRGB(theme_list.Last().Code_CmpBody);
                        }
                        else if (line.Contains("SchematicColor3=")) {
                            theme_list.Last().Code_GpcFlag = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().GpcFlag = ColorCodeToRGB(theme_list.Last().Code_GpcFlag);
                        }
                        else if (line.Contains("SchematicColor4=")) {
                            theme_list.Last().Code_CmpFill = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().CmpFill = ColorCodeToRGB(theme_list.Last().Code_CmpFill);
                        }
                        else if (line.Contains("SchematicColor5=")) {
                            theme_list.Last().Code_CmpTxt = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().CmpTxt = ColorCodeToRGB(theme_list.Last().Code_CmpTxt);
                        }
                        else if (line.Contains("SchematicColor6=")) {
                            theme_list.Last().Code_FlgTxt = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().FlgTxt = ColorCodeToRGB(theme_list.Last().Code_FlgTxt);
                        }
                        else if (line.Contains("SchematicColor7=")) {
                            theme_list.Last().Code_SpcDir = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().SpcDir = ColorCodeToRGB(theme_list.Last().Code_SpcDir);
                        }
                        else if (line.Contains("SchematicColor8=")) {
                            theme_list.Last().Code_Comment = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Comment = ColorCodeToRGB(theme_list.Last().Code_Comment);
                        }
                        else if (line.Contains("SchematicColor9=")) {
                            theme_list.Last().Code_Unconnected = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Unconnected = ColorCodeToRGB(theme_list.Last().Code_Unconnected);
                        }
                        else if (line.Contains("SchematicColor10=")) {
                            theme_list.Last().Code_Highlight = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Highlight = ColorCodeToRGB(theme_list.Last().Code_Highlight);
                        }
                        else if (line.Contains("SchematicColor11=")) {
                            theme_list.Last().Code_Grid = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Grid = ColorCodeToRGB(theme_list.Last().Code_Grid);
                        }
                        else if (line.Contains("SchematicColor12=")) {
                            theme_list.Last().Code_Back = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().Back = ColorCodeToRGB(theme_list.Last().Code_Back);
                        }
                        else if (line.Contains("SchematicColor13=")) {
                            theme_list.Last().Code_GpcAnn = Int32.Parse(line.Split('=')[1]);
                            theme_list.Last().GpcAnn = ColorCodeToRGB(theme_list.Last().Code_GpcAnn);
                        }
                    }
                } while (line != null);
            }

            comboBox1.SelectedIndex = 0;





            //MessageBox.Show(themefile_str);


            //var c = File.ReadLines("C:\\Users\\Administrator\\AppData\\Roaming\\LTspiceXVII.ini").SkipWhile(line => !line.Contains("SchematicColor0=")).TakeWhile(line => !line.Contains("NetlistNormalTextColor")); ;
            //Color Wires = ColorCodeToRGB(Int32.Parse(c.ElementAt(0).Split('=')[1]));
            //Color Junctions = ColorCodeToRGB(Int32.Parse(c.ElementAt(1).Split('=')[1]));
            //Color CmpBody = ColorCodeToRGB(Int32.Parse(c.ElementAt(2).Split('=')[1]));
            //Color GpcFlag = ColorCodeToRGB(Int32.Parse(c.ElementAt(3).Split('=')[1]));
            //Color CmpFill = ColorCodeToRGB(Int32.Parse(c.ElementAt(4).Split('=')[1]));
            //Color CmpTxt = ColorCodeToRGB(Int32.Parse(c.ElementAt(5).Split('=')[1]));
            //Color FlgTxt = ColorCodeToRGB(Int32.Parse(c.ElementAt(6).Split('=')[1]));
            //Color SpcDir = ColorCodeToRGB(Int32.Parse(c.ElementAt(7).Split('=')[1]));
            //Color Comment = ColorCodeToRGB(Int32.Parse(c.ElementAt(8).Split('=')[1]));
            //Color Unconnected = ColorCodeToRGB(Int32.Parse(c.ElementAt(9).Split('=')[1]));
            //Color Highlight = ColorCodeToRGB(Int32.Parse(c.ElementAt(10).Split('=')[1]));
            //Color Grid = ColorCodeToRGB(Int32.Parse(c.ElementAt(11).Split('=')[1]));
            //Color Back = ColorCodeToRGB(Int32.Parse(c.ElementAt(12).Split('=')[1]));
            //Color GpcAnn = ColorCodeToRGB(Int32.Parse(c.ElementAt(13).Split('=')[1]));

            //DrawImage(Wires, Junctions, CmpBody, GpcFlag, CmpFill, CmpTxt, FlgTxt, SpcDir, Comment, Unconnected, Highlight, Grid, GpcAnn, Back);


        }

        private void DrawImage(Color Wires, Color Junctions, Color CmpBody, Color GpcFlag, Color CmpFill, Color CmpTxt, Color FlgTxt, Color SpcDir, Color Comment, Color Unconnected, Color Highlight, Color Grid, Color GpcAnn, Color Back) {
            pictureBox1.Image = null;
            Bitmap bitmap = new Bitmap(232, 148, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            
            //Back = Color.FromArgb(255, Back);
            graphics.Clear(Back);


            // Component Fill:
            graphics.FillRectangle(new SolidBrush(CmpFill), 186, 0, 232, 110);

            // Component Body:
            Pen pen = new Pen(CmpBody, 2);
            graphics.DrawLines(pen, new Point[] { new Point(186, 0), new Point(186, 110), new Point(232, 110) });
            graphics.DrawLines(pen, new Point[] { new Point(37, 78), new Point(37, 88) });
            graphics.DrawLines(pen, new Point[] { new Point(29, 88), new Point(44, 88) });
            graphics.DrawLines(pen, new Point[] { new Point(29, 92), new Point(44, 92) });
            graphics.DrawLines(pen, new Point[] { new Point(37, 92), new Point(37, 103) });
            graphics.DrawLines(pen, new Point[] { new Point(112, 91), new Point(112, 93), new Point(119, 97), new Point(105, 104), new Point(119, 111), new Point(105, 118), new Point(112, 121), new Point(112, 124) });

            // Unconnected pins:
            pen.Color = Unconnected;
            graphics.DrawPolygon(pen, new Point[] { new Point(182, 79), new Point(182, 86), new Point(189, 86), new Point(189, 79) });
            graphics.DrawPolygon(pen, new Point[] { new Point(182, 10), new Point(182, 17), new Point(189, 17), new Point(189, 10) });

            // GND:
            pen.Color = GpcFlag;
            graphics.DrawPolygon(pen, new Point[] { new Point(28, 132), new Point(46, 132), new Point(37, 140) });
            graphics.DrawPolygon(pen, new Point[] { new Point(103, 132), new Point(120, 132), new Point(112, 140) });

            // Wires:
            pen.Color = Wires;
            graphics.DrawLines(pen, new Point[] { new Point(37, 132), new Point(37, 103) });
            graphics.DrawLines(pen, new Point[] { new Point(37, 79), new Point(37, 48), new Point(186, 48) });
            graphics.DrawLines(pen, new Point[] { new Point(112, 48), new Point(112, 56) });
            graphics.DrawLines(pen, new Point[] { new Point(112, 83), new Point(112, 91) });
            graphics.DrawLines(pen, new Point[] { new Point(112, 124), new Point(112, 131) });

            // Junctions:
            graphics.FillRectangle(new SolidBrush(Junctions), 108, 45, 8, 8);

            // Highlighted component:
            pen.Color = Highlight;
            graphics.DrawLines(pen, new Point[] { new Point(112, 56), new Point(112, 67) });
            graphics.DrawLines(pen, new Point[] { new Point(104, 67), new Point(120, 68) });
            graphics.DrawLines(pen, new Point[] { new Point(104, 72), new Point(120, 72) });
            graphics.DrawLines(pen, new Point[] { new Point(112, 72), new Point(112, 86) });


            // Text:
            var fontFamily = new FontFamily("Arial");
            var font = new Font(fontFamily, 13, FontStyle.Regular, GraphicsUnit.Pixel);

            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString("Comment Text", font, new SolidBrush(Comment), new PointF(21, 20));
            graphics.DrawString("C1", font, new SolidBrush(CmpTxt), new PointF(45, 73));
            graphics.DrawString("100p", font, new SolidBrush(CmpTxt), new PointF(45, 92));
            graphics.DrawString("R1", font, new SolidBrush(CmpTxt), new PointF(124, 100));
            graphics.DrawString("5K", font, new SolidBrush(CmpTxt), new PointF(124, 115));
            graphics.DrawString("LBO", font, new SolidBrush(CmpTxt), new PointF(190, 7));
            graphics.DrawString("Vc", font, new SolidBrush(CmpTxt), new PointF(190, 42));
            graphics.DrawString("LBI", font, new SolidBrush(CmpTxt), new PointF(190, 77));

            graphics.DrawString("C2", font, new SolidBrush(Highlight), new PointF(119, 56));
            graphics.DrawString(".01u", font, new SolidBrush(Highlight), new PointF(119, 72));

            graphics.DrawString("VC", font, new SolidBrush(FlgTxt), new PointF(136, 33));
            graphics.DrawString(".tran 10m", font, new SolidBrush(SpcDir), new PointF(159, 130));

            pen.Color = GpcAnn;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            graphics.DrawEllipse(pen, 20, 62, 68, 57);

            Color backgrid = Color.FromArgb(255, 255 - Grid.R, 255 - Grid.G, 255 - Grid.B);


            //ControlPaint.DrawGrid(graphics, new Rectangle(Point.Empty, bitmap.Size), new Size(10, 10), Color.FromArgb(Grid.ToArgb() ^ 0xffffff));
            //ControlPaint.DrawGrid(graphics, new Rectangle(Point.Empty, bitmap.Size), new Size(10, 10), Back);
            DrawGrid(graphics, new Rectangle(Point.Empty, bitmap.Size), new Size(10, 10), Grid);

            pictureBox1.Image = bitmap;
        }

        private Color ColorCodeToRGB(int colorcode) {
            string hexValue = colorcode.ToString("X6");
            string blue = hexValue.Substring(0, 2);
            string green = hexValue.Substring(2, 2);
            string red = hexValue.Substring(4, 2);
            int blue_dec = Convert.ToInt32(blue, 16);
            int green_dec = Convert.ToInt32(green, 16);
            int red_dec = Convert.ToInt32(red, 16);
            string color_code = red_dec.ToString() + green_dec.ToString() + blue_dec.ToString();
            return Color.FromArgb(red_dec, green_dec, blue_dec);
        }

        private void FindIniFile() {
            //textBox1.Text = "C:\\Users\\Administrator\\AppData\\Roaming\\LTspiceXVII.ini";
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LTspiceXVII.ini";
        }

        private void PopulateComboBox() {
            //throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e) {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            Theme t = theme_list[comboBox1.SelectedIndex];
            DrawImage(t.Wires, t.Junctions, t.CmpBody, t.GpcFlag, t.CmpFill, t.CmpTxt, t.FlgTxt, t.SpcDir, t.Comment, t.Unconnected, t.Highlight, t.Grid, t.GpcAnn, t.Back);

        }

        private void button2_Click(object sender, EventArgs e) {
            //textBox1.Text;
            //var c = File.ReadLines(textBox1.Text).SkipWhile(line => !line.Contains("SchematicColor0=")).TakeWhile(line => !line.Contains("NetlistNormalTextColor"));

            //string text = File.ReadAllText(textBox1.Text);
            //string[] textLines = File.ReadAllLines(textBox1.Text);
            //text = text.Replace("some text", "new value");
            //File.WriteAllText("test.txt", text);

            //string result = textLines.SingleOrDefault(l => l.StartsWith("SchematicColor0="));



            //MessageBox.Show(result);

            //foreach (string line in textLines.Where(l => l.StartsWith("SchematicColor0=")))
            //    MessageBox.Show(line);;


            //int counter = 0;
            //string line;

            //// Read the file and display it line by line.
            //System.IO.StreamReader file = new System.IO.StreamReader(textBox1.Text);
            //while ((line = file.ReadLine()) != null) {
            //    if (line.Contains("SchematicColor0=")) {
            //        //Console.WriteLine(counter.ToString() + ": " + line);
            //        MessageBox.Show(counter.ToString()+line);
            //    }

            //    counter++;
            //}

            //file.Close();



            string[] textLines = File.ReadAllLines(textBox1.Text);
            //foreach (string line in textLines ) {
            //    if (line.StartsWith("SchematicColor0=")) MessageBox.Show(line);
            //}

            for (int i = 0; i < textLines.Length; i++) {
                //textLines[i] = textLines[i].Replace("pdf", "txt");
                if (textLines[i].StartsWith("SchematicColor0=")) textLines[i]= "SchematicColor0=" + theme_list[comboBox1.SelectedIndex].Code_Wires.ToString();
                else if (textLines[i].StartsWith("SchematicColor1=")) textLines[i] = "SchematicColor1=" + theme_list[comboBox1.SelectedIndex].Code_Junctions.ToString();
                else if (textLines[i].StartsWith("SchematicColor2=")) textLines[i] = "SchematicColor2=" + theme_list[comboBox1.SelectedIndex].Code_CmpBody.ToString();
                else if (textLines[i].StartsWith("SchematicColor3=")) textLines[i] = "SchematicColor3=" + theme_list[comboBox1.SelectedIndex].Code_GpcFlag.ToString();
                else if (textLines[i].StartsWith("SchematicColor4=")) textLines[i] = "SchematicColor4=" + theme_list[comboBox1.SelectedIndex].Code_CmpFill.ToString();
                else if (textLines[i].StartsWith("SchematicColor5=")) textLines[i] = "SchematicColor5=" + theme_list[comboBox1.SelectedIndex].Code_CmpTxt.ToString();
                else if (textLines[i].StartsWith("SchematicColor6=")) textLines[i] = "SchematicColor6=" + theme_list[comboBox1.SelectedIndex].Code_FlgTxt.ToString();
                else if (textLines[i].StartsWith("SchematicColor7=")) textLines[i] = "SchematicColor7=" + theme_list[comboBox1.SelectedIndex].Code_SpcDir.ToString();
                else if (textLines[i].StartsWith("SchematicColor8=")) textLines[i] = "SchematicColor8=" + theme_list[comboBox1.SelectedIndex].Code_Comment.ToString();
                else if (textLines[i].StartsWith("SchematicColor9=")) textLines[i] = "SchematicColor9=" + theme_list[comboBox1.SelectedIndex].Code_Unconnected.ToString();
                else if (textLines[i].StartsWith("SchematicColor10=")) textLines[i] = "SchematicColor10=" + theme_list[comboBox1.SelectedIndex].Code_Highlight.ToString();
                else if (textLines[i].StartsWith("SchematicColor11=")) textLines[i] = "SchematicColor11=" + theme_list[comboBox1.SelectedIndex].Code_Grid.ToString();
                else if (textLines[i].StartsWith("SchematicColor12=")) textLines[i] = "SchematicColor12=" + theme_list[comboBox1.SelectedIndex].Code_Back.ToString();
                else if (textLines[i].StartsWith("SchematicColor13=")) textLines[i] = "SchematicColor13=" + theme_list[comboBox1.SelectedIndex].Code_GpcAnn.ToString();
            }

            //string newtext = string.Join(textLines);

            string newText = string.Join(System.Environment.NewLine, textLines);

            File.WriteAllText(textBox1.Text, newText);

            int a = 1;
        }


        private static Brush gridBrush;
        private static Size gridSize;
        private static bool gridInvert;
        //
        // Summary:
        //     Draws a grid of one-pixel dots with the specified spacing, within the specified
        //     bounds, on the specified graphics surface, and in the specified color.
        //
        // Parameters:
        //   graphics:
        //     The System.Drawing.Graphics to draw on.
        //
        //   area:
        //     The System.Drawing.Rectangle that represents the dimensions of the grid.
        //
        //   pixelsBetweenDots:
        //     The System.Drawing.Size that specified the height and width between the dots
        //     of the grid.
        //
        //   foreColor:
        //     The System.Drawing.Color of the grid.
        public static void DrawGrid(Graphics graphics, Rectangle area, Size pixelsBetweenDots, Color foreColor) {
            if (graphics == null) {
                throw new ArgumentNullException("graphics");
            }

            if (pixelsBetweenDots.Width <= 0 || pixelsBetweenDots.Height <= 0) {
                throw new ArgumentOutOfRangeException("pixelsBetweenDots");
            }

            gridSize = pixelsBetweenDots;
            int num = 16;
            int num2 = (num / pixelsBetweenDots.Width + 1) * pixelsBetweenDots.Width;
            int num3 = (num / pixelsBetweenDots.Height + 1) * pixelsBetweenDots.Height;
            Bitmap bitmap = new Bitmap(num2, num3);
            for (int i = 0; i < num2; i += pixelsBetweenDots.Width) {
                for (int j = 0; j < num3; j += pixelsBetweenDots.Height) {
                    bitmap.SetPixel(i, j, foreColor);
                }
            }

            gridBrush = new TextureBrush(bitmap);
            bitmap.Dispose();
            graphics.FillRectangle(gridBrush, area);
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/dasilvaleandro21/LTSpiceThemer");
        }
    }
}
