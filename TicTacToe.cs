using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games
{
    public partial class TicTacToe : Form
    {
        //public string player { get; set; }

        public TicTacToe()
        {
            InitializeComponent();
            //Random random = new Random();
            //int playerPiece = random.Next(1, 3);
            //TicTacToe.player = "X";

            //Game field buttons
            button1.Click += new EventHandler(gameButton_Click);
            button2.Click += new EventHandler(gameButton_Click);
            button3.Click += new EventHandler(gameButton_Click);
            button4.Click += new EventHandler(gameButton_Click);
            button5.Click += new EventHandler(gameButton_Click);
            button6.Click += new EventHandler(gameButton_Click);
            button7.Click += new EventHandler(gameButton_Click);
            button8.Click += new EventHandler(gameButton_Click);
            button9.Click += new EventHandler(gameButton_Click);

            //Play button
            button10.Click += new EventHandler(button10_Click);

            //Menu strip
            mainMenuToolStripMenuItem.Click += new EventHandler(mainMenuToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            ticTacToeToolStripMenuItem.Click += new EventHandler(ticTacToeToolStripMenuItem_Click);
            flippyToolStripMenuItem.Click += new EventHandler(flippyToolStripMenuItem_Click);
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            logixToolStripMenuItem.Click += new EventHandler(logixToolStripMenuItem_Click);
        }

        //Game field buttons
        private void gameButton_Click(object sender, EventArgs e)
        {
            Button triggeredButton = (Button)sender;
            Button[] gameArray = GetGameButtons();
            bool gameEnd;

            triggeredButton.Text = "X";
            triggeredButton.Enabled = false;
            listBox1.Items.Add(string.Format("Placed at {0}", triggeredButton.Name[triggeredButton.Name.Length - 1]));

            gameEnd = CheckForGameEnd();

            int compMove = GetNoobCompMove();
            if ((compMove != -1) && (gameEnd != true))
            {
                gameArray[compMove].Text = "O";
                gameArray[compMove].Enabled = false;
                listBox2.Items.Add(string.Format("Placed at {0}", gameArray[compMove].Name[gameArray[compMove].Name.Length - 1]));
            }

        }

        //Play button
        private void button10_Click(object sender, EventArgs e)
        {
            Button[] gameArray = GetGameButtons();

            ClearGame();
            EnableGameButtons();
        }

        //Menu strip
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToMainMenu();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.ExitApplication();
        }
        private void ticTacToeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //does nothing when already in Tic Tac Toe
        }
        private void flippyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
        }
        private void logixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
        }

        //methods
        public bool CheckForGameEnd()
        {
            Button[] gameArray = GetGameButtons();
            bool gameOver = false;

            string Winner = TicTacToeGame.CheckForWinner(gameArray);
            if (Winner != "")
            {
                DisableGameButtons();
                if (Winner == "X")
                {
                    listBox1.Items.Add("You Win!");
                }
                else
                {
                    listBox2.Items.Add("You Win!");
                }
                MessageBox.Show(string.Format("WINNER IS: {0}", Winner));
                gameOver = true;
            }
            else if (NoRemainingMoves())
            {
                MessageBox.Show(string.Format("GAME IS A TIE"));
                DisableGameButtons();
                gameOver = true;
            }

            return gameOver;
        }

        public bool NoRemainingMoves()
        {
            Button[] gameArray = GetGameButtons();
            bool noneRemaining = true;

            foreach (Button button in gameArray)
            {
                if (button.Text == "")
                {
                    noneRemaining = false;
                }
            }
            return noneRemaining;
        }

        public int GetNoobCompMove()
        {
            Button[] gameArray = GetGameButtons();
            int compMove = -1;
            int listLocation = -1;
            int i = 0;

            List<int> compChoiceList = new List<int>();
            foreach (Button button in gameArray)
            {
                if (button.Text == "")
                {
                    compChoiceList.Add(i);
                }
                i++;
            }
            if (compChoiceList.Count() != 0)
            {
                Random random = new Random();
                listLocation = random.Next(0, compChoiceList.Count());
                compMove = compChoiceList[listLocation];
            }

            return compMove;
        }

        public void ClearGame()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in gameArray)
            {
                button.Text = "";
                button.BackColor = default(Color);
            }
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        public void EnableGameButtons()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in gameArray)
            {
                button.Enabled = true;
            }
        }

        public void DisableGameButtons()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (Button button in gameArray)
            {
                button.Enabled = false;
            }
        }

        public Button[] GetGameButtons()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            return gameArray;
        }

        public void GoToMainMenu()
        {
            this.Hide();
            var MainMenu = new MainMenu();
            MainMenu.Closed += (s, args) => this.Close();
            MainMenu.Show();
        }
    }
}
