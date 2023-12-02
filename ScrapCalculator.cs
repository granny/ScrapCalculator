using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace ScrapCalculator
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class ScrapCalculator : BaseUnityPlugin
    {

        internal static ManualLogSource Log;
        
        private void Awake()
        {
            Log = Logger;

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
