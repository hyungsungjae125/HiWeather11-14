﻿using System;
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
        public Main()
        {
           
            InitializeComponent();

            Load += Main_Load;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            Size = new Size(1000, 600);
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

            Btnclass sbtn = new Btnclass(this, "sbtn", "검색", 50, 25, 920, 48, btn1_Click);
            Btnclass rfbtn = new Btnclass(this, "rfbtn", "새로고침", 50, 45, 800, 0, btn1_Click);
            Btnclass bmbtn = new Btnclass(this, "bmbtn", "즐찾추가", 50, 45, 850, 0, btn1_Click);
            
            weather.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("sunny");
            weather.SizeMode = PictureBoxSizeMode.StretchImage;
            weather.Location = new Point(300, 30);
            weather.Size = new Size(100, 100);

            picture.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("dust2");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Location = new Point(530, 30);
            picture.Size = new Size(50, 50);


            panel1.Controls.Add(dc.lb1(adlb));
            panel1.Controls.Add(dc.lb1(dglb));
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
            MessageBox.Show("피드백");
        }
        private void btn4_Click(Object o, EventArgs e)
        {
            MessageBox.Show("설정");
        }

    }
}

        