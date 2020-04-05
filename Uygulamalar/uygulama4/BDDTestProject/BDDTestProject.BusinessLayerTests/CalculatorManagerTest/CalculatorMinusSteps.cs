using System;
using System.Collections.Generic;
using System.Linq;
using BDDTestProject.BusinessLayer;
using TechTalk.SpecFlow;

namespace BDDTestProject.BusinessLayerTests.CalculatorManagerTest
{
    [Binding]
    [Scope(Tag = "@RakamCikartma", Feature = "CalculatorManagerTests")]
    public class CalculatorMinusSteps
    {

        private FeatureContext _featureContext;
        private CalculatorManager _calculatorManager;
        private Memories _memories;

        public CalculatorMinusSteps(FeatureContext featureContext)
        {


            _featureContext = featureContext;

            _memories = _featureContext.Get<Memories>("Memories");

            if (_memories == null)
            {

                _memories = new Memories();
                _memories.Numbers = new List<int>();
                _featureContext.Add("Memories", _memories);

            }

            _calculatorManager = new CalculatorManager(_memories);

        }


        [Given(@"Addnumber fonksiyonuna (.*) parametresi int array olarak girilir çağrılır")]
        public void GivenAddnumberFonksiyonunaParametresiIntArrayOlarakGirilirCağrılır(string p0)
        {

            int[] numbers = p0.Split(',').Select(t => Convert.ToInt32(t)).ToArray();

            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Sonucun true dondugu gorulur")]
        public void ThenSonucunTrueDonduguGorulur()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"RemoveNumber fonksiyonuna bir rakam paramertre olaraka girilerek çağrılır")]
        public void ThenRemoveNumberFonksiyonunaBirRakamParamertreOlarakaGirilerekCağrılır()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Memories de silinen rakam kontrol edilerek siliniğinden eminolounur")]
        public void ThenMemoriesDeSilinenRakamKontrolEdilerekSiliniğindenEminolounur()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Tüm rakamlar silinir")]
        public void ThenTumRakamlarSilinir()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Rakamların silindiğin Memories kontol edilerek eminolunur")]
        public void ThenRakamlarınSilindiğinMemoriesKontolEdilerekEminolunur()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
