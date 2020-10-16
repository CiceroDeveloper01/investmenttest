using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.AbstractFactory.Interface
{
    public interface ITrade
    {
        int IDClient { get; set; }
        string Name { get; set; }
        double ValueClient { get; set; }
        string ClientSector { get; set; }
    }
}
