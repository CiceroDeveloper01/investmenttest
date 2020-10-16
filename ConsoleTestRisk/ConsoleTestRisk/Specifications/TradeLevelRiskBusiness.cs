using ConsoleTestRisk.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTestRisk.Specifications
{
    public class TradeLevelRiskBusiness : ISpecification<Categories>
    {
        public Client Client { get; private set; }

        public string RiskClient { get; private set; }

        public TradeLevelRiskBusiness(Client client)
        {
            Client = client;
        }

        public bool IsSatisfiedBy(List<Categories> categories)
        {
            var categoriestrade = categories.Where(x => x.ClientSector == Client.ClientSector).ToList();
            foreach (var categorie in categoriestrade)
            {
                ELevelRisk eLevelRisk = (ELevelRisk)Enum.Parse(typeof(ELevelRisk), categorie.LevelCategory, true);
                switch (eLevelRisk)
                {
                    case ELevelRisk.LowRisk:
                        if (Client.ValueClient < categorie.ValueCategory)
                        {
                            RiskClient = categorie.LevelCategory;
                            return true;
                        }
                        break;
                    case ELevelRisk.MediumRisk:
                    case ELevelRisk.HighRisk:
                        if (Client.ValueClient >= categorie.ValueCategory)
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
