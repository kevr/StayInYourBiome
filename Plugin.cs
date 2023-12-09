using BepInEx;
using StayInYourBiome.Patches;
using HarmonyLib;
using System.Reflection;

namespace StayInYourBiome
{
    [BepInPlugin(Plugin.GUID, Plugin.NAME, Plugin.VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string NAME = "StayInYourBiome";
        public const string AUTHOR = "Kevver";
        public const string GUID = $"{AUTHOR}.{NAME}";
        public const string VERSION = "1.0.2";

        private readonly Harmony harmony = new(NAME);

        private void Awake()
        {
            // Initialize loggers
            BepInEx.Logging.Logger.Sources.Add(UpdateSpawnList.Logger);

            // Patch assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            harmony.PatchAll(assembly);
        }
    }
}
