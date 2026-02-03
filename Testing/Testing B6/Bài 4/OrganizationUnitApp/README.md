# Java Form Application - Add Organization Unit

## 📦 Ứng Dụng Java Swing

Ứng dụng form "Add Organization Unit" với đầy đủ validation và kết nối SQL Server.

---

## 🚀 Cách Chạy

### **Cách 1: Maven (Khuyến nghị)**

```bash
cd "d:\Năm 4\Testing\Testing B6\Bài 4\OrganizationUnitApp"

# Build project
mvn clean package

# Chạy ứng dụng
mvn exec:java -Dexec.mainClass="fploy.ui.MainApp"
```

### **Cách 2: Command Line**

```bash
cd "d:\Năm 4\Testing\Testing B6\Bài 4\OrganizationUnitApp"

# Compile
javac -d target/classes -sourcepath src/main/java src/main/java/fploy/ui/*.java

# Run
java -cp "target/classes;path/to/mssql-jdbc.jar" fploy.ui.MainApp
```

---

## 📁 Cấu Trúc Project

```
OrganizationUnitApp/
├── pom.xml
└── src/
    └── main/
        └── java/
            └── fploy/
                ├── ui/
                │   ├── MainApp.java
                │   └── AddOrganizationUnitForm.java
                ├── dao/
                │   ├── DatabaseConnection.java
                │   ├── OrganizationDAO.java
                │   └── OrganizationUnitDAO.java
                └── model/
                    ├── Organization.java
                    └── OrganizationUnit.java
```

---

## ✨ Tính Năng

### **Form có các trường:**
- ✅ Unit Id (textfield)
- ✅ Name* (textfield - required)
- ✅ Description (textarea)
- ✅ Organization (dropdown)
- ✅ Save button (màu xanh lá)
- ✅ Cancel button (màu trắng)

### **Validation tự động:**
- ✅ Unit Id không để trống
- ✅ Name không để trống  
- ✅ Organization phải chọn
- ✅ Unit Id không được trùng
- ✅ Unit Id chỉ chứa chữ và số
- ✅ Name tối đa 255 ký tự
- ✅ Unit Id tối đa 50 ký tự

### **Kết nối Database:**
- ✅ SQL Server: LAPTOP-KN5KJVA1
- ✅ Database: lab6_testing
- ✅ Integrated Security

---

## 🧪 Test Cases Tự Động

Form đã có validation tích hợp cho **10 test case** từ TEST_CASE_DOCUMENT.md:

| TC | Kiểm tra | Validation |
|----|---------|-----------|
| TC_001 | Thêm hợp lệ | ✅ |
| TC_002 | Unit Id trống | ✅ Error message |
| TC_003 | Name trống | ✅ Error message |
| TC_004 | Org không chọn | ✅ Error message |
| TC_005 | Unit Id trùng | ✅ Check database |
| TC_006 | Ký tự đặc biệt | ✅ Regex validation |
| TC_007 | Name quá dài | ✅ Length check |
| TC_008 | Có Description | ✅ |
| TC_009 | Khoảng trắng | ✅ Auto trim |
| TC_010 | Click Cancel | ✅ Clear form |

---

## 📝 Hướng Dẫn Test

1. **Chạy database script** (đã chạy rồi ✅)
2. **Build & Run form:**
   ```bash
   cd OrganizationUnitApp
   mvn clean package exec:java -Dexec.mainClass="fploy.ui.MainApp"
   ```
3. **Thực hiện 10 test case** theo TEST_CASE_DOCUMENT.md
4. **Ghi lại kết quả** Pass/Fail

---

## ⚙️ Dependencies

Maven sẽ tự động tải:
- **mssql-jdbc** 12.4.2.jre8 (SQL Server Driver)

---

## 🔧 Troubleshooting

### Lỗi: Connection failed
```
Kiểm tra SQL Server đang chạy
Kiểm tra tên server: LAPTOP-KN5KJVA1
```

### Lỗi: Driver not found
```bash
mvn clean install
# Maven sẽ tải lại dependencies
```

### Lỗi: Maven not found
```bash
Dùng đường dẫn đầy đủ:
"C:\apache-maven-3.9.12-bin\apache-maven-3.9.12\bin\mvn" clean package
```

---

**✨ Form Java đã sẵn sàng để test! ✨**
