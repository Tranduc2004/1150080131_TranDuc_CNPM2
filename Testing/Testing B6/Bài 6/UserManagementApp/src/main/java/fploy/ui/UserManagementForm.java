package fploy.ui;

import fploy.dao.UserDAO;
import fploy.model.User;

import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import java.awt.*;
import java.sql.SQLException;
import java.util.List;
import java.util.regex.Pattern;

public class UserManagementForm extends JFrame {
    private JTextField txtUsername;
    private JPasswordField txtPassword;
    private JTextField txtFullname;
    private JComboBox<String> cboRole;
    private JTextField txtEmail;
    
    private JButton btnCreate;
    private JButton btnUpdate;
    private JButton btnDelete;
    private JButton btnReset;
    
    private JTable tblUsers;
    private DefaultTableModel tableModel;
    
    private UserDAO userDAO;
    private int selectedUserId = -1;
    
    // Validation patterns
    private static final Pattern USERNAME_PATTERN = Pattern.compile("^[a-zA-Z0-9_]{3,50}$");
    private static final Pattern EMAIL_PATTERN = Pattern.compile("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$");
    
    public UserManagementForm() {
        userDAO = new UserDAO();
        initComponents();
        loadUsers();
        setTitle("User Management System - NGHIÊNHIM");
        setSize(900, 600);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    
    private void initComponents() {
        JPanel mainPanel = new JPanel(new BorderLayout(10, 10));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(15, 15, 15, 15));
        
        // Top Panel - Title
        JPanel titlePanel = new JPanel();
        JLabel lblTitle = new JLabel("NGHIÊNHIM - User Management");
        lblTitle.setFont(new Font("Arial", Font.BOLD, 20));
        titlePanel.add(lblTitle);
        mainPanel.add(titlePanel, BorderLayout.NORTH);
        
        // Center Panel - Split into Form and Table
        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT);
        splitPane.setDividerLocation(400);
        
        // Left Panel - Form
        JPanel formPanel = createFormPanel();
        splitPane.setLeftComponent(formPanel);
        
        // Right Panel - Table
        JPanel tablePanel = createTablePanel();
        splitPane.setRightComponent(tablePanel);
        
        mainPanel.add(splitPane, BorderLayout.CENTER);
        
