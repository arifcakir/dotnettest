using System;
using BDDTestProject.BusinessLayer;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDDTestProject.BusinessLayerTests.CalculatorManagerTest
{
    [Binding]
    [Scope(Feature = "CalculatorManagerTests")]
    public class LoginSteps
    {


        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


        [Given(@"Loginmanager kullanılarak Login Fonksiyonuna (.*),(.*) paramereleri verilerek çağrılır")]
        public void GivenLoginmanagerKullanılarakLoginFonksiyonunaVeParamereleriVerilerekCağrılır(string p0, string p1)
        {
            IdentityManagment.Login(p0, p1);
        }
        
        [Then(@"Login işleminin sonucunun başarılı olduğu true değeri ile anlaşılır")]
        public void ThenLoginIslemininSonucununBasarılıOlduğuTrueDeğeriIleAnlasılır()
        {
            IdentityManagment.IsAuthenticated().Should().Be(true);
        }
    }
}
