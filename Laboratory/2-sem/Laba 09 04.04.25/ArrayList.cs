using System;

public class ArrayList<T>
{
    private T[] array;
    private int count;

    public ArrayList(int capacity = 4)
    {
        if (capacity < 0)
            throw new ArgumentException("Емкость не может быть отрицательной", nameof(capacity));

        array = new T[capacity];
        count = 0;
    }

    public void Add(T item)
    {
        if (count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }

        array[count++] = item;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс за пределами границы массива");

        for (int i = index; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }

        array[count - 1] = default(T);
        count--;
    }

    public T GetItem(int index)
    {
        if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof(index), "Индекс за пределами границы массива");

        return array[index];
    }

    public int Count => count;
}
class Program
{
    static void Main()
    {
        ArrayList<int> array = new ArrayList<int>();
        array.Add(100);
        array.Add(200);
        array.Add(300);

        Console.WriteLine(array.GetItem(0));

        array.RemoveAt(0);

        Console.WriteLine(array.GetItem(0));
    }
}
