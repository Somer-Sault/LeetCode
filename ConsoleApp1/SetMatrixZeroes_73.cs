using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
  public static class SetMatrixZeroes_73
  {
    // O(M+N) Space
    // O(M*N) RT
    public static void SetZeroes(int[][] matrix)
    {
      var zero_rows = new HashSet<int>();
      var zero_cols = new HashSet<int>();

      int rows = matrix.Length;
      int cols = matrix[0].Length;

      for (int i = 0; i < rows; ++i)
        for (int j = 0; j < cols; ++j)
        {
          if (matrix[i][j] == 0)
          {
            if (!zero_rows.Contains(i))
              zero_rows.Add(i);

            if (!zero_cols.Contains(j))
              zero_cols.Add(j);
          }
        }


      foreach (int r in zero_rows)
        for (int c = 0; c < cols; c++)
          matrix[r][c] = 0;

      foreach (int c in zero_cols)
        for (int r = 0; r < rows; r++)
          matrix[r][c] = 0;

    }
  }
}
