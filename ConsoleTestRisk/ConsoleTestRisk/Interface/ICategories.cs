using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.AbstractFactory.Interface
{
    public interface ICategories
    {
        int IDCategorie { get; }
        string NameCategory { get; }
        string LevelCategory { get; }
        double ValueCategory { get; }
        string ClientSector { get; }
    }
}
