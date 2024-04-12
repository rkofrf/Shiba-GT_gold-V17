using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BepInEx;
using dark.efijiPOIWikjek;
using Displyy_Template.Backend;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.StructWrapping;
using GorillaLocomotion.Gameplay;
using GorillaNetworking;
using GorillaTagScripts;
using HarmonyLib;
using Mono.Cecil;
using Pathfinding.RVO;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice;
using Sirenix.OdinInspector;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Valve.VR;
using Valve.VR.InteractionSystem;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.UI.GridLayoutGroup;

namespace Displyy_Template.UI
{
    internal class MenusGUI : MonoBehaviour
    {
        bool oiesfk1;
        bool oiesfk;
        bool on = true;
        private Rect GuiRect = new Rect(0, 0, 392, 232);
        public static bool emulators;
        bool wasd;
        bool one;
        bool two;
        bool three;
        bool four;
        bool six;
        bool five;
        bool one1;
        string NameChangingString;
        string slavetest2;
        bool two1;
        bool three1;
        bool four1;
        bool five1;
        bool six1;
        bool seven1;
        bool eight1;
        bool nine1;
        bool players;
        public static float FCMovmentSpeed = 1.0f;
        public static float FCJumpSpeed = 1.0f;
        public static float FcRotation = 1.0f;
        string stringthing = "INPUT TEXT HERE";
        bool seven;
        public bool forntite;
        bool eight;
        bool nine;
        public float buttonSpacingY = 7f;
        public Vector2 scrollPosition = Vector2.zero;
        public Vector2 scrollPosition2 = Vector2.zero;
        bool computer;
        bool menubuttons;

        void Start()
        {
            WristMenu.whataloser = Time.time + 10f;
            if (System.IO.File.Exists("GoldPrefs\\WASDPrefsMovement.txt"))
            {
                savedFCMovmentSpeed = float.Parse(System.IO.File.ReadAllText("GoldPrefs\\WASDPrefsMovement.txt"), CultureInfo.InvariantCulture.NumberFormat);
                FCMovmentSpeed = savedFCMovmentSpeed;
            }
            if (System.IO.File.Exists("GoldPrefs\\WASDPrefsJump.txt"))
            {
                savedFCJumpSpeed = float.Parse(System.IO.File.ReadAllText("GoldPrefs\\WASDPrefsJump.txt"), CultureInfo.InvariantCulture.NumberFormat);
                FCJumpSpeed = savedFCJumpSpeed;
            }
            if (System.IO.File.Exists("GoldPrefs\\WASDPrefsRotation.txt"))
            {
                savedFcRotation = float.Parse(System.IO.File.ReadAllText("GoldPrefs\\WASDPrefsRotation.txt"), CultureInfo.InvariantCulture.NumberFormat);
                FcRotation = savedFcRotation;
            }
        }
        public string labelText = "Upper Right Label\nskid";
        public GUIStyle labelStyle;
        public static bool arrayliston = true;
        public static bool RigPatch = true;

        void OnGUI()
        {
            //if (WristMenu.whataloser < Time.time)
            //{
            //    WristMenu.whataloser = Time.time + 4f;
            //new Thread(WristMenu.checker).Start();
            //}
            if (WristMenu.returnedstring == "ON")
            {
                return;
            }
            if (arrayliston)
            {
                //arraylist

                foreach (ButtonInfo b in WristMenu.buttons)
                {
                    if (b.enabled == true)
                    {
                        if (labelText == null)
                        {
                            labelText += b.buttonText;
                        }
                        else
                        {
                            labelText += "\n" + b.buttonText;
                        }
                        if (!Mods.RGB)
                        {
                            GUI.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time + WristMenu.buttons.IndexOf(b) / (WristMenu.buttons.Count / 2f) - 1, 1f));
                        }
                    }
                }

