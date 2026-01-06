using System;

namespace _1150080131_TranDuc
{
    public static class TH2
    {
        public static void Run()
        {
            int a = ReadInt("Nhập số a: ");
            int b = ReadInt("Nhập số b: ");

            if (a > b) Console.WriteLine($"Số lớn hơn là: {a}");
            else if (b > a) Console.WriteLine($"Số lớn hơn là: {b}");
            else Console.WriteLine("Hai số bằng nhau.");
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Console.WriteLine("Giá trị không hợp lệ, hãy nhập lại số nguyên.");
            }
        }
    }
}
