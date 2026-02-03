package fploy.ui;

import fploy.dao.OrganizationDAO;
import fploy.dao.OrganizationUnitDAO;
import fploy.model.Organization;
import fploy.model.OrganizationUnit;

import javax.swing.*;
import java.awt.*;
import java.sql.SQLException;
import java.util.List;

public class AddOrganizationUnitForm extends JFrame {
    private JTextField txtUnitId;
    private JTextField txtUnitName;
    private JTextArea txtDescription;
    private JComboBox<Organization> cboOrganization;
    private JButton btnSave;
    private JButton btnCancel;
    
    private OrganizationUnitDAO unitDAO;
    private OrganizationDAO orgDAO;

    public AddOrganizationUnitForm() {
        unitDAO = new OrganizationUnitDAO();
        orgDAO = new OrganizationDAO();
        
        initComponents();
        loadOrganizations();
    }

    private void initComponents() {
        setTitle("Add Organization Unit");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(500, 450);
        setLocationRelativeTo(null);
        setLayout(new BorderLayout(10, 10));

        // Header
        JPanel headerPanel = new JPanel();
        headerPanel.setBackground(new Color(70, 130, 180));
        JLabel lblTitle = new JLabel("Add Organization Unit");
        lblTitle.setFont(new Font("Arial", Font.BOLD, 18));
        lblTitle.setForeground(Color.WHITE);
        headerPanel.add(lblTitle);
        add(headerPanel, BorderLayout.NORTH);

        // Form Panel
        JPanel formPanel = new JPanel(new GridBagLayout());
        formPanel.setBorder(BorderFactory.createEmptyBorder(20, 20, 20, 20));
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.insets = new Insets(5, 5, 5, 5);

        // Unit Id
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.weightx = 0;
        formPanel.add(new JLabel("Unit Id"), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        txtUnitId = new JTextField(20);
        formPanel.add(txtUnitId, gbc);

        // Name
        gbc.gridx = 0;
        gbc.gridy = 1;
        gbc.weightx = 0;
        JLabel lblName = new JLabel("Name*");
        lblName.setForeground(Color.RED);
        formPanel.add(lblName, gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        txtUnitName = new JTextField(20);
        formPanel.add(txtUnitName, gbc);

        // Description
        gbc.gridx = 0;
        gbc.gridy = 2;
        gbc.weightx = 0;
        gbc.anchor = GridBagConstraints.NORTHWEST;
        formPanel.add(new JLabel("Description"), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        gbc.weighty = 1;
        gbc.fill = GridBagConstraints.BOTH;
        txtDescription = new JTextArea(5, 20);
        txtDescription.setLineWrap(true);
        txtDescription.setWrapStyleWord(true);
        txtDescription.setBorder(BorderFactory.createLineBorder(Color.GRAY));
        JScrollPane scrollPane = new JScrollPane(txtDescription);
        formPanel.add(scrollPane, gbc);

        // Organization
        gbc.gridx = 0;
        gbc.gridy = 3;
        gbc.weightx = 0;
        gbc.weighty = 0;
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.anchor = GridBagConstraints.CENTER;
        formPanel.add(new JLabel("This unit will be added under"), gbc);

        gbc.gridx = 1;
        gbc.weightx = 1;
        cboOrganization = new JComboBox<>();
        formPanel.add(cboOrganization, gbc);

        // Required note
        gbc.gridx = 0;
        gbc.gridy = 4;
        gbc.gridwidth = 2;
        JLabel lblRequired = new JLabel("* Required");
        lblRequired.setForeground(Color.RED);
        lblRequired.setFont(new Font("Arial", Font.ITALIC, 10));
        formPanel.add(lblRequired, gbc);

        add(formPanel, BorderLayout.CENTER);

        // Button Panel
        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.RIGHT, 10, 10));
        
        btnCancel = new JButton("Cancel");
        btnCancel.setPreferredSize(new Dimension(100, 35));
        btnCancel.setBackground(Color.WHITE);
        btnCancel.setBorder(BorderFactory.createLineBorder(Color.GRAY));
        btnCancel.addActionListener(e -> clearForm());

        btnSave = new JButton("Save");
        btnSave.setPreferredSize(new Dimension(100, 35));
        btnSave.setBackground(new Color(144, 238, 144));
        btnSave.setForeground(Color.WHITE);
        btnSave.setBorder(BorderFactory.createEmptyBorder());
        btnSave.addActionListener(e -> saveOrganizationUnit());

        buttonPanel.add(btnCancel);
        buttonPanel.add(btnSave);
        add(buttonPanel, BorderLayout.SOUTH);
    }

    private void loadOrganizations() {
        try {
            List<Organization> organizations = orgDAO.getAllOrganizations();
            for (Organization org : organizations) {
                cboOrganization.addItem(org);
            }
        } catch (SQLException e) {
            showError("Error loading organizations: " + e.getMessage());
        }
    }

    private void saveOrganizationUnit() {
        // Validation
        String unitId = txtUnitId.getText().trim();
        String unitName = txtUnitName.getText().trim();
        String description = txtDescription.getText().trim();
        Organization selectedOrg = (Organization) cboOrganization.getSelectedItem();

        // Validate Unit Id
        if (unitId.isEmpty()) {
            showError("Unit Id is required");
            txtUnitId.requestFocus();
            return;
        }

        // Validate Name
        if (unitName.isEmpty()) {
            showError("Name is required");
            txtUnitName.requestFocus();
            return;
        }

        // Validate Organization
        if (selectedOrg == null) {
            showError("Organization is required");
            return;
        }

        // Check Unit Id length
        if (unitId.length() > 50) {
            showError("Unit Id must be less than 50 characters");
            txtUnitId.requestFocus();
            return;
        }

        // Check Name length
        if (unitName.length() > 255) {
            showError("Name must be less than 255 characters");
            txtUnitName.requestFocus();
            return;
        }

        // Check for special characters in Unit Id
        if (!unitId.matches("^[a-zA-Z0-9]+$")) {
            showError("Unit Id contains invalid characters. Only letters and numbers are allowed.");
            txtUnitId.requestFocus();
            return;
        }

        try {
            // Check if Unit Id already exists
            if (unitDAO.isUnitIdExists(unitId)) {
                showError("Unit Id already exists");
                txtUnitId.requestFocus();
                return;
            }

            // Save to database
            OrganizationUnit unit = new OrganizationUnit(
                unitId,
                unitName,
                description,
                selectedOrg.getOrgId()
            );

            unitDAO.insertOrganizationUnit(unit);
            
            showSuccess("Unit added successfully");
            clearForm();

        } catch (SQLException e) {
            showError("Error saving unit: " + e.getMessage());
        }
    }

    private void clearForm() {
        txtUnitId.setText("");
        txtUnitName.setText("");
        txtDescription.setText("");
        if (cboOrganization.getItemCount() > 0) {
            cboOrganization.setSelectedIndex(0);
        }
        txtUnitId.requestFocus();
    }

    private void showError(String message) {
        JOptionPane.showMessageDialog(this, message, "Error", JOptionPane.ERROR_MESSAGE);
    }

    private void showSuccess(String message) {
        JOptionPane.showMessageDialog(this, message, "Success", JOptionPane.INFORMATION_MESSAGE);
    }
}
