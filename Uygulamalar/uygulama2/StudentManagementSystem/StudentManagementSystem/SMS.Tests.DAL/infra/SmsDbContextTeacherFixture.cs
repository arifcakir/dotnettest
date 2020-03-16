using Microsoft.EntityFrameworkCore;
using SMS.DAL;
using System;
using System.Threading.Tasks;

namespace SMS.Tests.DAL.infra
{
    public class SmsDbContextTeacherFixture: IAsyncDisposable
    {
        public SmsDbContextTeacherFixture()
        {
            var builder = new DbContextOptionsBuilder<SmsDbContext>();

            builder.UseSqlite("Filename=../../../SqLiteDbs/SmsTeacherTest.db");

            SmsDbContext = new SmsDbContext(builder.Options);
            SmsDbContext.Database.OpenConnectionAsync();
            SmsDbContext.Database.EnsureCreatedAsync();
        }

        public SmsDbContext SmsDbContext { get; }
       
        public ValueTask DisposeAsync()
        {
            return new ValueTask(SmsDbContext.Database.CloseConnectionAsync());
        }
    }

}

