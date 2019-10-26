# Sharp99Taxi

Sharp99Taxi é uma implementação da API da 99 Taxi Empresas em C# usando .NET Standard.

Para começar a usar você primeiro precisa solicitar um Token junto a 99Taxi.

A Documentação da API está em https://github.com/99taxis/corp-api-documentation

############################ WORK IN PROGRESS #####################################

A Maioria dos metodos já estão implementados porem ainda sem testes, para usar é só seguir o exemplo a seguir.


            using (var service99 = new Services99(_apiToken))
            {
                var companies = service99.GetCompanies().Result;
            }
            
            
Todos os metodos estão dentro de Taxi99.Services99 e os Modelos estão em Taxi99.Models.

Espero estar ajudando.
