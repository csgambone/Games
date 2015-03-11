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
    public partial class Flippy : Form
    {
        FlippyGame Game = new FlippyGame();
        //public Stopwatch gameTime;
        Stopwatch gameTime = new Stopwatch();

        public Flippy()
        {
            InitializeComponent();

            //Game field buttons
            Button[] gameArray = GetGameButtons();
            foreach (Button gameButton in gameArray)
            {
                gameButton.Click += new EventHandler(gameButton_Click);
            }

            //Play button [Centers]
            button1.Click += new EventHandler(playCenters_Click);

            //Play button [No Centers]
            button197.Click += new EventHandler(playNoCenters_Click);

            //Menu strip
            mainMenuToolStripMenuItem.Click += new EventHandler(mainMenuToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            ticTacToeToolStripMenuItem.Click += new EventHandler(ticTacToeToolStripMenuItem_Click);
            flippyToolStripMenuItem.Click += new EventHandler(flippyToolStripMenuItem_Click);
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            logixToolStripMenuItem.Click += new EventHandler(logixToolStripMenuItem_Click);

            //Start disabled
            DisableGameButtons();
        }

        //Game field buttons
        private void gameButton_Click(object sender, EventArgs e)
        {
            Button triggeredButton = (Button)sender;

            Game.moves++;

            string buttonName = triggeredButton.Name;
            string buttonNumberString = buttonName.Substring(6, buttonName.Length - 6);
            double buttonNumber = Convert.ToDouble(buttonNumberString);
            buttonNumber--;

            //Row
            int row = (int)Math.Ceiling(buttonNumber / 15);
            //Column
            int column = (int)Math.Ceiling(buttonNumber % 15);
            if (column == 0)
            {
                column = 15;
            }

            row--;
            column--;

            Game.SwapColor(row, column);
            RenderGame();
        }

        private void playCenters_Click(object sender, EventArgs e)
        {
            ClearGame();
            Game.NewGame(true);
            RenderGame();
            EnableGameButtons();
            gameTime.Start();
        }

        private void playNoCenters_Click(object sender, EventArgs e)
        {
            ClearGame();
            Game.NewGame(false);
            RenderGame();
            EnableGameButtons();
            gameTime.Start();
        }

        public void RenderGame() {
            Button[] gameArray = GetGameButtons();

            int i = 0;
            int j = 0;
            int redCount = 0;
            int blueCount = 0;
            int greyCount = 0;

            foreach (Button gameButton in gameArray)
            {
                if (Game.GameBoard[i, j] == 0)
                {
                    gameButton.BackColor = Color.Red;
                    redCount++;
                }
                else if (Game.GameBoard[i, j] == 1)
                {
                    gameButton.BackColor = Color.Blue;
                    blueCount++;
                }
                else
                {
                    greyCount++;
                }

                //increment/reset counters for two dimensional gameArray
                if (j == 14)
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
            if (blueCount == 0)
            {
                DisableGameButtons();
                label8.ForeColor = Color.Red;
                label8.Text = "YOU WIN!";
            }
            else if (redCount == 0)
            {
                DisableGameButtons();
                label8.ForeColor = Color.Blue;
                label8.Text = "YOU WIN!";
            }

            //Update stats
            label4.Text = redCount.ToString();
            label5.Text = blueCount.ToString();
            label6.Text = greyCount.ToString();
            label11.Text = Game.moves.ToString();
            if (gameTime != null)
            {
                TimeSpan ts = gameTime.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
                label12.Text = elapsedTime;
            }
            
        }

        public Button[] GetGameButtons()
        {
            Button[] gameArray = { button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16, 
                                     button17, button18, button19, button20, button21, button22, button23, button24, button25, button26, button27, button28, button29, button30, button31, 
                                     button32, button33, button34, button35, button36, button37, button38, button39, button40, button41, button42, button43, button44, button45, button46, 
                                     button47, button48, button49, button50, button51, button52, button53, button54, button55, button56, button57, button58, button59, button60, button61, 
                                     button62, button63, button64, button65, button66, button67, button68, button69, button70, button71, button72, button73, button74, button75, button76, 
                                     button77, button78, button79, button80, button81, button82, button83, button84, button85, button86, button87, button88, button89, button90, button91, 
                                     button92, button93, button94, button95, button96, button97, button98, button99, button100, button101, button102, button103, button104, button105, button106, 
                                     button107, button108, button109, button110, button111, button112, button113, button114, button115, button116, button117, button118, button119, button120, button121, 
                                     button122, button123, button124, button125, button126, button127, button128, button129, button130, button131, button132, button133, button134, button135, button136, 
                                     button137, button138, button139, button140, button141, button142, button143, button144, button145, button146, button147, button148, button149, button150, button151, 
                                     button152, button153, button154, button155, button156, button157, button158, button159, button160, button161, button162, button163, button164, button165, button166, 
                                     button167, button168, button169, button170, button171, button172, button173, button174, button175, button176, button177, button178, button179, button180, button181, 
                                     button182, button183, button184, button185, button186, button187, button188, button189, button190, button191, button192, button193, button194, button195, button196
                                 };
            return gameArray;
        }

        public void EnableGameButtons()
        {
            Button[] gameArray = GetGameButtons();
            foreach (Button button in gameArray)
            {
                button.Enabled = true;
            }
        }

        public void DisableGameButtons()
        {
            Button[] gameArray = GetGameButtons();
            foreach (Button button in gameArray)
            {
                button.Enabled = false;
            }
        }

        public void ClearGame()
        {
            Button[] gameArray = GetGameButtons();
            foreach (Button gameButton in gameArray)
            {
                gameButton.BackColor = default(Color);
            }
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
            MainMenu.NYI();
        }
        private void logixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
        }
    }
}
