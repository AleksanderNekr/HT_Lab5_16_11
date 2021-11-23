// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class Program
{
    private static void Main()
    {
        // Тип значений, допускающий значение NULL, или T?,
        // представляет все значения своего базового типа значения T,
        // а также дополнительное значение NULL
        GenerateArray(out int[,]? arr);
        WriteArray(arr);
        Console.WriteLine();
        arr = arr.DeleteColumnsContainZero();
        WriteArray(arr);
        GenerateArray(out int[][] jaggedArr);
        WriteArray(jaggedArr);
        Console.WriteLine();
        int[] newArr = { 1, 2, 3, 4 };
        jaggedArr = jaggedArr.Append(newArr, 4);
        WriteArray(jaggedArr);
    }

    #region Дополнительные функции

    /// <summary>
    ///     Ввод числа типа <see cref="T:System.Int32" />
    /// </summary>
    private static void ReadInt(out int intNum, string message = "Введите целое число: ")
    {
        Console.Write(message);
        bool isConvert;
        do
        {
            isConvert = int.TryParse(Console.ReadLine(), out intNum);
            if (!isConvert)
                Console.Write("ОШИБКА! Введено нецелое число!\nВведите заново: ");
        } while (!isConvert);
    }

    /// <summary>
    ///     Ввод числа типа <see cref="T:System.UInt32" />
    /// </summary>
    /// <param name="uintNum">Число</param>
    /// <param name="message">Необязательное сообщение при вводе</param>
    private static void ReadUint(out uint uintNum, string message = "Введите целое неотрицательное число: ")
    {
        Console.Write(message);
        bool isConvert;
        do
        {
            isConvert = uint.TryParse(Console.ReadLine(), out uintNum);
            if (!isConvert)
                Console.Write("ОШИБКА! Введено нецелое число," +
                              " или отрицательное, "           +
                              "или не число!\nВведите заново: ");
        } while (!isConvert);
    }


    /// <summary>
    ///     Вывод сообщений после формирования массивов или матриц
    /// </summary>
    /// <param name="param">Параметр, отвечающий за размер массива или матрицы</param>
    /// <param name="msgSuccess">Сообщение об успешном формировании (необязательно)</param>
    /// <param name="msgEmpty">Сообщение о том, что массив или матрица пусты (необязательно)</param>
    private static void FinalMessage(int    param,
                                     string msgSuccess = "Массив успешно сформирован",
                                     string msgEmpty   = "Массив не содержит элементов")
    {
        Console.WriteLine(msgSuccess);
        if (param == 0)
            Console.WriteLine(msgEmpty);
    }

    /// <summary>
    ///     Вывод сообщений после формирования массивов или матриц
    /// </summary>
    /// <param name="param">Параметр, отвечающий за размер массива или матрицы</param>
    /// <param name="msgSuccess">Сообщение об успешном формировании (необязательно)</param>
    /// <param name="msgEmpty">Сообщение о том, что массив или матрица пусты (необязательно)</param>
    private static void FinalMessage(uint   param,
                                     string msgSuccess = "Массив успешно сформирован",
                                     string msgEmpty   = "Массив не содержит элементов")
    {
        Console.WriteLine(msgSuccess);
        if (param == 0)
            Console.WriteLine(msgEmpty);
    }

    #endregion

    #region Одномерный массив

    private const string InpMsg = "Введите целое неотрицательное число – размер массива: ";

    /// <summary>
    ///     Ручной ввод элементов массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[] arrayInts)
    {
        ReadUint(out uint sizeArray, InpMsg);
        arrayInts = new int[sizeArray];

        for (int i = 0; i < sizeArray; i++)
            ReadInt(out arrayInts[i], $"Введите {i + 1} элемент: ");

        FinalMessage(sizeArray);
    }

    /// <summary>
    ///     Генерация массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[] arrayInts)
    {
        ReadUint(out uint sizeArray, InpMsg);
        arrayInts = new int[sizeArray];
        Random generator = new();

        for (int i = 0; i < sizeArray; i++)
            arrayInts[i] = generator.Next(-100, 101);

        FinalMessage(sizeArray);
    }

    /// <summary>
    ///     Вывод массива <see cref="T:System.Int32" /> значений в консоль
    /// </summary>
    private static void WriteArray(int[] arrayInts)
    {
        if (arrayInts.Length > 0)
        {
            foreach (int variable in arrayInts)
                Console.Write($"{variable,5}");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Массив не содержит элементов");
        }
    }

    /// <summary>
    ///     Вставляет число типа <see cref="T:System.Int32" /> в массив
    ///     <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    /// <param name="element">Вставляемое число</param>
    /// <param name="index">Индекс в массиве для вставляемого числа</param>
    private static int[] Append(this int[] arrayInts, int element, int index)
    {
        Array.Resize(ref arrayInts, arrayInts.Length + 1);
        Array.Copy(arrayInts, index,
                   arrayInts, index + 1,
                   arrayInts.Length - index - 1);
        arrayInts[index] = element;

        return arrayInts;
    }

    /// <summary>
    ///     Вставляет массив чисел типа <see cref="T:System.Int32" />
    ///     в массив <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="arrayInts">Исходный массив</param>
    /// <param name="arrayIntsAdd">Дополнительный массив</param>
    /// <param name="index">
    ///     Индекс, на место которого начинать вставлять массив
    ///     (по умолчанию – 0)
    /// </param>
    private static int[] Append(this int[] arrayInts, int[] arrayIntsAdd, int index = 0)
    {
        foreach (int element in arrayIntsAdd)
            arrayInts = arrayInts.Append(element, index);

        return arrayInts;
    }

    #endregion

    #region Двумерный массив

    private const string InpMsgSizeRow     = "Введите целое неотрицательное число – количество строк матрицы: ";
    private const string InpMsgSizeColumn  = "Введите целое неотрицательное число – количество столбцов матрицы: ";
    private const string OutMsgMatrSuccess = "Матрица успешно сформирована";
    private const string OutMsgMatrEmpty   = "Матрица не содержит элементов";

    /// <summary>
    ///     Ручной ввод элементов двумерного массива
    ///     <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[,] matrInts)
    {
        ReadUint(out uint sizeRow,    InpMsgSizeRow);
        ReadUint(out uint sizeColumn, InpMsgSizeColumn);
        matrInts = new int[sizeRow, sizeColumn];

        for (int i = 0; i < sizeRow; i++)
            for (int j = 0; j < sizeColumn; j++)
                ReadInt(out matrInts[i, j],
                        "Введите целое число – элемент" +
                        $" в [{i + 1}, {j + 1}] ячейке: ");

        FinalMessage(matrInts.Length, OutMsgMatrSuccess, OutMsgMatrEmpty);
    }

    /// <summary>
    ///     Генерация двумерного массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[,] matrInts)
    {
        ReadUint(out uint sizeRow,    InpMsgSizeRow);
        ReadUint(out uint sizeColumn, InpMsgSizeColumn);
        matrInts = new int[sizeRow, sizeColumn];

        Random generator = new();
        for (int i = 0; i < sizeRow; i++)
            for (int j = 0; j < sizeColumn; j++)
                matrInts[i, j] = generator.Next(-100, 101);

        FinalMessage(matrInts.Length, OutMsgMatrSuccess, OutMsgMatrEmpty);
    }

    /// <summary>
    ///     Вывод двумерного массива <see cref="T:System.Int32" /> значений в консоль
    /// </summary>
    private static void WriteArray(int[,] matrInts)
    {
        if (matrInts.Length > 0)
            for (int i = 0; i < matrInts.GetLength(0); i++)
            {
                for (int j = 0; j < matrInts.GetLength(1); j++)
                    Console.Write($"{matrInts[i, j],5}");
                Console.WriteLine();
            }
        else
            Console.WriteLine(OutMsgMatrEmpty);
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
    private static int[,] DeleteColumnsContainZero(this int[,] matrInts)
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

    #region Рваный массив

    private const string InpMsgCount = "Введите целое неотрицательное число" +
                                       " – количество ";

    /// <summary>
    ///     Ручной ввод элементов рваного массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[][] jaggedArrInts)
    {
        ReadUint(out uint sizeRow, $"{InpMsgCount}строк рваного массива: ");
        jaggedArrInts = new int[sizeRow][];

        for (int i = 0; i < sizeRow; i++)
        {
            ReadUint(out uint sizeColumn, $"{InpMsgCount}ячеек в {i + 1} строке: ");
            jaggedArrInts[i] = new int[sizeColumn];
            for (int j = 0; j < sizeColumn; j++)
                ReadInt(out jaggedArrInts[i][j],
                        $"Введите элемент – целое число в {j + 1} ячейку: ");
        }

        FinalMessage(jaggedArrInts.Length);
    }

    /// <summary>
    ///     Генерация элементов <see cref="T:System.Int32" /> значений
    ///     рваного массива с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[][] jaggedArrInts)
    {
        Random generator = new();
        ReadUint(out uint sizeRow, $"{InpMsgCount}строк рваного массива: ");

        jaggedArrInts = new int[sizeRow][];
        for (int i = 0; i < sizeRow; i++)
        {
            ReadUint(out uint sizeColumn, $"{InpMsgCount}ячеек в {i + 1} строке: ");
            jaggedArrInts[i] = new int[sizeColumn];
            for (int j = 0; j < sizeColumn; j++)
                jaggedArrInts[i][j] = generator.Next(-100, 101);
        }

        FinalMessage(jaggedArrInts.Length);
    }

    /// <summary>
    ///     Вывод рваного массива <see cref="T:System.Int32" /> значений в консоль
    /// </summary>
    private static void WriteArray(int[][] jaggedArrInts)
    {
        if (jaggedArrInts.Length > 0)
            foreach (int[] row in jaggedArrInts)
                WriteArray(row);
        else
            Console.WriteLine("Массив не содержит элементов");
    }

    /// <summary>
    ///     Добавляет в рваный массив одномерный массив чисел
    ///     <see cref="T:System.Int32" /> значений на место указанного индекса
    /// </summary>
    /// <param name="jaggedArrInts">Исходный рваный массив</param>
    /// <param name="addArrInts">Дополнительный одномерный массив</param>
    /// <param name="index">Индекс места вставки</param>
    /// <returns></returns>
    private static int[][] Append(this int[][] jaggedArrInts, int[] addArrInts, int index)
    {
        Array.Resize(ref jaggedArrInts, jaggedArrInts.Length + 1);
        Array.Copy(jaggedArrInts, index,
                   jaggedArrInts, index + 1,
                   jaggedArrInts.Length - index - 1);
        jaggedArrInts[index] = addArrInts;

        return jaggedArrInts;
    }

    #endregion
}