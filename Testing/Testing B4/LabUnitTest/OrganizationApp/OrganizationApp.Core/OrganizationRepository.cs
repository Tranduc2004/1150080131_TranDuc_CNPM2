using System;
using System.Data.SqlClient;

namespace OrganizationApp.Core
{
    public class OrganizationRepository
    {
        public virtual bool ExistsByName(string orgName)
        {
            const string sql = @"SELECT COUNT(1) FROM ORGANIZATION
                                 WHERE LOWER(OrgName) = LOWER(@name);";

            using (var conn = new SqlConnection(Db.ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", orgName ?? "");
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public virtual int Insert(Organization org)
        {
            const string sql = @"
INSERT INTO ORGANIZATION (OrgName, Address, Phone, Email)
OUTPUT INSERTED.OrgID
VALUES (@OrgName, @Address, @Phone, @Email);";

            using (var conn = new SqlConnection(Db.ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@OrgName", org.OrgName);
                cmd.Parameters.AddWithValue("@Address", (object)org.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)org.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)org.Email ?? DBNull.Value);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
