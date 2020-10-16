using ConsoleTestRisk.AbstractFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestRisk.Specifications
{
    public class TradeLevelRiskBusiness : ISpecification<ICategories>
    {
        public readonly ITrade _trade;
        public string RiskClient { get; private set; }
        public TradeLevelRiskBusiness(ITrade trade)
        {
            _trade = trade;
        }
        public bool IsSatisfiedBy(List<ICategories> categories)
        {
            var categoriestrade = categories.Where(x => x.ClientSector == _trade.ClientSector).ToList();
            foreach (var categorie in categoriestrade)
            {
                ELevelRisk eLevelRisk = (ELevelRisk)Enum.Parse(typeof(ELevelRisk), categorie.LevelCategory, true);
                switch (eLevelRisk)
                {
                    case ELevelRisk.LowRisk:
                        if (_trade.ValueClient < categorie.ValueCategory)
                        {
                            RiskClient = categorie.LevelCategory;
                            return true;
                        }
                        break;
                    case ELevelRisk.MediumRisk:
                    case ELevelRisk.HighRisk:
                        if (_trade.ValueClient >= categorie.ValueCategory)
                        {
                            RiskClient = categorie.LevelCategory;
                            return true;
                        }
                        break;
                }
            }
            return false;
        }
    }
}
