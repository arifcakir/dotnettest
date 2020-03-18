using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SMS.BL.Domain.General;
using SMS.Mvc;
using SMS.Tests.Mvc.Infra;
using Xunit;

namespace SMS.Tests.Mvc
{
   public class StudentcontrollerTests:BaseTest, IClassFixture<SmsWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly IOptionManager _optionManager;

        public StudentcontrollerTests(SmsWebApplicationFactory<Startup> factory) :base()
        {

            _client = factory.CreateClient();
            _optionManager = factory.OptionManager;
        }

        [Theory(DisplayName = "Student IndexView get testi")]
        [InlineData(SMS.Tests.Mvc.Infra.Constants.StudentIndexWelcomeMessage)]
        public async Task Student_Index_cagrildiginda_welcome_message_donmeli(string welcomeMessage)
        {

            //Act
            var response = await _client.GetAsync("/Student/Index");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Contains(welcomeMessage, responseString);
        }


        [Theory(DisplayName = "Student AddUpdateView kayıt ekleme testi")]
        [InlineData(Constants.StudentAddUpdateSuccessfulMessage)]
        public async Task Student_kaydedildiginde_ekrana_basasrili_mesaji_donmeli(string successfullMessage)
        {

            //Arrange
            var genders = await _optionManager.GetGenders();

            var formData = new Dictionary<string, string>
            {
                { "Student.Id", "" },
                { "Student.FirstName", "Firstname" },
                { "Student.LastName", "Lastname" },
                { "Student.BirthDate", "11/11/1996" },
                { "Student.StudentId", "2345678" },
                { "Student.Gender", "Male" },
                { "Student.Age", "20" }
            };

            //Act
            var response = await _client.PostAsync("/Student/AddUpdate", new FormUrlEncodedContent(formData));
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            //Assert
            Assert.Contains(successfullMessage, responseString);
        }

       // public async Task 



    }
}
