using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestRisk.Specifications
{
    public interface ISpecification<Entity>
    {
        string RiskClient { get; }
        bool IsSatisfiedBy(List<Entity> entity);
    }
}
