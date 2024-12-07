using System;
using System.Linq;

public class MathOperations
{
    // Перевантаження Add: робота з числами
    public int Add(int a, int b) => a + b;
    public double Add(double a, double b) => a + b;

    // Перевантаження Add: робота з масивами чисел
    public int Add(int[] array) => array.Sum();
    public double Add(double[] array) => array.Sum();

    // Перевантаження Add: робота з матрицями
    public int[,] Add(int[,] matrix1, int[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Розміри матриць повинні співпадати.");

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix1[i, j] + matrix2[i, j];

        return result;
    }

    // Метод Subtract: робота з числами
    public int Subtract(int a, int b) => a - b;
    public double Subtract(double a, double b) => a - b;

    // Метод Subtract: робота з матрицями
    public int[,] Subtract(int[,] matrix1, int[,] matrix2)
    {
        if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            throw new ArgumentException("Розміри матриць повинні співпадати.");

        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix1[i, j] - matrix2[i, j];

        return result;
    }

    // Перевантаження Multiply: робота з числами
    public int Multiply(int a, int b) => a * b;
    public double Multiply(double a, double b) => a * b;

    // Перевантаження Multiply: робота з матрицями
    public int[,] Multiply(int[,] matrix1, int[,] matrix2)
    {
        if (matrix1.GetLength(1) != matrix2.GetLength(0))
            throw new ArgumentException("Кількість стовпців першої матриці повинна дорівнювати кількості рядків другої.");

        int rows = matrix1.GetLength(0);
        int cols = matrix2.GetLength(1);
        int commonDim = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                for (int k = 0; k < commonDim; k++)
                    result[i, j] += matrix1[i, k] * matrix2[k, j];

        return result;
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        var mathOps = new MathOperations();

        // Тест: числа
        Console.WriteLine($"Add(3, 5): {mathOps.Add(3, 5)}");
        Console.WriteLine($"Subtract(10, 3): {mathOps.Subtract(10, 3)}");
        Console.WriteLine($"Multiply(4, 6): {mathOps.Multiply(4, 6)}");

        // Тест: масиви
        int[] array = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Add(array): {mathOps.Add(array)}");

        // Тест: матриці
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

        Console.WriteLine("Add(matrix1, matrix2):");
        var sumMatrix = mathOps.Add(matrix1, matrix2);
        PrintMatrix(sumMatrix);

        Console.WriteLine("Subtract(matrix1, matrix2):");
        var subMatrix = mathOps.Subtract(matrix1, matrix2);
        PrintMatrix(subMatrix);

        Console.WriteLine("Multiply(matrix1, matrix2):");
        var mulMatrix = mathOps.Multiply(matrix1, matrix2);
        PrintMatrix(mulMatrix);
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i, j]} ");
            Console.WriteLine();
        }
    }
}
