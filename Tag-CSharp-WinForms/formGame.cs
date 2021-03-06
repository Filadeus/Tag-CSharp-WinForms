﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tag_CSharp_WinForms
{
    public partial class formGame : Form
    {
        Core game;
        DateTime date;
        public formGame()
        {
            InitializeComponent();
            game = new Core(4);
        }

        private void tickTimer(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();

            stopWatch = stopWatch.AddTicks(tick);
            lTimer.Text = String.Format("{0:mm:ss:ff}", stopWatch);
        }
        
        private Button button(int pos)
        {
            switch (pos)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }
        
        private void fill()
        {
            for(int pos = 0; pos < 16; pos++)
            {
                button(pos).Text = game.getNumber(pos).ToString();
                button(pos).Visible = game.getNumber(pos) > 0;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            int buttonPressed = Convert.ToInt32(((Button)sender).Tag);
            /*
            date = DateTime.Now;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(tickTimer);
            timer.Start();
            */
            game.shiftButton(buttonPressed);
            fill();

            if (game.checkForWin())
                //timer.Stop();
                MessageBox.Show("Вы победили!", "Congrats!");
        }

        private void menuStartGame_Click(object sender, EventArgs e)
        {
            game.initGame();
            for(int i = 0; i < 100; i++)
            {
                game.randomShift();
            }
            fill();
        }

        private void menuGameExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
