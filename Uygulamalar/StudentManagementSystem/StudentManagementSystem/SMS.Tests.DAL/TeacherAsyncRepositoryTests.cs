using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
   [Trait("Category","Teacher Async Repository Tests")]
   [Collection("Teacher Repository Collection")]
   public class TeacherAsyncRepositoryTests
    {

        private readonly IAsyncRepository<Teacher> _asyncTeacherRepository;
        private readonly SmsDbContext _smsDbContext;
        public TeacherAsyncRepositoryTests(SmsDbContextTeacherFixture SmsDbContextFixture)
        {
            _smsDbContext = SmsDbContextFixture.SmsDbContext;
            _asyncTeacherRepository =new BaseAsyncRepository<Teacher>(_smsDbContext);
        }

        [Fact(DisplayName = "Bütün öğretmenlerin getirilmesi testi")]
        public async Task GetAll_testi()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var teachersForInsert = new List<Teacher>
            {
                new Teacher
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Murat",
                    LastName = "Çabuk",
                    Gender = "Male",
                },
                new Teacher
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Ahmet",
                    LastName = "Mehmet",
                    Gender = "Male",
                },
                new Teacher
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Mehmet",
                    LastName = "Ahmet",
                    Gender = "Male",
                }
            };

            var ids= new List<int>();
           
            foreach (var teacher in teachersForInsert)
            {
               var id =  await _asyncTeacherRepository.Insert(teacher);
               await _asyncTeacherRepository.Save();
               ids.Add(id.Id);
            }

            //Act
            var teachers = await _asyncTeacherRepository.GetAll();
            
            foreach (var teacher in teachers)
            {
               _ = await _asyncTeacherRepository.Delete(teacher);
               _ = await _asyncTeacherRepository.Save();
            }


            //Assert
            Assert.True(teachers.Select(s=> s.Id).SequenceEqual(ids));

        }

        [Fact(DisplayName = "Teacher için Firstname alanın boş geçilmesi testi")]
        public async Task Isim_alani_bos_kayıt_girtildiginde_hata()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var teacher = new Teacher
            {
                BirthDate = new DateTime(2000, 1, 1),
                FirstName = null,
                LastName = "Çabuk",
                Gender = "Male",
            };


            //Act
            _ = await _asyncTeacherRepository.Insert(teacher);

            //Assert
            await Assert.ThrowsAsync<DbUpdateException>(async ()=> await _asyncTeacherRepository.Save());

            _smsDbContext.Entry(teacher).State = EntityState.Detached;
        }


    }
}
