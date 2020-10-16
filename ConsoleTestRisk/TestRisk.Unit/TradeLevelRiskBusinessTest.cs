using Xunit;
using ConsoleTestRisk;
using ConsoleTestRisk.AbstractFactory.Interface;
using ConsoleTestRisk.Domain;
using System.Collections.Generic;
using ConsoleTestRisk.Specifications;

namespace TestRisk.Unit
{
    public class TradeLevelRiskBusinessTest
    {
        [Fact]
        public void TestListReturnRisks()
        {

            ITrade trade = new Client(1, "Credit Suisse", 2000000, ETypeCompany.Private.ToString());

            List<ICategories> categories = new List<ICategories>();
            categories.Add(new Categories(1, "Baixo Risco Operacional e Baixa Rentabilidade", ELevelRisk.LowRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(2, "Médio Risco Operacional e Média Rentabilidade", ELevelRisk.MediumRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(3, "Alto Risco Operacional e Alta Rentabilidade", ELevelRisk.HighRisk.ToString(), 1000000, ETypeCompany.Private.ToString()));

            var tradeLevelRiskBusiness = new TradeLevelRiskBusiness(trade);
            bool satisfied =  tradeLevelRiskBusiness.IsSatisfiedBy(categories);

            Assert.True(satisfied);
        }
    }
}
