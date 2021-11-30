// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class Program
{
    private static void Main()
    {
        int[]   array       = Array.Empty<int>();
        int[,]  matrix      = new int[0, 0];
        int[][] jaggedArray = Array.Empty<int[]>();

        while (true)
        {
            Console.Write("Выберите, с каким из"                          +
                          " следующих видов массивов вы хотите работать:" +
                          "\n1. Одномерный массив"                        +
                          "\n2. Двумерный массив"                         +
                          "\n3. Рваный массив"                            +
                          "\n4. Завершить выполнение программы\n"         +
                          "\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MenuArr(ref array);
                    break;
                case "2":
                    MenuMatr(ref matrix);
                    break;
                case "3":
                    MenuJag(ref jaggedArray);
                    break;
                case "4":
                    Console.WriteLine("Завершение программы...");
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    #region Литерные строки некоторых сообщений

    private const string MsgInputCountOf       = "Введите целое неотрицательное число – количество ";
    private const string MsgCreateArraySuccess = "Массив успешно сформирован";
    private const string MsgArrayEmpty         = "\nМассив не содержит элементов";
    private const string MsgErrUnknownChar     = "\nОШИБКА! Введен неизвестный символ! Введите заново";

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
            Console.Write("\nВы выбрали работу с одномерными массивами\n"     +
                          "Выберите, что сделать:"                            +
                          "\n1. Создать массив"                               +
                          "\n2. Вывести массив на экран"                      +
                          "\n3. Добавить элементы в начало и в конец массива" +
                          "\n4. Вернуться в главное меню\n"                   +
                          "\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
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
                                          ? "\nДополнительные элементы успешно добавлены в начало!"
                                          : "\nДополнительных элементов в начало не добавлено!");

                    Console.WriteLine("\nФормирование массива элементов," +
                                      " добавляемых в КОНЕЦ массива");
                    MenuArrCreate(ref arrAdd);
                    arrInts = arrInts.Append(arrAdd, arrInts.Length);
                    Console.WriteLine(arrAdd.Length > 0
                                          ? "\nДополнительные элементы успешно добавлены в конец!"
                                          : "\nДополнительных элементов в конец не добавлено!");

                    break;
                case "4":
                    Console.WriteLine("\nВы выбрали вернуться в главное меню");
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    /// <summary>
    ///     Меню для заполнения одномерного массива <see cref="T:System.Int32" /> значениями
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    // Используется ref для возможности возврата в предыдущее меню,
    // не перезаписывая массив (как пришлось бы делать в случае с out)
    private static void MenuArrCreate(ref int[] arrayInts)
    {
        while (true)
        {
            Console.Write("Выберите, что сделать:"             +
                          "\n1. Ввести элементы вручную"       +
                          "\n2. Сгенерировать элементы"        +
                          " с помощью датчика случайных чисел" +
                          "\n3. Вернуться в предыдущее меню\n" +
                          "\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВыбрано ввести элементы массива вручную");
                    ReadArray(out arrayInts);
                    return;
                case "2":
                    Console.WriteLine("\nВыбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out arrayInts);
                    return;
                case "3":
                    Console.WriteLine("\nВы выбрали вернуться в предыдущее меню");
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    /// <summary>
    ///     Ручной ввод элементов массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[] arrayInts)
    {
        Console.Write($"{MsgInputCountOf}элементов: ");
        ReadUint(out uint sizeArray);
        arrayInts = new int[sizeArray];

        for (int i = 0; i < sizeArray; i++)
        {
            Console.Write($"Введите целое число – {i + 1} элемент: ");
            ReadInt(out arrayInts[i]);
        }

        Console.WriteLine(MsgCreateArraySuccess);
        WriteArray(arrayInts);
    }

    /// <summary>
    ///     Генерация массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[] arrayInts)
    {
        Console.Write($"{MsgInputCountOf}элементов: ");
        ReadUint(out uint sizeArray);
        arrayInts = new int[sizeArray];
        Random generator = new();

        for (int i = 0; i < sizeArray; i++)
            arrayInts[i] = generator.Next(-50, 51);

        Console.WriteLine(MsgCreateArraySuccess);
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
            Console.WriteLine(MsgArrayEmpty);
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
            Console.Write("\nВы выбрали работу с двумерными массивами\n" +
                          "Выберите, что сделать:"                       +
                          "\n1. Создать массив"                          +
                          "\n2. Вывести массив на экран"                 +
                          "\n3. Удалить все столбцы, в которых есть"     +
                          " хотя бы один нулевой элемент"                +
                          "\n4. Вернуться в главное меню"                +
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
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    /// <summary>
    ///     Меню для заполнения матрицы значениями <see cref="T:System.Int32" />
    /// </summary>
    /// <param name="matrInts">Матрица</param>
    private static void MenuMatrCreate(ref int[,] matrInts)
    {
        while (true)
        {
            Console.Write("Выберите, что сделать:"             +
                          "\n1. Ввести элементы вручную"       +
                          "\n2. Сгенерировать элементы"        +
                          " с помощью датчика случайных чисел" +
                          "\n3. Вернуться в предыдущее меню\n" +
                          "\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВыбрано ввести элементы массива вручную");
                    ReadArray(out matrInts);
                    return;
                case "2":
                    Console.WriteLine("\nВыбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out matrInts);
                    return;
                case "3":
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
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
        Console.Write($"{MsgInputCountOf}строк двумерного массива (матрицы): ");
        ReadUint(out uint countOfRows);
        Console.Write($"{MsgInputCountOf}столбцов двумерного массива (матрицы): ");
        ReadUint(out uint countOfColumns);
        matrInts = new int[countOfRows, countOfColumns];

        for (int i = 0; i < countOfRows; i++)
            for (int j = 0; j < countOfColumns; j++)
            {
                Console.Write("Введите целое число – элемент" +
                              $" в [{i + 1}, {j + 1}] ячейке: ");
                ReadInt(out matrInts[i, j]);
            }

        Console.WriteLine(MsgCreateArraySuccess);
        WriteArray(matrInts);
    }

    /// <summary>
    ///     Генерация двумерного массива
    ///     <see cref="T:System.Int32" />
    ///     с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[,] matrInts)
    {
        Console.Write($"{MsgInputCountOf}строк двумерного массива (матрицы): ");
        ReadUint(out uint countOfRows);
        Console.Write($"{MsgInputCountOf}столбцов двумерного массива (матрицы): ");
        ReadUint(out uint countOfColumns);
        matrInts = new int[countOfRows, countOfColumns];

        Random generator = new();
        for (int i = 0; i < countOfRows; i++)
            for (int j = 0; j < countOfColumns; j++)
                matrInts[i, j] = generator.Next(-5, 5);

        Console.WriteLine(MsgCreateArraySuccess);
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
            Console.WriteLine(MsgArrayEmpty);
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
            Console.WriteLine($"{MsgArrayEmpty}, удаление невозможно");
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
            Console.Write("\nВы выбрали работу с рваными массивами"  +
                          "\nВыберите, что сделать:"                 +
                          "\n1. Создать массив"                      +
                          "\n2. Вывести массив на экран"             +
                          "\n3. Добавить строку на заданную позицию" +
                          "\n4. Вернуться в главное меню\n"          +
                          "\nВаш выбор: ");
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
                                      " на заданную позицию в рваном массиве");
                    int[] arrAdd = Array.Empty<int>();
                    MenuArrCreate(ref arrAdd);

                    if (arrAdd.Length > 0)
                    {
                        uint pos = ReadPositionToInsert(jaggedArrInts);
                        jaggedArrInts = jaggedArrInts.Append(arrAdd, pos - 1);
                    }
                    else
                    {
                        Console.WriteLine("Исходный массив остается прежним");
                    }

                    break;
                case "4":
                    Console.WriteLine("\nВы выбрали вернуться в главное меню");
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    /// <summary>
    ///     Меню для заполнения рваного массива
    /// </summary>
    /// <param name="jaggedArrInts">Рваный массив</param>
    private static void MenuJagArrCreate(ref int[][] jaggedArrInts)
    {
        while (true)
        {
            Console.Write("Выберите, что сделать:"                +
                          "\n1. Ввести элементы вручную"          +
                          "\n2. Сгенерировать элементы с помощью" +
                          " датчика случайных чисел"              +
                          "\n3. Вернуться в предыдущее меню\n"    +
                          "\nВаш выбор: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\nВыбрано ввести элементы массива вручную");
                    ReadArray(out jaggedArrInts);
                    return;
                case "2":
                    Console.WriteLine("\nВыбрано сгенерировать элементы массива " +
                                      "с помощью датчика случайных чисел");
                    GenerateArray(out jaggedArrInts);
                    return;
                case "3":
                    return;
                default:
                    Console.WriteLine(MsgErrUnknownChar);
                    break;
            }
        }
    }

    /// <summary>
    ///     Ввод позиции строки рваного элемента для вставки новой
    /// </summary>
    /// <param name="jaggedArrInts">Рваный массив</param>
    /// <returns>Позиция для вставки строки</returns>
    private static uint ReadPositionToInsert(int[][] jaggedArrInts)
    {
        uint pos;
        int  maxPos = jaggedArrInts.Length + 1;
        do
        {
            Console.Write("\nВведите позицию строки – место, куда нужно вставлять новую строку" +
                          $" (целое число от 1 до {maxPos}): ");
            ReadUint(out pos);

            Console.WriteLine(pos > maxPos || pos < 1
                                  ? "\nНельзя вставить на эту позицию, позиция должна быть" +
                                    $" больше 0 и не больше {maxPos}!"
                                  : "\nПозиция успешно введена, строка вставлена на эту позицию");
        } while (pos > maxPos || pos < 1);

        return pos;
    }

    /// <summary>
    ///     Ручной ввод элементов рваного массива <see cref="T:System.Int32" /> значений
    /// </summary>
    private static void ReadArray(out int[][] jaggedArrInts)
    {
        Console.Write($"{MsgInputCountOf}строк рваного массива: ");
        ReadUint(out uint countOfRows);
        jaggedArrInts = new int[countOfRows][];

        for (int i = 0; i < countOfRows; i++)
        {
            Console.Write($"{MsgInputCountOf}ячеек в {i + 1} строке: ");
            ReadUint(out uint countOfCells);
            jaggedArrInts[i] = new int[countOfCells];
            for (int j = 0; j < countOfCells; j++)
            {
                Console.Write($"Введите элемент – целое число в {j + 1} ячейку: ");
                ReadInt(out jaggedArrInts[i][j]);
            }
        }

        Console.WriteLine(MsgCreateArraySuccess);
        WriteArray(jaggedArrInts);
    }

    /// <summary>
    ///     Генерация элементов <see cref="T:System.Int32" /> значений
    ///     рваного массива с помощью датчика случайных чисел
    /// </summary>
    private static void GenerateArray(out int[][] jaggedArrInts)
    {
        Random generator = new();
        Console.Write($"{MsgInputCountOf}строк рваного массива: ");
        ReadUint(out uint countOfRows);

        jaggedArrInts = new int[countOfRows][];
        for (int i = 0; i < countOfRows; i++)
        {
            Console.Write($"{MsgInputCountOf}ячеек в {i + 1} строке: ");
            ReadUint(out uint countOfCells);
            jaggedArrInts[i] = new int[countOfCells];
            for (int j = 0; j < countOfCells; j++)
                jaggedArrInts[i][j] = generator.Next(-50, 51);
        }

        Console.WriteLine(MsgCreateArraySuccess);
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
            Console.WriteLine(MsgArrayEmpty);
    }

    /// <summary>
    ///     Добавляет в рваный массив одномерный массив чисел
    ///     <see cref="T:System.Int32" /> значений на место указанного индекса
    /// </summary>
    /// <param name="jaggedArrInts">Исходный рваный массив</param>
    /// <param name="addArrInts">Дополнительный одномерный массив</param>
    /// <param name="index">Индекс места вставки</param>
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
                Console.Write("ОШИБКА! Введено нецелое число, или строка," +
                              " или слишком большое целое!"                +
                              "\nВведите заново: ");
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
                Console.Write("ОШИБКА! Введено нецелое число, или отрицательное, " +
                              "или не число!\nВведите заново: ");
        } while (!isConvert);
    }

    #endregion
}