using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OrganizationApp.Core;

namespace OrganizationApp.Tests
{
    [TestClass]
    public class OrganizationServiceUnitTests
    {
        [TestMethod]
        public void Save_Throws_When_OrgName_Empty()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = "" };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("OrgName is required", ex.Message);
        }

        [TestMethod]
        public void Save_Throws_When_OrgName_Whitespace()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = "   " };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("OrgName is required", ex.Message);
        }

        [TestMethod]
        public void Save_Throws_When_OrgName_Length_2()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = "AB" };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("OrgName length must be 3-255", ex.Message);
        }

        [TestMethod]
        public void Save_Succeeds_When_OrgName_Length_3()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = "ABC" };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Save_Succeeds_When_OrgName_Length_255()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = new string('A', 255) };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Save_Throws_When_OrgName_Length_256()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization { OrgName = new string('A', 256) };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("OrgName length must be 3-255", ex.Message);
        }

        [TestMethod]
        public void Save_Throws_When_Email_Invalid()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Email = "abc@@gmail"
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("Email is invalid", ex.Message);
        }

        [TestMethod]
        public void Save_Succeeds_When_Email_Valid()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Email = "test@example.com"
            };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Save_Throws_When_Phone_Has_Letters()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Phone = "09ABCD123"
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("Phone must be digits only", ex.Message);
        }

        [TestMethod]
        public void Save_Throws_When_Phone_Length_8()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Phone = "12345678"
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("Phone length must be 9-12", ex.Message);
        }

        [TestMethod]
        public void Save_Succeeds_When_Phone_Length_9()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Phone = "123456789"
            };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Save_Succeeds_When_Phone_Length_12()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Phone = "123456789012"
            };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void Save_Throws_When_Phone_Length_13()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Phone = "1234567890123"
            };

            var ex = Assert.ThrowsException<ArgumentException>(() => service.Save(org));
            Assert.AreEqual("Phone length must be 9-12", ex.Message);
        }

        [TestMethod]
        public void Save_Succeeds_When_Address_Null()
        {
            var service = new OrganizationService(new FakeOrganizationRepository());
            var org = new Organization
            {
                OrgName = "ABC",
                Address = null
            };

            int id = service.Save(org);
            Assert.AreEqual(1, id);
        }
    }
}
