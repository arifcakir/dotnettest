using SMS.BL.Domain.Student;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LazyCache;
using Moq;
using SMS.BL;
using SMS.Core.Data.Interfaces;
using SMS.Core.Extensions;
using SMS.Core.Multiculture;
using SMS.DAL.Entities;
using Xunit;

namespace SMS.Tests.BL
{

    [Trait("Category", "Student Manager Tests")]
    public class StudentManagerTests
    {

        private IStudentManager sutStudentManager;
        private readonly Mock<IAsyncRepository<Student>> asyncStudentRespositoryMock;
        private readonly Mock<IDateTimeProvider> dateTimeProviderMock;

        private readonly Mock<IMapper> mapperMock;
        private readonly Mock<IAppCache> cacheMock;


        public StudentManagerTests()
        {
            asyncStudentRespositoryMock = new Mock<IAsyncRepository<Student>>();
            dateTimeProviderMock = new Mock<IDateTimeProvider>();

            // Bu ikisini biz yazmadık mock lamaya gerek var mı?
            mapperMock = new Mock<IMapper>();
            cacheMock = new Mock<IAppCache>();
        }

        //kaç tane değer test edilmeli
        [Fact(DisplayName = "Öğrenci kaydı için minimum yaş testi")]
        public async Task Minimum_yas_altindaki_ogrenciler_kaydedildiginde_result_fail_donmeli()
        {
            // TODO : sadece ilgilendiğimiz parametreleri doldursak olmazmıydı
            //Arrange
            var studentBlDto = new StudentBlDto
            {
                BirthDate = new DateTime(2003, 01, 01),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
                StudentId = "123456",
                Age = 17
            };

            var student = new Student
            {
                BirthDate = new DateTime(2003, 01, 01),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
                StudentId = "123456"
            };

            mapperMock.Setup(t => t.Map<Student>(studentBlDto)).Returns(student);

            asyncStudentRespositoryMock.Setup(t => t.Insert(student));

            dateTimeProviderMock.Setup(t => t.GetTodayDateTime())
                                                        .ReturnsAsync(() => new DateTime(2020,01,01));

            sutStudentManager = new StudentManager(asyncStudentRespositoryMock.Object, 
                                                   mapperMock.Object, 
                                                   dateTimeProviderMock.Object, 
                                                   cacheMock.Object);

            var studentAddUpdateModel = new StudentAddUpdateModel
            {
                Student = studentBlDto
            };

            //Act
            var result = await  sutStudentManager.Add(studentAddUpdateModel);
            var count = result.SpecResult.FailedSpecifications.ToFilteredSpecs(nameof(StudentBlDto.BirthDate)).Count;

            //Assert
            Assert.True(count > 0);


            // TODO : şu şekilde yapsaydık olmazmıydı
            // Assert.False(result.IsOk);

        }

    }
}
