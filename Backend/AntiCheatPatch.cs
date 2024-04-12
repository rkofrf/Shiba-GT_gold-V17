using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using PlayFab;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Displyy_Template.Backend
{
    [HarmonyPatch(typeof(GorillaNot), "SendReport")]
    internal class anticheatnotif : MonoBehaviour
    {
        private static bool Prefix(string susReason, string susId, string susNick)
        {
            if (susId == PhotonNetwork.LocalPlayer.UserId)
            {
                if (susReason != "empty rig")
                {
                    Debug.Log("report");
                    NotifiLib.SendNotification("<color=red>[ANTICHEAT] REPORTED FOR: " + susReason + "</color>");
                }
            }
            return false;
        }
    }
}
