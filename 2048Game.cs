using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class _2048Game
    {
        public int[,] GameBoard = new int[4, 4];
        public int score = 0;

        public void NewGame()
        {
            Random random = new Random();
            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;

            Array.Clear(GameBoard, 0, GameBoard.Length);

            i = random.Next(0, 4);
            j = random.Next(0, 4);

            NewGameButton(i, j);

            do
            {
                k = random.Next(0, 4);
                m = random.Next(0, 4);
            } while ((i == k) && (j == m));

            NewGameButton(k, m);

            score = 0;
        }

        private void NewGameButton(int row, int column)
        {
            Random random = new Random();

            //1 in 10 chance of activated button being 4, 90% chance of 2
            if (random.Next(0, 10) == 0)
            {
                GameBoard[row, column] = 4;
            }
            else
            {
                GameBoard[row, column] = 2;
            }
        }
    }
}
