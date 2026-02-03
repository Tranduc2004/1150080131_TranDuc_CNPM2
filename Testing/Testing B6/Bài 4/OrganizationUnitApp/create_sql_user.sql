-- =========================================
-- TẠO SQL USER CHO ỨNG DỤNG
-- =========================================

-- Bước 1: Tạo Login
CREATE LOGIN testuser WITH PASSWORD = 'Test@123';
GO

-- Bước 2: Chuyển sang database
USE lab6_testing;
GO

-- Bước 3: Tạo User và cấp quyền
CREATE USER testuser FOR LOGIN testuser;
GO

-- Bước 4: Cấp quyền db_owner (full quyền trên database)
ALTER ROLE db_owner ADD MEMBER testuser;
GO

-- =========================================
-- KIỂM TRA
-- =========================================
SELECT 
    name AS LoginName,
    type_desc AS LoginType,
    create_date,
    is_disabled
FROM sys.server_principals
WHERE name = 'testuser';
GO

SELECT 
    dp.name AS UserName,
    dp.type_desc AS UserType,
    r.name AS RoleName
FROM sys.database_principals dp
LEFT JOIN sys.database_role_members drm ON dp.principal_id = drm.member_principal_id
LEFT JOIN sys.database_principals r ON drm.role_principal_id = r.principal_id
WHERE dp.name = 'testuser';
GO

PRINT 'SQL User created successfully!';
PRINT 'Username: testuser';
PRINT 'Password: Test@123';
GO
