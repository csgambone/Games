using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    class FlippyGame
    {
        public int[,] GameBoard = new int[13, 15];
        public bool centers;
        public int moves = 0;

        public void NewGame(bool centersSelect)
        {
            Random random = new Random();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    GameBoard[i,j] = random.Next(0, 2);

                    //unflippable space, 4% chance
                    if (random.Next(0, 21) == 20)
                    {
                        GameBoard[i, j] = 2;
                    }
                }
            }

            centers = centersSelect;
            moves = 0;
        }

        public void SwapColor(int row, int column)
        {
            if (centers)
            {
                SwapButton(row, column);
            }
            if (row < 12)
            {
                SwapButton(row + 1, column);
            }
            if (column < 14)
            {
                SwapButton(row, column + 1);
            }
            if (row > 0)
            {
                SwapButton(row - 1, column);
            }
            if (column > 0)
            {
                SwapButton(row, column - 1);
            }

        }

        private void SwapButton(int row, int column)
        {
            if (GameBoard[row, column] == 1)
            {
                GameBoard[row, column] = 0;
            }
            else if (GameBoard[row, column] == 0)
            {
                GameBoard[row, column] = 1;
            }
        }
    }
}
