using System;
using System.IO;
using System.Linq;

namespace _1150080131_TranDuc
{
    public static class TH10
    {
        public static void Run()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input_array.txt");

            if (!File.Exists(path))
            {
                // Tạo file mẫu nếu chưa có
                File.WriteAllText(path, "5 2 9 1 7 3");
                Console.WriteLine($"Không thấy file, đã tạo mẫu: {path}");
            }

            int[] arr = File.ReadAllText(path)
                            .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Console.WriteLine("Mảng ban đầu: " + string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("Mảng đã sắp xếp: " + string.Join(", ", arr));
        }

        private static void SelectionSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                    if (a[j] < a[min]) min = j;

                if (min != i) (a[i], a[min]) = (a[min], a[i]);
            }
        }
    }
}
