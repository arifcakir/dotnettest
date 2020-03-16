using System;
using System.Collections.Generic;
using System.Linq;
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
    [Trait("Category", "Student Async Repository Tests")]
    [Collection("Student Repository Collection")]
    public class StudentAsyncRepositoryTests
    {
        private readonly IAsyncRepository<Student> asyncStudentRepository;
        public SmsDbContext SmsDbContext { get; }
        public StudentAsyncRepositoryTests(SmsDbContextStudentFixture SmsDbContextFixture)
        {
            SmsDbContext = SmsDbContextFixture.SmsDbContext;
            asyncStudentRepository = new BaseAsyncRepository<Student>(SmsDbContext);
        }

        [Fact(DisplayName = "Bütün öğrecilerin getirilmesi testi")]
        public async Task GetAll_testi()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var studentsForInsert = new List<Student>
            {
                new Student
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Murat",
                    LastName = "Çabuk",
                    Gender = "Male",
                    StudentId = "123456"
                },
                new Student
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Ahmet",
                    LastName = "Mehmet",
                    Gender = "Male",
                    StudentId = "123456"
                },
                new Student
                {
                    BirthDate = new DateTime(2000, 1, 1),
                    FirstName = "Mehmet",
                    LastName = "Ahmet",
                    Gender = "Male",
                    StudentId = "123456"
                }
            };

            var ids = new List<int>();
            foreach (var student in studentsForInsert)
            {
                var id = await asyncStudentRepository.Insert(student);
               _ = await asyncStudentRepository.Save();
                ids.Add(id.Id);
            }

            //Act
            var students = await asyncStudentRepository.GetAll();

            foreach (var student in students)
            {
               _ = await asyncStudentRepository.Delete(student);
               _ = await asyncStudentRepository.Save();
            }

            //Assert
            Assert.True(students.Select(s=>s.Id).SequenceEqual(ids));
        }

        [Fact(DisplayName = "Student için Firstname alanın boş geçilmesi testi")]
        public async Task Isim_alani_bos_kayıt_girildiginde_hata_donmeli()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var student = new Student
            {
                BirthDate = new DateTime(2000, 1, 1),
                FirstName = null,
                LastName = "Çabuk",
                Gender = "Male",
                StudentId = "123456"
            };

            //Act
            var result = await asyncStudentRepository.Insert(student);

            //Assert
            await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(async () =>
               await asyncStudentRepository.Save());
        }

        [Fact(DisplayName = "Student silme testi")]
        public async Task Delete_Testi()
        {
            await Task.Delay(new TimeSpan(0, 0, Constants.ThreadSleepDelay));

            //Arrange
            var student = new Student
            {
                BirthDate = new DateTime(2000, 1, 1),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
                StudentId = "123456"
            };

            var result = await asyncStudentRepository.Insert(student);
            await asyncStudentRepository.Save();
            student.Id = result.Id;

            //Act
           _= await asyncStudentRepository.Delete(student);
            await asyncStudentRepository.Save();

            var filteredStudent = await asyncStudentRepository.GetWhere(t => t.Id == student.Id);

            //Assert
            Assert.Empty(filteredStudent);
        }
    }
}
