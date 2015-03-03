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
            triggeredButton.Text = "X";
        }

        //Play button
        private void button10_Click(object sender, EventArgs e)
        {
            MainMenu.NYI();
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
        public void GoToMainMenu()
        {
            this.Hide();
            var MainMenu = new MainMenu();
            MainMenu.Closed += (s, args) => this.Close();
            MainMenu.Show();
        }
    }
}
