using System;

namespace _1150080131_TranDuc
{
    public static class TH9
    {
        public static void Run()
        {
            Console.Write("Nhập số lượng phần tử n: ");
            int n = ReadPositiveInt();

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử arr[{i}]: ");
                arr[i] = ReadInt();
            }

            int sum = 0;
            foreach (int x in arr)
            {
                sum += x;
            }

            Console.WriteLine("Tổng các phần tử trong mảng = " + sum);
        }

        private static int ReadPositiveInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int v) && v > 0)
                    return v;
                Console.Write("Giá trị không hợp lệ. Nhập lại số nguyên dương: ");
            }
        }

        private static int ReadInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int v))
                    return v;
                Console.Write("Giá trị không hợp lệ. Nhập lại số nguyên: ");
            }
        }
    }
}
