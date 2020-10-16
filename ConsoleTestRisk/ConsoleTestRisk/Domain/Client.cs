using ConsoleTestRisk.AbstractFactory.Interface;

namespace ConsoleTestRisk.Domain
{
    public class Client : ITrade
    {
        public int IDClient { get; set; }
        public string Name { get; set; }
        public double ValueClient { get; set; }
        public string ClientSector { get; set; }
        public Client(int idclient, string name, double valueclient, string clientsector)
        {
            IDClient = idclient;
            Name = name;
            ValueClient = valueclient;
            ClientSector = clientsector;
        }
    }
}
