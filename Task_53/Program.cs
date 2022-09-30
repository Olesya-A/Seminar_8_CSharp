// 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

int row = EnterInt("Enter row: ");
int col = EnterInt("Enter column: ");
int[,] numbers = new int[row, col];

Fill2DArray(numbers);
Print2DArray(numbers);

Console.WriteLine();

Changed2DArray(numbers);
Print2DArray(numbers);

int EnterInt(string prompt)
{
    Console.Write(prompt);
    return int.Parse(Console.ReadLine()!);
}

void Fill2DArray(int[,] numbers)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            numbers[i, j] = new Random().Next(1, 11);
        }
    }
}

void Print2DArray(int[,] numbers)
{
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            Console.Write($"{numbers[i, j],2} ");
        }
        Console.WriteLine();
    }
}

// void Swap(int a, int b)
// {
//     int temp = a;
//     a = b;
//     b = temp;
// }

void Changed2DArray(int[,] numbers)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        (numbers[0, j], numbers[numbers.GetLength(0) - 1, j]) = (numbers[numbers.GetLength(0) - 1, j], numbers[0, j]);
    }
}