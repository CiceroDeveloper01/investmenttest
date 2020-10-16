using ConsoleTestRisk;
using ConsoleTestRisk.AbstractFactory;
using ConsoleTestRisk.AbstractFactory.Interface;
using ConsoleTestRisk.Domain;
using System.Collections.Generic;
using Xunit;

namespace TestRisk.Unit
{
    public class RiskFactoryTest
    {
        [Fact]
        public void TestListReturnRisks()
        {
            var riskCalculatedAssert = new List<string>();
            riskCalculatedAssert.Add("LowRisk - Prefeitura de São Paulo");
            riskCalculatedAssert.Add("LowRisk - Estado de São Paulo");
            riskCalculatedAssert.Add("MediumRisk - Governo Federal do Brasil");
            riskCalculatedAssert.Add("HighRisk - Credit Suisse");


            List <ITrade> trades = new List<ITrade>();
            trades.Add(new Client(1, "Credit Suisse", 2000000, ETypeCompany.Private.ToString()));
            trades.Add(new Client(2, "Prefeitura de São Paulo", 400000, ETypeCompany.Public.ToString()));
            trades.Add(new Client(3, "Estado de São Paulo", 500000, ETypeCompany.Public.ToString()));
            trades.Add(new Client(4, "Governo Federal do Brasil", 3000000, ETypeCompany.Public.ToString()));
            
            List<ICategories> categories = new List<ICategories>();
            categories.Add(new Categories(1, "Baixo Risco Operacional e Baixa Rentabilidade", ELevelRisk.LowRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(2, "Médio Risco Operacional e Média Rentabilidade", ELevelRisk.MediumRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(3, "Alto Risco Operacional e Alta Rentabilidade", ELevelRisk.HighRisk.ToString(), 1000000, ETypeCompany.Private.ToString()));

            var risk = new Risk();
            var resultstestmethod = risk.CalculatedRisk(trades, categories);

            Assert.Equal(riskCalculatedAssert, resultstestmethod);

        }
    }
}
