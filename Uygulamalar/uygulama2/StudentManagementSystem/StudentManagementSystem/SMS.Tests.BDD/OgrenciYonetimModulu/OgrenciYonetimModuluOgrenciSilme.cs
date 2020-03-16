using System;
using System.Net.Http;
using System.Threading.Tasks;
using SMS.Mvc;
using SMS.Tests.BDD.Infra;
using TechTalk.SpecFlow;

namespace SMS.Tests.BDD.OgrenciYonetimModulu
{
    [Binding]
    [Scope(Tag = "OgrenciSilme", Feature = "OgrenciYonetimModulu")]
    public class OgrenciYonetimModuluOgrenciSilme
    {

        private ScenarioContext scenarioContext;
        private FeatureContext featureContext;
        private SmsWebApplicationFactory<Startup> factory;
        private HttpClient httpClient;
        public OgrenciYonetimModuluOgrenciSilme(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            scenarioContext = scenarioContext;
            featureContext = featureContext;


        }


        [BeforeScenario]
        public async Task BeforeScenario()
        {
            factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
            httpClient = factory.CreateClient();

        }

        [AfterScenario()]
        public async Task AfterScenario()
        {


        }


        [Given(@"Menüden öğreci listele linkine tıklanır")]
        public async Task GivenMenudenOgreciListeleLinkineTiklanir()
        {
           
        }
        
        [Given(@"Listeleme ekranında yer alan (.*), (.*), (.*), (.*) ve (.*) bilgileri girilir")]
        public async Task GivenListelemeEkranindaYerAlanBilgileriGirilir(string Firstname, string Lastname, string Birthdate, string Age, string Gender)
        {
           
        }
        
        [When(@"Ara butonuna tıklanır")]
        public async Task WhenAraButonunaTıklanır()
        {
            
        }
        
        [When(@"Listede yer alan sil linklerinden birine tıklanır")]
        public async Task WhenListedeYerAlanSilLinklerindenBirineTiklanir()
        {
            
        }
        
        [Then(@"Öğrenci listeleme işleminin başarılı olduğu görülür")]
        public async Task ThenOgrenciListelemeIslemininBasariliOlduguGorulur()
        {
            
        }
        
        [Then(@"Öğrenci silme işleminin başarılı olduğu görülür")]
        public async Task ThenOğrenciSilmeIslemininBasariliOlduğuGorulur(Table table)
        {
            
        }
    }
}
