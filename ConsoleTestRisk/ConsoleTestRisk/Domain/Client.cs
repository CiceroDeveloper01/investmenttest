using ConsoleTestRisk.AbstractFactory.Interface;

namespace ConsoleTestRisk.Domain
{
    public class Client : ITrade
    {
        public int IDClient { get; }
        public string Name { get; }
        public double ValueClient { get; }
        public string ClientSector { get; }
        public Client(int idclient, string name, double valueclient, string clientsector)
        {
            IDClient = idclient;
            Name = name;
            ValueClient = valueclient;
            ClientSector = clientsector;
        }
    }
}
