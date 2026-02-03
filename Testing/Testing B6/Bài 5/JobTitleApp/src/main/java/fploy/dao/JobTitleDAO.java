package fploy.dao;

import fploy.db.DatabaseConnection;
import fploy.model.JobTitle;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class JobTitleDAO {
    
    public boolean addJobTitle(JobTitle jobTitle) throws SQLException {
        String sql = "INSERT INTO job_title (job_title, job_description, job_specification_filename, " +
                     "job_specification_data, job_specification_size, note) VALUES (?, ?, ?, ?, ?, ?)";
        
        Connection conn = null;
        PreparedStatement pstmt = null;
        
        try {
            conn = DatabaseConnection.getConnection();
            pstmt = conn.prepareStatement(sql);
            
            pstmt.setString(1, jobTitle.getJobTitle());
            pstmt.setString(2, jobTitle.getJobDescription());
            pstmt.setString(3, jobTitle.getJobSpecificationFilename());
            
            if (jobTitle.getJobSpecificationData() != null) {
                pstmt.setBytes(4, jobTitle.getJobSpecificationData());
            } else {
                pstmt.setNull(4, Types.VARBINARY);
            }
            
            pstmt.setInt(5, jobTitle.getJobSpecificationSize());
            pstmt.setString(6, jobTitle.getNote());
            
            int rowsAffected = pstmt.executeUpdate();
            return rowsAffected > 0;
            
        } finally {
            if (pstmt != null) pstmt.close();
            DatabaseConnection.closeConnection(conn);
        }
    }
    
    public List<JobTitle> getAllJobTitles() throws SQLException {
        String sql = "SELECT * FROM job_title ORDER BY created_at DESC";
        List<JobTitle> jobTitles = new ArrayList<>();
        
        Connection conn = null;
        Statement stmt = null;
        ResultSet rs = null;
        
        try {
            conn = DatabaseConnection.getConnection();
            stmt = conn.createStatement();
            rs = stmt.executeQuery(sql);
            
            while (rs.next()) {
                JobTitle jobTitle = new JobTitle();
                jobTitle.setJobId(rs.getInt("job_id"));
                jobTitle.setJobTitle(rs.getString("job_title"));
                jobTitle.setJobDescription(rs.getString("job_description"));
                jobTitle.setJobSpecificationFilename(rs.getString("job_specification_filename"));
                jobTitle.setJobSpecificationData(rs.getBytes("job_specification_data"));
                jobTitle.setJobSpecificationSize(rs.getInt("job_specification_size"));
                jobTitle.setNote(rs.getString("note"));
                jobTitle.setCreatedAt(rs.getTimestamp("created_at"));
                jobTitle.setUpdatedAt(rs.getTimestamp("updated_at"));
                
                jobTitles.add(jobTitle);
            }
            
            return jobTitles;
            
        } finally {
            if (rs != null) rs.close();
            if (stmt != null) stmt.close();
            DatabaseConnection.closeConnection(conn);
        }
    }
    
    public boolean isDuplicateJobTitle(String jobTitle) throws SQLException {
        String sql = "SELECT COUNT(*) FROM job_title WHERE job_title = ?";
        
        Connection conn = null;
        PreparedStatement pstmt = null;
        ResultSet rs = null;
        
        try {
            conn = DatabaseConnection.getConnection();
            pstmt = conn.prepareStatement(sql);
            pstmt.setString(1, jobTitle);
            
            rs = pstmt.executeQuery();
            if (rs.next()) {
                return rs.getInt(1) > 0;
            }
            return false;
            
        } finally {
            if (rs != null) rs.close();
            if (pstmt != null) pstmt.close();
            DatabaseConnection.closeConnection(conn);
        }
    }
}
