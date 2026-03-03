package dtm.data;

import org.testng.annotations.DataProvider;

public class DangNhapData {
    @DataProvider(name = "du_lieu_dang_nhap")
    public static Object[][] getData() {
        return new Object[][]{
                {"standard_user", "secret_sauce", "THANH_CONG", "Tài khoản valid chuẩn"},
                {"problem_user", "secret_sauce", "THANH_CONG", "Tài khoản lỗi UI nhưng vẫn đăng nhập được"},
                {"performance_glitch_user", "secret_sauce", "THANH_CONG", "Tài khoản chậm"},
                {"error_user", "secret_sauce", "THANH_CONG", "Tài khoản lỗi chức năng"},
                {"visual_user", "secret_sauce", "THANH_CONG", "Tài khoản visual"},

                {"locked_out_user", "secret_sauce", "BI_KHOA", "Tài khoản bị khóa"},

                {"khong_ton_tai_001", "mat_khau_tu_dat", "SAI_THONG_TIN", "Tài khoản không tồn tại"},
                {"standard_user", "wrong_password", "SAI_THONG_TIN", "Sai password"},
                {"user@#$", "secret_sauce", "SAI_THONG_TIN", "Username ký tự đặc biệt"},
                {" standard_user", "secret_sauce", "SAI_THONG_TIN", "Username có khoảng trắng đầu"},
                {"standard_user ", "secret_sauce", "SAI_THONG_TIN", "Username có khoảng trắng cuối"},

                {"", "secret_sauce", "TRUONG_TRONG", "Để trống username"},
                {"standard_user", "", "TRUONG_TRONG", "Để trống password"},
                {"", "", "TRUONG_TRONG", "Để trống cả hai"},

                {null, "secret_sauce", "TRUONG_TRONG", "Username null"},
                {"standard_user", null, "TRUONG_TRONG", "Password null"},
                {null, null, "TRUONG_TRONG", "Cả username/password đều null"}
        };
    }
}