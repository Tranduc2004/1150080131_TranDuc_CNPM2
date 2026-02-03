package fploy.ui;

import javax.swing.*;

public class MainApp {
    public static void main(String[] args) {
        SwingUtilities.invokeLater(() -> {
            try {
                UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName());
            } catch (Exception e) {
                e.printStackTrace();
            }
            
            AddOrganizationUnitForm form = new AddOrganizationUnitForm();
            form.setVisible(true);
        });
    }
}
