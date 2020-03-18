using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using SMS.BL.Domain.General;
using SMS.Globalizaiton.Resources;
using SMS.Mvc;
using SMS.Tests.BDD.Infra;
using TechTalk.SpecFlow;
using Xunit;

namespace SMS.Tests.BDD.OgrenciYonetimModulu
{
    [Binding]
    [Scope( Feature = "OgrenciYonetimModulu")] //Scope a dikkat edilirse sadece feature düzeyinde bırakıılmış. ekstra tag yok.
                                               //amaç silme testiyle ortak olan adımları tekrar yazmamak
    public class OgrenciYonetimModuluOgrenciSilme
    {

        private FeatureContext FeatureContext;
        private SmsWebApplicationFactory<Startup> factory;
        private HttpClient httpClient;
        private IOptionManager optionManager;
        private string id;
        private string responseString;

        public OgrenciYonetimModuluOgrenciSilme( FeatureContext featureContext)
        {
            FeatureContext = featureContext;

            factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
            httpClient = factory.CreateClient();
            optionManager = factory.OptionManager;

        }


        //[BeforeScenario]
        //public async Task BeforeScenario()
        //{
        //    factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
        //    httpClient = factory.CreateClient();

        //}

        //[AfterScenario()]
        //public async Task AfterScenario()
        //{


        //}


        //[Given(@"Menüden öğreci listele linkine tıklanır")]
        //public async Task GivenMenudenOgreciListeleLinkineTiklanir()
        //{

        //}

        //[Given(@"Listeleme ekranında yer alan (.*), (.*), (.*), (.*) ve (.*) bilgileri girilir")]
        //public async Task GivenListelemeEkranindaYerAlanBilgileriGirilir(string Firstname, string Lastname, string Birthdate, string Age, string Gender)
        //{

        //}

        //[When(@"Ara butonuna tıklanır")]
        //public async Task WhenAraButonunaTıklanır()
        //{

        //}


        //[Then(@"Öğrenci listeleme işleminin başarılı olduğu görülür")]
        //public async Task ThenOgrenciListelemeIslemininBasariliOlduguGorulur()
        //{

        //}

        [When(@"Listede yer alan sil linklerinden birine tıklanır")]
        public async Task WhenListedeYerAlanSilLinklerindenBirineTiklanir()
        {
          
            //listeleme senaryonundan gelen html sonuc okunuyor
            var responseStringFromFeature = FeatureContext.Get<String>("responseString");
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(responseStringFromFeature);
            id = htmlDoc.GetElementbyId("td0").InnerText;
            var message = await httpClient.GetAsync($"/Student/Delete?id{id}");

            responseString = await message.Content.ReadAsStringAsync();

            Assert.True(message.EnsureSuccessStatusCode().IsSuccessStatusCode);
            
        }
        
        
        
        [Then(@"Öğrenci silme işleminin başarılı olduğu görülür")]
        public async Task ThenOğrenciSilmeIslemininBasariliOlduğuGorulur(Table table)
        {


            //Assert
            Assert.True(responseString.Contains(Resource.Successful));

        }
    }
}
