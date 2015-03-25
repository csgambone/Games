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
            button17.Click += new EventHandler(play_Click);

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

        private void play_Click(object sender, EventArgs e)
        {
            //ClearGame();
            Game.NewGame();
            RenderGame();
            gameTime.Restart();
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            TimeSpan ts = gameTime.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
            label12.Text = elapsedTime;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                Game.MoveLeft(Game.GameBoard);
                RenderGame();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                Game.MoveRight();
                RenderGame();
                return true;
            }
            else if (keyData == Keys.Up)
            {
                Game.MoveUp();
                RenderGame();
                return true;
            }
            else if (keyData == Keys.Down)
            {
                Game.MoveDown();
                RenderGame();
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }


        public void RenderGame()
        {
            Button[] gameArray = GetGameButtons();

            int i = 0;
            int j = 0;

            foreach (Button gameButton in gameArray)
            {
                if (Game.GameBoard[i, j] != 0)
                {
                    gameButton.Text = Game.GameBoard[i, j].ToString();
                }
                else
                {
                    gameButton.Text = "";
                }

                //increment/reset counters for two dimensional gameArray
                if (j == 3)
                {
                    i++;
                    j = 0;
                }
                else
                {
                    j++;
                }
            }

            //Win detection
        }

        public void ClearGame()
        {
            Button[] gameArray = GetGameButtons();
            foreach (Button gameButton in gameArray)
            {
                gameButton.Text = "";
            }
        }

        public Button[] GetGameButtons()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16 };
            return gameArray;
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
