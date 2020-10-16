using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.AbstractFactory.Interface
{
    public interface ITrade
    {
        int IDClient { get; }
        string Name { get;  }
        double ValueClient { get; }
        string ClientSector { get; }
    }
}
