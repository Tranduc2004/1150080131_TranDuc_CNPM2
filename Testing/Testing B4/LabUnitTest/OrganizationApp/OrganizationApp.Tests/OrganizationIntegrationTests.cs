using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Transactions;
using OrganizationApp.Core;

namespace OrganizationApp.Tests
{
    [TestClass]
    public class OrganizationIntegrationTests
    {
        private OrganizationService _service;

        [TestInitialize]
        public void Setup()
        {
            _service = new OrganizationService(new OrganizationRepository());
        }

        [TestMethod]
        public void Save_Valid_Inserts_To_DB()
        {
            using (var tx = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var org = new Organization
                {
                    OrgName = "Org_" + Guid.NewGuid(),
                    Address = "HCM",
                    Phone = "0912345678",
                    Email = "test@gmail.com"
                };

                int id = _service.Save(org);
                Assert.IsTrue(id > 0);

                // do not call tx.Complete() so the insert is rolled back after the test
            }
        }

        [TestMethod]
        public void Save_Duplicate_Name_Throws()
        {
            string name = "OrgDup_" + Guid.NewGuid();

            using (var tx = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                _service.Save(new Organization { OrgName = name });
                var ex = Assert.ThrowsException<ArgumentException>(() =>
                    _service.Save(new Organization { OrgName = name.ToLower() }) // test case-insensitive
                );

                Assert.AreEqual("Organization Name already exists", ex.Message);

                // rollback by disposing scope without Complete()
            }
        }

        [TestMethod]
        public void Save_Valid_With_Null_Email_Phone_Inserts()
        {
            using (var tx = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var org = new Organization
                {
                    OrgName = "OrgNull_" + Guid.NewGuid(),
                    Address = "HCM",
                    Phone = null,
                    Email = null
                };

                int id = _service.Save(org);
                Assert.IsTrue(id > 0);

                // rollback by disposing scope without Complete()
            }
        }
    }
}
