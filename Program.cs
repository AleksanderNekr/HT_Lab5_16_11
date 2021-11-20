// This program writed using C# 10 and .NET 6

namespace HT_Lab5_16_11;

internal static class MyArray
{
    /// <summary>
    ///     Ввод числа типа <see cref="T:System.Int32" />
    /// </summary>
    private static int ReadInt()
    {
        bool isConvert;
        int  intNum;
        do
        {
            isConvert = int.TryParse(Console.ReadLine(), out intNum);
            if (!isConvert)
                Console.Write("ОШИБКА! Введено нецелое число!\nВведите заново: ");
        } while (!isConvert);

        return intNum;
    }

    /// <summary>
    ///     Ручной ввод элементов массива
    /// </summary>
    /// <param name="size">Размер массива</param>
    /// <returns>Массив <see cref="T:System.Int32" /> значений</returns>
    internal static int[] ReadArray(uint size)
    {
        var arrayInts = new int[size];
        for (var i = 0; i < size; i++)
        {
            Console.Write($"Введите элемент №{i + 1}: ");
            arrayInts[i] = ReadInt();
        }

        Console.WriteLine("Массив успешно сформирован");
        if (size == 0)
            Console.WriteLine("Массив не содержит элементов");
        return arrayInts;
    }
}

internal static class Program
{
    private static void Main()
    {
        var arr = MyArray.ReadArray(5);
        foreach (var variable in arr) Console.Write(variable + " ");
    }
}