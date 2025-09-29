using System;

namespace _1150080131_TranDuc
{
    public static class TH4
    {
        public static void Run()
        {
            Console.Write("Nhập tháng (1-12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Nhập năm: ");
            int year = int.Parse(Console.ReadLine());

            int days;
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12: days = 31; break;
                case 4: case 6: case 9: case 11: days = 30; break;
                case 2:
                    days = (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)) ? 29 : 28;
                    break;
                default:
                    Console.WriteLine("Tháng không hợp lệ!"); return;
            }
            Console.WriteLine($"Tháng {month}/{year} có {days} ngày.");
        }
    }
}
