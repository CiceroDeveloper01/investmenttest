using ConsoleTestRisk.AbstractFactory.Interface;

namespace ConsoleTestRisk.Domain
{
    public class Categories : ICategories
    {
        public int IDCategorie { get; }
        public string NameCategory { get; }
        public string LevelCategory { get; }
        public double ValueCategory { get; }
        public string ClientSector { get; }
        public Categories(int idcategorie, string namecategory, string levelcategory, double valuecategory, string clientsector)
        {
            IDCategorie = idcategorie;
            NameCategory = namecategory;
            LevelCategory = levelcategory;
            ValueCategory = valuecategory;
            ClientSector = clientsector;
        }
    }
}