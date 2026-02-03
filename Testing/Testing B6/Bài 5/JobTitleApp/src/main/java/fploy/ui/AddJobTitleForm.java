package fploy.ui;

import fploy.dao.JobTitleDAO;
import fploy.model.JobTitle;

import javax.swing.*;
import javax.swing.filechooser.FileNameExtensionFilter;
import java.awt.*;
import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.sql.SQLException;

public class AddJobTitleForm extends JFrame {
    private JTextField txtJobTitle;
    private JTextArea txtJobDescription;
    private JTextField txtFilePath;
    private JButton btnBrowse;
    private JLabel lblFileInfo;
    private JTextArea txtNote;
    private JButton btnSave;
    private JButton btnCancel;
    
    private File selectedFile;
    private JobTitleDAO jobTitleDAO;
    
    public AddJobTitleForm() {
        jobTitleDAO = new JobTitleDAO();
        initComponents();
        setTitle("Add Job Title");
        setSize(600, 550);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    
    private void initComponents() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BorderLayout(10, 10));
        mainPanel.setBorder(BorderFactory.createEmptyBorder(15, 15, 15, 15));
        
        // Form Panel
        JPanel formPanel = new JPanel(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.fill = GridBagConstraints.HORIZONTAL;
        
        // Job Title (Required)
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.weightx = 0;
        JLabel lblJobTitle = new JLabel("Job Title: *");
        formPanel.add(lblJobTitle, gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        txtJobTitle = new JTextField(30);
        formPanel.add(txtJobTitle, gbc);
        
        // Job Description (Optional)
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.weightx = 0;
        formPanel.add(new JLabel("Job Description:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        gbc.fill = GridBagConstraints.BOTH;
        txtJobDescription = new JTextArea(4, 30);
        txtJobDescription.setLineWrap(true);
        txtJobDescription.setWrapStyleWord(true);
        JScrollPane scrollDescription = new JScrollPane(txtJobDescription);
        formPanel.add(scrollDescription, gbc);
        
        // Job Specification (File Upload)
        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.weightx = 0;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        formPanel.add(new JLabel("Job Specification:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        JPanel filePanel = new JPanel(new BorderLayout(5, 0));
        txtFilePath = new JTextField();
        txtFilePath.setEditable(false);
        btnBrowse = new JButton("Browse");
        btnBrowse.addActionListener(e -> browseFile());
        filePanel.add(txtFilePath, BorderLayout.CENTER);
        filePanel.add(btnBrowse, BorderLayout.EAST);
        formPanel.add(filePanel, gbc);
        
        // File Info Label
        gbc.gridx = 1;
        gbc.gridy = 3;
        lblFileInfo = new JLabel("Allowed up to 1MB");
        lblFileInfo.setFont(new Font("Arial", Font.ITALIC, 10));
        lblFileInfo.setForeground(Color.GRAY);
        formPanel.add(lblFileInfo, gbc);
        
        // Note (Optional)
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.weightx = 0;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        formPanel.add(new JLabel("Note:"), gbc);
        
        gbc.gridx = 1;
        gbc.weightx = 1;
        gbc.fill = GridBagConstraints.BOTH;
        txtNote = new JTextArea(4, 30);
        txtNote.setLineWrap(true);
        txtNote.setWrapStyleWord(true);
        JScrollPane scrollNote = new JScrollPane(txtNote);
        formPanel.add(scrollNote, gbc);
        
        mainPanel.add(formPanel, BorderLayout.CENTER);
        
        // Button Panel
        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        btnCancel = new JButton("Cancel");
        btnCancel.addActionListener(e -> clearForm());
        
        btnSave = new JButton("Save");
        btnSave.addActionListener(e -> saveJobTitle());
        
        buttonPanel.add(btnCancel);
        buttonPanel.add(btnSave);
        
        mainPanel.add(buttonPanel, BorderLayout.SOUTH);
        
        add(mainPanel);
    }
    
    private void browseFile() {
        JFileChooser fileChooser = new JFileChooser();
        fileChooser.setFileFilter(new FileNameExtensionFilter(
            "Document Files", "pdf", "doc", "docx", "txt"));
        
        int result = fileChooser.showOpenDialog(this);
        if (result == JFileChooser.APPROVE_OPTION) {
            selectedFile = fileChooser.getSelectedFile();
            txtFilePath.setText(selectedFile.getAbsolutePath());
            
            // Display file size
            long fileSizeKB = selectedFile.length() / 1024;
            lblFileInfo.setText(String.format("File size: %d KB", fileSizeKB));
            
            if (fileSizeKB > 1024) {
                lblFileInfo.setForeground(Color.RED);
            } else {
                lblFileInfo.setForeground(Color.GRAY);
            }
        }
    }
    
    private void saveJobTitle() {
        // Validate Job Title (Required)
        String jobTitle = txtJobTitle.getText().trim();
        if (jobTitle.isEmpty()) {
            JOptionPane.showMessageDialog(this,
                "Job Title is required!",
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            txtJobTitle.requestFocus();
            return;
        }
        
        // Validate Job Title length (max 100 characters)
        if (jobTitle.length() > 100) {
            JOptionPane.showMessageDialog(this,
                "Job Title must not exceed 100 characters!",
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            txtJobTitle.requestFocus();
            return;
        }
        
        // Check for duplicate Job Title
        try {
            if (jobTitleDAO.isDuplicateJobTitle(jobTitle)) {
                JOptionPane.showMessageDialog(this,
                    "Job Title already exists!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                txtJobTitle.requestFocus();
                return;
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(this,
                "Error checking duplicate: " + e.getMessage(),
                "Database Error",
                JOptionPane.ERROR_MESSAGE);
            return;
        }
        
        // Validate Job Description length (max 400 characters)
        String jobDescription = txtJobDescription.getText().trim();
        if (jobDescription.length() > 400) {
            JOptionPane.showMessageDialog(this,
                "Job Description must not exceed 400 characters!",
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            txtJobDescription.requestFocus();
            return;
        }
        
        // Validate file size (max 1024 KB = 1 MB)
        byte[] fileData = null;
        String filename = null;
        int fileSize = 0;
        
        if (selectedFile != null) {
            long fileSizeKB = selectedFile.length() / 1024;
            if (fileSizeKB > 1024) {
                JOptionPane.showMessageDialog(this,
                    "File size must not exceed 1024 KB (1 MB)!",
                    "Validation Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            try {
                fileData = Files.readAllBytes(selectedFile.toPath());
                filename = selectedFile.getName();
                fileSize = (int) selectedFile.length();
            } catch (IOException e) {
                JOptionPane.showMessageDialog(this,
                    "Error reading file: " + e.getMessage(),
                    "File Error",
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
        }
        
        // Validate Note length (max 400 characters)
        String note = txtNote.getText().trim();
        if (note.length() > 400) {
            JOptionPane.showMessageDialog(this,
                "Note must not exceed 400 characters!",
                "Validation Error",
                JOptionPane.ERROR_MESSAGE);
            txtNote.requestFocus();
            return;
        }
        
        // Create JobTitle object
        JobTitle newJobTitle = new JobTitle(
            jobTitle,
            jobDescription.isEmpty() ? null : jobDescription,
            filename,
            fileData,
            fileSize,
            note.isEmpty() ? null : note
        );
        
        // Save to database
        try {
            boolean success = jobTitleDAO.addJobTitle(newJobTitle);
            if (success) {
                JOptionPane.showMessageDialog(this,
                    "Job Title added successfully!",
                    "Success",
                    JOptionPane.INFORMATION_MESSAGE);
                clearForm();
            } else {
                JOptionPane.showMessageDialog(this,
                    "Failed to add Job Title!",
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
    
    private void clearForm() {
        txtJobTitle.setText("");
        txtJobDescription.setText("");
        txtFilePath.setText("");
        txtNote.setText("");
        selectedFile = null;
        lblFileInfo.setText("Allowed up to 1MB");
        lblFileInfo.setForeground(Color.GRAY);
    }
}
