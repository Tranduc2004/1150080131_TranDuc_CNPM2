-- Bài 6: User Management System
-- Database Schema for SQL Server

-- Create database (if not exists)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'lab6_testing')
BEGIN
    CREATE DATABASE lab6_testing;
END
GO

USE lab6_testing;
GO

-- Drop table if exists
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'users')
BEGIN
    DROP TABLE users;
END
GO

-- Create users table
CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    fullname NVARCHAR(100) NOT NULL,
    role VARCHAR(20) NOT NULL CHECK (role IN ('Admin', 'User', 'Manager', 'Guest')),
    email VARCHAR(100) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Create index for faster lookups
CREATE INDEX idx_username ON users(username);
CREATE INDEX idx_email ON users(email);
GO

-- Insert sample data
INSERT INTO users (username, password, fullname, role, email) VALUES
('admin', '123', N'Nguyễn Văn Admin', 'Admin', 'admin@gmail.com'),
('user01', '456', N'Trần Thị User', 'User', 'user01@gmail.com'),
('manager', '789', N'Lê Văn Manager', 'Manager', 'manager@gmail.com');
GO

-- Create trigger to update updated_at timestamp
CREATE TRIGGER trg_users_update
ON users
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE users
    SET updated_at = GETDATE()
    FROM users u
    INNER JOIN inserted i ON u.user_id = i.user_id;
END
GO

-- Verify data
SELECT * FROM users;
GO
