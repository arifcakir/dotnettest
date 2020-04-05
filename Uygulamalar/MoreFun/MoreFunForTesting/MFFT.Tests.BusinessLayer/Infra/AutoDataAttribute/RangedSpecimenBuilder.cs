using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoFixture.Kernel;

namespace MFFT.Tests.BusinessLayer.Infra.AutoDataAttribute
{


    public  class SpecInlineData
    {
        public  int[] Numbers;
        public  int Result;
    }

    public  class RangedRequest
    {
        public  int Count { get; set; }
        public  int Min { get; set; }
        public  int Max { get; set; }
    }


    public class RangedSpecimenBuilder : ISpecimenBuilder
    {
        private RangedRequest _rangedRequest;

        //public NegativeSpecimenBuilder(NegativeRequest negativeRequest)
        //{
        //    _rangedRequest = negativeRequest;
        //}

        public object Create(object request, ISpecimenContext context)
        {
            //var propertyInfo = request as PropertyInfo;
            //if (propertyInfo != null &&
            //    propertyInfo.Name.Equals("SpecInlineData") &&
            //    propertyInfo.PropertyType == typeof(SpecInlineData))
            //{
            //    //return new OmitSpecimen();
            //    return createData();
            //}

           // var negativeRequest = request as NegativeRequest;
            var specInlineData=new SpecInlineData();
            specInlineData.Numbers=new int[5];


            for (int i = 0; i < 5; i++)
            {
                specInlineData.Numbers[i] = new Random().Next(-100,-1);
            }

            specInlineData.Result = specInlineData.Numbers.Sum();


            return specInlineData;


           
        }


      

    }
}
