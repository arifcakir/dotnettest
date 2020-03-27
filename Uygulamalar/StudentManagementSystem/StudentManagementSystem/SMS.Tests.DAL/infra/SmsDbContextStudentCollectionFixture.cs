using System;
using Microsoft.Extensions.DependencyInjection;
using SMS.DAL;
using Xunit;

namespace SMS.Tests.DAL.infra
{
    [CollectionDefinition("Student Repository Collection")]
    public class SmsDbContextStudentCollectionFixture : ICollectionFixture<SmsDbContextStudentFixture>
    {
        public SmsDbContext SmsDbContext { get; }
        public SmsDbContextStudentCollectionFixture(SmsDbContextStudentFixture smsDbContextFixture)
        {
            SmsDbContext = smsDbContextFixture.SmsDbContext;
        }
    }
}
