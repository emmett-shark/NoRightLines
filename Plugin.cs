using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace NoRightLines;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake() => new Harmony(PluginInfo.PLUGIN_GUID).PatchAll();

    [HarmonyPatch(typeof(LevelSelectController), nameof(LevelSelectController.Start))]
    public static class LevelSelectControllerStartPatches
    {
        public static void Postfix()
        {
            GameObject.Find("MainCanvas/FullScreenPanel/GameButtonsPanel/RightLines").SetActive(false);
        }
    }
}
