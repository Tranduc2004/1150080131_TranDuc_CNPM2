-- SQL Server Script để tạo Database và Bảng cho Bài 5
-- ============================================
-- TẠO DATABASE (Nếu chưa có)
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'lab6_testing')
BEGIN
    CREATE DATABASE lab6_testing;
END
GO

USE lab6_testing;
GO

-- ============================================
-- TẠO BẢNG JOB_TITLE
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'job_title')
BEGIN
    CREATE TABLE job_title (
        job_id INT PRIMARY KEY IDENTITY(1,1),
        job_title VARCHAR(100) NOT NULL,
        job_description VARCHAR(400),
        job_specification_filename VARCHAR(255),
        job_specification_data VARBINARY(MAX),
        job_specification_size INT,
        note VARCHAR(400),
        created_date DATETIME DEFAULT GETDATE(),
        updated_date DATETIME DEFAULT GETDATE()
    );
END
GO

-- ============================================
-- XÓA DỮ LIỆU CŨ (NẾU CÓ)
-- ============================================
DELETE FROM job_title;
GO

-- ============================================
-- CHÈN DỮ LIỆU MẪU
-- ============================================
INSERT INTO job_title (job_title, job_description, note) VALUES
('Software Developer', 'Develop and maintain software applications', 'Full-time position'),
('Project Manager', 'Manage project timeline and resources', 'Senior level'),
('Data Analyst', 'Analyze business data and create reports', 'Junior level');
GO

-- ============================================
-- KIỂM TRA DỮ LIỆU
-- ============================================
SELECT * FROM job_title;
GO

PRINT 'Database and table created successfully!';
PRINT 'Table: job_title';
PRINT 'Sample data: 3 job titles';
GO
