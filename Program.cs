// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class Program
{
    private static void Main()
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
                    MenuMatr(ref matr);
                    break;
                case "3":
                    MenuJag(ref jagArr);
                    break;
                case "4":
                    Console.WriteLine("Завершение программы...");
                    return;
                default:
                    Console.WriteLine("Введен неизвестный символ! Введите заново");
                    break;
            }
        }

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

    /// <summary>
    ///     Функция для ввода позиции строки рваного элемента для вставки новой
    /// </summary>
    /// <param name="jaggedArrInts">Рваный массив</param>
    /// <returns>Позиция для вставки строки</returns>
    private static uint ReadPositionToInsert(int[][] jaggedArrInts)
    {
        uint pos;
        do
        {
            Console.Write("\nВведите позицию строки – место, куда нужно вставлять новую строку: ");
            ReadUint(out pos);

            Console.WriteLine(pos > jaggedArrInts.Length + 1
                                  ? "\nНельзя вставить на эту позицию, позиция не должна быть" +
                                    " больше количества строк рваного массива + 1!"
                                  : "\nПозиция успешно введена");
        } while (pos > jaggedArrInts.Length + 1);

        return pos;
    }

    #endregion

    #region Одномерный массив

    /// <summary>
    ///     Меню для одномерного массива <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="arrInts">Массив</param>
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
                    MenuArrCreate(ref arrInts);
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
                    MenuArrCreate(ref arrAdd);
                    arrInts = arrInts.Append(arrAdd);
                    Console.WriteLine(arrAdd.Length > 0
                                          ? "\nЭлементы успешно добавлены в начало!"
                                          : "\nЭлементов нет, массив не изменился!");

                    Console.WriteLine("\nФормирование массива элементов," +
                                      " добавляемых в КОНЕЦ массива");
                    MenuArrCreate(ref arrAdd);
                    arrInts = arrInts.Append(arrAdd, arrInts.Length);
                    Console.WriteLine(arrAdd.Length > 0
                                          ? "\nЭлементы успешно добавлены в конец!"
                                          : "\nЭлементов нет, массив не изменился!");

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

    /// <summary>
    ///     Меню для создания одномерного массива <see cref="T:System.Int32" /> элементов
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    // Используется ref для возможности возврата в предыдущее меню,
    // не перезаписывая массив (как пришлось бы делать в случае с out)
    private static void MenuArrCreate(ref int[] arrayInts)
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
        WriteArray(arrayInts);
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
            arrayInts[i] = generator.Next(-50, 51);

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
            Console.WriteLine("\n" + OutMsgArrayEmpty);
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
    ///     Меню для матрицы <see cref="T:System.Int32" /> значений
    /// </summary>
    /// <param name="matrInts">Матрица значений</param>
    private static void MenuMatr(ref int[,] matrInts)
    {
        while (true)
        {
            Console.Write("\nВы выбрали работу с двумерными массивами\n"  +
                          "Выберите, что сделать:\n1. Создать массив\n"   +
                          "2. Вывести массив на экран\n3. Удалить все "   +
                          "столбцы, в которых есть хотя бы один"          +
                          " нулевой элемент\n4. Вернуться в главное меню" +
                          "\n\nВаш выбор: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВы выбрали создать массив");
                    MenuMatrCreate(ref matrInts);
                    break;
                case "2":
                    Console.WriteLine("\nВы выбрали вывести массив на экран");
                    WriteArray(matrInts);
                    break;
                case "3":
                    Console.WriteLine("\nВы выбрали удалить все столбцы," +
                                      " в которых есть хотя бы один"      +
                                      " нулевой элемент");
                    matrInts = matrInts.DeleteColumnsContainZero();
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

    /// <summary>
    ///     Меню для создания матрицы
    /// </summary>
    /// <param name="matrInts">Матрица</param>
    private static void MenuMatrCreate(ref int[,] matrInts)
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
                    ReadArray(out matrInts);
                    return;
                case "2":
                    Console.WriteLine("Выбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out matrInts);
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
        WriteArray(matrInts);
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
        Console.Write($"{InpMsgCountOf}столбцов двумерного массива (матрицы): ");
        ReadUint(out uint countOfColumns);
        matrInts = new int[countOfRows, countOfColumns];

        Random generator = new();
        for (int i = 0; i < countOfRows; i++)
            for (int j = 0; j < countOfColumns; j++)
                matrInts[i, j] = generator.Next(-5, 5);

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
            Console.WriteLine("\n" + OutMsgArrayEmpty);
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
        if (matrInts.Length > 0)
        {
            // Переменная-счетчик удалений
            int deleteCounter = 0;

            string numbersStr = "";

            for (int j = 0; j < matrInts.GetLength(1); j++)
                for (int i = 0; i < matrInts.GetLength(0); i++)
                {
                    if (j >= matrInts.GetLength(1) || matrInts[i, j] != 0)
                        continue;
                    matrInts = matrInts.DeleteColumn(j);

                    // Удаление произошло
                    deleteCounter++;

                    // Накапливаем номера удаленных столбцов для вывода
                    numbersStr = numbersStr.Insert(numbersStr.Length, j + deleteCounter + ", ");

                    // Приравниваем -1, так как в цикле for призойдет инкремент на 1,
                    // а нужно проверять с элемента с индексом 0
                    i = -1;
                }

            // Удаляем 2 последних лишних символа (", ")
            numbersStr = deleteCounter > 0
                             ? numbersStr.Remove(numbersStr.Length - 2, 2)
                             : numbersStr;

            Console.WriteLine(deleteCounter > 0
                                  ? deleteCounter != 1
                                        ? $"\nСтолбцы с номерами {numbersStr} успешно удалены!"
                                        : $"\nСтолбец №{numbersStr} успешно удален!"
                                  : "\nВ матрице нет нулевых элементов!");
        }
        else
        {
            Console.WriteLine($"\n{OutMsgArrayEmpty}, удаление невозможно");
        }

        return matrInts;
    }

    #endregion

    #region Рваный массив

    /// <summary>
    ///     Меню для рваного массива
    /// </summary>
    /// <param name="jaggedArrInts">Рваный массив</param>
    private static void MenuJag(ref int[][] jaggedArrInts)
    {
        while (true)
        {
            Console.Write("\nВы выбрали работу с рваными массивами\n"   +
                          "Выберите, что сделать:\n1. Создать массив\n" +
                          "2. Вывести массив на экран\n3. Добавить "    +
                          "строку с заданным номером\n4. Вернуться"     +
                          " в главное меню\n\nВаш выбор: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВы выбрали создать массив");
                    MenuJagArrCreate(ref jaggedArrInts);
                    break;
                case "2":
                    Console.WriteLine("\nВы выбрали вывести массив на экран");
                    WriteArray(jaggedArrInts);
                    break;
                case "3":
                    Console.WriteLine("\nВы выбрали добавить строку (массив элементов)" +
                                      " с заданным номером");
                    int[] arrAdd = Array.Empty<int>();
                    MenuArrCreate(ref arrAdd);

                    uint pos = ReadPositionToInsert(jaggedArrInts);
                    jaggedArrInts = jaggedArrInts.Append(arrAdd, pos - 1);
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

    private static void MenuJagArrCreate(ref int[][] jaggedArrInts)
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
                    ReadArray(out jaggedArrInts);
                    return;
                case "2":
                    Console.WriteLine("Выбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out jaggedArrInts);
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
        WriteArray(jaggedArrInts);
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
                jaggedArrInts[i][j] = generator.Next(-50, 51);
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
            Console.WriteLine("\n" + OutMsgArrayEmpty);
    }

    /// <summary>
    ///     Добавляет в рваный массив одномерный массив чисел
    ///     <see cref="T:System.Int32" /> значений на место указанного индекса
    /// </summary>
    /// <param name="jaggedArrInts">Исходный рваный массив</param>
    /// <param name="addArrInts">Дополнительный одномерный массив</param>
    /// <param name="index">Индекс места вставки</param>
    /// <returns></returns>
    private static int[][] Append(this int[][] jaggedArrInts, int[] addArrInts, uint index)
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