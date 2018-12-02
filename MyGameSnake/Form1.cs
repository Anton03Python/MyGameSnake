using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGameSnake
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        int W = 80, H = 60;
        int S = 10;
        List<coord> snake = new List<coord>();
        coord apple; // координаты яблока
        int way = 0; // направление движения змеи: 0 - вверх, 1 - вправо, 2 - вниз, 3 - влево
        int apples = 0; // количество собранных яблок

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 200; // таймер срабатывает раз в 200 милисекунд
            timer.Tick += new EventHandler(timer1_Tick); 
            timer.Start(); // запускаем таймер
            snake.Add(new coord(W / 2, H - 3));
            snake.Add(new coord(W / 2, H - 2));
            snake.Add(new coord(W / 2, H - 1));
            apple = new coord(rand.Next(W), rand.Next(H)); // координаты яблока
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    if (way != 2)
                        way = 0;
                    break;
                case Keys.Right:
                    if (way != 3)
                        way = 1;
                    break;
                case Keys.Down:
                    if (way != 0)
                        way = 2;
                    break;
                case Keys.Left:
                    if (way != 1)
                        way = 3;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // запоминаем координаты головы змеи
            int x = snake[0].X, y = snake[0].Y;
            switch (way)
            {
                case 0:
                    y--;
                    if (y < 0)
                        y = H - 1;
                    break;
                case 1:
                    x++;
                    if (x >= W)
                    {
                        x = 0;                          
                    }
                    break;
                case 2:
                    y++;
                    if (y >= H)
                        y = 0;
                    break;
                case 3:
                    x--;
                    if (x < 0)
                        x = W - 1;
                    break;
            }
            coord c = new coord(x, y); // сегмент с новыми координатами головы
            snake.Insert(0, c); // вставляем его в начало списка сегментов змеи(змея выросла на один сегмент)
            if (snake[0].X == apple.X && snake[0].Y == apple.Y) // если координаты головы и яблока совпали
            {
                apple = new coord(rand.Next(W), rand.Next(H)); // располагаем яблоко в новых случайных координатах
                if (apples % 10 == 0) // после каждого десятого яблока
                {
                    timer.Interval -= 10;
                }
            }
            else 
                snake.RemoveAt(snake.Count - 1);
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0].X == snake[i].X && snake[0].Y == snake[i].Y)
                {
                    timer.Stop();
                    DialogResult result = MessageBox.Show("Game Over!", "Information", MessageBoxButtons.OK);   
                    if (result == DialogResult.OK)
                    {
                        // TODO: сделать продолжение игры(обнулить длину змеи и т.д)
                    }
                }
            }
            Invalidate(); //идет вызов Program_Paint
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // рисуем яблоко и змейку
            e.Graphics.FillEllipse(Brushes.Green, new Rectangle(apple.X * S, apple.Y * S, S, S));
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(snake[0].X * S, snake[0].Y * S, S, S));
            for (int i = 1; i < snake.Count; i++)
                e.Graphics.FillRectangle(Brushes.Black, new Rectangle(snake[i].X * S, snake[i].Y * S, S, S));            
        }
    }
}
