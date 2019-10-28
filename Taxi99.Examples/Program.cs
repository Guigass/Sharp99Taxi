using System;
using Taxi99;
using Taxi99.Models;

namespace Taxi99.Examples
{
    class Program
    {
        static string _apiToken = "SEU TOKEN API";
        static void Main(string[] args)
        {
            //Você pode passar a URL do sandbox para teste, caso não passe nada ele usará a url de PRODUÇÂO
            //using (var service99 = new Services99(_apiToken, "https://sandbox-api-corp.99app.com/v1"))
            using (var service99 = new Services99(_apiToken))
            {
                var companies = service99.GetCompanies().Result;
            }
        }
    }
}
