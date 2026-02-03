package fploy.model;

import java.sql.Timestamp;

public class JobTitle {
    private int jobId;
    private String jobTitle;
    private String jobDescription;
    private String jobSpecificationFilename;
    private byte[] jobSpecificationData;
    private int jobSpecificationSize;
    private String note;
    private Timestamp createdAt;
    private Timestamp updatedAt;
    
    public JobTitle() {
    }
    
    public JobTitle(String jobTitle, String jobDescription, String jobSpecificationFilename, 
                    byte[] jobSpecificationData, int jobSpecificationSize, String note) {
        this.jobTitle = jobTitle;
        this.jobDescription = jobDescription;
        this.jobSpecificationFilename = jobSpecificationFilename;
        this.jobSpecificationData = jobSpecificationData;
        this.jobSpecificationSize = jobSpecificationSize;
        this.note = note;
    }
    
    // Getters and Setters
    public int getJobId() {
        return jobId;
    }
    
    public void setJobId(int jobId) {
        this.jobId = jobId;
    }
    
    public String getJobTitle() {
        return jobTitle;
    }
    
    public void setJobTitle(String jobTitle) {
        this.jobTitle = jobTitle;
    }
    
    public String getJobDescription() {
        return jobDescription;
    }
    
    public void setJobDescription(String jobDescription) {
        this.jobDescription = jobDescription;
    }
    
    public String getJobSpecificationFilename() {
        return jobSpecificationFilename;
    }
    
    public void setJobSpecificationFilename(String jobSpecificationFilename) {
        this.jobSpecificationFilename = jobSpecificationFilename;
    }
    
    public byte[] getJobSpecificationData() {
        return jobSpecificationData;
    }
    
    public void setJobSpecificationData(byte[] jobSpecificationData) {
        this.jobSpecificationData = jobSpecificationData;
    }
    
    public int getJobSpecificationSize() {
        return jobSpecificationSize;
    }
    
    public void setJobSpecificationSize(int jobSpecificationSize) {
        this.jobSpecificationSize = jobSpecificationSize;
    }
    
    public String getNote() {
        return note;
    }
    
    public void setNote(String note) {
        this.note = note;
    }
    
    public Timestamp getCreatedAt() {
        return createdAt;
    }
    
    public void setCreatedAt(Timestamp createdAt) {
        this.createdAt = createdAt;
    }
    
    public Timestamp getUpdatedAt() {
        return updatedAt;
    }
    
    public void setUpdatedAt(Timestamp updatedAt) {
        this.updatedAt = updatedAt;
    }
}
