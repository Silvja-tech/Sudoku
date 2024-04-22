using System;
using System.Linq;

using System;
using System.Linq;

public class Sudoku
{
    private readonly int[][] sudokuData;

    public Sudoku(int[][] sudokuData)
    {
        this.sudokuData = sudokuData;
    }

    public static void Main()
    {
        Sudoku goodSudoku = new Sudoku([
        [7, 8, 4, 1, 5, 9, 3, 2, 6],
        [5, 3, 9, 6, 7, 2, 8, 4, 1],
        [6, 1, 2, 4, 3, 8, 7, 5, 9],

        [9, 2, 8, 7, 1, 5, 4, 6, 3],
        [3, 5, 7, 8, 4, 6, 1, 9, 2],
        [4, 6, 1, 9, 2, 3, 5, 8, 7],

        [8, 7, 6, 3, 9, 4, 2, 1, 5],
        [2, 4, 3, 5, 6, 1, 9, 7, 8],
        [1, 9, 5, 2, 8, 7, 6, 3, 4]
        ]);

        Console.WriteLine("Is valid? " + goodSudoku.IsValid());
    }

    public bool IsValid()
    {
        int size = sudokuData.GetLength(0);
        int littleSize = (int)Math.Sqrt(size);

        // Rows and columns 
        for (int i = 0; i < size; i++)
        {
            if (!IsValidGroup(sudokuData[i]) || !IsValidGroup(GetColumn(i)))
                return false;
        }

        // Little squares
        for (int i = 0; i < size; i += littleSize)
        {
            for (int j = 0; j < size; j += littleSize)
            {
                if (!IsValidGroup(GetLittleSquare(i, j, littleSize)))
                    return false;
            }
        }

        return true;
    }

    private int[] GetColumn(int columnIndex)
    {
        int size = sudokuData.GetLength(0);
        int[] column = new int[size];

        for (int i = 0; i < size; i++)
        {
            column[i] = sudokuData[i][columnIndex];
        }

        return column;
    }

    private int[] GetLittleSquare(int startRow, int startColumn, int littleSize)
    {
        int[] littleSquare = new int[littleSize * littleSize];
        int count = 0;

        for (int i = startRow; i < startRow + littleSize; i++)
        {
            for (int j = startColumn; j < startColumn + littleSize; j++)
            {
                littleSquare[count++] = sudokuData[i][j];
            }
        }

        return littleSquare;
    }

    private bool IsValidGroup(int[] group)
    {
        int size = group.Length;
        int[] sortedGroup = group.OrderBy(x => x).ToArray();

        for (int i = 0; i < size; i++)
        {
            if (sortedGroup[i] != i + 1)
                return false;
        }

        return true;
    }
}