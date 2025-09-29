using System;

namespace _1150080131_TranDuc
{
    public static class TH5
    {
        public static void Run()
        {
            Console.Write("Nhập số nguyên n: ");
            int n = int.Parse(Console.ReadLine());

            // a) Kiểm tra chẵn lẻ
            if (n % 2 == 0)
                Console.WriteLine("n là số chẵn.");
            else
                Console.WriteLine("n là số lẻ.");

            // b) Kiểm tra âm hay không âm
            if (n < 0)
                Console.WriteLine("n là số âm.");
            else
                Console.WriteLine("n là số không âm.");
        }
    }
}
