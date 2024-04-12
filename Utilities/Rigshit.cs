using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Photon.Realtime;
using Displyy_Template.UI;
using GorillaLocomotion.Gameplay;
using HarmonyLib;

namespace dark.efijiPOIWikjek
{
    internal class RigShit : MonoBehaviour
    {
        public static Player NetPlayerToPlayer(NetPlayer np)
        {
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                if (np.UserId == p.UserId)
                {
                    return p;
                }
            }
            return null;
        }

        public static VRRig GetRigFromPlayer(Photon.Realtime.Player p)
        {
            return GorillaGameManager.instance.FindPlayerVRRig(p);
        }

        public static PhotonView GetViewFromPlayer(Photon.Realtime.Player p)
        {
            return WristMenu.rig2view(GorillaGameManager.instance.FindPlayerVRRig(p));
        }

        public static VRRig GetOwnVRRig()
        {
            return GorillaTagger.Instance.offlineVRRig;
        }

        public static PhotonView GetViewFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig);
        }

        public static Photon.Realtime.Player GetPlayerFromRig(VRRig rig)
        {
            return WristMenu.rig2view(rig).Owner;
        }

        public static GorillaRopeSwing GetPlayersRope(VRRig rig)
        {
            return (GorillaRopeSwing)Traverse.Create(rig).Field("currentRopeSwing").GetValue();
        }

        private float Distance2D(Vector3 a, Vector3 b)
        {
            Vector2 a2 = new Vector2(a.x, a.z);
            Vector2 b2 = new Vector2(b.x, b.z);
            return Vector2.Distance(a2, b2);
        }

        private RaycastHit[] rayResults = new RaycastHit[1];
        private LayerMask layerMask;

        private bool PlayerNear(VRRig rig, float dist, out float playerDist)
        {
            if (rig == null)
            {
                playerDist = float.PositiveInfinity;
                return false;
            }
            playerDist = this.Distance2D(rig.transform.position, base.transform.position);
            return playerDist < dist && Physics.RaycastNonAlloc(new Ray(base.transform.position, rig.transform.position - base.transform.position), this.rayResults, playerDist, this.layerMask) <= 0;
        }

        private bool ClosestPlayer(in Vector3 myPos, out VRRig outRig)
        {
            //pro skidded from gtag src :fire:
            layerMask = (UnityLayer.Default.ToLayerMask() | UnityLayer.GorillaObject.ToLayerMask());
            float num = float.MaxValue;
            outRig = null;
            foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
            {
                float num2 = 0f;
                if (this.PlayerNear(vrrig, GorillaTagManager.instance.tagDistanceThreshold, out num2) && num2 < num)
                {
                    num = num2;
                    outRig = vrrig;
                }
            }
            return num != float.MaxValue;
        }


        public static bool battleIsOnCooldown(VRRig rig)
        {
            return rig.mainSkin.material.name.Contains("hit");
        }

        public static Photon.Realtime.Player GetRandomPlayer(bool includeSelf)
        {
            if (includeSelf)
            {
                Player p = PhotonNetwork.PlayerList[UnityEngine.Random.Range(0, 11)];
                if (p != null)
                {
                    return p;
                }
                return GetRandomPlayer(includeSelf);
            }
            Player p2 = PhotonNetwork.PlayerListOthers[UnityEngine.Random.Range(0, 10)];
            if (p2 != null)
            {
                return p2;
            }
            return GetRandomPlayer(includeSelf);
        }
    }
}
