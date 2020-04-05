using BDDTestProject.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDDTestProject.BusinessLayerTests.CalculatorManagerTest
{
    [Binding]
    [Scope(Tag = "@RakamEklemeToplama", Feature = "CalculatorManagerTests")]
    public class CalculatorAddSumSteps
    {
        private FeatureContext _featureContext;
        private ScenarioContext _scenarioContext;
        private CalculatorManager _calculatorManager;
        private Memories _memories;

        public CalculatorAddSumSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
        {

            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

            _memories = _featureContext.Get<Memories>("Memories");

            if (_memories == null)
            {

                _memories=new Memories();
                _memories.Numbers=new List<int>();
                _featureContext.Add("Memories", _memories);

            }

            _calculatorManager = new CalculatorManager(_memories);

        }



        [Given(@"Addnumber fonksiyonuna (.*) parametresi int array olarak girilir çağrılır")]
        public void GivenAddnumberFonksiyonunaParametresiIntArrayOlarakGirilirCağrılır(string p0)
        {

            int[] numbers = p0.Split(',').Select(t => Convert.ToInt32(t)).ToArray();


            foreach (var val in numbers)
            {
                 _calculatorManager.Addnumber(val);
            }

            _scenarioContext.Add("AddResult", true);

        }
        
        [Then(@"Sonucun true dondugu gorulur")]
        public void ThenSonucunTrueDonduguGorulur()
        {
           var result= _scenarioContext.Get<bool>("AddResult");
           result.Should().Be(true);
        }
        
        [Then(@"SumAllMemories fonksiyonu çağrılır")]
        public void ThenSumAllMemoriesFonksiyonuCağrılır()
        {
            var result = _calculatorManager.SumAllMemories();

            _scenarioContext.Add("SumResult", true);

        }
        
        [Then(@"Sonucun verilen sayıların toplamı olduğu görülür")]
        public void ThenSonucunVerilenSayılarınToplamıOlduğuGorulur()
        {
            var result = _scenarioContext.Get<int>("SumResult");

            result.Should().Be(10);
        }

        [Then(@"Tüm rakamlar silinir")]
        public void ThenTumRakamlarSilinir()
        {
            _calculatorManager.ClearMemeories();
        }

        [Then(@"Rakamların silindiğin Memories kontol edilerek eminolunur")]
        public void ThenRakamlarınSilindiğinMemoriesKontolEdilerekEminolunur()
        {
            _memories.Numbers.Count.Should().Be(0);
        }
    }
}
