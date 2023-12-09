using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using BepInEx.Logging;

namespace StayInYourBiome.Patches;

[HarmonyPatch(typeof(SpawnSystem), nameof(SpawnSystem.UpdateSpawnList))]
static class UpdateSpawnList
{
    public static ManualLogSource Logger = new ManualLogSource($"{Plugin.GUID}.UpdateSpawning");

    static bool Prefix(SpawnSystem __instance, List<SpawnSystem.SpawnData> spawners, DateTime currentTime, bool eventSpawners)
    {
        // Modify all spawners
        foreach (SpawnSystem.SpawnData spawner in spawners)
        {
            string fixedKey = "defeated_kevver";
            bool keyIsNull = string.IsNullOrEmpty(spawner.m_requiredGlobalKey);
            bool beenFixed = spawner.m_requiredGlobalKey == fixedKey;
            if (!keyIsNull && !beenFixed)
            {
                Logger.LogInfo($"Changing spawner required global key from '{spawner.m_requiredGlobalKey}' to '{fixedKey}'");
                spawner.m_requiredGlobalKey = fixedKey;
            }
        }

        return true;
    }
}
