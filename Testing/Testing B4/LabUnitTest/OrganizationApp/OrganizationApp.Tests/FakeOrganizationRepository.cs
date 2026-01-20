using OrganizationApp.Core;

namespace OrganizationApp.Tests
{
    // Simple fake repository for unit tests
    public class FakeOrganizationRepository : OrganizationRepository
    {
        private readonly bool _exists;
        private readonly int _insertId;

        public FakeOrganizationRepository(bool exists = false, int insertId = 1)
        {
            _exists = exists;
            _insertId = insertId;
        }

        public override bool ExistsByName(string orgName) => _exists;
        public override int Insert(Organization org) => _insertId;
    }

}
