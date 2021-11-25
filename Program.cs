// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class Program
{
    private static void Main()
    {
        MainMenu();

//        // Тип значений, допускающий значение NULL, или T?,
//        // представляет все значения своего базового типа значения T,
//        // а также дополнительное значение NULL
//        GenerateArray(out int[,]? arr);
//        WriteArray(arr);
//        Console.WriteLine();
//        arr = arr.DeleteColumnsContainZero();
//        WriteArray(arr);
//        GenerateArray(out int[][] jaggedArr);
//        WriteArray(jaggedArr);
//        Console.WriteLine();
//        int[] newArr = { 1, 2, 3, 4 };
//        jaggedArr = jaggedArr.Append(newArr, 4);
//        WriteArray(jaggedArr);
    }

    #region Меню

    private static void MainMenu()
    {
        int[]   arr    = Array.Empty<int>();
        int[,]  matr   = new int[0, 0];
        int[][] jagArr = Array.Empty<int[]>();

        while (true)
        {
            Console.Write("Выберите, с каким из"                            +
                          " следующих видов массивов вы хотите работать:\n" +
                          "1. Одномерный массив\n2. Двумерный массив\n"     +
                          "3. Рваный массив\n4. Завершить выполнение"       +
                          " программы\n\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MenuArr(ref arr);
                    break;
                case "2":
//                    TODO
                    break;
                case "3":
//                    TODO
                    break;
                case "4":
                    Console.WriteLine("Завершение программы...");
                    return;
                default:
                    Console.WriteLine("Введен неизвестный символ! Введите заново");
                    break;
            }
        }
    }

    private static void MenuArr(ref int[] arrInts)
    {
        while (true)
        {
            Console.Write("\nВы выбрали работу с одномерными массивами\n" +
                          "Выберите, что сделать:\n1. Создать массив\n"   +
                          "2. Вывести массив на экран\n3. Добавить "      +
                          "элементы в начало и в конец массива\n"         +
                          "4. Вернуться в главное меню\n\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВы выбрали создать массив");
                    MenuCreateArr(ref arrInts);
                    break;
                case "2":
                    Console.WriteLine("\nВы выбрали вывести массив на экран");
                    WriteArray(arrInts);
                    break;
                case "3":
                    Console.WriteLine("\nВы выбрали добавить элементы" +
                                      " в начало и в конец массива");

                    int[] arrAdd = Array.Empty<int>();

                    Console.WriteLine("\nФормирование массива элементов," +
                                      " добавляемых в НАЧАЛО массива");
                    MenuCreateArr(ref arrAdd);
                    arrInts = arrInts.Append(arrAdd);

                    Console.WriteLine("\nФормирование массива элементов," +
                                      " добавляемых в КОНЕЦ массива");
                    MenuCreateArr(ref arrAdd);
                    arrInts = arrInts.Append(arrAdd, arrInts.Length);

                    Console.WriteLine("\nЭлементы успешно добавлены!");
                    break;
                case "4":
                    Console.WriteLine("\nВы выбрали вернуться в главное меню");
                    return;
                default:
                    Console.WriteLine("\nВведен неизвестный символ! Введите заново");
                    break;
            }
        }
    }

    // Используется ref для возможности возврата в предыдущее меню,
    // не перезаписывая массив
    private static void MenuCreateArr(ref int[] arrayInts, string msgInput = "")
    {
        while (true)
        {
            Console.Write("Выберите, что сделать:\n"             +
                          "1. Ввести элементы вручную\n"         +
                          "2. Сгенерировать элементы"            +
                          " с помощью датчика случайных чисел\n" +
                          "3. Вернуться в предыдущее меню\n\n"   +
                          "Ваш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Выбрано ввести элементы массива вручную");
                    ReadArray(out arrayInts);
                    return;
                case "2":
                    Console.WriteLine("Выбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out arrayInts);
                    return;
                case "3":
                    return;
                default:
                    Console.WriteLine("Введен неизвестный символ!" +
                                      " Введите заново");
                    break;
            }
        }
    }

    #endregion

    #region Литерные строки сообщений

    private const string InpMsgCountOf      = "Введите целое неотрицательное число – количество ";
    private const string OutMsgArraySuccess = "Массив успешно сформирован";
    private const string OutMsgArrayEmpty   = "Массив не содержит элементов";

    #endregion

    #region Дополнительные функции

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

    /// <summary>
    ///     Ввод числа типа <see cref="T:System.UInt32" />
    /// </summary>
    /// <param name="uintNum">Число</param>
    private static void ReadUint(out uint uintNum)
    {
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

    #endregion

    #region Одномерный массив

    /// <summary>
    ///     Ручной ввод элементов массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[] arrayInts)
    {
        Console.Write($"{InpMsgCountOf}элементов: ");
        ReadUint(out uint sizeArray);
        arrayInts = new int[sizeArray];

        for (int i = 0; i < sizeArray; i++)
        {
            Console.Write($"Введите целое число – {i + 1} элемент: ");
            ReadInt(out arrayInts[i]);
        }

        Console.WriteLine(OutMsgArraySuccess);
    }

    /// <summary>
    ///     Генерация массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[] arrayInts)
    {
        Console.Write($"{InpMsgCountOf}элементов: ");
        ReadUint(out uint sizeArray);
        arrayInts = new int[sizeArray];
        Random generator = new();

        for (int i = 0; i < sizeArray; i++)
            arrayInts[i] = generator.Next(-100, 101);

        Console.WriteLine(OutMsgArraySuccess);
        WriteArray(arrayInts);
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
            Console.WriteLine(OutMsgArrayEmpty);
        }
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
        Array.Resize(ref arrayInts, arrayInts.Length + arrayIntsAdd.Length);
        Array.Copy(arrayInts, index,
                   arrayInts, index + arrayIntsAdd.Length,
                   arrayInts.Length - index - arrayIntsAdd.Length);

        for (int i = index; i < arrayIntsAdd.Length + index; i++)
            arrayInts[i] = arrayIntsAdd[i - index];

        return arrayInts;
    }

    #endregion

    #region Двумерный массив

    /// <summary>
    ///     Ручной ввод элементов двумерного массива
    ///     <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[,] matrInts)
    {
        Console.Write($"{InpMsgCountOf}строк двумерного массива (матрицы): ");
        ReadUint(out uint countOfRows);
        Console.Write($"{InpMsgCountOf}столбцов двумерного массива (матрицы): ");
        ReadUint(out uint countOfColumns);
        matrInts = new int[countOfRows, countOfColumns];

        for (int i = 0; i < countOfRows; i++)
            for (int j = 0; j < countOfColumns; j++)
            {
                Console.Write("Введите целое число – элемент" +
                              $" в [{i + 1}, {j + 1}] ячейке: ");
                ReadInt(out matrInts[i, j]);
            }

        Console.WriteLine(OutMsgArraySuccess);
    }

    /// <summary>
    ///     Генерация двумерного массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[,] matrInts)
    {
        Console.Write($"{InpMsgCountOf}строк двумерного массива (матрицы): ");
        ReadUint(out uint countOfRows);
        Console.WriteLine($"{InpMsgCountOf}столбцов двумерного массива (матрицы): ");
        ReadUint(out uint countOfColumns);
        matrInts = new int[countOfRows, countOfColumns];

        Random generator = new();
        for (int i = 0; i < countOfRows; i++)
            for (int j = 0; j < countOfColumns; j++)
                matrInts[i, j] = generator.Next(-100, 101);

        Console.WriteLine(OutMsgArraySuccess);
        WriteArray(matrInts);
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
            Console.WriteLine(OutMsgArrayEmpty);
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

    /// <summary>
    ///     Ручной ввод элементов рваного массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[][] jaggedArrInts)
    {
        Console.Write($"{InpMsgCountOf}строк рваного массива: ");
        ReadUint(out uint countOfRows);
        jaggedArrInts = new int[countOfRows][];

        for (int i = 0; i < countOfRows; i++)
        {
            Console.Write($"{InpMsgCountOf}ячеек в {i + 1} строке: ");
            ReadUint(out uint countOfCells);
            jaggedArrInts[i] = new int[countOfCells];
            for (int j = 0; j < countOfCells; j++)
            {
                Console.Write($"Введите элемент – целое число в {j + 1} ячейку: ");
                ReadInt(out jaggedArrInts[i][j]);
            }
        }

        Console.WriteLine(OutMsgArraySuccess);
    }

    /// <summary>
    ///     Генерация элементов <see cref="T:System.Int32" /> значений
    ///     рваного массива с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[][] jaggedArrInts)
    {
        Random generator = new();
        Console.Write($"{InpMsgCountOf}строк рваного массива: ");
        ReadUint(out uint countOfRows);

        jaggedArrInts = new int[countOfRows][];
        for (int i = 0; i < countOfRows; i++)
        {
            Console.Write($"{InpMsgCountOf}ячеек в {i + 1} строке: ");
            ReadUint(out uint countOfCells);
            jaggedArrInts[i] = new int[countOfCells];
            for (int j = 0; j < countOfCells; j++)
                jaggedArrInts[i][j] = generator.Next(-100, 101);
        }

        Console.WriteLine(OutMsgArraySuccess);
        WriteArray(jaggedArrInts);
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
            Console.WriteLine(OutMsgArrayEmpty);
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