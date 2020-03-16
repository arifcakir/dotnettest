using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SMS.BL.Domain.General;
using SMS.Globalizaiton.Resources;
using SMS.Mvc;
using SMS.Tests.BDD.Infra;
using TechTalk.SpecFlow;
using Xunit;

namespace SMS.Tests.BDD.OgrenciYonetimModulu
{
    [Binding]
    [Scope(Tag="OgrenciEkleme",Feature = "OgrenciYonetimModulu")]
    public class OgrenciYonetimModuluOgrenciEkleme
    {

        public ScenarioContext scenarioContext;
        public FeatureContext featureContext;
        private SmsWebApplicationFactory<Startup> factory;
        private HttpClient httpClient;
        private IOptionManager optionManager;

        private Dictionary<string, string> formData;
        private string responseString;
        public OgrenciYonetimModuluOgrenciEkleme(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            scenarioContext = scenarioContext;
            featureContext = featureContext;

            factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
            httpClient = factory.CreateClient();
            optionManager = factory.OptionManager;



        }


        //[BeforeScenario]
        //public async Task BeforeScenario()
        //{
        //}

        //[AfterScenario()]
        //public async Task AfterScenario()
        //{


        //}



        [Given(@"Menüden öğrenci ekle linkine tıklanır")]
        public async Task GivenMenudenOgrenciEkleLinkineTiklanir()
        {
           var response = await httpClient.GetAsync("/Student/AddUpdate");
            var message = response.EnsureSuccessStatusCode();

            Assert.True(message.IsSuccessStatusCode);

        }

        


        [Given(@"Ekleme ekranında yer alan (.*), (.*), (.*), (.*), (.*) ve (.*) bilgileri girilir")]
        public async Task GivenEklemeEkranindaYerAlanVeBilgileriGirilir(string Firstname, string Lastname, 
            string Birthdate, string Age, string Gender, string StudentId)
        {
            //Arrange
            var genders = await optionManager.GetGenders();

            formData = new Dictionary<string, string>
            {
                { "Student.Id", "" },
                { "Student.FirstName", Firstname },
                { "Student.LastName", Lastname },
                { "Student.BirthDate", Birthdate },
                { "Student.StudentId", StudentId },
                { "Student.Gender", Gender },
                { "Student.Age", Age }
            };

           // scenarioContext.Add("formData", formData);



        }


        [When(@"Kaydet butonuna tıklanılır")]
        public async Task WhenKaydetButonunaTiklanilir()
        {
            //Arrange
          //  var formData = scenarioContext.Get<Dictionary<string, string>>("formData");


            //Act
            var response = await httpClient.PostAsync("Student/AddUpdate", new FormUrlEncodedContent(formData));
            var message = response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();

           // scenarioContext.Add("responseString", responseString);

            //Assert
            Assert.True(message.IsSuccessStatusCode);
        }
        
        [Then(@"Öğrenci ekleme işleminin başarılı olduğu görülür")]
        public async Task ThenOgrenciEklemeIslemininBasariliOlduğuGorulur()
        {
           // var responseString = scenarioContext.Get<String>("responseString");
            //Assert
            Assert.Contains(Constants.StudentAddUpdateSuccessfulMessage, responseString);
        }
    }
}
