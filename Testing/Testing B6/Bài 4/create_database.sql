-- SQL Server Script để tạo Database và Bảng cho Bài 4
-- ============================================
-- TẠO DATABASE
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'lab6_testing')
BEGIN
    CREATE DATABASE lab6_testing;
END
GO

USE lab6_testing;
GO

-- ============================================
-- TẠO BẢNG ORGANIZATION
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'organization')
BEGIN
    CREATE TABLE organization (
        org_id INT PRIMARY KEY IDENTITY(1,1),
        org_name VARCHAR(255) NOT NULL UNIQUE,
        org_description TEXT,
        created_date DATETIME DEFAULT GETDATE(),
        updated_date DATETIME DEFAULT GETDATE()
    );
END
GO

-- ============================================
-- TẠO BẢNG ORGANIZATION UNIT
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'organization_unit')
BEGIN
    CREATE TABLE organization_unit (
        unit_id VARCHAR(50) PRIMARY KEY,
        unit_name VARCHAR(255) NOT NULL,
        unit_description TEXT,
        org_id INT NOT NULL,
        created_date DATETIME DEFAULT GETDATE(),
        updated_date DATETIME DEFAULT GETDATE(),
        FOREIGN KEY (org_id) REFERENCES organization(org_id) ON DELETE CASCADE
    );
END
GO

-- ============================================
-- XÓA DỮ LIỆU CŨ (NẾU CÓ)
-- ============================================
DELETE FROM organization_unit;
DELETE FROM organization;
GO

-- ============================================
-- CHÈN DỮ LIỆU MẪU VÀO ORGANIZATION
-- ============================================
INSERT INTO organization (org_name, org_description) VALUES
('FPoly', 'FPT Polytechnic - Cơ sở đào tạo'),
('Microsoft', 'Microsoft Corporation'),
('Google', 'Google LLC');
GO

-- ============================================
-- CHÈN DỮ LIỆU MẫU VÀO ORGANIZATION_UNIT
-- ============================================
INSERT INTO organization_unit (unit_id, unit_name, unit_description, org_id) VALUES
('IT001', 'IT Department', 'Phòng IT', 1),
('HR001', 'Human Resource', 'Phòng Nhân sự', 1),
('ACC001', 'Accounting', 'Phòng Kế toán', 1);
GO

-- ============================================
-- KIỂM TRA DỮ LIỆU ĐÃ TẠO
-- ============================================
SELECT * FROM organization;
SELECT * FROM organization_unit;
GO
