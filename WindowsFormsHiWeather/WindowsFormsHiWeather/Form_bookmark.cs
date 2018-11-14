using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHiWeather
{
    public partial class Form_bookmark : Form
    {
        public Form_bookmark()
        {
            InitializeComponent();

            Load += Form_bookmark_Load;
            //MessageBox.Show("테스트");
        }

        private void Form_bookmark_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            MainLabelCreate();
            //TableLayoutPanelCreate();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Controls.Add(pn_create(i, j));
                }
            }
        }
        private void MainLabelCreate()
        {
            Label label;
            label = new Label();
            label.Name = "label";
            label.Text = "즐겨찾기";
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(0, 0);
            label.Size = new Size(100, 20);
            label.Font = new Font(FontFamily.GenericSansSerif, 15.0F, FontStyle.Bold);
            //label.Font.Bold = true;
            //label.Font.Size = 10;
            //label.Size=new Size(1000,200);

            Controls.Add(label);
        }
        private Panel pn_create(int i, int j)
        {
            Panel p = new Panel();
            Label label = new Label();
            Label label1 = new Label();
            PictureBox picture = new PictureBox();

            p.Name = "panel" + (i * 2 + j + 1);
            p.Location = new Point(20 + i * 435, 35 + j * 140);
            p.Size = new Size(405, 120);
            p.BorderStyle = BorderStyle.FixedSingle;

            label.Text = "금천구, 서울특별시";
            label.Location = new Point(120, 10);
            label.Size = new Size(300, 30);
            label.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);

            label1.Text = (13).ToString() + "˚C";
            label1.Location = new Point(150, 50);
            label1.Size = new Size(100, 20);
            label1.Font = new Font(FontFamily.GenericSerif, 14.0F);

            //Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("dust1.PNG");
            string filePath = Application.StartupPath + @"\dust1.PNG";
            //MessageBox.Show(filePath);
            //picture.Image = new Bitmap(@"C:\Users\GDC20\Desktop\visual github\HiWeather\Hiweather\Hiweather\image\dust1.PNG");
            picture.Image = new Bitmap(filePath);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(5, 20);
            picture.Size = new Size(50, 50);


            p.Controls.Add(label);
            p.Controls.Add(label1);
            p.Controls.Add(picture);
            return p;
        }
        
    }
}
