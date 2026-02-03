# Cấu Hình SQL Server Authentication

## ❌ Lỗi: "This driver is not configured for integrated authentication"

**Nguyên nhân:** SQL Server driver không thể dùng Windows Authentication (Integrated Security).

**Giải pháp:** Đổi sang SQL Authentication với username/password.

---

## 🔧 Bước 1: Tạo SQL Login

### **Cách 1: SQL Server Management Studio (SSMS)**

1. Mở **SSMS**
2. Kết nối vào server `LAPTOP-KN5KJVA1`
3. Mở rộng: **Security** > **Logins**
4. Right-click **Logins** > **New Login...**
5. Điền thông tin:
   - **Login name:** `testuser`
   - Chọn: **SQL Server authentication**
   - **Password:** `Test@123`
   - Bỏ chọn: **Enforce password policy** (cho đơn giản)
   - **Default database:** `lab6_testing`
6. Vào tab **User Mapping**:
   - Chọn database: `lab6_testing`
   - Chọn role: `db_owner`
7. Click **OK**

### **Cách 2: SQL Query**

Chạy lệnh SQL này:

```sql
-- Tạo login
CREATE LOGIN testuser WITH PASSWORD = 'Test@123';
GO

-- Chuyển sang database
USE lab6_testing;
GO

-- Tạo user và cấp quyền
CREATE USER testuser FOR LOGIN testuser;
GO

ALTER ROLE db_owner ADD MEMBER testuser;
GO
```

---

## 🔧 Bước 2: Enable SQL Authentication

### **Kiểm tra SQL Server có hỗ trợ SQL Authentication không:**

1. Mở **SSMS**
2. Right-click server name > **Properties**
3. Vào **Security** page
4. Chọn: **SQL Server and Windows Authentication mode**
5. Click **OK**
6. **Restart SQL Server service:**
   - Mở **SQL Server Configuration Manager**
   - Right-click **SQL Server (MSSQLSERVER)** hoặc instance name
   - Click **Restart**

---

## 🔧 Bước 3: Cập Nhật Code

File `DatabaseConnection.java` đã được sửa. Bây giờ cập nhật username/password:

### **Mở file:** 
`d:\Năm 4\Testing\Testing B6\Bài 4\OrganizationUnitApp\src\main\java\fploy\dao\DatabaseConnection.java`

### **Thay đổi:**

```java
private static final String USERNAME = "testuser";  // Username vừa tạo
private static final String PASSWORD = "Test@123";   // Password vừa tạo
```

**HOẶC nếu dùng sa account:**

```java
private static final String USERNAME = "sa";
private static final String PASSWORD = "your_sa_password";
```

---

## 🔧 Bước 4: Build Lại và Chạy

```bash
cd "d:\Năm 4\Testing\Testing B6\Bài 4\OrganizationUnitApp"

# Build lại
cmd /c "C:\apache-maven-3.9.12-bin\apache-maven-3.9.12\bin\mvn clean package"

# Chạy
java -cp "target\organization-unit-app-1.0-SNAPSHOT.jar;C:\Users\trand\.m2\repository\com\microsoft\sqlserver\mssql-jdbc\12.4.2.jre8\mssql-jdbc-12.4.2.jre8.jar" fploy.ui.MainApp
```

---

## 💡 Nếu Vẫn Lỗi

### **Option A: Dùng sa account (Nhanh nhất)**

Nếu bạn biết password của `sa`, hãy dùng:

```java
private static final String USERNAME = "sa";
private static final String PASSWORD = "your_sa_password";
```

### **Option B: Tạo user mới**

Làm theo **Bước 1** ở trên.

### **Option C: Kiểm tra SQL Server có chấp nhận SQL Auth không**

Làm theo **Bước 2** ở trên.

---

## 📋 Checklist

- [ ] Tạo SQL login (`testuser` / `Test@123`)
- [ ] Enable SQL Server Authentication
- [ ] Restart SQL Server service
- [ ] Cập nhật username/password trong code
- [ ] Build lại project (`mvn clean package`)
- [ ] Chạy lại app
- [ ] ✅ Form mở thành công!

---

## 🆘 Troubleshooting

### Lỗi: "Login failed for user 'testuser'"
→ Kiểm tra password, hoặc user chưa có quyền trên database

### Lỗi: "SQL Server does not exist"
→ Kiểm tra server name: `LAPTOP-KN5KJVA1`

### Lỗi: "TCP/IP not enabled"
→ Mở **SQL Server Configuration Manager** > **SQL Server Network Configuration** > **Protocols** > Enable **TCP/IP**

---

**Sau khi làm xong → Build lại và chạy form! ✨**
