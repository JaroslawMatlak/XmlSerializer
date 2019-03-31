using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SerializerDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArgument = GetFirstArgumentIntegerValue(args);

            var requestModels = FakeRequestModelsGenerator.GenerateRequestModels(firstArgument);

            HttpDataSender.SendRequestModelsCollectionToSerializerApi(requestModels);

            Console.Write(JsonConvert.SerializeObject(requestModels));
            Console.ReadKey();
        }

        private static int GetFirstArgumentIntegerValue(string[] args)
        {
            var result = 0;
            if (args.Length == 0)
            {
                ShowException("The application requires one argument of type INT");
                return 0;
            }
            if(!int.TryParse(args[0], out result))
            {
                ShowException("The application requires one argument of type INT");
                return 0;
            }
            return result;
        }

        private static void ShowException(string message)
        {
            Console.WriteLine("Exception: " + message);
            Console.ReadKey();
        }
    }
}
