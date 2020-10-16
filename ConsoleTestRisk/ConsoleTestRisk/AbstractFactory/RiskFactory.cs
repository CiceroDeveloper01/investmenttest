using ConsoleTestRisk.AbstractFactory.Interface;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleTestRisk.AbstractFactory
{
    public abstract class RiskFactory
    {
        public abstract List<string> CalculatedRisk(List<ITrade> trades, List<ICategories> categories);
    }
}
