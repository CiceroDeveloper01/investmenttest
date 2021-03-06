﻿using ConsoleTestRisk.AbstractFactory.Interface;

namespace ConsoleTestRisk.Domain
{
    public class Categories : ICategories
    {
        public int IDCategorie { get; set; }
        public string NameCategory { get; set; }
        public string LevelCategory { get; set; }
        public double ValueCategory { get; set; }
        public string ClientSector { get; set; }
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