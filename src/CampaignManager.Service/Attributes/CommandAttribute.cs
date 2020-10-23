using System;

namespace CampaignManager.Service
{
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }

        public CommandAttribute(string name)
        {
            Name = name;
        }
    }
}