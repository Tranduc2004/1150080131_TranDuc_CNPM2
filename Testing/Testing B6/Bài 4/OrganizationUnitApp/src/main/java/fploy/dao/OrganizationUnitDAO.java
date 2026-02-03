package fploy.dao;

import fploy.model.OrganizationUnit;

import java.sql.*;

public class OrganizationUnitDAO {
    
    public void insertOrganizationUnit(OrganizationUnit unit) throws SQLException {
        String query = "INSERT INTO organization_unit (unit_id, unit_name, unit_description, org_id) VALUES (?, ?, ?, ?)";
        
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement pstmt = conn.prepareStatement(query)) {
            
            pstmt.setString(1, unit.getUnitId());
            pstmt.setString(2, unit.getUnitName());
            pstmt.setString(3, unit.getUnitDescription());
            pstmt.setInt(4, unit.getOrgId());
            
            pstmt.executeUpdate();
        }
    }
    
    public boolean isUnitIdExists(String unitId) throws SQLException {
        String query = "SELECT COUNT(*) FROM organization_unit WHERE unit_id = ?";
        
        try (Connection conn = DatabaseConnection.getConnection();
             PreparedStatement pstmt = conn.prepareStatement(query)) {
            
            pstmt.setString(1, unitId);
            ResultSet rs = pstmt.executeQuery();
            
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
        }
        
        return false;
    }
}
