import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.time.LocalDate;
import java.time.format.DateTimeParseException;
import java.util.HashMap;
import java.util.Map;

public class RegisterFrame extends JFrame {
    
    private JTextField txtMaKhachHang;
    private JTextField txtHoTen;
    private JTextField txtEmail;
    private JTextField txtSoDienThoai;
    private JTextArea txtDiaChi;
    private JPasswordField txtMatKhau;
    private JPasswordField txtXacNhanMatKhau;
    private JTextField txtNgaySinh;
    private JRadioButton rbNam, rbNu, rbKhac;
    private JCheckBox cbDongY;
    
    private Map<String, JLabel> errorLabels = new HashMap<>();
    private JLabel lblSuccessMessage;
    
    public RegisterFrame() {
        setTitle("Đăng Ký Tài Khoản Khách Hàng");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(600, 750);
        setLocationRelativeTo(null);
        setResizable(false);
        
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BoxLayout(mainPanel, BoxLayout.Y_AXIS));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));
        
        // Tiêu đề
        JLabel lblTitle = new JLabel("ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG");
        lblTitle.setFont(new Font("Arial", Font.BOLD, 18));
        lblTitle.setAlignmentX(Component.CENTER_ALIGNMENT);
        mainPanel.add(lblTitle);
        mainPanel.add(Box.createVerticalStrut(20));
        
        // Mã Khách Hàng
        mainPanel.add(createFormGroup("Mã Khách Hàng", "6-10 ký tự, chỉ chữ và số", field -> txtMaKhachHang = (JTextField) field, "maKhachHang"));
        
        // Họ và Tên
        mainPanel.add(createFormGroup("Họ và Tên", "Nhập họ tên đầy đủ", field -> txtHoTen = (JTextField) field, "hoTen"));
        
        // Email
        mainPanel.add(createFormGroup("Email", "vd: nguyenvana@email.com", field -> txtEmail = (JTextField) field, "email"));
        
        // Số Điện Thoại
        mainPanel.add(createFormGroup("Số Điện Thoại", "Bắt đầu bằng số 0, 10-12 số", field -> txtSoDienThoai = (JTextField) field, "soDienThoai"));
        
        // Địa Chỉ
        JPanel pnlDiaChi = new JPanel();
        pnlDiaChi.setLayout(new BoxLayout(pnlDiaChi, BoxLayout.Y_AXIS));
        pnlDiaChi.setMaximumSize(new Dimension(Integer.MAX_VALUE, 80));
        
        JLabel lblDiaChi = new JLabel("Địa chỉ *");
        lblDiaChi.setFont(new Font("Arial", Font.PLAIN, 12));
        pnlDiaChi.add(lblDiaChi);
        
        txtDiaChi = new JTextArea(3, 30);
        txtDiaChi.setLineWrap(true);
        txtDiaChi.setWrapStyleWord(true);
        txtDiaChi.setFont(new Font("Arial", Font.PLAIN, 12));
        JScrollPane scrollDiaChi = new JScrollPane(txtDiaChi);
        pnlDiaChi.add(scrollDiaChi);
        
        JLabel errorDiaChi = new JLabel();
        errorDiaChi.setForeground(Color.RED);
        errorDiaChi.setFont(new Font("Arial", Font.PLAIN, 11));
        pnlDiaChi.add(errorDiaChi);
        errorLabels.put("diaChi", errorDiaChi);
        
        mainPanel.add(pnlDiaChi);
        mainPanel.add(Box.createVerticalStrut(10));
        
        // Mật Khẩu
        mainPanel.add(createPasswordGroup("Mật khẩu", "Ít nhất 8 ký tự", field -> txtMatKhau = (JPasswordField) field, "matKhau"));
        
        // Xác Nhận Mật Khẩu
        mainPanel.add(createPasswordGroup("Xác nhận Mật khẩu", "Nhập lại mật khẩu", field -> txtXacNhanMatKhau = (JPasswordField) field, "xacNhanMatKhau"));
        
        // Ngày Sinh
        mainPanel.add(createFormGroup("Ngày sinh", "mm/dd/yyyy", field -> txtNgaySinh = (JTextField) field, "ngaySinh"));
        
        // Giới Tính
        JPanel pnlGioiTinh = new JPanel();
        pnlGioiTinh.setLayout(new BoxLayout(pnlGioiTinh, BoxLayout.X_AXIS));
        pnlGioiTinh.setMaximumSize(new Dimension(Integer.MAX_VALUE, 30));
        
        JLabel lblGioiTinh = new JLabel("Giới tính");
        lblGioiTinh.setFont(new Font("Arial", Font.PLAIN, 12));
        pnlGioiTinh.add(lblGioiTinh);
        pnlGioiTinh.add(Box.createHorizontalStrut(30));
        
        ButtonGroup groupGioiTinh = new ButtonGroup();
        rbNam = new JRadioButton("Nam");
        rbNu = new JRadioButton("Nữ");
        rbKhac = new JRadioButton("Khác");
        
        groupGioiTinh.add(rbNam);
        groupGioiTinh.add(rbNu);
        groupGioiTinh.add(rbKhac);
        
        pnlGioiTinh.add(rbNam);
        pnlGioiTinh.add(rbNu);
        pnlGioiTinh.add(rbKhac);
        pnlGioiTinh.add(Box.createHorizontalGlue());
        
        mainPanel.add(pnlGioiTinh);
        mainPanel.add(Box.createVerticalStrut(10));
        
        // Điều Khoản Dịch Vụ
        JPanel pnlDongY = new JPanel();
        pnlDongY.setLayout(new BoxLayout(pnlDongY, BoxLayout.Y_AXIS));
        pnlDongY.setMaximumSize(new Dimension(Integer.MAX_VALUE, 50));
        
        cbDongY = new JCheckBox("Tôi đồng ý với các điều khoản dịch vụ *");
        cbDongY.setFont(new Font("Arial", Font.PLAIN, 12));
        pnlDongY.add(cbDongY);
        
        JLabel errorDongY = new JLabel();
        errorDongY.setForeground(Color.RED);
        errorDongY.setFont(new Font("Arial", Font.PLAIN, 11));
        pnlDongY.add(errorDongY);
        errorLabels.put("dongY", errorDongY);
        
        mainPanel.add(pnlDongY);
        mainPanel.add(Box.createVerticalStrut(10));
        
        // Thông báo thành công
        lblSuccessMessage = new JLabel();
        lblSuccessMessage.setForeground(new Color(0, 128, 0));
        lblSuccessMessage.setFont(new Font("Arial", Font.BOLD, 12));
        lblSuccessMessage.setAlignmentX(Component.CENTER_ALIGNMENT);
        mainPanel.add(lblSuccessMessage);
        mainPanel.add(Box.createVerticalStrut(10));
        
        // Các nút
        JPanel pnlButtons = new JPanel();
        pnlButtons.setMaximumSize(new Dimension(Integer.MAX_VALUE, 40));
        
        JButton btnDangKy = new JButton("Đăng ký");
        btnDangKy.setPreferredSize(new Dimension(120, 35));
        btnDangKy.setFont(new Font("Arial", Font.BOLD, 12));
        btnDangKy.setBackground(new Color(0, 102, 204));
        btnDangKy.setForeground(Color.WHITE);
        btnDangKy.addActionListener(e -> handleRegister());
        
        JButton btnNhapLai = new JButton("Nhập lại");
        btnNhapLai.setPreferredSize(new Dimension(120, 35));
        btnNhapLai.setFont(new Font("Arial", Font.BOLD, 12));
        btnNhapLai.setBackground(new Color(102, 102, 102));
        btnNhapLai.setForeground(Color.WHITE);
        btnNhapLai.addActionListener(e -> handleReset());
        
        pnlButtons.add(btnDangKy);
        pnlButtons.add(Box.createHorizontalStrut(20));
        pnlButtons.add(btnNhapLai);
        
        mainPanel.add(pnlButtons);
        
        // Scroll pane
        JScrollPane scrollPane = new JScrollPane(mainPanel);
        scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
        add(scrollPane);
    }
    
    private JPanel createFormGroup(String label, String placeholder, java.util.function.Consumer<JComponent> fieldConsumer, String fieldName) {
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));
        panel.setMaximumSize(new Dimension(Integer.MAX_VALUE, 60));
        
        JLabel lbl = new JLabel(label + " *");
        lbl.setFont(new Font("Arial", Font.PLAIN, 12));
        panel.add(lbl);
        
        JTextField field = new JTextField(placeholder);
        field.setFont(new Font("Arial", Font.PLAIN, 12));
        field.setMaximumSize(new Dimension(Integer.MAX_VALUE, 25));
        panel.add(field);
        fieldConsumer.accept(field);
        
        JLabel errorLabel = new JLabel();
        errorLabel.setForeground(Color.RED);
        errorLabel.setFont(new Font("Arial", Font.PLAIN, 11));
        panel.add(errorLabel);
        errorLabels.put(fieldName, errorLabel);
        
        return panel;
    }
    
    private JPanel createPasswordGroup(String label, String placeholder, java.util.function.Consumer<JComponent> fieldConsumer, String fieldName) {
        JPanel panel = new JPanel();
        panel.setLayout(new BoxLayout(panel, BoxLayout.Y_AXIS));
        panel.setMaximumSize(new Dimension(Integer.MAX_VALUE, 60));
        
        JLabel lbl = new JLabel(label + " *");
        lbl.setFont(new Font("Arial", Font.PLAIN, 12));
        panel.add(lbl);
        
        JPasswordField field = new JPasswordField(placeholder);
        field.setFont(new Font("Arial", Font.PLAIN, 12));
        field.setMaximumSize(new Dimension(Integer.MAX_VALUE, 25));
        panel.add(field);
        fieldConsumer.accept(field);
        
        JLabel errorLabel = new JLabel();
        errorLabel.setForeground(Color.RED);
        errorLabel.setFont(new Font("Arial", Font.PLAIN, 11));
        panel.add(errorLabel);
        errorLabels.put(fieldName, errorLabel);
        
        return panel;
    }
    
    private void handleRegister() {
        // Xóa tất cả lỗi trước đó
        clearErrors();
        lblSuccessMessage.setText("");
        
        String maKhachHang = txtMaKhachHang.getText();
        String hoTen = txtHoTen.getText();
        String email = txtEmail.getText();
        String soDienThoai = txtSoDienThoai.getText();
        String diaChi = txtDiaChi.getText();
        String matKhau = new String(txtMatKhau.getPassword());
        String xacNhanMatKhau = new String(txtXacNhanMatKhau.getPassword());
        String ngaySinhStr = txtNgaySinh.getText();
        boolean dongY = cbDongY.isSelected();
        
        // Validate
        boolean isValid = true;
        
        String error = RegisterFormValidator.validateMaKhachHang(maKhachHang);
        if (error != null) {
            errorLabels.get("maKhachHang").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateHoTen(hoTen);
        if (error != null) {
            errorLabels.get("hoTen").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateEmail(email);
        if (error != null) {
            errorLabels.get("email").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateSoDienThoai(soDienThoai);
        if (error != null) {
            errorLabels.get("soDienThoai").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateDiaChi(diaChi);
        if (error != null) {
            errorLabels.get("diaChi").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateMatKhau(matKhau);
        if (error != null) {
            errorLabels.get("matKhau").setText(error);
            isValid = false;
        }
        
        error = RegisterFormValidator.validateXacNhanMatKhau(matKhau, xacNhanMatKhau);
        if (error != null) {
            errorLabels.get("xacNhanMatKhau").setText(error);
            isValid = false;
        }
        
        LocalDate ngaySinh = null;
        if (!ngaySinhStr.isEmpty()) {
            try {
                ngaySinh = LocalDate.parse(ngaySinhStr, java.time.format.DateTimeFormatter.ofPattern("MM/dd/yyyy"));
                error = RegisterFormValidator.validateNgaySinh(ngaySinh);
                if (error != null) {
                    errorLabels.get("ngaySinh").setText(error);
                    isValid = false;
                }
            } catch (DateTimeParseException e) {
                errorLabels.get("ngaySinh").setText("Ngày sinh không hợp lệ (mm/dd/yyyy)");
                isValid = false;
            }
        }
        
        error = RegisterFormValidator.validateDongYDieuKhoan(dongY);
        if (error != null) {
            errorLabels.get("dongY").setText(error);
            isValid = false;
        }
        
        if (isValid) {
            String gioiTinh = null;
            if (rbNam.isSelected()) {
                gioiTinh = "Nam";
            } else if (rbNu.isSelected()) {
                gioiTinh = "Nữ";
            } else if (rbKhac.isSelected()) {
                gioiTinh = "Khác";
            }
            
            // Lưu vào database
            if (DatabaseService.insertKhachHang(maKhachHang, hoTen, email, soDienThoai, diaChi, matKhau, ngaySinh, gioiTinh, dongY)) {
                lblSuccessMessage.setText("Đăng ký tài khoản thành công!");
                handleReset();
            } else {
                JOptionPane.showMessageDialog(this, "Lỗi: Không thể lưu tài khoản", "Lỗi", JOptionPane.ERROR_MESSAGE);
            }
        }
    }
    
    private void handleReset() {
        txtMaKhachHang.setText("");
        txtHoTen.setText("");
        txtEmail.setText("");
        txtSoDienThoai.setText("");
        txtDiaChi.setText("");
        txtMatKhau.setText("");
        txtXacNhanMatKhau.setText("");
        txtNgaySinh.setText("");
        
        ButtonGroup groupGioiTinh = new ButtonGroup();
        groupGioiTinh.clearSelection();
        rbNam.setSelected(false);
        rbNu.setSelected(false);
        rbKhac.setSelected(false);
        
        cbDongY.setSelected(false);
        
        clearErrors();
        lblSuccessMessage.setText("");
    }
    
    private void clearErrors() {
        for (JLabel errorLabel : errorLabels.values()) {
            errorLabel.setText("");
        }
    }
    
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            RegisterFrame frame = new RegisterFrame();
            frame.setVisible(true);
        });
    }
}
