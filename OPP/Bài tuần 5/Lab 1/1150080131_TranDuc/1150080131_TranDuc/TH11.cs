using System;
using System.Linq;

namespace _1150080131_TranDuc
{
    public static class TH11
    {
        public static void Run()
        {
            int n = ReadPositiveInt("Nhập số lượng phần tử n: ");

            // Nhập mảng tăng dần (nếu người dùng nhập chưa tăng dần, sẽ tự sắp xếp lại)
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = ReadInt($"a[{i}]= ");
            }

            // Đảm bảo mảng tăng dần (nếu đề yêu cầu chắc chắn tăng dần, có thể bỏ dòng này)
            if (!IsNonDecreasing(a))
            {
                Array.Sort(a);
                Console.WriteLine("Mảng nhập chưa tăng dần, đã tự sắp xếp lại.");
            }

            Console.Write("Nhập số nguyên x cần chèn: ");
            int x = ReadInt();

            // Tìm vị trí chèn bằng BinarySearch
            int idx = Array.BinarySearch(a, x);
            int insertPos = (idx >= 0) ? idx + 1 : ~idx; // chèn sau các phần tử bằng x

            // Tạo mảng mới và chèn
            int[] b = new int[n + 1];
            Array.Copy(a, 0, b, 0, insertPos);
            b[insertPos] = x;
            Array.Copy(a, insertPos, b, insertPos + 1, n - insertPos);

            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", a));
            Console.WriteLine($"Chèn {x} vào vị trí {insertPos}");
            Console.WriteLine("Mảng sau khi chèn: " + string.Join(", ", b));
        }

        private static bool IsNonDecreasing(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i] < a[i - 1]) return false;
            return true;
        }

        private static int ReadPositiveInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v) && v > 0) return v;
                Console.WriteLine("Giá trị không hợp lệ. Nhập lại số nguyên dương.");
            }
        }

        private static int ReadInt(string prompt = null)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Console.WriteLine("Giá trị không hợp lệ. Nhập lại số nguyên.");
            }
        }
    }
}
