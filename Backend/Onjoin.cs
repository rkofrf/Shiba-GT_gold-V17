using System;
using System.Collections.Generic;
using System.Text;
using Photon.Realtime;
using GorillaNetworking;
using HarmonyLib;
using Mono;
using UnityEngine;
using GTAG_NotificationLib;
using Displyy_Template.UI;
using Photon.Pun;
using System.Runtime.CompilerServices;

namespace Displyy_Template.Backend
{

    [HarmonyPatch(typeof(GorillaNot))]
    [HarmonyPatch("OnPlayerEnteredRoom", MethodType.Normal)]
    internal class OnJoin : HarmonyPatch
    {
        private static void Prefix(Player newPlayer)
        {
            Mods.sigma = true;
            new System.Threading.Thread(WristMenu.Red);
            if (Mods.notifs)
            {
                NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + newPlayer.NickName + " Joined Lobby");
            }
            new System.Threading.Thread(WristMenu.Red);
        }
    }

    [HarmonyPatch(typeof(GorillaNot))]
    [HarmonyPatch("OnPlayerLeftRoom", MethodType.Normal)]
    internal class OnLeave : HarmonyPatch
    {
        private static void Prefix(Player otherPlayer)
        {
            new System.Threading.Thread(WristMenu.Red);
            if (otherPlayer != PhotonNetwork.LocalPlayer)
            {
                if (Mods.notifs)
                {
                    NotifiLib.SendNotification("<color=blue>[ROOM]:</color> Player " + otherPlayer.NickName + " Left Lobby");
                    if (PhotonNetwork.IsMasterClient)
                    {
                        NotifiLib.SendNotification("<color=yellow>[ROOM]: YOU ARE NOW MASTER CLIENT!</color>");
                    }
                }
            }
            new System.Threading.Thread(WristMenu.Red);
        }
    }
}