                foreach (ButtonInfo b in WristMenu.settingsbuttons)
                {
                    if (b.enabled == true)
                    {
                        if (labelText == null)
                        {
                            labelText += b.buttonText;
                        }
                        else
                        {
                            labelText += "\n" + b.buttonText;
                        }
                        GUI.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time + WristMenu.buttons.IndexOf(b) / (WristMenu.buttons.Count / 2f) - 1, 1f));
                    }
                }

                foreach (ButtonInfo b in WristMenu.opbuttons)
                {
                    if (b.enabled == true)
                    {
                        if (labelText == null)
                        {
                            labelText += b.buttonText;
                        }
                        else
                        {
                            labelText += "\n" + b.buttonText;
                        }
                        GUI.color = Color.Lerp(Color.cyan, Color.magenta, Mathf.PingPong(Time.time + WristMenu.buttons.IndexOf(b) / (WristMenu.buttons.Count / 2f) - 1, 1f));
                    }
                }

                labelStyle = new GUIStyle(GUI.skin.label);
                labelStyle.alignment = TextAnchor.UpperRight;
                labelStyle.fontSize = 21;
                float labelWidth = 500f;
                float labelHeight = 999f;
                float labelX = Screen.width - labelWidth - 10;
                float labelY = 50f;
                string[] lines = labelText.Split('\n');

                string[] sortedLines = lines.OrderBy(line => -labelStyle.CalcSize(new GUIContent(line)).x).ToArray();
                string sortedString = string.Join("\n", sortedLines);
                labelText = sortedString;

                GUI.Label(new Rect(labelX, labelY, labelWidth, labelHeight), labelText, labelStyle);
                GUI.Label(new Rect(labelX, 10f, labelWidth, labelHeight), "Click F3 To Close", labelStyle);
                labelText = null;
            }
            if (Mods.GetButtonOP("Name Change").enabled == true && Mods.NameChangerString == null)
            {
                GUI.Box(new Rect(250, 250, 200, 150), "Assign Name Changing Name");
                NameChangingString = GUI.TextField(new Rect(250, 300, 200, 50), NameChangingString);
                if (GUI.Button(new Rect(250, 350, 200, 50), "Submit"))
                {
                    Mods.NameChangerString = NameChangingString;
                }
            }
            if (on)
            {

                //fun

                GUI.backgroundColor = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
                GUI.contentColor = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
                GUI.color = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
                int fps = Mathf.RoundToInt(1.0f / Time.deltaTime);
                GuiRect = GUI.Window(9999, GuiRect, new GUI.WindowFunction(MainWindowFunction), "<color=white>" + WristMenu.MenuTitle + " [f2 to close]</color> <color=yellow>FPS: " + fps + "</color>");
            }
        }

        public void MainWindowFunction(int WindowId)
        {
            GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
            GUI.Box(new Rect(0, 0, 97, 232), "");
            if (GUI.Button(new Rect(5, 21, 87, 41), "MenuButtons"))
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                menubuttons = true;
                emulators = false;
                computer = false;
                players = false;
            }
            if (GUI.Button(new Rect(5, 61, 87, 41), "Emulators"))
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                menubuttons = false;
                emulators = true;
                computer = false;
                players = false;
            }
            if (GUI.Button(new Rect(5, 101, 87, 41), "Computer"))
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                menubuttons = false;
                emulators = false;
                computer = true;
                players = false;
            }
            if (GUI.Button(new Rect(5, 141, 87, 41), "Players"))
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                menubuttons = false;
                emulators = false;
                computer = false;
                players = true;
            }
            if (menubuttons)
            {
                List<ButtonInfo> info = new List<ButtonInfo>();
                if (Mods.inSettings)
                {
                    info = WristMenu.settingsbuttons;
                }
                if (Mods.inPlayers)
                {
                    info = WristMenu.opbuttons;
                }
                if (!Mods.inSettings && !Mods.inPlayers && !Mods.inFavorite)
                {
                    info = WristMenu.buttons;
                }
                if (Mods.inFavorite && !Mods.inSettings && !Mods.inPlayers)
                {
                    info = WristMenu.favoritebuttons;
                }
                    float buttonHeight = 25;
                float scrollViewHeight = info.Count * (buttonHeight + buttonSpacingY + 99);
                scrollPosition = GUI.BeginScrollView(new Rect(10, 10, Screen.width - 20, Screen.height - 20), scrollPosition,
                new Rect(0, 0, Screen.width - 40, scrollViewHeight + 20));
                for (int i = 0; i < info.Count; i++)
                {
                    Rect buttonRect = new Rect(130, 21 + i * (buttonHeight + buttonSpacingY), 220, buttonHeight);
                    if (info[i].enabled == true)
                    {
                        GUI.backgroundColor = Color.red;
                    }
                    else
                    {
                        GUI.backgroundColor = Color.black;
                    }
                    if (GUI.Button(buttonRect, info[i].buttonText))
                    {
                        info[i].enabled = !info[i].enabled;
                        WristMenu.lastPressedButtonIndex = i;
                        GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                    }
                }

                GUI.EndScrollView();
            }
            GUI.backgroundColor = Color.black;
            if (emulators)
            {
                one = GUI.Toggle(new Rect(100, 21, 140, 25), one, "Emulate Left Trigger");
                if (one)
                {
                    WristMenu.triggerDownL = true;
                }
                else
                {
                    WristMenu.triggerDownL = false;
                }
                two = GUI.Toggle(new Rect(100, 51, 140, 25), two, "Emulate Right Trigger");
                if (two)
                {
                    WristMenu.triggerDownR = true;
                }
                else
                {
                    if (!nine)
                    {
                        WristMenu.triggerDownR = false;
                    }
                }
                three = GUI.Toggle(new Rect(100, 81, 140, 25), three, "Emulate Left Grip");
                if (three)
                {
                    WristMenu.gripDownL = true;
                }
                else
                {
                    WristMenu.gripDownL = false;
                }
                four = GUI.Toggle(new Rect(100, 111, 140, 25), four, "Emulate Right Grip");
                if (four)
                {
                    WristMenu.gripDownR = true;
                }
                else
                {
                    if (!nine)
                    {
                        WristMenu.gripDownR = false;
                    }
                }
                five = GUI.Toggle(new Rect(100, 141, 140, 25), five, "Emulate Left Primary");
                if (five)
                {
                    WristMenu.xbuttonDown = true;
                }
                else
                {
                    WristMenu.xbuttonDown = false;
                }
                six = GUI.Toggle(new Rect(100, 171, 140, 25), six, "Emulate Right Primary");
                if (six)
                {
                    WristMenu.abuttonDown = true;
                }
                else
                {
                    WristMenu.abuttonDown = false;
                }
                seven = GUI.Toggle(new Rect(240, 21, 140, 25), seven, "Emulate Left Secondary");
                if (seven)
                {
                    WristMenu.ybuttonDown = true;
                }
                else
                {
                    WristMenu.ybuttonDown = false;
                }
                eight = GUI.Toggle(new Rect(240, 51, 140, 25), eight, "Emulate Right Secondary");
                if (eight)
                {
                    WristMenu.bbuttonDown = true;
                }
                else
                {
                    WristMenu.bbuttonDown = false;
                }
                nine = GUI.Toggle(new Rect(240, 81, 140, 25), nine, "Emulate Gun");
                if (nine)
                {
                    WristMenu.gripDownR = true;
                    Ray ray = imgonnakms.ScreenPointToRay(UnityInput.Current.mousePosition);
                    if (Physics.Raycast(ray, out Mods.raycastHit) && Mods.pointer == null)
                    {
                        Mods.pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        UnityEngine.Object.Destroy(Mods.pointer.GetComponent<Rigidbody>());
                        UnityEngine.Object.Destroy(Mods.pointer.GetComponent<SphereCollider>());
                        Mods.pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    }
                    Mods.pointer.transform.position = Mods.raycastHit.point;
                    if (UnityInput.Current.GetMouseButton(0))
                    {
                        WristMenu.triggerDownR = true;
                    }
                    else
                    {
                        WristMenu.triggerDownR = false;
                    }
                    forntite = true;
                }
                else
                {
                    Mods.pointer = null;
                    Destroy(Mods.pointer);
                }
            }
            if (computer)
            {
                stringthing = GUI.TextField(new Rect(130, 21, 220, 25), stringthing);
                if (GUI.Button(new Rect(130, 46, 220, 25), "Set Name"))
                {
                    PhotonNetwork.LocalPlayer.NickName = stringthing;
                    PhotonNetwork.NickName = stringthing;
                    PlayerPrefs.SetString("playerName", stringthing);
                    GorillaComputer.instance.currentName = stringthing;
                    PlayerPrefs.Save();
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                }
                if (GUI.Button(new Rect(130, 71, 220, 25), "Join Room"))
                {
                    PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(stringthing);
                    GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                }
                GUI.Label(new Rect(130, 97, 220, 25), "WASD Movment Speed = " + FCMovmentSpeed.ToString());
                FCMovmentSpeed = GUI.HorizontalSlider(new Rect(130, 111, 220, 25), FCMovmentSpeed, 0f, 10f);
                GUI.Label(new Rect(130, 131, 220, 25), "WASD Rotation Speed = " + FcRotation.ToString());
                FcRotation = GUI.HorizontalSlider(new Rect(130, 151, 220, 25), FcRotation, 0f, 10f);
                GUI.Label(new Rect(130, 171, 220, 25), "WASD Jump Speed = " + FCJumpSpeed.ToString());
                FCJumpSpeed = GUI.HorizontalSlider(new Rect(130, 191, 220, 25), FCJumpSpeed, 0f, 10f);
                wasd = GUI.Toggle(new Rect(130, 211, 220, 25), wasd, "WASD");
            }
            if (players)
            {
                playersString = null;
                float buttonHeight = 23;
                float scrollViewHeight = PhotonNetwork.PlayerList.Length * (buttonHeight + buttonSpacingY + 99);
                scrollPosition = GUI.BeginScrollView(new Rect(10, 10, Screen.width - 20, Screen.height - 20), scrollPosition,
                new Rect(0, 0, Screen.width - 40, scrollViewHeight + 999));

                for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
                {
                    if (playersString != null)
                    {
                        playersString += "\n\n" + PhotonNetwork.PlayerList[i].NickName;
                    }
                    else
                    {
                        playersString += PhotonNetwork.PlayerList[i].NickName;
                    }
                    object rah;
                    if (PhotonNetwork.PlayerList[i].CustomProperties.TryGetValue("mods", out rah) && rah is string)
                    {
                        playersString += " : <color=red>MODS:\n" + rah + "</color>";
                    }
                }

                GUI.Label(new Rect(90, 10, 232, 9999), playersString);
                GUI.EndScrollView();
            }





            if (GUI.Button(new Rect(375, 5, 25, 220), "D\nI\nS\nC\nO\nN\nN\nE\nC\nT"))
            {
                PhotonNetwork.Disconnect();
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
            }
        }

    private static Texture2D button = new Texture2D(1, 1);
        string playersString;
        private static Texture2D buttonhovered = new Texture2D(1, 1);
        private static Texture2D buttonactive = new Texture2D(1, 1);

        public static void wasdd()
        {
            GorillaTagger.Instance.rigidbody.useGravity = false;
            GorillaTagger.Instance.rigidbody.velocity = Vector3.zero;
            float NSpeed = FCMovmentSpeed * Time.deltaTime;
            if (UnityInput.Current.GetKey(KeyCode.LeftShift) || UnityInput.Current.GetKey(KeyCode.RightShift))
            {
                NSpeed *= 10f;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftArrow) || UnityInput.Current.GetKey(KeyCode.A))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.RightArrow) || UnityInput.Current.GetKey(KeyCode.D))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.right * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.UpArrow) || UnityInput.Current.GetKey(KeyCode.W))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.DownArrow) || UnityInput.Current.GetKey(KeyCode.S))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.forward * -1f * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.Space) || UnityInput.Current.GetKey(KeyCode.PageUp))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * NSpeed;
            }
            if (UnityInput.Current.GetKey(KeyCode.LeftControl) || UnityInput.Current.GetKey(KeyCode.PageDown))
            {
                GorillaLocomotion.Player.Instance.transform.position += Camera.main.transform.up * -1f * NSpeed;
            }
            if (UnityInput.Current.GetMouseButton(1))
            {
                Vector3 val = UnityInput.Current.mousePosition - previousMousePosition;
                float num2 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.y + val.x * 0.3f;
                float num3 = GorillaLocomotion.Player.Instance.transform.localEulerAngles.x - val.y * 0.3f;
                GorillaLocomotion.Player.Instance.transform.localEulerAngles = new Vector3(num3, num2, 0f);
            }
            previousMousePosition = UnityInput.Current.mousePosition;
        }

        public static string[] AmongUs = new string[]
{
     @"
     ⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⢰⡿⠋⠁⠀⠀⠈⠉⠙⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢀⣿⠇⠀⢀⣴⣶⡾⠿⠿⠿⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⣀⣀⣸⡿⠀⠀⢸⣿⣇⠀⠀⠀⠀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⣾⡟⠛⣿⡇⠀⠀⢸⣿⣿⣷⣤⣤⣤⣤⣶⣶⣿⠇⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀
     ⢀⣿⠀⢀⣿⡇⠀⠀⠀⠻⢿⣿⣿⣿⣿⣿⠿⣿⡏⠀⠀⠀⠀⢴⣶⣶⣿⣿⣿⣆
     ⢸⣿⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⣿⡇⣀⣠⣴⣾⣮⣝⠿⠿⠿⣻⡟
     ⢸⣿⠀⠘⣿⡇⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠉⠀
     ⠸⣿⠀⠀⣿⡇⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀
     ⠀⠻⣷⣶⣿⣇⠀⠀⠀⢠⣼⣿⣿⣿⣿⣿⣿⣿⣛⣛⣻⠉⠁⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⣀⣀⣀⣼⡿⢿⣿⣿⣿⣿⣿⡿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠙⠻⠿⠟⠋⠑⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     "
};

        public static string[] AmongUs4 = new string[]
{
     @"
     ⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⢰⡿⠋⠁⠀⠀⠈⠉⠙⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢀⣿⠇⠀⢀⣴⣶⡾⠿⠿⠿⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⣀⣀⣸⡿⠀⠀⢸⣿⣇⠀⠀⠀⠀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⣾⡟⠛⣿⡇⠀⠀⢸⣿⣿⣷⣤⣤⣤⣤⣶⣶⣿⠇⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀
     ⢀⣿⠀⢀⣿⡇⠀⠀⠀⠻⢿⣿⣿⣿⣿⣿⠿⣿⡏⠀⠀⠀⠀⢴⣶⣶⣿⣿⣿⣆
     ⢸⣿⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⣿⡇⣀⣠⣴⣾⣮⣝⠿⠿⠿⣻⡟
     ⢸⣿⠀⠘⣿⡇⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠉⠀
     ⠸⣿⠀⠀⣿⡇⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀
     ⠀⠻⣷⣶⣿⣇⠀⠀⠀⢠⣼⣿⣿⣿⣿⣿⣿⣿⣛⣛⣻⠉⠁⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⣀⣀⣀⣼⡿⢿⣿⣿⣿⣿⣿⡿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠙⠻⠿⠟⠋⠑⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     "
};

        public static string[] AmongUs3 = new string[]
{
     @"
     ⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⢰⡿⠋⠁⠀⠀⠈⠉⠙⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢀⣿⠇⠀⢀⣴⣶⡾⠿⠿⠿⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⣀⣀⣸⡿⠀⠀⢸⣿⣇⠀⠀⠀⠀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⣾⡟⠛⣿⡇⠀⠀⢸⣿⣿⣷⣤⣤⣤⣤⣶⣶⣿⠇⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀
     ⢀⣿⠀⢀⣿⡇⠀⠀⠀⠻⢿⣿⣿⣿⣿⣿⠿⣿⡏⠀⠀⠀⠀⢴⣶⣶⣿⣿⣿⣆
     ⢸⣿⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⣿⡇⣀⣠⣴⣾⣮⣝⠿⠿⠿⣻⡟
     ⢸⣿⠀⠘⣿⡇⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠉⠀
     ⠸⣿⠀⠀⣿⡇⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀
     ⠀⠻⣷⣶⣿⣇⠀⠀⠀⢠⣼⣿⣿⣿⣿⣿⣿⣿⣛⣛⣻⠉⠁⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⣀⣀⣀⣼⡿⢿⣿⣿⣿⣿⣿⡿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠙⠻⠿⠟⠋⠑⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     "
};

        public static string[] AmongUs2 = new string[]
{
     @"
     ⠀⠀⠀⠀⠀⠀⠀⣠⣤⣤⣤⣤⣤⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⢰⡿⠋⠁⠀⠀⠈⠉⠙⠻⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢀⣿⠇⠀⢀⣴⣶⡾⠿⠿⠿⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⣀⣀⣸⡿⠀⠀⢸⣿⣇⠀⠀⠀⠀⠀⠀⠙⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⣾⡟⠛⣿⡇⠀⠀⢸⣿⣿⣷⣤⣤⣤⣤⣶⣶⣿⠇⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀
     ⢀⣿⠀⢀⣿⡇⠀⠀⠀⠻⢿⣿⣿⣿⣿⣿⠿⣿⡏⠀⠀⠀⠀⢴⣶⣶⣿⣿⣿⣆
     ⢸⣿⠀⢸⣿⡇⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⣿⡇⣀⣠⣴⣾⣮⣝⠿⠿⠿⣻⡟
     ⢸⣿⠀⠘⣿⡇⠀⠀⠀⠀⠀⠀⠀⣠⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠉⠀
     ⠸⣿⠀⠀⣿⡇⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠉⠀⠀⠀⠀
     ⠀⠻⣷⣶⣿⣇⠀⠀⠀⢠⣼⣿⣿⣿⣿⣿⣿⣿⣛⣛⣻⠉⠁⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⢸⣿⣀⣀⣀⣼⡿⢿⣿⣿⣿⣿⣿⡿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀
     ⠀⠀⠀⠀⠀⠙⠛⠛⠛⠋⠁⠀⠙⠻⠿⠟⠋⠑⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
     "
};

        static Vector3 previousMousePosition;

        public static float savedFCMovmentSpeed = 1.0f;
        public static float savedFCJumpSpeed = 1.0f;
        public static float savedFcRotation = 1.0f;
        public static GameObject what;
        public static void mousecollidergun()
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(UnityInput.Current.mousePosition);
            if (Physics.Raycast(ray, out raycastHit) && what == null)
            {
                what = GameObject.CreatePrimitive(PrimitiveType.Cube);
                UnityEngine.Object.Destroy(what.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(what.GetComponent<BoxCollider>());
                what.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            }
            what.transform.position = raycastHit.point;
            if (UnityInput.Current.GetMouseButtonDown(0))
            {
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").transform.position = raycastHit.point;
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = false;
            }
        }

        static Camera imgonnakms;

        void Update()
        {
            if (GameObject.Find("Third Person Camera"))
            {
                imgonnakms = GameObject.Find("Shoulder Camera").GetComponent<Camera>();
            }
            else
            {
                imgonnakms = Camera.main;
            }
            //SAVING FLOATS
            if (UnityInput.Current.GetMouseButton(0))
            {
                new Thread(WristMenu.checker).Start();
                Ray ray = imgonnakms.ScreenPointToRay(UnityInput.Current.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").transform.position = hit.point;
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = false;
            }
            else
            {
                GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHandTriggerCollider").GetComponent<TransformFollow>().enabled = true;
            }
            if (FCMovmentSpeed != savedFCMovmentSpeed && FCMovmentSpeed != 1f)
            {
                System.IO.Directory.CreateDirectory("GoldPrefs");
                savedFCMovmentSpeed = FCMovmentSpeed;
                System.IO.File.WriteAllText("GoldPrefs\\WASDPrefsMovement.txt", savedFCMovmentSpeed.ToString());
            }
            if (FCJumpSpeed != savedFCJumpSpeed && FCJumpSpeed != 1f)
            {
                System.IO.Directory.CreateDirectory("GoldPrefs");
                savedFCJumpSpeed = FCJumpSpeed;
                System.IO.File.WriteAllText("GoldPrefs\\WASDPrefsJump.txt", savedFCJumpSpeed.ToString());
            }
            if (FcRotation != savedFcRotation && FcRotation != 1f )
            {
                System.IO.Directory.CreateDirectory("GoldPrefs");
                savedFcRotation = FcRotation;
                System.IO.File.WriteAllText("GoldPrefs\\WASDPrefsRotation.txt", savedFcRotation.ToString());
            }




            if (UnityInput.Current.GetKey(KeyCode.F2))
            {
                if (oiesfk == false)
                {
                    on = !on;
                    oiesfk = true;
                }
            }
            else
            {
                oiesfk = false;
            }


            if (UnityInput.Current.GetKey(KeyCode.F3))
            {
                if (oiesfk1 == false)
                {
                    arrayliston = !arrayliston;
                    oiesfk1 = true;
                }
            }
            else
            {
                oiesfk1 = false;
            }
            if (wasd)
            {
                wasdd();
            }
        }
    }
}
