using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Io.Cucumber.Messages;
using SMS.BL.Domain.General;
using SMS.Mvc;
using SMS.Tests.BDD.Infra;
using TechTalk.SpecFlow;
using Xunit;

namespace SMS.Tests.BDD.OgrenciYonetimModulu
{
    [Binding]
    [Scope( Feature = "OgrenciYonetimModulu")] //Scope a dikkat edilirse sadece feature düzeyinde bırakıılmış. ekstra tag yok.
                                               //amaç silme testiyle ortak olan adımları tekrar yazmamak
    public class OgrenciYonetimModuluOgrenciListeleme
    {

        
        public FeatureContext FeatureContext;
        private SmsWebApplicationFactory<Startup> factory;
        private HttpClient httpClient;
        private IOptionManager optionManager;

        private Dictionary<string, string> formData;
        private string responseString;
        public OgrenciYonetimModuluOgrenciListeleme(FeatureContext featureContext)
        {

            FeatureContext = featureContext;

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


        [Given(@"Menüden öğreci listele linkine tıklanır")]
        public async Task GivenMenudenOgreciListeleLinkineTiklanir()
        {
            //Act
            var response = await httpClient.GetAsync("/Student/List");
            var message = response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();
            //scenarioContext.Add("responseString", responseString);


            //Assert
            Assert.True(message.IsSuccessStatusCode);
        }
        
        [Given(@"Listeleme ekranında yer alan (.*), (.*), (.*) ve (.*) bilgileri girilir")]
        public async Task GivenListelemeEkranindaYerAlanBilgileriGirilir(string Firstname, string Lastname, string Birthdate, 
            string Gender)
        {


            //Arrange
            var genders = await optionManager.GetGenders();

            formData = new Dictionary<string, string>
            {
                { "Student.Id", "" },
                { "Student.FirstName", Firstname },
                { "Student.LastName", Lastname },
                { "Student.BirthDate", Birthdate },
                { "Student.Gender", Gender },
            };



        }
        
        [When(@"Ara butonuna tıklanır")]
        public async Task  WhenAraButonunaTıklanır()
        {
            //Act
            var response = await httpClient.PostAsync("/Student/List", new FormUrlEncodedContent(formData));
            var message = response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();

            FeatureContext.Add("responseString", responseString);

            //Assert
            Assert.True(message.IsSuccessStatusCode);
        }
        
        [Then(@"Öğrenci listeleme işleminin başarılı olduğu görülür")]
        public async Task ThenOgrenciListelemeIslemininBasariliOlduguGorulur()
        {

            // burada listeden donen sayıyada bakmak lazım.
            // yani kaydedip sonuçta aldığımız sayının aynı olması lazım.
            // sonuçta testler mümkün olduğuca bağımsız olmalı.
            Assert.Contains("td0", responseString);
        }
    }
}