        add(mainPanel);
    }
    
    private JPanel createFormPanel() {
        JPanel panel = new JPanel(new BorderLayout(10, 10));
        panel.setBorder(BorderFactory.createTitledBorder("USER EDITION"));
        
        // Form fields
        JPanel fieldsPanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(8, 8, 8, 8);
        gbc.fill = GridBagConstraints.HORIZONTAL;
        
        // Username
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.weightx = 0;
        fieldsPanel.add(new JLabel("Username:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        txtUsername = new JTextField(20);
        fieldsPanel.add(txtUsername, gbc);
        
        // Password
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.weightx = 0;
        fieldsPanel.add(new JLabel("Password:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        txtPassword = new JPasswordField(20);
        fieldsPanel.add(txtPassword, gbc);
        
        // Fullname
        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.weightx = 0;
        fieldsPanel.add(new JLabel("Fullname:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        txtFullname = new JTextField(20);
        fieldsPanel.add(txtFullname, gbc);
        
        // Role (Vai trò)
        gbc.gridx = 0;
        gbc.gridy = 3;
        gbc.weightx = 0;
        fieldsPanel.add(new JLabel("Vai trò:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        String[] roles = {"", "Admin", "User", "Manager", "Guest"};
        cboRole = new JComboBox<>(roles);
        fieldsPanel.add(cboRole, gbc);
        
        // Email
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.weightx = 0;
        fieldsPanel.add(new JLabel("Email:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        txtEmail = new JTextField(20);
        fieldsPanel.add(txtEmail, gbc);
        
        panel.add(fieldsPanel, BorderLayout.CENTER);
        
        // Button Panel
        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER, 10, 10));
        
        btnCreate = new JButton("Create");
        btnCreate.setBackground(new Color(52, 152, 219));
        btnCreate.setForeground(Color.WHITE);
        btnCreate.addActionListener(e -> createUser());
        
        btnUpdate = new JButton("Update");
        btnUpdate.setBackground(new Color(46, 204, 113));
        btnUpdate.setForeground(Color.WHITE);
        btnUpdate.addActionListener(e -> updateUser());
        
        btnDelete = new JButton("Delete");
        btnDelete.setBackground(new Color(231, 76, 60));
        btnDelete.setForeground(Color.WHITE);
        btnDelete.addActionListener(e -> deleteUser());
        
        btnReset = new JButton("Reset");
        btnReset.setBackground(new Color(241, 196, 15));
        btnReset.setForeground(Color.WHITE);
        btnReset.addActionListener(e -> resetForm());
        
        buttonPanel.add(btnCreate);
        buttonPanel.add(btnUpdate);
        buttonPanel.add(btnDelete);
        buttonPanel.add(btnReset);
        
        panel.add(buttonPanel, BorderLayout.SOUTH);
        
        return panel;
    }
    
    private JPanel createTablePanel() {
        JPanel panel = new JPanel(new BorderLayout(5, 5));
        panel.setBorder(BorderFactory.createTitledBorder("USER LIST"));
        
        // Create table
        String[] columns = {"ID", "Username", "Password", "Fullname", "Role", "Email"};
        tableModel = new DefaultTableModel(columns, 0) {
            @Override
            public boolean isCellEditable(int row, int column) {
                return false;
            }
        };
        
        tblUsers = new JTable(tableModel);
        tblUsers.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
        tblUsers.getSelectionModel().addListSelectionListener(e -> {
            if (!e.getValueIsAdjusting()) {
                int selectedRow = tblUsers.getSelectedRow();
                if (selectedRow >= 0) {
                    loadUserToForm(selectedRow);
                }
            }
        });
        
        // Set column widths
        tblUsers.getColumnModel().getColumn(0).setPreferredWidth(40);
        tblUsers.getColumnModel().getColumn(1).setPreferredWidth(100);
        tblUsers.getColumnModel().getColumn(2).setPreferredWidth(80);
        tblUsers.getColumnModel().getColumn(3).setPreferredWidth(150);
        tblUsers.getColumnModel().getColumn(4).setPreferredWidth(80);
        tblUsers.getColumnModel().getColumn(5).setPreferredWidth(150);
        
        JScrollPane scrollPane = new JScrollPane(tblUsers);
        panel.add(scrollPane, BorderLayout.CENTER);
        
        return panel;
    }
    
    private void loadUsers() {
        try {
            List<User> users = userDAO.getAllUsers();
            tableModel.setRowCount(0);
            
            for (User user : users) {
                Object[] row = {
                    user.getUserId(),
                    user.getUsername(),
                    "***",  // Hide password
                    user.getFullname(),
                    user.getRole(),
                    user.getEmail()
                };
                tableModel.addRow(row);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this,
                "Error loading users: " + e.getMessage(),
                "Database Error",
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    private void loadUserToForm(int rowIndex) {
        selectedUserId = (int) tableModel.getValueAt(rowIndex, 0);
        txtUsername.setText((String) tableModel.getValueAt(rowIndex, 1));
        
        // Get actual password from database
        try {
            List<User> users = userDAO.getAllUsers();
            for (User user : users) {
                if (user.getUserId() == selectedUserId) {
                    txtPassword.setText(user.getPassword());
                    break;
                }
            }
        } catch (SQLException e) {
            txtPassword.setText("");
        }
        
        txtFullname.setText((String) tableModel.getValueAt(rowIndex, 3));
        cboRole.setSelectedItem((String) tableModel.getValueAt(rowIndex, 4));
        txtEmail.setText((String) tableModel.getValueAt(rowIndex, 5));
    }
    
    private void createUser() {
        // Validate input
        String validationError = validateInput();
        if (validationError != null) {
            JOptionPane.showMessageDialog(this,
                validationError,
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        String username = txtUsername.getText().trim();
        String password = new String(txtPassword.getPassword());
        String fullname = txtFullname.getText().trim();
        String role = (String) cboRole.getSelectedItem();
        String email = txtEmail.getText().trim();
        
        // Check duplicate username
        try {
            if (userDAO.isDuplicateUsername(username, 0)) {
                JOptionPane.showMessageDialog(this,
                    "Username already exists!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            // Check duplicate email
            if (userDAO.isDuplicateEmail(email, 0)) {
                JOptionPane.showMessageDialog(this,
                    "Email already exists!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            // Create user
            User user = new User(username, password, fullname, role, email);
            boolean success = userDAO.addUser(user);
            
            if (success) {
                JOptionPane.showMessageDialog(this,
                    "User created successfully!",
                    "Success",
                    JOptionPane.INFORMATION_MESSAGE);
                resetForm();
                loadUsers();
            } else {
                JOptionPane.showMessageDialog(this,
                    "Failed to create user!",
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this,
                "Database error: " + e.getMessage(),
                "Error",
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    private void updateUser() {
        if (selectedUserId == -1) {
            JOptionPane.showMessageDialog(this,
                "Please select a user to update!",
                "No Selection",
                JOptionPane.WARNING_MESSAGE);
            return;
        }
        
        // Validate input
        String validationError = validateInput();
        if (validationError != null) {
            JOptionPane.showMessageDialog(this,
                validationError,
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        String username = txtUsername.getText().trim();
        String password = new String(txtPassword.getPassword());
        String fullname = txtFullname.getText().trim();
        String role = (String) cboRole.getSelectedItem();
        String email = txtEmail.getText().trim();
        
        try {
            // Check duplicate username (excluding current user)
            if (userDAO.isDuplicateUsername(username, selectedUserId)) {
                JOptionPane.showMessageDialog(this,
                    "Username already exists!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            // Check duplicate email (excluding current user)
            if (userDAO.isDuplicateEmail(email, selectedUserId)) {
                JOptionPane.showMessageDialog(this,
                    "Email already exists!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            // Update user
            User user = new User(username, password, fullname, role, email);
            user.setUserId(selectedUserId);
            
            boolean success = userDAO.updateUser(user);
            
            if (success) {
                JOptionPane.showMessageDialog(this,
                    "User updated successfully!",
                    "Success",
                    JOptionPane.INFORMATION_MESSAGE);
                resetForm();
                loadUsers();
            } else {
                JOptionPane.showMessageDialog(this,
                    "Failed to update user!",
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this,
                "Database error: " + e.getMessage(),
                "Error",
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    private void deleteUser() {
        if (selectedUserId == -1) {
            JOptionPane.showMessageDialog(this,
                "Please select a user to delete!",
                "No Selection",
                JOptionPane.WARNING_MESSAGE);
            return;
        }
        
        int confirm = JOptionPane.showConfirmDialog(this,
            "Are you sure you want to delete this user?",
            "Confirm Delete",
            JOptionPane.YES_NO_OPTION,
            JOptionPane.WARNING_MESSAGE);
        
        if (confirm == JOptionPane.YES_OPTION) {
            try {
                boolean success = userDAO.deleteUser(selectedUserId);
                
                if (success) {
                    JOptionPane.showMessageDialog(this,
                        "User deleted successfully!",
                        "Success",
                        JOptionPane.INFORMATION_MESSAGE);
                    resetForm();
                    loadUsers();
                } else {
                    JOptionPane.showMessageDialog(this,
                        "Failed to delete user!",
                        "Error",
                        JOptionPane.ERROR_MESSAGE);
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(this,
                    "Database error: " + e.getMessage(),
                    "Error",
                    JOptionPane.ERROR_MESSAGE);
            }
        }
    }
    
    private void resetForm() {
        txtUsername.setText("");
        txtPassword.setText("");
        txtFullname.setText("");
        cboRole.setSelectedIndex(0);
        txtEmail.setText("");
        selectedUserId = -1;
        tblUsers.clearSelection();
    }
    
    private String validateInput() {
        String username = txtUsername.getText().trim();
        String password = new String(txtPassword.getPassword());
        String fullname = txtFullname.getText().trim();
        String role = (String) cboRole.getSelectedItem();
        String email = txtEmail.getText().trim();
        
        // Username validation
        if (username.isEmpty()) {
            return "Username is required!";
        }
        if (!USERNAME_PATTERN.matcher(username).matches()) {
            if (username.length() < 3 || username.length() > 50) {
                return "Username must be 3-50 characters!";
            }
            return "Username can only contain letters, numbers, underscores!";
        }
        
        // Password validation
        if (password.isEmpty()) {
            return "Password is required!";
        }
        if (password.length() < 3) {
            return "Password must be at least 3 characters!";
        }
        if (password.length() > 100) {
            return "Password must not exceed 100 characters!";
        }
        
        // Fullname validation
        if (fullname.isEmpty()) {
            return "Fullname is required!";
        }
        if (fullname.length() > 100) {
            return "Fullname must not exceed 100 characters!";
        }
        
        // Role validation
        if (role == null || role.isEmpty()) {
            return "Role is required!";
        }
        
        // Email validation
        if (email.isEmpty()) {
            return "Email is required!";
        }
        if (!EMAIL_PATTERN.matcher(email).matches()) {
            return "Invalid email format!";
        }
        
        return null;
    }
}
