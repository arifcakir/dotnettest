using System;
using System.Threading.Tasks;
using Xunit;
using SMS.Core.Data.Interfaces;
using SMS.DAL.Entities;
using SMS.Tests.DAL.infra;
using SMS.DAL;
using SMS.Core.Data;

/// <summary>
/// Sayfalamanın çalışıp çalışmadığı, belirli kısıtları taşımayan entitylerin kaydedilip edilmediği
/// Filtrelemelerin çalışıp çalışmadığı vb gibi testler yapılabilir.
/// http://www.mukeshkumar.net/articles/efcore/unit-testing-with-inmemory-provider-and-sqlite-in-memory-database-in-ef-core
/// </summary>

namespace SMS.Tests.DAL
{ 
   [Trait("Category","Teacher2 Async Repository Tests")]
   [Collection("Teacher Repository Collection")]
   public class Teacher2AsyncRepositoryTests
    {
        private readonly IAsyncRepository<Teacher> _asyncTeacherRepository;
        private readonly SmsDbContext _smsDbContext ;
        public Teacher2AsyncRepositoryTests(SmsDbContextTeacherFixture SmsDbContextFixture)
        {
            _smsDbContext = SmsDbContextFixture.SmsDbContext;
            _asyncTeacherRepository =new BaseAsyncRepository<Teacher>(_smsDbContext);
        }

        [Fact(DisplayName = "Teacher silme testi")]
        public async Task Delete_Testi()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var teacher = new Teacher
            {
                BirthDate = new DateTime(2000, 1, 1),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
            };
           
            var result = await _asyncTeacherRepository.Insert(teacher);
            await _asyncTeacherRepository.Save();
           

            //Act
           _ = await _asyncTeacherRepository.Delete(result);
            await _asyncTeacherRepository.Save();

            var filteredTeacher = await _asyncTeacherRepository.GetWhere(t => t.Id == result.Id);

            //Assert
            Assert.Empty(filteredTeacher);

        }

    }
}
