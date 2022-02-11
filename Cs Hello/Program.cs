// See https://aka.ms/new-console-template for more information

public class HW1
{
    private static int MinCustomerTime(int[] buff)
    {
        int min = buff[0];
        for (int i = 1; i < buff.Length; i++)
        {
            if (buff[i] < min && buff[i] != 0)
            {
                min = buff[i];
            }
        }
        return min;
    }

    private static int MaxCustomerTime(int[] buff)
    {
        int max = buff[0];
        for (int i = 1; i < buff.Length; i++)
        {
            if (buff[i] > max)
            {
                max = buff[i];
            }
        }
        return max;
    }

    public static long QueueTime(int[] customers, int n)
    {
        if(customers.Length <= n)
            return MaxCustomerTime(customers);

        long time = 0;
        int[] buff = new int[n];
        int i = 0;
        for(int j = 0; j < buff.Length && i < customers.Length; j++, i++)
        {
              buff[j] = customers[i];
        }

        while (i < customers.Length)
        {
            int minBuffTime = MinCustomerTime(buff);
            for (int j = 0; j < buff.Length; j++)
            {
                buff[j] -= minBuffTime;
            }
            time += minBuffTime;

            for (int j = 0; j < buff.Length; j++)
            {
                if(buff[j] == 0)
                {
                    if(i != customers.Length)
                        buff[j] = customers[i++];
                    else
                        return time + MaxCustomerTime(buff);
                }
            }
        }
        time += MaxCustomerTime(buff);
        return time;
    }
}

public class Program
{
    public static void Main()
    {
        int[] a = new int[] { 5, 3, 4 };
        Console.WriteLine("Test case 1: {0}", HW1.QueueTime(a, 1));
        int[] b = new int[] {10, 2, 3, 3 };
        Console.WriteLine("Test case 2: {0}", HW1.QueueTime(b, 2));
        int[] c = new int[] { 2, 3, 10 };
        Console.WriteLine("Test case 3: {0}", HW1.QueueTime(c, 2));
        int[] d = new int[] { 25, 8, 63 };
        Console.WriteLine("Test case 4: {0}", HW1.QueueTime(d, 3));
        int[] e = new int[] { 213, 87, 94 };
        Console.WriteLine("Test case 5: {0}", HW1.QueueTime(e, 4));
        int[] f = new int[] { 1, 5, 5, 4, 10 };
        Console.WriteLine("Test case 6: {0}", HW1.QueueTime(f, 3));
    }
}
