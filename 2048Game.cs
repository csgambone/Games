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

        private void SpawnNumber()
        {
            int[,] emptyCoords = new int[14, 2];
            int count = 0;
            int selection;
            Random random = new Random();

            //spawn 10% 4, 90% 2 in empty slot
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (GameBoard[i,j] == 0)
                    {
                        emptyCoords[count, 0] = i;
                        emptyCoords[count, 1] = j;
                        count++;
                    }
                }
            }
            if (count != 0)
            {
                selection = random.Next(0, count);
                NewGameButton(emptyCoords[selection, 0], emptyCoords[selection, 1]);
            }
            else
            {
                //Game Over
            }
        }

        //Movement methods
        public void MoveLeft()
        {
            //Loop through rows from 0 to 3
            for (int i = 0; i < 4; i++)
            {
                //Loop through columns within row
                for (int j = 0; j < 4; j++)
                {
                    for (int k = j; k > 0; k--)
                    {
                        //check column for equal, if equal sum in check column, clear current column
                        if (GameBoard[i, k] == GameBoard[i, k - 1])
                        {
                            //destination x2, current = 0
                            GameBoard[i, k - 1] = GameBoard[i, k - 1] * 2;
                            GameBoard[i, k] = 0;
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (GameBoard[i, k - 1] == 0)
                        {
                            //destination = current, current = 0
                            GameBoard[i, k - 1] = GameBoard[i, k];
                            GameBoard[i, k] = 0;
                        }
                    }
                }
            }
            //Spawn new number
            SpawnNumber();
        }

        public void MoveRight()
        {
            //Loop through rows from 0 to 3
            for (int i = 0; i < 4; i++)
            {
                //Loop through columns within row
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = 0; k < j; k++)
                    {
                        //check column for equal, if equal sum in check column, clear current column
                        if (GameBoard[i, k] == GameBoard[i, k + 1])
                        {
                            //destination x2, current = 0
                            GameBoard[i, k + 1] = GameBoard[i, k + 1] * 2;
                            GameBoard[i, k] = 0;
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (GameBoard[i, k + 1] == 0)
                        {
                            //destination = current, current = 0
                            GameBoard[i, k + 1] = GameBoard[i, k];
                            GameBoard[i, k] = 0;
                        }
                    }
                }
            }
            //Spawn new number
            SpawnNumber();
        }

        public void MoveUp()
        {
            //Loop through columns from 0 to 3
            for (int j = 0; j < 4; j++)
            {
                //Loop through rows within column
                for (int i = 0; i < 4; i++)
                {
                    for (int k = i; k > 0; k--)
                    {
                        //check column for equal, if equal sum in check column, clear current column
                        if (GameBoard[k, j] == GameBoard[k - 1, j])
                        {
                            //destination x2, current = 0
                            GameBoard[k - 1, j] = GameBoard[k - 1, j] * 2;
                            GameBoard[k, j] = 0;
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (GameBoard[k - 1, j] == 0)
                        {
                            //destination = current, current = 0
                            GameBoard[k - 1, j] = GameBoard[k, j];
                            GameBoard[k, j] = 0;
                        }
                    }
                }
            }
            //Spawn new number
            SpawnNumber();
        }

        public void MoveDown()
        {
            //Loop through columns from 0 to 3
            for (int j = 0; j < 4; j++)
            {
                //Loop through rows within column
                for (int i = 3; i >= 0; i--)
                {
                    for (int k = 0; k < i; k++)
                    {
                        //check column for equal, if equal sum in check column, clear current column
                        if (GameBoard[k, j] == GameBoard[k + 1, j])
                        {
                            //destination x2, current = 0
                            GameBoard[k + 1, j] = GameBoard[k + 1, j] * 2;
                            GameBoard[k, j] = 0;
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (GameBoard[k + 1, j] == 0)
                        {
                            //destination = current, current = 0
                            GameBoard[k + 1, j] = GameBoard[k, j];
                            GameBoard[k, j] = 0;
                        }
                    }
                }
            }
            //Spawn new number
            SpawnNumber();
        }
    }
}
