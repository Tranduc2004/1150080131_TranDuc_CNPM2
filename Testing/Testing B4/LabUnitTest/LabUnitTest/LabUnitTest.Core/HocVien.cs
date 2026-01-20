public class HocVien
{
    public string MaSo { get; }
    public string HoTen { get; }
    public string QueQuan { get; }
    public double M1, M2, M3;

    public HocVien(string ma, string ten, string qq, double m1, double m2, double m3)
    {
        MaSo = ma;
        HoTen = ten;
        QueQuan = qq;
        M1 = m1; M2 = m2; M3 = m3;
    }

    public double DTB() => (M1 + M2 + M3) / 3;

    public bool DuHocBong()
        => DTB() >= 8 && M1 >= 5 && M2 >= 5 && M3 >= 5;
}
