package fploy.dao;

import fploy.model.Organization;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class OrganizationDAO {
    
    public List<Organization> getAllOrganizations() throws SQLException {
        List<Organization> organizations = new ArrayList<>();
        String query = "SELECT org_id, org_name, org_description FROM organization ORDER BY org_name";
        
        try (Connection conn = DatabaseConnection.getConnection();
             Statement stmt = conn.createStatement();
             ResultSet rs = stmt.executeQuery(query)) {
            
            while (rs.next()) {
                Organization org = new Organization(
                    rs.getInt("org_id"),
                    rs.getString("org_name"),
                    rs.getString("org_description")
                );
                organizations.add(org);
            }
        }
        
        return organizations;
    }
}
