// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class MyArray
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
    internal static void ReadArray(out int[] arrayInts, uint size)
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
}

internal static class Program
{
    private static void Main()
    {
        MyArray.ReadArray(out var arr, 5);
        foreach (var variable in arr)
            Console.Write(variable + " ");
    }
}