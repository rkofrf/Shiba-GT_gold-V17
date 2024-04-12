using Displyy_Template.Utilities;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using ExitGames.Client.Photon;
using UnityEngine;
using Displyy_Template.UI;
using System.Text;
using System.Threading.Tasks;
using Displyy_Template.UI;
using GorillaNetworking;
using dark.efijiPOIWikjek;
using GorillaLocomotion.Gameplay;
using GorillaExtensions;
using Steamworks;
using HarmonyLib;
using System.Reflection;
using GorillaTag;
using static UnityEngine.UI.GridLayoutGroup;
using Photon.Pun.UtilityScripts;
using System.IO;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using Oculus.Interaction.HandGrab;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using GorillaTagScripts;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Voice.Unity;
using System.ComponentModel;
using UnityEngine.UIElements;
using OVRSimpleJSON;
using GTAG_NotificationLib;
using System.Threading;
using UnityEngine.XR;
using UnityEngine.InputSystem.HID;
using System.Runtime.InteropServices;
using TMPro;
using Random = UnityEngine.Random;
using PlayFab;
using System.Text.RegularExpressions;
using System.Security.Policy;
using UnityEngine.UI;
using PlayFab.ClientModels;
using Oculus.Platform;
using Mono.Cecil.Cil;
using Photon.Voice;
using Oculus.Platform.Models;
using Mono.Math;
using Valve.VR;
using static UnityEngine.Rendering.VolumeComponent;
using POpusCodec.Enums;
using System.Runtime.Remoting.Messaging;
using Unity.Mathematics;
using System.Runtime.InteropServices.ComTypes;
using GorillaGameModes;
using System.Net;
using Pathfinding.Ionic.Zip;
using UnityEngine.SceneManagement;
using System.Timers;
using Fusion.Photon.Realtime;
using Fusion;

namespace Displyy_Template.Backend
{
    internal class Mods : MonoBehaviour
    {
        public static bool oiwefkwenfjk;
        public static bool weuhfewh;
        public static bool spin;
        public static bool roll;
        public static bool back;
        public static bool upside;

        public static void HeadSpin()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 15f;
            spin = true;
        }

        public static void nuhuhheadspin()
        {
            if (spin)
            {
                spin = false;
                RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;
            }
        }

