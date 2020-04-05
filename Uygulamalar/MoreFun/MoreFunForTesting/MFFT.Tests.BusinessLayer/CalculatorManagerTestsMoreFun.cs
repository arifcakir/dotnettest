using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;
using FluentAssertions;
using MFFT.BusinessLayer;
using MFFT.Core;
using MFFT.DataLayer;
using MFFT.Tests.BusinessLayer.Infra;
using MFFT.Tests.BusinessLayer.Infra.AutoDataAttribute;
using NSubstitute;
using Xunit;

namespace MFFT.Tests.BusinessLayer
{


    //------------------------------------------------- kesin bakılmalı
    //https://nsubstitute.github.io/help/partial-subs/
    //https://nsubstitute.github.io/help/auto-and-recursive-mocks/
    //-------------

    public class CalculatorManagerTests
    {
        private readonly ICalculatorManager _calculatorManager;
        private readonly IMathRepository _mathRepository;
        public CalculatorManagerTests()
        {
            //NSubstitute Mocking
            _mathRepository = Substitute.For<IMathRepository>();
            _mathRepository.GetIntMax().Returns(Int32.MaxValue);
            _mathRepository.GetIntMin().Returns(Int32.MinValue);


            _calculatorManager = new CalculatorManager(_mathRepository);

        }

        [Theory(DisplayName = "Sum Test for (- -)")]
        [InlineData(new int[]{-1,-1}, -2)]
        [InlineData(new int[] { -10, -20 }, -30)]
        public void Iki_Negatif_Sayı_Toplandiginda_Sonuc_Negatif_Toplam_Olmali(int[] numbers, int result)
        {
            var resultSum = _calculatorManager.Sum(numbers);

            //FluentAssertion
           resultSum.Should().Be(result)
                .And.BeNegative()
                .And.BeOfType(typeof(int), "Çünkü toplama işlemi yapılıyor.");
        }


        [Theory(DisplayName = "Sum Test for (- -) With AutoData")]
        //AutoFixture editlendi
        [RangedAutoData]

        public void Negatif_Sayilar_Toplandiginda_Sonuc_Negatif_Toplam_Olmali_AutoData(SpecInlineData testInlineData)
        {
            var resultSum = _calculatorManager.Sum(testInlineData.Numbers);

            //FluentAssertion
            resultSum.Should().Be(testInlineData.Result)
                .And.BeNegative()
                .And.BeOfType(typeof(int), "Çünkü toplama işlemi yapılıyor.");
        }


        


        [Fact]
        public void test()
        {

            var fixture = new Fixture();

            var text = fixture.Create<string>();

            var number = fixture.Create<int>();

            var generatedTextWithPrefix = fixture.Create("Name");

            //Replaced Default Algorithm
            fixture.Register<string>(() => "murat");
            var result = fixture.Create<string>();

           // Sequence of Strings
           var strings = fixture.CreateMany<string>(10);
           var numbers = fixture.CreateMany<int>(5);

           var productCatsWithProducts = fixture.Build<ProductCat>()
                   .With(pc=> pc.Products, fixture.Build<List<Product>>().CreateMany<Product>(3).ToList())
                   .CreateMany(4);

           //Disable Property
           var product = fixture.Build<Product>()
               .Without(p => p.Price)
               .Create();

           //Perform Action
           var pr = fixture.Create<Product>();
           var pci = fixture.Build<ProductCat>()
               .Do(x => x.Products.Add(pr))
               .With(x => x.SelectedProduct, pr)
               .Create();


          // Customize Type
           var mc = fixture.Create<Product>();
           fixture.Customize<ProductCat>(
               ob => ob
                                .Do(x => x.Products.Add(mc))
                                .Do(s=>s.ProductCatName="Cat" + new Random().Next(1,300).ToString())
                                .With(x => x.SelectedProduct, new Product{Id = 1, Price = new decimal(12.5), ProductName = "Name"}));


           var mvm = fixture.Create<ProductCat>();



            //https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet

        }



        [Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void String_Ifade_Rakam_Olarak_Verilirse_Olumlu_Mesaj_Donmeli(string number)
        {
            //NSubstitute yapılan mocklamnın dogru olup olmadığının kontrolü
            _mathRepository.IsNumber(number).Returns(MFFT.Core.Constants.NumberMessage);
            _mathRepository.Received().IsNumber(number);
            _mathRepository.DidNotReceive().IsNumber("test");

            var result = _calculatorManager.IsNumber(number);

            result.Should().BeEquivalentTo(Constants.NumberMessage);
        }




        [Theory(DisplayName = "Minus from MaxInt Negative Test")]
        [InlineAutoNSubstituteData(-2)]
        [InlineAutoNSubstituteData(-100)]
        //normalde AutoFixture olmasaydı (SUT) CalculatorManager yukarıda constructor da tanımlanacaktı. Yukarıda örneği mevcut
        public void MaxInt_Degerinden_Negative_Rakam_cikartildiginda_Hata_Patlamalidir(int number, CalculatorManager calculatorManager)
        {
            Action action = () => calculatorManager.SubtractFromMaxInt(number);

            //FluentAssertion
            action.Should().Throw<OverflowException>();
        }

        [Theory(DisplayName = "Minus from MaxInt Negative Test"),AutoData()]

        //normalde AutoFixture olmasaydı (SUT) CalculatorManager yukarıda constructor da tanımlanacaktı. Yukarıda örneği mevcut
        public void MaxInt_Degerinden_Negative_Rakam_cikartildiginda_Hata_Patlamalidir(int number, CalculatorManager calculatorManager)
        {
            Action action = () => calculatorManager.SubtractFromMaxInt(number);

            //FluentAssertion
            action.Should().Throw<OverflowException>();
        }




    }
}
