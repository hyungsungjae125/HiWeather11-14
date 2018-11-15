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
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            Load += Form_main_Load;
        }
        Panel panel;
        private void Form_main_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.Size = new Size(1000, 600);
            
            panel = new Panel();
            panel.Size = new Size(1000, 600);
            panel.Location = new Point(0, 100);
            Controls.Add(panel);

            Drawclass d = new Drawclass();
            d.btn(new Btnclass(this, "btn1", "일기예보", 200, 100, 0, 0, btn_click));
            d.btn(new Btnclass(this, "btn2", "즐겨찾기", 200, 100, 200, 0, btn_click));
            d.btn(new Btnclass(this, "btn_feedback", "피드백", 60, 40, 800, 20, btn_click));
            d.btn(new Btnclass(this, "btn_setting", "설정", 60, 40, 900, 20, btn_click));
        }
        Form form = null;
        private void btn_click(object sender, EventArgs e)
        {
            if(form != null)
            {
                form.Close();
                form = null;
            }

            Button button = (Button) sender;

            form = new Form();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            form.BackColor = Color.AliceBlue;

            switch (button.Name)
            {
                case "btn1"://일기예보 버튼
                    form.BackColor = Color.Beige;
                    break;
                case "btn2"://즐겨찾기 버튼
                    form.Controls.Add(pn_create(0,0));
                    break;
                case "btn_feedback"://피드백 버튼
                    //;
                    break;
                case "btn_setting"://설정 버튼
                    //Form_bookmark bookmark = new Form_bookmark();
                    //bookmark.FormBorderStyle = FormBorderStyle.None;
                    //bookmark.WindowState = FormWindowState.Normal;
                    //bookmark.Size = new Size(400,200);
                    //bookmark.ShowDialog();

                    Form_config config = new Form_config();
                    config.ShowDialog();
                    break;
                default:
                    form.BackColor = Color.Yellow;
                    break;
            }
            panel.Controls.Add(form);
            form.Show();
        }

        private Panel pn_create(int i, int j)
        {
            Panel p = new Panel();
            Label label = new Label();
            Label label1 = new Label();
            PictureBox weather = new PictureBox();
            PictureBox picture = new PictureBox();

            p.Name = "panel" + (i * 2 + j + 1);
            
            p.Size = new Size(405, 120);
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Location = new Point(i*400+10, j*120+10);
            label.Text = "금천구, 서울특별시";
            label.Location = new Point(120, 10);
            label.Size = new Size(300, 30);
            label.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);

            label1.Text = (13).ToString() + "˚C";
            label1.Location = new Point(150, 50);
            label1.Size = new Size(50, 20);
            label1.Font = new Font(FontFamily.GenericSerif, 14.0F);


            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("sunny");
            weather.SizeMode = PictureBoxSizeMode.StretchImage;
            weather.Location = new Point(10, 10);
            weather.Size = new Size(100, 100);

            picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("dust2");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(200, 45);
            picture.Size = new Size(50, 50);


            p.Controls.Add(label);
            p.Controls.Add(label1);
            p.Controls.Add(weather);
            p.Controls.Add(picture);

            return p;
        }
    }
}
