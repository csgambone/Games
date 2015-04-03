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
        public bool active = false;
        public bool gameOver = false;
        public bool win = false;

        public void NewGame()
        {
            Random random = new Random();
            gameOver = false;
            score = 0;

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
            int[,] emptyCoords = new int[16, 2];
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

            //Check for win
            if (win == true)
            {
                active = false;
                gameOver = true;
            }
            else if (count != 0)
            {
                selection = random.Next(0, count);
                NewGameButton(emptyCoords[selection, 0], emptyCoords[selection, 1]);
            }
            else
            {
                //Check for Game Over
                if (GameOver() == true)
                {
                    active = false;
                    gameOver = true;
                }
            }
        }

        private bool GameOver()
        {
            bool gameOver = true;

            for (int i = 0; i <= 3; i++)
            {
                if (LookAhead(i) == true) {
                    gameOver = false;
                }
            }

            return gameOver;
        }

        //0 = right, 1 = down, 2 = left, 3 = up
        private bool LookAhead(int direction)
        {
            int[,] lookAheadBoard = new int[4, 4];
            //int[,] lookAheadBoard = GameBoard;
            /*
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    lookAheadBoard[i, j] = GameBoard[i, j];
                }
            }*/

            Array.Copy(GameBoard, lookAheadBoard, GameBoard.Length);

            bool canMove = false;

            switch (direction)
            {
                case 0:
                    lookAheadBoard = MoveRight(lookAheadBoard, true);
                    break;
                case 1:
                    lookAheadBoard = MoveDown(lookAheadBoard, true);
                    break;
                case 2:
                    lookAheadBoard = MoveLeft(lookAheadBoard, true);
                    break;
                case 3:
                    lookAheadBoard = MoveUp(lookAheadBoard, true);
                    break;
                default:
                    Console.WriteLine("Invalid input to _2048Game.LookAhead()");
                    break;
            }

            //bool equal = (lookAheadBoard.Rank == GameBoard.Rank) && (Enumerable.Range(0, lookAheadBoard.Rank).All(dimension => lookAheadBoard.GetLength(dimension) == GameBoard.GetLength(dimension))) && (lookAheadBoard.Cast<int>().SequenceEqual(GameBoard.Cast<int>()));

            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (lookAheadBoard[i, j] != GameBoard[i, j])
                    {
                        canMove = true;
                    }
                }
            }

            /*
            if (equal)
            {
                canMove = false;
            }
            */

            return canMove;
        }

        //Movement methods
        public int[,] MoveLeft(int[,] Board, bool LookAhead = false)
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
                        if (Board[i, k] == Board[i, k - 1])
                        {
                            //destination x2, current = 0
                            Board[i, k - 1] = Board[i, k - 1] * 2;
                            Board[i, k] = 0;
                            if (LookAhead == false)
                            {
                                //add destroyed tile value to score
                                score += Board[i, k - 1];
                                //if destroyed tile is half of win value, win value was created, set win=true
                                if (Board[i, k - 1] == 2048)
                                {
                                    win = true;
                                }
                            }
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (Board[i, k - 1] == 0)
                        {
                            //destination = current, current = 0
                            Board[i, k - 1] = Board[i, k];
                            Board[i, k] = 0;
                        }
                    }
                }
            }
            if (LookAhead == false)
            {
                //Spawn new number
                SpawnNumber();
            }
            return Board;
        }

        public int[,] MoveRight(int[,] Board, bool LookAhead = false)
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
                        if (Board[i, k] == Board[i, k + 1])
                        {
                            //destination x2, current = 0
                            Board[i, k + 1] = Board[i, k + 1] * 2;
                            Board[i, k] = 0;
                            if (LookAhead == false)
                            {
                                //add destroyed tile value to score
                                score += Board[i, k + 1];
                                //if destroyed tile is half of win value, win value was created, set win=true
                                if (Board[i, k + 1] == 2048)
                                {
                                    win = true;
                                }
                            }
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (Board[i, k + 1] == 0)
                        {
                            //destination = current, current = 0
                            Board[i, k + 1] = Board[i, k];
                            Board[i, k] = 0;
                        }
                    }
                }
            }
            if (LookAhead == false)
            {
                //Spawn new number
                SpawnNumber();
            }
            return Board;
        }

        public int[,] MoveUp(int[,] Board, bool LookAhead = false)
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
                        if (Board[k, j] == Board[k - 1, j])
                        {
                            //destination x2, current = 0
                            Board[k - 1, j] = Board[k - 1, j] * 2;
                            Board[k, j] = 0;
                            if (LookAhead == false)
                            {
                                //add destroyed tile value to score
                                score += Board[k - 1, j];
                                //if destroyed tile is half of win value, win value was created, set win=true
                                if (Board[k - 1, j] == 32)
                                {
                                    win = true;
                                }
                            }
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (Board[k - 1, j] == 0)
                        {
                            //destination = current, current = 0
                            Board[k - 1, j] = Board[k, j];
                            Board[k, j] = 0;
                        }
                    }
                }
            }
            if (LookAhead == false)
            {
                //Spawn new number
                SpawnNumber();
            }
            return Board;
        }

        public int[,] MoveDown(int[,] Board, bool LookAhead = false)
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
                        if (Board[k, j] == Board[k + 1, j])
                        {
                            //destination x2, current = 0
                            Board[k + 1, j] = Board[k + 1, j] * 2;
                            Board[k, j] = 0;
                            if (LookAhead == false)
                            {
                                //add destroyed tile value to score
                                score += Board[k + 1, j];
                                //if destroyed tile is half of win value, win value was created, set win=true
                                if (Board[k + 1, j] == 2048)
                                {
                                    win = true;
                                }
                            }
                        }
                        //if any possible destination from 0 column to current column-1 is 0, move there in that order of priority
                        else if (Board[k + 1, j] == 0)
                        {
                            //destination = current, current = 0
                            Board[k + 1, j] = Board[k, j];
                            Board[k, j] = 0;
                        }
                    }
                }
            }
            if (LookAhead == false)
            {
                //Spawn new number
                SpawnNumber();
            }
            return Board;
        }
    }
}
