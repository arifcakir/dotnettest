using SMS.BL.Domain.Teacher;
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

    [Trait("Category","Teacher Manager Tests")]
    public class TeacherManagerTests
    {

        private ITeacherManager sutTeacherManager;
        private readonly Mock<IAsyncRepository<Teacher>> asyncTeacherRespositoryMock;
        private readonly Mock<IDateTimeProvider> dateTimeProviderMock;

        private readonly Mock<IMapper> mapperMock;
        private readonly Mock<IAppCache> cacheMock;


        public TeacherManagerTests()
        {
            asyncTeacherRespositoryMock = new Mock<IAsyncRepository<Teacher>>();
            dateTimeProviderMock = new Mock<IDateTimeProvider>();


            // Bu ikisini biz yazmadık mock lamaya gerek var mı?
            mapperMock = new Mock<IMapper>();
            cacheMock = new Mock<IAppCache>();

        }

        //kaç tane değer test edilmeli
        [Theory(DisplayName = "Öğretmen kaydı için yaş aralığı testi")]
        [InlineData(TeacherDomainConstants.MinAgeForTeacher -1)]
        [InlineData(TeacherDomainConstants.MaxAgeForTeacher + 1)]

        public async Task Kabul_edilen_yas_araligi_disinda_ogretmen_kaydedildiginde_result_fail_donmeli(int age)
        {

            //Arrange

            dateTimeProviderMock.Setup(t => t.GetTodayDateTime())
                .ReturnsAsync(() => new DateTime(2020, 01, 01));

            var today = dateTimeProviderMock.Object.GetTodayDateTime();

            // TODO : sadece ilgilendiğimiz parametreleri doldursak olmazmıydı
           var teacherBlDto = new TeacherBlDto
            {
                BirthDate = new DateTime(today.Result.Year - age, 01, 01),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
               
            };

            var teacher = new Teacher
            {
                BirthDate = new DateTime(2003, 01, 01),
                FirstName = "Murat",
                LastName = "Çabuk",
                Gender = "Male",
            };

            mapperMock.Setup(t => t.Map<Teacher>(teacherBlDto)).Returns(teacher);

            asyncTeacherRespositoryMock.Setup(t => t.Insert(teacher));

            sutTeacherManager = new TeacherManager(asyncTeacherRespositoryMock.Object, 
                                                   mapperMock.Object, 
                                                   dateTimeProviderMock.Object, 
                                                   cacheMock.Object);

            var teacherAddUpdateModel = new TeacherAddUpdateModel
            {
                Teacher = teacherBlDto
            };

            //Act
            var result = await  sutTeacherManager.Add(teacherAddUpdateModel);
            var count = result.SpecResult.FailedSpecifications.ToFilteredSpecs(nameof(TeacherBlDto.BirthDate)).Count;

            //Assert
            Assert.True(count > 0);

            // TODO : şu şekilde yapsaydık olmazmıydı
            // Assert.False(result.IsOk);


        }

    }
}
