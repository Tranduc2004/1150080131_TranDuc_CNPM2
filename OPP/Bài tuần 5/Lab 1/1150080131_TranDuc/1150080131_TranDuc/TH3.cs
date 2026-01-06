using System;

namespace _1150080131_TranDuc
{
    public static class TH3
    {
        public static void Run()
        {
            int a = ReadInt("Nhập số a: ");
            int b = ReadInt("Nhập số b: ");
            int c = ReadInt("Nhập số c: ");

            if (a == b && b == c)
            {
                Console.WriteLine("Ba số bằng nhau.");
                return;
            }

            int max = Math.Max(a, Math.Max(b, c));
            Console.Write($"Số lớn nhất là: {max}");

            // Có nhiều số cùng lớn nhất?
            int countMax = (a == max ? 1 : 0) + (b == max ? 1 : 0) + (c == max ? 1 : 0);
            if (countMax > 1) Console.Write(" (có nhiều số cùng lớn nhất)");
            Console.WriteLine();
        }

        // Hỗ trợ nhập số an toàn
        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value)) return value;
                Console.WriteLine("Giá trị không hợp lệ, hãy nhập lại số nguyên.");
            }
        }
    }
}
