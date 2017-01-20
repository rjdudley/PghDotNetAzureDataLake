using Microsoft.Analytics.Interfaces;
using System.Collections.Generic;
using System;

namespace PghDotNetDataLake
{
    public class NameChanger : IProcessor
    {

        private static IDictionary<string, string> NewName = new Dictionary<string, string>
         {
             {
                 "John", "Bubba"
             }
         };
        public override IRow Process(IRow input, IUpdatableRow output)
        {
            string State = input.Get<string>("State");
            string Gender = input.Get<string>("Gender");
            int Year = input.Get<int>("Year");
            string Name = input.Get<string>("Name");

            if (NewName.Keys.Contains(Name))
            {
                Name = NewName[Name];
            }
            int Instances = input.Get<int>("Instances");

            output.Set<string>(0, State);
            output.Set<string>(1, Gender);
            output.Set<int>(2, Year);
            output.Set<string>(3, Name);
            output.Set<int>(4, Instances);

            return output.AsReadOnly();
        }
    }
}
