using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SMS.Globalizaiton.Resources;
using SMS.Mvc;
using SMS.Tests.BDD.Infra;
using SQLitePCL;
using TechTalk.SpecFlow;
using Xunit;

namespace SMS.Tests.BDD.OgrenciYonetimModulu
{
    [Binding]
    [Scope(Feature = "OgrenciYonetimModulu")]
    public class OgrenciYonetimModuluOgrenciBackground
    {


        public ScenarioContext scenarioContext;
        public FeatureContext FeatureContext;
        private SmsWebApplicationFactory<Startup> factory;
        private HttpClient httpClient;
        private string responseString;

        public OgrenciYonetimModuluOgrenciBackground(ScenarioContext scenarioContext, FeatureContext featureContext)
        {

            //burası background lduğu için aslında hangi senaryo çalışıyorsa oranın senaryo kaydına gideceği için burada kullanmak çok mantıklı değil aslında
            // bu nedenla aşağıda bu clas için private değişkenler tanımlanarak class içi veriler bu değişkenlerle taşındı
            scenarioContext = scenarioContext;
            FeatureContext = featureContext;

            var count = featureContext.Keys.Where(t => t == "SmsWebApplicationcontext").Count();

            if (count == 0)
            {
                featureContext.Add("SmsWebApplicationcontext", new SmsWebApplicationFactory<Startup>());
            }


            factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
            httpClient = factory.CreateClient();

        }


        //[BeforeScenario]
        //public void BeforeTest()
        //{

        //    //scenarioContext.Add("SmsWebApplicationcontext", new SmsWebApplicationFactory<Startup>());
        //   // featureContext.Add("SmsWebApplicationcontext", new SmsWebApplicationFactory<Startup>());

        //    // factory = scenarioContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
        //    // httpClient = factory.CreateClient();


        //    //factory = featureContext.Get<SmsWebApplicationFactory<Startup>>("SmsWebApplicationcontext");
        //    //httpClient = factory.CreateClient();

        //}



        [Given(@"""(.*)"" adresi açılır")]
        [Scope(Tag = "OgrenciBackground")]
        public async Task GivenAnasayfaAdresiAcilir(string p0)
        {
            //Act
            var response = await httpClient.GetAsync("/Home/Index");
            var message = response.EnsureSuccessStatusCode();

            responseString = await response.Content.ReadAsStringAsync();
            //scenarioContext.Add("responseString", responseString);


            //Assert
            Assert.True(message.IsSuccessStatusCode);

        }

        [Then(@"Açılan sayfanın anasayfa olduğu görülür")]
        [Scope(Tag = "OgrenciBackground")]
        public async Task ThenAcilanSayfaninAnasayfaOlduguGorulur()
        {
           // var responseString = scenarioContext.Get<String>("responseString");
            //Assert
            Assert.Contains(Resource.Welcome, responseString);
        }
    }
}
