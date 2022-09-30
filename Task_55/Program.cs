// 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
// В случае, если это невозможно, программа должна вывести сообщение для пользователя.

int row = EnterInt("Enter row: ");
int col = EnterInt("Enter column: ");
int[,] numbers = new int[row, col];

Fill2DArray(numbers);
Print2DArray(numbers);

Console.WriteLine();

ChangedRowsColumns(numbers);
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

bool IsPossible(int[,] numbers)
{
    return numbers.GetLength(0) == numbers.GetLength(1) || numbers.GetLength(0) == numbers.GetLength(1);
}


void ChangedRowsColumns(int[,] numbers)
{
    if (IsPossible(numbers))
    {
        // int[,] numbersNew = new int[numbers.GetLength(0), numbers.GetLength(1)];
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            for (int j = i; j < numbers.GetLength(1); j++)
            {
                Swap(ref numbers[i, j], ref numbers[j,i]);
            }
        }
        // numbers[i, j] = numbersNew[i, j];
    }
    else Console.WriteLine("Заменить строки на столбцы невозможно.");
}

void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}