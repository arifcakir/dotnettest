using System;
using AutoFixture.DataAnnotations;
using AutoFixture.Xunit2;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FluentAssertions;
using MFFT.BusinessLayer;
using MFFT.Core;
using MFFT.DataLayer;
using MFFT.Tests.BusinessLayer.Infra;
using Moq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
        [NegativeAutoData]
        [InlineAutoData(typeof(RangedRequest))]

        public void Negatif_Sayilar_Toplandiginda_Sonuc_Negatif_Toplam_Olmali_AutoData(SpecInlineData testInlineData)
        {
            var resultSum = _calculatorManager.Sum(testInlineData.Numbers);

            //FluentAssertion
            resultSum.Should().Be(testInlineData.Result)
                .And.BeNegative()
                .And.BeOfType(typeof(int), "Çünkü toplama işlemi yapılıyor.");
        }


        [Theory(DisplayName = "Minus from MaxInt Negative Test")]
        [InlineData(-2)]
        [InlineData(-100)]
        public void MaxInt_Degerinden_Negative_Rakam_cikartildiginda_Hata_Patlamalidir(int number)
        {
            Action action=()=> _calculatorManager.SubtractFromMaxInt(number);

            //FluentAssertion
            action.Should().Throw<OverflowException>();
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





    }
}
