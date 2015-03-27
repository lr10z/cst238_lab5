using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI___Lab_5
{
    public partial class Form1 : Form
    {
        private Random numberGenerator;
        public Form1()
        {
            InitializeComponent();
            numberGenerator = new Random();
            button1.Visible = false;
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //update drawing on the form
            Graphics g = e.Graphics;

            Font font1 = new Font("Arial", 10, GraphicsUnit.Point);
            g.DrawString("Pens", font1, Brushes.Black, new Point(1, 2));
            Pen pen = new Pen(Color.LightGray, 1);
            g.DrawLine(pen, 0, 20, 702, 20);
            pen = new Pen(Color.Gray, 2);
            g.DrawLine(pen, 0, 25, 702, 25);
            pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, 0, 30, 702, 30);

            // Solid Brush
            font1 = new Font("Arial", 8, GraphicsUnit.Point);
            g.DrawString("Solid Brush", font1, Brushes.Black, new Point(1, 40));
            Brush brush = new SolidBrush(Color.BurlyWood);
            g.FillRectangle(brush, 0, 55, 351, 55);

            // Texture Brush
            font1 = new Font("Arial", 18, GraphicsUnit.Point);
            g.DrawString("Texture Brush", font1, Brushes.Black, new Point(1, 160));
            brush = new TextureBrush(Properties.Resources.Desert);
            g.FillRectangle(brush, 0, 200, 702, 466);
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //These will create immediately drawn circles in the PictureBox
            Graphics g = pictureBox1.CreateGraphics();

            int x, y, r;
            x = numberGenerator.Next(0, pictureBox1.Width);
            y = numberGenerator.Next(0, pictureBox1.Height);
            r = numberGenerator.Next(0, 50);
            if (x + r >= pictureBox1.Width)
                x = pictureBox1.Width - r;
            if (y + r >= pictureBox1.Height)
                y = pictureBox1.Height - r;
            Rectangle rect = new Rectangle(x, y, r, r);
            g.DrawImage(Properties.Resources.A10963, rect);
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Color randomColor = Color.FromArgb(numberGenerator.Next(255), numberGenerator.Next(255),
                                               numberGenerator.Next(255));
            Graphics g = e.Graphics;
            Pen pen = new Pen(randomColor, 10);
            g.DrawEllipse(pen, 50, 10, 100, 100);


            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            randomColor = Color.FromArgb(numberGenerator.Next(255), numberGenerator.Next(255),
                                               numberGenerator.Next(255));
            pen = new Pen(randomColor, 10);
            g.DrawRectangle(pen, rect);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            
        }

    }
}
