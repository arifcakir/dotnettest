using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentSpecification.Abstractions.Validation;

namespace SMS.Core.Extensions
{
  public  static class ErrorExceptionEntensions
    {


        public static IReadOnlyList<FailedSpecification> ToFilteredSpecs(this IReadOnlyList<FailedSpecification> failedSpecifications, string propertyName)
        {
            var failedSpecs = new List<FailedSpecification>();

            foreach (var resultFailedSpecification in failedSpecifications)
            {
                var value = resultFailedSpecification.Parameters.Where(t => t.Value.ToString().Contains(propertyName)).FirstOrDefault();

                if (value.Value != null)
                {
                    failedSpecs.Add(resultFailedSpecification);
                }

            }

            return failedSpecs;

        }


    }
}
