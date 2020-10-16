using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.AbstractFactory.Interface
{
    public interface ICategories
    {
        int IDCategorie { get; set; }
        string NameCategory { get; set; }
        string LevelCategory { get; set; }
        double ValueCategory { get; set; }
        string ClientSector { get; set; }
    }
}
