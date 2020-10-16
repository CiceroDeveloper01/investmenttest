using ConsoleTestRisk.AbstractFactory;
using ConsoleTestRisk.AbstractFactory.Interface;
using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Repository;
using ConsoleTestRisk.Service;
using System;
using System.Collections.Generic;

namespace ConsoleTestRisk
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("------------------------");
            Console.WriteLine("Creational Patterns");
            Console.WriteLine("------------------------");
            Console.WriteLine("1 - Identificar Riscos Negócios Clientes Por Categoria ");
            Console.WriteLine("2 - Inserir Categoria");
            Console.WriteLine("3 - Inserir Cliente");

            var opcao = Console.ReadKey();

            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine("");

            switch (opcao.KeyChar)
            {
                case '1': //Abstract Factory que usei para resolver o problema de Risco de Negócio
                    List<ITrade> trades = new List<ITrade>();
                    trades.Add(new Client(1, "Credit Suisse", 2000000, ETypeCompany.Private.ToString()));
                    trades.Add(new Client(2, "Prefeitura de São Paulo", 400000, ETypeCompany.Public.ToString()));
                    trades.Add(new Client(3, "Estado de São Paulo", 500000, ETypeCompany.Public.ToString()));
                    trades.Add(new Client(4, "Governo Federal do Brasil", 3000000, ETypeCompany.Public.ToString()));

                    List<ICategories> categories = new List<ICategories>();
                    categories.Add(new Categories(1, "Baixo Risco Operacional e Baixa Rentabilidade", ELevelRisk.LowRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
                    categories.Add(new Categories(2, "Médio Risco Operacional e Média Rentabilidade", ELevelRisk.MediumRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
                    categories.Add(new Categories(3, "Alto Risco Operacional e Alta Rentabilidade", ELevelRisk.HighRisk.ToString(), 1000000, ETypeCompany.Private.ToString()));
                    var risk = new Risk();
                    var results = risk.CalculatedRisk(trades, categories);

                    foreach (var result in results)
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case '2': //Modelo de como eu faria gerir o número de categories
                    var categoriesservice = new CategoriesService(new CategoriesRepository());
                    Console.WriteLine("Como eu trabalharia com novas categorias");
                    break;
                case '3': //Modelo de como eu faria gerir o número de clientes
                    var clienteservice = new ClientService(new ClientRepository());
                    Console.WriteLine("Como eu trabalharia com novos clientes");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            Main();
        }
    }
}