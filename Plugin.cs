using BepInEx;
using BepInEx.Logging;
using GotBagels.Patches;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GotBagels
{
    [BepInPlugin(modGUID,modName,modVersion)]
    public class BagelsBase : BaseUnityPlugin
    {
        private const string modGUID = "We.GotBagels";
        private const string modName = "GotBagels";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static BagelsBase Instance;

        internal ManualLogSource mls;

        internal static List<AudioClip> SoundFX;
        internal static AssetBundle Bundle;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Fresh Bagels out of the oven!");

            harmony.PatchAll(typeof(BagelsBase));   // Patches in Bagel parent class into the game
            harmony.PatchAll(typeof(BagelSoundStartofRound)); // Patches sound effect logic for game start up speaker
            harmony.PatchAll(typeof(BagelOpen));    // Patches in bagel open class for gift boxharmony.PatchAll(typeof(BagelSoundStartofRound));

            mls = Logger;

            SoundFX = new List<AudioClip>();

            string FolderLocation = Instance.Info.Location;
            FolderLocation = FolderLocation.TrimEnd("GotBagels.dll".ToCharArray());
            Bundle = AssetBundle.LoadFromFile(FolderLocation + "bagels");
            if(Bundle != null)
            {
                mls.LogInfo("Successfully buttered bagels!");
                SoundFX = Bundle.LoadAllAssets<AudioClip>().ToList();
            }
            else
            {
                mls.LogError("Failed to load bagel assets. Bagels are burnt :(");
            }

        }

    }
}
