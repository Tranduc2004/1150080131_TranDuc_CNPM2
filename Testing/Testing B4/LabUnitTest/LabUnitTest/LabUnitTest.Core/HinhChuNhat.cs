using System;

public class HinhChuNhat
{
    public Diem TrenTrai { get; }
    public Diem DuoiPhai { get; }

    public HinhChuNhat(Diem trenTrai, Diem duoiPhai)
    {
        if (trenTrai == null || duoiPhai == null ||
            trenTrai.X >= duoiPhai.X || trenTrai.Y <= duoiPhai.Y)
            throw new ArgumentException("Invalid Rectangle");

        TrenTrai = trenTrai;
        DuoiPhai = duoiPhai;
    }

    public double DienTich()
    {
        return (DuoiPhai.X - TrenTrai.X) *
               (TrenTrai.Y - DuoiPhai.Y);
    }

    public bool GiaoNhau(HinhChuNhat other)
    {
        if (other == null) return false;

        return !(DuoiPhai.X < other.TrenTrai.X ||
                 other.DuoiPhai.X < TrenTrai.X ||
                 TrenTrai.Y < other.DuoiPhai.Y ||
                 other.TrenTrai.Y < DuoiPhai.Y);
    }
}
