using ConsoleTestRisk.AbstractFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestRisk.AbstractFactory
{
    public class Risk : RiskFactory
    {
        public override List<string> CalculatedRisk(List<ITrade> trades, List<ICategories> categories)
        {
            var riskCalculated = new List<string>();
            List<ITrade> TradesCategories = new List<ITrade>();
            foreach(var categorie in categories)
            {
                ELevelRisk eLevelRisk = (ELevelRisk)Enum.Parse(typeof(ELevelRisk), categorie.LevelCategory, true);
                switch (eLevelRisk)
                {
                    case ELevelRisk.LowRisk:
                        TradesCategories = trades.Where(x => x.ClientSector == categorie.ClientSector && x.ValueClient < categorie.ValueCategory).ToList();
                        break;
                    case ELevelRisk.MediumRisk:
                    case ELevelRisk.HighRisk:
                        TradesCategories = trades.Where(x => x.ClientSector == categorie.ClientSector && x.ValueClient >= categorie.ValueCategory).ToList();
                        break;
                }
                foreach(var tradecategorie in TradesCategories)
                {
                    riskCalculated.Add($"{categorie.LevelCategory} - {tradecategorie.Name}");
                }
            }
            return riskCalculated;
        }
    }
}