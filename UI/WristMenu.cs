using dark.efijiPOIWikjek;
using Displyy_Template.Backend;
using Displyy_Template.UI;
using Displyy_Template.Utilities;
using GTAG_NotificationLib;
using HarmonyLib;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

//Template is based off mango
namespace Displyy_Template.UI
{
    public class ButtonInfo
    {
        public string buttonText = "Error";
        public Action method = null;
        public Action disableMethod = null;
        public bool? enabled = false;
        public bool isClickable = false;
        public string toolTip = "This button doesn't have a tooltip/tutorial";
        public bool showTooltip = true;
    }

    internal class WristMenu : MonoBehaviour
    {

        void Start()
        {
            Draw();
        }

        public static PhotonView rig2view(VRRig p)
        {
            return (PhotonView)Traverse.Create(p).Field("photonView").GetValue();
        }

        public static List<ButtonInfo> settingsbuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go back!"},
            new ButtonInfo { buttonText = "Save Preferences", method =() => Mods.Save(), enabled = false, toolTip = "Save your settings!"},
            new ButtonInfo { buttonText = "Player Gun Lock", method =() => Mods.GunLock(), disableMethod =() => Mods.UNGodModLock(), enabled = false, toolTip = "When you use guns, it locks on the player!"},
            new ButtonInfo { buttonText = "Turn Off Notifications", method =() => Mods.OffNotifs(), disableMethod =() => Mods.OnNotifs(), enabled = false, toolTip = "No more notifications!"},
            new ButtonInfo { buttonText = "Menu Layout: ShibaGT", method =() => Mods.ChangeLayout(), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Left Hand Menu", method =() => Mods.lefthand(), disableMethod =() => Mods.offlefthand(), enabled = false, toolTip = "oepn menu different!"},
            new ButtonInfo { buttonText = "Antireport: Leave", method =() => Mods.AntireportSettings(false), enabled = false, toolTip = "sewfi!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.Platforms(), enabled = false, toolTip = "skbiiti!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.ChangeProj(false), enabled = false, toolTip = "Change the projectile!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.ChangeTrail(false), enabled = false, toolTip = "Change the trail!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.rainbow(), disableMethod =() => Mods.offrainbow(), enabled = false, toolTip = "rianbow!"},
            new ButtonInfo { buttonText = "Change Time Of Day: Day", method =() => Mods.ChangeTime(false), enabled = false, toolTip = "rianbow!"},
            new ButtonInfo { buttonText = "Turn Off Leaves", method =() => Mods.offleaves(), disableMethod =() => Mods.offoffleaves(), enabled = false, toolTip = "no elaves!"},
            new ButtonInfo { buttonText = "Make Platforms Sticky", method =() => Mods.sticky(), disableMethod =() => Mods.offsticky(), enabled = false, toolTip = "platforms!"},
            new ButtonInfo { buttonText = "Platforms Type: Normal", method =() => Mods.ChangePlatforms(false), enabled = false, toolTip = "platforms!"},
            new ButtonInfo { buttonText = "Make Crash Mods Not TP", method =() => Mods.notpcrash(), disableMethod =() => Mods.notnotprcrahs(), enabled = false, toolTip = "activatig means crash all stuff will be BELOW you, so make sure ur ont he ground if you activae and do crash all!"},
            new ButtonInfo { buttonText = "ESP Color: Tagged", method =() => Mods.ChangeESP(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "Tracers Color: Tagged", method =() => Mods.ChangeTracersColor (false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "Tracers Position: Right Hand", method =() => Mods.ChangeTracersPos(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "Speed Boost: Mosa", method =() => Mods.ChangeSpeed(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.makecycle(), disableMethod =() => Mods.disablecycle(), enabled = false, toolTip = "so like you can dude just edit all the choices then use a proj mod :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.cycle1(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.cycle2(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.cycle3(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.cycle4(false), enabled = false, toolTip = "too many fucking settings man :sob:!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.changeprojcolor(false), enabled = false, toolTip = "without rainbow!"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.bothhanded(), disableMethod =() => Mods.offbothhanded(), enabled = false, toolTip = "so like you can dude just edit all the choices then use a proj mod :sob:!"},
            new ButtonInfo { buttonText = "First Person Camera", method =() => Mods.fpc(), disableMethod =() => Mods.fpcoff(), enabled = false, toolTip = "quest 23"},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.changecrashpower(false), enabled = false, toolTip = "determines hpow powerful the crash mods are, just incase you dont have a good enough pc."},
            new ButtonInfo { buttonText = "REMOVED", method =() => Mods.antimoderator(), enabled = false, toolTip = "no sticks!"},
            new ButtonInfo { buttonText = "Menu Theme First Color: Black", method =() => Mods.Change1Theme(false), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Menu Theme Second Color: Purple", method =() => Mods.Change2Theme(false), enabled = false, toolTip = "Change the layout!"},
            new ButtonInfo { buttonText = "Menu Theme Button Color: Same As Menu", method =() => Mods.ChangeButtonColor(false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme Text On Color: White", method =() => Mods.ChangeOnTextColor(false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme Text Off Color: Purple", method =() => Mods.ChangeOffTextColor (false), enabled = false, toolTip = "Change the text button layout!"},
            new ButtonInfo { buttonText = "Menu Theme RGB", method =() => Mods.RGBMenu(), disableMethod =() => Mods.OffRGBMenu(), enabled = false, toolTip = "quest 23"},
        };

        public static List<ButtonInfo> opbuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "OP Mods", method = () => Mods.OPMods(), enabled = false, toolTip = "Go back!" },
            new ButtonInfo { buttonText = "Antiban", method =() => Mods.Antiban(), disableMethod =() => Mods.offantiban(), enabled = false, showTooltip = false, toolTip = "HOLD ON!!"},
            new ButtonInfo { buttonText = "Antiban Status <color=green>[NEW]</color>", method =() => Mods.AntibanStatus(), enabled = false, isClickable = true, showTooltip = false, toolTip = "HOLD ON!!"},
            new ButtonInfo { buttonText = "Set Master", method =() => Mods.SetMaster(), enabled = false, isClickable = true, toolTip = "setr master! seter", showTooltip = false},
            new ButtonInfo { buttonText = "Auto Set Master <color=green>[NEW]</color>", method =() => Mods.AutoSetMaster(), enabled = false, isClickable = false, toolTip = "setr master! seter", showTooltip = false},
            new ButtonInfo { buttonText = "Nuke Modcheckers", method =() => Mods.giveallmods(), enabled = false, toolTip = "gives everyone 'mods' according to mod checkers!"},
            new ButtonInfo { buttonText = "Disable Network Triggers SS!", method =() => Mods.setmaster(), enabled = false, toolTip = "SUPER OP BRUH!"},
            new ButtonInfo { buttonText = "Trap Stump", method =() => Mods.penisohio(), enabled = false, toolTip = "doesnt work for you, but it traps others!"},
            new ButtonInfo { buttonText = "Lag All [t]", method =() => Mods.funnn(), enabled = false, toolTip = "<color=red>WAY BETTER FOR QUEST, AND KINDA WEIRD IDK, TRY IN PRIVS</color>!"},
            new ButtonInfo { buttonText = "Lag Gun", method =() => Mods.funnngun(), enabled = false, toolTip = "<color=red>WAY BETTER FOR QUEST, AND KINDA WEIRD IDK, TRY IN PRIVS</color>!"},
            //new ButtonInfo { buttonText = "Freeze PCVR & Kill Quest's Screen", method =() => Mods.bubbleepic(), isClickable = true, enabled = false, toolTip = "matster!"},
            //new ButtonInfo { buttonText = "Green Sky", method =() => Mods.bubblesky(), enabled = false, toolTip = "matster!"},
            //new ButtonInfo { buttonText = "Crash Gun", method =() => Mods.bubblegun(), enabled = false, toolTip = "matster!"},
            //new ButtonInfo { buttonText = "Crash All", method =() => Mods.spawnbubble(), enabled = false, toolTip = "matster!"},
            //new ButtonInfo { buttonText = "Crash Aura", method =() => Mods.bubbleaura(), enabled = false, toolTip = "matster!"},
            //new ButtonInfo { buttonText = "Crash On Touch", method =() => Mods.bubbletouch(), enabled = false, toolTip = "matster!"},
            new ButtonInfo { buttonText = "Name Change All", method =() => Mods.NameChangeAll(), enabled = false, toolTip = "someone has to leave for it to be visible idk why"},
            new ButtonInfo { buttonText = "Name Change Gun", method =() => Mods.NameChangeGun(), enabled = false, toolTip = "someone has to leave for it to be visible idk why"},
           // new ButtonInfo { buttonText = "Invis On Report <color=green>[NEW]</color>", method =() => Mods.InvisOnReport(), enabled = false, toolTip = "body once told me"},
           // new ButtonInfo { buttonText = "Invis Gun", method =() => Mods.ballgun(), enabled = false, toolTip = "body once told me"},
           // new ButtonInfo { buttonText = "Invis All", method =() => Mods.ballsall(), enabled = false, toolTip = "some"},
           // new ButtonInfo { buttonText = "Invis Aura", method =() => Mods.ballsaura(), enabled = false, toolTip = "some"},
           // new ButtonInfo { buttonText = "Invis On Touch", method =() => Mods.ballsontouch(), enabled = false, toolTip = "some"},
            new ButtonInfo { buttonText = "Crash Gun", method =() => Mods.CrashGun(), enabled = false, toolTip = "Point the gun at someone to crash them!"},
            new ButtonInfo { buttonText = "Crash All", method =() => Mods.CrashAll(), enabled = false, toolTip = "Crashes everyone in the game!"},
            new ButtonInfo { buttonText = "Crash Aura", method =() => Mods.CrashAura(), enabled = false, toolTip = "Crashes anyone near you!"},
            new ButtonInfo { buttonText = "Crash On Touch", method =() => Mods.CrashOnTouch(), enabled = false, toolTip = "Crashes anyone that touches you!"},
            new ButtonInfo { buttonText = "Crash On You Touch <color=green>[NEW]</color>", method =() => Mods.CrashOnYouTouch(), enabled = false, toolTip = "Crashes anyone that touches you!"},
            //new ButtonInfo { buttonText = "Crash Gun 2 <color=green>[NEW]</color>", method =() => Mods.Crash2Gun(), enabled = false, toolTip = "Point the gun at someone to crash them!"},
            //new ButtonInfo { buttonText = "Crash All 2 <color=green>[NEW]</color>", method =() => Mods.Crash2All(), enabled = false, toolTip = "Crashes everyone in the game!"},
            //new ButtonInfo { buttonText = "Crash Aura 2 <color=green>[NEW]</color>", method =() => Mods.Crash2Aura(), enabled = false, toolTip = "Crashes anyone near you!"},
            //new ButtonInfo { buttonText = "Crash On Touch 2 <color=green>[NEW]</color>", method =() => Mods.Crash2OnTouch(), enabled = false, toolTip = "Crashes anyone that touches you!"},
            //new ButtonInfo { buttonText = "Crash On You Touch 2 <color=green>[NEW]</color>", method =() => Mods.Crash2OnYouTouch(), enabled = false, toolTip = "Crashes anyone that you touch!"},
            //new ButtonInfo { buttonText = "Instant Crash Gun <color=green>[NEW]</color>", method =() => Mods.EpicGun(), enabled = false, toolTip = "Point the gun at someone to crash them!"},
            //new ButtonInfo { buttonText = "Instant Crash All <color=green>[NEW]</color>", method =() => Mods.ihatepeoplereal(), enabled = false, toolTip = "Crashes everyone in the game!"},
            //new ButtonInfo { buttonText = "Instant Crash Aura <color=green>[NEW]</color>", method =() => Mods.EpicAura(), enabled = false, toolTip = "Crashes anyone near you!"},
            //new ButtonInfo { buttonText = "Instant Crash On Touch <color=green>[NEW]</color>", method =() => Mods.EpicOnTouch(), enabled = false, toolTip = "Crashes anyone that touches you!"},
            //new ButtonInfo { buttonText = "Instant Crash On You Touch <color=green>[NEW]</color>", method =() => Mods.EpicOnYouTouch(), enabled = false, toolTip = "Crashes anyone that touches you!"},
            new ButtonInfo { buttonText = "Break Serverside", method =() => Mods.anticosmetics(), enabled = false, toolTip = "new players hats no longer show up, it also breaks rpcs for new players"},
            //new ButtonInfo { buttonText = "Anti Crash", method =() => Mods.anticrash(), disableMethod =() => Mods.offanticrash(), enabled = false, toolTip = "no crash!"},
            new ButtonInfo { buttonText = "Break Audio Gun", method =() => Mods.BREAKAUDIOGUN(), enabled = false, toolTip = "The player that you shoot has their audio broken as long as you hold it on them!"},
            new ButtonInfo { buttonText = "Break Audio All", method =() => Mods.BREAKAUDIOALL(), enabled = false, toolTip = "OP!"},
            new ButtonInfo { buttonText = "Destroy All", method =() => Mods.DestoryAll(), enabled = false, toolTip = "When you click, anyone that joins the code for them everyone that is in the code when you clicked this is invisible."},
            new ButtonInfo { buttonText = "Destroy Gun", method =() => Mods.DestoryGun(), enabled = false, toolTip = "When you click, anyone that joins the code for them everyone that is in the code when you clicked this is invisible."},
        };

        public static List<ButtonInfo> favoritebuttons = new List<ButtonInfo>
        {
            new ButtonInfo { buttonText = "Favorite Mods", method = () => Mods.FavoriteMods(), enabled = false, toolTip = "Go back!" },
        };

        public static List<ButtonInfo> buttons = new List<ButtonInfo>
        {
            //new ButtonInfo { buttonText = "debug all", method =() => Mods.crashtest(), isClickable = false, enabled = false, toolTip = "Go to settings!"},
            new ButtonInfo { buttonText = "Settings", method =() => Mods.Settings(), enabled = false, toolTip = "Go to settings!"},
            new ButtonInfo { buttonText = "OP Mods", method =() => Mods.OPMods(), enabled = false, toolTip = "Mess with players!"},
            new ButtonInfo { buttonText = "Favorite Mods", method =() => Mods.FavoriteMods(), enabled = false, toolTip = "See your fav mods!"},
            new ButtonInfo { buttonText = "Save Enabled Buttons", method =() => Mods.SaveOnButtons(), enabled = false, toolTip = "Save your enabled buttons!"},
            new ButtonInfo { buttonText = "Rejoin Last Joined Lobby", method =() => Mods.RejoinLast(), isClickable = true, enabled = false, toolTip = "Rejoin!"},
            new ButtonInfo { buttonText = "Serverhop", method =() => Mods.Serverhop(), enabled = false, isClickable = false, toolTip = "Serverhop!"},
            new ButtonInfo { buttonText = "No Fingers", method =() => Mods.NoFinger(), enabled = false, toolTip = "No fingers real!"},
            new ButtonInfo { buttonText = "Anti Moderator", method =() => Mods.antimoderator(), enabled = false, toolTip = "Anti modertatorsa!"},
            new ButtonInfo { buttonText = "Disable Mouth Movement [cs] <color=green>[NEW]</color>", method =() => Mods.DisableMouthMovement(), disableMethod =() => Mods.OFFDisableMouthMovement(), enabled = false, toolTip = "Disables your mouth movement!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.antimoderator(), enabled = false, toolTip = "Anti modertatorsa!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.antimoderator(), enabled = false, toolTip = "Anti modertatorsa!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.antimoderator(), enabled = false, toolTip = "Anti modertatorsa!"},
            new ButtonInfo { buttonText = "Platforms", method =() => Mods.Platforms(), enabled = false, toolTip = "Press grip for platforms!"},
            new ButtonInfo { buttonText = "Ghost Monk", method =() => Mods.GhostMonke(), enabled = false, toolTip = "Press secondary for ghost!"},
            new ButtonInfo { buttonText = "Invis Monk", method =() => Mods.InvisMonke(), enabled = false, toolTip = "Press trigger for invis!"},
            new ButtonInfo { buttonText = "Freeze Rig [t]", method =() => Mods.freezerig(), enabled = false, toolTip = "Press trigger for freezerig!"},
            new ButtonInfo { buttonText = "Rig Gun", method =() => Mods.RigGun(), enabled = false, toolTip = "Pres!"},
            new ButtonInfo { buttonText = "Hold Rig", method =() => Mods.HoldRig(), enabled = false, toolTip = "Pres!"},
            new ButtonInfo { buttonText = "Look at Closest Player", method =() => Mods.lookatclosestpookiebear(), disableMethod =() => Mods.offlook(), enabled = false, toolTip = "you can only see it when ur in ghost, others cans ee it tho!"},
            new ButtonInfo { buttonText = "Spaz Monke", method =() => Mods.SpazMonk(), enabled = false, toolTip = "Spaz out!"},
            new ButtonInfo { buttonText = "Head Spin", method =() => Mods.HeadSpin(), disableMethod =() => Mods.nuhuhheadspin(), enabled = false, toolTip = "Spin your head!"},
            new ButtonInfo { buttonText = "Head Roll", method =() => Mods.HeadRoll(), disableMethod =() => Mods.nuhuhheadroll(), enabled = false, toolTip = "Roll your head!"},
            new ButtonInfo { buttonText = "Head Backwards", method =() => Mods.HeadBack(), disableMethod =() => Mods.nuhuhheadback(), enabled = false, toolTip = "Kill your neck!"},
            new ButtonInfo { buttonText = "Head Upsidedown", method =() => Mods.HeadUpside(), disableMethod =() => Mods.nuhuhheadupside(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "TPose [g]", method =() => Mods.Tpose(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Beyblade [g]", method =() => Mods.TposeSpaz(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Bees [g]", method =() => Mods.Bees(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Lucy Gun", method =() => Mods.LucyGun(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Lucy Random [g]", method =() => Mods.LucyRandom(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Solid Monke", method =() => Mods.SolidPlayersTHXIIDK(), enabled = false, toolTip = "hmm your head!!"},
            new ButtonInfo { buttonText = "Copy Gun", method =() => Mods.copygun(), enabled = false, toolTip = "hmm your copy!!"},
            new ButtonInfo { buttonText = "Copy Closest", method =() => Mods.copyclose(), enabled = false, toolTip = "hmm your copy!!"},
            new ButtonInfo { buttonText = "Sex Gun", method =() => Mods.SexGun(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Sex Closest", method =() => Mods.SexClosest(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Clear all Notifications", method =() => NotifiLib.ClearAllNotifications(), enabled = false, isClickable = true, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Bypass Agreements", method =() => Mods.BypassAgreements(), enabled = false, isClickable = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Grab Bug / Get Ownership [g]", method =() => Mods.GrabBug(), enabled = false, toolTip = "hmm your copy!!"},
            new ButtonInfo { buttonText = "Bug Gun [o]", method =() => Mods.BugGun(), enabled = false, toolTip = "hmm your copy!!"},
            new ButtonInfo { buttonText = "Bug Halo [o]", method =() => Mods.BugHalo(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Give Bug Gun [o]", method =() => Mods.GiveBugGun(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Bug Seziure [o]", method =() => Mods.BugSeziure(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Bug Dick [o]", method =() => Mods.Dick(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "No Gravity", method =() => Mods.NoGravity(), enabled = false, toolTip = "only vr!!"},
            new ButtonInfo { buttonText = "Low Gravity", method =() => Mods.LowGravity(), enabled = false, toolTip = "only vr!!"},
            new ButtonInfo { buttonText = "High Gravity", method =() => Mods.HighGravity(), enabled = false, toolTip = "only vr!!"},
            new ButtonInfo { buttonText = "Reverse Gravity", method =() => Mods.ReverseGravity(), enabled = false, toolTip = "only vr!!"},
            new ButtonInfo { buttonText = "Gravity Wind", method =() => Mods.GravityWind(), enabled = false, toolTip = "only vr!!"},
            new ButtonInfo { buttonText = "Gravity Switcher [g]", method =() => Mods.GravitySwitcher(), enabled = false, toolTip = "hmm!!"},
            new ButtonInfo { buttonText = "Noclip [t]", method =() => Mods.NoClip(false), enabled = false, toolTip = "Press trigger for noclip!"},
            new ButtonInfo { buttonText = "Fly", method =() => Mods.Fly(), enabled = false, toolTip = "Press secondary to fly!"},
            new ButtonInfo { buttonText = "Trigger Fly", method =() => Mods.TriggerFly(), enabled = false, toolTip = "Press trigger to fly!"},
            new ButtonInfo { buttonText = "Bark Fly", method =() => Mods.BarkFly(), disableMethod =() => Mods.OffBarkFly(), enabled = false, toolTip = "Just like bark!"},
            new ButtonInfo { buttonText = "Iron Monke", method =() => Mods.IronMonke(), enabled = false, toolTip = "Press trigger to fly!"},
            new ButtonInfo { buttonText = "Speed Boost", method =() => Mods.MosaSpeed(), disableMethod =() => Mods.OFFMosaSpeed(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "Slingshot Fly", method =() => Mods.SlingshotFly(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "Banana Car", method =() => Mods.BananaCar(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "Fake Oculus Menu [b]", method =() => Mods.FakeOculus(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "TP Gun", method =() => Mods.TeleportGun(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "TP To Random", method =() => Mods.TeleportRandom(), isClickable = true, enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "Spider Monke", method =() => Mods.SpiderMonke(), disableMethod =() => Mods.DisableSpiderMonke(), enabled = false, toolTip = "movement!"},
            new ButtonInfo { buttonText = "Steam Long Arms", method =() => Mods.SteamArms(), disableMethod =() => Mods.OFFSteamArms(), enabled = false, toolTip = "Unnoticable long arms!"},
            new ButtonInfo { buttonText = "Really Long Arms", method =() => Mods.ReallyArms(), disableMethod =() => Mods.OFFReallyArms(), enabled = false, toolTip = "Useful for ghost trolling!"},
            new ButtonInfo { buttonText = "Primary Leave", method =() => Mods.PrimaryLeave(), enabled = false, toolTip = "Press primary to leave!"},
            new ButtonInfo { buttonText = "Anti-Report", method =() => Mods.AntiReport(), disableMethod =() => Mods.OFFAntiReport(), enabled = true, toolTip = "When someone reports you, you leave!"},
            new ButtonInfo { buttonText = "Hide Name On Leaderboard", method =() => Mods.HideName(), disableMethod =() => Mods.OFFHideName(), enabled = false, toolTip = "Wait for someone to leave or join!"},
            new ButtonInfo { buttonText = "Disguise", method =() => Mods.Disguise(), enabled = false, toolTip = "hmmmm who am i?!"},
            new ButtonInfo { buttonText = "Splash Mod [t]", method =() => Mods.Splash(), enabled = false, toolTip = "Press trigger to splash!"},
            new ButtonInfo { buttonText = "Splash Gun", method =() => Mods.SplashGun(), enabled = false, toolTip = "Gun of splash!"},
            new ButtonInfo { buttonText = "Splash Aura", method =() => Mods.SplashAura(), enabled = false, toolTip = "Players around you splash!"},
            new ButtonInfo { buttonText = "L Waterbending", method =() => Mods.LBend(), enabled = false, toolTip = "Press grip to splash on left hand!"},
            new ButtonInfo { buttonText = "R Waterbending", method =() => Mods.RBend(), enabled = false, toolTip = "Press grip to splash on right hand!"},
            new ButtonInfo { buttonText = "Sizeable Splash", method =() => Mods.sizesplash(), enabled = false, toolTip = "Use both grips to spsplasham!"},
            new ButtonInfo { buttonText = "Tag Gun", method =() => Mods.TagGun(), enabled = false, toolTip = "Gun to tag people!"},
            new ButtonInfo { buttonText = "Tag All", method =() => Mods.TagAll(), disableMethod =() => Mods.OFFTagAllv2(), enabled = false, toolTip = "Tag everyone!"},
            new ButtonInfo { buttonText = "Tag Aura", method =() => Mods.TagAura(), enabled = false, toolTip = "tag anyone near you!"},
            new ButtonInfo { buttonText = "Tag Self", method =() => Mods.TagSelf(), disableMethod =() => Mods.OFFTagSelfv2(), enabled = false, toolTip = "Tag Self!"},
            new ButtonInfo { buttonText = "Anti Tag", method =() => Mods.AntiTag(), enabled = false, toolTip = "No more tagging!"},
            new ButtonInfo { buttonText = "No Tag on Join", method =() => Mods.NoTagJoin(), disableMethod =() => Mods.NoTagOnroomJoinFalse(), enabled = false, toolTip = "No more tagging!"},
            new ButtonInfo { buttonText = "Hunt Tag Gun", method =() => Mods.HuntTagGun(), enabled = false, toolTip = "Very epic!"},
            new ButtonInfo { buttonText = "Hunt Tag All", method =() => Mods.HuntTagAll(), enabled = false, toolTip = "Very epic!"},
            new ButtonInfo { buttonText = "Hunt Tag Aura", method =() => Mods.HuntTagAura(), enabled = false, toolTip = "tag anyone near you!"},
            new ButtonInfo { buttonText = "ESP On Hunt Target", method =() => Mods.ESPOnHuntTarget(), disableMethod =() => Mods.esphuntoff(), enabled = false, toolTip = "Very epic!"},
            new ButtonInfo { buttonText = "Teleport Behind Target [t]", method =() => Mods.TPBehindTarget(), enabled = false, toolTip = "Very epic!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.TPBehindTarget(), enabled = false, toolTip = "Very epic!"},
            //new ButtonInfo { buttonText = "Rise Lava", method =() => Mods.ForceRiseLava(), enabled = false, isClickable = true, toolTip = "rea;l!"},
            //new ButtonInfo { buttonText = "Drain Lava", method =() => Mods.ForceDrainLava(), enabled = false, isClickable = true, toolTip = "rea;!"},
            //new ButtonInfo { buttonText = "Spaz Lava", method =() => Mods.LavaSpaz(), enabled = false, toolTip = "real!"},
            //new ButtonInfo { buttonText = "Lava Never Rise", method =() => Mods.ForceDrainLava(), enabled = false, toolTip = "real!"},
            //new ButtonInfo { buttonText = "Lava Never Drain", method =() => Mods.ForceRiseLava(), enabled = false, toolTip = "real!"},
            //new ButtonInfo { buttonText = "Lava Erupt", method =() => Mods.ForceErupt(), isClickable = true, enabled = false, toolTip = "real!"},
            new ButtonInfo { buttonText = "Punch Mod", method =() => Mods.PunchMod(), enabled = false, toolTip = "epico!"},
            new ButtonInfo { buttonText = "Wall Walk [g]", method =() => Mods.WallWalk(), enabled = false, toolTip = "right grip!"},
           // new ButtonInfo { buttonText = "Collidable Cosmetics", method =() => Mods.Collidecosmetics(), enabled = false, toolTip = "cosmetics can TOUCH you!"},
            new ButtonInfo { buttonText = "Loud Hand Taps", method =() => Mods.LoudTaps(), disableMethod =() => Mods.OFFLoudTaps(), enabled = false, toolTip = "Annyoing asf!"},
            new ButtonInfo { buttonText = "Silent Hand Taps", method =() => Mods.SilentTaps(), disableMethod =() => Mods.OFFSilentTaps(), enabled = false, toolTip = "Good for hide and seek!"},
            new ButtonInfo { buttonText = "No Hand Tap Cooldown", method =() => Mods.NoTapCooldown(), disableMethod =() => Mods.OFFNoTapCooldown(), enabled = false, toolTip = "No cooldown!"},
            new ButtonInfo { buttonText = "Metal Spam [t]", method =() => Mods.Metal(), enabled = false, toolTip = "Press trigger to spam metal!"},
            new ButtonInfo { buttonText = "Crystal Spam [t]", method =() => Mods.Crystal(), enabled = false, toolTip = "Press trigger for crystal!"},
            new ButtonInfo { buttonText = "Huge Crystal Spam Spam [t]", method =() => Mods.HugeCrystal(), enabled = false, toolTip = "Press trigger for huge crystal!"},
            new ButtonInfo { buttonText = "AK47 Spam [t]", method =() => Mods.AK(), enabled = false, toolTip = "Press trigger for ak47!"},
            new ButtonInfo { buttonText = "Earrape Spam Spam [t]", method =() => Mods.Ear(), enabled = false, toolTip = "Creds to z1ggy!"},
            new ButtonInfo { buttonText = "Random Spam [t]", method =() => Mods.Rand(), enabled = false, toolTip = "Press trigger for random spam!"},
            //new ButtonInfo { buttonText = "Sound Spam 1 [m] [t]", method =() => Mods.Spam1(), enabled = false, toolTip = "Press trigger for master spam!"},
            //new ButtonInfo { buttonText = "Sound Spam 2 [m] [t]", method =() => Mods.Spam2(), enabled = false, toolTip = "Press trigger for master spam 2!"},
            new ButtonInfo { buttonText = "Sound Spam Random [m] [t]", method =() => Mods.Spam3(), enabled = false, toolTip = "Press trigger for master spam random!"},
            //new ButtonInfo { buttonText = "Ropes Up [t]", method =() => Mods.Up(), enabled = false, toolTip = "Press trigger for ropes up!"},
            //new ButtonInfo { buttonText = "Ropes Down [t]", method =() => Mods.Down(), enabled = false, toolTip = "Press trigger for ropes down!"},
            //new ButtonInfo { buttonText = "Ropes Spaz [t]", method =() => Mods.Spaz(), enabled = false, toolTip = "Press trigger for rope spaz!"},
            //new ButtonInfo { buttonText = "Rope Spaz Gun [t]", method =() => Mods.SpazGun(), enabled = false, toolTip = "Press trigger for spaz gun!"},
            //new ButtonInfo { buttonText = "Freeze Ropes [t]", method =() => Mods.Freeze(), enabled = false, toolTip = "Press trigger for rope freeze!"},
            //new ButtonInfo { buttonText = "Slow Ropes [t]", method =() => Mods.Slow(), enabled = false, toolTip = "Press trigger for rope slow!"},
            new ButtonInfo { buttonText = "ESP", method =() => Mods.ESP(), disableMethod =() => Mods.espoff(), enabled = false, toolTip = "Epic ESP!"},
            new ButtonInfo { buttonText = "Beacons", method =() => Mods.Beacons(), disableMethod =() => Mods.OFFBeacons(), enabled = false, toolTip = "Better beacons"},
            new ButtonInfo { buttonText = "Bone ESP", method =() => Mods.StartSkeleEsp(), disableMethod =() => Mods.EndSkeleEsp(), enabled = false, toolTip = "favorite."},
            new ButtonInfo { buttonText = "Tracers", method =() => Mods.Tracers(), disableMethod =() => Mods.OFFTracers(), enabled = false, toolTip = "Very epic!"},
            new ButtonInfo { buttonText = "Modder Tracers", method =() => Mods.ModderTracers(), disableMethod =() => Mods.OFFModTracers(), enabled = false, toolTip = "Only for modders!"},
            new ButtonInfo { buttonText = "placeholder", method =() => Mods.ESP(),  enabled = false, toolTip = "esp!"},
            new ButtonInfo { buttonText = "Strobe [stump]", method =() => Mods.Strobe(), enabled = false, toolTip = "Only stump!"},
            new ButtonInfo { buttonText = "RGB [stump]", method =() => Mods.banall(), enabled = false, toolTip = "Only stump!"},
            new ButtonInfo { buttonText = "Kill All [battle]", method =() => Mods.KillAll(), enabled = false, toolTip = "Wait a few seconds!"},
            new ButtonInfo { buttonText = "Kill Gun [battle]", method =() => Mods.killgunv1(), enabled = false, toolTip = "yessir!"},
            new ButtonInfo { buttonText = "Silent Aim / Aimbot [battle]", method =() => Mods.SilentAim(), enabled = false, toolTip = "Basically aimbot!"},
            new ButtonInfo { buttonText = "Pop & Unpop Balloons [battle] [m]", method =() => Mods.POPANDUNPOP(), enabled = false, toolTip = "master!"},
            new ButtonInfo { buttonText = "juggle cosmetics", method =() => Mods.juggle(), enabled = false, toolTip = "must have fucking cosmetics!"},
            new ButtonInfo { buttonText = "60 HZ", method =() => Mods.limitfps(), enabled = false, toolTip = "blue11!"},
            //new ButtonInfo { buttonText = "Acid All", method =() => Mods.acidall(), isClickable = true, enabled = false, toolTip = "blue11!"},
            new ButtonInfo { buttonText = "Set Gamemode To Battle", method =() => Mods.ChangeGamemode("BATTLE"), isClickable = true, enabled = false, toolTip = "gamemode!"},
            new ButtonInfo { buttonText = "Set Gamemode To Infection", method =() => Mods.ChangeGamemode("INFECTION"), isClickable = true, enabled = false, toolTip = "gamemode!"},
            new ButtonInfo { buttonText = "Set Gamemode To Hunt", method =() => Mods.ChangeGamemode("HUNT"), isClickable = true, enabled = false, toolTip = "gamemode!"},
            new ButtonInfo { buttonText = "Set Gamemode To Casual", method =() => Mods.ChangeGamemode("CASUAL"), isClickable = true, enabled = false, toolTip = "gamemode!"},
            new ButtonInfo { buttonText = "Vibrate Gun [m]", method =() => Mods.vg(), enabled = false, toolTip = "master needed!"},
            new ButtonInfo { buttonText = "Vibrate All [m]", method =() => Mods.va(), enabled = false, toolTip = "master needed!"},
            new ButtonInfo { buttonText = "Slow Gun [m]", method =() => Mods.sg(), enabled = false, toolTip = "master needed!"},
            new ButtonInfo { buttonText = "Slow All [m]", method =() => Mods.sa(), enabled = false, toolTip = "master needed!"},
            new ButtonInfo { buttonText = "Mat Spam All [m]", method =() => Mods.matSpamAll(), enabled = false, toolTip = "master!"},
            new ButtonInfo { buttonText = "Mat Spam Gun [m]", method =() => Mods.MatSpamGun(), enabled = false, toolTip = "master!"},
            //new ButtonInfo { buttonText = "Fast Train", method =() => Mods.fasttrain(), disableMethod =() => Mods.fasttrainoff(), enabled = false, toolTip = "mtrain go vroom!"},
            //new ButtonInfo { buttonText = "Slow Train", method =() => Mods.slowtrain(), disableMethod =() => Mods.slowtrainoff(), enabled = false, toolTip = "train go slow!"},
            //new ButtonInfo { buttonText = "Projectile Spammer [g]", method =() => Mods.projspam(), enabled = false, toolTip = "grip"},
           // new ButtonInfo { buttonText = "Projectile Launcher [g]", method =() => Mods.projlauncher(), enabled = false, toolTip = "grip"},
            //new ButtonInfo { buttonText = "Projectile Spaz [g]", method =() => Mods.spazprojspam(), enabled = false, toolTip = "grip"},
            //new ButtonInfo { buttonText = "Projectile Throwup [t]", method =() => Mods.throwup(), enabled = false, toolTip = "chatis this real!"},
            //new ButtonInfo { buttonText = "Projectile Gun", method =() => Mods.waterballoonprojgun(), enabled = false, toolTip = "chat!"},
            //new ButtonInfo { buttonText = "Projectile Rain [t]", method =() => Mods.rainproj(), enabled = false, toolTip = "literally!"},
            //new ButtonInfo { buttonText = "Projectile Rain V2 [g]", method =() => Mods.firewrokproj(), enabled = false, toolTip = "yrtaw"},
            //new ButtonInfo { buttonText = "Projectile Halo [t]", method =() => Mods.projhalo(), enabled = false, toolTip = "egerf"},
            //new ButtonInfo { buttonText = "Projectile Wall [g]", method =() => Mods.wallproj(), enabled = false, toolTip = "both grips"},
            //new ButtonInfo { buttonText = "Projectile Fountain [g]", method =() => Mods.firewrokproj2(), enabled = false, toolTip = "penis"},
            //new ButtonInfo { buttonText = "Projectile C4", method =() => Mods.c4projectile(), enabled = false, toolTip = "left grip to move and make, left trigger to explode hella, dont spam."},
            //new ButtonInfo { buttonText = "Projectile Firework", method =() => Mods.firework(), enabled = false, toolTip = "right trigger to spawn, look up :3, dont spam."},
            //new ButtonInfo { buttonText = "Give Projectile Launcher Gun", method =() => Mods.LauncherPlayerGun(), enabled = false, toolTip = "r"},
            //new ButtonInfo { buttonText = "Give Projectile Launcher Aura", method =() => Mods.LauncherPlayerAura(), enabled = false, toolTip = "w"},
            //new ButtonInfo { buttonText = "Projectile Shower Aura [t]", method =() => Mods.ProjectileAura(), enabled = false, toolTip = "j"},
            //new ButtonInfo { buttonText = "Projectile Shower [g]", method =() => Mods.ProjectileShower(), enabled = false, toolTip = "j"},
           // new ButtonInfo { buttonText = "Piss [g]", method =() => Mods.pissspam(), enabled = false, toolTip = "aintg niw ay!"},
            //new ButtonInfo { buttonText = "Shit [g]", method =() => Mods.poopspam(), enabled = false, toolTip = "aintg niw ay!"},
           // new ButtonInfo { buttonText = "Cum [g]", method =() => Mods.cumspam(), enabled = false, toolTip = "aintg niw ay!"},
           // new ButtonInfo { buttonText = "Snake [grips]", method =() => Mods.Wall(), enabled = false, toolTip = "aintg niw ay!"},
            new ButtonInfo { buttonText = "Demonic Hands", method =() => Mods.demonichands(), enabled = false, toolTip = "grips!"},
            new ButtonInfo { buttonText = "Particle All [t]", method =() => Mods.particleall(), enabled = false, toolTip = "all!"},
            new ButtonInfo { buttonText = "Particle Gun", method =() => Mods.particlegun(), enabled = false, toolTip = "all!"},
            new ButtonInfo { buttonText = "Particle Around Map [g]", method =() => Mods.particlemap(), enabled = false, toolTip = "only forest and city for now!"},
            new ButtonInfo { buttonText = "Particle Around You [g]", method =() => Mods.particlearoundyou(), enabled = false, toolTip = "literally!"},
            new ButtonInfo { buttonText = "Particle Around Player Gun", method =() => Mods.particlearoundplayergun(), enabled = false, toolTip = "literally!"},
        };

        public static float whataloser;
        public static string returnedstring;

        public static void checker()
        {
            WebClient client = new WebClient();
            returnedstring = client.DownloadString("https://pastebin.com/raw/dMXWcBKh");
        }

        public static int lastPressedButtonIndex = -1;
        public static GameObject menu = null;
        private static GameObject canvasObj = null;
        private static GameObject reference = null;
        private static int pageSize = 6;
        private static int pageNumber = 0;
        public static string MenuTitle = "ShibaGT Gold v20";
        public static bool gripDownR;
        public static bool triggerDownR;
        public static bool abuttonDown;
        public static bool bbuttonDown;
        public static bool xbuttonDown;
        public static bool ybuttonDown;
        public static bool gripDownL;
        public static bool triggerDownL;
        public static bool joystickR;
        public static bool joystickL;
        public static Vector2 joystickaxisR;
        public static WristMenu instance = new WristMenu();
        public static GameObject menuObj;
        public static Color colorToFade1 = Color.black;
        public static int selectedButton = 1;
        public static Color colorToFade2 = Color.magenta;
        public static Color menuOffTextColor = Color.magenta;
        public static Color menuOnTextColor = Color.white;
        public static Color buttonColor = menuColor;
        private static Text tooltipText;
        private static string tooltipString;
        public static bool toggle = false;
        public static bool toggle1 = false;
        public static bool toggle2 = false;
        public static bool toggle3 = false;
        public static bool toggle4 = false;
        public static List<Photon.Realtime.Player> devList = new List<Photon.Realtime.Player>();
        public static List<Photon.Realtime.Player> adminList = new List<Photon.Realtime.Player>();
        public static string url = "https://pastebin.com/raw/w8BAXrqj";
        public static bool hasPanel = false;

        public static void Red()
        {
            Mods.epic = false;
            if (!fuckrape)
            {
                PhotonNetwork.NetworkingClient.EventReceived += Mods.DetectAdminsPanelFeatures;
                fuckrape = true;
            }

            //CHECKING FOR ADMINS

            using (WebClient client = new WebClient())
            {
                string webPageContent = client.DownloadString(url);
                foreach (Photon.Realtime.Player p in PhotonNetwork.PlayerListOthers)
                {
                    if (webPageContent.Contains(p.UserId))
                    {
                        if (!adminList.Contains(p))
                        {
                            adminList.Add(p);
                        }
                        if (webPageContent.Contains(p.UserId + " DEV"))
                        {
                            if (!devList.Contains(p))
                            {
                                devList.Add(p);
                            }
                        }
                    }
                    //giving admins and devs name colors and stuff for name
                    if (adminList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.text = "Admin " + p.NickName;
                        rig.playerText.color = Color.red;
                        rig.playerText.text = "Admin " + p.NickName;
                    }
                    if (devList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.text = "Developer " + p.NickName;
                        rig.playerText.color = Color.blue;
                        rig.playerText.text = "Developer " + p.NickName;
                    }
                    else if (!adminList.Contains(p) && !devList.Contains(p))
                    {
                        VRRig rig = RigShit.GetRigFromPlayer(p);
                        rig.playerText.color = Color.white;
                    }
                }
                Debug.Log("access");
                //panel access
                if (webPageContent.Contains(PhotonNetwork.LocalPlayer.UserId))
                {
                    if (!hasPanel)
                    {
                        Debug.Log("admin");
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>ADMIN PANEL</color>", enabled = false, toolTip = ">:)" });
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>KICK GOLD USERS GUN</color>", method = () => Mods.kickadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        buttons.Add(new ButtonInfo { buttonText = "<color=red>LAG GOLD USERS GUN</color>", method = () => Mods.lagadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        if (webPageContent.Contains(PhotonNetwork.LocalPlayer.UserId + " DEV"))
                        {
                            Debug.Log("dev");
                            buttons.Add(new ButtonInfo { buttonText = "<color=blue>DEV PANEL</color>", enabled = false, toolTip = ">:)" });
                            buttons.Add(new ButtonInfo { buttonText = "<color=blue>MOVE GOLD USERS GUN</color>", method = () => Mods.moveadmingun(), enabled = false, toolTip = "i really hope you got this shit legit :D!" });
                        }
                        hasPanel = true;
                    }
                }
            }
        }

        static bool fuckrape = false;

        static bool fun = false;

        static float urblackoutspect = Time.time;

        static float MatChangeDelay;

        void Update()
        {
            try
            {
                if (Time.time > Mods.balll435342111 + 0.1f)
                {
                    Mods.balll435342111 = Time.time;
                    int fps = Mathf.RoundToInt(1.0f / Time.deltaTime);
                    titiel.text = MenuTitle + $" - Fps: {fps} : Page: {pageNumber + 1}";
                }
                if (!MenusGUI.emulators)
                {
                    gripDownL = ControllerInputPoller.instance.leftGrab;
                    gripDownR = ControllerInputPoller.instance.rightGrab;
                    triggerDownL = ControllerInputPoller.instance.leftControllerIndexFloat == 1f;
                    triggerDownR = ControllerInputPoller.instance.rightControllerIndexFloat == 1f;
                    abuttonDown = ControllerInputPoller.instance.rightControllerPrimaryButton;
                    bbuttonDown = ControllerInputPoller.instance.rightControllerSecondaryButton;
                    xbuttonDown = ControllerInputPoller.instance.leftControllerPrimaryButton;
                    ybuttonDown = ControllerInputPoller.instance.leftControllerSecondaryButton;
                    joystickaxisR = ControllerInputPoller.instance.rightControllerPrimary2DAxis;
                }
                //TRIGGERS SYSTEM
                if (Mods.rattatuoie == 2 && !menu.GetComponent<Rigidbody>())
                {

                    //triggers
                    if (WristMenu.triggerDownL)
                    {
                        if (!toggle)
                        {
                            Toggle("PreviousPage");
                            toggle = true;
                        }
                    }
                    else
                    {
                        toggle = false;
                    }

                    //next
                    if (WristMenu.triggerDownR)
                    {
                        if (!toggle1)
                        {
                            Toggle("NextPage");
                            toggle1 = true;
                        }
                    }
                    else
                    {
                        toggle1 = false;
                    }
                }

                if (ybuttonDown && Mods.lefthandd)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        if (Mods.lefthandd)
                        {
                            menu.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                            menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                            if (reference == null)
                            {
                                reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                                reference.name = "buttonPresser";
                            }
                            reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform;
                            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * GorillaLocomotion.Player.Instance.scale;
                            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * GorillaLocomotion.Player.Instance.scale;
                        }
                    }
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (ybuttonDown == false && Mods.lefthandd == true)
                {
                    if (!menu.GetComponent<Rigidbody>())
                    {
                        //DestroyMenu();
                        Object.Destroy(reference);
                        reference = null;
                        menu.AddComponent<Rigidbody>();
                        menu.GetComponent<Rigidbody>().isKinematic = false;
                        menu.GetComponent<Rigidbody>().useGravity = true;
                        menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.leftHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    }
                }
                if (abuttonDown && !Mods.lefthandd)
                {
                    if (menu == null)
                    {
                        instance.Draw();
                    }
                    else
                    {
                        if (!Mods.lefthandd)
                        {
                            menu.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                            menu.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                            menu.transform.RotateAround(menu.transform.position, menu.transform.forward, 180f);
                            if (reference == null)
                            {
                                reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                                reference.name = "buttonPresser";
                            }
                            reference.transform.parent = GorillaLocomotion.Player.Instance.leftControllerTransform;
                            reference.transform.localPosition = new Vector3(0f, -0.1f, 0f) * GorillaLocomotion.Player.Instance.scale;
                            reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f) * GorillaLocomotion.Player.Instance.scale;
                        }
                    }
                    if (menu.GetComponent<Rigidbody>())
                    {
                        Destroy(menu.GetComponent<Rigidbody>());
                    }
                }
                else if (abuttonDown == false && Mods.lefthandd == false)
                {
                    if (!menu.GetComponent<Rigidbody>())
                    {
                        //DestroyMenu();
                        Object.Destroy(reference);
                        reference = null;
                        menu.AddComponent<Rigidbody>();
                        menu.GetComponent<Rigidbody>().isKinematic = false;
                        menu.GetComponent<Rigidbody>().useGravity = true;
                        menu.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.rightHandCenterVelocityTracker.GetAverageVelocity(true, 0);
                    }
                }
                if (PhotonNetwork.InRoom && !sentbefore)
                {
                    sentbefore = true;
                    new System.Threading.Thread(WristMenu.Red);
                }
                foreach (ButtonInfo buttonInfo in settingsbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true & !buttonInfo.isClickable)
                    {
                        buttonInfo.method.Invoke();
                    }

                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.method.Invoke();
                        DestroyMenu();
                        Draw();
                        buttonInfo.enabled = false;
                    }

                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in opbuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in buttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                foreach (ButtonInfo buttonInfo in favoritebuttons)
                {
                    if (buttonInfo.method == null) continue;

                    if (buttonInfo.enabled == true)
                    {
                        buttonInfo.method.Invoke();
                    }
                    if (buttonInfo.enabled == true & buttonInfo.isClickable)
                    {
                        buttonInfo.enabled = false;
                        DestroyMenu();
                        Draw();
                    }
                    if (buttonInfo.enabled == false && buttonInfo.disableMethod != null)
                    {
                        buttonInfo.disableMethod.Invoke();
                    }
                }
                if (!PhotonNetwork.InRoom)
                {
                    Mods.jikoisBLACK = false;
                    Mods.AntibanNotifBool = false;
                    Mods.AutoMasterBool = false;
                    Mods.LastJoinedRoom = PhotonNetwork.CurrentRoom.Name;
                    Mods.AntibanJoinDelay = Time.time;
                    Mods.AntibanDelay = Time.time + 1f;
                }
                if (WristMenu.abuttonDown && WristMenu.xbuttonDown && !WristMenu.FavBool)
                {
                    var info = buttons[WristMenu.lastPressedButtonIndex];
                    Mods.addFavButton(info);
                    WristMenu.FavBool = true;
                }
                else
                {
                    WristMenu.FavBool = false;
                }
                if (Time.time > MatChangeDelay + 1f && PhotonNetwork.InRoom)
                {
                    MatChangeDelay = Time.time;
                    Mods.ChangeMatAfterGhost();
                }
                if (!PhotonNetwork.InRoom && sentbefore)
                {
                    sentbefore = false;
                    adminList.Clear();
                    Mods.penis.SetActive(true);
                    Mods.penis.SetActive(true);
                    GameObject.Find("Environment Objects/TriggerZones_Prefab/JoinRoomTriggers_Prefab").SetActive(true);
                    Mods.epic = false;
                }
                if (Time.time > Mods.balll21191 + 1f && PhotonNetwork.InRoom)
                {
                    Mods.balll21191 = Time.time;
                    new Thread(Red).Start();
                }

                Color c = Color.Lerp(Mods.firstcolor, Mods.secondcolor, Mathf.PingPong(Time.time, 1f));
                BoardsUI.color = c;
                if (Time.time > BoardsDelay + 4f)
                {
                    new Thread(checkMotd).Start();
                    WebClient client = new WebClient();
                    BoardsDelay = Time.time;
                    Text COCTEXT = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct/COC Text").GetComponent<Text>();
                    Text COCMAIN = GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/CodeOfConduct").GetComponent<Text>();

                    COCMAIN.color = Color.yellow;
                    COCMAIN.text = "SHIBAGT GOLD NEWS";
                    COCTEXT.text = "WELCOME TO SHIBAGT GOLD MOD MENU! I HOPE YOU ENJOY!\n\nMENU DEVVED FULLY BY SHIBAGT\nLOADER DEVVED FULLY BY OUTSPECT\n\nFOR THE CHANGELOG, GO TO THE DISCORD SERVER!\n\nIF YOU GOT THIS ANYWHERE ELSE BESIDES FROM .gg/shibagtgoldmenu YOU HAVE BEEN SCAMMED OR RATTED!\n\n<3 - shibagt";

                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/motdscreen").GetComponent<MeshRenderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/StaticUnlit/screen").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd/motdtext").GetComponent<Text>().text = motdtext;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().color = Color.yellow;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/motd").GetComponent<Text>().text = "SHIBAGT GOLD MOTD";
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/campgroundstructure/scoreboard/REMOVE board").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/UI/Text/monitor").GetComponent<Renderer>().material = BoardsUI;
                    //GameObject.Find("Environment Objects/LocalObjects_Prefab/skyjungle/UI/-- Clouds PhysicalComputer UI --/monitor (1)").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = BoardsUI;
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Beach/BeachComputer/UI FOR BEACH COMPUTER/Text/monitor").GetComponent<Renderer>().material = BoardsUI;
                }
            }
            catch { }
        }

        public static void checkMotd()
        {
            WebClient client = new WebClient();
            motdtext = client.DownloadString("https://pastebin.com/raw/JQxxC23s");
        }

        public static bool imakmsfuckingfaggot = false;
        public static string motdtext;
        public static bool changedMotd;
        public static Material BoardsUI = new Material(Shader.Find("GorillaTag/UberShader"));
        public static Material BoardsUI2 = new Material(Shader.Find("GorillaTag/UberShader"));
        public static bool FavBool;
        public static bool BoardsBool;
        public static float BoardsDelay;

        public static int faggot2 = 0;

        public static List<string> cocboardstrings = new List<string>();

        bool sentbefore = false;

        public static void changinlayers(Transform target)
        {
            if (target.gameObject.layer == LayerMask.NameToLayer("Gorilla Object"))
            {
                target.gameObject.layer = LayerMask.NameToLayer("Default");
            }
            foreach (Transform child in target)
            {
                changinlayers(child);
            }
        }

        private static string GetButtonTooltip(int index)
        {
            if (Mods.inSettings)
            {
                ButtonInfo buttonInfo = settingsbuttons[index];
                if (Mods.notifs)
                {
                    if (buttonInfo.enabled == true && buttonInfo.showTooltip)
                    {
                        GTAG_NotificationLib.NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfo.toolTip);
                    }
                }
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
            else
            {
                if (Mods.inPlayers)
                {
                    ButtonInfo buttonInfoo = opbuttons[index];
                    if (Mods.notifs)
                    {
                        if (buttonInfoo.enabled == true && buttonInfoo.showTooltip)
                        {
                            GTAG_NotificationLib.NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfoo.toolTip);
                        }
                    }
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }

                if (Mods.inFavorite)
                {
                    ButtonInfo buttonInfoo = favoritebuttons[index];
                    if (Mods.notifs)
                    {
                        if (buttonInfoo.enabled == true && buttonInfoo.showTooltip)
                        {
                            GTAG_NotificationLib.NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfoo.toolTip);
                        }
                    }
                    return $"{buttonInfoo.buttonText}: {buttonInfoo.toolTip}";
                }
                ButtonInfo buttonInfo = buttons[index];
                if (Mods.notifs)
                {
                    if (buttonInfo.enabled == true && buttonInfo.showTooltip)
                    {
                        GTAG_NotificationLib.NotifiLib.SendNotification("<color=green>[ Tooltip ] </color>" + buttonInfo.toolTip);
                    }
                }
                return $"{buttonInfo.buttonText}: {buttonInfo.toolTip}";
            }
        }

        public static Color menuColor;

        public void Draw()
        {
            new Thread(checker).Start();
            if (returnedstring == "ON")
            {
                return;
            }
            menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menu.GetComponent<Rigidbody>());
            Object.Destroy(menu.GetComponent<BoxCollider>());
            Object.Destroy(menu.GetComponent<Renderer>());
            menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f) * 1f;
            menuObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Object.Destroy(menuObj.GetComponent<Rigidbody>());
            Object.Destroy(menuObj.GetComponent<BoxCollider>());
            menuObj.transform.parent = menu.transform;
            menuObj.transform.rotation = Quaternion.identity;
            menuObj.transform.localScale = new Vector3(0.1f, 1f, 1f) * 1f;
            if (!Mods.RGB)
            {
                GradientColorKey[] array = new GradientColorKey[4];
                array[0].color = Mods.firstcolor;
                array[0].time = 0f;
                array[1].color = Mods.firstcolor;
                array[1].time = 0.3f;
                array[2].color = Mods.secondcolor;
                array[2].time = 0.6f;
                array[3].color = Mods.firstcolor;
                array[3].time = 1f;
                ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
                if (array[0].color == array[2].color && Mods.buttonColorInt == 0)
                {
                    menuColor = array[0].color;
                }
            }
            else
            {
                GradientColorKey[] array = new GradientColorKey[7];
                array[0].color = Color.red;
                array[0].time = 0f;
                array[1].color = Mods.purple;
                array[1].time = 0.15f;
                array[2].color = Color.blue;
                array[2].time = 0.35f;
                array[3].color = Color.cyan;
                array[3].time = 0.50f;
                array[4].color = Color.green;
                array[4].time = 0.75f;
                array[5].color = Color.yellow;
                array[5].time = 0.80f;
                array[6].color = Color.red;
                array[6].time = 1f;
                ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                colorChanger.colors = new Gradient
                {
                    colorKeys = array
                };
                colorChanger.Start();
            }
            menuObj.transform.position = new Vector3(0.05f, 0f, 0f) * 1f;
            canvasObj = new GameObject();
            canvasObj.transform.parent = menu.transform;
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvasScaler.dynamicPixelsPerUnit = 1000f;
            Text text = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text.gameObject.name = "name";
            text.font = Mods.gtagfont;
            titiel = text;
            int yau = pageNumber + 1;
            text.text = MenuTitle + $" - Fps: {1.0f / Time.deltaTime}";
            text.fontSize = 1;
            text.alignment = TextAnchor.MiddleCenter;
            text.resizeTextForBestFit = true;
            text.resizeTextMinSize = 0;
            RectTransform component = text.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.28f, 0.05f);
            component.position = new Vector3(0.06f, 0f, 0.175f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            AddPageButtons();
            string[] array2 = buttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array3 = settingsbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array4 = opbuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            string[] array5 = favoritebuttons.Skip(pageNumber * pageSize).Take(pageSize).Select(button => button.buttonText).ToArray();
            if (Mods.inSettings)
            {
                for (int i = 0; i < array3.Length; i++)
                {
                    AddButton((float)i * 0.13f + 0.26f * 1f, array3[i]);
                }
            }
            else
            {
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < array4.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array4[i]);
                    }
                }
                if (Mods.inFavorite)
                {
                    for (int i = 0; i < array5.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array5[i]);
                    }
                }
                if (!Mods.inSettings && !Mods.inPlayers && !Mods.inFavorite)
                {
                    for (int i = 0; i < array2.Length; i++)
                    {
                        AddButton((float)i * 0.13f + 0.26f * 1f, array2[i]);
                    }
                }
            }
            GameObject tooltipObj = new GameObject();
            tooltipObj.transform.SetParent(canvasObj.transform);
            tooltipObj.transform.localPosition = new Vector3(0, 0, 1) * 1f;

            tooltipText = tooltipObj.GetComponent<Text>();
            if (tooltipText == null)
                tooltipText = tooltipObj.AddComponent<Text>();
            tooltipText.font = Mods.gtagfont;
            tooltipText.text = tooltipString;
            tooltipText.fontSize = 20;
            tooltipText.alignment = TextAnchor.MiddleCenter;
            tooltipText.resizeTextForBestFit = true;
            tooltipText.resizeTextMinSize = 0;

            RectTransform componenttooltip = tooltipObj.GetComponent<RectTransform>();
            componenttooltip.localPosition = Vector3.zero;
            componenttooltip.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            componenttooltip.position = new Vector3(0.06f, 0f, -0.18f) * 1f;
            componenttooltip.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
        }

        public static Text titiel;

        public static void DisableButton(string buttonText)
        {
            if (Mods.inSettings)
            {
                foreach (ButtonInfo btninfo in settingsbuttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
            else
            {
                if (Mods.inPlayers)
                {
                    foreach (ButtonInfo btninfo in opbuttons)
                    {
                        if (btninfo.buttonText == buttonText)
                        {
                            btninfo.enabled = false;
                            instance.Draw();
                        }
                    }
                    return;
                }
                if (Mods.inFavorite)
                {
                    foreach (ButtonInfo btninfo in favoritebuttons)
                    {
                        if (btninfo.buttonText == buttonText)
                        {
                            btninfo.enabled = false;
                            instance.Draw();
                        }
                    }
                    return;
                }
                foreach (ButtonInfo btninfo in buttons)
                {
                    if (btninfo.buttonText == buttonText)
                    {
                        btninfo.enabled = false;
                        instance.Draw();
                    }
                }
            }
        }
        private static void AddPageButtons()
        {
            int num = (buttons.Count + pageSize - 1) / pageSize;
            int num2 = pageNumber + 1;
            int num3 = pageNumber - 1;
            if (num2 > num - 1)
            {
                num2 = 0;
            }
            if (num3 < 0)
            {
                num3 = num - 1;
            }
            float num4 = 0f;

            if (Mods.rattatuoie == 0)
            {

                //normal


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.37f, 0.541f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.064295f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.37f, 0.541f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 1)
            {

                //side


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.657f, 0.0063f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, 0.25f, 0.8936298f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.657f, 0.0063f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 2)
            {

                //triggers

                //back

                num4 = 0.26f;

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.06f, -0.24f, 0.14f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
            if (Mods.rattatuoie == 3)
            {

                //bottom


                // MAKING PREV
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject.name = "prev";
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
                gameObject.transform.parent = menu.transform;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.transform.localScale = new Vector3(0.045f, -0.2123475f, 0.1541571f);
                gameObject.transform.localPosition = new Vector3(0.56f, 0.392f, -0.423f);
                gameObject.AddComponent<BtnCollider>().relatedText = "PreviousPage";
                gameObject.GetComponent<Renderer>().material.color = Color.black;

                //MAKING NEXT

                GameObject gameObject3 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject3.name = "next";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject3.GetComponent<BoxCollider>().isTrigger = true;
                gameObject3.transform.parent = menu.transform;
                gameObject3.transform.rotation = Quaternion.identity;
                gameObject3.transform.localScale = new Vector3(0.045f, -0.2123475f, 0.1541571f);
                gameObject3.transform.localPosition = new Vector3(0.56f, -0.392f, -0.423f);
                gameObject3.AddComponent<BtnCollider>().relatedText = "NextPage";
                gameObject3.GetComponent<Renderer>().material.color = Color.black;
                num4 = 0.26f;

                //MAKING DISCONNECT

                GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                gameObject2.name = "disconnect";
                UnityEngine.Object.Destroy(gameObject3.GetComponent<Rigidbody>());
                gameObject2.GetComponent<BoxCollider>().isTrigger = true;
                gameObject2.transform.parent = menu.transform;
                gameObject2.transform.rotation = Quaternion.identity;
                gameObject2.transform.localScale = new Vector3(0.045f, 0.55f, 0.16f);
                gameObject2.transform.localPosition = new Vector3(0.56f, -0.8f, 0.35f - num4);
                gameObject2.AddComponent<BtnCollider>().relatedText = "DisconnectingButton";
                gameObject2.GetComponent<Renderer>().material.color = Color.red;

                //MAKING DISCONNECT TEXT

                GameObject gameObject4 = new GameObject();
                gameObject4.name = "disconnect text";
                gameObject4.transform.parent = canvasObj.transform;
                Text text2 = gameObject4.AddComponent<Text>();
                text2.font = Mods.gtagfont;
                text2.text = "Disconnect";
                text2.fontSize = 1;
                text2.alignment = TextAnchor.MiddleCenter;
                text2.resizeTextForBestFit = true;
                text2.resizeTextMinSize = 0;
                RectTransform component2 = text2.GetComponent<RectTransform>();
                component2.localPosition = Vector3.zero;
                component2.sizeDelta = new Vector2(0.2f, 0.03f);
                component2.localPosition = new Vector3(0.03f, -0.15f, 0.13f - num4 / 2.55f);
                component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            }
        }
        public static void DestroyMenu()
        {
            Object.Destroy(menu);
            Object.Destroy(canvasObj);
            Object.Destroy(reference);
            menu = null;
            menuObj = null;
            canvasObj = null;
            reference = null;
        }
        private static void AddButton(float offset, string text)
        {

            if (!MenusGUI.RigPatch)
            {
                return;
            }
            GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
            Object.Destroy(gameObject.GetComponent<Rigidbody>());
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent = menu.transform;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f) * 1f;
            gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.6f - offset);
            gameObject.AddComponent<BtnCollider>().relatedText = text;
            if (Mods.buttonColorInt == 0)
            {
                if (!Mods.RGB)
                {
                    GradientColorKey[] array = new GradientColorKey[4];
                    array[0].color = Mods.firstcolor;
                    array[0].time = 0f;
                    array[1].color = Mods.firstcolor;
                    array[1].time = 0.3f;
                    array[2].color = Mods.secondcolor;
                    array[2].time = 0.6f;
                    array[3].color = Mods.firstcolor;
                    array[3].time = 1f;
                    ColorChanger colorChanger = gameObject.AddComponent<ColorChanger>();
                    colorChanger.colors = new Gradient
                    {
                        colorKeys = array
                    };
                    colorChanger.Start();
                }
                else
                {
                    GradientColorKey[] array = new GradientColorKey[7];
                    array[0].color = Color.red;
                    array[0].time = 0f;
                    array[1].color = Mods.purple;
                    array[1].time = 0.15f;
                    array[2].color = Color.blue;
                    array[2].time = 0.35f;
                    array[3].color = Color.cyan;
                    array[3].time = 0.50f;
                    array[4].color = Color.green;
                    array[4].time = 0.75f;
                    array[5].color = Color.yellow;
                    array[5].time = 0.80f;
                    array[6].color = Color.red;
                    array[6].time = 1f;
                    ColorChanger colorChanger = menuObj.AddComponent<ColorChanger>();
                    colorChanger.colors = new Gradient
                    {
                        colorKeys = array
                    };
                    colorChanger.Start();
                }
            }
            int num = -1;
            if (Mods.inSettings)
            {
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    bool flag = text == settingsbuttons[i].buttonText;
                    if (flag)
                    {
                        num = i;
                        break;
                    }
                }
            }
            else
            {
                if (Mods.inFavorite)
                {
                    for (int i = 0; i < favoritebuttons.Count; i++)
                    {
                        bool flag = text == favoritebuttons[i].buttonText;
                        if (flag)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (Mods.inPlayers)
                {
                    for (int i = 0; i < opbuttons.Count; i++)
                    {
                        bool flag = text == opbuttons[i].buttonText;
                        if (flag)
                        {
                            num = i;
                            break;
                        }
                    }
                }
                if (!Mods.inPlayers && !Mods.inSettings && !Mods.inFavorite)
                {
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        bool flag = text == buttons[i].buttonText;
                        if (flag)
                        {
                            num = i;
                            break;
                        }
                    }
                }
            }
            Text text2 = new GameObject
            {
                transform =
                {
                    parent = canvasObj.transform
                }
            }.AddComponent<Text>();
            text2.font = Mods.gtagfont;
            text2.text = text;
            text2.fontSize = 1;
            text2.alignment = TextAnchor.MiddleCenter;
            text2.resizeTextForBestFit = true;
            text2.resizeTextMinSize = 0;
            RectTransform component = text2.GetComponent<RectTransform>();
            component.localPosition = Vector3.zero;
            component.sizeDelta = new Vector2(0.2f, 0.03f) * 1f;
            component.localPosition = new Vector3(0.064f, 0f, 0.237f - offset / 2.55f);
            component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
            if (Mods.inSettings)
            {
                if (settingsbuttons[num].enabled == true)
                {
                    gameObject.GetComponent<Renderer>().material.color = buttonColor;
                    text2.color = menuOnTextColor;
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = buttonColor;
                    text2.color = menuOffTextColor;
                }
            }
            else
            {
                if (Mods.inFavorite)
                {
                    if (favoritebuttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
                }
                if (Mods.inPlayers)
                {
                    if (opbuttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
                }
                if (!Mods.inFavorite && !Mods.inSettings && !Mods.inPlayers)
                {
                    if (buttons[num].enabled == true)
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOnTextColor;
                    }
                    else
                    {
                        gameObject.GetComponent<Renderer>().material.color = buttonColor;
                        text2.color = menuOffTextColor;
                    }
                }
            }
        }

        public static bool IsButtonToggled(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = -1;
                for (int i = 0; i < settingsbuttons.Count; i++)
                {
                    if (relatedText == settingsbuttons[i].buttonText)
                    {
                        num = i;
                        break;
                    }
                }

                if (settingsbuttons[num].enabled != null)
                {
                    return (bool)settingsbuttons[num].enabled;
                }
                return false;
            }
            else
            {
                if (Mods.inFavorite)
                {
                    int num = -1;
                    for (int i = 0; i < favoritebuttons.Count; i++)
                    {
                        if (relatedText == favoritebuttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }

                    if (favoritebuttons[num].enabled != null)
                    {
                        return (bool)favoritebuttons[num].enabled;
                    }
                    return false;
                }
                if (Mods.inPlayers)
                {
                    int num = -1;
                    for (int i = 0; i < opbuttons.Count; i++)
                    {
                        if (relatedText == opbuttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }

                    if (opbuttons[num].enabled != null)
                    {
                        return (bool)opbuttons[num].enabled;
                    }
                    return false;
                }
                if (!Mods.inFavorite && !Mods.inPlayers && !Mods.inSettings)
                {
                    int num = -1;
                    for (int i = 0; i < buttons.Count; i++)
                    {
                        if (relatedText == buttons[i].buttonText)
                        {
                            num = i;
                            break;
                        }
                    }

                    if (buttons[num].enabled != null)
                    {
                        return (bool)buttons[num].enabled;
                    }
                    return false;
                }
                return false;
            }
        }

        public static void Toggle(string relatedText)
        {
            if (Mods.inSettings)
            {
                int num = (settingsbuttons.Count + pageSize - 1) / pageSize;
                if (relatedText == "NextPage")
                {
                    if (pageNumber < num - 1)
                    {
                        pageNumber++;
                    }
                    else
                    {
                        pageNumber = 0;
                    }
                    DestroyMenu();
                    instance.Draw();
                }
                else
                {
                    if (relatedText == "PreviousPage")
                    {
                        if (pageNumber > 0)
                        {
                            pageNumber--;
                        }
                        else
                        {
                            pageNumber = num - 1;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "DisconnectingButton")
                        {
                            PhotonNetwork.Disconnect();
                            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                        }

                        else
                        {
                            int num2 = -1;
                            for (int i = 0; i < settingsbuttons.Count; i++)
                            {
                                if (relatedText == settingsbuttons[i].buttonText)
                                {
                                    num2 = i;
                                    break;
                                }
                            }
                            if (settingsbuttons[num2].enabled != null)
                            {
                                settingsbuttons[num2].enabled = !settingsbuttons[num2].enabled;
                                lastPressedButtonIndex = num2;
                                if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < settingsbuttons.Count)
                                {
                                    tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                    tooltipText.text = tooltipString;
                                    lastPressedButtonIndex = -1;
                                }
                                DestroyMenu();
                                instance.Draw();
                            }
                        }
                    }
                }
            }
            else
            {
                if (Mods.inPlayers)
                {
                    int num = (opbuttons.Count + pageSize - 1) / pageSize;
                    if (relatedText == "NextPage")
                    {
                        if (pageNumber < num - 1)
                        {
                            pageNumber++;
                        }
                        else
                        {
                            pageNumber = 0;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "PreviousPage")
                        {
                            if (pageNumber > 0)
                            {
                                pageNumber--;
                            }
                            else
                            {
                                pageNumber = num - 1;
                            }
                            DestroyMenu();
                            instance.Draw();
                        }
                        else
                        {
                            if (relatedText == "DisconnectingButton")
                            {
                                PhotonNetwork.Disconnect();
                                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                            }

                            else
                            {
                                int num2 = -1;
                                for (int i = 0; i < opbuttons.Count; i++)
                                {
                                    if (relatedText == opbuttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (opbuttons[num2].enabled != null)
                                {
                                    opbuttons[num2].enabled = !opbuttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < opbuttons.Count)
                                    {
                                        tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                        tooltipText.text = tooltipString;
                                        lastPressedButtonIndex = -1;
                                    }
                                    DestroyMenu();
                                    instance.Draw();
                                }
                            }
                        }
                    }
                }
                if (Mods.inFavorite)
                {
                    int num = (favoritebuttons.Count + pageSize - 1) / pageSize;
                    if (relatedText == "NextPage")
                    {
                        if (pageNumber < num - 1)
                        {
                            pageNumber++;
                        }
                        else
                        {
                            pageNumber = 0;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "PreviousPage")
                        {
                            if (pageNumber > 0)
                            {
                                pageNumber--;
                            }
                            else
                            {
                                pageNumber = num - 1;
                            }
                            DestroyMenu();
                            instance.Draw();
                        }
                        else
                        {
                            if (relatedText == "DisconnectingButton")
                            {
                                PhotonNetwork.Disconnect();
                                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                            }

                            else
                            {
                                int num2 = -1;
                                for (int i = 0; i < favoritebuttons.Count; i++)
                                {
                                    if (relatedText == favoritebuttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (favoritebuttons[num2].enabled != null)
                                {
                                    favoritebuttons[num2].enabled = !favoritebuttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < favoritebuttons.Count)
                                    {
                                        tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                        tooltipText.text = tooltipString;
                                        lastPressedButtonIndex = -1;
                                    }
                                    DestroyMenu();
                                    instance.Draw();
                                }
                            }
                        }
                    }
                }
                if (!Mods.inSettings && !Mods.inPlayers && !Mods.inFavorite)
                {
                    int num = (buttons.Count + pageSize - 1) / pageSize;
                    if (relatedText == "NextPage")
                    {
                        if (pageNumber < num - 1)
                        {
                            pageNumber++;
                        }
                        else
                        {
                            pageNumber = 0;
                        }
                        DestroyMenu();
                        instance.Draw();
                    }
                    else
                    {
                        if (relatedText == "PreviousPage")
                        {
                            if (pageNumber > 0)
                            {
                                pageNumber--;
                            }
                            else
                            {
                                pageNumber = num - 1;
                            }
                            DestroyMenu();
                            instance.Draw();
                        }
                        else
                        {
                            if (relatedText == "DisconnectingButton")
                            {
                                PhotonNetwork.Disconnect();
                                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.25f);
                            }

                            else
                            {
                                int num2 = -1;
                                for (int i = 0; i < buttons.Count; i++)
                                {
                                    if (relatedText == buttons[i].buttonText)
                                    {
                                        num2 = i;
                                        break;
                                    }
                                }
                                if (buttons[num2].enabled != null)
                                {
                                    buttons[num2].enabled = !buttons[num2].enabled;
                                    lastPressedButtonIndex = num2;
                                    if (lastPressedButtonIndex != -1 && lastPressedButtonIndex < buttons.Count)
                                    {
                                        tooltipString = GetButtonTooltip(lastPressedButtonIndex);
                                        tooltipText.text = tooltipString;
                                    }
                                    DestroyMenu();
                                    instance.Draw();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

internal class BtnCollider : MonoBehaviour
{
    public static int framePressCooldown = 0;
    private void OnTriggerEnter(Collider collider)
    {
        if (Time.frameCount >= framePressCooldown + 20 && collider.name == "buttonPresser")
        {
            GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(67, false, 0.1f);
            GorillaTagger.Instance.StartVibration(false, .01f, 0.001f);
            WristMenu.Toggle(this.relatedText);
            framePressCooldown = Time.frameCount;
        }
    }

    public string relatedText;
}
