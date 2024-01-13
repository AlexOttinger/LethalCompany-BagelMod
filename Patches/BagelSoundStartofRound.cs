using HarmonyLib;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotBagels.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class BagelSoundStartofRound
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void OverrideAudio(StartOfRound __instance)
        {
            __instance.shipIntroSpeechSFX = BagelsBase.SoundFX[0];
        }
    }
}
