using System;
using System.Globalization;

namespace _1150080131_TranDuc
{
    public static class HinhChuNhat
    {
        public static void Run()
        {
            // Nếu cần nhập dấu chấm thay vì dấu phẩy:
            // CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            double a = ReadDouble("Nhập chiều dài a: ");
            double b = ReadDouble("Nhập chiều rộng b: ");

            double P = 2 * (a + b); // chu vi
            double S = a * b;       // diện tích

            Console.WriteLine($"Chu vi là: {P}");
            Console.WriteLine($"Diện tích là: {S}");
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double v) && v > 0)
                    return v;
                Console.WriteLine("Giá trị không hợp lệ (phải là số dương). Nhập lại.");
            }
        }
    }
}
