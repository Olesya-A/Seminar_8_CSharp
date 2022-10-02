// 59: Задайте двумерный массив из целых чисел. 
// Напишите программу, которая удалит строку и столбец, 
// на пересечении которых расположен наименьший элемент массива.
//
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7


int row = EnterInt("Enter row: ");
int col = EnterInt("Enter column: ");
int[,] numbers = new int[row, col];

Fill2DArray(numbers);
Print2DArray(numbers);

Console.WriteLine();

int[,] indexMin = FindIndexOfMinElement(numbers);
Console.Write("Индекс минимального элемента равен: ");
Print2DArray(indexMin);

int[,] arrayWithoutLines = DeleteRowColumnMinElem(numbers, indexMin);
Print2DArray(arrayWithoutLines);


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

int[,] FindIndexOfMinElement(int[,] numbers)
{
    int min = numbers[0, 0];
    int[,] indexMin = new int[1, 2];
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if (numbers[i, j] < min)
            {
                min = numbers[i, j];
                indexMin[0, 0] = i;
                indexMin[0, 1] = j;
            }
        }
    }
    return indexMin;
}

int[,] DeleteRowColumnMinElem(int[,] numbers, int[,] indexMin)
{
    int[,] arrayWithoutLines = new int[numbers.GetLength(0) - 1, numbers.GetLength(1) - 1];
    int k = 0, l = 0;

    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if (indexMin[0, 0] != i && indexMin[0, 1] != j)
            {
                arrayWithoutLines[k, l] = numbers[i, j];
                l++;
            }
        }
        l = 0;
        if (indexMin[0, 0] != i)
            k++;
    }
    return arrayWithoutLines; 
}