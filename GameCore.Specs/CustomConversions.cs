using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameCore.Specs
{
    //Basically acts like a model binder
    [Binding]
    public class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransformation(int daysAgo)
        {
            return DateTime.Now.AddDays(-daysAgo);
        }

        [StepArgumentTransformation]
        public IEnumerable<Weapon> WeaponsTansformation(Table table)
        {
            return table.CreateSet<Weapon>();
        } 
    }
}
