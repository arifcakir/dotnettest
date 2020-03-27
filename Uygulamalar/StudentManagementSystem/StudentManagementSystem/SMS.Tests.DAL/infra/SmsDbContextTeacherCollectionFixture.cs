using SMS.DAL;
using Xunit;

namespace SMS.Tests.DAL.infra
{
    [CollectionDefinition("Teacher Repository Collection")]
    public class SmsDbContextTeacherCollectionFixture : ICollectionFixture<SmsDbContextTeacherFixture>
    {
        public SmsDbContext SmsDbContext { get; }
        public SmsDbContextTeacherCollectionFixture(SmsDbContextTeacherFixture smsDbContextFixture)
        {
            SmsDbContext = smsDbContextFixture.SmsDbContext;
        }
    }
}
