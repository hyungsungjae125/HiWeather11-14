using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsHiWeather
{
    class Drawclass
    {
        public void btn(Btnclass bc)
        {
           Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bc.Name;
            btn.Text = bc.Text;
            btn.Size = new Size(bc.SX, bc.SY);
            btn.Location = new Point(bc.PX, bc.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += bc.eh;
            bc.Form.Controls.Add(btn);
            
        }
        public Button btn1(Btnclass bc)
        {
            Button btn = new Button();
            btn.DialogResult = DialogResult.OK;
            btn.Name = bc.Name;
            btn.Text = bc.Text;
            btn.Size = new Size(bc.SX, bc.SY);
            btn.Location = new Point(bc.PX, bc.PY);
            btn.Cursor = Cursors.Hand;
            btn.Click += bc.eh;

            Image btn_myImage;

            if (bc.Name == "Home")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("Home");
            }
            else if (bc.Name == "bookmark")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("bookmark");
            }
            else if (bc.Name == "feedback")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("Feedback");
            }
            else if (bc.Name == "option")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("Option");
            }
            else if (bc.Name == "rfbtn")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("refresh");
            }
            else if (bc.Name == "bmbtn")
            {
                btn_myImage = (Image)Properties.Resources.ResourceManager.GetObject("refresh");
            }



            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(255, 255);
            imageList.Images.Add(btn_myImage);
            imageList.ImageSize = new Size(40, 28);
            imageList.TransparentColor = Color.Transparent;

            btn.ImageIndex = 0;
            btn.ImageList = imageList;
            btn.TabStop = false;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            return btn;

        }
       
        public Label lb(Lbclass lb)
        {
            Label label  = new Label(); 
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            lb.Form.Controls.Add(label);
            return label;
        }
        public Label lb1(Lbclass lb)
        {
            Label label = new Label();
            label.Name = lb.Name;
            label.Text = lb.Text;
            label.Size = new Size(lb.SX, lb.SY);
            label.Location = new Point(lb.PX, lb.PY);
            label.Font = new Font(FontFamily.GenericSansSerif, 20.0F, FontStyle.Bold);
            label.ForeColor = Color.White;
            return label;
        }
    }
}
