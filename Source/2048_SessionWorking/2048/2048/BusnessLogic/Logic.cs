using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace _2048.BisnessLogic
{
    public class Logic
    {
        public static Random rand = new Random();
        public static int[,] matrix = new int[4, 4];
        public static bool isOver = false;
        public static int score = 0;

        public static int[,] InitializeMatrix()
        {
            int[,] matrix = new int[4, 4];
            int a1 = rand.Next(0, matrix.GetLength(0));
            int a2 = rand.Next(0, matrix.GetLength(1));

            int b1 = rand.Next(0, matrix.GetLength(0));
            int b2 = rand.Next(0, matrix.GetLength(1));


            if (a1 == b1 && a2 == b2)
            {
                while (a1 == b1 && a2 == b2)
                {
                    b1 = rand.Next(0, matrix.GetLength(0));
                    b2 = rand.Next(0, matrix.GetLength(1));
                }
            }
            int randomValue1 = GenerateNumber();
            int randomValue2 = GenerateNumber();

            matrix[a1, a2] = randomValue1;
            matrix[b1, b2] = randomValue2;

            //for (int x = 0; x < 4; x++)
            //{
            //    for (int y = 0; y < 4; y++)
            //    {
            //        if (matrix[x, y] != 0)
            //        {
            //            Console.Write(" " + matrix[x, y] + " ");
            //        }
            //    }
            //}
            Logic.matrix = matrix;
            return matrix;
        }

        public static int GenerateNumber()
        {
            int number = rand.Next(100);
            int equals;
            bool bigger = false;
            if (number > 20)
            {
                bigger = true;
            }
            else
            {
                bigger = false;
            }

            equals = (bigger) ? 2 : 4; //80 % is 2 , 20% is 4

            return equals;
        }

        public static bool hasWon()
        {
            if (score == 2048)
            {
                return true;
            }
            return false;
        }

        public static bool BoardUnchaned(int[,] current,int[,] changedMatrix)
        {
            bool isEqual = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(current[i,j]!=changedMatrix[i,j])
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (!isEqual)
                {
                    break;
                }
            }
            return isEqual;
        }

        public static bool CheckEmptySlots(int[,] matrix) {
            bool isEmpty = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        isEmpty = true;
                        break;
                    }
                }
                if (isEmpty)
                {
                    break;
                }
            }
            return isEmpty;
        }
        public static void PutNewNumberOnBoard(int [,] matrix)
        {
            int x = 0;
            int y = 0;
            do
            {
                x = rand.Next(0, matrix.GetLength(0));
                y = rand.Next(0, matrix.GetLength(1));
            } while (matrix[x, y] != 0);
            matrix[x, y] = GenerateNumber();
        }

        //public static void CheckEmpty()
        //{
        //    int x = rand.Next(0, matrix.GetLength(0));
        //    int y = rand.Next(0, matrix.GetLength(1));
        //    if (matrix[x, y] == 0)
        //    {
        //        matrix[x, y] = GenerateNumber();
        //    }
        //    else
        //    {
        //            int won = hasWon();
        //            if (won == 1)
        //            {
        //               //message congrats
        //            }
        //            isOver = CheckGameOver();
        //            if (isOver)
        //            {
        //                //game over
        //            }
        //            else //if can merge some cells
        //            {
        //                // CheckEmpty();
        //            }
        //    }
                
        //}

        private static bool CheckGameOver()
        {
            bool rows = CheckRows(matrix, 0);
            bool cols = CheckColumns(matrix,0);
            if (rows == false && cols == false) 
            {
                return true; //then there aren't any merges , so should game over
            }
            return false; // if return false then the game continues
        }

        private static bool CheckColumns(int[,] matrix, int cols)
        {
                for (int i = 0; i < 3; i++)
                {
                      if (matrix[i, cols] == matrix[i + 1, cols] && matrix[i, cols] != 0)
                        {
                            //cols = 4; // go out 
                            return true;
                      }

                }
                    
                //if (cols < 4)
                //{
                //    CheckColumns(matrix, cols + 1);
                //}
            return false;
        }

        private static bool CheckRows(int[,] matrix, int row)
        {
            
                for (int i = 0; i < 3; i++)
                {
                    
                        if (matrix[row, i] == matrix[row, i + 1] && matrix[row, i] != 0)
                        {
                            row = 5;
                            return true;
                        }
                    }
                    
                //if (row < 3)
                //{
                //    CheckRows(matrix, row + 1);
                //}
            return false;
        }


        //public static void Test()
        //{
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            if (matrix[i, j] != 0)
        //            {
        //                Console.Write(" " + matrix[i, j] + " ");
        //            }
        //        }
        //    }
        //}

        public static int[,] MoveDown(int[,] matrix)
        {
            int[,] copyMatrix = (int[,])matrix.Clone();
            int iScore = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (matrix[k, j] == 0)
                        {
                            continue;
                        }
                        else if (matrix[k, j] == matrix[i, j])
                        {
                            matrix[i, j] *= 2;
                            iScore += matrix[i, j];
                            matrix[k, j] = 0; 
                            break;
                        }
                        else
                        {
                            if (matrix[i, j] == 0 && matrix[k, j] != 0)
                            {
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = 0;
                                i++;
                                break;
                            }
                            else if (matrix[i, j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            
            if(BoardUnchaned(copyMatrix, matrix))
            {
                return matrix;
            }

            if (!CheckEmptySlots(matrix))
            {
                return matrix;
            }

            if(!CheckGameOver())
            {
                return matrix;
            }

            if (hasWon())
            {
                return matrix;
            }

            PutNewNumberOnBoard(matrix);

            // CheckEmpty();
            //Test();
            score += iScore;
            return matrix;
        }



        public static int[,] MoveUp(int[,] matrix)
        {
            int[,] copyMatrix = (int[,])matrix.Clone();
            int iScore = 0;
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int k = i + 1; k < 4; k++)
                    {
                        if (matrix[k, j] == 0)
                        {
                            continue;
                        }
                        else if (matrix[k, j] == matrix[i, j])
                        {
                            matrix[i, j] *= 2;
                            iScore += matrix[i, j];
                            matrix[k, j] = 0;
                            break;
                        }
                        else
                        {
                            if (matrix[i, j] == 0 && matrix[k, j] != 0)
                            {
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = 0;
                                i--;
                                break;
                            }
                            else if (matrix[i, j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (BoardUnchaned(copyMatrix, matrix))
            {
                return matrix;
            }

            if (!CheckEmptySlots(matrix))
            {
                return matrix;
            }

            if (!CheckGameOver())
            {
                return matrix;
            }

            if (hasWon())
            {
                return matrix;
            }

            PutNewNumberOnBoard(matrix);
            //CheckEmpty();
            //Test();
            score += iScore;
            return matrix;
        }

        public static int[,] MoveLeft(int[,] matrix)
        {
            int[,] copyMatrix = (int[,])matrix.Clone();
            int iScore = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (matrix[i, k] == 0)
                        {
                            continue;
                        }
                        else if (matrix[i, k] == matrix[i, j])
                        {
                            matrix[i, j] *= 2;
                            iScore += matrix[i, j];
                            matrix[i, k] = 0;
                            break;
                        }
                        else
                        {
                            if (matrix[i, j] == 0 && matrix[i, k] != 0)
                            {
                                matrix[i, j] = matrix[i, k];
                                matrix[i, k] = 0;
                                j--;
                                break;
                            }
                            else if (matrix[i, j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (BoardUnchaned(copyMatrix, matrix))
            {
                return matrix;
            }

            if (!CheckEmptySlots(matrix))
            {
                return matrix;
            }

            if (!CheckGameOver())
            {
                return matrix;
            }

            if (hasWon())
            {
                return matrix;
            }

            PutNewNumberOnBoard(matrix);
            // CheckEmpty();
            //Test();
            score += iScore;
            return matrix;
        }

        public static int[,] MoveRight(int[,] matrix)
        {
            int[,] copyMatrix = (int[,])matrix.Clone();
            int iScore = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (matrix[i,k] == 0)
                        {
                            continue;
                        }
                        else if (matrix[i,k] == matrix[i,j])
                        {
                            matrix[i,j] *= 2;
                            iScore += matrix[i,j];
                            matrix[i,k] = 0;
                            break;
                        }
                        else
                        {
                            if (matrix[i,j] == 0 && matrix[i,k] != 0)
                            {
                                matrix[i,j] = matrix[i,k];
                                matrix[i,k] = 0;
                                j++;
                                break;
                            }
                            else if (matrix[i,j] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if (BoardUnchaned(copyMatrix, matrix))
            {
                return matrix;
            }

            if (!CheckEmptySlots(matrix))
            {
                return matrix;
            }

            if (!CheckGameOver())
            {
                return matrix;
            }

            if (hasWon())
            {
                return matrix;
            }

            PutNewNumberOnBoard(matrix);
            //CheckEmpty();
            //Test();
            score += iScore;
            return matrix;
        }
    }
}