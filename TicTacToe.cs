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
        public string playerPiece;
        public string compPiece;
        public string aiType;

        public TicTacToe()
        {
            InitializeComponent();

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
            button11.Click += new EventHandler(button11_Click);

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
            Button[] gameArray = GetGameButtons();
            bool gameEnd;
            int compMove;

            triggeredButton.Text = this.playerPiece;
            triggeredButton.Enabled = false;
            listBox1.Items.Add(string.Format("Placed at {0}", triggeredButton.Name[triggeredButton.Name.Length - 1]));

            gameEnd = CheckForGameEnd();

            if (aiType == "Pro")
            {
                compMove = GetProCompMove();
            }
            else
            {
                compMove = GetNoobCompMove();
            }
            

            if ((compMove != -1) && (gameEnd != true))
            {
                gameArray[compMove].Text = this.compPiece;
                gameArray[compMove].Enabled = false;
                listBox2.Items.Add(string.Format("Placed at {0}", gameArray[compMove].Name[gameArray[compMove].Name.Length - 1]));
            }

            if (gameEnd == false)
            {
                gameEnd = CheckForGameEnd();
            }
            

        }

        //Play button [Noob]
        private void button10_Click(object sender, EventArgs e)
        {
            Button[] gameArray = GetGameButtons();

            ClearGame();
            EnableGameButtons();
            NewGame("Noob");

            
        }

        //Play button [Pro]
        private void button11_Click(object sender, EventArgs e)
        {
            Button[] gameArray = GetGameButtons();

            ClearGame();
            EnableGameButtons();
            NewGame("Pro");


        }

        

        //methods
        public void NewGame(string aiType)
        {
            TicTacToeGame game = new TicTacToeGame();
            this.aiType = aiType;

            Random random = new Random();
            int coinFlip = random.Next(1, 3);
            if (coinFlip == 1)
            {
                this.playerPiece = "X";
                this.compPiece = "O";
            }
            else
            {
                this.playerPiece = "O";
                this.compPiece = "X";
            }

            label1.Text = string.Format("Player ({0})", this.playerPiece);
            label2.Text = string.Format("Computer ({0})", this.compPiece);

            //if computer is X, make its initial move
            if (this.compPiece == "X")
            {
                Button[] gameArray = GetGameButtons();
                int compInitMove;
                if (this.aiType == "Pro")
                {
                    compInitMove = GetProCompMove();
                }
                else
                {
                    compInitMove = GetNoobCompMove();
                }
                gameArray[compInitMove].Text = this.compPiece;
                gameArray[compInitMove].Enabled = false;
                listBox2.Items.Add(string.Format("Placed at {0}", gameArray[compInitMove].Name[gameArray[compInitMove].Name.Length - 1]));
            }

        }
        public bool CheckForGameEnd()
        {
            Button[] gameArray = GetGameButtons();
            bool gameOver = false;

            string Winner = TicTacToeGame.CheckForWinner(gameArray);
            if (Winner != "")
            {
                DisableGameButtons();
                if (Winner == this.playerPiece)
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
                DisableGameButtons();
                listBox1.Items.Add("You Tie!");
                listBox2.Items.Add("You Tie!");
                MessageBox.Show(string.Format("GAME IS A TIE"));
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



        //Pro move
        public int GetProCompMove()
        {
            int compMove = -1;
            Button[] gameArray = GetGameButtons();

            //take win
            if (WinOrBlockWin(this.playerPiece) != -1) {
                return WinOrBlockWin(this.playerPiece);
            }

            //block enemy win
            if (WinOrBlockWin(this.compPiece) != -1) {
                return WinOrBlockWin(this.compPiece);
            }

            //two corners trick block
            if ((gameArray[4].Text == this.playerPiece) && ((string.Concat(gameArray[0].Text, gameArray[8].Text) == string.Concat(this.compPiece, this.compPiece)) || (string.Concat(gameArray[2].Text, gameArray[6].Text) == string.Concat(this.compPiece, this.compPiece)))) {
                if (TakeByType("SIDE") != -1) {
                    return TakeByType("SIDE");
                }
            }

            //block enemy best play
            if (TakeOrBlockMostAdvantageous(this.playerPiece, this.compPiece) != -1) {
                return TakeOrBlockMostAdvantageous(this.playerPiece, this.compPiece);
            }

            //take own best play
            if (TakeOrBlockMostAdvantageous(this.compPiece, this.playerPiece) != -1) {
                return TakeOrBlockMostAdvantageous(this.compPiece, this.playerPiece);
            }

            //take middle
            if (TakeByType("MIDDLE") != -1) {
                return TakeByType("MIDDLE");
            }

            //take a corner
            if (TakeByType("CORNER") != -1) {
                return TakeByType("CORNER");
            }

            //take a side
            if (TakeByType("SIDE") != -1) {
                return TakeByType("SIDE");
            }

            return compMove;
        }

        //Pro move private methods
        private int WinOrBlockWin(string piece)
        {
            int move = -1;
            Button[] gameArray = GetGameButtons();
            int[,] WIN_COND = {{0,1,2}, {3,4,5}, {6,7,8}, {0,3,6}, {1,4,7}, {2,5,8}, {0,4,8}, {2,4,6}};

            for (int i = 0; i <= 7; i++) {
                if (string.Concat(gameArray[WIN_COND[i,0]].Text, string.Concat(gameArray[WIN_COND[i,1]].Text, gameArray[WIN_COND[i,2]].Text)) == string.Concat(piece, piece)) {
                    for (int j = 0; j <= 2; j++) {
                        if (gameArray[WIN_COND[i,j]].Text == "") {
                            move = WIN_COND[i, j];
                            return move;
                        }
                    }
                }
            }

            return move;
        }

        private int TakeOrBlockMostAdvantageous(string piece, string otherPiece)
        {
            int move = -1;

            Button[] gameArray = GetGameButtons();
            int[,] WIN_COND = {{0,1,2}, {3,4,5}, {6,7,8}, {0,3,6}, {1,4,7}, {2,5,8}, {0,4,8}, {2,4,6}};
            int[] SIDE = {1,3,5,7};
            int[] CORNER = {0,2,6,8};
            int[] MIDDLE = {4};
            int[] priority = {0,0,0,0,0,0,0,0,0};
            int value = 0;

            for (int i = 0; i <= 8; i++) {
                if (gameArray[i].Text == "") {
                    for (int j = 0; j <= 7; j++) {
                        if (i == WIN_COND[j,0]) {
                            if (((gameArray[WIN_COND[j,1]].Text == otherPiece) && (gameArray[WIN_COND[j,2]].Text == "")) || ((gameArray[WIN_COND[j,1]].Text == "") && (gameArray[WIN_COND[j,2]].Text == otherPiece))) {
                                priority[i] += 1;
                            }
                        }

                        if (i == WIN_COND[j,1]) {
                            if (((gameArray[WIN_COND[j,0]].Text == otherPiece) && (gameArray[WIN_COND[j,2]].Text == "")) || ((gameArray[WIN_COND[j,0]].Text == "") && (gameArray[WIN_COND[j,2]].Text == otherPiece))) {
                                priority[i] += 1;
                            }
                        }

                        if (i == WIN_COND[j,2]) {
                            if (((gameArray[WIN_COND[j,0]].Text == otherPiece) && (gameArray[WIN_COND[j,1]].Text == "")) || ((gameArray[WIN_COND[j,0]].Text == "") && (gameArray[WIN_COND[j,1]].Text == otherPiece))) {
                                priority[i] += 1;
                            }
                        }
                    }
                }
            }

            for (int k = 0; k <= 8; k++) {
                if (priority[k] > value) {
                    value = priority[k];
                    move = k;
                }
                else if ((priority[k] != 0) && (priority[k] == value)) {
                    if ((SIDE.Contains(move) && (CORNER.Contains(k) || MIDDLE.Contains(k))) || (CORNER.Contains(move) && MIDDLE.Contains(k)))
                    {
                        move = k;
                    }
                }
            }
            return move;
        }

        private int TakeByType(string type)
        {
            int move = -1;

            Button[] gameArray = GetGameButtons();
            int[] SIDE = {1,3,5,7};
            int[] CORNER = {0,2,6,8};
            int[] MIDDLE = {4};
            int[] useThis;

            if (type == "MIDDLE")
            {
                useThis = MIDDLE;
            }
            else if (type == "CORNER")
            {
                useThis = CORNER;
            }
            else
            {
                useThis = SIDE;
            }

            foreach (int cell in useThis)
            {
                if (gameArray[cell].Text == "")
                {
                    move = cell;
                    return move;
                }
            }

            return move;
        }



        public void ClearGame()
        {
            Button[] gameArray = GetGameButtons();
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

        public Button[] GetGameButtons()
        {
            Button[] gameArray = { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
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
            //does nothing when already in Tic Tac Toe
        }
        private void flippyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.GoToFlippy(this);
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
