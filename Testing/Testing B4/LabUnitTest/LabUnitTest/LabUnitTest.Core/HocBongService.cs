using System.Collections.Generic;
using System.Linq;

public static class HocBongService
{
    public static List<HocVien> LayDanhSachHocBong(List<HocVien> ds)
        => ds.Where(h => h.DuHocBong()).ToList();
}
