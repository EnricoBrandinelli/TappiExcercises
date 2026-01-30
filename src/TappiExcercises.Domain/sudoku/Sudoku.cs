using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TappiExcercises.Domain.sudoku
{
    public class Sudoku
    {
        public bool CheckSubMatrix(int minr, int maxr, int minc, int maxc, int[,] matrix)
        {
            List<int> check = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for(int r = minr; r<= maxr; r++)
            {
                for(int c = minc; c<=maxc; c++)
                {
                    foreach(int i in check)
                    {
                        if (matrix[r,c] == i)
                        {
                            check.Remove(i);
                            break;
                        }
                    }
                }
            }

            if (check.Count == 0)
            {
                return true;
            }
            else
                return false;
        }

       
    }
}
