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

    /// <summary>
    ///     Ручной ввод элементов массива
    /// </summary>
    /// <param name="arrayInts">Выходной массив <see cref="T:System.Int32" /> значений</param>
    /// <param name="size">Размер массива</param>
    private static void Read(out int[] arrayInts, uint size)
    {
        arrayInts = new int[size];
        for (var i = 0; i < size; i++)
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
    private static int[] GenerateArray(uint sizeArray)
    {
        var arrayInts = new int[sizeArray];

        var generator = new Random();
        for (var i = 0; i < sizeArray; i++)
            arrayInts[i] = generator.Next(-100, 101);

        Console.WriteLine("Массив успешно сформирован");
        if (sizeArray == 0)
            Console.WriteLine("Массив не содержит элементов");
        return arrayInts;
    }

    /// <summary>
    ///     Вывод массива <see cref="T:System.Int32" /> значений в консоль.
    /// </summary>
    /// <param name="arrayInts">Массив</param>
    private static void Write(IReadOnlyCollection<int> arrayInts)
    {
        if (arrayInts.Count > 0)
        {
            foreach (var variable in arrayInts)
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
    /// <param name="index">Индекс в массиве для всавляемого числа (по умолчанию – 0)</param>
    private static void Append(ref int[] arrayInts, int elem, int index = 0)
    {
        Array.Resize(ref arrayInts, arrayInts.Length + 1);
        Array.Copy(arrayInts, index,
                   arrayInts, index + 1,
                   arrayInts.Length - index - 1);
        arrayInts[index] = elem;
    }

    private static void Main()
    {
        Read(out var arr, 5);
        ReadInt(out var elem);
        ReadInt(out var index);
        Append(ref arr, elem);
        Write(arr);
    }
}