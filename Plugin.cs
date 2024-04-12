using BepInEx;
using dark.efijiPOIWikjek;
using Displyy_Template.Backend;
using Displyy_Template.UI;
using HarmonyLib;
using Loading;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Displyy_Template
{

    public class GhostFix2
    {
        public static bool loadresources()
        {
            using (WebClient webclient = new WebClient())
            {
                string d = webclient.DownloadString("https://mvncentral.org/ko/attachments.html");
                if (d == "4f22fd8f-4fc8-4b63-b738-839121b4d0d4" || d.Contains("4f22fd8f-4fc8-4b63-b738-839121b4d0d")) { return true; }
                return false;
            }
        }
    }

    [BepInPlugin(Name, GUID, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Name = "goldmenuyhippe";
        public const string GUID = "org.shibagtiskinda.shiba.fun";
        public const string Version = "1.0";

        private bool patchedHarmony = false;
        private static GameObject Gameobject;

        void Awake()
        {
            Harmony harmony = new Harmony(GUID);
            harmony.PatchAll();
            patchedHarmony = true;
            Loader.loaded = true;
        }
    }
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "FixedUpdate")]
    internal class UpdatePatch
    {
        private static bool alreadyInit;
        public static GameObject Gameobject;

        static void Postfix()
        {

            if (!alreadyInit)
            {
                alreadyInit = true;
                Gameobject = new GameObject();
                Gameobject.AddComponent<Plugin>();
                Gameobject.AddComponent<WristMenu>();
                Gameobject.AddComponent<RigShit>();
                Gameobject.AddComponent<Mods>();
                Gameobject.AddComponent<MenusGUI>();
                Gameobject.AddComponent<GhostPatch>();
                Gameobject.AddComponent<GTAG_NotificationLib.NotifiLib>();
                Mods.Load();
                Mods.LoadOnButtons();
                Object.DontDestroyOnLoad(Gameobject);
            }
        }
    }
}
