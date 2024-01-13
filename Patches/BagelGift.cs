using HarmonyLib;
using GameNetcodeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotBagels.Patches
{
    [HarmonyPatch(typeof(GiftBoxItem))] // Finds Assembly in Game Code from ILSpy to Modify
    internal class BagelOpen
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        static void OverrideAudio(GiftBoxItem __instance) // Audio override of assembly
        {
            __instance.openGiftAudio = BagelsBase.SoundFX[0]; // public command from ILSpy is modified using sound effect assets from plugin
        }
    }
}
