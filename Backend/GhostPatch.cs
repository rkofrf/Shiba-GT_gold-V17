using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using HarmonyLib;
using System.Threading;
using System.Net;
using Photon.Pun;
using System.Linq;
using GorillaLocomotion.Gameplay;

namespace Displyy_Template.Backend
{
    [HarmonyPatch(typeof(VRRig), "OnDisable")]
    internal class GhostPatch : MonoBehaviour
    {
        public static bool Prefix(VRRig __instance)
        {
            return !(__instance == GorillaTagger.Instance.offlineVRRig);
        }
    }
}
