using System.Collections.Generic;
using Bogus;
using System;

namespace SerializerDataGenerator
{
    public static class FakeRequestModelsGenerator
    {
        public static List<RequestModel> GenerateRequestModels(int number)
        {
            var generator = new Faker<RequestModel>();
            var result = new List<RequestModel>();

            for (var k = 0; k < number; ++k)
            {
                var requestModel = generator
                    .CustomInstantiator(f => new RequestModel())
                    .RuleFor(r => r.Index, f => f.Random.Number(0, int.MaxValue))
                    .RuleFor(r => r.Name, f => f.Random.String(maxChar: (char)255))
                    .RuleFor(r => r.Visits, f => f.Random.Number(0, int.MaxValue))
                    .RuleFor(r => r.Date, f => f.Date.Between(DateTime.Parse("0001-01-01"), DateTime.Parse("9999-12-31")))
                    .Generate();

                result.Add(requestModel);
                    
            }

            return result;
        }

        private static string ConvertCharsToString(char[] chars)
        {
            var result = "";
            foreach (var c in chars)
                result += c;
            return result;
        }

    }
}
