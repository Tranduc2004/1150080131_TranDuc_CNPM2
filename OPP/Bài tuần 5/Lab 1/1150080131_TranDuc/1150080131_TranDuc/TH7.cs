using System;

namespace _1150080131_TranDuc
{
    public static class TH7
    {
        public static void Run()
        {
            double a = ReadPositiveDouble("Nhập độ dài cạnh a: ");
            double b = ReadPositiveDouble("Nhập độ dài cạnh b: ");
            double c = ReadPositiveDouble("Nhập độ dài cạnh c: ");

            // Kiểm tra điều kiện tạo thành tam giác: a, b, c > 0 và
            // tổng hai cạnh bất kỳ > cạnh còn lại
            if (IsTriangle(a, b, c))
            {
                double p = a + b + c;            // chu vi
                double s = p / 2.0;              // nửa chu vi
                double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c)); // Heron

                Console.WriteLine($"Chu vi tam giác: {p}");
                Console.WriteLine($"Diện tích tam giác: {area}");
            }
            else
            {
                Console.WriteLine("Ba đoạn thẳng KHÔNG lập thành tam giác (vi phạm bất đẳng thức tam giác).");
            }
        }

        private static bool IsTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0
                   && a + b > c
                   && a + c > b
                   && b + c > a;
        }

        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                    return value;
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số thực dương.");
            }
        }
    }
}
