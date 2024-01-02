using System.Collections.Generic;
using System.Linq;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace ScrapCalculator.Patches
{
    [HarmonyPatch]
    public class HudManagerPatcher
    {
        private enum ScanType
        {
            Default,
            Enemy,
            Scrap
        }

        private static int _totalNodes;

        [HarmonyPostfix]
        [HarmonyPatch(typeof(HUDManager), nameof(HUDManager.UpdateScanNodes))]
        private static void OnScan(HUDManager __instance, PlayerControllerB playerScript)
        {
            if (GameNetworkManager.Instance.localPlayerController == null)
            {
                return; // only run if player exists
            }

            if (!StartOfRound.Instance.inShipPhase && !GameNetworkManager.Instance.localPlayerController.isInHangarShipRoom)
            {
                return; // only run when in the ship
            }

            if (_totalNodes == __instance.scanNodes.Count)
            {
                return; // only run when nodes are added/removed
            }
            _totalNodes = __instance.scanNodes.Count;

            List<KeyValuePair<RectTransform, ScanNodeProperties>> scraps = __instance.scanNodes
                .Where(pair => pair.Value.nodeType == (int) ScanType.Scrap)
                .OrderByDescending(pair => pair.Value.scrapValue)
                .ToList();

            int quota = TimeOfDay.Instance.profitQuota - TimeOfDay.Instance.quotaFulfilled;
            for (var i = 0; i < scraps.Count;)
            {
                var scrap = scraps[i];
                int amount = quota - scrap.Value.scrapValue;

                if (amount >= 0)
                {
                    scrap.Key.GetComponent<Animator>().SetInteger("colorNumber", (int) ScanType.Enemy);
                    scraps.Remove(scrap);
                    quota = amount;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
