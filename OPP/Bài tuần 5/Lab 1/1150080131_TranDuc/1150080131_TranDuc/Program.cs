using System;

namespace _1150080131_TranDuc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Gọi bài bạn muốn chạy:
            // Bai01.Run();
            // Bai02.Run(); 
            // ví dụ chạy bài Thực hành 4
            Console.WriteLine("Chọn bài thực hành (1-9):");
            Console.WriteLine("1. Hình chữ nhật (HinhChuNhat)");
            Console.WriteLine("2. Thực hành 2 (TH2)");
            Console.WriteLine("3. Thực hành 3 (TH3)");
            Console.WriteLine("4. Thực hành 4 (TH4)");
            Console.WriteLine("5. Thực hành 5 (TH5)");
            Console.WriteLine("6. Thực hành 6 (TH6)");
            Console.WriteLine("7. Thực hành 7 (TH7)");
            Console.WriteLine("8. Thực hành 8 (TH8)");
            Console.WriteLine("9. Thực hành 9 (TH9)");
            Console.WriteLine("10. Thực hành 10 (TH10)");
            Console.WriteLine("11. Thực hành 11 (TH11)");
            Console.Write("Lựa chọn của bạn: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: HinhChuNhat.Run(); break;
                case 2: TH2.Run(); break;
                case 3: TH3.Run(); break;
                case 4: TH4.Run(); break;
                case 5: TH5.Run(); break;
                case 6: TH6.Run(); break;
                case 7: TH7.Run(); break;
                case 8: TH8.Run(); break;
                case 9: TH9.Run(); break;
                case 10: TH10.Run(); break;
                case 11: TH11.Run(); break;
                default:    
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }

            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();
        }
    }
}
