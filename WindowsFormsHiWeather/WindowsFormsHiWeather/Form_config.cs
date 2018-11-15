using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHiWeather
{
    public partial class Form_config : Form
    {
        public Form_config()
        {
            InitializeComponent();

            Load += Form_config_Load;
        }

        private Button btn;
        private Label lb;
        private string ctrType;
        private RadioButton selectedrb;
        private TextBox textBox1;


        private void Form_config_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;

            SetRegion();


            ArrayList arrList = new ArrayList();
            BackColor = Color.AliceBlue;

            //arrList.Add(new Item("window_button", 700, 20, "window1"));
            //arrList.Add(new Item("window_button", 725, 20, "window2"));
            //arrList.Add(new Item("window_button", 750, 20, "window3"));

            arrList.Add(new Item("label", 50, 20, "설정"));
            arrList.Add(new Item("label", 50, 220, "온도표시단위"));
            arrList.Add(new Item("tabpage", 700, 150, "탭페이지1"));
            arrList.Add(new Item("radiobutton", 50, 250, "섭씨"));
            arrList.Add(new Item("radiobutton", 50, 270, "화씨"));
            arrList.Add(new Item("label", 50, 320, "시작 위치"));
            arrList.Add(new Item("radiobutton", 50, 350, "내 위치 항상검색"));
            arrList.Add(new Item("radiobutton", 50, 370, "기본위치"));
            arrList.Add(new Item("textbox", 160, 370, "text검색"));
            arrList.Add(new Item("search_button", 138, 370, "serch버튼")); // 138, 369,
            arrList.Add(new Item("button", 550, 380, "적용"));
            arrList.Add(new Item("button", 650, 380, "취소"));

            for (int i = 0; i < arrList.Count; i++)
            {
                Control_Create((Item)arrList[i]);
            }
        }


        private Control Control_Create(Item item)
        {

            Control ctr = new Control();
            TabControl tabctr = new TabControl();
            ctrType = item.getType();

            switch (item.getType())
            {

                case "button":
                    btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_click;
                    ctr = btn;
                    break;
                case "search_button":
                    btn = new Button();
                    btn.DialogResult = DialogResult.OK;
                    btn.Cursor = Cursors.Hand;
                    btn.Click += btn_click;

                    //System.Drawing.Image myImage = Image.FromFile (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\Image.gif");
                    System.Drawing.Image myImage = (Image)WindowsFormsHiWeather.Properties.Resources.ResourceManager.GetObject("search_button");

                    ImageList imageList1 = new ImageList();
                    //imageList1.Images.Add(Image.FromFile("C:\\search_button.bmp"));

                    imageList1.ImageSize = new Size(255, 255);
                    imageList1.Images.Add(myImage);
                    imageList1.ImageSize = new System.Drawing.Size(40, 28);
                    imageList1.TransparentColor = System.Drawing.Color.Transparent;

                    btn.ImageIndex = 0;
                    btn.ImageList = imageList1;
                    //btn.Image = Image.FromFile();
                    // Align the image and text on the button.
                    //btn.ImageAlign = ContentAlignment.MiddleRight;
                    //btn.TextAlign = ContentAlignment.MiddleCenter;
                    //btn.BackgroundImageLayout = ImageLayout.Zoom;  // 테스트중

                    // Give the button a flat appearance.
                    btn.TabStop = false;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    ctr = btn;
                    break;
                case "label":
                    ctr = new Label();
                    break;
                case "tabpage":
                    ctr = new System.Windows.Forms.TabPage();
                    tabctr = new System.Windows.Forms.TabControl();
                    tabctr.Location = new System.Drawing.Point(50, 50); // TabControl 시작 위치 지정
                    tabctr.Size = new System.Drawing.Size(item.getX(), item.getY()); //  TabControl 사이즈 크기 지정.
                    tabctr.SelectedIndex = 0;
                    tabctr.TabIndex = 0;

                    ctr.Size = new System.Drawing.Size(256, 214);  // (256, 214) TabPage 사이즈 크기 지정.
                    ctr.TabIndex = 0;
                    tabctr.Controls.Add(ctr);
                    break;
                case "radiobutton":
                    ctr = new System.Windows.Forms.RadioButton();
                    break;
                case "textbox":
                    textBox1 = new System.Windows.Forms.TextBox();
                    textBox1.AcceptsReturn = true;
                    textBox1.AcceptsTab = true;
                    //textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
                    //textBox1.Multiline = true;
                    //textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                    ctr = textBox1;
                    break;

                default:
                    break;
            }
            ////////////Switch문 종료 //////////////

            ctr.Name = item.getTxt();

            if (ctrType != "search_button")
            {
                ctr.Text = item.getTxt();
            }

            //////// 버튼 사이즈 설정 ///////
            if (ctrType == "label")
            {
                ctr.Size = new Size(100, 20);  // 사이즈 설정
                ctr.Location = new Point(item.getX(), item.getY());  // 위치지정
            }
            else if (ctrType == "button")
            {
                ctr.Size = new Size(100, 30);  // 사이즈 설정
                ctr.Location = new Point(item.getX(), item.getY());  // 위치지정
            }
            else if (ctrType == "search_button")
            {
                ctr.Size = new Size(23, 23);  // (23, 23) 사이즈 설정
                ctr.Location = new Point(item.getX(), item.getY());  // 위치지정

            }
            else if (ctrType == "window_button")
            {
                ctr.Size = new Size(22, 20);  // (23, 23) 사이즈 설정
                ctr.Location = new Point(item.getX(), item.getY());  // 위치지정

            }
            else if (ctrType == "textbox")
            {
                ctr.Size = new Size(100, 30);  // 사이즈 설정
                ctr.Location = new Point(item.getX(), item.getY());  // 위치지정
            }
            else if (ctrType == "radiobutton")
            {
                ctr.Location = new System.Drawing.Point(item.getX(), item.getY());
                ctr.Size = new System.Drawing.Size(73, 15);  // radio 버튼 사이즈
            }

            /////// 컨트롤 폼에 추가 ////////
            if (ctrType != "tabpage")
            {
                Controls.Add(ctr);
            }
            else if (ctrType == "tabpage")
            {
                Controls.Add(tabctr);
            }

            return ctr;
        }


        //private Label lb_create(int i)
        //{

        //    lb = new Label();
        //    lb.Name = string.Format("btn_{0}", (i + 1));
        //    lb.Text = string.Format("확인 : {0}", (i + 1));
        //    lb.Size = new Size(100, 50);  // 사이즈 설정
        //    lb.Location = new Point((100 * i) + 30, 30);  // 위치지정
        //    return lb;
        //}

        // 생성한 버튼에 대한 옵션
        private void btn_click(object o, EventArgs a)
        {
            string names = "";
            foreach (Control ct in Controls)
            {
                // names += ct.Name + " ";
                //if(ct.Name != "btn_3")
                //{
                ct.BackColor = Color.Silver;
                //}                
            }
            // 생성한 버튼 연결
            btn = (Button)o;
            //btn.BackColor = (btn.BackColor == Color.Green) ? btn.BackColor = Color.Silver : btn.BackColor = Color.Green;                     
        }


        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            // Ensure that the RadioButton.Checked property
            // changed to true.
            if (rb.Checked)
            {
                // Keep track of the selected RadioButton by saving a reference
                // to it.
                selectedrb = rb;
            }
        }

        private void SetRegion()
        {
            Rectangle rectangle = this.DisplayRectangle;
            GraphicsPath path = new GraphicsPath();
            int arcRadius = 50;
            path.AddArc(rectangle.X + 16, rectangle.Y + 4, arcRadius, arcRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - arcRadius - 6, rectangle.Y + 4, arcRadius, arcRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - arcRadius - 6, rectangle.Y + rectangle.Height - arcRadius - 18, arcRadius, arcRadius, 0, 90);
            path.AddArc(rectangle.X + 16, rectangle.Y + rectangle.Height - arcRadius - 18, arcRadius, arcRadius, 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
        }


    }

}

public class Item
{
    private string type;
    private int x;
    private int y;
    private string txt;
    public Item(string type, int x, int y, string txt)
    {
        this.type = type;
        this.x = x;
        this.y = y;
        this.txt = txt;

    }
    public string getType()
    {
        return type;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    public string getTxt()
    {
        return txt;

    }

}

