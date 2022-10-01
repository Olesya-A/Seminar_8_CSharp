// 57: Составить частотный словарь элементов двумерного массива. 
// Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.

int row = EnterInt("Enter row: ");
int col = EnterInt("Enter column: ");
int[,] numbers = new int[row, col];

Fill2DArray(numbers);
Print2DArray(numbers);

Console.WriteLine();

List<int> @checked = WhatElements(numbers);
ElementCounter(numbers, @checked);

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


List<int> WhatElements(int[,] numbers) // пробегается по матрице и вписывает в лист встречающиеся значения
{
    List<int> @checked = new List<int>();
    for (int i = 0; i < numbers.GetLength(0); i++)
    {
        for (int j = 0; j < numbers.GetLength(1); j++)
        {
            if (!@checked.Contains(numbers[i, j])) // если не содержится
            {
                @checked.Add(numbers[i, j]);
            }
        }
    }
    return @checked; // собака тут нужна для экранирования зарезервированного имени 
}


void ElementCounter(int[,] numbers, List<int> @checked) // теперь просим пройтись по матрице и сравнить с листом
{
    foreach (int element in @checked) // для каждого (уникального) элемента в листе
    {
        int counter = 0;
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            
            for (int j = 0; j < numbers.GetLength(1); j++)
            {
                if (element == numbers[i, j])
                {
                    counter++; // если встречаем элемент - плюсуем
                }
            }
        }
        Console.WriteLine($"Элементов, равных {element} в данной матрице: {counter}.");
    }
}  // O(n^3)




// МОЙ ВАРИАНТ РЕШЕНИЯ
// void FrequencyDictionaryOfArrayElements(int[,] numbers)
// {
//     int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//     for (int k = 0; k < array.Length; k++)
//     {
//         int count = 0;
//         for (int i = 0; i < numbers.GetLength(0); i++)
//         {
//             for (int j = 0; j < numbers.GetLength(1); j++)
//             {
//                 if (array[k] == numbers[i,j])
//                 {
//                     count++;
//                 }
//             }
//         }
//         Console.WriteLine($"{array[k]} встречается {count} раз");
//     }
// }