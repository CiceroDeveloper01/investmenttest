using ConsoleTestRisk;
using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestRisk.Unit
{
    public class CategorieTest
    {
        public readonly IOperationsBasicRepository<Categories> operationsBasicRepository;
        public CategorieTest()
        {
            Mock<IOperationsBasicRepository<Categories>> mockClientRepository = new Mock<IOperationsBasicRepository<Categories>>();

            IList<Categories> categories = new List<Categories>();
            categories.Add(new Categories(1, "Baixo Risco Operacional e Baixa Rentabilidade", ELevelRisk.LowRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(2, "Médio Risco Operacional e Média Rentabilidade", ELevelRisk.MediumRisk.ToString(), 1000000, ETypeCompany.Public.ToString()));
            categories.Add(new Categories(3, "Alto Risco Operacional e Alta Rentabilidade", ELevelRisk.HighRisk.ToString(), 1000000, ETypeCompany.Private.ToString()));

            mockClientRepository.Setup(mr => mr.Get()).Returns(categories);

            mockClientRepository.Setup(mr => mr.GetID(It.IsAny<int>())).Returns((int i) => categories.Where(x => x.IDCategorie == i).Single());

            mockClientRepository.Setup(mr => mr.Insert(It.IsAny<Categories>())).Returns((Categories cat) =>
            {
                categories.Add(cat);
                return true;
            });

            mockClientRepository.Setup(mr => mr.Update(It.IsAny<Categories>())).Returns((Categories cat) =>
            {
                var original = categories.Where(q => q.IDCategorie == cat.IDCategorie).Single();
                if (original != null)
                {
                    original.NameCategory = cat.NameCategory;
                    original.ValueCategory = cat.ValueCategory;
                }
                return true;
            });

            mockClientRepository.Setup(mr => mr.Delete(It.IsAny<Categories>())).Returns((Categories cat) =>
            {
                var original = categories.Where(q => q.IDCategorie == cat.IDCategorie).Single();
                if (original != null)
                {
                    categories.Remove(original);
                }
                return true;
            });
            this.operationsBasicRepository = mockClientRepository.Object;
        }

        [Fact]
        public void CanReturnClientById()
        {
            Categories testCategories = this.operationsBasicRepository.GetID(2);

            Assert.NotNull(testCategories);
            Assert.Equal("Médio Risco Operacional e Média Rentabilidade", testCategories.NameCategory);
        }

        [Fact]
        public void CanInsertCategories()
        {
            Categories newCategories = new Categories(4, "Alto Risco Operacional e Baixa Rentabilidade", ELevelRisk.HighRisk.ToString(), 1000000, ETypeCompany.Private.ToString());

            int categoriesCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(3, categoriesCount);

            this.operationsBasicRepository.Insert(newCategories);

            categoriesCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(4, categoriesCount);
        }

        [Fact]
        public void CanUpdateCategories()
        {
            Categories testCategories = this.operationsBasicRepository.GetID(1);

            testCategories.NameCategory = "Alto Risco Operacional e Baixa Rentabilidade";

            this.operationsBasicRepository.Update(testCategories);

            Assert.Equal("Alto Risco Operacional e Baixa Rentabilidade", this.operationsBasicRepository.GetID(1).NameCategory);
        }

        [Fact]
        public void CanDeleteCategories()
        {
            Categories testCategories = this.operationsBasicRepository.GetID(1);

            int categoriesCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(3, categoriesCount);

            this.operationsBasicRepository.Delete(testCategories);

            categoriesCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(2, categoriesCount);
        }
    }
}
