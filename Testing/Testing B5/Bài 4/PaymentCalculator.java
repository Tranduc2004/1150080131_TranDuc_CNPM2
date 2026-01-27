import javax.swing.*;
import javax.swing.border.EmptyBorder;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class PaymentCalculator extends JFrame {
    private JCheckBox maleCheckBox;
    private JCheckBox femaleCheckBox;
    private JCheckBox childCheckBox;
    private JTextField ageTextField;
    private JTextField paymentTextField;
    private JButton calculateButton;
    
    public PaymentCalculator() {
        setTitle("Payment Calculator");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(500, 400);
        setLocationRelativeTo(null);
        
        initComponents();
    }
    
    private void initComponents() {
        JPanel mainPanel = new JPanel();
        mainPanel.setLayout(new BorderLayout(10, 10));
        mainPanel.setBorder(new EmptyBorder(20, 20, 20, 20));
        
        // Title panel
        JPanel titlePanel = new JPanel();
        titlePanel.setBackground(new Color(173, 216, 230));
        JLabel titleLabel = new JLabel("Calculate the Payment for the Patient");
        titleLabel.setFont(new Font("Arial", Font.BOLD, 16));
        titlePanel.add(titleLabel);
        
        // Form panel
        JPanel formPanel = new JPanel();
        formPanel.setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();
        gbc.insets = new Insets(5, 5, 5, 5);
        gbc.anchor = GridBagConstraints.WEST;
        
        // Gender checkboxes
        maleCheckBox = new JCheckBox("Male");
        femaleCheckBox = new JCheckBox("Female");
        childCheckBox = new JCheckBox("Child (0 - 17 years)");
        
        ButtonGroup genderGroup = new ButtonGroup();
        genderGroup.add(maleCheckBox);
        genderGroup.add(femaleCheckBox);
        genderGroup.add(childCheckBox);
        
        gbc.gridx = 0;
        gbc.gridy = 0;
        gbc.gridwidth = 3;
        formPanel.add(maleCheckBox, gbc);
        
        gbc.gridy = 1;
        formPanel.add(femaleCheckBox, gbc);
        
        gbc.gridy = 2;
        formPanel.add(childCheckBox, gbc);
        
        // Age input
        gbc.gridy = 3;
        gbc.gridwidth = 1;
        JLabel ageLabel = new JLabel("Age (Years)");
        formPanel.add(ageLabel, gbc);
        
        gbc.gridx = 1;
        ageTextField = new JTextField(15);
        formPanel.add(ageTextField, gbc);
        
        gbc.gridx = 2;
        calculateButton = new JButton("Calculate");
        formPanel.add(calculateButton, gbc);
        
        // Payment output
        gbc.gridx = 0;
        gbc.gridy = 4;
        JLabel paymentLabel = new JLabel("Payment is");
        formPanel.add(paymentLabel, gbc);
        
        gbc.gridx = 1;
        paymentTextField = new JTextField(15);
        paymentTextField.setEditable(false);
        formPanel.add(paymentTextField, gbc);
        
        gbc.gridx = 2;
        JLabel euroLabel = new JLabel("euro €");
        formPanel.add(euroLabel, gbc);
        
        // Add action listener to calculate button
        calculateButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                calculatePayment();
            }
        });
        
        mainPanel.add(titlePanel, BorderLayout.NORTH);
        mainPanel.add(formPanel, BorderLayout.CENTER);
        
        add(mainPanel);
    }
    
    private void calculatePayment() {
        try {
            String ageText = ageTextField.getText().trim();
            
            if (ageText.isEmpty()) {
                JOptionPane.showMessageDialog(this, 
                    "Please enter age!", 
                    "Error", 
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            int age = Integer.parseInt(ageText);
            
            if (age < 0 || age > 145) {
                JOptionPane.showMessageDialog(this, 
                    "Age must be between 0 and 145!", 
                    "Error", 
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            if (!maleCheckBox.isSelected() && !femaleCheckBox.isSelected() && !childCheckBox.isSelected()) {
                JOptionPane.showMessageDialog(this, 
                    "Please select gender/type!", 
                    "Error", 
                    JOptionPane.ERROR_MESSAGE);
                return;
            }
            
            int payment = calculatePaymentAmount(age);
            paymentTextField.setText(String.valueOf(payment));
            
        } catch (NumberFormatException ex) {
            JOptionPane.showMessageDialog(this, 
                "Please enter a valid number for age!", 
                "Error", 
                JOptionPane.ERROR_MESSAGE);
        }
    }
    
    public int calculatePaymentAmount(int age) {
        if (childCheckBox.isSelected()) {
            if (age >= 0 && age <= 17) {
                return 50;
            } else {
                throw new IllegalArgumentException("Child age must be between 0 and 17");
            }
        } else if (maleCheckBox.isSelected()) {
            if (age >= 18 && age <= 35) {
                return 100;
            } else if (age >= 36 && age <= 50) {
                return 120;
            } else if (age >= 51 && age <= 145) {
                return 140;
            }
        } else if (femaleCheckBox.isSelected()) {
            if (age >= 18 && age <= 35) {
                return 80;
            } else if (age >= 36 && age <= 50) {
                return 110;
            } else if (age >= 51 && age <= 145) {
                return 140;
            }
        }
        
        throw new IllegalArgumentException("Invalid age or gender selection");
    }
    
    public static void main(String[] args) {
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                new PaymentCalculator().setVisible(true);
            }
        });
    }
}
