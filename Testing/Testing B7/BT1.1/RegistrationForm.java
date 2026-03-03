import javax.swing.BorderFactory;
import javax.swing.BoxLayout;
import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JRadioButton;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.SwingUtilities;
import javax.swing.UIManager;
import javax.swing.WindowConstants;
import javax.swing.event.DocumentEvent;
import javax.swing.event.DocumentListener;
import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.time.DateTimeException;
import java.time.LocalDate;
import java.time.Period;
import java.time.format.DateTimeFormatter;
import java.util.LinkedHashSet;
import java.util.Set;
import java.util.regex.Pattern;

public class RegistrationForm extends JFrame {
    private final JTextField fullNameField = new JTextField(24);
    private final JTextField usernameField = new JTextField(24);
    private final JTextField emailField = new JTextField(24);
    private final JTextField phoneField = new JTextField(24);
    private final JPasswordField passwordField = new JPasswordField(24);
    private final JPasswordField confirmPasswordField = new JPasswordField(24);
    private final JTextField dobField = new JTextField(24);
    private final JRadioButton maleRadio = new JRadioButton("Nam");
    private final JRadioButton femaleRadio = new JRadioButton("Nữ");
    private final JRadioButton noDiscloseRadio = new JRadioButton("Không muốn tiết lộ");
    private final JTextField referralCodeField = new JTextField(24);
    private final JCheckBox termsCheckBox = new JCheckBox("Tôi đồng ý với Điều khoản");
    private final JButton registerButton = new JButton("Đăng ký");
    private final JButton loginButton = new JButton("Đăng nhập");
    private final JButton termsLinkButton = new JButton("Xem Điều khoản");

    private static final Pattern FULL_NAME_PATTERN = Pattern.compile("^[\\p{L} ]{2,50}$");
    private static final Pattern USERNAME_PATTERN = Pattern.compile("^[a-z][a-z0-9_]{4,19}$");
    private static final Pattern EMAIL_PATTERN = Pattern.compile(
            "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$");
    private static final Pattern PHONE_PATTERN = Pattern.compile("^0\\d{9}$");
    private static final Pattern REFERRAL_CODE_PATTERN = Pattern.compile("^[A-Z0-9]{8}$");
    private static final DateTimeFormatter DOB_FORMATTER = DateTimeFormatter.ofPattern("dd/MM/yyyy");

    private static final Set<String> EXISTING_USERNAMES = new LinkedHashSet<>(Set.of("admin_01", "shopvn01", "tester_99"));
    private static final Set<String> EXISTING_EMAILS = new LinkedHashSet<>(Set.of("existing@shopvn.vn", "admin@shopvn.vn"));
    private static final Set<String> VALID_REFERRAL_CODES = Set.of("AB12CD34", "SHOP2026", "WELCOME1", "VNTEST01");

