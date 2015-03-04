using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Games
{
    class TicTacToeGame
    {
        private static int[,] Winners = new int[,]
		{
		    {0,1,2},
			{3,4,5},
			{6,7,8},
			{0,3,6},
			{1,4,7},
			{2,5,8},
			{0,4,8},
			{2,4,6}
		};


        public static string CheckForWinner(Button[] gameArray)
        {
            string winner = "";
            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0];
                int b = Winners[i, 1];
                int c = Winners[i, 2];

                Button b1 = gameArray[a];
                Button b2 = gameArray[b];
                Button b3 = gameArray[c];

                
                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                {
                    continue;
                }
                

                if ((b1.Text == b2.Text) && (b2.Text == b3.Text))
                {
                    b1.BackColor = b2.BackColor = b3.BackColor = Color.LightCoral;
                    winner = b1.Text;
                    break;
                }
            }
            return winner;
        }
    }

    
}
