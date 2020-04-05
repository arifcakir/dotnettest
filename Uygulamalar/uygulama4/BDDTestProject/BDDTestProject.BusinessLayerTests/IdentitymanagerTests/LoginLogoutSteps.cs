using System;
using TechTalk.SpecFlow;

namespace BDDTestProject.BusinessLayerTests.IdentitymanagerTests
{
    [Binding]
    [Scope(Tag = "@SistemeGirisCikisTesti", Feature = "IdentityManagerTests")]
    public class LoginLogoutSteps
    {
        [Given(@"Login fonsiyonuna ""(.*)"" ve ""(.*)"" girilerek çağrılır")]
        public void GivenLoginFonsiyonunaVeGirilerekCağrılır(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Login işlemi sonucunun true olduğu görülür")]
        public void ThenLoginIslemiSonucununTrueOlduğuGorulur()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Logout fonksiyonu çağrılır")]
        public void ThenLogoutFonksiyonuCağrılır()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Logout işleriminin sonucunun true olduğu görülür")]
        public void ThenLogoutIslerimininSonucununTrueOlduğuGorulur()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
