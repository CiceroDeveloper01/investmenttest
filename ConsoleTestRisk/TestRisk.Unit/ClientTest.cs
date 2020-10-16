using ConsoleTestRisk;
using ConsoleTestRisk.Domain;
using ConsoleTestRisk.Interface;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestRisk.Unit
{
    public class ClientTest
    {
        public readonly IOperationsBasicRepository<Client> operationsBasicRepository;
        public ClientTest()
        {
            Mock<IOperationsBasicRepository<Client>> mockClientRepository = new Mock<IOperationsBasicRepository<Client>>();

            IList<Client> trades = new List<Client>();
            trades.Add(new Client(1, "Credit Suisse", 2000000, ETypeCompany.Private.ToString()));
            trades.Add(new Client(2, "Prefeitura de São Paulo", 400000, ETypeCompany.Public.ToString()));
            trades.Add(new Client(3, "Estado de São Paulo", 500000, ETypeCompany.Public.ToString()));
            trades.Add(new Client(4, "Governo Federal do Brasil", 3000000, ETypeCompany.Public.ToString()));

            mockClientRepository.Setup(mr => mr.Get()).Returns(trades);

            mockClientRepository.Setup(mr => mr.GetID(It.IsAny<int>())).Returns((int i) => trades.Where(x => x.IDClient == i).Single());

            mockClientRepository.Setup(mr => mr.Insert(It.IsAny<Client>())).Returns((Client cli) =>
            {
                trades.Add(cli);
                return true;
            });

            mockClientRepository.Setup(mr => mr.Update(It.IsAny<Client>())).Returns((Client cli) =>
            {
                var original = trades.Where(q => q.IDClient == cli.IDClient).Single();
                if (original != null)
                {
                    original.Name = cli.Name;
                    original.ValueClient = cli.ValueClient;
                }
                return true;
            });

            mockClientRepository.Setup(mr => mr.Delete(It.IsAny<Client>())).Returns((Client cli) =>
            {
                var original = trades.Where(q => q.IDClient == cli.IDClient).Single();
                if (original != null)
                {
                    trades.Remove(original);
                }
                return true;
            });
            this.operationsBasicRepository = mockClientRepository.Object;
        }

        [Fact]
        public void CanReturnClientById()
        {
            Client testClient = this.operationsBasicRepository.GetID(2);

            Assert.NotNull(testClient); 
            Assert.Equal("Prefeitura de São Paulo", testClient.Name); 
        }

        [Fact]
        public void CanInsertClient()
        {
            Client newClient = new Client(5, "Unilever Brasil S/A", 2000000, ETypeCompany.Private.ToString());
            
            int clientCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(4, clientCount); 
            
            this.operationsBasicRepository.Insert(newClient);
            
            clientCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(5, clientCount);
        }

        [Fact]
        public void CanUpdateClient()
        {
            Client testClient = this.operationsBasicRepository.GetID(1);

            testClient.Name = "Credit Suisse S/A";

            this.operationsBasicRepository.Update(testClient);

            Assert.Equal("Credit Suisse S/A", this.operationsBasicRepository.GetID(1).Name);
        }

        [Fact]
        public void CanDeleteClient()
        {
            Client testClient = this.operationsBasicRepository.GetID(1);

            int clientCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(4, clientCount);

            this.operationsBasicRepository.Delete(testClient);

            clientCount = this.operationsBasicRepository.Get().Count();
            Assert.Equal(3, clientCount);   
        }
    }
}
