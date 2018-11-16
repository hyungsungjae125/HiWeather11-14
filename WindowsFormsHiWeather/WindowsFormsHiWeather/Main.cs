﻿using System;
using System.Collections;
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
    public partial class Main : Form
    {

        ArrayList weatherlist = new ArrayList();//장소에대한 리스트
        Days[] days = new Days[7];//장소에 대한 일별 세부사항 리스트
        Conditions[] hours = new Conditions[8];//장소에 대한 시간 세부사항 리스트
        public Main()
        {
           
            InitializeComponent();

            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            Size = new Size(1000, 600);

            //==================================================
            //금천구 날씨추가
            days[0] = new Days(15, "부분적으로 맑음", 15, 5);
            days[1] = new Days(16, "부분적으로 맑음", 13, -3);
            days[2] = new Days(17, "부분적으로 맑음", 10, -2);
            days[3] = new Days(18, "부분적으로 맑음", 12, 3);
            days[4] = new Days(19, "맑음", 13, -1);
            days[5] = new Days(20, "대체로 흐림", 10, 1);
            days[6] = new Days(21, "부분적으로 맑음", 10, -1);
            hours[0] = new Conditions(0, "대체로 흐림", 14, 0, 49, 2, "북서");
            hours[1] = new Conditions(3, "대체로 흐림", 14, 0, 53, 2, "북");
            hours[2] = new Conditions(6, "부분적으로 맑음", 14, 0, 47, 2, "북서");
            hours[3] = new Conditions(9, "부분적으로 맑음", 14, 0, 46, 2, "북서");
            hours[4] = new Conditions(12, "부분적으로 맑음", 14, 0, 43, 2, "북서");
            hours[5] = new Conditions(15, "부분적으로 맑음", 14, 0, 40, 2, "북");
            hours[6] = new Conditions(18, "대체로 흐림", 14, 0, 40, 2, "북동");
            hours[7] = new Conditions(21, "대체로 흐림", 14, 0, 42, 2, "북동");

            weatherlist.Add(new Weather("금천구", "서울특별시", days, hours));
            //==================================================

            //==================================================
            //관악구 날씨추가
            days[0] = new Days(15, "부분적으로 맑음", 15, 5);
            days[1] = new Days(16, "부분적으로 맑음", 13, -3);
            days[2] = new Days(17, "부분적으로 맑음", 10, -2);
            days[3] = new Days(18, "부분적으로 맑음", 12, 3);
            days[4] = new Days(19, "맑음", 13, -1);
            days[5] = new Days(20, "대체로 흐림", 10, 1);
            days[6] = new Days(21, "부분적으로 맑음", 10, -1);
            hours[0] = new Conditions(0, "대체로 흐림", 5, 0, 49, 2, "북서");
            hours[1] = new Conditions(3, "대체로 흐림", 7, 0, 53, 2, "북");
            hours[2] = new Conditions(6, "부분적으로 맑음", 8, 0, 47, 2, "북서");
            hours[3] = new Conditions(9, "부분적으로 맑음", 11, 0, 46, 2, "북서");
            hours[4] = new Conditions(12, "부분적으로 맑음", 14, 0, 43, 2, "북서");
            hours[5] = new Conditions(15, "부분적으로 맑음", 12, 0, 40, 2, "북");
            hours[6] = new Conditions(18, "대체로 흐림", 11, 0, 40, 2, "북동");
            hours[7] = new Conditions(21, "대체로 흐림", 8, 0, 42, 2, "북동");

            weatherlist.Add(new Weather("관악구", "서울특별시", days, hours));
            //==================================================

            MenuPan(1000,70,0,0);
            MainPan(1000, 530, 0, 70);
           
        }
        Panel panel1;
        Panel panel2;
        Panel panel3;
        Drawclass dc = new Drawclass();

        private void MenuPan(int sX,int sY,int pX,int pY)
        {
            panel3 = new Panel();
            Btnclass bt1 = new Btnclass(this, "Home", "홈", 80,70, 0, 0, btn1_Click);
            Btnclass bt2 = new Btnclass(this, "bookmark", "즐겨찾기", 80, 70, 80, 0, btn2_Click);
            
            Btnclass bt3 = new Btnclass(this, "feedback", "피드백", 80, 70, 800, 0, btn3_Click);
            Btnclass bt4 = new Btnclass(this, "option", "설정", 80, 70, 880, 0, btn4_Click);
            
            panel3.Location = new Point(pX, pY);
            panel3.Size = new Size(sX, sY);
            panel3.BackColor = Color.SkyBlue;

            Controls.Add(panel3);

            panel3.Controls.Add(dc.btn1(bt1));
            panel3.Controls.Add(dc.btn1(bt2));
            panel3.Controls.Add(dc.btn1(bt3));
            panel3.Controls.Add(dc.btn1(bt4));

        }
        
        private void MainPan(int sX, int sY, int pX, int pY)
        {
            panel1 = new Panel();

            panel1.Location = new Point(pX, pY);
            panel1.Size = new Size(sX, sY);
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BackgroundImage = (Bitmap)WindowsFormsHiWeather.Properties.Resources.background;

            PictureBox weather = new PictureBox();
            PictureBox picture = new PictureBox();

            TextBox tb = new TextBox();

            tb.Size = new Size(120, 50);
            tb.Location = new Point(800, 50);
           
            tb.ResumeLayout(false);
            tb.PerformLayout();

            ResumeLayout(false);
            PerformLayout();

            Lbclass adlb = new Lbclass(this, "adlb", ((Weather)weatherlist[0]).Place + ", " + ((Weather)weatherlist[0]).City, 300, 25, 370, 0); // 주소 라벨
            Lbclass dglb = new Lbclass(this, "dglb", days[0].Toptemperature + "˚C  " + days[0].Toptemperature.ToString() + "/" + days[0].Bottomtemperature.ToString() + " \n" + days[0].Condition, 110, 50, 400, 40); // 기상 라벨
            Lbclass timelb = new Lbclass(this, "timelb", "마지막 업데이트: " + DateTime.Now.ToString("HH") + ":" + DateTime.Now.ToString("mm") + ":" + DateTime.Now.ToString("ss"), 200, 20, 350, 100);

            Btnclass sbtn = new Btnclass(this, "sbtn", "검색", 50, 25, 920, 48, btn5_Click);
            Btnclass rfbtn = new Btnclass(this, "rfbtn", "새로고침", 50, 45, 800, 0, btn5_Click);
            Btnclass bmbtn = new Btnclass(this, "bmbtn", "즐찾추가", 50, 45, 850, 0, btn5_Click);
            
            weather.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("sunny");
            weather.SizeMode = PictureBoxSizeMode.StretchImage;
            weather.Location = new Point(330, 30);
            weather.Size = new Size(70, 65);

            picture.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("dust2");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(510, 30);
            picture.Size = new Size(70, 65);
            
            
              for(int i=0;i<days.Length;i++)
            {   
                PictureBox wticon = new PictureBox();
                 PictureBox dusticon=new PictureBox();
                Lbclass addrlb =new Lbclass(this, "addrlb", days[i].Day.ToString()+"일", 80, 20, 30+i*140, 300); // 주소 라벨
                Lbclass dgrlb = new Lbclass(this, "dgrlb", days[i].Toptemperature+"˚C  "+days[i].Toptemperature.ToString()+"/"+days[i].Bottomtemperature.ToString(), 60, 40, 15+(i*140), 370); // 기상 라벨
                Lbclass cdlb = new Lbclass(this, "cdlb",days[i].Condition, 100, 40, (15+i*140), 410);
                           
                 dusticon.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("dust1");
                 dusticon.SizeMode = PictureBoxSizeMode.StretchImage;
                 dusticon.Location = new Point(55+(i*140), 330);
                 dusticon.ClientSize = new Size(40, 40);
                 
                wticon.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("sunny");        
                 wticon.SizeMode = PictureBoxSizeMode.StretchImage;
                 wticon.Location = new Point(15+(i*140), 330);
                 wticon.ClientSize = new Size(40, 40);
                
                panel1.Controls.Add(dc.lb1(addrlb,15));
                panel1.Controls.Add(dc.lb1(dgrlb,12));
                panel1.Controls.Add(dc.lb1(cdlb,12));
                panel1.Controls.Add(wticon);
                panel1.Controls.Add(dusticon);
            }

            panel1.Controls.Add(dc.lb1(adlb,18));
            panel1.Controls.Add(dc.lb1(dglb,13));
            panel1.Controls.Add(dc.btn1(sbtn));
            panel1.Controls.Add(dc.btn1(rfbtn));
            panel1.Controls.Add(dc.btn1(bmbtn));
            panel1.Controls.Add(tb);
            panel1.Controls.Add(weather);
            panel1.Controls.Add(picture);
            panel1.Controls.Add(dc.lb1(timelb, 10));

            Controls.Add(panel1);
            
        }

        private bool Book_create()
        {
            panel2 = new Panel();
            panel2.Location = new Point(0, 70);
            panel2.Size = new Size(1000, 530);
            //panel1.BackColor = Color.Aqua;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BackgroundImage = (Bitmap)WindowsFormsHiWeather.Properties.Resources.background;
            panel2.BackColor = Color.Transparent;
            ((Weather)weatherlist[0]).Book = true;
            ((Weather)weatherlist[1]).Book = true;
            for (int a = 0, i = 0, j = 0; a < weatherlist.Count; a++)
            {
                Panel p = new Panel();
                Label label = new Label();
                Label label1 = new Label();
                PictureBox weather = new PictureBox();
                PictureBox picture = new PictureBox();
                i = a % 2;

                if (((Weather)weatherlist[a]).Book)
                {
                    p.Name = "panel" + a + 1;

                    p.Size = new Size(400, 120);
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Location = new Point(i * 500 + 10, j * 120 + 10);

                    label.Text = ((Weather)weatherlist[a]).Place + ", " + ((Weather)weatherlist[i]).City;
                    label.Location = new Point(120, 10);
                    label.Size = new Size(300, 30);
                    label.Font = new Font(FontFamily.GenericSansSerif, 16.0F, FontStyle.Bold);

                    label1.Text = ((((Weather)weatherlist[a]).Conditions_hour[2]).Temperature).ToString() + "˚C";
                    label1.Location = new Point(150, 50);
                    label1.Size = new Size(50, 20);
                    label1.Font = new Font(FontFamily.GenericSerif, 14.0F);

                    switch (((Weather)weatherlist[a]).Conditions_hour[2].Condition)
                    {
                        case "맑음":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.sunny;
                            break;
                        case "부분적으로 맑음":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.sunny;
                            break;
                        case "대체로 흐림":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.cloudy;
                            break;
                        case "비옴":
                            weather.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.sunny;
                            break;
                    }
                    weather.SizeMode = PictureBoxSizeMode.StretchImage;
                    weather.Location = new Point(10, 10);
                    weather.Size = new Size(100, 100);

                    int dust = ((Weather)weatherlist[a]).Conditions_hour[2].Dust;
                    if (dust >= 0 && dust < 30)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.dust1;
                    }
                    else if (dust >= 30 && dust < 60)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.dust2;
                    }
                    else if (dust >= 60 && dust < 90)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.dust3;
                    }
                    else if (dust >= 90)
                    {
                        picture.Image = (Bitmap)WindowsFormsHiWeather.Properties.Resources.dust4;
                    }
                    picture.SizeMode = PictureBoxSizeMode.StretchImage;
                    picture.Location = new Point(200, 45);
                    picture.Size = new Size(50, 50);


                    p.Controls.Add(label);
                    p.Controls.Add(label1);
                    p.Controls.Add(weather);
                    p.Controls.Add(picture);
                    panel2.Controls.Add(p);
                }
                if ((a % 2) == 1)
                {
                    j++;
                }

            }
            this.Controls.Add(panel2);
            return true;
        }

        Form form = new Form();
        private void btn1_Click(Object o, EventArgs e)
        {
            MessageBox.Show("홈");
        }

        private void btn2_Click(Object o, EventArgs e)
        {
            MessageBox.Show("즐겨찾기");
        }
        private void btn3_Click(Object o, EventArgs e)
        {
            Form_Feedback feedback = new Form_Feedback();
            feedback.StartPosition = FormStartPosition.CenterParent;
            feedback.ShowDialog();
            //MessageBox.Show("피드백");
        }
        private void btn4_Click(Object o, EventArgs e)
        {
            Form_config config = new Form_config();
            config.StartPosition = FormStartPosition.CenterParent;
            config.ShowDialog();
            //MessageBox.Show("설정");
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name)
            {
                case "sbtn":
                    MessageBox.Show("검색");
                    break;
                case "rfbtn":
                    MessageBox.Show("새로고침");
                    break;
                case "bmbtn":
                    MessageBox.Show("즐겨찾기추가");
                    break;
                default:
                    break;
            }
        }


    }
}

        