using System;
using System.Text.RegularExpressions;

namespace OrganizationApp.Core
{
    public class OrganizationService
    {
        private readonly OrganizationRepository _repo;

        public OrganizationService(OrganizationRepository repo)
        {
            _repo = repo;
        }

        public int Save(Organization org)
        {
            Validate(org);

            if (_repo.ExistsByName(org.OrgName))
                throw new ArgumentException("Organization Name already exists");

            return _repo.Insert(org);
        }

        private void Validate(Organization org)
        {
            if (org == null) throw new ArgumentException("Invalid Data");

            // OrgName
            if (string.IsNullOrWhiteSpace(org.OrgName))
                throw new ArgumentException("OrgName is required");

            org.OrgName = org.OrgName.Trim();
            if (org.OrgName.Length < 3 || org.OrgName.Length > 255)
                throw new ArgumentException("OrgName length must be 3-255");

            // Email (nếu nhập)
            if (!string.IsNullOrWhiteSpace(org.Email))
            {
                org.Email = org.Email.Trim();
                if (!Regex.IsMatch(org.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("Email is invalid");
            }
            else org.Email = null;

            // Phone (nếu nhập)
            if (!string.IsNullOrWhiteSpace(org.Phone))
            {
                org.Phone = org.Phone.Trim();
                if (!Regex.IsMatch(org.Phone, @"^\d+$"))
                    throw new ArgumentException("Phone must be digits only");
                if (org.Phone.Length < 9 || org.Phone.Length > 12)
                    throw new ArgumentException("Phone length must be 9-12");
            }
            else org.Phone = null;

            // Address
            org.Address = string.IsNullOrWhiteSpace(org.Address) ? null : org.Address.Trim();
        }
    }
}
