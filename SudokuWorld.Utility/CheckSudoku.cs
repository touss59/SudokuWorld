using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuWorld.Utility
{
    public static class CheckSudoku
    {
        // Convert the string into an array 9x9
        public static int[,] ConvertGridToArray(string value)
        {
            int[,] grid = new int[9, 9];
            int position = 0;
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y]= (int)char.GetNumericValue(value[position]);
                    position++;
                }
            }
            return grid;
        }
        // Methods to Get CorrectionsGrid or Verifications
        public static bool IsPossible(int x, int y, int n, int[,] grid)
        {
            for(var i = 0; i < 9; i++)
            {
                if (grid[x, i] == n)
                {
                    return false;
                }
            }

            for (var j = 0; j < 9; j++)
            {
                if (grid[j, y] == n)
                {
                    return false;
                }
            }

            int xo = x / 3;
            xo *= 3;
            int yo =y / 3;
            yo *= 3;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (grid[xo + i,yo + j] == n)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public static bool ContainZero(int[,] grid)
        {
            foreach(var i in grid)
            {
                if (i == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static void PreSolve(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 0)
                    {
                        for(var n = 1; n < 10; n++)
                        {
                            if (IsPossible(i, j, n, grid))
                            {
                                grid[i, j] = n;
                                PreSolve(grid);
                                if (!ContainZero(grid))
                                {
                                    return;
                                }
                                grid[i, j] = 0;
                            }
                        }
                        return;
             
                    }
                }
            }
        }
        public static string Solve(string value)
        {
            string result = "";
            int[,] grid = ConvertGridToArray(value);
            PreSolve(grid);
            foreach(var i in grid)
            {
                result += i;
            }
            return result;
        }

        public static string GetErrors(string result, string anwser)
        {
            string errors = "";
            for(int i=0; i < result.Length; i++)
            {
                if (result[i] != anwser[i])
                {
                    errors += i+",";
                }
            }
            errors = errors.Remove(errors.Length - 1);
            return errors;
        }
    }    
}
