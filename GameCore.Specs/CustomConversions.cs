using System;
using TechTalk.SpecFlow;

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
    }
}
