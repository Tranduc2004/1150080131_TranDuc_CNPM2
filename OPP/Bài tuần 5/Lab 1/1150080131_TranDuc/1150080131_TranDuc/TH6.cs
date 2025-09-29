using System;

namespace _1150080131_TranDuc
{
    public static class TH6
    {
        public static void Run()
        {
            double dai = ReadPositiveDouble("Nhập chiều dài: ");
            double rong = ReadPositiveDouble("Nhập chiều rộng: ");

            double chuVi = 2 * (dai + rong);
            double dienTich = dai * rong;

            Console.WriteLine($"Chu vi hình chữ nhật là: {chuVi}");
            Console.WriteLine($"Diện tích hình chữ nhật là: {dienTich}");
        }

        // Hàm nhập số thực dương
        private static double ReadPositiveDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double value) && value > 0)
                {
                    return value;
                }
                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập số thực dương.");
            }
        }
    }
}
