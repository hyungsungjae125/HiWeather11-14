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
        Drawclass dc = new Drawclass();

        private void MenuPan(int sX,int sY,int pX,int pY)
        {

            Btnclass bt1 = new Btnclass(this, "Home", "홈", 80,70, 0, 0, btn1_Click);
            Btnclass bt2 = new Btnclass(this, "bookmark", "즐겨찾기", 80, 70, 80, 0, btn2_Click);
            
            Btnclass bt3 = new Btnclass(this, "feedback", "피드백", 80, 70, 800, 0, btn3_Click);
            Btnclass bt4 = new Btnclass(this, "option", "설정", 80, 70, 880, 0, btn4_Click);

            //Bitmap bit = (Bitmap)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("cloudy");

            panel1 = new Panel();
            
            panel1.Location = new Point(pX, pY);
            panel1.Size = new Size(sX, sY);
            panel1.BackColor = Color.SkyBlue;

            Controls.Add(panel1);

            panel1.Controls.Add(dc.btn1(bt1));
            panel1.Controls.Add(dc.btn1(bt2));
            panel1.Controls.Add(dc.btn1(bt3));
            panel1.Controls.Add(dc.btn1(bt4));

        }
        
        private void MainPan(int sX, int sY, int pX, int pY)
        {
            panel1 = new Panel();

            panel1.Location = new Point(pX, pY);
            panel1.Size = new Size(sX, sY);
            panel1.BackColor = Color.Aqua;

            PictureBox weather = new PictureBox();
            PictureBox picture = new PictureBox();

            TextBox tb = new TextBox();

            tb.Size = new Size(120, 50);
            tb.Location = new Point(800, 50);
           
            tb.ResumeLayout(false);
            tb.PerformLayout();

            ResumeLayout(false);
            PerformLayout();

            Lbclass adlb = new Lbclass(this, "adlb", "금천구\n서울 특별시", 130, 70, 400, 30);
            Lbclass dglb = new Lbclass(this, "dglb", "13˚C", 130, 70, 400, 100);

            Btnclass sbtn = new Btnclass(this, "sbtn", "검색", 50, 25, 920, 48, btn5_Click);
            Btnclass rfbtn = new Btnclass(this, "rfbtn", "새로고침", 50, 45, 800, 0, btn5_Click);
            Btnclass bmbtn = new Btnclass(this, "bmbtn", "즐찾추가", 50, 45, 850, 0, btn5_Click);
            
            weather.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("sunny");
            weather.SizeMode = PictureBoxSizeMode.StretchImage;
            weather.Location = new Point(300, 30);
            weather.Size = new Size(100, 100);

            picture.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("dust2");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(530, 30);
            picture.Size = new Size(50, 50);
            
            
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

            panel1.Controls.Add(dc.lb1(adlb,20));
            panel1.Controls.Add(dc.lb1(dglb,15));
            panel1.Controls.Add(dc.btn1(sbtn));
            panel1.Controls.Add(dc.btn1(rfbtn));
            panel1.Controls.Add(dc.btn1(bmbtn));
            panel1.Controls.Add(tb);
            panel1.Controls.Add(weather);
            panel1.Controls.Add(picture);

            Controls.Add(panel1);
            
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

        