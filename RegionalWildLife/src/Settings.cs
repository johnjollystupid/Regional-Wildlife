using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ModSettings;

namespace RegionalWildLife
{

    public enum AnimalType
    {
        Default,
        NoWildlife,
        Rabbits,
        Deer,
        Wolves,
        Timberwolves,
        Bears,
        Moose
    }

    internal class RegionalWildLifeSettings : JsonModSettings
    {

        [Name("Ash Canyon")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves","Bears","Moose")]
        public AnimalType ashCanyonWildLife = AnimalType.Default;

        [Name("Blackrock")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType blackrockWildLife = AnimalType.Default;

        [Name("Bleak Inlet")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType bleakInletWildLife = AnimalType.Default;

        [Name("Broken Railroad")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType brokenRailroadWildLife = AnimalType.Default;

        [Name("Coastal Highway")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType coastalHighwayWildLife = AnimalType.Default;

        [Name("Crumbling Highway")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType crumblingHighwayWildLife = AnimalType.Default;

        [Name("Desolation Point")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType desolationPointWildLife = AnimalType.Default;

        [Name("Forlorn Muskeg")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType forlornMuskegWildLife = AnimalType.Default;

        [Name("Hushed River Valley")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType hushedRiverValleyWildLife = AnimalType.Default;

        [Name("Mountain Town")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType mountainTownWildLife = AnimalType.Default;

        [Name("Mystery Lake")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType mysteryLakeWildLife = AnimalType.Default;

        [Name("Pleasant Valley")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType pleasantValleyWildLife = AnimalType.Default;

        [Name("Timberwolf Mountain")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType timberwolfMountainWildLife = AnimalType.Default;

        [Name("Winding River")]
        [Description(Implementation.settingDescription)]
        [Choice("Default", "No Wildlife", "Rabbits", "Deer", "Wolves", "Timberwolves", "Bears", "Moose")]
        public AnimalType windingRiverWildLife = AnimalType.Default;


    }
    internal static class Settings
    {
        internal static RegionalWildLifeSettings options;

        internal static void OnLoad()
        {
            options = new RegionalWildLifeSettings();
            options.AddToModSettings("Regional Wildlife", MenuType.MainMenuOnly);
        }

    }
}
