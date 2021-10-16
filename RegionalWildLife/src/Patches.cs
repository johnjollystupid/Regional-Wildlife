using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;


namespace RegionalWildLife
{
    internal class Patches
    {
        [HarmonyPatch(typeof(SpawnRegion), "Start")]
        internal class ChangeWildlifeSpawns
        {
            private static void Postfix(SpawnRegion __instance)
            {

                GetSettings(__instance);

            }
        }

        private static void GetSettings(SpawnRegion spawnRegion)
        {
            string activeScene = GameManager.m_ActiveScene;
            if (activeScene is null) return;

            if (activeScene == "AshCanyonRegion") AddWildLife(spawnRegion, Settings.options.ashCanyonWildLife);
            else if (activeScene == "CanneryRegion") AddWildLife(spawnRegion, Settings.options.bleakInletWildLife);
            else if (activeScene == "CoastalRegion") AddWildLife(spawnRegion, Settings.options.coastalHighwayWildLife);
            else if (activeScene == "CrashMountainRegion") AddWildLife(spawnRegion, Settings.options.timberwolfMountainWildLife);
            else if (activeScene == "DamRiverTransitionZoneB") AddWildLife(spawnRegion, Settings.options.windingRiverWildLife);
            else if (activeScene == "HighwayTransitionZone") AddWildLife(spawnRegion, Settings.options.crumblingHighwayWildLife);
            else if (activeScene == "LakeRegion") AddWildLife(spawnRegion, Settings.options.mysteryLakeWildLife);
            else if (activeScene == "MarshRegion") AddWildLife(spawnRegion, Settings.options.forlornMuskegWildLife);
            else if (activeScene == "MountainTownRegion") AddWildLife(spawnRegion, Settings.options.mountainTownWildLife);
            else if (activeScene == "RiverValleyRegion") AddWildLife(spawnRegion, Settings.options.hushedRiverValleyWildLife);
            else if (activeScene == "RuralRegion") AddWildLife(spawnRegion, Settings.options.pleasantValleyWildLife);
            else if (activeScene == "TracksRegion") AddWildLife(spawnRegion, Settings.options.brokenRailroadWildLife);
            else if (activeScene == "WhalingStationRegion") AddWildLife(spawnRegion, Settings.options.desolationPointWildLife);
            else if (activeScene == "BlackrockPrisonZone") AddWildLife(spawnRegion, Settings.options.blackrockWildLife);
            else if (activeScene == "BlackrockRegion") AddWildLife(spawnRegion, Settings.options.blackrockWildLife);
        }

        
        

        static int spawnsDayPilgrim = 0;
        static int spawnsDayVoyager = 0;
        static int spawnsDayStalker = 0;
        static int spawnsDayInterloper = 0;
        static int spawnsNightPilgrim = 0;
        static int spawnsNightVoyager = 0;
        static int spawnsNightStalker = 0;
        static int spawnsNightInterloper = 0;

        private static void AddWildLife(SpawnRegion spawnRegion, AnimalType animalType)
        {
            

            if (spawnRegion is null) return;

            switch(animalType)
            {
                case AnimalType.Default:
                    //Do Nothing
                    return;

                case AnimalType.NoWildlife:

                    RemoveWildlife(spawnRegion);

                    return;

                case AnimalType.Rabbits:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Rabbit) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Rabbit) SetWildlifeSpawns(spawnRegion);

                    return;

                case AnimalType.Deer:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Stag) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Stag) SetWildlifeSpawns(spawnRegion);

                    return;

                case AnimalType.Bears:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Bear) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Bear) SetWildlifeSpawns(spawnRegion);

                    return;

                case AnimalType.Moose:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Moose) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Moose) SetWildlifeSpawns(spawnRegion);

                    return;

                case AnimalType.Wolves:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Wolf) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Wolf) SetWildlifeSpawns(spawnRegion);

                    return;

                case AnimalType.Timberwolves:
                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Wolf) GetWildlifeSpawns(spawnRegion);

                    RemoveWildlife(spawnRegion);

                    CreateTimberwolves(spawnRegion);

                    if (spawnRegion.m_AiSubTypeSpawned == AiSubType.Wolf) SetWildlifeSpawns(spawnRegion);

                    return;


            }
        }


        private static void GetWildlifeSpawns(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;

            spawnsDayInterloper = spawnRegion.m_MaxSimultaneousSpawnsDayInterloper;
            spawnsDayPilgrim = spawnRegion.m_MaxSimultaneousSpawnsDayPilgrim;
            spawnsDayStalker = spawnRegion.m_MaxSimultaneousSpawnsDayStalker;
            spawnsDayVoyager = spawnRegion.m_MaxSimultaneousSpawnsDayVoyageur;
            spawnsNightInterloper = spawnRegion.m_MaxSimultaneousSpawnsNightInterloper;
            spawnsNightPilgrim = spawnRegion.m_MaxSimultaneousSpawnsNightPilgrim;
            spawnsNightStalker = spawnRegion.m_MaxSimultaneousSpawnsNightStalker;
            spawnsNightVoyager = spawnRegion.m_MaxSimultaneousSpawnsNightVoyageur; 
        }

        private static void SetWildlifeSpawns(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;

            spawnRegion.m_MaxSimultaneousSpawnsDayInterloper = spawnsDayInterloper;
            spawnRegion.m_MaxSimultaneousSpawnsDayPilgrim = spawnsDayPilgrim;
            spawnRegion.m_MaxSimultaneousSpawnsDayStalker = spawnsDayStalker;
            spawnRegion.m_MaxSimultaneousSpawnsDayVoyageur = spawnsDayVoyager;
            spawnRegion.m_MaxSimultaneousSpawnsNightInterloper = spawnsNightInterloper;
            spawnRegion.m_MaxSimultaneousSpawnsNightPilgrim = spawnsNightPilgrim;
            spawnRegion.m_MaxSimultaneousSpawnsNightStalker = spawnsNightStalker;
            spawnRegion.m_MaxSimultaneousSpawnsNightVoyageur = spawnsNightVoyager;
        }

        private static void RemoveWildlife(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;

            spawnRegion.m_MaxSimultaneousSpawnsDayInterloper = 0;
            spawnRegion.m_MaxSimultaneousSpawnsDayPilgrim = 0;
            spawnRegion.m_MaxSimultaneousSpawnsDayStalker = 0;
            spawnRegion.m_MaxSimultaneousSpawnsDayVoyageur = 0;
            spawnRegion.m_MaxSimultaneousSpawnsNightInterloper = 0;
            spawnRegion.m_MaxSimultaneousSpawnsNightPilgrim = 0;
            spawnRegion.m_MaxSimultaneousSpawnsNightStalker = 0;
            spawnRegion.m_MaxSimultaneousSpawnsNightVoyageur = 0;
        }

        private static void CreateTimberwolves(SpawnRegion spawnRegion)
        {
            if (spawnRegion is null) return;
            GameObject timberwolf = Resources.Load("WILDLIFE_Wolf_grey")?.Cast<GameObject>();
            GameObject timberwolf_aurora = Resources.Load("WILDLIFE_Wolf_grey_aurora")?.Cast<GameObject>();
            if (timberwolf && timberwolf_aurora)
            {
                spawnRegion.m_AuroraSpawnablePrefab = timberwolf_aurora;
                spawnRegion.m_SpawnablePrefab = timberwolf;
                
            }
        }

        

    }
}

    
    
        




   