        public static void HeadRoll()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.x += 15f;
            roll = true;
        }

        public static void nuhuhheadroll()
        {
            if (roll)
            {
                roll = false;
                RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0.0f;
            }
        }

        public static void HeadBack()
        {
            if (!back)
            {
                GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y = 180;
                back = true;
            }
        }

        public static void nuhuhheadback()
        {
            if (back)
            {
                back = false;
                RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;
            }
        }

        public static void HeadUpside()
        {
            if (!upside)
            {
                RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 180;
                upside = true;
            }
        }

        public static void nuhuhheadupside()
        {
            if (upside)
            {
                upside = false;
                RigShit.GetOwnVRRig().head.trackingRotationOffset.x = 0.0f;
            }
        }

        public static bool inSettings = false;

        public static bool inPlayers = false;

        public static void Settings()
        {
            GetButton("Settings").enabled = false;
            GetButtonSettings("Settings").enabled = false;
            inSettings = !inSettings;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void OPMods()
        {
            GetButton("OP Mods").enabled = false;
            GetButtonOP("OP Mods").enabled = false;
            inPlayers = !inPlayers;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw(); ;
        }

        public static bool inFavorite = false;

        public static string[] favoriteButtons;

        static bool favBool;

        public static void FavoriteMods()
        {
            if (File.Exists("GoldPrefs\\goldSavedFavorites.txt") && !favBool)
            {
                foreach (string name in System.IO.File.ReadAllLines("GoldPrefs\\goldSavedFavorites.txt"))
                {
                    WristMenu.favoritebuttons.Add(GetButton(name));
                    WristMenu.favoritebuttons.Add(GetButtonOP(name));
                }
                favBool = true;
            }
            GetButton("Favorite Mod").enabled = false;
            WristMenu.favoritebuttons[0].enabled = false;
            inFavorite = !inFavorite;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static float NameDelay;

        public static float SettingNameDelay;

        public static string NameChangerString = null;

        public static void NameChangeAll()
        {
            if (NameChangerString == null)
            {
                if (SettingNameDelay < Time.time)
                {
                    SettingNameDelay = Time.time + 5f;
                    NotifiLib.SendNotification("<color=blue>[NAME CHANGER]</color> Assign the thing to change their names to on the gui!");
                    return;
                }
            }
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban!");
                return;
            }
            if (NameDelay < Time.time)
            {
                NameDelay = Time.time + 0.05f;
                foreach (Player p in PhotonNetwork.PlayerList)
                {
                    Hashtable hashtable = new Hashtable();
                    hashtable[byte.MaxValue] = NameChangerString;
                    Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
                    dictionary.Add(251, hashtable);
                    dictionary.Add(254, p.ActorNumber);
                    dictionary.Add(250, true);
                    PhotonNetwork.CurrentRoom.LoadBalancingClient.LoadBalancingPeer.SendOperation(252, dictionary, SendOptions.SendUnreliable);
                }
            }
        }

        /*public static bool OpSetPropertiesOfActor(int actorNr, Hashtable actorProperties, Hashtable expectedProperties = null, WebFlags webFlags = null)
        {
            bool flag = OpSetPropertiesOfActor2(actorNr, actorProperties, expectedProperties, webFlags);
            Player player = PhotonNetwork.CurrentRoom.GetPlayer(actorNr, false);
            if (player != null)
            {
                player.InternalCacheProperties(actorProperties);
                this.InRoomCallbackTargets.OnPlayerPropertiesUpdate(player, actorProperties);
            }
            return flag;
        }

        public static bool OpSetPropertiesOfActor2(int actorNr, Hashtable actorProperties, Hashtable expectedProperties = null, WebFlags webflags = null)
        {
            Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
            dictionary.Add(251, actorProperties);
            dictionary.Add(254, actorNr);
            dictionary.Add(250, true);
            if (expectedProperties != null && expectedProperties.Count != 0)
            {
                dictionary.Add(231, expectedProperties);
            }
            if (webflags != null && webflags.HttpForward)
            {
                dictionary[234] = webflags.WebhookFlags;
            }
            var peer = new PhotonPeer(ConnectionProtocol.WebSocket);
            return peer.SendOperation(252, dictionary, SendOptions.SendReliable);
        }*/

        public static void backtomain()
        {
            inPlayers = false;
            OPMods();
        }

        public static void selectplayer(string id)
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                if (p.UserId == id)
                {
                    WristMenu.opbuttons.Clear();
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = "Players", method = () => Mods.backtomain(), enabled = false, toolTip = "Go back!" });
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = p.NickName, method = () => Mods.backtomain(), enabled = false, toolTip = "Go back!" });
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = p.UserId, method = () => Mods.backtomain(), enabled = false, toolTip = "Go back!" });
                    object s;
                    bool modder;
                    if (p.CustomProperties.TryGetValue("mods", out s) && s is string)
                    {
                        modder = true;
                    }
                    else
                    {
                        modder = false;
                    }
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = "Is Modder: " + modder, method = () => Mods.backtomain(), enabled = false, toolTip = "Go back!" });
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = "Teleport To " + p.NickName, method = () => Mods.teleport(id), enabled = false, toolTip = "Teleport to this player!" });
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = "Tag " + p.NickName, method = () => Mods.tag(id), enabled = false, toolTip = "Tag this player!" });
                    WristMenu.opbuttons.Add(new ButtonInfo { buttonText = "Crash " + p.NickName, method = () => Mods.crash(id), disableMethod = () => Mods.crwdhyg(), enabled = false, toolTip = "Crash this player!" });
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static void tag(string id)
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                if (p.UserId == id)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = GorillaGameManager.instance.FindPlayerVRRig(beesPlayer).transform.position - new Vector3(0, 6, 0);
                    PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
                    {
                        p
                    });
                    PhotonView.Get(GorillaGameManager.instance.GetComponent<GorillaGameManager>()).RPC("ReportTagRPC", RpcTarget.MasterClient, new object[]
                    {
                        p
                    });
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    WristMenu.opbuttons[5].enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static bool ns;

        public static void crash(string id)
        {
            ns = true;
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                if (p.UserId == id)
                {
                    if (crashtp)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-92.2935f, 45.3772f, -20.7123f);
                    }
                    Mods.KickDeps(beesPlayer);
                    Mods.KickDeps(beesPlayer);
                    PhotonNetwork.SendAllOutgoingCommands();
                }
            }
        }

        public static void crwdhyg()
        {
            if (ns)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                ns = false;
            }
        }

        public static void HoldRig()
        {
            if (WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.leftHandFollower.position;
            }
            if (WristMenu.gripDownR)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.rightHandFollower.position;
            }
            if (!WristMenu.gripDownR && !WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void RigGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position;
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static void TeleportGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    GorillaLocomotion.Player.Instance.transform.position = pointer.transform.position;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static void TeleportRandom()
        {
            MeshCollider[] meshColliders = Resources.FindObjectsOfTypeAll<MeshCollider>();
            foreach (MeshCollider coll in meshColliders)
            {
                coll.enabled = false;
            }
            VRRig random = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
            GorillaLocomotion.Player.Instance.transform.position = random.transform.position;
            foreach (MeshCollider coll in meshColliders)
            {
                coll.enabled = true;
            }
        }

        public static void teleport(string id)
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                if (p.UserId == id)
                {
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    GorillaLocomotion.Player.Instance.transform.position = RigShit.GetRigFromPlayer(beesPlayer).transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.position = RigShit.GetRigFromPlayer(beesPlayer).transform.position;
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    WristMenu.opbuttons[4].enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static bool invisplat = false;

        public static void IronMonke()
        {
            if (WristMenu.gripDownR)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.x, 15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.y, 15f * GorillaLocomotion.Player.Instance.rightControllerTransform.right.z), ForceMode.Acceleration);
            }
            if (WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(115, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 10f, GorillaTagger.Instance.tapHapticDuration);
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.x * -1f, 15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.y * -1f, 15f * GorillaLocomotion.Player.Instance.leftControllerTransform.right.z * -1f), ForceMode.Acceleration);
            }
        }
        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }

        public static void PrimaryLeave()
        {
            if (WristMenu.xbuttonDown)
            {
                PhotonNetwork.Disconnect();
            }
        }
        static float delyatimer;

        public static void Spamlucy()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Gong;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
        }

        public static void spazlucy()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").transform.rotation = UnityEngine.Random.rotation;
        }

        public static AssetBundle assetBundle = null;

        public static Font gtagfont = Resources.GetBuiltinResource<Font>("Arial.ttf");

        public static void limitfps()
        {
            foreach (GameObject obj in UnityEngine.Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
            {

            }
        }

        public static void juggle()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.5f;
                GameObject g = GameObject.Find("Player Objects/GorillaParent/Local Gorilla Player(Clone)/Holdables");
                foreach (TransferrableObject t in Resources.FindObjectsOfTypeAll<TransferrableObject>())
                {
                    if (t.IsMyItem())
                    {
                        if (t.currentState == TransferrableObject.PositionState.InLeftHand)
                        {
                            t.currentState = TransferrableObject.PositionState.OnChest;
                        }
                        if (t.currentState == TransferrableObject.PositionState.OnLeftArm)
                        {
                            t.currentState = TransferrableObject.PositionState.InLeftHand;
                        }
                        if (t.currentState == TransferrableObject.PositionState.OnLeftShoulder)
                        {
                            t.currentState = TransferrableObject.PositionState.OnLeftArm;
                        }
                        if (t.currentState == TransferrableObject.PositionState.OnRightShoulder)
                        {
                            t.currentState = TransferrableObject.PositionState.OnLeftShoulder;
                        }
                        if (t.currentState == TransferrableObject.PositionState.OnRightArm)
                        {
                            t.currentState = TransferrableObject.PositionState.OnRightShoulder;
                        }
                        if (t.currentState == TransferrableObject.PositionState.InRightHand)
                        {
                            t.currentState = TransferrableObject.PositionState.OnRightArm;
                        }
                        if (t.currentState == TransferrableObject.PositionState.OnChest)
                        {
                            t.currentState = TransferrableObject.PositionState.InRightHand;
                        }
                    }
                }
            }
        }

        public enum Effects
        {
            TaggedTime,
            JoinedTaggedTime,
            SetSlowedTime
        }

        public static void vg()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (WristMenu.gripDownR)
                {
                    if (!MenusGUI.emulators)
                    {
                        if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                        {
                            pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        }
                    }
                    Photon.Realtime.Player owner;
                    if (WristMenu.triggerDownR)
                    {
                        if (gunLock)
                        {
                            if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                            {
                                lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                            }
                            if (lockedrig != null)
                            {
                                pointer.transform.position = lockedrig.transform.position;
                            }
                            else
                            {
                                pointer.transform.position = raycastHit.point;
                            }
                            owner = RigShit.GetPlayerFromRig(lockedrig);
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                    }
                    if (WristMenu.triggerDownR)
                    {
                        if (lockedrig != null)
                        {
                            owner = RigShit.GetPlayerFromRig(lockedrig);
                        }
                        else
                        {
                            owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                        }
                        if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                        {
                            if (Time.time > balll2111 + 1f && PhotonNetwork.InRoom)
                            {
                                balll2111 = Time.time;
                                statuseffect(Mods.Effects.JoinedTaggedTime, owner);
                            }
                        }
                    }
                    else
                    {
                        lockedrig = null;
                    }
                }
                else
                {
                    GameObject.Destroy(pointer);
                }
            }
        }


        public static void sg()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (WristMenu.gripDownR)
                {
                    if (!MenusGUI.emulators)
                    {
                        if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                        {
                            pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                            UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                            pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        }
                    }
                    Photon.Realtime.Player owner;
                    if (WristMenu.triggerDownR)
                    {
                        if (gunLock)
                        {
                            if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                            {
                                lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                            }
                            if (lockedrig != null)
                            {
                                pointer.transform.position = lockedrig.transform.position;
                            }
                            else
                            {
                                pointer.transform.position = raycastHit.point;
                            }
                            owner = RigShit.GetPlayerFromRig(lockedrig);
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                    }
                    if (WristMenu.triggerDownR)
                    {
                        if (lockedrig != null)
                        {
                            owner = RigShit.GetPlayerFromRig(lockedrig);
                        }
                        else
                        {
                            owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                        }
                        if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                        {
                            if (Time.time > balll2111 + 1f && PhotonNetwork.InRoom)
                            {
                                balll2111 = Time.time;
                                statuseffect(Mods.Effects.TaggedTime, owner);
                            }
                        }
                    }
                    else
                    {
                        lockedrig = null;
                    }
                }
                else
                {
                    GameObject.Destroy(pointer);
                }
            }
        }

        private static readonly RaiseEventOptions reoTarget = new RaiseEventOptions
        {
            TargetActors = new int[1]
        };

        public static void statuseffect(Mods.Effects status, Player target)
        {
            statusSendData[0] = status;
            byte b = 2;
            object obj = statusSendData;
            SendProjEvent(b, obj, target, soUnreliable);
        }

        public static void statuseffect(Mods.Effects status, RpcTarget target)
        {
            statusSendData[0] = status;
            byte b = 2;
            object obj = statusSendData;
            SendProjEvent(b, obj, target, soUnreliable);
        }

        internal static void SendProjEvent(in byte code, in object evData, in RpcTarget target, in SendOptions so)
        {
            SendProjEvent(code, evData, reoOthers, so);
        }

        internal static void SendProjEvent(in byte code, in object evData, in Player target, in SendOptions so)
        {
            reoTarget.TargetActors[0] = target.ActorNumber;
            SendProjEvent(code, evData, reoTarget, so);
        }

        private static object[] statusSendData = new object[1];

        public static void va()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (Time.time > balll2111 + 1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    statuseffect(Mods.Effects.JoinedTaggedTime, RpcTarget.Others);
                }
            }
        }

        public static void sa()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (Time.time > balll2111 + 1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    statuseffect(Mods.Effects.TaggedTime, RpcTarget.Others);
                }
            }
        }

        private ScienceExperimentManager.PlayerGameState[] inGamePlayerStatesMAL = new ScienceExperimentManager.PlayerGameState[10];

        public static void Acid1(int pId)
        {
            bool flag = false;
            var instance = ScienceExperimentManager.instance;
            ScienceExperimentManager.PlayerGameState[] inGamePlayerStates = new ScienceExperimentManager.PlayerGameState[10];
            inGamePlayerStates = (ScienceExperimentManager.PlayerGameState[])Traverse.Create(instance).Field("inGamePlayerStates").GetValue();

            int inGamePlayerCount = (int)Traverse.Create(instance).Field("inGamePlayerCount").GetValue();

            for (int i = 0; i < inGamePlayerCount; i++)
            {
                if (inGamePlayerStates[i].playerId == pId)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag && inGamePlayerCount < 10)
            {
                bool touchedLiquid = false;
                inGamePlayerStates[inGamePlayerCount] = new ScienceExperimentManager.PlayerGameState
                {
                    playerId = pId,
                    touchedLiquid = touchedLiquid,
                    touchedLiquidAtProgress = -1f
                };
                inGamePlayerCount++;
            }

            Traverse.Create(instance).Field("inGamePlayerStates").SetValue(inGamePlayerStates);
        }

        public static void Acid2(int playerId)
        {
            Debug.Log("starting 2");
            var instance = ScienceExperimentManager.instance;
            int inGamePlayerCount = PhotonNetwork.PlayerList.Length;
            for (int i = 0; i < inGamePlayerCount - 1; i++)
            {
                Debug.Log("starting for loop");
                ScienceExperimentManager.PlayerGameState[] inGamePlayerStates = new ScienceExperimentManager.PlayerGameState[10];
                inGamePlayerStates = (ScienceExperimentManager.PlayerGameState[])Traverse.Create(instance).Field("inGamePlayerStates").GetValue();
                ScienceExperimentManager.PlayerGameState playerGameState = inGamePlayerStates[i];
                playerGameState.touchedLiquidAtProgress = 1f;
                playerGameState.touchedLiquid = true;
                inGamePlayerStates[i] = playerGameState;
                Debug.Log("set var 2");
                Traverse.Create(instance).Field("inGamePlayerStates").SetValue(inGamePlayerStates);
                if (Traverse.Create(instance).Field("inGamePlayerStates").GetValue() == inGamePlayerStates)
                {
                    Debug.Log("work psl");
                }
                Debug.Log("2");
            }
        }


        public static void acidall()
        {
            var lol = ScienceExperimentManager.instance;
            PhotonView sciencephotonview = ScienceExperimentManager.instance.photonView;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                lol.PlayerTouchedLavaRPC(new PhotonMessageInfo(player, PhotonNetwork.ServerTimestamp, ScienceExperimentManager.instance.photonView));
            }
        }

        public static void acidself()
        {
            ScienceExperimentManager.instance.photonView.RPC("PlayerTouchedLavaRPC", RpcTarget.All, null);
        }

        public static bool anticrashh;

        public static void anticrash()
        {
            anticrashh = true;
        }

        public static void offanticrash()
        {
            anticrashh = false;
        }

        public static void SpawnBlueLucy()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Gong;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
            GetButton("Summon Lucy").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void SpawnLurker()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("cooldownTimeRemaining").SetValue(0f);
            GetButton("Summon Lurker").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void LucyGrabForever()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.InitialRise;
        }


        public static void LurkerGrabForever()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().PossessionDuration = 999;
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().cooldownDuration = 0;
        }


        public static void red()
        {
            if (WristMenu.gripDownR)
            {
                GameObject.Find("RedFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
            }
        }

        public static void yel()
        {
            if (WristMenu.gripDownR)
            {
                GameObject.Find("YellowFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
            }
        }

        public static void gre()
        {
            if (WristMenu.gripDownR)
            {
                GameObject.Find("GreenFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
            }
        }

        public static void pur()
        {
            if (WristMenu.gripDownR)
            {
                GameObject.Find("PurpleFlowerThrowable").transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
            }
        }

        public static bool epic;
        static bool wieufhwf;

        static GameObject rightHand;
        static GameObject leftHand;
        static GorillaPlayerScoreboardLine playersLine;
        public static GameObject pookiebear;
        public static float distance = 2.0f; // Distance from the player
        public static float moveSpeed = 5.0f; // Movement speed of the wall

        public static void pookieproj(Vector3 pookiepos, Vector3 pookievelocit, Color pookiecolor)
        {
            if (PhotonNetwork.InRoom && WristMenu.gripDownR)
            {
                var ohio = HashToName(projectilehash);
                int hash = 1;
                if (cycle)
                {
                    fuckyoucsharp++;
                    if (fuckyoucsharp == 0)
                    {
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                    if (fuckyoucsharp == 1)
                    {
                        hash = projectilehashc2;
                        ohio = HashToName(projectilehashc2);
                    }
                    if (fuckyoucsharp == 2)
                    {
                        hash = projectilehashc3;
                        ohio = HashToName(projectilehashc3);
                    }
                    if (fuckyoucsharp == 3)
                    {
                        hash = projectilehashc4;
                        ohio = HashToName(projectilehashc4);
                    }
                    if (fuckyoucsharp == 4)
                    {
                        fuckyoucsharp = 0;
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                }
                else
                {
                    hash = projectilehash;
                    ohio = HashToName(projectilehash);
                }
                SendProjectile(ohio, pookiepos, pookievelocit, pookiecolor);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void Wall()
        {
            if (WristMenu.gripDownL && WristMenu.gripDownR)
            {
                if (pookiebear == null)
                {
                    pookiebear = new GameObject("wallobj");
                    pookiebear.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                }
                else
                {
                    if (Time.time > balll2111 + 0.1f)
                    {
                        balll2111 = Time.time;
                        // Calculate the target position based on the player's position
                        Vector3 targetPosition = GorillaTagger.Instance.offlineVRRig.transform.position + positions[currentPositionIndex];

                        // Move the GameObject towards the target position
                        pookiebear.transform.position = Vector3.MoveTowards(pookiebear.transform.position, targetPosition, moveSpeed * Time.deltaTime);

                        // Check if the GameObject has reached the target position
                        if (Vector3.Distance(pookiebear.transform.position, targetPosition) < 0.01f)
                        {
                            // Move to the next position in the pattern
                            currentPositionIndex = (currentPositionIndex + 1) % positions.Length;
                        }

                        pookieproj(pookiebear.transform.position, Vector3.zero, projcolor);
                    }
                }
            }
            else
            {
                if (pookiebear != null)
                {
                    pookiebear = null;
                    Destroy(GameObject.Find("wallobj"));
                }
            }
        }

        public static Vector3[] positions = new Vector3[]
        {
            new Vector3(distance, 0, distance),
            new Vector3(0, 0, distance),
            new Vector3(-distance, 0, distance),
            new Vector3(distance, 0, 0),
            new Vector3(0, 0, 0), // Center
            new Vector3(-distance, 0, 0),
            new Vector3(distance, 0, -distance),
            new Vector3(0, 0, -distance),
            new Vector3(-distance, 0, -distance)
        };
        public static int currentPositionIndex = 0;

        public static void offantireportv2()
        {
            if (wieufhwf)
            {
                string nickName = savedName;
                PhotonNetwork.LocalPlayer.NickName = nickName;
                PhotonNetwork.NickName = nickName;
                PhotonNetwork.NetworkingClient.NickName = nickName;
                wieufhwf = false;
            }
        }

        public static void AntiReportV2()
        {
            string nickName = savedName + "------------------------------------------------------------------------------------------";
            PhotonNetwork.LocalPlayer.NickName = nickName;
            PhotonNetwork.NickName = nickName;
            PhotonNetwork.NetworkingClient.NickName = nickName;
            wieufhwf = true;

        }

        public static void iuehkfsjd()
        {
            wieufhwf = false;
        }

        public static void ballsontouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    Vector3 adjustedLocalHandPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    float distance = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").position);
                    float distance2 = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").position);

                    if (distance < 0.5f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        testingballs2(rig);
                    }
                    if (distance2 < 0.5f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        testingballs2(rig);
                    }
                }
            }
        }

        public static void CrashOnTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    Vector3 adjustedLocalHandPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    float distance = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").position);
                    float distance2 = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                        Debug.unityLogger.logEnabled = false;
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void Crash2OnTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    Vector3 adjustedLocalHandPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    float distance = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").position);
                    float distance2 = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (Time.time > CrashFloat2 + 0.12f)
                        {
                            CrashFloat2 = Time.time;
                            for (int i = 0; i < 20; i++)
                            {
                                PhotonNetwork.SendRate = 1;
                                CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                                Debug.unityLogger.logEnabled = false;
                            }
                        }
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (Time.time > CrashFloat2 + 0.12f)
                        {
                            CrashFloat2 = Time.time;
                            for (int i = 0; i < 20; i++)
                            {
                                PhotonNetwork.SendRate = 1;
                                CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                                Debug.unityLogger.logEnabled = false;
                            }
                        }
                    }
                }
            }
        }

        static float crashstuff4;

        public static void EpicOnTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    Vector3 adjustedLocalHandPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                    float distance = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").position);
                    float distance2 = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (crashstuff4 < Time.time)
                        {
                            crashstuff4 = Time.time + 0.1f;
                            for (int i = 0; i < 50; i++)
                            {
                                object[] array = new object[] { 1f, 1f, 1f };
                                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RigShit.GetPlayerFromRig(rig), array);
                            }
                        }
                        Debug.unityLogger.logEnabled = false;
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (crashstuff4 < Time.time)
                        {
                            crashstuff4 = Time.time + 0.1f;
                            for (int i = 0; i < 50; i++)
                            {
                                object[] array = new object[] { 1f, 1f, 1f };
                                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RigShit.GetPlayerFromRig(rig), array);
                            }
                        }
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void CrashOnYouTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    var myrig = GorillaTagger.Instance.offlineVRRig;
                    var distance = Vector3.Distance(myrig.rightHandTransform.position, rig.transform.position);
                    var distance2 = Vector3.Distance(myrig.leftHandTransform.position, rig.transform.position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                        Debug.unityLogger.logEnabled = false;
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void Crash2OnYouTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    var myrig = GorillaTagger.Instance.offlineVRRig;
                    var distance = Vector3.Distance(myrig.rightHandTransform.position, rig.transform.position);
                    var distance2 = Vector3.Distance(myrig.leftHandTransform.position, rig.transform.position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (Time.time > CrashFloat2 + 0.12f)
                        {
                            CrashFloat2 = Time.time;
                            for (int i = 0; i < 20; i++)
                            {
                                PhotonNetwork.SendRate = 1;
                                CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                                Debug.unityLogger.logEnabled = false;
                            }
                        }
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (Time.time > CrashFloat2 + 0.12f)
                        {
                            CrashFloat2 = Time.time;
                            for (int i = 0; i < 20; i++)
                            {
                                PhotonNetwork.SendRate = 1;
                                CallRaiseEventMethod(RigShit.GetPlayerFromRig(rig));
                                Debug.unityLogger.logEnabled = false;
                            }
                        }
                    }
                }
            }
        }

        static float crashstuff5;

        public static void EpicOnYouTouch()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    var myrig = GorillaTagger.Instance.offlineVRRig;
                    var distance = Vector3.Distance(myrig.rightHandTransform.position, rig.transform.position);
                    var distance2 = Vector3.Distance(myrig.leftHandTransform.position, rig.transform.position);

                    if (distance < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (crashstuff5 < Time.time)
                        {
                            crashstuff5 = Time.time + 0.1f;
                            for (int i = 0; i < 50; i++)
                            {
                                object[] array = new object[] { 1f, 1f, 1f };
                                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RigShit.GetPlayerFromRig(rig), array);
                            }
                        }
                        Debug.unityLogger.logEnabled = false;
                    }
                    if (distance2 < 0.3f)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        if (crashstuff5 < Time.time)
                        {
                            crashstuff5 = Time.time + 0.1f;
                            for (int i = 0; i < 50; i++)
                            {
                                object[] array = new object[] { 1f, 1f, 1f };
                                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RigShit.GetPlayerFromRig(rig), array);
                            }
                        }
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void bubbletouch()
        {
            if (Time.time > balll2 + 0.5f)
            {
                balll2 = Time.time;
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isOfflineVRRig)
                    {
                        Vector3 adjustedLocalHandPosition = GorillaTagger.Instance.offlineVRRig.transform.position;
                        float distance = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R").position);
                        float distance2 = Vector3.Distance(adjustedLocalHandPosition, rig.gameObject.transform.Find("rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").position);

                        if (distance < 0.5f)
                        {
                            if (!PhotonNetwork.IsMasterClient)
                            {
                                NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master first!");
                                return;
                            }
                            var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                            generator.photonView.RPC("SpawnSodaBubbleRPC", RigShit.GetPlayerFromRig(rig), new object[]
                            {
                            new Vector2(0, 0),
                            9999999999999999999999999999999999f,
                            9999999f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                            });
                            flushmanually();
                        }
                        if (distance2 < 0.5f)
                        {
                            if (!PhotonNetwork.IsMasterClient)
                            {
                                NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master first!");
                                return;
                            }
                            var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                            generator.photonView.RPC("SpawnSodaBubbleRPC", RigShit.GetPlayerFromRig(rig), new object[]
                            {
                            new Vector2(0, 0),
                            9999999999999999999999999999999999f,
                            9999999f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                            });
                            flushmanually();
                        }
                    }
                }
            }
        }

        static GameObject theline;

        public static void DebugAllButtons()
        {
            Debug.LogError("SETTINGS");
            foreach (ButtonInfo info in WristMenu.settingsbuttons)
            {
                Debug.Log(info.buttonText);
            }
            Debug.LogError("NORMAL");
            foreach (ButtonInfo info in WristMenu.buttons)
            {
                Debug.Log(info.buttonText);
            }
        }

        public static GorillaScoreBoard[] boards = null;

        public static void AntiReport()
        {
            try
            {
                if (boards == null)
                {
                    boards = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                }
                foreach (GorillaScoreBoard board in boards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                        {
                            Transform report = line.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float D1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                    float D2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                                    float threshold = 0.35f;

                                    if (D1 < threshold || D2 < threshold)
                                    {
                                        if (AntireportInt == 0)
                                        {
                                            PhotonNetwork.Disconnect();
                                            NotifiLib.SendNotification("<color=red>[AntiReport] </color> The Player " + vrrig.playerText.text + " almost reported you, but dont worry ShibaGT Gold's antireport made u leave before they could report u!");
                                        }
                                        if (AntireportInt == 1)
                                        {
                                            GetButton("Serverho").enabled = true;
                                            NotifiLib.SendNotification("<color=red>[AntiReport] </color> The Player " + vrrig.playerText.text + " almost reported you, but dont worry ShibaGT Gold's antireport made u serverhop before they could report u!");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { } // Not connected
        }

        static bool FakeOculusBool;

        public static void FakeOculus()
        {
            if (WristMenu.bbuttonDown)
            {
                FakeOculusBool = true;
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller").SetActive(false);
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller").SetActive(false);
            }
            else
            {
                if (FakeOculusBool)
                {
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller").SetActive(true);
                    GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller").SetActive(true);
                    FakeOculusBool = false;
                }
            }
        }

        public static void GiveHoneyComb()
        {
            if (WristMenu.gripDownL)
            {
                GorillaGameManager.instance.FindVRRigForPlayer(PhotonNetwork.LocalPlayer).RPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    true,
                    true
                });
                NewFlusher();
            }
            if (WristMenu.gripDownR)
            {
                GorillaGameManager.instance.FindVRRigForPlayer(PhotonNetwork.LocalPlayer).RPC("EnableNonCosmeticHandItemRPC", RpcTarget.All, new object[]
                {
                    true,
                    false
                });
                NewFlusher();
            }
        }

        public static Vector3 rightgrapplePoint;
        public static Vector3 leftgrapplePoint;
        public static SpringJoint rightjoint;
        public static SpringJoint leftjoint;
        public static bool isLeftGrappling = false;
        public static bool isRightGrappling = false;

        public static void DisableSpiderMonke()
        {
            if (SpiderMonkeBool)
            {
                isLeftGrappling = false;
                UnityEngine.Object.Destroy(leftjoint);
                isRightGrappling = false;
                UnityEngine.Object.Destroy(rightjoint);
                SpiderMonkeBool = false;
            }
        }


        public static void SpiderMonke()
        {
            if (WristMenu.gripDownL)
            {
                if (!isLeftGrappling)
                {
                    isLeftGrappling = true;
                    RaycastHit lefthit;
                    if (Physics.Raycast(GorillaTagger.Instance.leftHandTransform.position, GorillaTagger.Instance.leftHandTransform.forward, out lefthit, 100f))
                    {
                        leftgrapplePoint = lefthit.point;

                        leftjoint = GorillaTagger.Instance.gameObject.AddComponent<SpringJoint>();
                        leftjoint.autoConfigureConnectedAnchor = false;
                        leftjoint.connectedAnchor = leftgrapplePoint;

                        float leftdistanceFromPoint = Vector3.Distance(GorillaTagger.Instance.bodyCollider.attachedRigidbody.position, leftgrapplePoint);

                        leftjoint.maxDistance = leftdistanceFromPoint * 0.8f;
                        leftjoint.minDistance = leftdistanceFromPoint * 0.25f;

                        leftjoint.spring = 10f;
                        leftjoint.damper = 50f;
                        leftjoint.massScale = 12f;
                    }
                }

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.white;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.leftHandTransform.position);
                liner.SetPosition(1, leftgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                isLeftGrappling = false;
                UnityEngine.Object.Destroy(leftjoint);
            }

            if (WristMenu.gripDownR)
            {
                if (!isRightGrappling)
                {
                    isRightGrappling = true;
                    RaycastHit righthit;
                    if (Physics.Raycast(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.rightHandTransform.forward, out righthit, 100f))
                    {
                        rightgrapplePoint = righthit.point;

                        rightjoint = GorillaTagger.Instance.gameObject.AddComponent<SpringJoint>();
                        rightjoint.autoConfigureConnectedAnchor = false;
                        rightjoint.connectedAnchor = rightgrapplePoint;

                        float rightdistanceFromPoint = Vector3.Distance(GorillaTagger.Instance.bodyCollider.attachedRigidbody.position, rightgrapplePoint);

                        rightjoint.maxDistance = rightdistanceFromPoint * 0.8f;
                        rightjoint.minDistance = rightdistanceFromPoint * 0.25f;

                        rightjoint.spring = 10f;
                        rightjoint.damper = 50f;
                        rightjoint.massScale = 12f;
                    }
                }

                GameObject line = new GameObject("Line");
                LineRenderer liner = line.AddComponent<LineRenderer>();
                UnityEngine.Color thecolor = Color.white;
                liner.startColor = thecolor; liner.endColor = thecolor; liner.startWidth = 0.025f; liner.endWidth = 0.025f; liner.positionCount = 2; liner.useWorldSpace = true;
                liner.SetPosition(0, GorillaTagger.Instance.rightHandTransform.position);
                liner.SetPosition(1, rightgrapplePoint);
                liner.material.shader = Shader.Find("GorillaTag/UberShader");
                UnityEngine.Object.Destroy(line, Time.deltaTime);
            }
            else
            {
                isRightGrappling = false;
                UnityEngine.Object.Destroy(rightjoint);
            }
            SpiderMonkeBool = true;
        }

        static bool SpiderMonkeBool;
        
        public static bool RGB;

        public static void RGBMenu()
        {
            RGB = true;
        }

        public static void OffRGBMenu()
        {
            RGB = false;
        }

        public static void OffFakeOculus()
        {
            if (FakeOculusBool)
            {
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller").SetActive(true);
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/RightHand Controller").SetActive(true);
                FakeOculusBool = false;
            }
        }

        public static void CrashOnReport()
        {
            try
            {
                if (boards == null)
                {
                    boards = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                }
                foreach (GorillaScoreBoard board in boards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (RigShit.NetPlayerToPlayer(line.linePlayer) == PhotonNetwork.LocalPlayer)
                        {
                            Transform report = line.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float D1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                    float D2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                                    float threshold = 0.35f;

                                    if (D1 < threshold || D2 < threshold)
                                    {
                                        Debug.unityLogger.logEnabled = false;
                                        CallRaiseEventMethod(RigShit.NetPlayerToPlayer(line.linePlayer));
                                        NotifiLib.SendNotification("<color=red>[Crash] </color> The Player " + vrrig.playerText.text + " Got crashed due to them reporting you :D");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { } // Not connected
        }

        public static void InvisOnReport()
        {
            try
            {
                if (boards == null)
                {
                    boards = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                }
                foreach (GorillaScoreBoard board in boards)
                {
                    foreach (GorillaPlayerScoreboardLine line in board.lines)
                    {
                        if (RigShit.NetPlayerToPlayer(line.linePlayer) == PhotonNetwork.LocalPlayer)
                        {
                            Transform report = line.reportButton.gameObject.transform;
                            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                            {
                                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                                {
                                    float D1 = Vector3.Distance(vrrig.rightHandTransform.position, report.position);
                                    float D2 = Vector3.Distance(vrrig.leftHandTransform.position, report.position);

                                    float threshold = 0.35f;

                                    if (D1 < threshold || D2 < threshold)
                                    {
                                        testingballs2(RigShit.GetRigFromPlayer(RigShit.NetPlayerToPlayer(line.linePlayer)));
                                        NotifiLib.SendNotification("<color=red>[Crash] </color> The Player " + vrrig.playerText.text + " Got crashed due to them reporting you :D");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { } // Not connected
        }

        public static void ballsall()
        {
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                return;
            }
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
            {
                foreach (Player p in PhotonNetwork.PlayerListOthers)
                {
                    testingballs();
                    //Hashtable hashtable = new Hashtable();
                    //hashtable[(byte)0] = p.ActorNumber;
                    //PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendReliable);
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
            }
        }

        public static void addFavButton(ButtonInfo info)
        {
            if (info != null && !WristMenu.favoritebuttons.Contains(info))
            {
                WristMenu.favoritebuttons.Add(info);
                saveFavs(info);
                NotifiLib.SendNotification("<color=yellow>[FAV MODS]</color> Added " + info.buttonText + " To Favorite Mods");

            }
        }

        public static void LavaSpaz()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("BECOME MASTER!");
                return;
            }
            if (balll < Time.time)
            {
                balll = Time.time + 0.1f;
                int rInt = Random.Range(1, 3);
                if (rInt == 1)
                    ForceRiseLava();
                if (rInt == 2)
                    ForceDrainLava();
            }
        }

        public static void ForceRiseLava()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("BECOME MASTER!");
                return;
            }
            InfectionLavaController controller = InfectionLavaController.Instance;
            System.Type type = controller.GetType();

            FieldInfo fieldInfo = type.GetField("reliableState", BindingFlags.NonPublic | BindingFlags.Instance);

            object reliableState = fieldInfo.GetValue(controller);

            FieldInfo stateFieldInfo = reliableState.GetType().GetField("state");
            stateFieldInfo.SetValue(reliableState, InfectionLavaController.RisingLavaState.Full);

            FieldInfo stateFieldInfo2 = reliableState.GetType().GetField("stateStartTime");
            stateFieldInfo2.SetValue(reliableState, PhotonNetwork.Time);

            fieldInfo.SetValue(controller, reliableState);
        }

        public static void ForceDrainLava()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("BECOME MASTER!");
                return;
            }
            InfectionLavaController controller = InfectionLavaController.Instance;
            System.Type type = controller.GetType();

            FieldInfo fieldInfo = type.GetField("reliableState", BindingFlags.NonPublic | BindingFlags.Instance);

            object reliableState = fieldInfo.GetValue(controller);

            FieldInfo stateFieldInfo = reliableState.GetType().GetField("state");
            stateFieldInfo.SetValue(reliableState, InfectionLavaController.RisingLavaState.Drained);

            FieldInfo stateFieldInfo2 = reliableState.GetType().GetField("stateStartTime");
            stateFieldInfo2.SetValue(reliableState, PhotonNetwork.Time);

            fieldInfo.SetValue(controller, reliableState);
        }

        public static void ForceErupt()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("BECOME MASTER!");
                return;
            }
            InfectionLavaController controller = InfectionLavaController.Instance;
            System.Type type = controller.GetType();

            FieldInfo fieldInfo = type.GetField("reliableState", BindingFlags.NonPublic | BindingFlags.Instance);

            object reliableState = fieldInfo.GetValue(controller);

            FieldInfo stateFieldInfo = reliableState.GetType().GetField("state");
            stateFieldInfo.SetValue(reliableState, InfectionLavaController.RisingLavaState.Erupting);

            FieldInfo stateFieldInfo2 = reliableState.GetType().GetField("stateStartTime");
            stateFieldInfo2.SetValue(reliableState, (PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)));

            fieldInfo.SetValue(controller, reliableState);
        }

        static List<string> names = new List<string>();

        public static void saveFavs(ButtonInfo infoo)
        {
            names.Clear();
            if (System.IO.File.Exists("GoldPrefs\\goldSavedFavorites.txt"))
            {
                foreach (string s in System.IO.File.ReadAllLines("GoldPrefs\\goldSavedFavorites.txt"))
                {
                    names.Add(s);
                }
            }
            names.Add(infoo.buttonText);
            System.IO.Directory.CreateDirectory("GoldPrefs");
            System.IO.File.WriteAllLines("GoldPrefs\\goldSavedFavorites.txt", names);
        }

        public static object obj;

        public static void ChangeMatAfterGhost()
        {
            string gamemode = "INFECTION";
            var infgamemode = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
            var huntgamemode = GameObject.Find("GT Systems/GameModeSystem/Gorilla Hunt Manager").GetComponent<GorillaHuntManager>();
            PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("gameMode", out obj);
            if (obj.ToString().Contains("INFECTION"))
            {
                gamemode = "INFECTION";
            }
            if (obj.ToString().Contains("HUNT"))
            {
                gamemode = "HUNT";
            }
            if (obj.ToString().Contains("CASUAL"))
            {
                gamemode = "CASUAL";
            }
            if (gamemode == "INFECTION")
            {
                if (infgamemode.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(2);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
                }
            }
            if (gamemode == "HUNT")
            {
                if (huntgamemode.currentHunted.Contains(PhotonNetwork.LocalPlayer))
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(3);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
                }
            }
            if (gamemode == "CASUAL")
            {
                GorillaTagger.Instance.offlineVRRig.ChangeMaterialLocal(0);
            }
        }

        public static void testingballs()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.01f;
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isOfflineVRRig)
                    {
                        WristMenu.rig2view(rig).TransferOwnership(PhotonNetwork.LocalPlayer);
                        WristMenu.rig2view(rig).ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        WristMenu.rig2view(rig).OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        PhotonNetwork.Destroy(WristMenu.rig2view(rig));
                    }
                }
            }
        }

        public static void testingballs3(VRRig rig)
        {
            WristMenu.rig2view(rig).TransferOwnership(PhotonNetwork.LocalPlayer);
            WristMenu.rig2view(rig).ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            WristMenu.rig2view(rig).OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            PhotonNetwork.Destroy(WristMenu.rig2view(rig));
        }

        public static void BeeGrabPlayer(Player p)
        {
            Debug.Log("grab");
            PhotonStream photonStream = new PhotonStream(true, null);
            PhotonMessageInfo photonMessageInfo = new PhotonMessageInfo(PhotonNetwork.LocalPlayer, PhotonNetwork.ServerTimestamp, GorillaTagger.Instance.myVRRig);
            AngryBeeSwarm.instance.photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
            AngryBeeSwarm.instance.targetPlayer = p;
            AngryBeeSwarm.instance.currentState = AngryBeeSwarm.ChaseState.Grabbing;
            Traverse.Create(AngryBeeSwarm.instance).Field("currentSpeed").SetValue(5f);
            AngryBeeSwarm.instance.photonView.SerializeView(photonStream, photonMessageInfo);
        }

        public static void BeeUnGrabPlayer()
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA UNGRAB");
            PhotonStream photonStream = new PhotonStream(true, null);
            PhotonMessageInfo photonMessageInfo = new PhotonMessageInfo(PhotonNetwork.LocalPlayer, PhotonNetwork.ServerTimestamp, GorillaTagger.Instance.myVRRig);
            AngryBeeSwarm.instance.photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
            AngryBeeSwarm.instance.targetPlayer = null;
            AngryBeeSwarm.instance.currentState = AngryBeeSwarm.ChaseState.Grabbing;
            AngryBeeSwarm.instance.photonView.SerializeView(photonStream, photonMessageInfo);
        }

        public static void SpawnBees()
        {
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=red>[HOVER]</color> Turn on antiban and use set master!");
                return;
            }
            PhotonStream photonStream = new PhotonStream(true, null);
            PhotonMessageInfo photonMessageInfo = new PhotonMessageInfo(PhotonNetwork.LocalPlayer, PhotonNetwork.ServerTimestamp, GorillaTagger.Instance.myVRRig);
            AngryBeeSwarm.instance.photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
            AngryBeeSwarm.instance.currentState = AngryBeeSwarm.ChaseState.Dormant;
            AngryBeeSwarm.instance.photonView.SerializeView(photonStream, photonMessageInfo);
        }

        public static void testingballs2(VRRig rig)
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.01f;
                    WristMenu.rig2view(rig).TransferOwnership(PhotonNetwork.LocalPlayer);
                    WristMenu.rig2view(rig).ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    WristMenu.rig2view(rig).OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    PhotonNetwork.Destroy(WristMenu.rig2view(rig));
            }
        }

        public static void OFFAntiReport()
        {
            if (epic)
            {
                epic = false;
            }
        }

        static bool weijkfssweoifjeofjf1;

        static bool weijkfssweoifjeofjf;


        public static string roomCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
        private static string RandomRoomName()
        {
            string text = "";
            for (int i = 0; i < 7; i++)
            {
                text += roomCharacters.Substring(UnityEngine.Random.Range(0, roomCharacters.Length), 1);
            }
            if (GorillaComputer.instance.CheckAutoBanListForName(text))
            {
                return text;
            }
            return RandomRoomName();
        }

        static string name;

        public static void HideName()
        {
            if (OEIFJWEF == false)
            {
                name = PhotonNetwork.NickName;
                string balls = RandomRoomName();
                PhotonNetwork.LocalPlayer.NickName = balls;
                PhotonNetwork.NickName = balls;
                PhotonNetwork.NetworkingClient.NickName = balls;
                OEIFJWEF = true;
            }
        }

        public static void OFFHideName()
        {
            if (OEIFJWEF)
            {
                PhotonNetwork.LocalPlayer.NickName = name;
                PhotonNetwork.NickName = name;
                PhotonNetwork.NetworkingClient.NickName = name;
                OEIFJWEF = false;
            }
        }

        static bool OEIFJWEF;

        public static void MosaSpeed()
        {
            if (!oiwefkwenfjk)
            {
                foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                {
                    if (speed == 0)
                    {
                        surfascdse.extraVelMaxMultiplier = 1.2f;
                        surfascdse.extraVelMultiplier = 1.1f;
                    }
                    else if (speed == 1)
                    {
                        surfascdse.extraVelMaxMultiplier = 1.5f;
                        surfascdse.extraVelMultiplier = 1.4f;
                    }
                    else if (speed == 2)
                    {
                        surfascdse.extraVelMaxMultiplier = 10f;
                        surfascdse.extraVelMultiplier = 10f;
                    }
                }
                oiwefkwenfjk = true;
            }
        }

        public static void OFFMosaSpeed()
        {
            if (oiwefkwenfjk)
            {
                foreach (GorillaSurfaceOverride surfascdse in Resources.FindObjectsOfTypeAll<GorillaSurfaceOverride>())
                {
                    surfascdse.extraVelMaxMultiplier = 1f;
                    surfascdse.extraVelMultiplier = 1f;
                }
                oiwefkwenfjk = false;
            }
        }

        static public GameObject hand1;
        static public GameObject hand2;
        static public bool ghostToggled;

        public static void Fly()
        {
            if (WristMenu.bbuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * (float)flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static List<string> namelist = new List<string>();

        public static void Disguise()
        {
            Color color;
            color = UnityEngine.Random.ColorHSV();
            namelist.Add("MONKEYMAN");
            namelist.Add("GOOBER");
            namelist.Add("REALONE");
            namelist.Add("LAMPGT");
            namelist.Add("DISGUISEDMAN");
            namelist.Add("GOOFYGOOBER");
            namelist.Add("JIKOMAN");
            namelist.Add("BAGUETTE");
            namelist.Add("POOKIE");
            namelist.Add("HMMM");
            namelist.Add("WHATIS");
            namelist.Add("FORTNITE");
            namelist.Add("MOUSE");
            namelist.Add("SPESZ");
            GorillaTagger.Instance.offlineVRRig.enabled = false;
            GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(-66.7989f, 12.5422f, -82.6815f);
            if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
            {
                string randomname = namelist[UnityEngine.Random.Range(0, 13)];
                PhotonNetwork.NickName = randomname;
                GorillaComputer.instance.savedName = randomname;
                PlayerPrefs.SetString("playerName", randomname);
                PlayerPrefs.Save();
                GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
                Debug.Log("local");
                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.All, new object[]
                {
                    color.r,
                    color.g,
                    color.b,
                    false
                });
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                foreach (ButtonInfo b in WristMenu.buttons)
                {
                    if (b.buttonText.Contains("Disguise"))
                    {
                        b.enabled = false;
                    }
                }
                namelist.Clear();
                WristMenu.DestroyMenu();
                WristMenu.instance.Draw();
            }
        }

        public static void antimoderator()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (!rig.isOfflineVRRig)
                {
                    if (rig.concatStringOfCosmeticsAllowed.Contains("LBAAK"))
                    {
                        PhotonNetwork.Disconnect();
                        NotifiLib.SendNotification("<color=red>[ANTI-MODERATOR]</color> Someone with a STICK joined, disconnected.");
                    }
                }
            }
        }

        public static void FastFly()
        {
            if (WristMenu.bbuttonDown)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * (float)27;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void TriggerFly()
        {
            if (WristMenu.triggerDownL)
            {
                GorillaLocomotion.Player.Instance.transform.position += (GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime) * (float)flySpeed;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void SteamArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
        }

        public static void flushmanually()
        {
            GorillaNot.instance.rpcErrorMax = int.MaxValue;
            GorillaNot.instance.rpcCallLimit = int.MaxValue;
            GorillaNot.instance.logErrorMax = int.MaxValue;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
            PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
            PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
            PhotonNetwork.SendAllOutgoingCommands();
            GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
        }

        public static void SplashGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = pointer.transform.position;
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                        {
                            RigShit.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    flushmanually();
                    RigShit.GetOwnVRRig().enabled = true;
                }
                else
                {
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
            else
            {
                RigShit.GetOwnVRRig().enabled = true;
                GameObject.Destroy(pointer);
            }
        }

        static bool eirsukdjyfj = false;

        public static void StartSkeleEsp()
        {
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig != null && !rig.isOfflineVRRig)
                {
                    rig.gameObject.GetOrAddComponent<SkeletonESPClass>();
                }
            }
            eirsukdjyfj = true;
        }

        public static void EndSkeleEsp()
        {
            if (eirsukdjyfj)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (rig != null && !rig.isOfflineVRRig)
                    {
                        Destroy(rig.gameObject.GetComponent<SkeletonESPClass>());
                    }
                }
            }
            eirsukdjyfj = false;
        }

        public static void TagGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    ChangeMatAfterGhost();
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        {
                            NotifiLib.SendNotification("<color=red>[TAG ALL]</color> You must be tagged!");
                            GetButton("Tag Gun").enabled = false;
                            return;
                        }
                        if (!RigShit.GetRigFromPlayer(owner).mainSkin.material.name.Contains("fected") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
                        {
                            if (balll < Time.time)
                            {
                                balll = Time.time + 0.15f;
                                RigShit.GetOwnVRRig().enabled = false;
                                RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(owner).transform.position - new Vector3(0, 2, 0);
                                GorillaGameModes.GameMode.ReportTag(owner);
                                if (balll2 < Time.time)
                                {
                                    balll2 = Time.time + 0.35f;
                                    RigShit.GetOwnVRRig().enabled = true;
                                }
                                flushmanually();
                            }
                        }
                    }
                }
                else
                {
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
            else
            {
                RigShit.GetOwnVRRig().enabled = true;
                lockedrig = null;
                GameObject.Destroy(pointer);
            }
        }

        public static void LucyGrabAll()
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = p;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = RigShit.GetRigFromPlayer(beesPlayer).head.rigTarget;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 10;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabDuration *= 2;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.InitialRise;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
            }
        }

        public static void LucyGrabAura()
        {
            if (WristMenu.triggerDownL)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (Vector3.Distance(vrrig.transform.position, RigShit.GetOwnVRRig().transform.position) <= 9 && vrrig.playerText.text != PhotonNetwork.LocalPlayer.NickName)
                    {
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = RigShit.GetPlayerFromRig(vrrig);
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = vrrig.head.rigTarget;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 10;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabDuration *= 2;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.InitialRise;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
                    }
                }
            }
        }

        public static void LurkerGrabGun()
        {
            if (WristMenu.gripDownR)
            {
                if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Object.Destroy(pointer.GetComponent<Rigidbody>());
                    Object.Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
                pointer.transform.position = raycastHit.point;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                    }
                    PhotonView view = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>());
                    if (lockedrig != null)
                    {
                        view = RigShit.GetViewFromRig(lockedrig);
                    }
                    Photon.Realtime.Player owner = view.Owner;
                    VRRig rig = RigShit.GetRigFromPlayer(owner);
                    if (view != null || owner != null)
                    {
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().seekCloseEnoughDistance = 9999;
                        Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("cooldownTimeRemaining").SetValue(0f);
                        Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetPlayer").SetValue(owner);
                        Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetTransform").SetValue(rig.transform.position);
                        Traverse.Create(GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>()).Field("targetVRRig").SetValue(rig);
                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static RaycastHit raycastHit;

        public static void LucyGrabGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                PhotonView view = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>());
                Photon.Realtime.Player owner = view.Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                        view = RigShit.GetViewFromRig(lockedrig);
                    }

                    if (lockedrig != null)
                    {
                        view = RigShit.GetViewFromRig(lockedrig);
                    }
                    VRRig rig = RigShit.GetRigFromPlayer(owner);
                    if (view != null || owner != null)
                    {
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer = owner;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().followTarget = rig.head.rigTarget;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabSpeed = 40;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabbedPlayer = owner;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().grabTime *= 5;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.InitialRise;
                        GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.Grabbing;
                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static void LucyPosGun()
        {
            if (WristMenu.gripDownR)
            {
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit);
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentSpeed = 0;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState = HalloweenGhostChaser.ChaseState.InitialRise;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().UpdateState();
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").transform.position = pointer.transform.position;

                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static void LurkerPosGun()
        {
            if (WristMenu.gripDownR)
            {
                if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                    pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                }
                pointer.transform.position = raycastHit.point;
                if (WristMenu.triggerDownR)
                {
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").GetComponent<LurkerGhost>().photonView.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                    GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab").transform.position = pointer.transform.position;
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static void HuntTagGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        if (balll < Time.time)
                        {
                            balll = Time.time + 0.25f;
                            //RigShit.GetOwnVRRig().enabled = false;
                            //RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(beesPlayer).transform.position - new Vector3(0, 2, 0);
                            GorillaGameModes.GameMode.ReportTag(owner);
                            //RigShit.GetOwnVRRig().enabled = true;
                        }
                        flushmanually();
                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static System.Collections.IEnumerator HuntTagAll2()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                //RigShit.GetOwnVRRig().enabled = false;
                //RigShit.GetOwnVRRig().transform.position = GorillaGameManager.instance.FindPlayerVRRig(beesPlayer).transform.position - new Vector3(0, 2, 0);
                GorillaGameModes.GameMode.ReportTag(player);
                yield return new WaitForSeconds(0.2f); // Wait for 0.2 seconds
                //RigShit.GetOwnVRRig().enabled = true;
            }
        }

        static Player beesplayer;

        public static System.Collections.IEnumerator StopMovement()
        {
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeGrabPlayer(beesplayer);
            yield return new WaitForSeconds(0.1f);
            BeeUnGrabPlayer();
            yield return new WaitForSeconds(0.3f);
        }

        public static void OFFTagAllv2()
        {
            if (gy4hefrij)
            {
                gy4hefrij = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        static bool gy4hefrij2;

        public static void OFFTagSelfv2()
        {
            if (gy4hefrij2)
            {
                gy4hefrij2 = false;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void HuntTagAll()
        {
            CoroutineRunner.RunCoroutine(HuntTagAll2());
        }

        public class SkeletonESPClass : MonoBehaviour
        {
            public Color lineColor = Color.white;
            public float lineWidth = 0.02f;

            private LineRenderer lineRenderer;
            private List<GameObject> lineObjects = new List<GameObject>();
            public static bool RGBSkeletonESP = false;

            private void Start()
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
            }
            private void Update()
            {
                DrawSkeleton();
            }

            private void OnDestroy()
            {
                ClearLineObjects();
            }

            public void DrawSkeleton()
            {
                ClearLineObjects();

                VRRig rig = GetComponent<VRRig>();
                if (rig == null)
                {
                    Debug.LogWarning("niga");
                    return;
                }

                Color colorrig = rig.mainSkin.material.color;
                if (RGBSkeletonESP)
                {
                    colorrig = GetAnimatedColor();
                }
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.35f, 0), rig.headMesh.transform.position, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.headMesh.transform.up * +0.2f, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.transform.right * -0.15f, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.transform.right * +0.15f, colorrig);
                DrawLine(rig.headMesh.transform.position + rig.transform.right * -0.15f, rig.myBodyDockPositions.leftArmTransform.position, colorrig);
                DrawLine(rig.headMesh.transform.position + rig.transform.right * +0.15f, rig.myBodyDockPositions.rightArmTransform.position, colorrig);
                DrawLine(rig.myBodyDockPositions.leftArmTransform.position, rig.leftHandTransform.position, colorrig);
                DrawLine(rig.myBodyDockPositions.rightArmTransform.position, rig.rightHandTransform.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightThumb.fingerBone1.position, colorrig);
                DrawLine(rig.rightThumb.fingerBone1.position, rig.rightThumb.fingerBone2.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightIndex.fingerBone1.position, colorrig);
                DrawLine(rig.rightIndex.fingerBone1.position, rig.rightIndex.fingerBone2.position, colorrig);
                DrawLine(rig.rightIndex.fingerBone2.position, rig.rightIndex.fingerBone3.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightMiddle.fingerBone1.position, colorrig);
                DrawLine(rig.rightMiddle.fingerBone1.position, rig.rightMiddle.fingerBone2.position, colorrig);
                DrawLine(rig.rightMiddle.fingerBone2.position, rig.rightMiddle.fingerBone3.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftThumb.fingerBone1.position, colorrig);
                DrawLine(rig.leftThumb.fingerBone1.position, rig.leftThumb.fingerBone2.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftIndex.fingerBone1.position, colorrig);
                DrawLine(rig.leftIndex.fingerBone1.position, rig.leftIndex.fingerBone2.position, colorrig);
                DrawLine(rig.leftIndex.fingerBone2.position, rig.leftIndex.fingerBone3.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftMiddle.fingerBone1.position, colorrig);
                DrawLine(rig.leftMiddle.fingerBone1.position, rig.leftMiddle.fingerBone2.position, colorrig);
                DrawLine(rig.leftMiddle.fingerBone2.position, rig.leftMiddle.fingerBone3.position, colorrig);
            }
            private Color GetAnimatedColor()
            {
                float time = Time.time;
                float red = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
                float green = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
                float blue = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
                return new Color(red, green, blue);
            }
            private void ClearLineObjects()
            {
                foreach (GameObject lineObj in lineObjects)
                {
                    Destroy(lineObj);
                }
                lineObjects.Clear();
            }

            private GameObject CreateLineObject()
            {
                GameObject lineObj = new GameObject("LineObject");
                lineObj.transform.SetParent(transform);
                lineObjects.Add(lineObj);
                return lineObj;
            }

            private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
            {
                GameObject lineObj = CreateLineObject();
                LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                lineRenderer.startColor = color;
                lineRenderer.endColor = color;
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(new Vector3[] { startPos, endPos });
            }
        }
        public class RGBSkeletonESPClass : MonoBehaviour
        {
            public Color lineColor = Color.white;
            public float lineWidth = 0.02f;

            private LineRenderer lineRenderer;
            private List<GameObject> lineObjects = new List<GameObject>();
            public static bool RGBSkeletonESP = false;

            private void Start()
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
            }
            private void Update()
            {
                DrawSkeleton();
            }

            private void OnDestroy()
            {
                ClearLineObjects();
            }

            public void DrawSkeleton()
            {
                ClearLineObjects();

                VRRig rig = GetComponent<VRRig>();
                if (rig == null)
                {
                    Debug.LogWarning("niga2");
                    return;
                }

                var colorrig = GetAnimatedColor();

                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.35f, 0), rig.headMesh.transform.position, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.headMesh.transform.up * +0.2f, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.transform.right * -0.15f, colorrig);
                DrawLine(rig.headMesh.transform.position - new Vector3(0, 0.05f, 0), rig.headMesh.transform.position + rig.transform.right * +0.15f, colorrig);
                DrawLine(rig.headMesh.transform.position + rig.transform.right * -0.15f, rig.myBodyDockPositions.leftArmTransform.position, colorrig);
                DrawLine(rig.headMesh.transform.position + rig.transform.right * +0.15f, rig.myBodyDockPositions.rightArmTransform.position, colorrig);
                DrawLine(rig.myBodyDockPositions.leftArmTransform.position, rig.leftHandTransform.position, colorrig);
                DrawLine(rig.myBodyDockPositions.rightArmTransform.position, rig.rightHandTransform.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightThumb.fingerBone1.position, colorrig);
                DrawLine(rig.rightThumb.fingerBone1.position, rig.rightThumb.fingerBone2.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightIndex.fingerBone1.position, colorrig);
                DrawLine(rig.rightIndex.fingerBone1.position, rig.rightIndex.fingerBone2.position, colorrig);
                DrawLine(rig.rightIndex.fingerBone2.position, rig.rightIndex.fingerBone3.position, colorrig);
                DrawLine(rig.rightHandTransform.position, rig.rightMiddle.fingerBone1.position, colorrig);
                DrawLine(rig.rightMiddle.fingerBone1.position, rig.rightMiddle.fingerBone2.position, colorrig);
                DrawLine(rig.rightMiddle.fingerBone2.position, rig.rightMiddle.fingerBone3.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftThumb.fingerBone1.position, colorrig);
                DrawLine(rig.leftThumb.fingerBone1.position, rig.leftThumb.fingerBone2.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftIndex.fingerBone1.position, colorrig);
                DrawLine(rig.leftIndex.fingerBone1.position, rig.leftIndex.fingerBone2.position, colorrig);
                DrawLine(rig.leftIndex.fingerBone2.position, rig.leftIndex.fingerBone3.position, colorrig);
                DrawLine(rig.leftHandTransform.position, rig.leftMiddle.fingerBone1.position, colorrig);
                DrawLine(rig.leftMiddle.fingerBone1.position, rig.leftMiddle.fingerBone2.position, colorrig);
                DrawLine(rig.leftMiddle.fingerBone2.position, rig.leftMiddle.fingerBone3.position, colorrig);
            }
            private Color GetAnimatedColor()
            {
                float time = Time.time;
                float red = Mathf.Sin(time * 2f) * 0.5f + 0.5f;
                float green = Mathf.Sin(time * 1.5f) * 0.5f + 0.5f;
                float blue = Mathf.Sin(time * 2.5f) * 0.5f + 0.5f;
                return new Color(red, green, blue);
            }
            private void ClearLineObjects()
            {
                foreach (GameObject lineObj in lineObjects)
                {
                    Destroy(lineObj);
                }
                lineObjects.Clear();
            }

            private GameObject CreateLineObject()
            {
                GameObject lineObj = new GameObject("LineObject");
                lineObj.transform.SetParent(transform);
                lineObjects.Add(lineObj);
                return lineObj;
            }

            private void DrawLine(Vector3 startPos, Vector3 endPos, Color color)
            {
                GameObject lineObj = CreateLineObject();
                LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
                lineRenderer.startColor = color;
                lineRenderer.endColor = color;
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(new Vector3[] { startPos, endPos });
            }
        }

        static bool baweiofjwf = true;

        static Player beesPlayer;

        public static GameObject auraObj = null;

        static float smth46;

        public static void TagAura()
        {
            if (balll < Time.time)
            {
                ChangeMatAfterGhost();
                balll = Time.time + 0.2f;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Vector3 you = GorillaTagger.Instance.offlineVRRig.transform.position;
                    Vector3 rig = vrrig.headMesh.transform.position;
                    float distance = Vector3.Distance(rig, you);
                    ////if (auraObj == null)
                    //{
                        //auraObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //auraObj.transform.position = you;
                        //auraObj.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                        //auraObj.transform.localScale = new Vector3(GorillaGameManager.instance.tagDistanceThreshold - 0.5f, GorillaGameManager.instance.tagDistanceThreshold - 0.5f, GorillaGameManager.instance.tagDistanceThreshold - 0.5f);
                        //Color newColor = new Color(1, 1, 1, 0.5f);
                        //auraObj.GetComponent<Renderer>().material.color = newColor;
                        //auraObj.name = "Aura Object";
                        //Destroy(auraObj.GetComponent<SphereCollider>());
                    //}
                    //auraObj.transform.position = you;
                    //auraObj.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                    if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !vrrig.mainSkin.material.name.Contains("fected") && GorillaLocomotion.Player.Instance.disableMovement == false && distance < GorillaGameManager.instance.tagDistanceThreshold - 0.5f)
                    {
                        GorillaGameModes.GameMode.ReportTag(RigShit.GetPlayerFromRig(vrrig));
                    }
                }
            }
        }

        public static void HuntTagAura()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.2f;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Vector3 you = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                    Vector3 rig = vrrig.headMesh.transform.position;
                    float distance = Vector3.Distance(rig, you);
                    if (GorillaLocomotion.Player.Instance.disableMovement == false && distance < GorillaGameManager.instance.tagDistanceThreshold)
                    {
                        GorillaGameModes.GameMode.ReportTag(RigShit.GetPlayerFromRig(vrrig));
                    }
                }
            }
        }

        public static VRRig taggingrig;

        public static void TagSelf()
        {
            ChangeMatAfterGhost();
            foreach (GorillaTagManager gorillaTagManager in GameObject.FindObjectsOfType<GorillaTagManager>())
            {
                if (gorillaTagManager.currentInfected.Contains(PhotonNetwork.LocalPlayer))
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetButton("Tag Self").enabled = false;
                }
                else
                {
                    foreach (VRRig rig in GorillaParent.instance.vrrigs)
                    {
                        if (rig.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = rig.rightHandTransform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = rig.rightHandTransform.position;
                        }
                    }
                }
            }
        }

        public static void LoudTaps()
        {
            GorillaTagger.Instance.handTapVolume = 999f;
            stuiejrf = true;
        }

        public static void OFFLoudTaps()
        {
            if (stuiejrf)
            {
                stuiejrf = false;
                GorillaTagger.Instance.handTapVolume = 0.1f;
            }
        }

        public static void SilentTaps()
        {
            GorillaTagger.Instance.handTapVolume = 0f;
            stuiejrf1 = true;
        }

        static bool stuiejrf1 = false;

        public static void OFFSilentTaps()
        {
            if (stuiejrf1)
            {
                stuiejrf1 = false;
                GorillaTagger.Instance.handTapVolume = 0.1f;
            }
        }

        public static void NoTapCooldown()
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
            stuiejrf2 = true;
        }

        public static void Metal()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            18,
                            true,
                              999f
                });
                flushmanually();
            }
        }

        public static void Crystal()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            20,
                            true,
                            999f
                });
                flushmanually();
            }
        }

        public static void HugeCrystal()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            213,
                            true,
                              999f
                });
                flushmanually();
            }
        }

        public static void AK()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            203,
                            true,
                              999f
                });
                flushmanually();
            }
        }

        public static void Ear()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            215,
                            true,
                              999f
                });
                flushmanually();
            }
        }

        public static void Rand()
        {
            if (WristMenu.triggerDownL && balll < Time.time)
            {
                balll = Time.time + 0.01f;
                int rand = UnityEngine.Random.Range(0, 215);
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                {
                            rand,
                            true,
                              999f
                });
                flushmanually();
            }
        }

        /*public static void Up()
        {
            if (ropedelay < Time.time && WristMenu.triggerDownL)
            {
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    int num = (gorillaRopeSwing.localPlayerBoneIndex = gorillaRopeSwing.GetBoneIndex(gorillaRopeSwing.grabbedBone));
                    RopeSwingManager.instance.SendSetVelocity_RPC(gorillaRopeSwing.ropeId, num, velocity, wholeRope: true);
                    PhotonView photonView = gorillaRopeSwing.photonView;
                    string methodName = "SetVelocity";
                    RpcTarget target = RpcTarget.All;
                    object[] array2 = new object[4];
                    array2[0] = 10;
                    array2[1] = new Vector3((float)UnityEngine.Random.Range(10, 415169), (float)UnityEngine.Random.Range(10, 241161099), (float)UnityEngine.Random.Range(10, 3826319));
                    array2[2] = true;
                    photonView.RPC(methodName, target, array2);
                    flushmanually();
                }
                ropedelay = Time.time + 0.1f;
            }
        }*/

        /*public static void FreezeAll()
        {
            foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
            {
                PhotonView photonView = gorillaRopeSwing.photonView;
                string methodName = "SetVelocity";
                RpcTarget target = RpcTarget.Others;
                object[] array2 = new object[4];
                array2[0] = 1;
                array2[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                array2[2] = true;
                photonView.RPC(methodName, target, array2);
                flushmanually();
            }
            GetButton("Freeze All").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }*/

        public static void mean()
        {
            foreach (MagicCauldron mc in UnityEngine.Object.FindObjectsOfType(typeof(MagicCauldron)))
            {
                mc.photonView.RPC("OnIngredientAdd", RpcTarget.MasterClient, new object[]
                {
                        2
                });
                mc.photonView.RPC("OnIngredientAdd", RpcTarget.MasterClient, new object[]
{
                        3
});
                mc.photonView.RPC("OnIngredientAdd", RpcTarget.MasterClient, new object[]
{
                        0
});
            }
            Mods.flushmanually();
            GetButton("Low Gravity All").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void infrocks()
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject.Find("Photon Manager").GetComponent<Recorder>().SourceType = Recorder.InputSourceType.AudioClip;
                GameObject.Find("Photon Manager").GetComponent<Recorder>().AudioClip = GameObject.Find("SoundPostForest").GetComponent<SynchedMusicController>().audioSource.clip;
                GameObject.Find("Photon Manager").GetComponent<Recorder>().RestartRecording(true);
            }
        }

        public static List<Player> playerCrashed = new List<Player>();

        /*public static void Deathtrap()
        {
            foreach (Player rig in PhotonNetwork.PlayerListOthers)
            {
                if (RigShit.GetPlayersRope(RigShit.GetRigFromPlayer(rig)) != null)
                {
                    if (!playerCrashed.Contains(rig))
                    {
                        GTAG_NotificationLib.NotifiLib.SendNotification("<color=green>Crashing:</color> " + rig.NickName);
                        PhotonView photonView = RigShit.GetPlayersRope(RigShit.GetRigFromPlayer(rig)).photonView;
                        string methodName = "SetVelocity";
                        Player target = rig;
                        object[] array2 = new object[4];
                        array2[0] = 1;
                        array2[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                        array2[2] = true;
                        photonView.RPC(methodName, target, array2);
                        flushmanually();

                        playerCrashed.Add(rig);

                    }

                }
                else
                {
                    if (playerCrashed.Contains(rig))
                    {
                        playerCrashed.Remove(rig);
                    }
                }

            }
        }*/

        static bool antireportballs = false;



        /*public static void RopeCrashGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (ropedelay < Time.time)
                    {
                        ropedelay = Time.time + 0.1f;
                        if (RigShit.GetRigFromPlayer(owner).grabbedRopeIndex != -1)
                        {
                            foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                            {
                                PhotonView photonView = gorillaRopeSwing.photonView;
                                string methodName = "SetVelocity";
                                Player target = owner;
                                object[] array2 = new object[4];
                                array2[0] = 1;
                                array2[1] = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                                array2[2] = true;
                                photonView.RPC(methodName, target, array2);
                                flushmanually();
                                antireportballs = false;
                            }
                        }

                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }*/

        public static void LaunchProj(int proj, Vector3 pos, Vector3 vel)
        {
            fun = true;
            Color throwableProjectileColor = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
            if (rainboww)
            {
                int rand = (int)UnityEngine.Random.Range(0, 6);
                if (rand == 0)
                {
                    throwableProjectileColor = Color.red;
                }
                if (rand == 1)
                {
                    throwableProjectileColor = Color.yellow;
                }
                if (rand == 2)
                {
                    throwableProjectileColor = Color.black;
                }
                if (rand == 3)
                {
                    throwableProjectileColor = Color.white;
                }
                if (rand == 4)
                {
                    throwableProjectileColor = Color.magenta;
                }
                if (rand == 5)
                {
                    throwableProjectileColor = Color.green;
                }
            }
            GorillaGameManager.instance.returnPhotonView.RpcSecure("LaunchSlingshotProjectile", RpcTarget.All, true, new object[]
                {
                pos,
                vel,
                proj,
                projectiletrailhash,
                false,
                1,
                rainboww,
                throwableProjectileColor.r,
                throwableProjectileColor.g,
                throwableProjectileColor.b,
            throwableProjectileColor.a
                });
            PhotonNetwork.SendAllOutgoingCommands();
            RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
        }

        public static void DestoryGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        PhotonNetwork.CurrentRoom.StorePlayer(owner);
                        PhotonNetwork.CurrentRoom.Players.Remove(owner.ActorNumber);
                        PhotonNetwork.OpRemoveCompleteCacheOfPlayer(owner.ActorNumber);

                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        /*public static void Down()
        {
            if (ropedelay < Time.time && WristMenu.triggerDownL)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    PhotonView photonView = gorillaRopeSwing.photonView;
                    string methodName = "SetVelocity";
                    RpcTarget target = RpcTarget.All;
                    object[] array2 = new object[4];
                    array2[0] = 10;
                    array2[1] = new Vector3((float)UnityEngine.Random.Range(10, 411646), UnityEngine.Random.Range(10f, -2.262549E+09f), (float)UnityEngine.Random.Range(10, 3826319));
                    array2[2] = true;
                    photonView.RPC(methodName, target, array2);
                    flushmanually();
                }
            }
        }*/

        /*public static void Spaz()
        {
            if (ropedelay < Time.time && WristMenu.triggerDownL)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    PhotonView photonView = gorillaRopeSwing.photonView;
                    string methodName = "SetVelocity";
                    RpcTarget target = RpcTarget.All;
                    object[] array2 = new object[4];
                    array2[0] = 10;
                    array2[1] = new Vector3((float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999));
                    array2[2] = true;
                    photonView.RPC(methodName, target, array2);
                    flushmanually();
                }
            }
        }*/

        /*public static void SpazGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                GorillaRopeSwing rope = raycastHit.collider.GetComponentInParent<GorillaRopeSwing>();
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        rope = lockdedrope;
                    }

                    if (lockedrig != null)
                    {
                        rope = lockdedrope;
                    }
                }
                if (WristMenu.triggerDownR)
                {
                    if (ropedelay < Time.time)
                    {
                        ropedelay = Time.time + 0.1f;
                        Vector3 directionToLook = pointer.transform.position - rope.transform.position;
                        Quaternion lookRotation = Quaternion.LookRotation(directionToLook);
                        pointer.transform.rotation = lookRotation;
                        PhotonView photonView = rope.photonView;
                        string methodName = "SetVelocity";
                        RpcTarget target = RpcTarget.All;
                        object[] array2 = new object[4];
                        array2[0] = 10;
                        array2[1] = new Vector3((float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999), (float)UnityEngine.Random.Range(0, 999));
                        array2[2] = true;
                        photonView.RPC(methodName, target, array2);
                        flushmanually();
                    }
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }*/

        /*public static void Freeze()
        {
            if (ropedelay < Time.time && WristMenu.triggerDownL)
            {
                ropedelay = Time.time + 0.1f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    PhotonView photonView = gorillaRopeSwing.photonView;
                    string methodName = "SetVelocity";
                    RpcTarget target = RpcTarget.All;
                    object[] array2 = new object[4];
                    array2[0] = 10;
                    array2[1] = GorillaLocomotion.Player.Instance.bodyCollider.center;
                    array2[2] = true;
                    photonView.RPC(methodName, target, array2);
                    flushmanually();
                }
            }
        }*/
        
        /*public static void Slow()
        {
            if (ropedelay < Time.time && WristMenu.triggerDownL)
            {
                ropedelay = Time.time + 0.40f;
                foreach (GorillaRopeSwing gorillaRopeSwing in UnityEngine.Object.FindObjectsOfType(typeof(GorillaRopeSwing)))
                {
                    PhotonView photonView = gorillaRopeSwing.photonView;
                    string methodName = "SetVelocity";
                    RpcTarget target = RpcTarget.All;
                    object[] array2 = new object[4];
                    array2[0] = 10;
                    array2[1] = GorillaLocomotion.Player.Instance.bodyCollider.center;
                    array2[2] = true;
                    photonView.RPC(methodName, target, array2);
                    flushmanually();
                }
            }
        }*/

        public struct SoundEffect
        {
            public int id;

            public float volume;

            public SoundEffect(int soundID, float soundVolume)
            {
                id = soundID;
                volume = (volume = soundVolume);
            }
        }

        public static void SendSoundEffectToPlayer(int soundIndex, float soundVolume)
        {
            SendSoundEffectToPlayer(new SoundEffect(soundIndex, soundVolume), reoOthers);
        }

        public static object[] soundSendData = new object[2];
        public static readonly object[] sendEventData = new object[3];

        public static void SendSoundEffectToPlayer(SoundEffect sound, RaiseEventOptions player)
        {
            soundSendData[0] = sound.id;
            soundSendData[1] = sound.volume;
            byte b = 3;
            object obj = soundSendData;
            sendEventData[0] = PhotonNetwork.ServerTimestamp;
            sendEventData[1] = 3;
            sendEventData[2] = soundSendData;
            PhotonNetwork.RaiseEvent(3, sendEventData, reoALL, soUnreliable);
        }

        public static void Spam1()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                {
                    if (WristMenu.triggerDownL)
                    {
                        SendSoundEffectToPlayer(1, float.MaxValue - 1);
                        flushmanually();
                    }
                }
            }
        }

        public static void Spam2()
        {
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    if (WristMenu.triggerDownL)
                    {
                        SendSoundEffectToPlayer(2, float.MaxValue - 1);
                        flushmanually();
                    }
                }
            }
        }

        public static void Spam3()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (PhotonNetwork.LocalPlayer == PhotonNetwork.MasterClient)
                {
                    if (WristMenu.triggerDownL)
                    {
                        SendSoundEffectToPlayer((int)UnityEngine.Random.Range(0, 9), float.MaxValue - 1);
                        flushmanually();
                    }
                }
            }
        }


        public static void Tracers()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                bool NotME = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (NotME)
                {
                    if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
                    {
                        vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.015f;
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                    }
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
                    if (tracerscolor == 0)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.red;
                        }
                        else
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.green;
                        }
                    }
                    else
                    {
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
                    }
                    if (tracerspos == 0)
                    {
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
                    }
                    else if (tracerspos == 1)
                    {
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position);
                    }
                    else if (tracerspos == 2)
                    {
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0, 0.2f, 0));
                    }
                    else if (tracerspos == 3)
                    {
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0, -0.2f, 0));
                    }
                }
            }
            weufewfjdfjn111 = true;
        }

        public static void tracersss()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                Color fun;
                Vector3 rigpos;
                bool NotME = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (NotME)
                {
                    rigpos = vrrig.head.rigTarget.gameObject.transform.position;
                    if (tracerscolor == 0)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            fun = Color.red;
                        }
                        else
                        {
                            fun = Color.green;
                        }
                    }
                    else
                    {
                        fun = vrrig.playerColor;
                    }
                    Vector3 position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                    Vector3 point = rigpos;
                    Vector3 vector = (point - position).normalized;
                    float d = 99f;
                    vector *= d;
                    Color tC = Color.red;
                    bool flag3 = GorillaGameManager.instance != null;
                    bool flag4 = flag3;
                    bool flag5 = flag4;
                    if (flag5)
                    {
                        GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.All, new object[]
                        {
                                 rigpos,
                                 vector,
                                 -820530352,
                                 163790326,
                                 true,
                                 1,
                                 true,
                                 tC.r,
                                 tC.g,
                                 tC.b,
                                 1f
                        });

                    }
                }
            }
        }

        public static void LurkerESP()
        {
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
            GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.color = Color.blue;
            widhcnkesdj9 = true;
        }

        public static void ESP()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && ((UnityEngine.Object)((Renderer)vrrig.mainSkin).material).name.Contains("fected"))
                {
                    ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                    if (espcolor == 0)
                    {
                        ((Renderer)vrrig.mainSkin).material.color = new Color(9f, 0f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        ((Renderer)vrrig.mainSkin).material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
                else if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer)
                {
                    ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                    ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                    if (espcolor == 0)
                    {
                        ((Renderer)vrrig.mainSkin).material.color = new Color(0f, 9f, 0f, 0.5f);
                    }
                    else
                    {
                        vrrig.playerColor.a = 0.5f;
                        ((Renderer)vrrig.mainSkin).material.color = vrrig.playerColor;
                        vrrig.playerColor.a = 1f;
                    }
                }
            }
            widhcnkesdj = true;
        }

        public static void ESPOnHuntTarget()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                GorillaHuntManager instance = GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>();
                if (RigShit.GetRigFromPlayer(instance.GetTargetOf(PhotonNetwork.LocalPlayer)) == vrrig)
                {
                    ((Renderer)vrrig.mainSkin).material.shader = Shader.Find("GUI/Text Shader");
                    ((Renderer)vrrig.mainSkin).material.color = Color.blue;
                }
            }
            widhcnkesdj1 = true;
        }

        public static void TPBehindTarget()
        {
            if (WristMenu.triggerDownL)
            {
                GorillaHuntManager instance = GameObject.Find("Gorilla Hunt Manager(Clone)").GetComponent<GorillaHuntManager>();
                foreach (Player p in PhotonNetwork.PlayerListOthers)
                {
                    if (p == instance.GetTargetOf(PhotonNetwork.LocalPlayer))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(beesPlayer);
                        GorillaLocomotion.Player.Instance.transform.position = rig.transform.position + rig.transform.forward * -1f * Time.deltaTime;
                        GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.transform.position;
                    }
                }
            }
        }

        public static void WaterBalloonSpammer()
        {
            if (WristMenu.triggerDownL)
            {
                UnityEngine.Object.Destroy(GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<AudioSource>());
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().projectilePrefab.tag = "WaterBalloonProjectile";
                GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").GetComponent<SnowballThrowable>().randomizeColor = false;
            }
            else
            {
                if (!GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").gameObject.GetComponent<AudioSource>())
                {
                    GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.R/upper_arm.R/forearm.R/hand.R/palm.01.R/TransferrableItemRightHand/SnowballRightAnchor").transform.Find("LMACF.").gameObject.AddComponent<AudioSource>();
                }
            }
        }

        public static void DestoryAll()
        {
            foreach (Photon.Realtime.Player owner in PhotonNetwork.PlayerListOthers)
            {
                PhotonNetwork.CurrentRoom.StorePlayer(owner);
                PhotonNetwork.CurrentRoom.Players.Remove(owner.ActorNumber);
                PhotonNetwork.OpRemoveCompleteCacheOfPlayer(owner.ActorNumber);
            }
        }

        public static void KillAll()
        {
            if (balll2 < Time.time)
            {
                balll2 = Time.time + 3.5f;
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (rig.mainSkin.material.name.Contains("orangealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("blue") || rig.mainSkin.material.name.Contains("bluealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("orange"))
                    {
                        GameObject gameObject = ObjectPools.instance.Instantiate(-1674517839);
                        SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>();
                        Color throwableProjectileColor = GorillaTagger.Instance.offlineVRRig.GetThrowableProjectileColor(false);
                        component.Launch(rig.transform.position, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 0.5f, false, throwableProjectileColor);
                        flushmanually();
                    }
                }
            }
        }

        static float smth496;

        public static void SilentAim()
        {
            if (smth496 < Time.time)
            {
                smth496 = Time.time + 0.05f;
                VRRig target = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
                if (target.mainSkin.material.name.Contains("orangealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("blue") || target.mainSkin.material.name.Contains("bluealive") && GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("orange"))
                {
                    target = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
                }
                foreach (SlingshotProjectile proj in GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools").GetComponentsInChildren<SlingshotProjectile>())
                {
                    if (proj.projectileOwner == PhotonNetwork.LocalPlayer)
                    {
                        proj.gameObject.transform.position = target.transform.position;
                        flushmanually();
                    }
                }
            }
        }

        public static ButtonInfo GetButton(string name)
        {
            foreach (ButtonInfo buttons in WristMenu.buttons)
            {
                if (buttons.buttonText.Contains(name))
                {
                    return buttons;
                }
                if (buttons.buttonText == name)
                {
                    return buttons;
                }
            }
            return null;
        }

        public static ButtonInfo GetButtonOP(string name)
        {
            foreach (ButtonInfo buttons in WristMenu.opbuttons)
            {
                if (buttons.buttonText.Contains(name))
                {
                    return buttons;
                }
                if (buttons.buttonText == name)
                {
                    return buttons;
                }
            }
            return null;
        }

        public static ButtonInfo GetButtonSettings(string name)
        {
            foreach (ButtonInfo buttons in WristMenu.settingsbuttons)
            {
                if (buttons.buttonText == name)
                {
                    return buttons;
                }
            }
            return null;
        }

        public static void Beacons()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                bool NotME = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (NotME)
                {
                    if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
                    {
                        vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.025f;
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GUI/Text Shader");
                    }
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position + new Vector3(0, 50, 0));
                    vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, vrrig.head.rigTarget.gameObject.transform.position - new Vector3(0, 50, 0));
                }
            }
            weufewfjdfjn = true;
        }

        public static void OFFBeacons()
        {
            if (weufewfjdfjn == true)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
                }

                weufewfjdfjn = false;
            }
        }
        public static GradientColorKey[] colorKeysPlatformMonke9 = new GradientColorKey[3];
        public static GradientColorKey[] colorKeysPlatformMonke2 = new GradientColorKey[3];
        static bool kowfjwefwjnef = false;

        public static void OFFShibaESP()
        {
            if (kowfjwefwjnef)
            {
                VRRig[] array4 = (VRRig[])(object)UnityEngine.Object.FindObjectsOfType(typeof(VRRig));
                foreach (VRRig vrrig2 in array4)
                {
                    if (!vrrig2.isOfflineVRRig && !vrrig2.isMyPlayer)
                    {
                        vrrig2.ChangeMaterialLocal(vrrig2.currentMatIndex);
                    }
                }
                kowfjwefwjnef = false;
            }
        }

        public static float balll2111;

        public static float balll435342111;

        public static float balll21191;

        static float balll21111;

        static float balll2;

        static float balll3;

        public static void Strobe()
        {
            if (balll2 < Time.time)
            {
                balll2 = Time.time + 0.12f;
                Color color = Color.white;
                int rand = UnityEngine.Random.Range(0, 11);
                if (rand == 0)
                {
                    color = Color.black;
                }
                if (rand == 1)
                {
                    color = Color.white;
                }
                if (rand == 2)
                {
                    color = Color.yellow;
                }
                if (rand == 3)
                {
                    color = Color.red;
                }
                if (rand == 4)
                {
                    color = Color.green;
                }
                if (rand == 5)
                {
                    color = Color.magenta;
                }
                if (rand == 6)
                {
                    color = Color.cyan;
                }
                if (rand == 7)
                {
                    color = Color.grey;
                }
                if (rand == 8)
                {
                    color = Color.clear;
                }
                if (rand == 9)
                {
                    color = Color.blue;
                }
                if (rand == 10)
                {
                    color = Color.black;
                }
                ChangeMonkColor(color);
                flushmanually();
            }
        }

        public static void ChangeMonkColor(Color color)
        {
            if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
            {
                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.All, new object[]
                {
                color.r,
                color.g,
                color.b,
                false
                });
            }
        }


        public static void ShibaUserESP()
        {
            if (PhotonNetwork.InRoom)
            {
                colorKeysPlatformMonke9[0].color = Color.black;
                colorKeysPlatformMonke9[0].time = 0f;
                colorKeysPlatformMonke9[1].color = Color.green;
                colorKeysPlatformMonke9[1].time = 0.5f;
                colorKeysPlatformMonke9[2].color = Color.black;
                colorKeysPlatformMonke9[2].time = 1f;
                colorKeysPlatformMonke2[0].color = Color.black;
                colorKeysPlatformMonke2[0].time = 0f;
                colorKeysPlatformMonke2[1].color = Color.red;
                colorKeysPlatformMonke2[1].time = 0.5f;
                colorKeysPlatformMonke2[2].color = Color.black;
                colorKeysPlatformMonke2[2].time = 1f;
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                {
                    object darkPropertyValue;
                    if (p.CustomProperties.TryGetValue("Dark", out darkPropertyValue) && darkPropertyValue is string)
                    {
                        string isDark = (string)darkPropertyValue;
                        if (isDark == "true")
                        {
                            VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(beesPlayer);
                            if (rig != null)
                            {
                                rig.mainSkin.material.shader = Shader.Find("GUI/Text Shader");
                                ColorChanger colorChanger = rig.mainSkin.gameObject.GetOrAddComponent<ColorChanger>();
                                Gradient gradient = new Gradient();
                                colorChanger.colors = gradient;
                                if (rig.mainSkin.material.name.Contains("fected") || rig.mainSkin.material.name.Contains("rock"))
                                {
                                    gradient.colorKeys = colorKeysPlatformMonke2;
                                }
                                else if (!rig.mainSkin.material.name.Contains("fected"))
                                {
                                    gradient.colorKeys = colorKeysPlatformMonke;
                                }

                            }
                        }
                    }
                    else
                    {
                        VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(beesPlayer);
                        Destroy(rig.mainSkin.gameObject.GetComponent<ColorChanger>());
                    }
                }
            }
            kowfjwefwjnef = true;
        }

        public static void ModderTracers()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (RigShit.GetPlayerFromRig(vrrig).CustomProperties.ContainsKey("mods"))
                {
                    if (!vrrig.isMyPlayer)
                    {
                        if (!vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>())
                        {
                            vrrig.head.rigTarget.gameObject.AddComponent<LineRenderer>();
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().startWidth = 0.015f;
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                        }
                        if (tracerscolor == 0)
                        {
                            if (vrrig.mainSkin.material.name.Contains("fected"))
                            {
                                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.red;
                            }
                            else
                            {
                                vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = Color.green;
                            }
                        }
                        else
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().material.color = vrrig.playerColor;
                        }
                        vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(0, vrrig.head.rigTarget.gameObject.transform.position);
                        if (tracerspos == 0)
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position);
                        }
                        else if (tracerspos == 1)
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position);
                        }
                        else if (tracerspos == 2)
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0, 0.2f, 0));
                        }
                        else if (tracerspos == 3)
                        {
                            vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>().SetPosition(1, GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0, -0.2f, 0));
                        }
                    }
                }
            }
            weufewfjdfjn1111 = true;
        }

        public static void OFFTracers()
        {
            if (weufewfjdfjn111 == true)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());
                }

                weufewfjdfjn111 = false;
            }
        }

        public static void OFFModTracers()
        {
            if (weufewfjdfjn1111 == true)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    Destroy(vrrig.head.rigTarget.gameObject.GetComponent<LineRenderer>());

                }
                weufewfjdfjn1111 = false;
            }
        }

        static bool weufewfjdfjn111 = true;

        static bool weufewfjdfjn1111 = true;

        static bool weufewfjdfjn = true;

        static bool widhcnkesdj = false;

        static bool widhcnkesdj9 = false;

        static bool widhcnkesdj1 = false;

        public static void espoff()
        {
            if (widhcnkesdj)
            {
                VRRig[] array4 = (VRRig[])(object)UnityEngine.Object.FindObjectsOfType(typeof(VRRig));
                foreach (VRRig vrrig2 in array4)
                {
                    if (!vrrig2.isOfflineVRRig && !vrrig2.isMyPlayer)
                    {
                        vrrig2.ChangeMaterialLocal(vrrig2.currentMatIndex);
                    }
                }
                widhcnkesdj = false;
            }
        }

        public static void OFFLurkerESP()
        {
            if (widhcnkesdj9)
            {
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/URPScryable");
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/GhostLurker_Prefab/GhostLurker").GetComponent<Renderer>().material.color = new Color(0.6886f, 0.434f, 0.787f, 0.349f);
                widhcnkesdj9 = false;
            }
        }

        public static void esphuntoff()
        {
            if (widhcnkesdj1)
            {
                VRRig[] array4 = (VRRig[])(object)UnityEngine.Object.FindObjectsOfType(typeof(VRRig));
                foreach (VRRig vrrig2 in array4)
                {
                    if (!vrrig2.isOfflineVRRig && !vrrig2.isMyPlayer)
                    {
                        vrrig2.ChangeMaterialLocal(vrrig2.currentMatIndex);
                    }
                }
                widhcnkesdj1 = false;
            }
        }

        static float ropedelay;
        static float ropedelay1;
        static bool stuiejrf2 = false;

        public static void OFFNoTapCooldown()
        {
            if (stuiejrf2)
            {
                stuiejrf2 = false;
                GorillaTagger.Instance.tapCoolDown = 0.1f;
            }
        }

        static bool stuiejrf = true;


        static bool stuiejrf99 = true;

        public static void AntiReportInternal(EventData data)
        {
            if (data.Code == 50)
            {
                object[] a = (object[])data.CustomData;
                if ((string)a[0] == PhotonNetwork.LocalPlayer.UserId)
                {
                    PhotonNetwork.Disconnect();
                    NotifiLib.SendNotification("<color=red>[AntiReport] </color> Player " + (string)a[3] + " Reported you for " + (GorillaPlayerLineButton.ButtonType)a[1]);
                }
            }
        }

        public static void NoTagOnroomJoinFalse()
        {
            if (!stuiejrf99)
            {
                stuiejrf99 = true;
                PlayerPrefs.SetString("tutorial", "true");
                ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
                hashtable.Add("didTutorial", true);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
                PlayerPrefs.Save();
            }
        }

        public static void NoTagJoin()
        {
            PlayerPrefs.SetString("tutorial", "false");
            ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            hashtable.Add("didTutorial", true);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hashtable, null, null);
            PlayerPrefs.Save();
            stuiejrf99 = false;

        }

        public static void AntiTag()
        {
            if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
            {
                ChangeMatAfterGhost();
                return;
            }
            foreach (VRRig rig in GorillaParent.instance.vrrigs)
            {
                if (rig.mainSkin.material.name.Contains("fected"))
                {
                    if (Vector3.Distance(rig.transform.position, GorillaTagger.Instance.offlineVRRig.transform.position) <= 7)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.transform.position - new Vector3(0, 7, 0);
                    }
                }
            }
            GorillaTagger.Instance.offlineVRRig.enabled = true;
        }

        static bool gy4hefrij;

        public static void TagAll()
        {
            if (!GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected"))
            {
                ChangeMatAfterGhost();
                NotifiLib.SendNotification("<color=red>[TAG ALL]</color> You must be tagged!");
                GetButton("Tag All").enabled = false;
            }
            else
            {
                bool EveryoneTagged = false;
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (!vrrig.mainSkin.material.name.Contains("fected"))
                    {
                        EveryoneTagged = true;
                        break;
                    }
                }
                if (EveryoneTagged)
                {
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            GorillaTagger.Instance.myVRRig.transform.position = vrrig.transform.position;

                            Vector3 you = GorillaTagger.Instance.offlineVRRig.transform.position;
                            Vector3 rig = vrrig.transform.position;
                            float distance = Vector3.Distance(rig, you);

                            if (GorillaTagger.Instance.offlineVRRig.mainSkin.material.name.Contains("fected") && !vrrig.mainSkin.material.name.Contains("fected") && distance < 1.667)
                            {
                                GorillaGameModes.GameMode.ReportTag(RigShit.GetPlayerFromRig(vrrig));
                            }
                        }
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    GetButton("Tag All").enabled = false;
                }
            }
        }

        public static void SpazHands()
        {
            if (WristMenu.triggerDownR)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                var loco = GorillaLocomotion.Player.Instance;

                GorillaTagger.Instance.offlineVRRig.transform.position = loco.transform.position;
                    

                GorillaTagger.Instance.offlineVRRig.leftHandTransform.transform.position = loco.leftHandFollower.position;
                GorillaTagger.Instance.offlineVRRig.rightHandTransform.transform.position = loco.rightHandFollower.position;

                GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = loco.headCollider.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.headConstraint.position = loco.headCollider.transform.position;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 99), UnityEngine.Random.Range(0, 99), UnityEngine.Random.Range(0, 99)));
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.rotation = Quaternion.Euler(new Vector3(UnityEngine.Random.Range(0, 99), UnityEngine.Random.Range(0, 99), UnityEngine.Random.Range(0, 99)));
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                var loco = GorillaLocomotion.Player.Instance;
                GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = loco.headCollider.transform.rotation;
            }
        }

        public static Player lucyTarget;

        public static float lucyspeed = 0.1f;

        public static void LucyRandom()
        {
            if (WristMenu.gripDownR)
            {
                if (lucyTarget == null)
                {
                    lucyTarget = RigShit.GetRandomPlayer(false);
                }
                VRRig lucyTargetRig = RigShit.GetRigFromPlayer(lucyTarget);
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position += GorillaTagger.Instance.offlineVRRig.transform.forward * lucyspeed * Time.deltaTime;
                GorillaTagger.Instance.offlineVRRig.transform.LookAt(lucyTargetRig.transform);
                lucyspeed += 0.005f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lucyspeed = 0.1f;
            }
        }

        public static void BackwardsHands()
        {
            if (WristMenu.triggerDownR)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);
                GorillaTagger.Instance.myVRRig.transform.position = GorillaTagger.Instance.bodyCollider.transform.position + new Vector3(0f, 0.15f, 0f);

                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                GorillaTagger.Instance.myVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.headCollider.transform.rotation;

                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;

                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.RotateAround(GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position, GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.forward, 180f);
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.RotateAround(GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position, GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.forward, 180f);

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.leftHandTransform.position + GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.forward * 3f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.rightHandTransform.position + GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.forward * 3f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        static float flusherDelay;

        public static void NewFlusher()
        {
            if (flusherDelay < Time.time)
            {
                flusherDelay = Time.time + 0.12f;
                PhotonNetwork.OpCleanActorRpcBuffer(PhotonNetwork.LocalPlayer.ActorNumber);
                PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
                PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, null, null);
                PhotonNetwork.RemoveBufferedRPCs(int.MaxValue, null, null);
                PhotonNetwork.SendAllOutgoingCommands();
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                GorillaNot.instance.OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
            }
        }

        static bool a = false;

        public static void offnoclip()
        {
            foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
            {
                meshCollider2.enabled = true;
            }
        }

        public static void NoClip(bool force)
        {
            if (force)
            {
                foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                {
                    meshCollider2.enabled = false;
                }
            }
            if (!force)
            {
                if (WristMenu.triggerDownL && !a)
                {
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = false;
                    }
                    a = true;
                }
                if (!WristMenu.triggerDownL && a)
                {
                    foreach (MeshCollider meshCollider2 in Resources.FindObjectsOfTypeAll<MeshCollider>())
                    {
                        meshCollider2.enabled = true;
                    }
                    a = false;
                }
            }
        }

        public static void OFFTagAll()
        {
            if (!baweiofjwf)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                baweiofjwf = true;
            }

        }


        public static void RBend()
        {
            if (WristMenu.triggerDownR)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                {
                            RigShit.GetOwnVRRig().rightHandTransform.position,
                            RigShit.GetOwnVRRig().rightHandTransform.rotation,
                            10f,
                            100f,
                            true,
                            true
                });
                flushmanually();
            }
        }

        public static void LBend()
        {
            if (smth46 < Time.time)
            {
                smth46 = Time.time + 0.05f;
                if (WristMenu.triggerDownL)
                {
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                    {
                            RigShit.GetOwnVRRig().leftHandTransform.position,
                            RigShit.GetOwnVRRig().leftHandTransform.rotation,
                            10f,
                            100f,
                            true,
                            true
                    });
                    flushmanually();
                }
            }
        }

        public static void sizesplash()
        {
            if (smth46 < Time.time)
            {
                smth46 = Time.time + 0.05f;
                if (WristMenu.gripDownL && WristMenu.gripDownR)
                {
                    Vector3 pos;
                    pos = Vector3.Lerp(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position, 0.5f);
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                    {
                            pos,
                            Quaternion.identity,
                            (float)Vector3.Distance(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position) + 1,
                            (float)Vector3.Distance(GorillaTagger.Instance.rightHandTransform.position, GorillaTagger.Instance.leftHandTransform.position) + 1,
                            false,
                            true
                    });
                    flushmanually();
                }
            }
        }


        public static void SplashAura()
        {
            if (WristMenu.triggerDownL)
            {
                foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                {
                    if (Vector3.Distance(vrrig.transform.position, RigShit.GetOwnVRRig().transform.position) <= 9 && vrrig.playerText.text != PhotonNetwork.LocalPlayer.NickName)
                    {
                        GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                                {
                            vrrig.transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                                });
                        flushmanually();
                    }
                }
            }
        }



        public static GameObject pointer;

        public static void Splash()
        {
            if (WristMenu.triggerDownL)
            {
                if (balll < Time.time)
                {
                    balll = Time.time + 0.2f;
                    GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                        {
                            RigShit.GetOwnVRRig().transform.position,
                            UnityEngine.Random.rotation,
                            4f,
                            100f,
                            true,
                            false
                        });
                    flushmanually();
                }
            }
        }

        public static void POPANDUNPOP()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    GorillaBattleManager gorillaBattleManager = GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>();
                    int fun = (int)new System.Random().Next(0, 3);
                    gorillaBattleManager.playerLives[player.ActorNumber] = fun;
                }
            }
        }



        public static void LagGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                PhotonView view = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>());
                Photon.Realtime.Player owner = view.Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }

                    if (lockedrig != null)
                    {
                        view = RigShit.GetViewFromRig(lockedrig);
                    }
                    if (lockedrig != null)
                    {
                        view = RigShit.GetViewFromRig(lockedrig);
                    }
                    if (view != null || owner != null)
                    {
                        view.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        view.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        PhotonNetwork.Destroy(view);
                        PhotonNetwork.Destroy(view.gameObject);
                    }
                }
                else
                {
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                    lockedrig = null;
                }
            }
            else
            {
                Object.Destroy(pointer);
            }
        }

        public static void BREAKAUDIOALL()
        {
            if (balll2111 < Time.time)
            {
                balll2111 = Time.time + 0.01f;
                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.Others, new object[]
                {
                                94,
                                true,
                                float.MaxValue
                });
                flushmanually();
            }
        }

        public static void BREAKAUDIOGUN()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (owner != null)
                    {
                        if (balll2111 < Time.time)
                        {
                            balll2111 = Time.time + 0.01f;
                            GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", owner, new object[]
                            {
                                94,
                                true,
                                float.MaxValue
                            });
                            flushmanually();
                        }
                    }
                }
                else
                {
                    lockedrig = null;
                    pointer.GetComponent<Renderer>().material.color = Color.white;
                }
            }
            else
            {
                Object.Destroy(pointer);
            }
        }

        static bool gunLock;
        public static void GunLock()
        {
            gunLock = true;
        }

        static int flySpeed = 17;

        public static int rattatuoie = 0;

        public static void ChangeLayout()
        {
            System.IO.Directory.CreateDirectory("GoldPrefs");
            rattatuoie++;
            if (rattatuoie == 0)
            {
                //normal
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
            }
            if (rattatuoie == 1)
            {
                //side
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Side";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "side");
            }
            if (rattatuoie == 2)
            {
                //crsh
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Triggers";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "triggers");
            }
            if (rattatuoie == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Bottom";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "bottom");
            }
            if (rattatuoie == 4)
            {
                //back to normal
                rattatuoie = 0;
                WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
                File.WriteAllText("GoldPrefs\\goldlayout.txt", "shibagt");
            }
            WristMenu.settingsbuttons[4].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static int fucking = 0;
        public static int fucking1 = 0;
        public static Color firstcolor = Color.black;

        public static void Change1Theme(bool loading)
        {
            if (!loading)
            {
                fucking1++;
            }
            if (fucking1 == 0)
            {
                //normal
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Black";
                firstcolor = Color.black;
            }
            if (fucking1 == 1)
            {
                //side
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Blue";
                firstcolor = Color.blue;
            }
            if (fucking1 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Green";
                firstcolor = Color.green;
            }
            if (fucking1 == 3)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: White";
                firstcolor = Color.white;
            }
            if (fucking1 == 4)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Magenta";
                firstcolor = Color.magenta;
            }
            if (fucking1 == 5)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Cyan";
                firstcolor = Color.cyan;
            }
            if (fucking1 == 6)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Gray";
                firstcolor = Color.gray;
            }
            if (fucking1 == 7)
            {
                //crsh
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Red";
                firstcolor = Color.red;
            }
            if (fucking1 == 8)
            {
                //back to normal
                fucking1 = 0;
                WristMenu.settingsbuttons[30].buttonText = "Menu Theme First Color: Black";
                firstcolor = Color.black;
            }
            WristMenu.settingsbuttons[30].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void changeguntype(bool loading)
        {
            if (!loading)
            {
                guntype++;
            }
            if (guntype == 0)
            {
                WristMenu.settingsbuttons[27].buttonText = "Gun Type: Normal";
            }
            if (guntype == 1)
            {
                WristMenu.settingsbuttons[27].buttonText = "Gun Type: Line";
            }
            if (guntype == 2)
            {
                WristMenu.settingsbuttons[27].buttonText = "Gun Type: Normal";
                guntype = 0;
            }
            WristMenu.settingsbuttons[27].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void changeprojcolor(bool loading)
        {
            if (!loading)
            {
                colorproj++;
            }
            if (colorproj == 0)
            {
                //normal
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Black";
                projcolor = Color.black;
            }
            if (colorproj == 1)
            {
                //side
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Blue";
                projcolor = Color.blue;
            }
            if (colorproj == 2)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Green";
                projcolor = Color.green;
            }
            if (colorproj == 3)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: White";
                projcolor = Color.white;
            }
            if (colorproj == 4)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Magenta";
                projcolor = Color.magenta;
            }
            if (colorproj == 5)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Cyan";
                projcolor = Color.cyan;
            }
            if (colorproj == 6)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Gray";
                projcolor = Color.gray;
            }
            if (colorproj == 7)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Red";
                projcolor = Color.red;
            }
            if (colorproj == 8)
            {
                //crsh
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Yellow";
                projcolor = Color.yellow;
            }
            if (colorproj == 9)
            {
                //back to normal
                colorproj = 0;
                WristMenu.settingsbuttons[25].buttonText = "Projectile Mods Color: Black";
                projcolor = Color.black;
            }
            WristMenu.settingsbuttons[25].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int crashpower;

        public static void changecrashpower(bool loading)
        {
            if (!loading)
            {
                crashpower++;
            }
            if (crashpower == 11)
            {
                crashpower = 0;
            }
            if (crashpower == 0)
            {
                //normal
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 1";
            }
            if (crashpower == 1)
            {
                //side
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 2";
            }
            if (crashpower == 2)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 3";
            }
            if (crashpower == 3)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 4";
            }
            if (crashpower == 4)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 5";
            }
            if (crashpower == 5)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 6";
            }
            if (crashpower == 6)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 7";
            }
            if (crashpower == 7)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 8";
            }
            if (crashpower == 8)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 9";
            }
            if (crashpower == 9)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 10";
            }
            if (crashpower == 10)
            {
                //crsh
                WristMenu.settingsbuttons[28].buttonText = "Crash Power: 11";
            }
            WristMenu.settingsbuttons[28].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int fucking2;
        static Color projcolor = Color.black;
        static bool erihu = false;
        static int colorproj;
        static int guntype;
        static List<GameObject> leaves = new List<GameObject>();
        public static bool stickyplatforms = false;
        public static bool crashtp = true;
        public static bool cycle = false;
        public static bool fpcc = false;

        public static void sticky()
        {
            stickyplatforms = true;
        }

        public static void offsticky()
        {
            stickyplatforms = false;
        }

        public static void makecycle()
        {
            cycle = true;
        }

        public static void disablecycle()
        {
            cycle = false;
        }

        static bool bothhands = false;

        public static void bothhanded()
        {
            bothhands = true;
        }

        public static void offbothhanded()
        {
            bothhands = false;
        }

        static GameObject funn;

        public static void fpc()
        {
            fpcc = true;
            if (GameObject.Find("Third Person Camera") != null)
            {
                funn = GameObject.Find("Third Person Camera");
                funn.SetActive(false);
            }
            if (GameObject.Find("CameraTablet(Clone)") != null)
            {
                funn = GameObject.Find("CameraTablet(Clone)");
                funn.SetActive(false);
            }
        }

        public static void fpcoff()
        {
            fpcc = false;
            if (funn != null)
            {
                funn.SetActive(true);
                funn = null;
            }
        }

        public static void notpcrash()
        {
            crashtp = false;
        }

        public static void notnotprcrahs()
        {
            crashtp = true;
        }

        public static void offleaves()
        {
            if (!erihu)
            {
                erihu = true;
                foreach (GameObject g in Resources.FindObjectsOfTypeAll<GameObject>())
                {
                    if (g.activeSelf && g.name.Contains("smallleaves"))
                    {
                        g.SetActive(false);
                        leaves.Add(g);
                    }
                }
            }
        }

        public static void offoffleaves()
        {
            if (erihu)
            {
                erihu = false;
                foreach (GameObject l in leaves)
                {
                    l.SetActive(true);
                }
                leaves.Clear();
            }
        }

        public static BetterDayNightManager.WeatherType ww;
        public static void ChangeTime(bool loading)
        {
            if (!loading)
            {
                fucking2++;
            }
            if (fucking2 == 0)
            {
                //normal
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
            }
            if (fucking2 == 1)
            {
                //normal
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Day";
                BetterDayNightManager.instance.SetTimeOfDay(1);
            }
            if (fucking2 == 2)
            {
                //side
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Dawn";
                BetterDayNightManager.instance.SetTimeOfDay(6);
            }
            if (fucking2 == 3)
            {
                //crsh
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Night";
                BetterDayNightManager.instance.SetTimeOfDay(0);
            }
            if (fucking2 == 4)
            {
                //back to normal
                fucking2 = 0;
                WristMenu.settingsbuttons[11].buttonText = "Change Time Of Day: Untouched";
            }
            WristMenu.settingsbuttons[11].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int AntireportInt;

        public static void AntireportSettings(bool loading)
        {
            if (!loading)
            {
                AntireportInt++;
            }
            if (AntireportInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[6].buttonText = "Antireport: Leave";
            }
            if (AntireportInt == 1)
            {
                //normal
                WristMenu.settingsbuttons[6].buttonText = "Antireport: Serverhop";
            }
            if (AntireportInt == 2)
            {
                //back to normal
                AntireportInt = 0;
                WristMenu.settingsbuttons[6].buttonText = "Antireport: Leave";
            }
            WristMenu.settingsbuttons[6].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }


        public static Color purple
        {
            get
            {
                return new Color32(114, 0, 143, 255);
            }
        }



        public static Color secondcolor = purple;

        public static void Change2Theme(bool loading)
        {
            if (!loading)
            {
                fucking++;
            }
            if (fucking == 0)
            {
                //normal
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Purple";
                secondcolor = purple;
            }
            if (fucking == 1)
            {
                //side
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Blue";
                secondcolor = Color.blue;
            }
            if (fucking == 2)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Green";
                secondcolor = Color.green;
            }
            if (fucking == 3)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: White";
                secondcolor = Color.white;
            }
            if (fucking == 4)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Magenta";
                secondcolor = Color.magenta;
            }
            if (fucking == 5)
            {
                //Second
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Cyan";
                secondcolor = Color.cyan;
            }
            if (fucking == 6)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Black";
                secondcolor = Color.black;
            }
            if (fucking == 7)
            {
                //crsh
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Red";
                secondcolor = Color.red;
            }
            if (fucking == 8)
            {
                //back to normal
                fucking = 0;
                WristMenu.settingsbuttons[31].buttonText = "Menu Theme Second Color: Purple";
                secondcolor = purple;
            }
            WristMenu.settingsbuttons[31].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static int buttonColorInt;

        public static int textColorOnInt;

        public static int textColorOffInt;

        public static void ChangeButtonColor(bool loading)
        {
            if (!loading)
            {
                buttonColorInt++;
            }
            if (buttonColorInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Same As Menu";
                WristMenu.buttonColor = WristMenu.menuColor;
            }
            if (buttonColorInt == 1)
            {
                //side
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Blue";
                WristMenu.buttonColor = Color.blue;
            }
            if (buttonColorInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Green";
                WristMenu.buttonColor = Color.green;
            }
            if (buttonColorInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: White";
                WristMenu.buttonColor = Color.white;
            }
            if (buttonColorInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Magenta";
                WristMenu.buttonColor = Color.magenta;
            }
            if (buttonColorInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Cyan";
                WristMenu.buttonColor = Color.cyan;
            }
            if (buttonColorInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Gray";
                WristMenu.buttonColor = Color.gray;
            }
            if (buttonColorInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Red";
                WristMenu.buttonColor = Color.red;
            }
            if (buttonColorInt == 8)
            {
                //back to normal
                buttonColorInt = 0;
                WristMenu.settingsbuttons[32].buttonText = "Menu Theme Button Color: Same As Menu";
                WristMenu.buttonColor = WristMenu.menuColor;
            }
            WristMenu.settingsbuttons[32].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void ChangeOnTextColor(bool loading)
        {
            if (!loading)
            {
                textColorOnInt++;
            }
            if (textColorOnInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: White";
                WristMenu.menuOnTextColor = Color.white;
            }
            if (textColorOnInt == 1)
            {
                //side
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Blue";
                WristMenu.menuOnTextColor = Color.blue;
            }
            if (textColorOnInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Green";
                WristMenu.menuOnTextColor = Color.green;
            }
            if (textColorOnInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Purple";
                WristMenu.menuOnTextColor = purple;
            }
            if (textColorOnInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Magenta";
                WristMenu.menuOnTextColor = Color.magenta;
            }
            if (textColorOnInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Cyan";
                WristMenu.menuOnTextColor = Color.cyan;
            }
            if (textColorOnInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Gray";
                WristMenu.menuOnTextColor = Color.gray;
            }
            if (textColorOnInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: Red";
                WristMenu.menuOnTextColor = Color.red;
            }
            if (textColorOnInt == 8)
            {
                //back to normal
                textColorOnInt = 0;
                WristMenu.settingsbuttons[33].buttonText = "Menu Theme Text On Color: White";
                WristMenu.menuOnTextColor = Color.white;
            }
            WristMenu.settingsbuttons[33].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void ChangeOffTextColor(bool loading)
        {
            if (!loading)
            {
                textColorOffInt++;
            }
            if (textColorOffInt == 0)
            {
                //normal
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Magenta";
                WristMenu.menuOffTextColor = Color.magenta;
            }
            if (textColorOffInt == 1)
            {
                //side
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Blue";
                WristMenu.menuOffTextColor = Color.blue;
            }
            if (textColorOffInt == 2)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Green";
                WristMenu.menuOffTextColor = Color.green;
            }
            if (textColorOffInt == 3)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Purple";
                WristMenu.menuOffTextColor = purple;
            }
            if (textColorOffInt == 4)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: White";
                WristMenu.menuOffTextColor = Color.white;
            }
            if (textColorOffInt == 5)
            {
                //Second
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Cyan";
                WristMenu.menuOffTextColor = Color.cyan;
            }
            if (textColorOffInt == 6)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Gray";
                WristMenu.menuOffTextColor = Color.gray;
            }
            if (textColorOffInt == 7)
            {
                //crsh
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Red";
                WristMenu.menuOffTextColor = Color.red;
            }
            if (textColorOffInt == 8)
            {
                //back to normal
                textColorOffInt = 0;
                WristMenu.settingsbuttons[34].buttonText = "Menu Theme Text Off Color: Magenta";
                WristMenu.menuOffTextColor = Color.magenta;
            }
            WristMenu.settingsbuttons[34].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static int projectile = 0;
        public static int projectilehash = -820530352;

        public static int projectiletrail = 0;
        public static int projectiletrailhash = 1432124712;

        public static void ChangeProj(bool loading)
        {
            if (!loading)
            {
                projectile++;
            }
            if (projectile == 0)
            {
                //normal
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Slingshot";
                projectilehash = -820530352;
            }
            if (projectile == 1)
            {
                //side
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Deadshot";
                projectilehash = 693334698;
            }
            if (projectile == 2)
            {
                //crsh
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Cloud";
                projectilehash = 1511318966;
            }
            if (projectile == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Snowball";
                projectilehash = -675036877;
            }
            if (projectile == 4)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Cupid";
                projectilehash = 825718363;
            }
            if (projectile == 5)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Ice";
                projectilehash = -1671677000;
            }
            if (projectile == 6)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Elf";
                projectilehash = 1705139863;
            }
            if (projectile == 7)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Water Balloon";
                projectilehash = -1674517839;
            }
            if (projectile == 8)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Rock";
                projectilehash = -622368518;
            }
            if (projectile == 9)
            {
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Pepper";
                projectilehash = -1280105888;
            }
            if (projectile == 10)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Spider";
                projectilehash = -790645151;
            }
            if (projectile == 11)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Candy Cane";
                projectilehash = 2061412059;
            }
            if (projectile == 12)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Coal";
                projectilehash = -1433634409;
            }
            if (projectile == 13)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Roll Gift";
                projectilehash = -1433633837;
            }
            if (projectile == 14)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Round Gift";
                projectilehash = -160604350;
            }
            if (projectile == 15)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Square Gift";
                projectilehash = -666337545;
            }
            if (projectile == 16)
            {

                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Mentos";
                projectilehash = -716425086;
            }
            if (projectile == 17)
            {
                //back to normal
                projectile = 0;
                WristMenu.settingsbuttons[8].buttonText = "Projectile Mods Projectile: Slingshot";
                projectilehash = -820530352;
            }
            WristMenu.settingsbuttons[8].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static string HashToName(int hash)
        {
            if (hash == -820530352)
            {
                return "SlingshotProjectile";
            }
            if (hash == 693334698)
            {
                return "HornsSlingshotProjectile";
            }
            if (hash == 1511318966)
            {
                return "CloudSlingshot_Projectile";
            }
            if (hash == -675036877)
            {
                return "SnowballProjectile";
            }
            if (hash == 825718363)
            {
                return "CupidBow_Projectile";
            }
            if (hash == -1671677000)
            {
                return "IceSlingshot_Projectile";
            }
            if (hash == 1705139863)
            {
                return "ElfBow_Projectile";
            }
            if (hash == -1674517839)
            {
                return "WaterBalloonProjectile";
            }
            if (hash == -622368518)
            {
                return "LavaRockProjectile";
            }
            if (hash == -1280105888)
            {
                return "MoltenSlingshot_Projectile";
            }
            if (hash == -790645151)
            {
                return "SpiderBow_Projectile";
            }
            if (hash == 2061412059)
            {
                return "BucketGiftCane";
            }
            if (hash == -1433634409)
            {
                return "BucketGiftCoal";
            }
            if (hash == -1433633837)
            {
                return "BucketGiftRoll";
            }
            if (hash == -160604350)
            {
                return "BucketGiftRound";
            }
            if (hash == -666337545)
            {
                return "BucketGiftSquare";
            }
            if (hash == 488926162)
            {
                return "LavaSurfaceRock";
            }
            if (hash == -716425086)
            {
                return "ScienceCandyProjectile";
            }
            if (hash == -1405953129)
            {
                return "PaperAirplaneProjectile";
            }
            return "SlingshotProjectile";
        }

        public static string TrailHashToName(int hash)
        {
            if (hash == 1432124712)
            {
                return "SlingshotProjectileTrail";
            }
            if (hash == 163790326)
            {
                return "HornsSlingshotProjectileTrail";
            }
            if (hash == 16948542)
            {
                return "CloudSlingshot_ProjectileTrail";
            }
            if (hash == 1848916225)
            {
                return "CupidBow_ProjectileTrail";
            }
            if (hash == -1277271056)
            {
                return "IceSlingshot_ProjectileTrail";
            }
            if (hash == -67783235)
            {
                return "ElfBow_ProjectileTrail";
            }
            return "SlingshotProjectileTrail";
        }

        public static int projectilecycle1 = 0;
        public static int projectilehashc1 = -820530352;

        public static int projectilecycle2 = 0;
        public static int projectilehashc2 = -820530352;

        public static int projectilecycle3 = 0;
        public static int projectilehashc3 = -820530352;

        public static int projectilecycle4 = 0;
        public static int projectilehashc4 = -820530352;

        public static void cycle1(bool loading)
        {
            if (!loading)
            {
                projectilecycle1++;
            }
            if (projectilecycle1 == 0)
            {
                //normal
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Slingshot";
                projectilehashc1 = -820530352;
            }
            if (projectilecycle1 == 1)
            {
                //side
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Deadshot";
                projectilehashc1 = 693334698;
            }
            if (projectilecycle1 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Cloud";
                projectilehashc1 = 1511318966;
            }
            if (projectilecycle1 == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Snowball";
                projectilehashc1 = -675036877;
            }
            if (projectilecycle1 == 4)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Cupid";
                projectilehashc1 = 825718363;
            }
            if (projectilecycle1 == 5)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Ice";
                projectilehashc1 = -1671677000;
            }
            if (projectilecycle1 == 6)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Elf";
                projectilehashc1 = 1705139863;
            }
            if (projectilecycle1 == 7)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Water Balloon";
                projectilehashc1 = -1674517839;
            }
            if (projectilecycle1 == 8)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Rock";
                projectilehashc1 = -622368518;
            }
            if (projectilecycle1 == 9)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Pepper";
                projectilehashc1 = -1280105888;
            }
            if (projectilecycle1 == 10)
            {
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Spider";
                projectilehashc1 = -790645151;
            }
            if (projectilecycle1 == 11)
            {

                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Candy Cane";
                projectilehashc1 = 2061412059;
            }
            if (projectilecycle1 == 12)
            {

                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Coal";
                projectilehashc1 = -1433634409;
            }
            if (projectilecycle1 == 13)
            {

                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Roll Gift";
                projectilehashc1 = -1433633837;
            }
            if (projectilecycle1 == 14)
            {

                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Round Gift";
                projectilehashc1 = -160604350;
            }
            if (projectilecycle1 == 15)
            {

                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Square Gift";
                projectilehashc1 = -666337545;
            }
            if (projectilecycle1 == 16)
            {
                //back to normal
                projectilecycle1 = 0;
                WristMenu.settingsbuttons[21].buttonText = "Projectile Mods Cycle 1: Slingshot";
                projectilehashc1 = -820530352;
            }
            WristMenu.settingsbuttons[21].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void cycle2(bool loading)
        {
            if (!loading)
            {
                projectilecycle2++;
            }
            if (projectilecycle2 == 0)
            {
                //normal
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Slingshot";
                projectilehashc2 = -820530352;
            }
            if (projectilecycle2 == 1)
            {
                //side
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Deadshot";
                projectilehashc2 = 693334698;
            }
            if (projectilecycle2 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Cloud";
                projectilehashc2 = 1511318966;
            }
            if (projectilecycle2 == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Snowball";
                projectilehashc2 = -675036877;
            }
            if (projectilecycle2 == 4)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Cupid";
                projectilehashc2 = 825718363;
            }
            if (projectilecycle2 == 5)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Ice";
                projectilehashc2 = -1671677000;
            }
            if (projectilecycle2 == 6)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Elf";
                projectilehashc2 = 1705139863;
            }
            if (projectilecycle2 == 7)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Water Balloon";
                projectilehashc2 = -1674517839;
            }
            if (projectilecycle2 == 8)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Rock";
                projectilehashc2 = -622368518;
            }
            if (projectilecycle2 == 9)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Pepper";
                projectilehashc2 = -1280105888;
            }
            if (projectilecycle2 == 10)
            {
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Spider";
                projectilehashc2 = -790645151;
            }
            if (projectilecycle2 == 11)
            {

                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Candy Cane";
                projectilehashc2 = 2061412059;
            }
            if (projectilecycle2 == 12)
            {

                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Coal";
                projectilehashc2 = -1433634409;
            }
            if (projectilecycle2 == 13)
            {

                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Roll Gift";
                projectilehashc2 = -1433633837;
            }
            if (projectilecycle2 == 14)
            {

                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Round Gift";
                projectilehashc2 = -160604350;
            }
            if (projectilecycle2 == 15)
            {

                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Square Gift";
                projectilehashc2 = -666337545;
            }
            if (projectilecycle2 == 16)
            {
                //back to normal
                projectilecycle2 = 0;
                WristMenu.settingsbuttons[22].buttonText = "Projectile Mods Cycle 2: Slingshot";
                projectilehashc2 = -820530352;
            }
            WristMenu.settingsbuttons[22].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void cycle3(bool loading)
        {
            if (!loading)
            {
                projectilecycle3++;
            }
            if (projectilecycle3 == 0)
            {
                //normal
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Slingshot";
                projectilehashc3 = -820530352;
            }
            if (projectilecycle3 == 1)
            {
                //side
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Deadshot";
                projectilehashc3 = 693334698;
            }
            if (projectilecycle3 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Cloud";
                projectilehashc3 = 1511318966;
            }
            if (projectilecycle3 == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Snowball";
                projectilehashc3 = -675036877;
            }
            if (projectilecycle3 == 4)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Cupid";
                projectilehashc3 = 825718363;
            }
            if (projectilecycle3 == 5)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Ice";
                projectilehashc3 = -1671677000;
            }
            if (projectilecycle3 == 6)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Elf";
                projectilehashc3 = 1705139863;
            }
            if (projectilecycle3 == 7)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Water Balloon";
                projectilehashc3 = -1674517839;
            }
            if (projectilecycle3 == 8)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Rock";
                projectilehashc3 = -623368518;
            }
            if (projectilecycle3 == 9)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Pepper";
                projectilehashc3 = -1280105888;
            }
            if (projectilecycle3 == 10)
            {
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Spider";
                projectilehashc3 = -790645151;
            }
            if (projectilecycle3 == 11)
            {

                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Candy Cane";
                projectilehashc3 = 2061412059;
            }
            if (projectilecycle3 == 12)
            {

                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Coal";
                projectilehashc3 = -1433634409;
            }
            if (projectilecycle3 == 13)
            {

                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Roll Gift";
                projectilehashc3 = -1433633837;
            }
            if (projectilecycle3 == 14)
            {

                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Round Gift";
                projectilehashc3 = -160604350;
            }
            if (projectilecycle3 == 15)
            {

                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Square Gift";
                projectilehashc3 = -666337545;
            }
            if (projectilecycle3 == 16)
            {
                //back to normal
                projectilecycle3 = 0;
                WristMenu.settingsbuttons[23].buttonText = "Projectile Mods Cycle 3: Slingshot";
                projectilehashc3 = -820530352;
            }
            WristMenu.settingsbuttons[23].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void setmaster2()
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                ExecuteCloudScriptRequest executeCloudScriptRequest = new ExecuteCloudScriptRequest();
                executeCloudScriptRequest.FunctionName = "RoomClosed";
                executeCloudScriptRequest.FunctionParameter = new
                {
                    GameId = PhotonNetwork.CurrentRoom.Name,
                    Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper()
                };
                PlayFabClientAPI.ExecuteCloudScript(executeCloudScriptRequest, delegate (ExecuteCloudScriptResult result)
                {
                }, null, null, null);
                ExitGames.Client.Photon.Hashtable hashtablef = new ExitGames.Client.Photon.Hashtable();
                hashtablef.Add("gameMode", "forestcavescitycloudscanyonsbeachbasementCOMPETITIVECASUAL");
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtablef, null, null);
            }
        }

        public static void setamaster()
        {
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }

        public static bool NetworkTrigDisableBool;

        public static void setmaster()
        {
            if (PhotonNetwork.CurrentRoom != null && !PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("forestmountainscavescitycloudscanyonsbeachbasementCOMPETITIVEINFECTION"))
            {
                if (NetworkTrigDisableBool)
                {
                    string value = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, "forestmountainscavescitycloudscanyonsbeachbasementCOMPETITIVEINFECTION");
                    Hashtable propertiesToSet = new Hashtable
                                {
                                    {
                                        "gameMode",
                                        value
                                    }
                                };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(propertiesToSet, null, null);
                    NetworkTrigDisableBool = false;
                }
                Debug.Log("starting");
                PlayFabClientAPI.ExecuteCloudScript(new PlayFab.ClientModels.ExecuteCloudScriptRequest
                {
                    FunctionName = "RoomClosed",
                    FunctionParameter = new
                    {
                        GameId = PhotonNetwork.CurrentRoom.Name,
                        Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                        UserId = -1,
                        ActorNr = -1,
                        ActorCount = PhotonNetwork.ViewCount + 1,
                        AppVersion = PhotonNetwork.AppVersion
                    },
                }, result =>
                {
                    NetworkTrigDisableBool = true;
                }, null);
            }
            foreach (ButtonInfo b in WristMenu.buttons)
            {
                if (b.buttonText.Contains("Disable Network Triggers SS!"))
                {
                    b.enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static GameObject penis;

        public static bool TrapStumpBool;

        public static void penisohio()
        {
            if (PhotonNetwork.CurrentRoom != null && !PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("realCOMPETITIVEINFECTION"))
            {
                if (TrapStumpBool)
                {
                    string value = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, "realCOMPETITIVEINFECTION");
                    Hashtable propertiesToSet = new Hashtable
                                {
                                    {
                                        "gameMode",
                                        value
                                    }
                                };
                    PhotonNetwork.CurrentRoom.SetCustomProperties(propertiesToSet, null, null);
                    TrapStumpBool = false;
                }
                Debug.Log("starting");
                PlayFabClientAPI.ExecuteCloudScript(new PlayFab.ClientModels.ExecuteCloudScriptRequest
                {
                    FunctionName = "RoomClosed",
                    FunctionParameter = new
                    {
                        GameId = PhotonNetwork.CurrentRoom.Name,
                        Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                        UserId = -1,
                        ActorNr = -1,
                        ActorCount = PhotonNetwork.ViewCount + 1,
                        AppVersion = PhotonNetwork.AppVersion
                    },
                }, result =>
                {
                    TrapStumpBool = true;
                }, null);
                penis = GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab");
                penis.SetActive(false);
            }
            foreach (ButtonInfo b in WristMenu.buttons)
            {
                if (b.buttonText.Contains("Trap Stump"))
                {
                    b.enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        static bool fasttrainbool;
        static bool slowtrainbool;
        static bool freezetrainbool;

        public static void fasttrain()
        {
            fasttrainbool = true;
            GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
            PhotonView trainview = trainobj.GetComponent<PhotonView>();
            TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

            // script

            trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainmovement.duration = 4f;
        }
        public static void NoFinger()
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 0f;
            ControllerInputPoller.instance.rightControllerGripFloat = 0f;
            ControllerInputPoller.instance.leftControllerIndexFloat = 0f;
            ControllerInputPoller.instance.rightControllerIndexFloat = 0f;
            ControllerInputPoller.instance.leftControllerPrimaryButton = false;
            ControllerInputPoller.instance.leftControllerSecondaryButton = false;
            ControllerInputPoller.instance.rightControllerPrimaryButton = false;
            ControllerInputPoller.instance.rightControllerSecondaryButton = false;
        }

        public static void fasttrainoff()
        {
            if (fasttrainbool)
            {
                fasttrainbool = false;
                GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
                PhotonView trainview = trainobj.GetComponent<PhotonView>();
                TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

                // script

                trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainmovement.duration = 30f;
            }
        }

        public static void slowtrain()
        {
            slowtrainbool = true;
            GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
            PhotonView trainview = trainobj.GetComponent<PhotonView>();
            TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

            // script

            trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainmovement.duration = 120f;
        }

        public static void slowtrainoff()
        {
            if (slowtrainbool)
            {
                slowtrainbool = false;
                GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
                PhotonView trainview = trainobj.GetComponent<PhotonView>();
                TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

                // script

                trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainmovement.duration = 30f;
            }
        }

        public static void freezetrain()
        {
            freezetrainbool = true;
            GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
            PhotonView trainview = trainobj.GetComponent<PhotonView>();
            TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

            // script

            trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            trainmovement.duration = float.MaxValue - 100;
        }

        public static void freezetrainoff()
        {
            if (freezetrainbool)
            {
                freezetrainbool = false;
                GameObject trainobj = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Holiday2023Forest/Holiday2023Forest_Gameplay/NCTrain_Kit_Prefab/NCTrainEngine_Prefab");
                PhotonView trainview = trainobj.GetComponent<PhotonView>();
                TraverseSpline trainmovement = trainobj.GetComponent<TraverseSpline>();

                // script

                trainview.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainview.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                trainmovement.duration = 30f;
            }
        }

        public static void kickstump()
        {
            Hashtable hashtable4 = new Hashtable();
            hashtable4.Add("gameMode", null);
            PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable4, null, null);
        }

        public static void cycle4(bool loading)
        {
            if (!loading)
            {
                projectilecycle4++;
            }
            if (projectilecycle4 == 0)
            {
                //normal
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Slingshot";
                projectilehashc4 = -820530352;
            }
            if (projectilecycle4 == 1)
            {
                //side
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Deadshot";
                projectilehashc4 = 693334698;
            }
            if (projectilecycle4 == 2)
            {
                //crsh
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Cloud";
                projectilehashc4 = 1511318966;
            }
            if (projectilecycle4 == 3)
            {
                //back to normal
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Snowball";
                projectilehashc4 = -675036877;
            }
            if (projectilecycle4 == 4)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Cupid";
                projectilehashc4 = 825718363;
            }
            if (projectilecycle4 == 5)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Ice";
                projectilehashc4 = -1671677000;
            }
            if (projectilecycle4 == 6)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Elf";
                projectilehashc4 = 1705139863;
            }
            if (projectilecycle4 == 7)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Water Balloon";
                projectilehashc4 = -1674517839;
            }
            if (projectilecycle4 == 8)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Rock";
                projectilehashc4 = -624368518;
            }
            if (projectilecycle4 == 9)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Pepper";
                projectilehashc4 = -1280105888;
            }
            if (projectilecycle4 == 10)
            {
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Spider";
                projectilehashc4 = -790645151;
            }
            if (projectilecycle4 == 11)
            {

                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Candy Cane";
                projectilehashc4 = 2061412059;
            }
            if (projectilecycle4 == 12)
            {

                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Coal";
                projectilehashc4 = -1433634409;
            }
            if (projectilecycle4 == 13)
            {

                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Roll Gift";
                projectilehashc4 = -1433633837;
            }
            if (projectilecycle4 == 14)
            {

                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Round Gift";
                projectilehashc4 = -160604350;
            }
            if (projectilecycle4 == 15)
            {

                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Square Gift";
                projectilehashc4 = -666337545;
            }
            if (projectilecycle4 == 16)
            {
                //back to normal
                projectilecycle4 = 0;
                WristMenu.settingsbuttons[24].buttonText = "Projectile Mods Cycle 4: Slingshot";
                projectilehashc4 = -820530352;
            }
            WristMenu.settingsbuttons[24].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void offrainbow()
        {
            rainboww = false;
        }

        private static GradientColorKey[] ihate = new GradientColorKey[6];

        public static GameObject erm = null;

        public static void rainbow()
        {
            if (!rainboww)
            {
                Debug.Log("making funny 1");
                if (erm == null)
                {
                    erm = GameObject.CreatePrimitive(PrimitiveType.Cube);
                }
                ColorChanger ermm = erm.AddComponent<ColorChanger>();
                ihate[0].color = Color.yellow;
                ihate[0].time = 0f;
                ihate[1].color = Color.red;
                ihate[1].time = 0.2f;
                ihate[2].color = Color.magenta;
                ihate[2].time = 0.4f;
                ihate[3].color = Color.blue;
                ihate[3].time = 0.6f;
                ihate[4].color = Color.green;
                ihate[4].time = 0.8f;
                ihate[5].color = Color.yellow;
                ihate[5].time = 1f;
                ermm.colors = new Gradient
                {
                    colorKeys = ihate
                };
                Debug.Log("making funny 2");
                ermm.Start();
                Debug.Log("making funny 3");
                rainboww = true;
            }
        }
        public static bool rainboww = false;

        public static void ChangeTrail(bool loading)
        {
            if (!loading)
            {
                projectiletrail++;
            }
            if (projectiletrail == 0)
            {
                //normal
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Slingshot";
                projectiletrailhash = 1432124712;
            }
            if (projectiletrail == 1)
            {
                //side
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Deadshot";
                projectiletrailhash = 163790326;
            }
            if (projectiletrail == 2)
            {
                //crsh
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Cloud";
                projectiletrailhash = 16948542;
            }
            if (projectiletrail == 3)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Cupid";
                projectiletrailhash = 1848916225;
            }
            if (projectiletrail == 4)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Ice";
                projectiletrailhash = -1277271056;
            }
            if (projectiletrail == 5)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Elf";
                projectiletrailhash = -67783235;
            }
            if (projectiletrail == 6)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Pepper";
                projectiletrailhash = -748577108;
            }
            if (projectiletrail == 7)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Spider";
                projectiletrailhash = -1232128945;
            }
            if (projectiletrail == 8)
            {
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Nothing";
                projectiletrailhash = -1;
            }
            if (projectiletrail == 9)
            {
                projectiletrail = 0;
                WristMenu.settingsbuttons[9].buttonText = "Projectile Mods Trail: Slingshot";
                projectiletrailhash = 1432124712;
            }
            WristMenu.settingsbuttons[9].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static bool triggerplat = false;
        public static bool toggleplat = false;

        public static int platformstype = 0;

        public static void ChangePlatforms(bool loading)
        {
            if (!loading)
            {
                platformstype++;
            }
            if (platformstype == 0)
            {
                //normal
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
                invisplat = false;
            }
            if (platformstype == 1)
            {
                //side
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis";
                invisplat = true;
            }
            if (platformstype == 2)
            {
                //crsh
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Normal";
                triggerplat = true;
                invisplat = false;
            }
            if (platformstype == 3)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Trigger Invis";
                triggerplat = true;
                invisplat = true;
            }
            if (platformstype == 4)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal Trigger Toggle";
                invisplat = false;
                triggerplat = false;
                toggleplat = true;
            }
            if (platformstype == 5)
            {
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Invis Trigger Toggle";
                invisplat = true;
                triggerplat = false;
                toggleplat = true;
            }
            if (platformstype == 6)
            {
                platformstype = 0;
                WristMenu.settingsbuttons[14].buttonText = "Platforms Type: Normal";
                invisplat = false;
                triggerplat = false;
                toggleplat = false;
            }
            WristMenu.settingsbuttons[14].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int espcolor;

        public static void ChangeESP(bool loading)
        {
            if (!loading)
            {
                espcolor++;
            }
            if (espcolor == 0)
            {
                //normal
                WristMenu.settingsbuttons[16].buttonText = "ESP Color: Tagged";
            }
            if (espcolor == 1)
            {
                //side
                WristMenu.settingsbuttons[16].buttonText = "ESP Color: Color Code";
            }
            if (espcolor == 2)
            {
                //crsh
                espcolor = 0;
                WristMenu.settingsbuttons[16].buttonText = "ESP Color: Tagged";
            }
            WristMenu.settingsbuttons[16].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int tracerscolor;

        public static void ChangeTracersColor(bool loading)
        {
            if (!loading)
            {
                tracerscolor++;
            }
            if (tracerscolor == 0)
            {
                //normal
                WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Tagged";
            }
            if (tracerscolor == 1)
            {
                //side
                WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Color Code";
            }
            if (tracerscolor == 2)
            {
                //crsh
                tracerscolor = 0;
                WristMenu.settingsbuttons[17].buttonText = "Tracers Color: Tagged";
            }
            WristMenu.settingsbuttons[17].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int tracerspos;

        public static void ChangeTracersPos(bool loading)
        {
            if (!loading)
            {
                tracerspos++;
            }
            if (tracerspos == 0)
            {
                //normal
                WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Right Hand";
            }
            if (tracerspos == 1)
            {
                //side
                WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Left Hand";
            }
            if (tracerspos == 2)
            {
                //crsh
                WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Head";
            }
            if (tracerspos == 3)
            {
                //crsh
                WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Body";
            }
            if (tracerspos == 4)
            {
                //crsh
                tracerspos = 0;
                WristMenu.settingsbuttons[18].buttonText = "Tracers Position: Right Hand";
            }
            WristMenu.settingsbuttons[18].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static int speed;

        public static void ChangeSpeed(bool loading)
        {
            if (!loading)
            {
                speed++;
            }
            if (speed == 0)
            {
                //normal
                WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Mosa";
            }
            if (speed == 1)
            {
                //side
                WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Super";
            }
            if (speed == 2)
            {
                //crsh
                WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Fucking Insane";
            }
            if (speed == 3)
            {
                //crsh
                speed = 0;
                WristMenu.settingsbuttons[19].buttonText = "Speed Boost: Mosa";
            }
            WristMenu.settingsbuttons[19].enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        static string flybutton = "rsec";

        public static void UNGodModLock()
        {
            gunLock = false;
        }

        public static bool notifs = true;

        public static void OnNotifs()
        {
            notifs = true;
        }

        public static void OffNotifs()
        {
            notifs = false;
        }



        public static void Save()
        {
            Mods.GetButtonSettings("Save Preferences").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
            List<String> list = new List<String>();
            foreach (ButtonInfo info in WristMenu.settingsbuttons)
            {
                if (info.enabled == true)
                {
                    list.Add(info.buttonText);
                }
            }
            System.IO.Directory.CreateDirectory("GoldPrefs");
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedSpeed.txt", speed.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedProj.txt", projectile.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTrail.txt", projectiletrail.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedFirstColor.txt", fucking1.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedSecondColor.txt", fucking.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTextOnColor.txt", textColorOnInt.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTextOffColor.txt", textColorOffInt.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedButtonColor.txt", buttonColorInt.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTime.txt", fucking2.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedPlatforms.txt", platformstype.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedEsp.txt", espcolor.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTracersC.txt", tracerscolor.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedTracersP.txt", tracerspos.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedCycle1.txt", projectilecycle1.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedCycle2.txt", projectilecycle2.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedCycle3.txt", projectilecycle3.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedCycle4.txt", projectilecycle4.ToString());
            System.IO.File.WriteAllText("GoldPrefs\\goldSavedProjColor.txt", colorproj.ToString());
            File.WriteAllText("GoldPrefs\\goldSavedCrashPower.txt", crashpower.ToString());
            System.IO.File.WriteAllLines("GoldPrefs\\goldSavedPrefs.txt", list);
        }

        public static void SaveOnButtons()
        {
            Mods.GetButton("Save Enabled Buttons").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
            List<String> list = new List<String>();
            foreach (ButtonInfo info in WristMenu.buttons)
            {
                if (info.enabled == true)
                {
                    list.Add(info.buttonText);
                }
            }
            System.IO.Directory.CreateDirectory("GoldPrefs");
            System.IO.File.WriteAllLines("GoldPrefs\\goldSavedButtonsPref.txt", list);
        }

        public static void LoadOnButtons()
        {
            String[] thing = System.IO.File.ReadAllLines("GoldPrefs\\goldSavedButtonsPref.txt");
            foreach (String thing2 in thing)
            {
                GetButton(thing2).enabled = true;
            }
        }


        public static void Load()
        {
            String[] thing = System.IO.File.ReadAllLines("GoldPrefs\\goldSavedPrefs.txt");
            foreach (String thing2 in thing)
            {
                GetButtonSettings(thing2).enabled = true;
            }
            CheckSettings();
        }

        public static void CheckSettings()
        {
            if (File.Exists("GoldPrefs\\goldlayout.txt"))
            {
                if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "shibagt")
                {
                    Mods.rattatuoie = 0;
                    WristMenu.settingsbuttons[4].buttonText = "Menu Layout: ShibaGT";
                }
                else if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "side")
                {
                    Mods.rattatuoie = 1;
                    WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Side";
                }
                else if (File.ReadAllText("GoldPrefs\\goldlayout.txt") == "triggers")
                {
                    Mods.rattatuoie = 2;
                    WristMenu.settingsbuttons[4].buttonText = "Menu Layout: Triggers";
                }
            }
            foreach (ButtonInfo s in WristMenu.settingsbuttons)
            {
                if (s.enabled == true)
                {
                    s.method.Invoke();
                }
                if (s.enabled == false && s.disableMethod != null)
                {
                    s.disableMethod.Invoke();
                }
            }
            if (File.Exists("GoldPrefs\\goldSavedFirstColor.txt"))
            {
                fucking1 = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedFirstColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedSecondColor.txt"))
            {
                fucking = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedSecondColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedTextOnColor.txt"))
            {
                textColorOnInt = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedTextOnColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedTextOffColor.txt"))
            {
                textColorOffInt = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedTextOffColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedButtonColor.txt"))
            {
                buttonColorInt = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedButtonColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedTime.txt"))
            {
                fucking2 = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedTime.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedPlatforms.txt"))
            {
                platformstype = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedPlatforms.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedEsp.txt"))
            {
                espcolor = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedEsp.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedTracersC.txt"))
            {
                tracerscolor = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedTracersC.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedTracersP.txt"))
            {
                tracerspos = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedTracersP.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedSpeed.txt"))
            {
                speed = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedSpeed.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedProjColor.txt"))
            {
                colorproj = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedProjColor.txt"));
            }
            if (File.Exists("GoldPrefs\\goldSavedCrashPower.txt"))
            {
                crashpower = Convert.ToInt16(System.IO.File.ReadAllText("GoldPrefs\\goldSavedCrashPower.txt"));
            }
            Change1Theme(true);
            Change2Theme(true);
            ChangeButtonColor(true);
            ChangeOnTextColor(true);
            ChangeOffTextColor(true);
            ChangeTime(true);
            ChangeESP(true);
            ChangeTracersColor(true);
            ChangeTracersPos(true);
            changecrashpower(true);
        }

        public static void TAGSPAM()
        {
            if (Time.time > balll2111 + 0.08f)
            {
                balll2111 = Time.time;
                PhotonView.Get(GorillaGameManager.instance).RPC("ReportContactWithLavaRPC", RpcTarget.MasterClient, Array.Empty<object>());
            }
        }

        static float fillAmount;
        public static VRRig lockedrig;
        static GorillaRopeSwing lockdedrope;

        public static void KickDeps(Photon.Realtime.Player p)
        {
            Vector3 d = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, -2, 0);
            Vector3 vector = new Vector3(0f, 0f, 0f);
            GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", p, new object[]
            {
                            d,
                            vector,
                            -1674517839,
                            163790326,
                            false,
                            1,
                            false,
                            0f,
                            0f,
                            0f,
                            1f,
            });
        }

        public static void RpcPatcher(VRRig rig)
        {
            PhotonView myVRRig = GorillaTagger.Instance.myVRRig;
            CleanActorAndRPCBuffers(myVRRig);
        }

        public static void CleanActorAndRPCBuffers(PhotonView photonView)
        {
            int actorNumber = photonView.Owner.ActorNumber;
            PhotonNetwork.OpCleanActorRpcBuffer(actorNumber);
            PhotonNetwork.OpCleanRpcBuffer(photonView);
        }

        public static Vector3[] lastLeft = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };

        public static Vector3[] lastRight = new Vector3[] { Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero };

        public static void Collidecosmetics()
        {
            foreach (TransferrableObject holdableObject in UnityEngine.Object.FindObjectsOfType<TransferrableObject>())
            {
                if (!holdableObject.gameObject.GetComponent<MeshCollider>())
                {
                    holdableObject.gameObject.AddComponent<MeshCollider>();
                }
            }
        }

        public static Vector3 baseGravity;
        public static RaycastHit hit;
        public static bool yes;

        public static void offwallwalk()
        {
            yes = false;
        }

        public static void WallWalk()
        {
            if (!yes)
            {
                yes = true;
                baseGravity = UnityEngine.Physics.gravity;
            }
            if (WristMenu.gripDownR)
            {
                GorillaLocomotion.Player player = GorillaLocomotion.Player.Instance;
                if (player.wasLeftHandTouching || player.wasRightHandTouching)
                {
                    FieldInfo fieldInfo = typeof(GorillaLocomotion.Player).GetField("lastHitInfoHand", BindingFlags.NonPublic | BindingFlags.Instance);
                    hit = (RaycastHit)fieldInfo.GetValue(player);
                    UnityEngine.Physics.gravity = hit.normal * -baseGravity.magnitude * .25f;
                }
                else
                {
                    if (Vector3.Distance(player.bodyCollider.transform.position, hit.point) > 2 * GorillaLocomotion.Player.Instance.scale)
                        UnityEngine.Physics.gravity = baseGravity * .25f;
                }
            }
            else
            {
                UnityEngine.Physics.gravity = baseGravity;
            }
        }

        public static void PunchMod()
        {
            int index = -1;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    index++;

                    Vector3 they = vrrig.rightHandTransform.position;
                    Vector3 notthem = GorillaTagger.Instance.offlineVRRig.head.rigTarget.position;
                    float distance = Vector3.Distance(they, notthem);

                    if (distance < 0.25)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - lastRight[index]) * 10;
                    }
                    lastRight[index] = vrrig.rightHandTransform.position;

                    they = vrrig.leftHandTransform.position;
                    distance = Vector3.Distance(they, notthem);

                    if (distance < 0.25)
                    {
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity += Vector3.Normalize(vrrig.rightHandTransform.position - lastLeft[index]) * 10;
                    }
                    lastLeft[index] = vrrig.leftHandTransform.position;
                }
            }
        }

        public static void RaiseRpcEventse(Player p)
        {
            int eventContent = p.ActorNumber;
            int[] target = new int[1]
                {
                p.ActorNumber
                };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                TargetActors = target
            };
            //RigShit.GetViewFromPlayer(beesPlayer).ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            //RigShit.GetViewFromPlayer(beesPlayer).OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
            PhotonNetwork.NetworkingClient.OpRaiseEvent(207, eventContent, raiseEventOptions, SendOptions.SendReliable);
        }

        public static void CallRaiseEventMethod(Player p)
        {
            Hashtable hashtable = new Hashtable();
            hashtable[(byte)0] = p.ActorNumber;
            PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendReliable);
            NewFlusher();
        }

        public static void CallRaiseEventMethodMain()
        {
                Hashtable hashtable = new Hashtable();
                hashtable[(byte)0] = -1;
                PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendReliable);
                NewFlusher();
            
        }

        public static UnityEngine.Color color;
        public static float hue = 0f;
        public static float timer = 0f;
        public static float updateRate = 0f;
        public static float updateTimer = 0f;
        public static bool RandomColor = false;
        public static float CycleSpeed = 0.07f;
        public static float GlowAmount = 1f;

        public static void banall()
        {
            if (GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId))
            {
                if (Time.time > balll2111 + 0.12f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    updateTimer += Time.deltaTime;

                    if (RandomColor)
                    {
                        if ((double)Time.time > (double)timer)
                        {
                            color = UnityEngine.Random.ColorHSV(0f, 1f, GlowAmount, GlowAmount, GlowAmount, GlowAmount);
                            timer = Time.time + CycleSpeed;
                        }
                    }
                    else
                    {
                        if ((double)hue >= 1.0)
                        {
                            hue = 0f;
                        }
                        hue += CycleSpeed;
                        color = UnityEngine.Color.HSVToRGB(hue, 1f * GlowAmount, 1f * GlowAmount);
                    }

                    if ((double)updateTimer > (double)updateRate)
                    {
                        updateTimer = 999f;
                        GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
                        GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.Others, new object[]
                        {
                   color.r,
                   color.g,
                   color.b,
                   false
                        });
                        RpcPatcher(GorillaTagger.Instance.offlineVRRig);
                        flushmanually();
                    }
                }
            }
        }

        public static void aaaaaA()
        {
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }

        public static void aaaaaA2()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }

        public static bool BreakServBool;

        public static void anticosmetics()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=red>[GAMEMODE CHANGER]</color> Turn off antiban first!");
                return;
            }
            Debug.Log("starting");
            ExecuteCloudScriptRequest executeCloudScriptRequest = new ExecuteCloudScriptRequest();
            executeCloudScriptRequest.FunctionName = "RoomClosed";
            executeCloudScriptRequest.FunctionParameter = new
            {
                GameId = PhotonNetwork.CurrentRoom.Name,
                Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                UserId = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length + 1)].UserId,
                ActorNr = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length + 1)],
                ActorCount = PhotonNetwork.ViewCount,
                AppVersion = PhotonNetwork.AppVersion
            };
            PlayFabClientAPI.ExecuteCloudScript(executeCloudScriptRequest, delegate (ExecuteCloudScriptResult result)
            {
            }, result =>
            {
                BreakServBool = true;
            }, null);
        }

        public static void giveallmods()
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                ExitGames.Client.Photon.Hashtable s = new ExitGames.Client.Photon.Hashtable();
                s.Add("mods", "NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, NUKED BY SHIBAGT GOLD LOLLLL, ");
                p.SetCustomProperties(s, null, null);
            }
            GetButton("Nuke Modcheckers").enabled = false;
            WristMenu.DestroyMenu();
            WristMenu.instance.Draw();
        }

        public static void antiban2()
        {
            if (PlayFabClientAPI.IsClientLoggedIn())
            {
                PlayFabClientAPI.ForgetAllCredentials();
            }
        }


        public static bool jikoisBLACK;

        public static void SetMaster()
        {
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=red>[SET MASTER]</color> Enable Antiban first!");
            }
            else
            {
                PhotonNetwork.CurrentRoom.SetMasterClient(PhotonNetwork.LocalPlayer);
                NotifiLib.SendNotification("<color=red>[SET MASTER]</color> Set Master enabled!");
            }
        }

        public static bool AutoMasterBool;

        public static void AutoSetMaster()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                if (!AutoMasterBool)
                {
                    PhotonNetwork.CurrentRoom.SetMasterClient(PhotonNetwork.LocalPlayer);
                    NotifiLib.SendNotification("<color=red>[SET MASTER]</color> Set Master enabled!");
                    AutoMasterBool = true;
                }
            }
        }

        public static void offantiban()
        {
            if (jikoisBLACK)
            {
                jikoisBLACK = false;
                PhotonNetwork.Disconnect();
                NotifiLib.SendNotification("<color=red>[ANTIBAN]</color> Disconnected you due to used antiban in the server before, this is to evade bans!");
                AntibanNotifBool = false;
            }
        }

        public static void CrashAura()
        {
            if (Time.time > CrashFloat + 0.3f)
            {
                CrashFloat = Time.time;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, RigShit.GetRigFromPlayer(player).transform.position) < 4)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        CallRaiseEventMethod(player);
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void Crash2Aura()
        {
            if (Time.time > CrashFloat2 + 0.2f)
            {
                CrashFloat2 = Time.time;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, RigShit.GetRigFromPlayer(player).transform.position) < 4)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            PhotonNetwork.SendRate = 1;
                            CallRaiseEventMethod(player);
                            Debug.unityLogger.logEnabled = false;
                        }
                    };
                }
            }
        }

        static float crashstuff3;

        public static void EpicAura()
        {
            if (Time.time > crashstuff3 + 0.1f)
            {
                crashstuff3 = Time.time;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, RigShit.GetRigFromPlayer(player).transform.position) < 4)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        for (int i = 0; i < 50; i++)
                        {
                            object[] array = new object[] { 1f, 1f, 1f };
                            GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", player, array);
                        }
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
        }

        public static void ballsaura()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.15f;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, RigShit.GetRigFromPlayer(player).transform.position) < 4)
                    {
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                        {
                            NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                            return;
                        }
                        testingballs3(RigShit.GetRigFromPlayer(player));
                    }
                }
            }
        }

        public static void bubbleaura()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.15f;
                if (!PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master!");
                    return;
                }
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    if (Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, RigShit.GetRigFromPlayer(player).transform.position) < 4)
                    {
                        var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                        generator.photonView.RPC("SpawnSodaBubbleRPC", player, new object[]
                        {
                            new Vector2(0, 0),
                            9999999999999999999999999999999999f,
                            9999999f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                        });
                        flushmanually();
                    }
                }
            }
        }

        public static bool sigma;

        public static void GrabBug()
        {
            if (WristMenu.gripDownL)
            {
                var Bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
                Bug.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
            }
        }

        public static bool BarkFlyBool;
        public static float GravitySwitcherDelay;
        public static int SwitcherInt;

        public static void GravitySwitcher()
        {
            //1 nothing cuz its normal
            if (SwitcherInt == 2)
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (19.62f / Time.deltaTime)), ForceMode.Acceleration);
            if (SwitcherInt == 3)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.left * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (SwitcherInt == 4)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.right * (Time.deltaTime * (14.81f / Time.deltaTime)), ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }

            if (WristMenu.gripDownL && Time.time > GravitySwitcherDelay + 0.5f)
            {
                GravitySwitcherDelay = Time.time;
                SwitcherInt++;
                if (SwitcherInt == 1)
                    NotifiLib.SendNotification("Set Gravity To: Normal");
                if (SwitcherInt == 2)
                    NotifiLib.SendNotification("Set Gravity To: Up");
                if (SwitcherInt == 3)
                    NotifiLib.SendNotification("Set Gravity To: Left");
                if (SwitcherInt == 4)
                    NotifiLib.SendNotification("Set Gravity To: Right");
                if (SwitcherInt == 5)
                {
                    SwitcherInt = 1;
                    NotifiLib.SendNotification("Set Gravity To: Normal");
                }
            }
            if (WristMenu.gripDownR && Time.time > GravitySwitcherDelay + 0.5f)
            {
                GravitySwitcherDelay = Time.time;
                SwitcherInt--;
                if (SwitcherInt == 0)
                    SwitcherInt = 4;
                if (SwitcherInt == 1)
                    NotifiLib.SendNotification("Set Gravity To: Normal");
                if (SwitcherInt == 2)
                    NotifiLib.SendNotification("Set Gravity To: Up");
                if (SwitcherInt == 3)
                    NotifiLib.SendNotification("Set Gravity To: Left");
                if (SwitcherInt == 4)
                    NotifiLib.SendNotification("Set Gravity To: Right");
                if (SwitcherInt == 5)
                {
                    SwitcherInt = 1;
                    NotifiLib.SendNotification("Set Gravity To: Normal");
                }
            }
        }

        public static float GravityWindDelay;
        public static int WindInt;

        public static void GravityWind()
        {
            if (WindInt == 2)
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (19.62f / Time.deltaTime)), ForceMode.Acceleration);
            if (WindInt == 3)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.left * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }
            if (WindInt == 4)
            {
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.right * (Time.deltaTime * (14.81f / Time.deltaTime)), ForceMode.Acceleration);
                GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
            }

            if (Time.time > GravityWindDelay + 4f)
            {
                GravityWindDelay = Time.time;
                int RandomInt = Random.Range(1, 5);
                WindInt = RandomInt;
                if (SwitcherInt == 1)
                    NotifiLib.SendNotification("Set Gravity To: Normal");
                if (SwitcherInt == 2)
                    NotifiLib.SendNotification("Set Gravity To: Up");
                if (SwitcherInt == 3)
                    NotifiLib.SendNotification("Set Gravity To: Left");
                if (SwitcherInt == 4)
                    NotifiLib.SendNotification("Set Gravity To: Right");
            }
        }

        public static void ReverseGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (19.62f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void LowGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void NoGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.up * (Time.deltaTime * (9.81f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void HighGravity()
        {
            GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.AddForce(Vector3.down * (Time.deltaTime * (6.66f / Time.deltaTime)), ForceMode.Acceleration);
        }

        public static void BarkFly()
        {
            GetButton("No Gravity").enabled = true;

            var rb = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
            Vector2 xz = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;
            float y = SteamVR_Actions.gorillaTag_RightJoystick2DAxis.axis.y;

            Vector3 inputDirection = new Vector3(xz.x, y, xz.y);
            var playerForward = GorillaLocomotion.Player.Instance.bodyCollider.transform.forward;
            playerForward.y = 0;
            var playerRight = GorillaLocomotion.Player.Instance.bodyCollider.transform.right;
            playerRight.y = 0;

            var velocity = inputDirection.x * playerRight + y * Vector3.up + inputDirection.z * playerForward;
            velocity *= GorillaLocomotion.Player.Instance.scale * flySpeed;
            rb.velocity = Vector3.Lerp(rb.velocity, velocity, 0.12875f);
            BarkFlyBool = true;
        }

        public static void OffBarkFly()
        {
            if (BarkFlyBool)
            {
                GetButton("No Gravity").enabled = false;
                BarkFlyBool = false;
            }
        }

        public static float AntibanJoinDelay;
        public static bool AntibanBool;
        public static bool AntibanNotifBool;
        public static float AntibanDelay;
        public static bool AntibanDoneBool;

        public static void BoxEsp()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig)
                {
                    UnityEngine.Color thecolor = vrrig.playerColor;
                    if (espcolor == 0)
                    {
                        if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("INFECT"))
                        {
                            thecolor = vrrig.mainSkin.material.color;
                        }
                    }
                    thecolor.a = 0.8f;
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = vrrig.transform.position;
                    UnityEngine.Object.Destroy(box.GetComponent<BoxCollider>());
                    box.transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                    box.transform.LookAt(GorillaTagger.Instance.headCollider.transform.position);
                    box.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");
                    box.GetComponent<Renderer>().material.color = thecolor;
                    UnityEngine.Object.Destroy(box, Time.deltaTime);
                }
            }
        }

        public static void AntibanStatus()
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") && !PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=green>[ANTIBAN STATUS]</color> Antiban is enabled, but not set master.");
                return;
            }
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") && PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=green>[ANTIBAN STATUS]</color> Antiban is enabled, and you're master!");
                return;
            }
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=green>[ANTIBAN STATUS]</color> Antiban is NOT enabled.");
                return;
            }
            if (PhotonNetwork.IsMasterClient)
            {
                NotifiLib.SendNotification("<color=green>[ANTIBAN STATUS]</color> Antiban is NOT enabled, but you're master!");
            }
        }

        public static void Antiban()
        {
            if (!jikoisBLACK || Time.time < AntibanDelay + 0.6f)
            {
                if (PhotonNetwork.InRoom)
                {
                    if (Time.time > AntibanJoinDelay + 7f)
                    {
                        Debug.Log("join delay checked");
                        if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || Time.time < AntibanDelay + 0.7f)
                        {
                            if (AntibanDoneBool)
                            {
                                string value = PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Replace(GorillaComputer.instance.currentQueue, GorillaComputer.instance.currentQueue + "MODDEDMODDED");
                                Hashtable propertiesToSet = new Hashtable
                                {
                                    {
                                        "gameMode",
                                        value
                                    }
                                };
                                PhotonNetwork.CurrentRoom.SetCustomProperties(propertiesToSet, null, null);
                                if (!AntibanNotifBool)
                                {
                                    NotifiLib.SendNotification("<color=red>[ANTIBAN]</color> Turned on antiban!");
                                    AntibanNotifBool = true;
                                }
                            }
                            List<Player> list = (from player in PhotonNetwork.PlayerListOthers
                                                 where player != PhotonNetwork.LocalPlayer && !player.IsMasterClient
                                                 select player).ToList<Player>();
                            Player player2 = list[UnityEngine.Random.Range(0, list.Count)]; // random player thats not us 
                            ExecuteCloudScriptRequest executeCloudScriptRequest = new ExecuteCloudScriptRequest();
                            executeCloudScriptRequest.FunctionName = "RoomClosed";
                            executeCloudScriptRequest.FunctionParameter = new
                            {
                                GameId = PhotonNetwork.CurrentRoom.Name,
                                Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                                UserId = player2.UserId,
                                ActorNr = player2,
                                ActorCount = PhotonNetwork.ViewCount,
                                AppVersion = PhotonNetwork.AppVersion
                            };
                            PlayFabClientAPI.ExecuteCloudScript(executeCloudScriptRequest, delegate (ExecuteCloudScriptResult result)
                            {
                            }, result =>
                            {
                                AntibanDoneBool = true;
                            }, null);
                            if (!AntibanBool)
                            {
                                AntibanDelay = Time.time + 1f;
                                AntibanBool = true;
                            }
                            Debug.Log("finished.");
                            ohiosigma = false;
                            jikoisBLACK = true;
                        }
                    }
                    else
                    {
                        if (!ohiosigma)
                        {
                            NotifiLib.SendNotification("<color=red>[ANTIBAN]</color> Please wait 7 seconds before joining and using antiban.");
                            ohiosigma = true;
                            return;
                        }
                        return;
                    }
                }
                else
                {
                    AntibanBool = false;
                    AntibanNotifBool = false;
                    AntibanJoinDelay = Time.time;
                    jikoisBLACK = false;
                }
            }
        }

        public static bool ohiosigma;

        public static void RaiseRpcEvents(Player p)
        {
            int eventContent = p.ActorNumber;
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others
            };
            //PhotonNetwork.NetworkingClient.OpRaiseEvent(207, hashtable, null, SendOptions.SendUnreliable);
            PhotonNetwork.NetworkingClient.OpRaiseEvent(207, eventContent, raiseEventOptions, SendOptions.SendReliable);
        }

        public static float monkeys;

        private static readonly RaiseEventOptions ServerCleanOptions = new RaiseEventOptions
        {
            CachingOption = EventCaching.RemoveFromRoomCache
        };

        private static readonly Hashtable removeFilter = new Hashtable();

        private static readonly Hashtable ServerCleanDestroyEvent = new Hashtable();

        public static void throwup()
        {
            if (WristMenu.triggerDownL)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    Vector3 shootingDirection = GorillaLocomotion.Player.Instance.headCollider.transform.forward * 3; //getting direction
                    Vector3 fun = shootingDirection.normalized * 500; //setting speed
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.transform.position, fun, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
            }
        }

        public static float gridSize = 2f; // Adjust the size of each grid cell
        public static int gridCount = 3; // Number of grid cells in one direction
        static GameObject funynwall;


        public static List<Vector3> wallpositions = new List<Vector3>();
        public static int wallposint = 1;

        private static Vector3 targetPosition;
        private static int currentGrid = 0;

        public static void wallproj()
        {
            if (WristMenu.gripDownL && WristMenu.gripDownR)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }


                    Vector3 spawnPosition = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.forward * 1f;
                    Quaternion spawnRotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;

                    funynwall = new GameObject();
                    funynwall.transform.position = spawnPosition;
                    funynwall.transform.rotation = spawnRotation; // Set the rotation

                    Vector3 one = spawnPosition + spawnRotation * new Vector3(-0.5f, 0.7f, 1f);
                    Vector3 two = spawnPosition + spawnRotation * new Vector3(0f, 0.7f, 1f);
                    Vector3 three = spawnPosition + spawnRotation * new Vector3(0.5f, 0.7f, 1f);
                    Vector3 four = spawnPosition + spawnRotation * new Vector3(-0.5f, 0.4f, 1f);
                    Vector3 five = spawnPosition + spawnRotation * new Vector3(0f, 0.4f, 1f);
                    Vector3 six = spawnPosition + spawnRotation * new Vector3(0.5f, 0.4f, 1f);
                    Vector3 seven = spawnPosition + spawnRotation * new Vector3(-0.5f, 0.1f, 1f);
                    Vector3 eight = spawnPosition + spawnRotation * new Vector3(0f, 0.1f, 1f);
                    Vector3 nine = spawnPosition + spawnRotation * new Vector3(0.5f, 0.1f, 1f);

                    List<Vector3> wallpositions = new List<Vector3> { one, two, three, four, five, six, seven, eight, nine };

                    Vector3 usepos = Vector3.zero; // Initialize usepos

                    // Determine usepos based on wallposint
                    if (wallposint >= 1 && wallposint <= 9)
                    {
                        usepos = wallpositions[wallposint - 1];
                    }
                    else if (wallposint == 10)
                    {
                        usepos = wallpositions[0];
                        wallposint = 1;
                    }

                    wallposint++;

                    SendProjectile(ohio, usepos, Vector3.zero, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                    flushmanually();
                    wallpositions.Clear();
                }
            }
        }

        public static int fuckyoucsharp = 0;

        public static void projspam()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (WristMenu.gripDownR)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0), color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                }
                if (WristMenu.gripDownL && bothhands)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0), color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                }
            }
        }

        public static void leafspm()
        {
            if (Time.time > balll2111 + 0.01f && PhotonNetwork.InRoom)
            {
                if (WristMenu.gripDownR)
                {
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[] //making ss proj
                    {
                            GorillaTagger.Instance.offlineVRRig.rightHandTransform.position,
                            GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0),
                            1096146323,
                            projectiletrailhash,
                            false,
                            1,
                            true,
                            color.r,
                            color.g,
                            color.b,
                            color.a,
                    });
                    
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
                if (WristMenu.gripDownL && bothhands)
                {
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        /*int rand = (int)UnityEngine.Random.Range(0, 6);
                        if (rand == 0)
                        {
                            color = Color.red;
                        }
                        if (rand == 1)
                        {
                            color = Color.yellow;
                        }
                        if (rand == 2)
                        {
                            color = Color.black;
                        }
                        if (rand == 3)
                        {
                            color = Color.white;
                        }
                        if (rand == 4)
                        {
                            color = Color.magenta;
                        }
                        if (rand == 5)
                        {
                            color = Color.green;
                        }*/
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[] //making ss proj
                    {
                            GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
                            GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0),
                            1096146323,
                            projectiletrailhash,
                            false,
                            1,
                            true,
                            color.r,
                            color.g,
                            color.b,
                            color.a,
                    });
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
            }
            balll2111 = Time.time;
        }

        public static void spazprojspam()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (WristMenu.gripDownR)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    Vector3 charvel = new Vector3(UnityEngine.Random.Range(-33, 33), UnityEngine.Random.Range(-33, 33), UnityEngine.Random.Range(-33, 33));
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, charvel, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
                if (WristMenu.gripDownL && bothhands)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    Vector3 charvel = new Vector3(UnityEngine.Random.Range(-33, 33), UnityEngine.Random.Range(-33, 33), UnityEngine.Random.Range(-33, 33));
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, charvel, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
            }
        }

        public static void firework()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (WristMenu.gripDownR)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    Vector3 charvel = new Vector3(UnityEngine.Random.Range(-77, 77), UnityEngine.Random.Range(-77, 77), UnityEngine.Random.Range(-77, 77));
                    SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, 3, 0), charvel, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                }
            }
        }

        private static List<VRRig> validRigs = new List<VRRig>();

        public static List<VRRig> GetValidChoosableRigs()
        {
            validRigs.Clear();
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (!vrrig.isOfflineVRRig)
                {
                    if ((PhotonNetwork.InRoom || vrrig.isOfflineVRRig) && !(vrrig == null))
                    {
                        validRigs.Add(vrrig);
                    }
                }
            }
            return validRigs;
        }

        public static float Distance2D(Vector3 a, Vector3 b)
        {
            Vector2 a2 = new Vector2(a.x, a.z);
            Vector2 b2 = new Vector2(b.x, b.z);
            return Vector2.Distance(a2, b2);
        }

        private static RaycastHit[] rayResults = new RaycastHit[1];

        private static LayerMask layerMask;

        public static bool PlayerNear(VRRig rig, float dist, out float playerDist, Vector3 rigpos)
        {
            layerMask = (UnityLayer.Default.ToLayerMask() | UnityLayer.GorillaObject.ToLayerMask());
            if (rig == null)
            {
                playerDist = float.PositiveInfinity;
                return false;
            }
            playerDist = Distance2D(rig.transform.position, rigpos);
            return playerDist < dist && Physics.RaycastNonAlloc(new Ray(rigpos, rig.transform.position - rigpos), rayResults, playerDist, layerMask) <= 0;
        }

        public static bool ClosestPlayer(in Vector3 myPos, out VRRig outRig)
        {
            float num = float.MaxValue;
            outRig = null;
            foreach (VRRig vrrig in GetValidChoosableRigs())
            {
                float num2 = 0f;
                if (PlayerNear(vrrig, 15, out num2, myPos) && num2 < num)
                {
                    num = num2;
                    outRig = vrrig;
                }
            }
            return num != float.MaxValue;
        }

        public static Quaternion t;

        public static void lookatclosestpookiebear()
        {
            VRRig closestRig = GorillaTagger.Instance.offlineVRRig;
            ClosestPlayer(GorillaTagger.Instance.offlineVRRig.transform.position, out closestRig);
            weuhfewh = true;
            GorillaTagger.Instance.offlineVRRig.headConstraint.LookAt(closestRig.transform.position + new Vector3(0, 0.4f, 0));
        }

        public static void offlook()
        {
            if (weuhfewh)
            {
                weuhfewh = false;
                GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = GorillaLocomotion.Player.Instance.headCollider.transform.rotation;
            }
        }

        public static GameObject rainbowcube;

        public static void projlauncher()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                if (WristMenu.gripDownR)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    Vector3 shootingDirection;
                    Vector3 fun = Vector3.zero;
                    Vector3 posleft = Vector3.zero;
                        posleft = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                        shootingDirection = GorillaTagger.Instance.offlineVRRig.rightHandTransform.up; //getting direction
                        fun = shootingDirection.normalized * 7; //setting speed
                    SendProjectile(ohio, posleft, fun, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                }
                if (WristMenu.gripDownL && bothhands)
                {
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    Vector3 shootingDirection;
                    Vector3 fun = Vector3.zero;
                    Vector3 posleft = Vector3.zero;
                        posleft = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                        shootingDirection = GorillaTagger.Instance.offlineVRRig.leftHandTransform.up; //getting direction
                        fun = shootingDirection.normalized * 7; //setting speed
                    SendProjectile(ohio, posleft, fun, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                }
                balll2111 = Time.time;
            }
        }

        public static float orbitSpeed = 8f;
        private static float angle;


        public static void projhalo()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.triggerDownL)
            {
                balll2111 = Time.time;
                var ohio = HashToName(projectilehash);
                int hash = 1;
                if (cycle)
                {
                    fuckyoucsharp++;
                    if (fuckyoucsharp == 0)
                    {
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                    if (fuckyoucsharp == 1)
                    {
                        hash = projectilehashc2;
                        ohio = HashToName(projectilehashc2);
                    }
                    if (fuckyoucsharp == 2)
                    {
                        hash = projectilehashc3;
                        ohio = HashToName(projectilehashc3);
                    }
                    if (fuckyoucsharp == 3)
                    {
                        hash = projectilehashc4;
                        ohio = HashToName(projectilehashc4);
                    }
                    if (fuckyoucsharp == 4)
                    {
                        fuckyoucsharp = 0;
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                }
                else
                {
                    hash = projectilehash;
                    ohio = HashToName(projectilehash);
                }
                Color color = projcolor;
                if (rainboww)
                {
                    erm.transform.position = new Vector3(9999, 9999, 9999);
                    color = erm.GetComponent<ColorChanger>().color;
                }
                angle += orbitSpeed * Time.deltaTime;
                float x = GorillaTagger.Instance.offlineVRRig.transform.position.x + 0.7f * Mathf.Cos(angle);
                float y = GorillaTagger.Instance.offlineVRRig.transform.position.y + 1.5f;
                float z = GorillaTagger.Instance.offlineVRRig.transform.position.z + 0.7f * Mathf.Sin(angle);
                Vector3 funny = new Vector3(x, y, z);
                SendProjectile(ohio, funny, Vector3.zero, color);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void Dick()
        {
            var player = GorillaTagger.Instance.offlineVRRig;
            var BugHoldable = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            var BugObj = GameObject.Find("Floating Bug Holdable");
                Vector3 secondObjectPosition = GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0, 0.3f, 0) + player.transform.forward * 0.15f;
                BugObj.transform.rotation = player.transform.rotation;
                BugObj.transform.position = secondObjectPosition;
        }

        public static void BugHalo()
        {
            angle += orbitSpeed * Time.deltaTime;
            float x = RigShit.GetOwnVRRig().headConstraint.transform.position.x + 0.5f * Mathf.Cos(angle);
            float y = RigShit.GetOwnVRRig().headConstraint.transform.position.y + 0.5f;
            float z = RigShit.GetOwnVRRig().headConstraint.transform.position.z + 0.5f * Mathf.Sin(angle);
            GameObject.Find("Floating Bug Holdable").transform.position = new Vector3(x, y, z);
        }

        public static bool GamemodeChangerBool;

        public static void ChangeGamemode(string gamemoded)
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
            {
                NotifiLib.SendNotification("<color=red>[GAMEMODE CHANGER]</color> Turn off antiban first!");
                return;
            }
            if (GamemodeChangerBool)
            {
                Hashtable hashtable = new Hashtable();
                hashtable.Add("gameMode", GorillaComputer.instance.groupMapJoin + GorillaComputer.instance.currentQueue + gamemoded);
                PhotonNetwork.CurrentRoom.SetCustomProperties(hashtable, null, null);
                GamemodeChangerBool = false;
            }
            Debug.Log("starting");
            PlayFabClientAPI.ExecuteCloudScript(new PlayFab.ClientModels.ExecuteCloudScriptRequest
            {
                FunctionName = "RoomClosed",
                FunctionParameter = new
                {
                    GameId = PhotonNetwork.CurrentRoom.Name,
                    Region = Regex.Replace(PhotonNetwork.CloudRegion, "[^a-zA-Z0-9]", "").ToUpper(),
                    UserId = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length + 1)].UserId,
                    ActorNr = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, PhotonNetwork.PlayerList.Length + 1)],
                    ActorCount = PhotonNetwork.ViewCount,
                    AppVersion = PhotonNetwork.AppVersion
                },
            }, result =>
            {
                GamemodeChangerBool = true;
            }, null);
        }

        public static void firewrokproj()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownL)
            {
                balll2111 = Time.time;
                var ohio = HashToName(projectilehash);
                int hash = 1;
                if (cycle)
                {
                    fuckyoucsharp++;
                    if (fuckyoucsharp == 0)
                    {
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                    if (fuckyoucsharp == 1)
                    {
                        hash = projectilehashc2;
                        ohio = HashToName(projectilehashc2);
                    }
                    if (fuckyoucsharp == 2)
                    {
                        hash = projectilehashc3;
                        ohio = HashToName(projectilehashc3);
                    }
                    if (fuckyoucsharp == 3)
                    {
                        hash = projectilehashc4;
                        ohio = HashToName(projectilehashc4);
                    }
                    if (fuckyoucsharp == 4)
                    {
                        fuckyoucsharp = 0;
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                }
                else
                {
                    hash = projectilehash;
                    ohio = HashToName(projectilehash);
                }
                Color color = projcolor;
                if (rainboww)
                {
                    erm.transform.position = new Vector3(9999, 9999, 9999);
                    color = erm.GetComponent<ColorChanger>().color;
                }
                float minSpeed = 10f;
                float maxSpeed = 18f;
                float upwardForce = 2f; // Adjust the strength of the upward force
                // Generate a random direction vector
                Vector3 randomDirection = UnityEngine.Random.onUnitSphere;

                // Generate random speed
                float randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);

                // Add an upward force
                randomDirection.y += upwardForce;

                // Normalize the vector to maintain the direction and adjust the magnitude
                randomDirection.Normalize();
                Vector3 randomVelocity = randomDirection * randomSpeed;

                SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, 3, 0), randomVelocity, color);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void firewrokproj2()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownL)
            {
                balll2111 = Time.time;
                var ohio = HashToName(projectilehash);
                int hash = 1;
                if (cycle)
                {
                    fuckyoucsharp++;
                    if (fuckyoucsharp == 0)
                    {
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                    if (fuckyoucsharp == 1)
                    {
                        hash = projectilehashc2;
                        ohio = HashToName(projectilehashc2);
                    }
                    if (fuckyoucsharp == 2)
                    {
                        hash = projectilehashc3;
                        ohio = HashToName(projectilehashc3);
                    }
                    if (fuckyoucsharp == 3)
                    {
                        hash = projectilehashc4;
                        ohio = HashToName(projectilehashc4);
                    }
                    if (fuckyoucsharp == 4)
                    {
                        fuckyoucsharp = 0;
                        hash = projectilehashc1;
                        ohio = HashToName(projectilehashc1);
                    }
                }
                else
                {
                    hash = projectilehash;
                    ohio = HashToName(projectilehash);
                }
                Color color = projcolor;
                if (rainboww)
                {
                    erm.transform.position = new Vector3(9999, 9999, 9999);
                    color = erm.GetComponent<ColorChanger>().color;
                }
                float minSpeed = 2f;
                float maxSpeed = 10;
                float upwardForce = 4f; // Adjust the strength of the upward force
                // Generate a random direction vector
                Vector3 randomDirection = UnityEngine.Random.onUnitSphere;

                // Generate random speed
                float randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);

                // Add an upward force
                randomDirection.y += upwardForce;

                // Normalize the vector to maintain the direction and adjust the magnitude
                randomDirection.Normalize();
                Vector3 randomVelocity = randomDirection * randomSpeed;

                SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, 3, 0), randomVelocity, color);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void SlingshotFly()
        {
            if (WristMenu.gripDownR)
            {
                Rigidbody rigid = GorillaLocomotion.Player.Instance.gameObject.GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    rigid.AddForce(GorillaLocomotion.Player.Instance.headCollider.transform.forward * 20f, ForceMode.Acceleration);
                }
            }
        }

        public static void Frozone()
        {
            try
            {
                if (WristMenu.gripDownR)
                {
                    if (Time.time > balll2 + 0.05f)
                    {
                        balll2 = Time.time;
                        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        obj.transform.localScale = new Vector3(2, 0.1f, 1);
                        obj.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, -1, 0);
                        obj.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation;
                        GorillaSurfaceOverride surface = obj.AddComponent<GorillaSurfaceOverride>();
                        surface.overrideIndex = 61;
                        obj.GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
                if (WristMenu.gripDownL)
                {
                    foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType<GameObject>())
                    {
                        if (obj.name == "Cube")
                        {
                            Destroy(obj);
                        }

                    }
                }
            }
            catch (Exception ex) { }
        }

        public static Vector2 lerpthing;

        public static void BananaCar()
        {
            Vector2 rjoystick = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;
            lerpthing = Vector2.Lerp(lerpthing, rjoystick, 0.05f);

            Vector3 addition = GorillaTagger.Instance.bodyCollider.transform.forward * lerpthing.y + GorillaTagger.Instance.bodyCollider.transform.right * lerpthing.x;
            Physics.Raycast(GorillaTagger.Instance.bodyCollider.transform.position - new Vector3(0f, 0.2f, 0f), Vector3.down, out var Ray, 512);

            if (Ray.distance < 0.2f && (Mathf.Abs(lerpthing.x) > 0.05f || Mathf.Abs(lerpthing.y) > 0.05f))
            {
                GorillaTagger.Instance.bodyCollider.attachedRigidbody.velocity = addition * 10f;
            }
        }

        public static string[] ProjectileNames = new string[]
        {
            "SnowballProjectile",
            "WaterBalloon_Throwable",
            "LavaRockProjectile",
            "BucketGiftCane",
            "ScienceCandyProjectile",
        };

        public static void SendProjectile(string projName, Vector3 position, Vector3 velocity, Color color)
        {
            ControllerInputPoller.instance.leftControllerGripFloat = 1f;
            GameObject lhelp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(lhelp, 0.1f);
            lhelp.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            lhelp.GetComponent<Renderer>().material.color = color;
            lhelp.transform.position = GorillaTagger.Instance.leftHandTransform.position;
            lhelp.transform.rotation = GorillaTagger.Instance.leftHandTransform.rotation;
            int[] overrides = new int[]
            {
                32,
                204,
                231,
                240,
                249
            };
            lhelp.AddComponent<GorillaSurfaceOverride>().overrideIndex = overrides[Array.IndexOf(ProjectileNames, projName)];
            lhelp.GetComponent<Renderer>().enabled = false;
            try
            {
                Vector3 startpos = position;
                Vector3 charvel = velocity;

                Vector3 oldVel = GorillaTagger.Instance.GetComponent<Rigidbody>().velocity;
                string[] name2 = new string[]
                {
                        "LMACE.",
                        "LMAEX.",
                        "LMAGD.",
                        "LMAHQ.",
                        "LMAIE."
                };
                SnowballThrowable fart = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L/TransferrableItemLeftHand/" + ProjectileNames[System.Array.IndexOf(ProjectileNames, projName)] + "LeftAnchor").transform.Find(name2[System.Array.IndexOf(ProjectileNames, projName)]).GetComponent<SnowballThrowable>();
                Vector3 oldPos = fart.transform.position;
                fart.randomizeColor = true;
                fart.transform.position = startpos;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = charvel;
                GorillaTagger.Instance.offlineVRRig.SetThrowableProjectileColor(true, color);
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/EquipmentInteractor").GetComponent<EquipmentInteractor>().ReleaseLeftHand();
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = oldVel;
                fart.transform.position = oldPos;
                fart.randomizeColor = false;
            }
            catch { }
        }

        static Color pissColor = new Color(255f, 255f, 0f);
        static Color cumColor = new Color(255f, 255f, 255f);

        public static void pissspam()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownR)
            {
                balll2111 = Time.time;
                Vector3 shootingDirection = GorillaTagger.Instance.offlineVRRig.transform.forward; //getting direction
                Vector3 fun = shootingDirection.normalized * 10; //setting speed
                Color color = pissColor;
                SendProjectile("SlingshotProjectile", GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0, 0.3f, 0), fun, color);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void cumspam()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownR)
            {
                balll2111 = Time.time;
                Vector3 shootingDirection = GorillaTagger.Instance.offlineVRRig.transform.forward; //getting direction
                Vector3 fun = shootingDirection.normalized * 10; //setting speed
                SendProjectile("SlingshotProjectile", GorillaTagger.Instance.offlineVRRig.transform.position - new Vector3(0, 0.3f, 0), fun, cumColor);
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void poopspam()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom && WristMenu.gripDownR)
            {
                balll2111 = Time.time;
                Vector3 fun = Vector3.zero; //setting speed
                SendProjectile("SnowballThrowable", GorillaTagger.Instance.offlineVRRig.transform.position, fun, new Color32(73, 44, 0, 1));
                PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
            }
        }

        public static void particlearoundyou()
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized * Random.Range(0, 6);
            if (WristMenu.gripDownR)
            {
                SpawnImpact(GorillaTagger.Instance.offlineVRRig.transform.position + randomDirection, projcolor);
            }
        }

        public static GameObject obritthing;

        public static void particlemap()
        {
            Vector3 minPosition = Vector3.zero;
            Vector3 maxPosition = Vector3.zero;
            if (GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest").activeSelf)
            {
                minPosition = new Vector3(-81.1999f, 2.5157f, -86.2651f);
                maxPosition = new Vector3(-38.9959f, 31.9568f, -33.5882f);
            }
            if (GameObject.Find("Environment Objects/LocalObjects_Prefab/City").activeSelf)
            {
                minPosition = new Vector3(-27.3422f, 15.1089f, -108.7779f);
                maxPosition = new Vector3(-60.8962f, 30.1384f, -106.5273f);
            }



            Vector3 randomPosition = new Vector3(
                UnityEngine.Random.Range(minPosition.x, maxPosition.x),
                UnityEngine.Random.Range(minPosition.y, maxPosition.y),
                UnityEngine.Random.Range(minPosition.z, maxPosition.z)
            );

            if (WristMenu.gripDownR)
            {
                SpawnImpact(randomPosition, cumColor);
            }
        }

        public static void particleall()
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                foreach (VRRig rig in GorillaParent.instance.vrrigs)
                {
                    if (!rig.isOfflineVRRig)
                    {
                        if (WristMenu.triggerDownL)
                        {
                            SpawnImpactnOdELAY(rig.transform.position, rig.playerColor);
                        }
                    }
                }
                balll2111 = Time.time;
            }
        }

        public static void yaptap()
        {

        }

        public static void demonichands()
        {
            if (WristMenu.gripDownL)
            {
                SpawnImpact(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, Color.red);
            }
            if (WristMenu.gripDownR)
            {
                SpawnImpact(GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, Color.red);
            }
        }

        public float maxHorizontalDistance = 7f;

        public static Vector3 pookiebeargen()
        {
            float randomX = UnityEngine.Random.Range(-4, 4);
            float randomZ = UnityEngine.Random.Range(-4, 4);
            Vector3 newPosition = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(randomX, 3f, randomZ);
            newPosition.y = Mathf.Min(newPosition.y, GorillaTagger.Instance.offlineVRRig.transform.position.y + 3f);
            if ((GorillaTagger.Instance.offlineVRRig.transform.position - newPosition).magnitude < GorillaTagManager.instance.tagDistanceThreshold)
            {
                return newPosition;
            }
            else
            {
                return pookiebeargen();
            }
        }

        public static Vector3 rahhgen()
        {
            float randomX = UnityEngine.Random.Range(-3, 3);
            float randomZ = UnityEngine.Random.Range(-3, 3);
            Vector3 newPosition = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(randomX, 3f, randomZ);
            newPosition.y = Mathf.Min(newPosition.y, GorillaTagger.Instance.offlineVRRig.transform.position.y + 4f);
            if ((GorillaTagger.Instance.offlineVRRig.transform.position - newPosition).magnitude < GorillaTagManager.instance.tagDistanceThreshold)
            {
                return newPosition;
            }
            else
            {
                return pookiebeargen();
            }
        }

        static float crashstuff;

        public static void crashtest()
        {
            if (crashstuff < Time.time)
            {
                crashstuff = Time.time + 0.1f;
                for (int i = 0; i < 50; i++)
                {
                    object[] array = new object[] { 1f, 1f, 1f };
                    GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.Others, array);
                }
            }
        }

        public static void rainproj()
        {
            if (WristMenu.triggerDownL)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    Vector3 ee = pookiebeargen();
                    var ohio = HashToName(projectilehash);
                    int hash = 1;
                    if (cycle)
                    {
                        fuckyoucsharp++;
                        if (fuckyoucsharp == 0)
                        {
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                        if (fuckyoucsharp == 1)
                        {
                            hash = projectilehashc2;
                            ohio = HashToName(projectilehashc2);
                        }
                        if (fuckyoucsharp == 2)
                        {
                            hash = projectilehashc3;
                            ohio = HashToName(projectilehashc3);
                        }
                        if (fuckyoucsharp == 3)
                        {
                            hash = projectilehashc4;
                            ohio = HashToName(projectilehashc4);
                        }
                        if (fuckyoucsharp == 4)
                        {
                            fuckyoucsharp = 0;
                            hash = projectilehashc1;
                            ohio = HashToName(projectilehashc1);
                        }
                    }
                    else
                    {
                        hash = projectilehash;
                        ohio = HashToName(projectilehash);
                    }
                    Color color = projcolor;
                    if (rainboww)
                    {
                        erm.transform.position = new Vector3(9999, 9999, 9999);
                        color = erm.GetComponent<ColorChanger>().color;
                    }
                    SendProjectile(ohio, ee, Vector3.zero, color);
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                    flushmanually();
                }
            }
        }

        public static float balll12111;

        public static void rainprojmap()
        {
            if (WristMenu.triggerDownL)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    Vector3 minPosition = new Vector3(-78.1698f, 45.5251f, -83.1939f);
                    Vector3 maxPosition = new Vector3(-40.7027f, 42.2017f, -32.7972f);
                    Vector3 randomPosition = new Vector3(
                UnityEngine.Random.Range(minPosition.x, maxPosition.x),
                UnityEngine.Random.Range(minPosition.y, maxPosition.y),
                UnityEngine.Random.Range(minPosition.z, maxPosition.z)
            );
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = randomPosition;
                }
                if (Time.time > balll12111 + 0.00f && PhotonNetwork.InRoom)
                {
                    balll12111 = Time.time;
                    Vector3 ee = pookiebeargen();
                    GameObject gameObject = ObjectPools.instance.Instantiate(projectilehash); //making the cs projecitle
                    SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>(); //setting component
                    SlingshotProjectileTrail component2 = ObjectPools.instance.Instantiate(projectiletrailhash).GetComponent<SlingshotProjectileTrail>(); //making cs trail
                    SlingshotProjectile slingshotProjectile = null; //randoms tuff for fun idk
                    slingshotProjectile = gameObject.GetComponent<SlingshotProjectile>(); //setting this var
                    component2.AttachTrail(gameObject.gameObject, false, false); // attaching cs trail
                    Color color = Color.white;
                    if (rainboww)
                    {
                        int rand = (int)UnityEngine.Random.Range(0, 6);
                        if (rand == 0)
                        {
                            color = Color.red;
                        }
                        if (rand == 1)
                        {
                            color = Color.yellow;
                        }
                        if (rand == 2)
                        {
                            color = Color.black;
                        }
                        if (rand == 3)
                        {
                            color = Color.white;
                        }
                        if (rand == 4)
                        {
                            color = Color.magenta;
                        }
                        if (rand == 5)
                        {
                            color = Color.green;
                        }
                    }
                    GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[] //making ss proj
                    {
                            ee,
                            Vector3.zero,
                            projectilehash,
                            projectiletrailhash,
                            false,
                            1,
                            true,
                            color.r,
                            color.g,
                            color.b,
                            color.a,
                    });
                    Debug.Log("called rpc");
                    component.Launch(ee, Vector3.zero, PhotonNetwork.LocalPlayer, false, false, 0, 1, true, color); //launching cs projectile
                    PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                    RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                    flushmanually();
                }
            }
        }

        public static void SpawnImpact(Vector3 pos, Color color)
        {
            if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                object[] impactSendData = new object[6];
                impactSendData[0] = pos;
                impactSendData[1] = color.r;
                impactSendData[2] = color.g;
                impactSendData[3] = color.b;
                impactSendData[4] = color.a;
                impactSendData[5] = 1;
                byte b2 = 1;
                object obj = impactSendData;
                SendProjEvent(b2, obj, reoALL, soUnreliable);
                RpcPatcher(GorillaTagger.Instance.offlineVRRig);
                flushmanually();
            }
        }

        public static void SpawnImpactnOdELAY(Vector3 pos, Color color)
        {
            if (PhotonNetwork.InRoom)
            {
                object[] impactSendData = new object[6];
                impactSendData[0] = pos;
                impactSendData[1] = color.r;
                impactSendData[2] = color.g;
                impactSendData[3] = color.b;
                impactSendData[4] = color.a;
                impactSendData[5] = 1;
                byte b2 = 1;
                object obj = impactSendData;
                SendProjEvent(b2, obj, reoALL, soUnreliable);
                RpcPatcher(GorillaTagger.Instance.offlineVRRig);
                flushmanually();
            }
        }

        public static void SpawnImpact2(Vector3 pos, Color color)
        {
            if (Time.time > balll21111 + 0.1f && PhotonNetwork.InRoom)
            {
                balll21111 = Time.time;
                object[] impactSendData = new object[6];
                impactSendData[0] = pos;
                impactSendData[1] = color.r;
                impactSendData[2] = color.g;
                impactSendData[3] = color.b;
                impactSendData[4] = color.a;
                impactSendData[5] = 1;
                byte b2 = 1;
                object obj = impactSendData;
                SendProjEvent(b2, obj, reoALL, soUnreliable);
                RpcPatcher(GorillaTagger.Instance.offlineVRRig);
                flushmanually();
            }
        }

        public static void particlegun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        SpawnImpactnOdELAY(pointer.transform.position, Color.red);
                    }
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static bool fun = false;

        public static void waterballoonprojgun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        var ohio = HashToName(projectilehash);
                        int hash = 1;
                        if (cycle)
                        {
                            fuckyoucsharp++;
                            if (fuckyoucsharp == 0)
                            {
                                hash = projectilehashc1;
                                ohio = HashToName(projectilehashc1);
                            }
                            if (fuckyoucsharp == 1)
                            {
                                hash = projectilehashc2;
                                ohio = HashToName(projectilehashc2);
                            }
                            if (fuckyoucsharp == 2)
                            {
                                hash = projectilehashc3;
                                ohio = HashToName(projectilehashc3);
                            }
                            if (fuckyoucsharp == 3)
                            {
                                hash = projectilehashc4;
                                ohio = HashToName(projectilehashc4);
                            }
                            if (fuckyoucsharp == 4)
                            {
                                fuckyoucsharp = 0;
                                hash = projectilehashc1;
                                ohio = HashToName(projectilehashc1);
                            }
                        }
                        else
                        {
                            hash = projectilehash;
                            ohio = HashToName(projectilehash);
                        }
                        Color color = projcolor;
                        if (rainboww)
                        {
                            erm.transform.position = new Vector3(9999, 9999, 9999);
                            color = erm.GetComponent<ColorChanger>().color;
                        }
                        Vector3 funn = (raycastHit.point - GorillaTagger.Instance.offlineVRRig.rightHandTransform.position).normalized;
                        float penis = 55;
                        funn *= penis;
                        SendProjectile(ohio, GorillaTagger.Instance.offlineVRRig.rightHandTransform.position, funn, color);
                    }
                }
                else
                {
                    fun = false;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        private static readonly SendOptions soUnreliable = SendOptions.SendUnreliable;

        private static readonly RaiseEventOptions reoOthers = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.Others
        };

        private static readonly RaiseEventOptions reoALL = new RaiseEventOptions
        {
            Receivers = ReceiverGroup.All
        };


        public static void SendProjEvent(in byte code, in object evData, in RaiseEventOptions reo, in SendOptions so)
        {
            object[] sendEventData = new object[3];
            sendEventData[0] = PhotonNetwork.ServerTimestamp;
            sendEventData[1] = code;
            sendEventData[2] = evData;
            PhotonNetwork.RaiseEvent(3, sendEventData, reo, so);
        }

        static bool testgunvar;

        static List<GameObject> testgunvarList;

        public static void testfungun()
        {
            if (!testgunvar)
            {
                testgunvar = true;
                foreach (WorldShareableItem item in GameObject.FindObjectsOfType<WorldShareableItem>())
                {
                    if (item.gameObject.GetComponent<GorillaTagScripts.DecorativeItemReliableState>())
                    {
                        testgunvarList.Add(item.gameObject);
                    }
                }
            }
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > balll2111 + 0.01f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;


                        Vector3 funn = (raycastHit.point - GorillaTagger.Instance.offlineVRRig.rightHandTransform.position).normalized;
                        float penis = 55;
                        funn *= penis;


                        foreach (GameObject p in testgunvarList)
                        {
                            PhotonView a = p.GetComponent<PhotonView>();
                            a.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                            a.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                            p.transform.position = pointer.transform.position;
                        }
                    }
                }
                else
                {
                    fun = false;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
            }
        }

        public static GameObject pointer2;

        public static void waterballoonprojgun2()
        {
            if (WristMenu.gripDownL)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.leftControllerTransform.position - GorillaLocomotion.Player.Instance.leftControllerTransform.up, -GorillaLocomotion.Player.Instance.leftControllerTransform.up, out raycastHit) && pointer2 == null)
                    {
                        pointer2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer2.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer2.GetComponent<SphereCollider>());
                        pointer2.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer2.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownL)
                {
                    if (Time.time > balll2111 + 0.01f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        int hash = 1;
                        if (cycle)
                        {
                            fuckyoucsharp++;
                            if (fuckyoucsharp == 0)
                            {
                                hash = projectilehashc1;
                            }
                            if (fuckyoucsharp == 1)
                            {
                                hash = projectilehashc2;
                            }
                            if (fuckyoucsharp == 2)
                            {
                                hash = projectilehashc3;
                            }
                            if (fuckyoucsharp == 3)
                            {
                                hash = projectilehashc4;
                            }
                            if (fuckyoucsharp == 4)
                            {
                                fuckyoucsharp = 0;
                                hash = projectilehashc1;
                            }
                        }
                        else
                        {
                            hash = projectilehash;
                        }
                        GameObject gameObject = ObjectPools.instance.Instantiate(hash); //making the cs projecitle
                        SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>(); //setting component
                        if (projectiletrailhash != -1)
                        {
                            SlingshotProjectileTrail component2 = ObjectPools.instance.Instantiate(projectiletrailhash).GetComponent<SlingshotProjectileTrail>(); //making cs trail
                            component2.AttachTrail(gameObject.gameObject, false, false); // attaching cs trail
                        }
                        gameObject.gameObject.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position; //setting pos of cs proj
                        Color color = Color.white;
                        Vector3 funn = (raycastHit.point - GorillaTagger.Instance.offlineVRRig.leftHandTransform.position).normalized;
                        float penis = 55;
                        funn *= penis;
                        Color throwableProjectileColor = projcolor;
                        if (rainboww)
                        {
                            /*int rand = (int)UnityEngine.Random.Range(0, 6);
                            if (rand == 0)
                            {
                                color = Color.red;
                            }
                            if (rand == 1)
                            {
                                color = Color.yellow;
                            }
                            if (rand == 2)
                            {
                                color = Color.black;
                            }
                            if (rand == 3)
                            {
                                color = Color.white;
                            }
                            if (rand == 4)
                            {
                                color = Color.magenta;
                            }
                            if (rand == 5)
                            {
                                color = Color.green;
                            }*/
                            erm.transform.position = new Vector3(9999, 9999, 9999);
                            throwableProjectileColor = erm.GetComponent<ColorChanger>().color;
                        }
                        GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[]
            {
                            GorillaTagger.Instance.offlineVRRig.leftHandTransform.position,
                            funn,
                            hash,
                            projectiletrailhash,
                            false,
                            1,
                            true,
                            throwableProjectileColor.r,
                            throwableProjectileColor.g,
                            throwableProjectileColor.b,
                            throwableProjectileColor.a,
            });
                        component.Launch(GorillaTagger.Instance.offlineVRRig.leftHandTransform.position, funn, PhotonNetwork.LocalPlayer, false, false, 0, 1, true, throwableProjectileColor); //launching cs projectile
                        PhotonNetwork.SendAllOutgoingCommands();
                        RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                    }
                }
                else
                {
                    fun = false;
                }
            }
            else
            {
                GameObject.Destroy(pointer2);
            }
        }

        public static void KickDeps(RpcTarget p)
        {
            Vector3 d = GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, -3, 0);
            Vector3 vector = new Vector3(0f, 0f, 0f);
            GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[]
            {
                            d,
                            vector,
                            -1674517839,
                            163790326,
                            false,
                            1,
                            false,
                            0f,
                            0f,
                            0f,
                            1f
            });
        }

        static float MatFloat;

        public static void matSpamAll()
        {
            if (PhotonNetwork.IsMasterClient == false)
            {
                NotifiLib.SendNotification("<color=red>[MAT SPAM]</color> Become master!");
                GetButton("Mat Spam All").enabled = false;
                return;
            }
            if (Time.time > MatFloat + 0.1)
            {
                MatFloat = Time.time;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                {
                    GorillaTagManager gorillaTagManager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                    var ez = new System.Random().Next(0, 2);
                    if (ez == 1)
                    {
                        gorillaTagManager.currentInfected.Add(player);
                        gorillaTagManager.currentInfectedArray.AddItem(player.ActorNumber);
                        gorillaTagManager.currentInfected.Add(player);
                    }
                    else if (gorillaTagManager.currentInfected.Contains(player))
                    {
                        gorillaTagManager.currentInfected.Clear();
                    }
                    gorillaTagManager.ChangeCurrentIt(player);
                    gorillaTagManager.SetisCurrentlyTag(true);
                    gorillaTagManager.isCurrentlyTag = true;
                    gorillaTagManager.currentIt = player;
                    gorillaTagManager.currentInfectedArray.AddItem(player.ActorNumber);
                }
            }
        }

        public static void KickGunv3()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (Time.time > balll2 + 0.03f)
                    {
                        balll2 = Time.time;
                        if (crashtp)
                        {
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(0, 0, 0);
                        }
                        if (crashpower == 0)
                        {
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 1)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 2)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 3)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 4)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 5)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 6)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 7)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 8)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 9)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        if (crashpower == 10)
                        {
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                            Mods.KickDeps(owner);
                        }
                        PhotonNetwork.RemoveBufferedRPCs();
                        PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOutgoingCommands();
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void that()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (Time.time > balll2 + 0.03f)
                    {
                        balll2 = Time.time;
                        var ohio = new PhotonMessageInfo(owner, PhotonNetwork.ServerTimestamp, RigShit.GetViewFromPlayer(owner));
                        GorillaTagger.Instance.myVRRig.RPC("SetJoinTaggedTime", RpcTarget.Others, ohio);
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void killgunv1()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (Time.time > balll2 + 0.5f)
                    {
                        balll2 = Time.time;
                        if (!PhotonNetwork.IsMasterClient)
                        {
                            if (owner != null)
                            {
                                GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>().returnPhotonView.RPC("ReportSlingshotHit", RpcTarget.MasterClient, new object[]
                                {
                                    owner,
                                    raycastHit.collider.GetComponentInParent<VRRig>().transform.position,
                                    1
                                });
                                flushmanually();
                                PhotonNetwork.SendAllOutgoingCommands();
                            }
                        }
                        else
                        {
                            GorillaBattleManager gorillaBattleManager = GameObject.Find("Player Objects/GorillaParent/Gorilla Battle Manager(Clone)").GetComponent<GorillaBattleManager>();
                            if (gorillaBattleManager.playerLives[owner.ActorNumber] > 0)
                            {
                                gorillaBattleManager.playerLives[owner.ActorNumber] = gorillaBattleManager.playerLives[owner.ActorNumber] - 1;
                            }
                        }
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void objectsgun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                        PhotonNetwork.DestroyPlayerObjects(owner);
                        PhotonNetwork.SendAllOutgoingCommands();
                    
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void objectall()
        {
                foreach (Player p in PhotonNetwork.PlayerListOthers)
                {
                    PhotonNetwork.DestroyPlayerObjects(beesPlayer);
                    PhotonNetwork.SendAllOutgoingCommands();
                }
            
        }


        public static void particlearoundplayergun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    Vector3 randomDirection = Random.insideUnitSphere.normalized * Random.Range(0, 6);
                    if (WristMenu.gripDownR)
                    {
                        SpawnImpact(RigShit.GetRigFromPlayer(owner).transform.position + randomDirection, cumColor);
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void funnngun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
                    {
                        NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban!");
                        return;
                    }
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (WristMenu.triggerDownL && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        RaiseRpcEventse(owner);
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void bubblegun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (PhotonNetwork.IsMasterClient)
                    {
                        if (Time.time > balll2 + 1.2f)
                        {
                            balll2 = Time.time;
                            if (PhotonNetwork.InRoom)
                            {
                                var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                                generator.photonView.RPC("SpawnSodaBubbleRPC", owner, new object[]
                                {
                            new Vector2(0, 0),
                            9999999999999999999999999999999999f,
                            9999999f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                                });
                                flushmanually();
                            }
                        }
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master!");
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void ballgun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    testingballs2(RigShit.GetRigFromPlayer(owner));

                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void CrashGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (Time.time > CrashFloat + 0.2f)
                    {
                        CrashFloat = Time.time;
                        CallRaiseEventMethod(owner);
                        Debug.unityLogger.logEnabled = false;
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void Crash2Gun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (crashstuff < Time.time)
                    {
                        crashstuff = Time.time + 0.1f;
                        for (int i = 0; i < 35; i++)
                        {
                            PhotonNetwork.SendRate = 1;
                            CallRaiseEventMethod(owner);
                            Debug.unityLogger.logEnabled = false;
                        }
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }



        public static void EpicAll()
        {
            if (crashstuff < Time.time)
            {
                crashstuff = Time.time + 0.1f;
                for (int i = 0; i < 50; i++)
                {
                    object[] array = new object[] { 1f, 1f, 1f };
                    GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", RpcTarget.Others, array);
                }
            }
        }

        public static void Crash2All()
        {
            if (crashstuff < Time.time)
            {
                crashstuff = Time.time + 0.1f;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                for (int i = 0; i < 40; i++)
                {
                    PhotonNetwork.SendRate = 1;
                    CallRaiseEventMethodMain();
                    Debug.unityLogger.logEnabled = false;
                }
            }
        }

        public static void EpicGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    if (crashstuff2 < Time.time)
                    {
                        crashstuff2 = Time.time + 0.1f;
                        for (int i = 0; i < 50; i++)
                        {
                            object[] array = new object[] { 1f, 1f, 1f };
                            GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", owner, array);
                        }
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        static float crashstuff2;

        public static void DisableMouthMovement()
        {
            GorillaTagger.Instance.offlineVRRig.GetComponent<GorillaMouthFlap>().enabled = false;
        }

        public static void OFFDisableMouthMovement()
        {
            GorillaTagger.Instance.offlineVRRig.GetComponent<GorillaMouthFlap>().enabled = true;
        }

        public static void CrashAll()
        {
            if (Time.time > CrashFloat2 + 0.2f)
            {
                CrashFloat2 = Time.time;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban and use set master!");
                    return;
                }
                CallRaiseEventMethodMain();
                Debug.unityLogger.logEnabled = false;
            }
        }

        static float CrashFloat;
        static float CrashFloat2 = Time.time;
        static float Loop2 = Time.time;
        public static float timer2 = 0f;
        public static bool isFirstFunction = true;

        public static void StopMovementGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[STOP MOVEMENT]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner = null;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    timer2 += Time.deltaTime;

                    if (timer2 <= 1f)
                    {
                        if (isFirstFunction)
                        {
                            BeeGrabPlayer(owner);
                        }
                    }
                    else if (timer2 <= 0.2f)
                    {
                        if (!isFirstFunction)
                        {
                            BeeUnGrabPlayer();
                        }
                    }
                    else
                    {
                        isFirstFunction = !isFirstFunction;
                        timer2 = 0f;
                    }
                }
            }
            else
            {
                lockedrig = null;
            }
        }

        static float StopMovementDelay;

        public static void HoverPlayerGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[HOVER]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner = null;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    BeeGrabPlayer(owner);
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void HoverPlayerForeverGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[HOVER]</color> Turn on antiban and use set master!");
                    return;
                }
                Photon.Realtime.Player owner = null;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > timer3 + 3f)
                    {
                        BeeGrabPlayer(owner);
                    }
                    if (Time.time > timer3 + 3.2f)
                    {
                        BeeUnGrabPlayer();
                        timer3 = Time.time;
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static float timer3 = Time.time;

        public static VRRig hoverPlayerRig;

        public static void HoverPlayerLoop()
        {
            if (Time.time > balll2 + 2f)
            {
                balll2 = Time.time;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED") || !PhotonNetwork.IsMasterClient)
                {
                    NotifiLib.SendNotification("<color=red>[HOVER]</color> Turn on antiban and use set master!");
                    return;
                }
                hoverPlayerRig = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));
            }
            BeeGrabPlayer(RigShit.GetPlayerFromRig(hoverPlayerRig));
        }

        public static void NameChangeGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
                {
                    NotifiLib.SendNotification("<color=red>[NAME CHANGER]</color> Turn on antiban!");
                    return;
                }
                if (NameChangerString == null)
                {
                    if (SettingNameDelay < Time.time)
                    {
                        SettingNameDelay = Time.time + 5f;
                        NotifiLib.SendNotification("<color=blue>[NAME CHANGER]</color> Assign the thing to change their names to on the gui!");
                        return;
                    }
                }
                Photon.Realtime.Player owner = PhotonNetwork.PlayerList[5];
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (NameDelay < Time.time)
                    {
                        NameDelay = Time.time + 0.05f;
                        Hashtable hashtable = new Hashtable();
                        hashtable[byte.MaxValue] = NameChangerString;
                        Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
                        dictionary.Add(251, hashtable);
                        dictionary.Add(254, owner.ActorNumber);
                        dictionary.Add(250, true);
                        PhotonNetwork.CurrentRoom.LoadBalancingClient.LoadBalancingPeer.SendOperation(252, dictionary, SendOptions.SendUnreliable);
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void bubblesky()
        {
                if (Time.time > balll2 + 2f)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        balll2 = Time.time;
                        var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                        generator.photonView.RPC("SpawnSodaBubbleRPC", RpcTarget.Others, new object[]
                        {
                            new Vector2(0, 0),
                            999999999f,
                            3f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                        });
                        flushmanually();
                    }
                    else
                    {
                        NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master!");
                    }
                }
        }

        public static void bubbleepic()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                generator.photonView.RPC("SpawnSodaBubbleRPC", RpcTarget.Others, new object[]
                {
                            new Vector2(0, 0),
                            float.MaxValue,
                            9999999f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : ((double)Time.time)
                });
                flushmanually();
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master!");
            }
        }

        private struct BubbleData
        {
            // Token: 0x04002516 RID: 9494
            public Vector3 position;

            // Token: 0x04002517 RID: 9495
            public Vector3 direction;

            // Token: 0x04002518 RID: 9496
            public float spawnSize;

            // Token: 0x04002519 RID: 9497
            public float lifetime;

            // Token: 0x0400251A RID: 9498
            public double spawnTime;

            // Token: 0x0400251B RID: 9499
            public bool isTrail;

            // Token: 0x0400251C RID: 9500
            public SodaBubble bubble;
        }

        public static void spawnbubble()
        {
            //if (Time.time > balll2 + 1f)
            //{
            // balll2 = Time.time;
            if (PhotonNetwork.IsMasterClient)
            {
                if (WristMenu.triggerDownL)
                {
                    Debug.Log("start");
                    var generator = GameObject.Find("Environment Objects/PersistentObjects_Prefab/ScienceExperimentManager").GetComponent<ScienceExperimentPlatformGenerator>();
                    generator.photonView.RPC("SpawnSodaBubbleRPC", RpcTarget.Others, new object[]
                    {
                            new Vector2(0, 0),
                            3f,
                            55555f,
                            PhotonNetwork.InRoom ? PhotonNetwork.Time : Time.unscaledTimeAsDouble
                    });
                    flushmanually();
                }
            }
            else
            {
                NotifiLib.SendNotification("<color=red>[CRASH]</color> Become master!");
            }
            //}
        }

        public static void InstantCrashPCVR()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                }
                pointer.transform.position = raycastHit.point;
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > balll2 + 0.02f)
                    {
                        balll2 = Time.time;
                        string nickName = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + savedName;
                        PhotonNetwork.LocalPlayer.NickName = nickName;
                        PhotonNetwork.NickName = nickName;
                        PhotonNetwork.NetworkingClient.NickName = nickName;
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        Mods.KickDeps(owner);
                        PhotonNetwork.SendAllOutgoingCommands();
                        string nickName2 = savedName;
                        PhotonNetwork.LocalPlayer.NickName = nickName2;
                        PhotonNetwork.NickName = nickName2;
                        PhotonNetwork.NetworkingClient.NickName = nickName2;
                    }
                }
            }
        }

        public static void KickOnLucyTouch()
        {
            if (GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().currentState == HalloweenGhostChaser.ChaseState.Grabbing)
            {
                Player owner = GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().targetPlayer;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.ControllerActorNr = owner.ActorNumber;
                GameObject.Find("Environment Objects/PersistentObjects_Prefab/Halloween2023_PersistentObjects/Halloween Ghost/FloatingChaseSkeleton").GetComponent<HalloweenGhostChaser>().photonView.OwnerActorNr = owner.ActorNumber;
                string nickName = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + savedName;
                PhotonNetwork.LocalPlayer.NickName = nickName;
                PhotonNetwork.NickName = nickName;
                PhotonNetwork.NetworkingClient.NickName = nickName;
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                Mods.KickDeps(owner);
                PhotonNetwork.SendAllOutgoingCommands();
                string nickName2 = savedName;
                PhotonNetwork.LocalPlayer.NickName = nickName2;
                PhotonNetwork.NickName = nickName2;
                PhotonNetwork.NetworkingClient.NickName = nickName2;
            }
        }















        public static void testcrash()
        {
            if (Time.time > balll2 + 0.7f)
            {
                balll2 = Time.time;
                GorillaTagger.Instance.myVRRig.RPC("RequestCosmetics", 0, null);
            }
        }





















        static float ieuzrjhm;

        static bool shibaisblack;

        static GameObject c4;

        public static void c4projectile()
        {
            if (WristMenu.gripDownL)
            {
                if (c4 == null)
                {
                    c4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    c4.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
                    Destroy(c4.GetComponent<BoxCollider>());
                }
                c4.transform.position = GorillaTagger.Instance.offlineVRRig.leftHandTransform.position;
                c4.transform.rotation = GorillaTagger.Instance.offlineVRRig.leftHandTransform.rotation;
                shibaisblack = false;
            }
            if (WristMenu.triggerDownL)
            {
                Vector3 charvel = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel2 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel3 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 5));
                Vector3 charvel4 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel5 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel6 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel7 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel8 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel9 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 5));
                Vector3 charvel10 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel11 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel12 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel13 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel14 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel15 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Vector3 charvel16 = new Vector3(UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55), UnityEngine.Random.Range(-55, 55));
                Color orange = new Color(100f, 64.7f, 0);
                float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, c4.transform.position);
                if (distance <= GorillaTagManager.instance.tagDistanceThreshold)
                {
                    if (!shibaisblack)
                    {
                        ropedelay1 = Time.time + 0.08f;
                        shibaisblack = true;
                    }
                    Debug.Log("if distane");
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel2, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel3, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel4, orange, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel5, orange, -675036877, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel6, orange, -675036877, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel7, orange, -1674517839, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel7, Color.red, -1674517839, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel7, Color.red, -1674517839, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel8, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel9, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel10, Color.red, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel11, orange, 693334698, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel12, orange, -675036877, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel13, orange, -675036877, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel14, orange, -1674517839, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel15, Color.red, -1674517839, 163790326);
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(c4.transform.position, charvel16, Color.red, -1674517839, 163790326);
                    if (ropedelay1 < Time.time)
                    {
                        Destroy(c4);
                        c4 = null;
                    }
                }
                else
                {
                    NotifiLib.SendNotification("<color=blue>[C4]</color> Get closer to the c4 to explode it.");
                }
            }
        }

        public static void ProjectileAura()
        {
            if (WristMenu.triggerDownL)
            {
                if (Time.time > balll21111 + 0.2f && PhotonNetwork.InRoom)
                {
                    balll21111 = Time.time;
                    foreach (VRRig rig in GorillaParent.instance.vrrigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            float distance = Vector3.Distance(RigShit.GetOwnVRRig().transform.position, rig.transform.position);
                            if (distance < GorillaTagManager.instance.tagDistanceThreshold)
                            {
                                ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(rig.transform.position + new Vector3(0, 5, 0), Vector3.zero);
                            }
                        }
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void ProjectileShower()
        {
            if (WristMenu.gripDownL)
            {
                if (Time.time > balll2111 + 0.1f && PhotonNetwork.InRoom)
                {
                    balll2111 = Time.time;
                    ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(GorillaTagger.Instance.offlineVRRig.transform.position + new Vector3(0, 5, 0), Vector3.zero);
                }
            }
        }

        public static void nukeself()
        {
            if (WristMenu.triggerDownR)
            {
                Color orange = new Color(100f, 64.7f, 0);
                Vector3 charvel = new Vector3(0, 15.5f, 0);
                Vector3 ee = rahhgen();
                int hash = 1;
                if (cycle)
                {
                    fuckyoucsharp++;
                    if (fuckyoucsharp == 0)
                    {
                        hash = projectilehashc1;
                    }
                    if (fuckyoucsharp == 1)
                    {
                        hash = projectilehashc2;
                    }
                    if (fuckyoucsharp == 2)
                    {
                        hash = projectilehashc3;
                    }
                    if (fuckyoucsharp == 3)
                    {
                        hash = projectilehashc4;
                    }
                    if (fuckyoucsharp == 4)
                    {
                        fuckyoucsharp = 0;
                        hash = projectilehashc1;
                    }
                }
                else
                {
                    hash = projectilehash;
                }
                ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(ee, charvel, Color.red, hash, 163790326);
            }
        }

        public static void ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Vector3 pos, Vector3 vel, Color color, int hash, int projectiletrailhash)
        {
            GorillaGameManager.instance.returnPhotonView.RPC("LaunchSlingshotProjectile", RpcTarget.Others, new object[] //making ss proj
            {
                            pos,
                            vel,
                            hash,
                            projectiletrailhash,
                            false,
                            1,
                            true,
                            color.r,
                            color.g,
                            color.b,
                            color.a,
            });
            GameObject gameObject = ObjectPools.instance.Instantiate(hash); //making the cs projecitle
            SlingshotProjectile component = gameObject.GetComponent<SlingshotProjectile>(); //setting component
            if (projectiletrailhash != -1)
            {
                SlingshotProjectileTrail component2 = ObjectPools.instance.Instantiate(projectiletrailhash).GetComponent<SlingshotProjectileTrail>(); //making cs trail
                component2.AttachTrail(gameObject.gameObject, false, false); // attaching cs trail
            }
            component.Launch(pos, vel, PhotonNetwork.LocalPlayer, false, false, 0, 1, true, color); //launching cs projectile
            PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
            RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
        }

        public static void ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(Vector3 pos, Vector3 vel)
        {
            var ohio = HashToName(projectilehash);
            int hash = 1;
            if (cycle)
            {
                fuckyoucsharp++;
                if (fuckyoucsharp == 0)
                {
                    hash = projectilehashc1;
                    ohio = HashToName(projectilehashc1);
                }
                if (fuckyoucsharp == 1)
                {
                    hash = projectilehashc2;
                    ohio = HashToName(projectilehashc2);
                }
                if (fuckyoucsharp == 2)
                {
                    hash = projectilehashc3;
                    ohio = HashToName(projectilehashc3);
                }
                if (fuckyoucsharp == 3)
                {
                    hash = projectilehashc4;
                    ohio = HashToName(projectilehashc4);
                }
                if (fuckyoucsharp == 4)
                {
                    fuckyoucsharp = 0;
                    hash = projectilehashc1;
                    ohio = HashToName(projectilehashc1);
                }
            }
            else
            {
                hash = projectilehash;
                ohio = HashToName(projectilehash);
            }
            Color color = projcolor;
            if (rainboww)
            {
                erm.transform.position = new Vector3(9999, 9999, 9999);
                color = erm.GetComponent<ColorChanger>().color;
            }
            SendProjectile(ohio, pos, vel, color);
            PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
            RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
        }

        public static void LauncherPlayerAura()
        {
            if (balll < Time.time)
            {
                balll = Time.time + 0.05f;
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    float distance = Vector3.Distance(RigShit.GetOwnVRRig().transform.position, GorillaGameManager.instance.FindPlayerVRRig(player).transform.position);
                    if (distance < GorillaTagManager.instance.tagDistanceThreshold)
                    {
                        VRRig rig = GorillaGameManager.instance.FindPlayerVRRig(player);
                        Vector3 shootingDirection;
                        Vector3 fun = Vector3.zero;
                        shootingDirection = rig.rightHandTransform.up; //getting direction
                        fun = shootingDirection.normalized * 7; //setting speed
                        ermyupthisisprojectilethingyupyupyeahthatswhatshappenijng(rig.rightHandTransform.position, fun);
                    }
                }
            }
        }

        public static void LauncherPlayerGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                Vector3 rigpos;
                if (gunLock)
                {
                    float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, lockedrig.transform.position);
                    if (distance > GorillaTagManager.instance.tagDistanceThreshold)
                    {
                        rigpos = lockedrig.transform.position - new Vector3(0, 6, 0);
                        GorillaTagger.Instance.offlineVRRig.transform.position = rigpos;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                    }
                }
                else
                {
                    float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, raycastHit.collider.GetComponentInParent<VRRig>().transform.position);
                    if (distance > GorillaTagManager.instance.tagDistanceThreshold)
                    {
                        rigpos = raycastHit.collider.GetComponentInParent<VRRig>().transform.position - new Vector3(0, 6, 0);
                        GorillaTagger.Instance.offlineVRRig.transform.position = rigpos;
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                    }
                }
                if (WristMenu.triggerDownR)
                {
                    if (Time.time > balll2 + 0.1f)
                    {
                        balll2 = Time.time;
                        var ohio = HashToName(projectilehash);
                        int hash = 1;
                        if (cycle)
                        {
                            fuckyoucsharp++;
                            if (fuckyoucsharp == 0)
                            {
                                hash = projectilehashc1;
                                ohio = HashToName(projectilehashc1);
                            }
                            if (fuckyoucsharp == 1)
                            {
                                hash = projectilehashc2;
                                ohio = HashToName(projectilehashc2);
                            }
                            if (fuckyoucsharp == 2)
                            {
                                hash = projectilehashc3;
                                ohio = HashToName(projectilehashc3);
                            }
                            if (fuckyoucsharp == 3)
                            {
                                hash = projectilehashc4;
                                ohio = HashToName(projectilehashc4);
                            }
                            if (fuckyoucsharp == 4)
                            {
                                fuckyoucsharp = 0;
                                hash = projectilehashc1;
                                ohio = HashToName(projectilehashc1);
                            }
                        }
                        else
                        {
                            hash = projectilehash;
                            ohio = HashToName(projectilehash);
                        }
                        Color color = projcolor;
                        if (rainboww)
                        {
                            erm.transform.position = new Vector3(9999, 9999, 9999);
                            color = erm.GetComponent<ColorChanger>().color;
                        }
                        Vector3 shootingDirection;
                        Vector3 fun = Vector3.zero;
                        if (!gunLock)
                        {
                            shootingDirection = raycastHit.collider.GetComponentInParent<VRRig>().rightHandTransform.up; //getting direction
                        }
                        else
                        {
                            shootingDirection = lockedrig.rightHandTransform.up; //getting direction
                        }
                        fun = shootingDirection.normalized * 7; //setting speed
                        Vector3 weiufh;
                        if (gunLock)
                        {
                            weiufh = lockedrig.rightHandTransform.position;
                        }
                        else
                        {
                            weiufh = raycastHit.collider.GetComponentInParent<VRRig>().rightHandTransform.position;
                        }
                        SendProjectile(ohio, weiufh, fun, color);
                        PhotonNetwork.SendAllOutgoingCommands(); //fun rpc stuff
                        RpcPatcher(GorillaTagger.Instance.offlineVRRig); //more fun rpc stuff
                    }
                }
            }
            else
            {
                lockedrig = null;
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void skiddedurdnabitch(Vector3 pos, Vector3 vel)
        { 

        }

        public static void KickAllV3()
        {
            if (Time.time > balll2 + 0.03f)
            {
                balll2 = Time.time;
                if (WristMenu.triggerDownL)
                {
                    if (crashtp)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = false;
                        GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(0, 0, 0);
                    }
                    if (crashpower == 0)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 1)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 2)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 3)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 4)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 5)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 6)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 7)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 8)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 9)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    if (crashpower == 10)
                    {
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                        Mods.KickDeps(RpcTarget.Others);
                    }
                    PhotonNetwork.RemoveBufferedRPCs();
                   
                    //PhotonNetwork.NetworkingClient.LoadBalancingPeer.SendOutgoingCommands();
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }

        public static string savedName = PhotonNetwork.NickName;

        public static bool lefthandd;

        public static void lefthand()
        {
            lefthandd = true;
        }

        public static void offlefthand()
        {
            lefthandd = false;
        }

        public static void LagAll()
        {
            if (WristMenu.triggerDownL)
            {
                foreach (Player p in PhotonNetwork.PlayerList)
                {
                    if (p.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        PhotonView view = RigShit.GetViewFromPlayer(beesPlayer);
                        view.OwnerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        view.ControllerActorNr = PhotonNetwork.LocalPlayer.ActorNumber;
                        PhotonNetwork.Destroy(view);
                        PhotonNetwork.Destroy(view.gameObject);
                    }
                }
            }
        }

        public static void refection()
        {
            foreach (Player p in PhotonNetwork.PlayerListOthers)
            {
                Type type = typeof(PhotonNetwork);
                MethodInfo method = type.GetMethod("OpRemoveFromServerInstantiationsOfPlayer", BindingFlags.NonPublic | BindingFlags.Instance);
                if (method != null)
                {
                    object[] arguments = { p.ActorNumber };
                    method.Invoke(null, arguments);
                }
            }
        }
        public static void OFFSteamArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        public static void ReallyArms()
        {
            GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(2f, 2f, 2f);
        }

        static float aaa;

        static bool teleportGunAntiRepeat;

        public static void MatSpamGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != null)
                    {
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                    }
                    foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
                    {
                        if (Time.time > MatFloat + 0.2)
                        {
                            MatFloat = Time.time;
                            var gorillaTagManager = GameObject.Find("GT Systems/GameModeSystem/Gorilla Tag Manager").GetComponent<GorillaTagManager>();
                            {
                                    if (new System.Random().Next(0, 2) == 1)
                                    {
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                        gorillaTagManager.AddInfectedPlayer(owner);
                                    }
                                    else
                                    {
                                        if (gorillaTagManager.currentInfected.Contains(owner))
                                        {
                                            gorillaTagManager.currentInfected.Clear();
                                        }
                                    }
                                    gorillaTagManager.ChangeCurrentIt(owner);
                                    gorillaTagManager.SetisCurrentlyTag(true);
                                    gorillaTagManager.isCurrentlyTag = true;
                                    gorillaTagManager.currentIt = owner;
                                    gorillaTagManager.AddInfectedPlayer(owner);
                                }
                        }
                    }
                }
                else
                {
                    lockedrig = null;
                }
            }
        }

        public static void POPFx()
        {
            if (aaa < Time.time)
            {
                aaa = Time.time + 0.2f;
                int hash = PoolUtils.GameObjHashCode((GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BalloonPopFX(Clone)")));
                GorillaNot.instance.logErrorMax = 999999;
                GorillaNot.instance.rpcErrorMax = 999999;
                GorillaNot.instance.rpcCallLimit = 999999;
                GorillaGameManager.instance.returnPhotonView.RpcSecure("LaunchSlingshotProjectile", 0, true, new object[]
                {
                            GorillaLocomotion.Player.Instance.leftControllerTransform.transform.position,
                            GorillaLocomotion.Player.Instance.currentVelocity,
                            hash,
                            1848916225,
                            false,
                            1,
                            false,
                            0f,
                            0f,
                            0f,
                            0f
                });
            }
            flushmanually();
        }

        public static bool jikoisblackbutalsonotblack;

        static bool iuwhewejn = false;

        public static string LastJoinedRoom;
        public static float HopFloat;
        public static bool isJoiningRandom;
        public static string RejoinRoomCode;

        public static void Rejoin()
        {
            if (Time.time > HopFloat)
            {
                if (PhotonNetwork.InRoom)
                {
                    RejoinRoomCode = PhotonNetwork.CurrentRoom.Name;
                    PhotonNetwork.Disconnect();
                    HopFloat = Time.time + 2f;
                }
                else
                {
                    PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(RejoinRoomCode);
                    GetButton("Rejoin Lobby").enabled = false;
                    WristMenu.DestroyMenu();
                    WristMenu.instance.Draw();
                }
            }
        }

        public static void Serverhop()
        {
            if (Time.time > HopFloat)
            {
                if (PhotonNetwork.InRoom)
                {
                    PhotonNetwork.Disconnect();
                    HopFloat = Time.time + 2f;
                }
                else
                {
                    GameObject forest = GameObject.Find("Forest");
                    GameObject city = GameObject.Find("City");
                    GameObject canyons = GameObject.Find("Canyon");
                    GameObject mountains = GameObject.Find("Mountain");
                    GameObject beach = GameObject.Find("Beach");
                    GameObject basement = GameObject.Find("Basement");
                    GameObject caves = GameObject.Find("Cave_Main_Prefab");

                    try
                    {
                        if (forest.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Forest, Tree Exit").GetComponent<GorillaNetworking.GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (city.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - City Front").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (canyons.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Canyon").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (mountains.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Mountain For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (beach.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Beach from Forest").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (basement.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Basement For Computer").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                        if (caves.activeSelf == true)
                        {
                            GameObject.Find("JoinPublicRoom - Cave").GetComponent<GorillaNetworkJoinTrigger>().OnBoxTriggered();
                            GetButton("Serverho").enabled = false;
                            WristMenu.DestroyMenu();
                            WristMenu.instance.Draw();
                            return;
                        }
                    }
                    catch (Exception ex)
                    { }

                }
            }
        }

        public static void RejoinLast()
        {
            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(LastJoinedRoom);
        }

        public static void OFFReallyArms()
        {
            if (GetButton("Steam Long Arms").enabled == false)
            {
                GorillaLocomotion.Player.Instance.transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        public static float balll = 0f;

        public static void InvisMonke()
        {
            if (!WristMenu.triggerDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.transform.position = new Vector3(200f, 200f, 200f);
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
        }

        static VRRig chosenplayer = GorillaTagger.Instance.offlineVRRig;

        public static void copyclose()
        {
            ClosestPlayer(GorillaLocomotion.Player.Instance.transform.position, out chosenplayer);

            if (chosenplayer != null)
            {
                if (!chosenplayer.isOfflineVRRig)
                {
                    VRRig playerrighehe = chosenplayer;
                    RigShit.GetOwnVRRig().enabled = false;
                    RigShit.GetOwnVRRig().transform.position = playerrighehe.transform.position;
                    RigShit.GetOwnVRRig().transform.rotation = playerrighehe.transform.rotation;
                    RigShit.GetOwnVRRig().rightHandPlayer.transform.position = playerrighehe.rightHandPlayer.transform.position;
                    RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = playerrighehe.rightHandPlayer.transform.rotation;
                    RigShit.GetOwnVRRig().leftHandPlayer.transform.position = playerrighehe.leftHandPlayer.transform.position;
                    RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = playerrighehe.leftHandPlayer.transform.rotation;
                    RigShit.GetOwnVRRig().head.headTransform.transform.rotation = playerrighehe.head.headTransform.transform.rotation;
                    RigShit.GetOwnVRRig().head.headTransform.transform.position = playerrighehe.head.headTransform.transform.position;
                    GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = playerrighehe.headConstraint.rotation;
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = GorillaLocomotion.Player.Instance.headCollider.transform.rotation;
            }
        }

        public static void BypassAgreements()
        {
            foreach (LegalAgreements legal in UnityEngine.Object.FindObjectsOfType<LegalAgreements>())
            {
                legal.testFaceButtonPress = true;
            }
        }

        public static void SexClosest()
        {
            ClosestPlayer(GorillaLocomotion.Player.Instance.transform.position, out chosenplayer);

            if (chosenplayer != null)
            {
                if (!chosenplayer.isOfflineVRRig)
                {
                    VRRig whoCopy = chosenplayer;
                    GorillaTagger.Instance.offlineVRRig.enabled = false;

                    GorillaTagger.Instance.offlineVRRig.transform.position = whoCopy.transform.position + (whoCopy.transform.forward * -(0.2f + (Mathf.Sin(Time.frameCount / 8f) * 0.1f)));
                    GorillaTagger.Instance.myVRRig.transform.position = whoCopy.transform.position + (whoCopy.transform.forward * -(0.2f + (Mathf.Sin(Time.frameCount / 8f) * 0.1f)));

                    GorillaTagger.Instance.offlineVRRig.transform.rotation = whoCopy.transform.rotation;
                    GorillaTagger.Instance.myVRRig.transform.rotation = whoCopy.transform.rotation;

                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (whoCopy.transform.position + whoCopy.transform.right * -0.2f) + whoCopy.transform.up * -0.4f;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (whoCopy.transform.position + whoCopy.transform.right * 0.2f) + whoCopy.transform.up * -0.4f;

                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = whoCopy.transform.rotation;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = whoCopy.transform.rotation;

                    GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = whoCopy.transform.rotation;

                    if ((Time.frameCount % 45) == 0)
                    {
                        GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                        {
                                    64,
                                    false,
                                    999999f
                        });
                        Vector3 pos;
                        pos = whoCopy.transform.position - new Vector3(0, 0.5f, 0);
                        GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                        {
                            pos,
                            Quaternion.identity,
                            1.5f,
                            1.5f,
                            false,
                            true
                        });
                        flushmanually();
                    }

                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void copygun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != GorillaTagger.Instance.offlineVRRig || lockedrig == null)
                    {
                        if (lockedrig != null)
                        {
                            chosenplayer = lockedrig;
                        }
                        else
                        {
                            chosenplayer = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                    }
                    if (chosenplayer != null)
                    {
                        if (!chosenplayer.isOfflineVRRig)
                        {
                            VRRig playerrighehe = chosenplayer;
                            RigShit.GetOwnVRRig().enabled = false;
                            RigShit.GetOwnVRRig().transform.position = playerrighehe.transform.position;
                            RigShit.GetOwnVRRig().transform.rotation = playerrighehe.transform.rotation;
                            RigShit.GetOwnVRRig().rightHandPlayer.transform.position = playerrighehe.rightHandPlayer.transform.position;
                            RigShit.GetOwnVRRig().rightHandPlayer.transform.rotation = playerrighehe.rightHandPlayer.transform.rotation;
                            RigShit.GetOwnVRRig().leftHandPlayer.transform.position = playerrighehe.leftHandPlayer.transform.position;
                            RigShit.GetOwnVRRig().leftHandPlayer.transform.rotation = playerrighehe.leftHandPlayer.transform.rotation;
                            RigShit.GetOwnVRRig().head.headTransform.transform.rotation = playerrighehe.head.headTransform.transform.rotation;
                            RigShit.GetOwnVRRig().head.headTransform.transform.position = playerrighehe.head.headTransform.transform.position;
                            GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = playerrighehe.headConstraint.rotation;
                        }
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        GorillaTagger.Instance.offlineVRRig.headConstraint.rotation = GorillaLocomotion.Player.Instance.headCollider.transform.rotation;
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void LucyGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != GorillaTagger.Instance.offlineVRRig || lockedrig == null)
                    {
                        if (lockedrig != null)
                        {
                            chosenplayer = lockedrig;
                        }
                        else
                        {
                            chosenplayer = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                    }
                    if (chosenplayer != null)
                    {
                        if (!chosenplayer.isOfflineVRRig)
                        {
                            VRRig lucyTargetRig = chosenplayer;
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.transform.position += GorillaTagger.Instance.offlineVRRig.transform.forward * lucyspeed * Time.deltaTime;
                            GorillaTagger.Instance.offlineVRRig.transform.LookAt(lucyTargetRig.transform);
                            lucyspeed += 0.005f;
                        }
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        lucyspeed = 0.1f;
                    }
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                    lucyspeed = 0.1f;
                }
            }
        }

        public static float beesDelay;

        public static int[] bones = new int[] {
            4, 3, 5, 4, 19, 18, 20, 19, 3, 18, 21, 20, 22, 21, 25, 21, 29, 21, 31, 29, 27, 25, 24, 22, 6, 5, 7, 6, 10, 6, 14, 6, 16, 14, 12, 10, 9, 7
        };

        public static void SolidPlayersTHXIIDK()
        {
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                if (vrrig != GorillaTagger.Instance.offlineVRRig && Vector3.Distance(vrrig.transform.position, GorillaTagger.Instance.headCollider.transform.position) < 5f)
                {
                    Vector3 pointA = vrrig.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f);
                    Vector3 pointB = vrrig.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f);
                    GameObject bodyCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(bodyCollider.GetComponent<Rigidbody>());
                    bodyCollider.GetComponent<Renderer>().enabled = false;
                    bodyCollider.transform.position = Vector3.Lerp(pointA, pointB, 0.5f);
                    bodyCollider.transform.rotation = vrrig.transform.rotation;
                    bodyCollider.transform.localScale = new Vector3(0.3f, 0.55f, 0.3f);
                    UnityEngine.Object.Destroy(bodyCollider, Time.deltaTime * 2);

                    for (int i = 0; i < bones.Count<int>(); i += 2)
                    {
                        pointA = vrrig.mainSkin.bones[bones[i]].position;
                        pointB = vrrig.mainSkin.bones[bones[i + 1]].position;
                        bodyCollider = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        UnityEngine.Object.Destroy(bodyCollider.GetComponent<Rigidbody>());
                        bodyCollider.GetComponent<Renderer>().enabled = false;
                        bodyCollider.transform.position = Vector3.Lerp(pointA, pointB, 0.5f);
                        bodyCollider.transform.LookAt(pointB);
                        bodyCollider.transform.localScale = new Vector3(0.2f, 0.2f, Vector3.Distance(pointA, pointB));
                        UnityEngine.Object.Destroy(bodyCollider, Time.deltaTime * 2);
                    }
                }
            }
        }

        public static void Tpose()
        {
            if (WristMenu.gripDownR)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.rotation = GorillaTagger.Instance.bodyCollider.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.bodyCollider.transform.position + new Vector3(0, 0.3f, 0);

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void TposeSpaz()
        {
            if (WristMenu.gripDownR)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;

                GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles + new Vector3(4f, 7f, 0f));
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.bodyCollider.transform.position + new Vector3(0, -0.5f, 0);

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;

                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = UnityEngine.Random.rotation;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = UnityEngine.Random.rotation;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void Bees()
        {
            if (WristMenu.gripDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                if (Time.time > beesDelay)
                {
                    beesDelay = Time.time + 1f;
                    VRRig target = RigShit.GetRigFromPlayer(RigShit.GetRandomPlayer(false));

                    GorillaTagger.Instance.offlineVRRig.transform.position = target.transform.position + new Vector3(0f, 1f, 0f);
                    GorillaTagger.Instance.myVRRig.transform.position = target.transform.position + new Vector3(0f, 1f, 0f);

                    GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = target.transform.position;
                    GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = target.transform.position;
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static void BugGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    var Bug = GameObject.Find("Floating Bug Holdable");
                    Bug.transform.position = pointer.transform.position;
                }
                else
                {
                    RigShit.GetOwnVRRig().enabled = true;
                }
            }
            else
            {
                GameObject.Destroy(pointer);
                pointer = null;
            }
        }


        static int sexint;

        public static void SexGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != GorillaTagger.Instance.offlineVRRig || lockedrig == null)
                    {
                        if (lockedrig != null)
                        {
                            chosenplayer = lockedrig;
                        }
                        else
                        {
                            chosenplayer = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                    }
                    if (chosenplayer != null)
                    {
                        if (!chosenplayer.isOfflineVRRig)
                        {
                            VRRig whoCopy = chosenplayer;
                            GorillaTagger.Instance.offlineVRRig.enabled = false;

                            GorillaTagger.Instance.offlineVRRig.transform.position = whoCopy.transform.position + (whoCopy.transform.forward * -(0.2f + (Mathf.Sin(Time.frameCount / 8f) * 0.1f)));
                            GorillaTagger.Instance.myVRRig.transform.position = whoCopy.transform.position + (whoCopy.transform.forward * -(0.2f + (Mathf.Sin(Time.frameCount / 8f) * 0.1f)));

                            GorillaTagger.Instance.offlineVRRig.transform.rotation = whoCopy.transform.rotation;
                            GorillaTagger.Instance.myVRRig.transform.rotation = whoCopy.transform.rotation;

                            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = (whoCopy.transform.position + whoCopy.transform.right * -0.2f) + whoCopy.transform.up * -0.4f;
                            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = (whoCopy.transform.position + whoCopy.transform.right * 0.2f) + whoCopy.transform.up * -0.4f;

                            GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.rotation = whoCopy.transform.rotation;
                            GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.rotation = whoCopy.transform.rotation;

                            GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = whoCopy.transform.rotation;

                            if ((Time.frameCount % 45) == 0)
                            {
                                GorillaTagger.Instance.myVRRig.RPC("PlayHandTap", RpcTarget.All, new object[]
                                {
                                    64,
                                    false,
                                    999999f
                                });
                                Vector3 pos;
                                pos = whoCopy.transform.position - new Vector3(0, 0.5f, 0);
                                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                                {
                            pos,
                            Quaternion.identity,
                            1.5f,
                            1.5f,
                            false,
                            true
                                });
                                flushmanually();
                            }
                        }
                    }
                    else
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                    }
                }
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                lockedrig = null;
            }
        }

        public static void GiveBugGun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                }
                Photon.Realtime.Player owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        if (lockedrig != null)
                        {
                            pointer.transform.position = lockedrig.transform.position;
                        }
                        else
                        {
                            pointer.transform.position = raycastHit.point;
                        }
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    else
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                }
                if (lockedrig == null)
                {
                    pointer.transform.position = raycastHit.point;
                }
                if (WristMenu.triggerDownR)
                {
                    if (lockedrig != GorillaTagger.Instance.offlineVRRig || lockedrig == null)
                    {
                        if (lockedrig != null)
                        {
                            chosenplayer = lockedrig;
                        }
                        else
                        {
                            chosenplayer = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                    }
                    if (chosenplayer != null)
                    {
                        if (!chosenplayer.isOfflineVRRig)
                        {
                            VRRig whoCopy = chosenplayer;
                            var Bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
                            Bug.transform.position = whoCopy.rightHandTransform.position;
                            Bug.transform.rotation = whoCopy.rightHandTransform.rotation;
                        }
                    }
                }
            }
            else
            {
                lockedrig = null;
            }
        }

        public static void BugSeziure()
        {
            var Bug = GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>();
            Bug.transform.rotation = UnityEngine.Random.rotation;
        }

        public static void freezerig()
        {
            if (!WristMenu.triggerDownL)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.transform.position = GorillaLocomotion.Player.Instance.bodyCollider.transform.position;
                GorillaTagger.Instance.offlineVRRig.enabled = false;
            }
        }

        public static void SpazMonk()
        {
            System.Random random = new System.Random();
            if (PhotonNetwork.InRoom)
            {
                RigShit.GetOwnVRRig().head.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                RigShit.GetOwnVRRig().leftHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
                RigShit.GetOwnVRRig().rightHand.rigTarget.eulerAngles = new Vector3(random.Next(0, 360), random.Next(0, 360), random.Next(0, 360));
            }
        }

        public static void GhostMonke()
        {
            if (WristMenu.bbuttonDown)
            {
                if (!ghostToggled && GorillaTagger.Instance.offlineVRRig.enabled)
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    ghostToggled = true;
                }
                else
                {
                    if (!ghostToggled && !GorillaTagger.Instance.offlineVRRig.enabled)
                    {
                        GorillaTagger.Instance.offlineVRRig.enabled = true;
                        ghostToggled = true;
                    }
                }
            }
            else
            {
                ghostToggled = false;
            }
        }

        private static bool gripDown_left;

        private static bool gripDown_right;

        public static void lagadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        object[] eventContent = new object[3]
                        {
                            "Lag",
                            PhotonNetwork.LocalPlayer,
                            owner
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
            }
            else
            {
                lockedrig = null;
                GameObject.Destroy(pointer);
            }
        }

        static Player uefh;

        public static void moveadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                if (uefh != null)
                {
                    if (Time.time > balll2111 + 0.05f && PhotonNetwork.InRoom)
                    {
                        balll2111 = Time.time;
                        object[] eventContent = new object[4]
                        {
                                "Move",
                                PhotonNetwork.LocalPlayer,
                                uefh,
                                pointer.transform.position
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        uefh = owner;
                    }
                }
            }
            else
            {
                lockedrig = null;
                uefh = null;
                GameObject.Destroy(pointer);
            }
        }

        public static void kickadmingun()
        {
            if (WristMenu.gripDownR)
            {
                if (!MenusGUI.emulators)
                {
                    if (Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out raycastHit) && pointer == null)
                    {
                        pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
                        pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    pointer.transform.position = raycastHit.point;
                }
                Photon.Realtime.Player owner = RigShit.GetViewFromRig(raycastHit.collider.GetComponentInParent<VRRig>()).Owner;
                if (WristMenu.triggerDownR)
                {
                    if (gunLock)
                    {
                        if (raycastHit.collider.GetComponentInParent<VRRig>() != null)
                        {
                            lockedrig = raycastHit.collider.GetComponentInParent<VRRig>();
                        }
                        pointer.transform.position = lockedrig.transform.position;
                        owner = RigShit.GetPlayerFromRig(lockedrig);
                    }
                    if (lockedrig == null)
                    {
                        pointer.transform.position = raycastHit.point;
                    }
                    if (owner.UserId != PhotonNetwork.LocalPlayer.UserId)
                    {
                        object[] eventContent = new object[3]
                        {
                            "kick",
                            PhotonNetwork.LocalPlayer,
                            owner
                        };
                        RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                        {
                            Receivers = ReceiverGroup.Others
                        };
                        PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
            }
            else
            {
                lockedrig = null;
                GameObject.Destroy(pointer);
            }
        }

        public static void funnn()
        {
            if (Time.time > balll2111 + 0.01f && WristMenu.triggerDownL && PhotonNetwork.InRoom)
            {
                balll2111 = Time.time;
                if (!PhotonNetwork.CurrentRoom.CustomProperties.ToString().Contains("MODDED"))
                {
                    NotifiLib.SendNotification("<color=red>[CRASH]</color> Turn on antiban!");
                    return;
                }
                foreach (Player p in PhotonNetwork.PlayerListOthers)
                {
                    RaiseRpcEvents(beesPlayer);
                }
            }
        }

        public static void DetectAdminsPanelFeatures(EventData eventData)
        {
            if (eventData.Code == 70)
            {
                object[] array2 = (object[])eventData.CustomData;
                if ((string)array2[0] == "kick" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    PhotonNetwork.Disconnect();
                }
                if ((string)array2[0] == "Lag" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    Thread.Sleep(500);
                }
                if ((string)array2[0] == "Move" && (Player)array2[2] == PhotonNetwork.LocalPlayer && WristMenu.adminList.Contains(array2[1]))
                {
                    GorillaLocomotion.Player.Instance.transform.position = (Vector3)array2[3];
                }
            }
        }

        public static bool toggleon = false;

        static bool toggletoggletoggle;

        private static void PlatformsThing(bool invis, bool sticky)
        {
            colorKeysPlatformMonke[0].color = Color.red;
            colorKeysPlatformMonke[0].time = 0f;
            colorKeysPlatformMonke[1].color = Color.green;
            colorKeysPlatformMonke[1].time = 0.3f;
            colorKeysPlatformMonke[2].color = Color.blue;
            colorKeysPlatformMonke[2].time = 0.6f;
            colorKeysPlatformMonke[3].color = Color.red;
            colorKeysPlatformMonke[3].time = 1f;
            bool inputr;
            bool inputl;
            if (!triggerplat)
            {
                inputr = WristMenu.gripDownR;
                inputl = WristMenu.gripDownL;
            }
            else
            {
                inputr = WristMenu.triggerDownR;
                inputl = WristMenu.triggerDownL;
            }
            if (toggleplat)
            {
                if (WristMenu.triggerDownL && !toggletoggletoggle)
                {
                    toggleon = !toggleon;
                    toggletoggletoggle = true;
                    if (Mods.notifs && toggleon)
                    {
                        NotifiLib.SendNotification("Platforms Toggled On");
                    }
                    if (Mods.notifs && !toggleon)
                    {
                        NotifiLib.SendNotification("Platforms Toggled Off");
                    }
                }
                else if (!WristMenu.triggerDownL)
                {
                    toggletoggletoggle = false;
                }
            }
            else
            {
                toggleon = true;
            }
            if (inputr && toggleon)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    object[] eventContent = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                    GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    once_right = true;
                    once_right_false = false;
                    ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorKeysPlatformMonke;
                    colorChanger.colors = gradient;
                    colorChanger.Start();
                }
            }
            else if (!once_right_false && jump_right_local != null)
            {
                UnityEngine.Object.Destroy(jump_right_local);
                jump_right_local = null;
                once_right = false;
                once_right_false = true;
                RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
            }
            if (inputl && toggleon)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    object[] eventContent2 = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                    GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                    once_left = true;
                    once_left_false = false;
                    ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                    Gradient gradient2 = new Gradient();
                    gradient2.colorKeys = colorKeysPlatformMonke;
                    colorChanger2.colors = gradient2;
                    colorChanger2.Start();
                }
            }
            else if (!once_left_false && jump_left_local != null)
            {
                UnityEngine.Object.Destroy(jump_left_local);
                jump_left_local = null;
                once_left = false;
                once_left_false = true;
                RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    UnityEngine.Object.Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    UnityEngine.Object.Destroy(jump_left_network[j]);
                }
            }
        }

        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

        private static bool once_left;

        private static bool once_right;

        private static bool once_left_false;

        private static bool once_right_false;

        private static bool once_networking;

        private static GameObject[] jump_left_network = new GameObject[9999];

        private static GameObject[] jump_right_network = new GameObject[9999];

        private static GameObject jump_left_local = null;

        private static GameObject jump_right_local = null;

        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

        private static Vector3? checkpointPos;

    }
}
