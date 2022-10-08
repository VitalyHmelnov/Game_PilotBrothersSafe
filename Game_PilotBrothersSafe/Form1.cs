using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_PilotBrothersSafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        
        PictureBox[,] pb;
        bool [,] Arr = new bool[10, 10];
        private void button1_Click(object sender, EventArgs e)
        {
            
            int n = int.Parse(comboBox1.Text);            
            Controls.Clear();
            pb = new PictureBox[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Arr[i, j] = true;
                    pb[i, j] = new PictureBox();
                    pb[i, j].Location = new System.Drawing.Point(330 + i * 50, 100 + j * 50);
                    pb[i, j].Size = new System.Drawing.Size(50, 50);
                    pb[i, j].TabIndex = i;
                    pb[i, j].BackColor = Color.Transparent;
                    pb[i, j].Image = Resource1.handle;
                    Controls.Add(pb[i, j]);
                    int row = i;
                    int column = j;
                    pb[i, j].Click += (x, y) => { pbClick(row, column); };
                }
            }
            pb[0, 0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Arr[0, 0] = false;
            for (int i = 1; i < n; i++)
            {
                Arr[0, i] = false;
                Arr[i, 0] = false;
                pb[0, i].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pb[i, 0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }

        void pbClick(int row, int column)
        {
            int n = int.Parse(comboBox1.Text);
            int count = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == row || j == column)
                    {
                        if (Arr[i, j] == true)
                        {
                            Arr[i, j] = false;
                            Image image = pb[i, j].Image;
                            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            pb[i, j].Image = image;
                        }
                        else
                        {
                            Arr[i, j] = true;
                            Image image = pb[i, j].Image;
                            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            pb[i, j].Image = image;
                        }
                        
                    }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Arr[i,j]==true)
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                }
            }
            if (count==n*n||count==-n*n)
            {
                Controls.Clear();
                BackgroundImage = Resource1.safe_open;
                label1 = new Label();
                label1.Text = "Поздравляю, ты открыл сейф";
                label1.Location = new System.Drawing.Point(0, 60);
                label1.Size = new System.Drawing.Size(500, 20);
                Controls.Add(label1);

            }
        }
        
    }
}