    public RegistrationForm() {
        setTitle("Form Đăng Ký Tài Khoản - ShopVN.vn");
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        setMinimumSize(new Dimension(760, 560));
        setLocationRelativeTo(null);

        JPanel root = new JPanel(new BorderLayout(10, 10));
        root.setBorder(BorderFactory.createEmptyBorder(12, 12, 12, 12));

        JLabel header = new JLabel("Form Đăng Ký Tài Khoản – ShopVN.vn");
        header.setFont(header.getFont().deriveFont(Font.BOLD, 20f));
        root.add(header, BorderLayout.NORTH);

        JPanel formPanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.anchor = GridBagConstraints.WEST;
        gbc.fill = GridBagConstraints.HORIZONTAL;

        int row = 0;
        addField(formPanel, gbc, row++, "Họ và tên (*)", fullNameField);
        addField(formPanel, gbc, row++, "Tên đăng nhập (*)", usernameField);
        addField(formPanel, gbc, row++, "Email (*)", emailField);
        addField(formPanel, gbc, row++, "Số điện thoại (*)", phoneField);
        addField(formPanel, gbc, row++, "Mật khẩu (*)", passwordField);
        addField(formPanel, gbc, row++, "Xác nhận mật khẩu (*)", confirmPasswordField);
        addField(formPanel, gbc, row++, "Ngày sinh", dobField);

        ButtonGroup genderGroup = new ButtonGroup();
        genderGroup.add(maleRadio);
        genderGroup.add(femaleRadio);
        genderGroup.add(noDiscloseRadio);

        JPanel genderPanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 8, 0));
        genderPanel.add(maleRadio);
        genderPanel.add(femaleRadio);
        genderPanel.add(noDiscloseRadio);
        addField(formPanel, gbc, row++, "Giới tính", genderPanel);

        addField(formPanel, gbc, row++, "Mã giới thiệu", referralCodeField);

        JPanel termsPanel = new JPanel(new FlowLayout(FlowLayout.LEFT, 8, 0));
        termsPanel.add(termsCheckBox);
        styleAsLink(termsLinkButton);
        termsPanel.add(termsLinkButton);
        addField(formPanel, gbc, row++, "Đồng ý Điều khoản (*)", termsPanel);

        JScrollPane scrollPane = new JScrollPane(formPanel);
        scrollPane.setBorder(BorderFactory.createEmptyBorder());
        root.add(scrollPane, BorderLayout.CENTER);

        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        registerButton.setEnabled(false);
        buttonPanel.add(loginButton);
        buttonPanel.add(registerButton);
        root.add(buttonPanel, BorderLayout.SOUTH);

        setContentPane(root);
        attachEvents();
    }

    private void addField(JPanel panel, GridBagConstraints gbc, int row, String labelText, java.awt.Component field) {
        gbc.gridx = 0;
        gbc.gridy = row;
        gbc.weightx = 0;
        JLabel label = new JLabel(labelText + ":");
        label.setPreferredSize(new Dimension(180, 28));
        panel.add(label, gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        panel.add(field, gbc);
    }

    private void attachEvents() {
        DocumentListener requiredFieldsListener = new DocumentListener() {
            @Override
            public void insertUpdate(DocumentEvent e) {
                updateRegisterButtonState();
            }

            @Override
            public void removeUpdate(DocumentEvent e) {
                updateRegisterButtonState();
            }

            @Override
            public void changedUpdate(DocumentEvent e) {
                updateRegisterButtonState();
            }
        };

        fullNameField.getDocument().addDocumentListener(requiredFieldsListener);
        usernameField.getDocument().addDocumentListener(requiredFieldsListener);
        emailField.getDocument().addDocumentListener(requiredFieldsListener);
        phoneField.getDocument().addDocumentListener(requiredFieldsListener);
        passwordField.getDocument().addDocumentListener(requiredFieldsListener);
        confirmPasswordField.getDocument().addDocumentListener(requiredFieldsListener);
        termsCheckBox.addActionListener(e -> updateRegisterButtonState());

        termsLinkButton.addActionListener(e -> showTermsPopup());
        registerButton.addActionListener(e -> submitForm());
        loginButton.addActionListener(e -> JOptionPane.showMessageDialog(
                this,
                "Chuyển sang trang đăng nhập.",
                "Đăng nhập",
                JOptionPane.INFORMATION_MESSAGE));
    }

    private void updateRegisterButtonState() {
        boolean requiredFilled = !fullNameField.getText().trim().isEmpty()
                && !usernameField.getText().trim().isEmpty()
                && !emailField.getText().trim().isEmpty()
                && !phoneField.getText().trim().isEmpty()
                && getPassword(passwordField).length() > 0
                && getPassword(confirmPasswordField).length() > 0
                && termsCheckBox.isSelected();
        registerButton.setEnabled(requiredFilled);
    }

    private void submitForm() {
        LinkedHashSet<String> errors = new LinkedHashSet<>();

        String fullName = fullNameField.getText().trim();
        String username = usernameField.getText().trim();
        String email = emailField.getText().trim();
        String phone = phoneField.getText().trim();
        String password = getPassword(passwordField);
        String confirmPassword = getPassword(confirmPasswordField);
        String dobText = dobField.getText().trim();
        String referralCode = referralCodeField.getText().trim();

        if (!FULL_NAME_PATTERN.matcher(fullName).matches()) {
            errors.add("Họ và tên: chỉ gồm chữ cái và dấu cách, độ dài 2–50 ký tự.");
        }

        if (!USERNAME_PATTERN.matcher(username).matches()) {
            errors.add("Tên đăng nhập: bắt đầu bằng chữ cái, chỉ gồm chữ thường/số/_ và dài 5–20 ký tự.");
        }
        if (EXISTING_USERNAMES.contains(username)) {
            errors.add("Tên đăng nhập đã tồn tại trong hệ thống.");
        }

        if (!EMAIL_PATTERN.matcher(email).matches()) {
            errors.add("Email không đúng định dạng chuẩn.");
        }
        if (EXISTING_EMAILS.contains(email.toLowerCase())) {
            errors.add("Email đã được đăng ký trong hệ thống.");
        }

        if (!PHONE_PATTERN.matcher(phone).matches()) {
            errors.add("Số điện thoại Việt Nam phải bắt đầu bằng 0 và gồm đúng 10 chữ số.");
        }

        if (!isValidPassword(password)) {
            errors.add("Mật khẩu phải dài 8–32, có ít nhất 1 chữ hoa, 1 chữ thường, 1 chữ số, 1 ký tự đặc biệt (!@#$%...).");
        }

        if (!password.equals(confirmPassword)) {
            errors.add("Xác nhận mật khẩu phải trùng khớp hoàn toàn với mật khẩu.");
        }

        if (!dobText.isEmpty()) {
            LocalDate dob = parseDateStrict(dobText);
            if (dob == null) {
                errors.add("Ngày sinh phải đúng định dạng dd/MM/yyyy.");
            } else {
                int age = Period.between(dob, LocalDate.now()).getYears();
                if (age < 16 || age >= 100) {
                    errors.add("Tuổi phải từ 16 đến dưới 100 tại ngày đăng ký.");
                }
            }
        }

        if (!referralCode.isEmpty()) {
            if (!REFERRAL_CODE_PATTERN.matcher(referralCode).matches()) {
                errors.add("Mã giới thiệu gồm đúng 8 ký tự in hoa và số.");
            } else if (!VALID_REFERRAL_CODES.contains(referralCode)) {
                errors.add("Mã giới thiệu không tồn tại trong CSDL.");
            }
        }

        if (!termsCheckBox.isSelected()) {
            errors.add("Bạn phải đồng ý Điều khoản.");
        }

        if (!errors.isEmpty()) {
            JOptionPane.showMessageDialog(
                    this,
                    String.join("\n", errors),
                    "Dữ liệu chưa hợp lệ",
                    JOptionPane.ERROR_MESSAGE);
            return;
        }

        EXISTING_USERNAMES.add(username);
        EXISTING_EMAILS.add(email.toLowerCase());
        JOptionPane.showMessageDialog(
                this,
                "Đăng ký thành công!",
                "Thành công",
                JOptionPane.INFORMATION_MESSAGE);
    }

    private LocalDate parseDateStrict(String text) {
        String[] parts = text.split("/");
        if (parts.length != 3) {
            return null;
        }

        try {
            int day = Integer.parseInt(parts[0]);
            int month = Integer.parseInt(parts[1]);
            int year = Integer.parseInt(parts[2]);
            LocalDate date = LocalDate.of(year, month, day);
            String normalized = date.format(DOB_FORMATTER);
            return normalized.equals(text) ? date : null;
        } catch (NumberFormatException | DateTimeException ex) {
            return null;
        }
    }

    private boolean isValidPassword(String password) {
        if (password.length() < 8 || password.length() > 32) {
            return false;
        }

        boolean hasUpper = false;
        boolean hasLower = false;
        boolean hasDigit = false;
        boolean hasSpecial = false;

        for (char ch : password.toCharArray()) {
            if (Character.isUpperCase(ch)) {
                hasUpper = true;
            } else if (Character.isLowerCase(ch)) {
                hasLower = true;
            } else if (Character.isDigit(ch)) {
                hasDigit = true;
            } else if ("!@#$%^&*()_+-=[]{}|;:'\",.<>/?`~".indexOf(ch) >= 0) {
                hasSpecial = true;
            }
        }

        return hasUpper && hasLower && hasDigit && hasSpecial;
    }

    private String getPassword(JPasswordField field) {
        return new String(field.getPassword()).trim();
    }

    private void showTermsPopup() {
        JTextArea textArea = new JTextArea(
                "ĐIỀU KHOẢN SỬ DỤNG SHOPVN\n\n"
                        + "1. Người dùng chịu trách nhiệm về thông tin đã đăng ký.\n"
                        + "2. Không sử dụng tài khoản cho mục đích vi phạm pháp luật.\n"
                        + "3. ShopVN có quyền tạm khóa tài khoản nếu phát hiện bất thường.\n"
                        + "4. Dữ liệu cá nhân được xử lý theo chính sách bảo mật hiện hành.");
        textArea.setEditable(false);
        textArea.setLineWrap(true);
        textArea.setWrapStyleWord(true);
        textArea.setBackground(UIManager.getColor("Panel.background"));

        JScrollPane pane = new JScrollPane(textArea);
        pane.setPreferredSize(new Dimension(430, 220));

        JOptionPane.showMessageDialog(
                this,
                pane,
                "Điều khoản",
                JOptionPane.INFORMATION_MESSAGE);
    }

    private void styleAsLink(JButton button) {
        button.setBorderPainted(false);
        button.setContentAreaFilled(false);
        button.setOpaque(false);
        button.setForeground(new Color(0, 102, 204));
        button.setFocusPainted(false);
    }

    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            RegistrationForm form = new RegistrationForm();
            form.setVisible(true);
        });
    }
}