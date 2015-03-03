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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            //Game selection buttons
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);

            //Exit button
            button5.Click += new EventHandler(button5_Click);

            //Menu strip
            mainMenuToolStripMenuItem.Click += new EventHandler(mainMenuToolStripMenuItem_Click);
            exitToolStripMenuItem.Click += new EventHandler(exitToolStripMenuItem_Click);
            ticTacToeToolStripMenuItem.Click += new EventHandler(ticTacToeToolStripMenuItem_Click);
            flippyToolStripMenuItem.Click += new EventHandler(flippyToolStripMenuItem_Click);
            ToolStripMenuItem1.Click += new EventHandler(ToolStripMenuItem1_Click);
            logixToolStripMenuItem.Click += new EventHandler(logixToolStripMenuItem_Click);
        }

        //Game selection buttons
        private void button1_Click(object sender, EventArgs e)
        {
            GoToTicTacToe();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NYI();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NYI();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NYI();
        }

        //Exit button
        private void button5_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        //Menu strip
        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //does nothing when already in Main Menu
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
        private void ticTacToeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToTicTacToe();
        }
        private void flippyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NYI();
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NYI();
        }
        private void logixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NYI();
        }


        //methods
        public void GoToTicTacToe()
        {
            this.Hide();
            var TicTacToe = new TicTacToe();
            TicTacToe.Closed += (s, args) => this.Close();
            TicTacToe.Show();
        }

        public static void NYI()
        {
            MessageBox.Show("NOT YET IMPLEMENTED.");
        }

        public static void ExitApplication()
        {
            Application.Exit();
        }

    }
}
