// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class Program
{
    /// <summary>
    ///     Ввод числа типа <see cref="T:System.Int32" />
    /// </summary>
    private static void ReadInt(out int intNum)
    {
        bool isConvert;
        do
        {
            isConvert = int.TryParse(Console.ReadLine(), out intNum);
            if (!isConvert)
                Console.Write("ОШИБКА! Введено нецелое число!\nВведите заново: ");
        } while (!isConvert);
    }

    private static void Main()
    {
        // Тип значений, допускающий значение NULL, или T?,
        // представляет все значения своего базового типа значения T,
        // а также дополнительное значение NULL
        Generate(out int[,]? arr, 7, 7);
        Write(arr);
        Console.WriteLine();
        arr = arr.DeleteColumnContainsZero();
        Write(arr);
    }

    #region Одномерный массив

    /// <summary>
    ///     Ручной ввод элементов массива
    /// </summary>
    /// <param name="arrayInts">Выходной массив <see cref="T:System.Int32" /> значений</param>
    /// <param name="size">Размер массива</param>
    private static void Read(out int[] arrayInts, uint size)
    {
        arrayInts = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"Введите элемент №{i + 1}: ");
            ReadInt(out arrayInts[i]);
        }

        Console.WriteLine("Массив успешно сформирован");
        if (size == 0)
            Console.WriteLine("Массив не содержит элементов");
    }

    /// <summary>
    ///     Генерация массива
    ///     <see cref="T:System.Int32" />
    ///     значений размером sizeArray
    ///     с помощью датчика случайных чисел.
    /// </summary>
    private static void Generate(out int[] arrayInts, uint sizeArray)
    {
        arrayInts = new int[sizeArray];

        Random generator = new();
        for (int i = 0; i < sizeArray; i++)
            arrayInts[i] = generator.Next(-100, 101);

        Console.WriteLine("Массив успешно сформирован");
        if (sizeArray == 0)
            Console.WriteLine("Массив не содержит элементов");
    }

    /// <summary>
    ///     Вывод массива <see cref="T:System.Int32" /> значений в консоль.
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    private static void Write(int[] arrayInts)
    {
        if (arrayInts.Length > 0)
        {
            foreach (int variable in arrayInts)
                Console.Write(variable + " ");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Массив не содержит элементов");
        }
    }

    /// <summary>
    ///     Вставляет число типа <see cref="T:System.Int32" /> в массив <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    /// <param name="elem">Вставляемое число</param>
    /// <param name="index">Индекс в массиве для вставляемого числа (по умолчанию – 0)</param>
    private static int[] Append(this int[] arrayInts, int elem, int index = 0)
    {
        Array.Resize(ref arrayInts, arrayInts.Length + 1);
        Array.Copy(arrayInts, index,
                   arrayInts, index + 1,
                   arrayInts.Length - index - 1);
        arrayInts[index] = elem;
        return arrayInts;
    }

    /// <summary>
    ///     Вставляет массив чисел типа <see cref="T:System.Int32" /> в массив <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="arrayInts">Исходный массив</param>
    /// <param name="arrayIntsAdd">Дополнительный массив</param>
    /// <param name="index">Индекс, на место которого начинать вставлять массив (по умолчанию – 0)</param>
    private static int[] Append(this int[] arrayInts, int[] arrayIntsAdd, int index = 0)
    {
        foreach (int element in arrayIntsAdd)
            arrayInts = arrayInts.Append(element, index);
        return arrayInts;
    }

    #endregion

    #region Двумерный массив

    /// <summary>
    ///     Ручной ввод элементов двумерного массива
    /// </summary>
    /// <param name="matrInts">Выходной двумерный массив <see cref="T:System.Int32" /> значений</param>
    /// <param name="sizeRow">Количество строк двумерного массива</param>
    /// <param name="sizeColumn">Количество столбцов двумерного массива</param>
    private static void Read(out int[,] matrInts, uint sizeRow, uint sizeColumn)
    {
        matrInts = new int[sizeRow, sizeColumn];
        for (int i = 0; i < sizeRow; i++)
            for (int j = 0; j < sizeColumn; j++)
            {
                Console.Write($"Введите элемент в ячейке [{i + 1}, {j + 1}]: ");
                ReadInt(out matrInts[i, j]);
            }

        Console.WriteLine("Матрица успешно сформирована");
        if (matrInts.Length == 0)
            Console.WriteLine("Матрица не содержит элементов");
    }

    /// <summary>
    ///     Генерация двумерного массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел.
    /// </summary>
    /// <param name="matrInts">Двумерный массив</param>
    /// <param name="sizeRow">Количество строк двумерного массива</param>
    /// <param name="sizeColumn">Количество столбцов двумерного массива</param>
    private static void Generate(out int[,] matrInts, uint sizeRow, uint sizeColumn)
    {
        matrInts = new int[sizeRow, sizeColumn];

        Random generator = new();
        for (int i = 0; i < sizeRow; i++)
            for (int j = 0; j < sizeColumn; j++)
                matrInts[i, j] = generator.Next(-2, 2);

        Console.WriteLine("Матрица успешно сформирована");
        if (matrInts.Length == 0)
            Console.WriteLine("Матрица не содержит элементов");
    }

    /// <summary>
    ///     Вывод двумерного массива <see cref="T:System.Int32" /> значений в консоль.
    /// </summary>
    /// <param name="matrInts">Двумерный массив</param>
    private static void Write(int[,] matrInts)
    {
        if (matrInts.Length > 0)
            for (int i = 0; i < matrInts.GetLength(0); i++)
            {
                for (int j = 0; j < matrInts.GetLength(1); j++)
                    Console.Write($"{matrInts[i, j],4} ");

                Console.WriteLine();
            }
        else
            Console.WriteLine("Массив не содержит элементов");
    }

    /// <summary>
    ///     Удаляет из двумерного массива <see cref="T:System.Int32" /> значений
    ///     столбец с заданным индексом
    /// </summary>
    /// <param name="matrInts">Двумерный массив</param>
    /// <param name="indexColumn">Индекс удаляемого столбца</param>
    private static int[,] DeleteColumn(this int[,] matrInts, int indexColumn)
    {
        int[,] resMatrInts = new int[matrInts.GetLength(0), matrInts.GetLength(1) - 1];
        for (int j = 0; j < matrInts.GetLength(1); j++)
            if (j < indexColumn)
                for (int i = 0; i < matrInts.GetLength(0); i++)
                    resMatrInts[i, j] = matrInts[i, j];
            else if (j > indexColumn)
                for (int i = 0; i < matrInts.GetLength(0); i++)
                    resMatrInts[i, j - 1] = matrInts[i, j];
        return resMatrInts;
    }

    /// <summary>
    ///     Удаляет из двумерного массива <see cref="T:System.Int32" /> значений
    ///     все столбцы, содержащие хотя бы один 0
    /// </summary>
    /// <param name="matrInts">Двумерный массив</param>
    private static int[,] DeleteColumnContainsZero(this int[,] matrInts)
    {
        for (int j = 0; j < matrInts.GetLength(1); j++)
            for (int i = 0; i < matrInts.GetLength(0); i++)
            {
                if (j >= matrInts.GetLength(1) || matrInts[i, j] != 0)
                    continue;
                matrInts = matrInts.DeleteColumn(j);

                // Приравниваем -1, так как в цикле for призойдет инкремент на 1,
                // а нужно проверять с элемента с индексом 0
                i = -1;
            }

        return matrInts;
    }

    #endregion
}