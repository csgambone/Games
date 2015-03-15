﻿using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public partial class _2048 : Form
    {
        _2048Game Game = new _2048Game();

        //timer
        Stopwatch gameTime = new Stopwatch();
        Timer timeUpdater = new Timer();

        public _2048()
        {
            InitializeComponent();

            //Game field buttons

            //Play button
            //button1.Click += new EventHandler(playCenters_Click);

            //Menu strip
            mainMenuToolStripMenuItem.Click += new EventHandler(mainMenuToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            ticTacToeToolStripMenuItem.Click += new EventHandler(ticTacToeToolStripMenuItem_Click);
            flippyToolStripMenuItem.Click += new EventHandler(flippyToolStripMenuItem_Click);
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            logixToolStripMenuItem.Click += new EventHandler(logixToolStripMenuItem_Click);

            //timeUpdater setup
            timeUpdater.Tick += new EventHandler(TimerEventProcessor);
            timeUpdater.Interval = 100;
            timeUpdater.Start();
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            TimeSpan ts = gameTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            label12.Text = elapsedTime;
        }

        private void _2048_Load(object sender, EventArgs e)
        {

        }

        //Menu strip
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.GoToMainMenu(this);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.ExitApplication();
        }
        private void ticTacToeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.GoToTicTacToe(this);
        }
        private void flippyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //does nothing when already in Flippy
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainMenu.GoTo2048(this);
        }
        private void logixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
        }
    }
}