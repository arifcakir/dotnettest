using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SMS.DAL;
using System;
using System.Threading.Tasks;

namespace SMS.Tests.DAL.infra
{
    public class SmsDbContextStudentFixture: IAsyncDisposable
    {
        public SmsDbContextStudentFixture()
        {
            var builder = new DbContextOptionsBuilder<SmsDbContext>();
            //builder.UseInMemoryDatabase("databaseName=SMSTest");

            // inmemory seçildiği için ilişkiler oluşmuyor yani foreign key testleri yapılamaz.
            // veri eğer kaydedilirse diske Filename:sms gibi bir connections string yazılarak yapaılabilir.
            //builder.UseSqlite("DataSource=:memory:");

            var path = $"{Environment.CurrentDirectory.Split("SMS.Tests.DAL")[0]}SqLiteDb\\smsTestStudent.db";


            builder.UseSqlite($"Filename={path}");

            SmsDbContext = new SmsDbContext(builder.Options);
            SmsDbContext.Database.OpenConnection();
            SmsDbContext.Database.EnsureCreated();
        }

        public SmsDbContext SmsDbContext { get; }
       
        public ValueTask DisposeAsync()
        {
            // return  new ValueTask(SmsDbContext.Database.EnsureDeletedAsync());

            return new ValueTask(SmsDbContext.Database.EnsureDeletedAsync());

            //TODO : test edilmeli
            //SmsDbContext.DisposeAsync();

        }
    }

}

