// OOberMage.cs
//
// Dec 01 2007 RAGE - Release 1.000.000
//                    * Converted UberMage to Inheritance Model
// Dec 02 2007 RAGE - Release 1.003.000
//                    * OOberClass - Tweaked IsMounted to NOT count Ghost Wolf form
//                    * OOberClass - Tweaked Potion Drink to refresh health and mana values
//                    * OOberClass - Added Approach routines
//                    * OOberClass - Added Logic to prevent chasing too far
//                    * OOberClass - Changed Wand API
// Dec 02 2007 RAGE - Release 1.004.001
//                    * OOberClass - Fixed Drinking Health Potions
//                    * OOberClass - Added option to eat/drink together
//                    * Set class to eat and drink together
//                    * Lowered conjure food/drink to 5 of each
//                    * Added option to Frost Nova with Evocation
//                    * Added logic to skip Frost Nova with casters
// Dec 05 2007 RAGE - Release 1.005.001
//                    * OOberClass - Tweaked Approach code to not get TOO close
//                    * OOberClass - Added Charger to Mount Detection
//                    * OOberClass - Added PreDrink routine for potions
// Dec 05 2007 RAGE - Release 1.006.002
//                    * OOberClass - Tweaked TweakMelee
//                    * OOberClass - Tweaked Approach Target
//                    * Added clean disconnect from remote
// Dec 07 2007 RAGE - Release 1.007.003
//                    * OOberClass - Tweaked IsRunningAway logic to avoid null reference
//                    * Removed wait for target to engage
// Dec 08 2007 RAGE - Release 1.008.003
//                    * OOberClass - Replaced CastSpell with OOberCast :-)
//                    * OOberClass - Fixed exception when stopping classes that don't used GRemote.dll
// Dec 10 2007 RAGE - Release 1.010.003
//                    * OOberClass - Fixed the Inching Forward Issue
//                    * OOberClass - Fixed Spell Delay (so it is actually used doh!)
//                    * OOberClass - Structure Change preparing for OOberPatrol
// Dec 10 2007 RAGE - Release 1.011.004
//                    * OOberClass - Added Tracking Areas Travelled
//                    * OOberClass - Added check for stop and start Wand
//                    * Added Frostbite Detection
// Dec 10 2007 RAGE - Release 1.012.005
//                    * OOberClass - Added check for ready after stop Wand
//                    * OOberClass - Added detecting Frostwolf Howler for mounts
//                    * OOberClass - Added option to enter name of mount... Just in case :)
//                    * OOberClass - Added Obstacle Detection (NOT avoidance... yet)
//                    * Fixed backing up from frostbite mob, when not in melee distance
// Dec 14 2007 RAGE - Release 1.013.006
//                    * OOberClass - Expanded TerrainManager to Track Z data
//                    * OOberClass - Changed Mesh size to cover less area but more data
//                    * OOberClass - Tweaked eat and drink logic to retry
//                    * OOberClass - Tweaked CheckCommonCombatResult to avoid null reference
//                    * OOberClass - Moved most control messages from Log to Debug
//                    * Added option to pull with Arcane Blast
//                    * Added option to use Arcane Blast in combat
// Dec 16 2007 RAGE - Release 1.014.006
//                    * OOberClass - Added option to decide where to send class messages
//                    * OOberClass - Tweaked KillTargetReady to avoid early calls
//                    * OOberClass - Replaced Target.Face with custom routine
//                    * OOberClass - Fixed Avoid Adds triggering TargetIsRunning logic
//                    * OOberClass - Tweaked running logic to not wander too far from closest waypoint
//                    * OOberClass - Tweaked Start Attack to ignore pets
// Dec 20 2007 RAGE - Release 1.015.007
//                    * OOberClass - Fixed bug in SmartHeal for Null exception
//                    * OOberClass - Added option to delay checkstate logic
//                    * OOberClass - Extended trinkets from 2 to 6
//                    * OOberclass - Added events to trinket triggers
//                    * OOberclass - Tweaked ActivePVP to return control to Glider
//                    * Fixed targetting non-existant poly'd add
//                    * Added option to skip panic logic
// Dec 22 2007 RAGE - Release 1.016.007
//                    * OOberClass - Added Logic to leave form before mounting
//                    * OOberClass - Added Logic to stop chasing player if it moves to far out of pull distance
// Dec 27 2007 RAGE - Release 1.018.008
//                    * OOberClass - Release all keys when done with combat
//                    * OOberClass - Lowered Facing timeout
//                    * OOberClass - Added routine to keep target in front when in melee
//                    * OOberClass - Fixeed Distance Mount to work correctly
//                    * OOberClass - Added new virtual for party buffs
//                    * OOberclass - Added new Pet Detection Routine
//                    * Added small delay after mana shield to allow time for evocation
//                    * Changed Combustion detection method
//                    * Added melee range check for blast wave
// Dec 27 2007 RAGE - Release 1.019.009
//                    * OOberClass - Added PVP option to switch melee targets for closest one
//                    * OOberClass - Tweaked IsKeyReady to double check
//                    * OOberClass - Added option to use simple/oober Face
//                    * OOberClass - Added option to use simple/oober Approach
//                    * OOberClass - Tweaked GetIntoMeleeSight
//                    * OOberClass - Tweaked IsInFrontOfMe
//                    * OOberClass - Tweaked CastSpell GCD Check
//                    * OOberClass - Added IsImmobilized routine
//                    * Added Option to Apply Oil to weapons
// Jan 01 2008 RAGE - Release 1.022.009
//                    * OOberClass - Tweaked Approach Logic
//                    * OOberClass - Miscellaneous Tweaks to OOberFace 
//                    * OOberClass - Lowered PVP Buff Delay to 30 seconds
//                    * OOberClass - Miscellaneous Tweaks for PVP 
//                    * OOberClass - Miscellaneous Tweaks for PVP Healing
//                    * OOberClass - Added New Dodge-And-Move (DAM) logic for Melee
//                    * OOberClass - Added Caching for Wand State
// Jan 03 2008 RAGE - Release 1.023.009
//                    * OOberClass - Fixed trying to sit when not really resting
//                    * OOberClass - Tweaked OOberCast to wait for GCD correctly
//                    * OOberClass - Tweaked DAM to not think target is running
//                    * OOberClass - Tweaked DAM to only react to players
//                    * OOberClass - Tweaked IsPet to handle Totems
// Jan 11 2008 RAGE - Release 1.024.010
//                    * OOberClass - Added routine to check number of adds within specified range
//                    * OOberClass - Expanded One Shot Kill to kill all hostiles within Pull range
//                    * OOberClass - Shuffled order of delays in OOberCast
//                    * OOberClass - Fixed bug where target is ignored if it attacks your pet first
//                    * OOberClass - Tweaked Wand Logic
//                    * OOberClass - Added logic to Face friend for Heal/Buffs
//                    * Skip Ice Barrier if mounted
// Jan 15 2008 RAGE - Release 1.025.011
//                    * OOberClass - Added logic to ignore mobs that are too high
//                    * OOberClass - Upgraded OOberFace logic to be smoother
//                    * OOberClass - Added CastBuff Method
//                    * OOberClass - Added own logic to determine Ambush
//                    * Added check to buff when not in combat
//                    * Skip buffs if mounted
//                    * Skip Ice Lance when about to evocate (after frost nova)
//                    * Send in Elemental for next fight if we still got him
// Jan 20 2008 RAGE - Release 1.026.012
//                    * OOberClass - Changed Movement Control
//                    * Tweaked Main Casting loop
//                    * Fixed Casting Icy Veins when option is disabled
// Jan 24 2008 RAGE - Release 1.027.013
//                    * OOberClass - Check if Friendly is Too High (vertically) to buff
//                    * Fixed Casting Blast Wave
//                    * Fixed Casting Flame Strike
//                    * Fixed Poly for Adds (Thx Jazha!)
// Jan 27 2008 RAGE - Release 1.028.013
//                    * OOberClass - Tweaked OOberApproach to stop Circling Target
//                    * OOberClass - Check If Pet is in Combat when doing finalstate
// Jan 29 2008 RAGE - Release 1.029.013
//                    * OOberClass - Added option to avoid Grouped Mobs
// Feb 02 2008 RAGE - Release 1.029.014
//                    * Added logic to back up after frost nova before evocation
// Feb 11 2008 RAGE - Release 1.031.015
//                    * OOberClass - Tweaked "Avoid Groups" logic to recognize Ambush
//                    * OOberClass - Tweaked "Avoid Groups" initial value to 15 yards
//                    * OOberClass - Tweaked KillTargetReady for OneKill mode
//                    * OOberClass - Tightened logic to reduce circling
//                    * Fixed problem with Poly Adds
//                    * Tweaked Check for Frost Nova before evocation
// Feb 11 2008 RAGE - Release 1.031.016
//                    * Added Logic to run up for Cone of Cold finisher
// Feb 11 2008 RAGE - Release 1.032.017
//                    * OOberClass - Added Hook for CastSpell interrupt
//                    * OOberclass - Tweaked Check Combat State to refresh pet for check of adds
//                    * Added Logic To Interrupt Pull if ambushed while casting
// Feb 23 2008 RAGE - Release 1.033.017
//                    * OOberClass - Tweaked OOberApproach to circle less
//                    * OOberClass - Wrapped GetActionInventory with exception handler (to Handle User Errors)
//                    * OOberClass - Tweaked CombatResult to detect "Pet still fighting" better
// Feb 27 2008 RAGE - Release 2.034.017
//                    * OOberClass - Miscellaneous Restructuring preparing for PPather
// Mar 05 2008 RAGE - Release 2.035.017
//                    * OOberClass - Upgraded to PPather 0.31
//                    * OOberClass - Fixed Circling Bug (yet again!)
//////////////////////////////////////////////////////////////////////////
//
// For more information on custom classes, please visit:
//
//          http://mmoglider.com/customclasses
//

#define NOPATHERENABLED

#if PATHERENABLED
//!Reference: WowTriangles.dll
//!Reference: System.Drawing.dll
using WowTriangles;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
#endif

using System;
using System.Threading;
using Glider.Common.Objects;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Collections.Generic;

//!Class: Glider.Common.Objects.OOberMage

namespace Glider.Common.Objects
{
    public enum IceBarrierMode { None = 0, Always = 1, OnHit = 2, Panic = 3 };
    public enum Finisher { None = 0, Wand = 1, Scorch = 2, ConeOfCold = 3 };

    public class OOberMage : OOberClass
    {
        #region Class Constants

        const double PULL_MIN_DISTANCE = 20.0;  // Don't try to use slow pull spell if closer than this.
        const double WAND_MAX_RANGE = 30.0;
        const double COUNTERSPELL_RANGE = 30.0;

        int[] BUFFID_COMBUSTION = { 11129, 28682, 29977 };
        int[] ARCANEINTELLECT =
            { 1459,1460,1461,1472,1473,1474,1475,3065,3066,10156,
              10157,10158,13326,16876,27126,27393,36880,39235,
              23028,23030,27127,27394,40374 //Arcane Brilliance
            };
        int[] FROSTARMOR =
            { 168,484,1174,1200,6116,6643,7300,7301,12544,12556,15784,18100,31256 };
        int[] ICEARMOR =
            { 506,844,1214,1228,7302,7320,10219,10220,10221,10222,27124,27391,36881 };
        int[] MAGEARMOR =
            { 6117,6121,22782,22783,22784,22785,27125,27392 };
        int[] MOLTENARMOR =
            { 30482,30663,34913,35915,35916 };
        int[] CLEARCASTING =
            { 12536,16246,16870,34754 };
        int[] MANASHIELD =
            { 1463,1481,8494,8495,8496,8497,10191,10192,10193,
              10194,10195,10196,17740,17741,27131,27398,29880,
              30973,31635,35064,38151, //Regular
              11252,12605,37424 //Improved
            };
        int[] DAMPENMAGIC =
            { 604,1266,5305,8450,8451,8452,8453,10173,10174,
              10175,10176,33944,33945,41478 };
        int[] AMPLIFYMAGIC =
            { 1008,1267,8455,8456,10169,10170,10171,10172,
              27130,27397,33946,33947 };
        int FROSTBITE = 12494;

        bool PULLING;

        #endregion

        #region Mage Properties/config
        GSpellTimer IceBarrier = new GSpellTimer(30 * 1000, true);         // Actual cooldown on casting.
        GSpellTimer Manastone = new GSpellTimer(3 * 60 * 1000, true);      // Cooldown between using mana stones.
        GSpellTimer Fireblast;
        GSpellTimer Evocation = new GSpellTimer(8 * 60 * 1000, true);
        GSpellTimer FoodConjure = new GSpellTimer(60 * 1000, true);        // Futility timer for conjuring to avoid looping action.
        GSpellTimer WaterConjure = new GSpellTimer(60 * 1000, true);       // Futility timer for conjuring to avoid looping action.
        GSpellTimer POMCooldown = new GSpellTimer(3 * 60 * 1000, true);
        GSpellTimer IcyVeinsCooldown = new GSpellTimer(3 * 60 * 1000, true);
        GSpellTimer APCooldown = new GSpellTimer(3 * 60 * 1000, true);  
        GSpellTimer Polyd = new GSpellTimer(50 * 1000, true);
        GSpellTimer Flamestrike = new GSpellTimer(8 * 1000, true);
        GSpellTimer Blastwave = new GSpellTimer(6 * 1000, true);
        GSpellTimer Blizzard = new GSpellTimer(8 * 1000, true);
        GSpellTimer ConeOfCold = new GSpellTimer(11 * 1000, true);
        GSpellTimer DragonsBreath = new GSpellTimer(20 * 1000, true);
        GSpellTimer Pyroblast = new GSpellTimer(12 * 1000, true);
        GSpellTimer FrostWard = new GSpellTimer(30 * 1000, true);
        GSpellTimer FireWard = new GSpellTimer(30 * 1000, true);
        GSpellTimer WaterElemental = new GSpellTimer(3 * 60  * 1000, true);
        GSpellTimer ManaTap = new GSpellTimer(30 * 1000, true);
        GSpellTimer ArcaneTorrent = new GSpellTimer(3 * 60 * 1000, true);
        GSpellTimer ArcaneBlast = new GSpellTimer(8 * 1000, true);
        int ABCount;

        bool UseStoneInv;     // Read inventory to determine if we have a manastone?
        bool UseOilMain;
        bool UseCounterspell;
        bool UseDampen;
        bool UseManastones;
        bool WaitOnPull;
        bool UsePoly;
        bool UseCombustion;
        bool UseFrostNova;
        bool ApproachFireblast;
        bool SaveFireblast;
        bool UseEvocation;
        bool UseFlamestrike;
        bool UseBlastwave;
        bool UseBlizzard;
        bool UseFlamestrikeAdds;
        bool UseBlastwaveAdds;
        bool UseBlizzardAdds;
        bool UseFireblast;
        bool UseArcaneIntellect;
        bool UseMSwithEvocation;
        bool UseFNwithEvocation;
        bool UseIcyVeins;
        bool LowManaWand;
        bool BloodElf;
        bool NeverPanic;
        int ManaTapCharges=0;
        string UseFrostWard = "Never";
        string UseFireWard = "Never";
        string UseDragonsBreath = "Never";
        string UseWaterElemental = "Never";
        string UseArcaneBlast = "Never";
        int FireblastDistance;
        IceBarrierMode ShieldMode;
        Finisher FinishMode;
        double FinishLife;
        double CounterspellLife;
        double ShieldLife;
        double ManaShieldLife;

        bool GotStone;
        long PolyGUID;
        double StartLife;

        bool ALWAYSPULL = false;
        string PULLWITH = "Frostbolt";
        string CLEARCASTINGWITH = "Any";
        bool USEFROSTBOLT = false;
        bool USEFIREBALL = true;
        bool USEARCANEMISSILES = false;
        bool USEPYROBLAST = false;
        bool USECONEOFCOLD = false;
        bool USEARCANEEXPLOSION = false;
        bool POLYINPANIC = false;
        bool USEICELANCE = false;
        string ARMORPRIMARY = "None";
        string ARMORLOWMANA = "None";
        string ARMORADDS = "None";
        string POMWITH = "None";
        string USEARCANEPOWER = "Never";
        double EVOCATIONTRIGGER = .50;
        bool USEAMPLIFYMAGIC = false;
        bool USEMELEE = false;
        double FROSTNOVALIFE = .35;

        #endregion

        #region Custom Config Dialog

        public override void CreateDefaultConfig()
        {
            Context.SetConfigValue("Mage.PullDistance", "30", false);
            Context.SetConfigValue("UberMage.FireblastCooldownSec", "8", false);
            Context.SetConfigValue("UberMage.UseFrostNova", "True", false);
            Context.SetConfigValue("UberMage.ApproachFireblast", "True", false);
            Context.SetConfigValue("UberMage.SaveFireblast", "False", false);
            Context.SetConfigValue("UberMage.UseCounterspell", "False", false);
            Context.SetConfigValue("UberMage.UseCombustion", "False", false);
            Context.SetConfigValue("UberMage.UsePoly", "False", false);
            Context.SetConfigValue("UberMage.UseEvocation", "False", false);
            Context.SetConfigValue("UberMage.WaitOnPull", "True", false);
            Context.SetConfigValue("UberMage.UseDampen", "False", false);
            Context.SetConfigValue("UberMage.UseManaStones", "False", false);
            Context.SetConfigValue("UberMage.IceBarrierMode", "Never", false);
            Context.SetConfigValue("UberMage.FinishLife", "10", false);
            Context.SetConfigValue("UberMage.CounterspellLife", "40", false);
            Context.SetConfigValue("UberMage.FireblastDistance", "20", false);
            Context.SetConfigValue("UberMage.FinisherMode", "None", false);
            Context.SetConfigValue("UberMage.ShieldLife", "50", false);
            Context.SetConfigValue("UberMage.AlwaysPull", "False", false);
            Context.SetConfigValue("UberMage.PullWith", "Frostbolt", false);
            Context.SetConfigValue("UberMage.UseArcaneMissiles", "False", false);
            Context.SetConfigValue("UberMage.UsePyroblast", "False", false);
            Context.SetConfigValue("UberMage.ClearcastingWith", "Any", false);
            Context.SetConfigValue("UberMage.ArmorPrimary", "None", false);
            Context.SetConfigValue("UberMage.ArmorLowMana", "None", false);
            Context.SetConfigValue("UberMage.ArmorAdds", "None", false);
            Context.SetConfigValue("UberMage.ManaShieldLife", "30", false);
            Context.SetConfigValue("UberMage.UseFrostbolt", "False", false);
            Context.SetConfigValue("UberMage.UseFireball", "True", false);
            Context.SetConfigValue("UberMage.UseConeOfCold", "False", false);
            Context.SetConfigValue("UberMage.UseArcaneExplosion", "False", false);
            Context.SetConfigValue("UberMage.POMWith", "None", false);
            Context.SetConfigValue("UberMage.UseArcanePower", "Never", false);
            Context.SetConfigValue("UberMage.UsePolyInPanic", "False", false);
            Context.SetConfigValue("UberMage.EvocationTrigger", "50", false);
            Context.SetConfigValue("UberMage.UseFlamestrike", "False", false);
            Context.SetConfigValue("UberMage.UseBlastwave", "False", false);
            Context.SetConfigValue("UberMage.UseBlizzard", "False", false);
            Context.SetConfigValue("UberMage.UseFlamestrikeAdds", "False", false);
            Context.SetConfigValue("UberMage.UseBlastwaveAdds", "False", false);
            Context.SetConfigValue("UberMage.UseBlizzardAdds", "False", false);
            Context.SetConfigValue("UberMage.UseAmplifyMagic", "False", false);
            Context.SetConfigValue("UberMage.UseFireblast", "False", false);
            Context.SetConfigValue("UberMage.UseArcaneIntellect", "True", false);
            Context.SetConfigValue("UberMage.UseSWPain", "False", false);
            Context.SetConfigValue("UberMage.UseDevouringPlague", "False", false);
            Context.SetConfigValue("UberMage.UseSWPainAdds", "False", false);
            Context.SetConfigValue("UberMage.UseDevouringPlagueAdds", "False", false);
            Context.SetConfigValue("UberMage.UseFrostWard", "Never", false);
            Context.SetConfigValue("UberMage.UseFireWard", "Never", false);
            Context.SetConfigValue("UberMage.UseDragonsBreath", "Never", false);
            Context.SetConfigValue("UberMage.UseWaterElemental", "Never", false);
            Context.SetConfigValue("UberMage.UseMSwithEvocation", "False", false);
            Context.SetConfigValue("UberMage.UseFNwithEvocation", "True", false);
            Context.SetConfigValue("UberMage.UseMelee", "False", false);
            Context.SetConfigValue("UberMage.UseIceLance", "False", false);
            Context.SetConfigValue("UberMage.LowManaWand", "True", false);
            Context.SetConfigValue("UberMage.BloodElf", "False", false);
            Context.SetConfigValue("UberMage.FrostNovaLife", "35", false);
            Context.SetConfigValue("UberMage.UseArcaneBlast", "Never", false);
            Context.SetConfigValue("UberMage.NeverPanic", "False", false);
            Context.SetConfigValue("UberMage.UseOilMain", "False", false);
            Context.SetConfigValue("UberMage.UseIcyVeins", "False", false);
            UberCreateDefaultConfig();
        }

        string IntToBarrier(int Barrier)
        {
            if (Barrier == 1) return "Always";
            if (Barrier == 2) return "On Hit";
            if (Barrier == 3) return "Panic";
            return "Never";
        }

        int BarrierToInt(string Barrier)
        {
            if (Barrier == "Always") return 1;
            if (Barrier == "On Hit") return 2;
            if (Barrier == "Panic") return 3;
            return 0;
        }

        string IntToFinisher(int Finisher)
        {
            if (Finisher == 1) return "Wand";
            if (Finisher == 2) return "Scorch";
            if (Finisher == 3) return "Cone of Cold";
            return "None";
        }

        int FinisherToInt(string Finisher)
        {
            if (Finisher == "Wand") return 1;
            if (Finisher == "Scorch") return 2;
            if (Finisher == "Cone of Cold") return 3;
            return 0;
        }

        public override void LoadConfig()
        {
            try { CounterspellLife = Context.GetConfigDouble("UberMage.CounterspellLife") / 100.0;}
            catch { Context.Log("ERROR Loading CounterspellLife"); }
            try { FinishLife = Context.GetConfigDouble("UberMage.FinishLife") / 100.0; } 
            catch { Context.Log("ERROR Loading FinishLife"); }
            try { ApproachFireblast = Context.GetConfigBool("UberMage.ApproachFireblast"); }
            catch { Context.Log("ERROR Loading ApproachFireblast"); }
            try { FireblastDistance = Context.GetConfigInt("UberMage.FireblastDistance"); }
            catch { Context.Log("ERROR Loading FireblastDistance"); }
            try { SaveFireblast = Context.GetConfigBool("UberMage.SaveFireblast"); }
            catch { Context.Log("ERROR Loading SaveFireblast"); }
            try { UseFrostNova = Context.GetConfigBool("UberMage.UseFrostNova"); }
            catch { Context.Log("ERROR Loading UseFrostNova"); }
            try { WaitOnPull = Context.GetConfigBool("UberMage.WaitOnPull"); }
            catch { Context.Log("ERROR Loading WaitOnPull"); }
            try { UseCounterspell = Context.GetConfigBool("UberMage.UseCounterspell"); }
            catch { Context.Log("ERROR Loading UseCounterspell"); }
            try { UseCombustion = Context.GetConfigBool("UberMage.UseCombustion"); }
            catch { Context.Log("ERROR Loading UseCombustion"); }
            try { UsePoly = Context.GetConfigBool("UberMage.UsePoly"); }
            catch { Context.Log("ERROR Loading UsePoly"); }
            try { UseEvocation = Context.GetConfigBool("UberMage.UseEvocation"); }
            catch { Context.Log("ERROR Loading UseEvocation"); }
            try { UseDampen = Context.GetConfigBool("UberMage.UseDampen"); }
            catch { Context.Log("ERROR Loading UseDampen"); }
            try { UseManastones = Context.GetConfigBool("UberMage.UseManaStones"); }
            catch { Context.Log("ERROR Loading UseManaStones"); }
            try { ShieldMode = (IceBarrierMode)BarrierToInt(Context.GetConfigString("UberMage.IceBarrierMode")); }
            catch { Context.Log("ERROR Loading IceBarrierMode"); }
            try { FinishMode = (Finisher)FinisherToInt(Context.GetConfigString("UberMage.FinisherMode")); }
            catch { Context.Log("ERROR Loading FinisherMode"); }
            try { Fireblast = new GSpellTimer((int)(Context.GetConfigDouble("UberMage.FireblastCooldownSec") * 1000), true); }
            catch { Context.Log("ERROR Loading FireblastCooldownSec"); }
            try { ShieldLife = Context.GetConfigDouble("UberMage.ShieldLife") / 100.0; }
            catch { Context.Log("ERROR Loading ShieldLife"); }
            try { ALWAYSPULL = Context.GetConfigBool("UberMage.AlwaysPull");}
            catch { Context.Log("ERROR Loading AlwaysPull"); }
            try { PULLWITH = Context.GetConfigString("UberMage.PullWith"); }
            catch { Context.Log("ERROR Loading PullWith"); }
            try { USEARCANEMISSILES = Context.GetConfigBool("UberMage.UseArcaneMissiles"); }
            catch { Context.Log("ERROR Loading UseArcaneMissiles"); }
            try { USEPYROBLAST = Context.GetConfigBool("UberMage.UsePyroblast"); }
            catch { Context.Log("ERROR Loading UsePyroblast"); }
            try { CLEARCASTINGWITH = Context.GetConfigString("UberMage.ClearcastingWith"); }
            catch { Context.Log("ERROR Loading ClearcastingWith"); }
            try { ARMORPRIMARY = Context.GetConfigString("UberMage.ArmorPrimary"); }
            catch { Context.Log("ERROR Loading ArmorPrimary"); }
            try { ARMORLOWMANA = Context.GetConfigString("UberMage.ArmorLowMana"); }
            catch { Context.Log("ERROR Loading ArmorLowMana"); }
            try { ARMORADDS = Context.GetConfigString("UberMage.ArmorAdds"); }
            catch { Context.Log("ERROR Loading ArmorAdds"); }
            try { ManaShieldLife = Context.GetConfigDouble("UberMage.ManaShieldLife") / 100.0; }
            catch { Context.Log("ERROR Loading ManaShieldLife"); }
            try { USEFROSTBOLT = Context.GetConfigBool("UberMage.UseFrostbolt"); }
            catch { Context.Log("ERROR Loading UseFrostbolt"); }
            try { USEFIREBALL = Context.GetConfigBool("UberMage.UseFireball"); }
            catch { Context.Log("ERROR Loading UseFireball"); }
            try { USECONEOFCOLD = Context.GetConfigBool("UberMage.UseConeOfCold"); }
            catch { Context.Log("ERROR Loading UseConeOfCold"); }
            try { USEARCANEEXPLOSION = Context.GetConfigBool("UberMage.UseArcaneExplosion"); }
            catch { Context.Log("ERROR Loading UseArcaneExplosion"); }
            try { POMWITH = Context.GetConfigString("UberMage.POMWith"); }
            catch { Context.Log("ERROR Loading POMWith"); }
            try { USEARCANEPOWER = Context.GetConfigString("UberMage.UseArcanePower"); }
            catch { Context.Log("ERROR Loading UseArcanePower"); }
            try { POLYINPANIC = Context.GetConfigBool("UberMage.UsePolyInPanic"); }
            catch { Context.Log("ERROR Loading UsePolyInPanic"); }
            try { EVOCATIONTRIGGER = (Context.GetConfigDouble("UberMage.EvocationTrigger") / 100); }
            catch { Context.Log("ERROR Loading EvocationTrigger"); }
            try { UseFlamestrike = Context.GetConfigBool("UberMage.UseFlamestrike"); }
            catch { Context.Log("ERROR Loading UseFlamestrike"); }
            try { UseBlastwave = Context.GetConfigBool("UberMage.UseBlastwave"); }
            catch { Context.Log("ERROR Loading UseBlastwave"); }
            try { UseBlizzard = Context.GetConfigBool("UberMage.UseBlizzard"); }
            catch { Context.Log("ERROR Loading UseBlizzard"); }
            try { UseFlamestrikeAdds = Context.GetConfigBool("UberMage.UseFlamestrikeAdds"); }
            catch { Context.Log("ERROR Loading UseFlamestrikeAdds"); }
            try { UseBlastwaveAdds = Context.GetConfigBool("UberMage.UseBlastwaveAdds"); }
            catch { Context.Log("ERROR Loading UseBlastwaveAdds"); }
            try { UseBlizzardAdds = Context.GetConfigBool("UberMage.UseBlizzardAdds"); }
            catch { Context.Log("ERROR Loading UseBlizzardAdds"); }
            try { USEAMPLIFYMAGIC = Context.GetConfigBool("UberMage.UseAmplifyMagic"); }
            catch { Context.Log("ERROR Loading UseAmplifyMagic"); }
            try { UseFireblast = Context.GetConfigBool("UberMage.UseFireblast"); }
            catch { Context.Log("ERROR Loading UseFireblast"); }
            try { UseArcaneIntellect = Context.GetConfigBool("UberMage.UseArcaneIntellect"); }
            catch { Context.Log("ERROR Loading UseArcaneIntellect"); }
            try { UseFrostWard = Context.GetConfigString("UberMage.UseFrostWard"); }
            catch { Context.Log("ERROR Loading UseFrostWard"); }
            try { UseFireWard = Context.GetConfigString("UberMage.UseFireWard"); }
            catch { Context.Log("ERROR Loading UseFireWard"); }
            try { UseDragonsBreath = Context.GetConfigString("UberMage.UseDragonsBreath"); }
            catch { Context.Log("ERROR Loading UseDragonsBreath"); }
            try { UseWaterElemental = Context.GetConfigString("UberMage.UseWaterElemental"); }
            catch { Context.Log("ERROR Loading UseWaterElemental"); }
            try { UseMSwithEvocation = Context.GetConfigBool("UberMage.UseMSwithEvocation"); }
            catch { Context.Log("ERROR Loading UseMSwithEvocation"); }
            try { UseFNwithEvocation = Context.GetConfigBool("UberMage.UseFNwithEvocation"); }
            catch { Context.Log("ERROR Loading UseFNwithEvocation"); }
            try { USEMELEE = Context.GetConfigBool("UberMage.UseMelee"); }
            catch { Context.Log("ERROR Loading UseMelee"); }
            try { USEICELANCE = Context.GetConfigBool("UberMage.UseIceLance"); }
            catch { Context.Log("ERROR Loading UseIceLance"); }
            try { LowManaWand = Context.GetConfigBool("UberMage.LowManaWand"); }
            catch { Context.Log("ERROR Loading LowManaWand"); }
            try { BloodElf = Context.GetConfigBool("UberMage.BloodElf"); }
            catch { Context.Log("ERROR Loading BloodElf"); }
            try { FROSTNOVALIFE = (Context.GetConfigDouble("UberMage.FrostNovaLife") / 100); }
            catch { Context.Log("ERROR Loading FrostNovaLife"); }
            try { UseArcaneBlast = Context.GetConfigString("UberMage.UseArcaneBlast"); }
            catch { Context.Log("ERROR Loading UseArcaneBlast"); }
            try { NeverPanic = Context.GetConfigBool("UberMage.NeverPanic"); }
            catch { Context.Log("ERROR Loading NeverPanic"); }
            try { UseOilMain = Context.GetConfigBool("UberMage.UseOilMain"); }
            catch { Context.Log("ERROR Loading UseOilMain"); }
            try { UseIcyVeins = Context.GetConfigBool("UberMage.UseIcyVeins"); }
            catch { Context.Log("ERROR Loading UseIcyVeins"); }
            UberLoadConfig();
        }

        public override GConfigResult ShowConfiguration()
        {
            CreateDefaultConfig();
            Assembly asm = System.Reflection.Assembly.LoadFile(
                AppDomain.CurrentDomain.BaseDirectory + "\\Classes\\GConfig.dll");

            foreach (Type loadedType in asm.GetTypes())
            {
                if (loadedType.Name == "GConfig")
                {
                    PropertyInfo pi;
                    object configDialog = loadedType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    MethodInfo showDialogMethod = loadedType.GetMethod("ShowDialog", new Type[] { });
                    Type type = configDialog.GetType();

                    //Set Current Values
                    SendToDialog(configDialog, "Mage.PullDistance");//This is special config used by glider
                    SendToDialog(configDialog, "UberMage.CounterspellLife");
                    SendToDialog(configDialog, "UberMage.FinishLife");
                    SendToDialog(configDialog, "UberMage.ApproachFireblast");
                    SendToDialog(configDialog, "UberMage.FireblastDistance");
                    SendToDialog(configDialog, "UberMage.SaveFireblast");
                    SendToDialog(configDialog, "UberMage.UseFrostNova");
                    SendToDialog(configDialog, "UberMage.WaitOnPull");
                    SendToDialog(configDialog, "UberMage.UseCounterspell");
                    SendToDialog(configDialog, "UberMage.UseCombustion");
                    SendToDialog(configDialog, "UberMage.UsePoly");
                    SendToDialog(configDialog, "UberMage.UseEvocation");
                    SendToDialog(configDialog, "UberMage.UseDampen");
                    SendToDialog(configDialog, "UberMage.UseManaStones");
                    SendToDialog(configDialog, "UberMage.IceBarrierMode");
                    SendToDialog(configDialog, "UberMage.FinisherMode");
                    SendToDialog(configDialog, "UberMage.FireblastCooldownSec");
                    SendToDialog(configDialog, "UberMage.ShieldLife");
                    SendToDialog(configDialog, "UberMage.AlwaysPull");
                    SendToDialog(configDialog, "UberMage.PullWith");
                    SendToDialog(configDialog, "UberMage.UseArcaneMissiles");
                    SendToDialog(configDialog, "UberMage.UsePyroblast");
                    SendToDialog(configDialog, "UberMage.ClearcastingWith");
                    SendToDialog(configDialog, "UberMage.ArmorPrimary");
                    SendToDialog(configDialog, "UberMage.ArmorLowMana");
                    SendToDialog(configDialog, "UberMage.ArmorAdds");
                    SendToDialog(configDialog, "UberMage.ManaShieldLife");
                    SendToDialog(configDialog, "UberMage.UseFrostbolt");
                    SendToDialog(configDialog, "UberMage.UseFireball");
                    SendToDialog(configDialog, "UberMage.UseConeOfCold");
                    SendToDialog(configDialog, "UberMage.UseArcaneExplosion");
                    SendToDialog(configDialog, "UberMage.POMWith");
                    SendToDialog(configDialog, "UberMage.UseArcanePower");
                    SendToDialog(configDialog, "UberMage.UsePolyInPanic");
                    SendToDialog(configDialog, "UberMage.EvocationTrigger");
                    SendToDialog(configDialog, "UberMage.UseFlamestrike");
                    SendToDialog(configDialog, "UberMage.UseBlastwave");
                    SendToDialog(configDialog, "UberMage.UseBlizzard");
                    SendToDialog(configDialog, "UberMage.UseFlamestrikeAdds");
                    SendToDialog(configDialog, "UberMage.UseBlastwaveAdds");
                    SendToDialog(configDialog, "UberMage.UseBlizzardAdds");
                    SendToDialog(configDialog, "UberMage.UseAmplifyMagic");
                    SendToDialog(configDialog, "UberMage.UseFireblast");
                    SendToDialog(configDialog, "UberMage.UseArcaneIntellect");
                    SendToDialog(configDialog, "UberMage.UseFrostWard");
                    SendToDialog(configDialog, "UberMage.UseFireWard");
                    SendToDialog(configDialog, "UberMage.UseDragonsBreath");
                    SendToDialog(configDialog, "UberMage.UseWaterElemental");
                    SendToDialog(configDialog, "UberMage.UseMSwithEvocation");
                    SendToDialog(configDialog, "UberMage.UseFNwithEvocation");
                    SendToDialog(configDialog, "UberMage.UseMelee");
                    SendToDialog(configDialog, "UberMage.UseIceLance");
                    SendToDialog(configDialog, "UberMage.LowManaWand");
                    SendToDialog(configDialog, "UberMage.BloodElf");
                    SendToDialog(configDialog, "UberMage.FrostNovaLife");
                    SendToDialog(configDialog, "UberMage.UseArcaneBlast");
                    SendToDialog(configDialog, "UberMage.NeverPanic");
                    SendToDialog(configDialog, "UberMage.UseOilMain");
                    SendToDialog(configDialog, "UberMage.UseIcyVeins");
                    UberSendToDialog(configDialog);
                    //Set Config File
                    pi = type.GetProperty("ConfigXML");
                    if (pi != null) pi.SetValue(configDialog, "OOberMage.XML", null);

                    //Popup Dialog
                    object modalResult = showDialogMethod.Invoke(configDialog, new object[] { });
                    if ((int)modalResult == 1)
                    {
                        //Get Current Values
                        GetFromDialog(configDialog, "Mage.PullDistance");//This is special config used by glider
                        GetFromDialog(configDialog, "UberMage.CounterspellLife");
                        GetFromDialog(configDialog, "UberMage.FinishLife");
                        GetFromDialog(configDialog, "UberMage.ApproachFireblast");
                        GetFromDialog(configDialog, "UberMage.FireblastDistance");
                        GetFromDialog(configDialog, "UberMage.SaveFireblast");
                        GetFromDialog(configDialog, "UberMage.UseFrostNova");
                        GetFromDialog(configDialog, "UberMage.WaitOnPull");
                        GetFromDialog(configDialog, "UberMage.UseCounterspell");
                        GetFromDialog(configDialog, "UberMage.UseCombustion");
                        GetFromDialog(configDialog, "UberMage.UsePoly");
                        GetFromDialog(configDialog, "UberMage.UseEvocation");
                        GetFromDialog(configDialog, "UberMage.UseDampen");
                        GetFromDialog(configDialog, "UberMage.UseManaStones");
                        GetFromDialog(configDialog, "UberMage.IceBarrierMode");
                        GetFromDialog(configDialog, "UberMage.FinisherMode");
                        GetFromDialog(configDialog, "UberMage.FireblastCooldownSec");
                        GetFromDialog(configDialog, "UberMage.ShieldLife");
                        GetFromDialog(configDialog, "UberMage.AlwaysPull");
                        GetFromDialog(configDialog, "UberMage.PullWith");
                        GetFromDialog(configDialog, "UberMage.UseArcaneMissiles");
                        GetFromDialog(configDialog, "UberMage.UsePyroblast");
                        GetFromDialog(configDialog, "UberMage.ClearcastingWith");
                        GetFromDialog(configDialog, "UberMage.ArmorPrimary");
                        GetFromDialog(configDialog, "UberMage.ArmorLowMana");
                        GetFromDialog(configDialog, "UberMage.ArmorAdds");
                        GetFromDialog(configDialog, "UberMage.ManaShieldLife");
                        GetFromDialog(configDialog, "UberMage.UseFrostbolt");
                        GetFromDialog(configDialog, "UberMage.UseFireball");
                        GetFromDialog(configDialog, "UberMage.UseConeOfCold");
                        GetFromDialog(configDialog, "UberMage.UseArcaneExplosion");
                        GetFromDialog(configDialog, "UberMage.POMWith");
                        GetFromDialog(configDialog, "UberMage.UseArcanePower");
                        GetFromDialog(configDialog, "UberMage.UsePolyInPanic");
                        GetFromDialog(configDialog, "UberMage.EvocationTrigger");
                        GetFromDialog(configDialog, "UberMage.UseFlamestrike");
                        GetFromDialog(configDialog, "UberMage.UseBlastwave");
                        GetFromDialog(configDialog, "UberMage.UseBlizzard");
                        GetFromDialog(configDialog, "UberMage.UseFlamestrikeAdds");
                        GetFromDialog(configDialog, "UberMage.UseBlastwaveAdds");
                        GetFromDialog(configDialog, "UberMage.UseBlizzardAdds");
                        GetFromDialog(configDialog, "UberMage.UseAmplifyMagic");
                        GetFromDialog(configDialog, "UberMage.UseFireblast");
                        GetFromDialog(configDialog, "UberMage.UseArcaneIntellect");
                        GetFromDialog(configDialog, "UberMage.UseFrostWard");
                        GetFromDialog(configDialog, "UberMage.UseFireWard");
                        GetFromDialog(configDialog, "UberMage.UseDragonsBreath");
                        GetFromDialog(configDialog, "UberMage.UseWaterElemental");
                        GetFromDialog(configDialog, "UberMage.UseMSwithEvocation");
                        GetFromDialog(configDialog, "UberMage.UseFNwithEvocation");
                        GetFromDialog(configDialog, "UberMage.UseMelee");
                        GetFromDialog(configDialog, "UberMage.UseIceLance");
                        GetFromDialog(configDialog, "UberMage.LowManaWand");
                        GetFromDialog(configDialog, "UberMage.BloodElf");
                        GetFromDialog(configDialog, "UberMage.FrostNovaLife");
                        GetFromDialog(configDialog, "UberMage.UseArcaneBlast");
                        GetFromDialog(configDialog, "UberMage.NeverPanic");
                        GetFromDialog(configDialog, "UberMage.UseOilMain");
                        GetFromDialog(configDialog, "UberMage.UseIcyVeins");
                        UberGetFromDialog(configDialog);
                        return GConfigResult.Accept;
                    }
                    return GConfigResult.Cancel;
                }
            }
            return GConfigResult.Cancel;
        }

        #endregion

        #region GGameClass overrides
        // Don't buy this stuff, we can make it.
        public override bool ShouldBuyFood { get { return false; } }
        public override bool ShouldBuyWater { get { return false; } }
        public override bool CanDrink
        {
            get { return true; }   // umm drinking good.
        }
        
        public override string DisplayName
        {
            #if PATHERENABLED
            get { return "OOber Mage w/PPather " + PATHERVERSION; }
            #else
            get { return "OOber Mage"; }
            #endif
        }

        public override bool Rest()
        {
            if (StopLeveling()) return false;
            ALWAYS_EATANDDRINK_TOGETHER = true;
            CheckHealth();
            CheckMana();
            WaitForSnack();
            if(!Me.IsUnderAttack)ConjureFood();
            if (!Me.IsUnderAttack) ConjureWater();
            if (!Me.IsUnderAttack) ConjureManaStone();
            ForcedRest();
            CheckTrinkets("After Rest");
            // Check & apply oil before we finish resting
            if (UseOilMain)
                CheckWeaponEnchant("UberMage.UseOilMain", "oil", "MainHandSlot");
            return false;  //Don't call base rest to reduce wait time
        }

        public override void OnStartGlide()
        {
            OOberLog("OnStartGlide");
            LoadConfig();
            SMARTHEAL = true; //Used for Emergency Poly decision
            USESWAND = true;

            if (UseManastones)
            {
                int Stones = GetActionInventory("UberMage.UseManastone");

                if (Stones == -1)
                {
                    Context.Log("Can't read manastone from inventory (barstate should not be indifferent), assuming no manastone present");
                    GotStone = false;
                    UseStoneInv = false;
                }
                else
                {
                    if (Stones == 0)
                        Context.Log("No mana stone, will conjure at rest");
                    else
                        Context.Log("Looks like we have a mana stone");

                    UseStoneInv = true;
                }
            }

            base.OnStartGlide();
        }

        public override void RunningAction()
        {
            if (ActivePVP()) return;
            if (BuffNearbyFriends()) return;
            if (SellToVendor()) return;
            if (!IsMounted())
            {
                if (Context.RemoveDebuffs(GBuffType.Curse, "UberMage.RemoveCurse", false)) return;
                if (CheckBuffs(true)) return;
            }
            if (BetweenTargetMode("UberMage")) return;
        }

        public override void ApproachingTarget(GUnit Target)
        {
            if (ShieldMode == IceBarrierMode.Always && IceBarrier.IsReady)
            {
                CastSpell("UberMage.IceBarrier");
                IceBarrier.Reset();
            }
        }
        #endregion

        #region KillTarget
        public override GCombatResult KillTarget(GUnit Target, bool IsAmbush)
        {
            KillTargetInit(Target, IsAmbush);
            bool Channeled;

            StartLife = Me.Health;
            MANA_HEALRESERVE = 0;
            MANA_HEALRESERVE_ADDS = 0;

            Polyd.ForceReady();
            PolyGUID = 0;

            if (Context.IsRunning || Context.IsSpinning)
            {
                mover.Stop();
                Thread.Sleep(401);  // Let the game register the arrow key reelase.
            }

            if (!KillTargetReady(Target, IsAmbush)) return FinalState(Target, IsAmbush);

            if (!IsAmbush) CheckBuffs(false);

            Channeled = false;
            //Send in pet if we got it
            Me.Refresh(true);
            if(Me.PetGUID!=0)SendKey("Common.PetAttack");

            // Cast pull spell if there's time:
            if (ALWAYSPULL || !IsAmbush)
            {
                Context.Log("Pulling with " + PULLWITH + "...");
                PULLING = true;
                CheckTrinkets("Before Pull");
                if (PULLWITH == "Scorch")
                {
                    CastSpell("UberMage.Scorch");
                    Channeled = false;
                    TrackAttack();
                }
                else if (PULLWITH == "Frostbolt")
                {
                    CastSpell("UberMage.Frostbolt");
                    Channeled = false;
                    TrackAttack();
                }
                else if (PULLWITH == "Frostbolt + Fireball")
                {
                    CastSpell("UberMage.Frostbolt");
                    Channeled = CastSpell("UberMage.Fireball");
                    TrackAttack();
                }
                else if (PULLWITH == "Frostbolt + Arcane Missiles")
                {
                    CastSpell("UberMage.Frostbolt");
                    CastSpell("UberMage.ArcaneMissiles");
                    TrackAttack();
                }
                else if (PULLWITH == "Fireball")
                {
                    Channeled = CastSpell("UberMage.Fireball");
                    TrackAttack();
                }
                else if (PULLWITH == "Fireball + Arcane Missiles")
                {
                    Channeled = CastSpell("UberMage.Fireball");
                    CastSpell("UberMage.ArcaneMissiles");
                    TrackAttack();
                }
                else if (PULLWITH == "Arcane Missiles")
                {
                    CastSpell("UberMage.ArcaneMissiles");
                    TrackAttack();
                }
                else if (PULLWITH == "Arcane Blast")
                {
                    CastSpell("UberMage.ArcaneBlast");
                    ABCount = 1;
                    ArcaneBlast.Reset();
                    TrackAttack();
                }
                else if (PULLWITH == "Pyroblast")
                {
                    CastSpell("UberMage.Pyroblast");
                    Pyroblast.Reset();
                    TrackAttack();
                }
                else if (PULLWITH == "Pyroblast + Fireball")
                {
                    CastSpell("UberMage.Pyroblast");
                    Pyroblast.Reset();
                    Channeled = CastSpell("UberMage.Fireball");
                    TrackAttack();
                }
                else if (PULLWITH == "Pyroblast + Arcane Missiles")
                {
                    CastSpell("UberMage.Pyroblast");
                    Pyroblast.Reset();
                    CastSpell("UberMage.ArcaneMissiles");
                    TrackAttack();
                }
                else if (PULLWITH == "Dragons Breath")
                {
                    if (!Approach(Target, Context.MeleeDistance)) return FinalState(Target, IsAmbush);
                    CastSpell("UberMage.DragonsBreath");
                    Channeled = CastSpell("UberMage.DragonsBreath");
                    DragonsBreath.Reset();
                    TrackAttack();
                }
                PULLING = false;
                CheckTrinkets("After Pull");
            }
            else
            {
                Context.Log("Skipping Pull");
            }

            // Wait for the MOB to get within blast range
            if (WaitOnPull) Target.WaitForApproach(PullDistance, 3000);
            if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);

            // Pop 'em with a fireblast if they're close enough and it's an ambush:
            if (UseFireblast && IsAmbush && Target.DistanceToSelf < FireblastDistance && Fireblast.IsReady)
            {
                CastSpell("UberMage.Fireblast");
                Fireblast.Reset();
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
            }

            // Ok, main loop:
            while (true)
            {
                Thread.Sleep(101);
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);

                //Adjust Distance
                if (Target.DistanceToSelf > PullDistance)
                {
                    if (Target.DistanceToSelf > 100.0)
                    {
                        Context.Log("! Target is way too far away!");
                        return GCombatResult.Vanished;
                    }
                    if (!Approach(Target, this.PullDistance)) return FinalState(Target, IsAmbush);
                    if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                }

                //Make sure we have Melee enabled
                if (USEMELEE && !Me.IsMeleeing && Target.DistanceToSelf <= Context.MeleeDistance + 5)
                {
                    ToggleCombat();
                    TrackAttack();
                    if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                }

                //Check Buffs
                CheckBuffs(true);
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                DoFrostWard(Target);
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                DoFireWard(Target);
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                DoIcyVeins();
                if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);

                // If we are in Finisher Range, finish it
                if (Target.Health < FinishLife && FinishMode != Finisher.None)
                {
                    if (FinishMode == Finisher.Wand)
                    {
                        OOberLog("Finish With Wand");
                        Face(Target);
                        StartWand();
                    }
                    else if (FinishMode == Finisher.Scorch)
                    {
                        OOberLog("Finish With Scorch");
                        CastSpell("UberMage.Scorch");
                    }
                    else if (FinishMode == Finisher.ConeOfCold)
                    {
                        OOberLog("Finish With ConeofCold");
                        Approach(Target, 5);
                        CastSpell("UberMage.ConeOfCold");
                    }
                    if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                }
                else// Otherwise do Standard Spell Attack
                {
                    // Wand cuz OOM
                    if (LowMana() && LowManaWand)
                    {
                        Face(Target);
                        StartWand();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }
                    
                    // Water Elemental?
                    if (CanUseMana() && UseWaterElemental == "Always" && WaterElemental.IsReady) SummonWaterElemental();

                    //Arcane Blast?
                    ChooseArcaneBlast();

                    // Flamestrike time?
                    if (CanUseMana() && UseFlamestrike && Flamestrike.IsReady && IsKeyReady("UberMage.FlameStrike"))
                    {
                        CastFlamestrike();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Blast Wave time?
                    if (CanUseMana() && UseBlastwave && Blastwave.IsReady &&
                        Target.DistanceToSelf <= Context.MeleeDistance && IsKeyReady("UberMage.BlastWave"))
                    {
                        CastSpell("UberMage.BlastWave");
                        Blastwave.Reset();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Blizzard time?
                    if (CanUseMana() && UseBlizzard && Blizzard.IsReady && IsKeyReady("UberMage.Blizzard"))
                    {
                        CastBlizzard();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Pyroblast time?
                    if (CanUseMana() && USEPYROBLAST && Pyroblast.IsReady && IsKeyReady("UberMage.Pyroblast"))
                    {
                        CastSpell("UberMage.Pyroblast");
                        Pyroblast.Reset();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Cone of Cold time?
                    if (CanUseMana() && USECONEOFCOLD && ConeOfCold.IsReady &&
                        Target.DistanceToSelf <= Context.MeleeDistance && IsKeyReady("UberMage.ConeOfCold"))
                    {
                        CastSpell("UberMage.ConeOfCold");
                        ConeOfCold.Reset();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // DragonsBreath time?
                    if (CanUseMana() && UseDragonsBreath == "Always" &&
                        DragonsBreath.IsReady &&
                        Target.DistanceToSelf <= Context.MeleeDistance &&
                        IsKeyReady("UberMage.DragonsBreath"))
                    {
                        CastSpell("UberMage.DragonsBreath");
                        DragonsBreath.Reset();
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Frost Nova as neccessary
                    if (ShouldFrostNova(Target))
                    {
                        DoFrostNova(Target);
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Frostbolt time?
                    if (CanUseMana() && USEFROSTBOLT && IsKeyReady("UberMage.Frostbolt"))
                    {
                        CastSpell("UberMage.Frostbolt");
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Fireball time?
                    if (CanUseMana() && USEFIREBALL && IsKeyReady("UberMage.Fireball"))
                    {
                        CastSpell("UberMage.Fireball");
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Arcane Missle time?
                    if (CanUseMana() && USEARCANEMISSILES && IsKeyReady("UberMage.ArcaneMissiles"))
                    {
                        CastSpell("UberMage.ArcaneMissiles");
                        TrackAttack();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }

                    // Fireblast time?
                    if (UseFireblast && CanUseMana() && Fireblast.IsReady && Target.DistanceToSelf < FireblastDistance && (Target.Health > .70 || !SaveFireblast))
                    {
                        CastSpell("UberMage.Fireblast");
                        TrackAttack();
                        Fireblast.Reset();
                        if (CheckState(Target, IsAmbush)) return FinalState(Target, IsAmbush);
                    }
                }

                OOberLog("Check Extras");
                if (KillTargetExtras(Target, IsAmbush)) return FinalState(Target, IsAmbush);

                if (CanUseMana()) Context.RemoveDebuffs(GBuffType.Curse, "UberMage.RemoveCurse", true);

            }

        }

        #endregion

        #region Mage Helper Functions

        bool bIsClearCasting = false;
        bool bIsPOM = false;
        void CheckClearcasting()
        {
            if (!Me.HasBuff(CLEARCASTING)) return;
            GUnit Target = Me.Target;
            if (Target == null) return;
            if (!Target.IsValid) return;
            bIsClearCasting = true;
            Context.Debug("Detected Clearcasting!");
            if (CLEARCASTINGWITH != "Any")
                CastSpell("UberMage." + CLEARCASTINGWITH);
            bIsClearCasting = false;
        }

        bool ChooseArmor()
        {
            string ArmorToUse = "None";
            if (!CanUseMana()) return false;
            //Pick Armor
            if (LowMana())
                ArmorToUse = ARMORLOWMANA;
            else if (HasAdds())
                ArmorToUse = ARMORADDS;
            else
                ArmorToUse = ARMORPRIMARY;
            //Apply it as Needed
            if (ArmorToUse == "Frost")
            {
                if (Me.HasBuff(FROSTARMOR)) return false;
                CastSpell("UberMage.FrostArmor");
                return true;
            }
            if (ArmorToUse == "Ice")
            {
                if (Me.HasBuff(ICEARMOR)) return false;
                CastSpell("UberMage.IceArmor");
                return true;
            }
            if (ArmorToUse == "Mage") 
            {
                if (Me.HasBuff(MAGEARMOR)) return false;
                CastSpell("UberMage.MageArmor");
                return true;
            }
            if (ArmorToUse == "Molten")
            {
                if (Me.HasBuff(MOLTENARMOR)) return false;
                CastSpell("UberMage.MoltenArmor");
                return true;
            }
            return false;
        }

        void CheckFrostbite(GUnit Target)
        {
            if (Target == null) return;
            if (!Target.IsValid) return;
            if (!Target.HasBuff(FROSTBITE)) return;
            Context.Log("Target Has Frostbite!");
            if (Target.DistanceToSelf<=Context.MeleeDistance) BackUp(Target);
            if (USEICELANCE && CanUseMana() && IsKeyReady("UberMage.IceLance") && !DoingEvocation) CastSpell("UberMage.IceLance");
        }

        bool ShouldFrostNova(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            if (!UseFrostNova) return false;
            if (Target.Health <= FROSTNOVALIFE) { OOberLog("FN: Below FNLife"); return false; }
            if (Target.DistanceToSelf > Context.MeleeDistance) { OOberLog("FN: Too Far"); return false; }
            if (Target.Mana > 0) { OOberLog("FN: Is Caster"); return false; }
            if (!Polyd.IsReady) { OOberLog("FN: Poly"); return false; }
            if (!IsKeyReady("UberMage.FrostNova")) { OOberLog("FN: Key Not Ready"); return false; }
            if (Target.HasBuff(FROSTBITE)) { OOberLog("FN: Frostbite"); return false; }
            GMonster Nearest = GObjectList.GetClosestNeutralMonster();
            if (Nearest != null && Nearest.DistanceToSelf < 12.0)  // Neutral mobs too close, will probably jump in.
                return false;
            return true;
        }

        // Do a frost nova move and return true if we did something.  False if we changed our minds.
        bool DoFrostNova(GUnit Monster)
        {
            //if (!IsKeyReady("UberMage.FrostNova")) return false;
            CastSpell("UberMage.FrostNova");
            BackUp(Monster);
            if (USEICELANCE && CanUseMana() && IsKeyReady("UberMage.IceLance") && !DoingEvocation) CastSpell("UberMage.IceLance");
            return true;
        }

        bool CanPoly(GUnit MyTarget)
        {
            if (MyTarget.CreatureType == GCreatureType.Beast || 
                MyTarget.CreatureType == GCreatureType.Humanoid) return true;
            OOberLog("Can't Poly " + MyTarget.ToString() + " (Invalid CreatureType)");
            return false;
        }

        void PolyTarget(GUnit Target)
        {
            if (!Polyd.IsReady || !UsePoly || !CanPoly(Target)) return;
            CastSpell("UberMage.Poly",false);
            Polyd.Reset();
            PolyGUID = Target.GUID;
            BackUp(Target);
        }

        void PolyAdd()
        {
            OOberLog("Want to Poly Add...");
            GUnit OriginalTarget = Me.Target;
            if (OriginalTarget == null || !OriginalTarget.IsValid)
            {
                OOberLog("Can't Find Original Target");
                return;
            }
            if (!Polyd.IsReady)
            {
                OOberLog("Another Target may still be poly'd");
                return;
            }
            if (!UsePoly)
            {
                OOberLog("Polymorph Disabled");
                return;
            }
            GUnit Add = GObjectList.GetNearestAttacker(OriginalTarget.GUID);
            if (Add == null || !Add.IsValid)
            {
                OOberLog("Can't Find Add");
                return;
            }
            if (!CanPoly(Add)) return;
            // Got an add!
            Context.Log("Additional attacker: \"" + Add.Name + "\", 0x" + Add.GUID.ToString("x") + ", polymorphing");
            if (!Add.SetAsTarget(false))    // Couldn't select it.
            {
                Context.Log("Could not select with Tab key, turning off poly option");
                OriginalTarget.SetAsTarget(true);
            }
            PolyTarget(Add);
            // Add is targeted!  Poly 'em:
            OriginalTarget.SetAsTarget(true);
            Face(OriginalTarget);
        }

        public override bool CheckPartyBuffs()
        {
            //LogHelper.Debug("CheckPartyBuffs for mage");
            return Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Druid) ||
                   Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Hunter) ||
                   Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Paladin) ||
                   Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Priest) ||
                   Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Shaman) ||
                   Context.Party.BuffParty("UberMage.ArcaneIntellectOther", (26 * 60), GPlayerClass.Warlock);
        }

        void CastFlamestrike()
        {
            if(CastSpellAOE("UberMage.FlameStrike"))Flamestrike.Reset();
        }

        void CastBlizzard()
        {
            if(CastSpellAOE("UberMage.Blizzard")) Blizzard.Reset();
        }

        void ChooseArcaneBlast()
        {
            if (!CanUseMana()) return;
            if (UseArcaneBlast == "Always" && ArcaneBlast.IsReady)
            {
                CastSpell("UberMage.ArcaneBlast");
                ABCount = 1;
                ArcaneBlast.Reset();
            }
            if (UseArcaneBlast == "Always Stacked")
            {
                if (ArcaneBlast.IsReady)
                {
                    CastSpell("UberMage.ArcaneBlast");
                    ABCount = 1;
                    ArcaneBlast.Reset();
                }
                else if (ABCount < 3)
                {
                    CastSpell("UberMage.ArcaneBlast");
                    ABCount++;
                    ArcaneBlast.Reset();
                }
            }
        }

        void ConjureFood()
        {
            int FoodLeft = GetActionInventory("UberMage.Eat");
            if (FoodLeft == -1)
            {
                Context.Log("Can't read food from inventory (barstate should not be indifferent)");
            }
            else if (FoodLeft < 5 && FoodConjure.IsReady)
            {
                FoodConjure.Reset();
                Context.Log("Only have " + FoodLeft + " food left, conjuring more");
                CastSpell("UberMage.ConjureFood");
                Thread.Sleep(771);  // Slight delay to let response come from server.
            }
        }

        void ConjureWater()
        {
            int WaterLeft = GetActionInventory("UberMage.Drink");
            if (WaterLeft == -1)
            {
                Context.Log("Can't read water from inventory (barstate should not be indifferent)");
            }
            else if (WaterLeft < 5 && WaterConjure.IsReady)
            {
                WaterConjure.Reset();
                Context.Log("Only have " + WaterLeft + " water left, conjuring more");
                CastSpell("UberMage.ConjureWater");
                Thread.Sleep(771);  // Slight delay to let response come from server.
            }
        }

        void ConjureManaStone()
        {
            if (UseManastones)
            {
                int StoneCount = GetActionInventory("UberMage.UseManastone");
                if (UseStoneInv) GotStone = StoneCount > 0;
                if (UseStoneInv && StoneCount==0 && Me.Mana > .35)
                {
                    CastSpell("UberMage.CreateManastone");
                    Thread.Sleep(1001);  // Let spell finish so inventory updates.
                    GotStone = true;
                }
            }
        }

        void DoFrostWard(GUnit Target)
        {
            if(FrostWard.IsReady &&
               ((UseFrostWard == "Always") ||
                (UseFrostWard == "With Caster" && Target.Mana > 0) || 
                (UseFrostWard == "With Elemental" && Target.CreatureType == GCreatureType.Elemental)) &&
               IsKeyReady("UberMage.FrostWard"))
            {
                CastSpell("UberMage.FrostWard");
                FrostWard.Reset();
            }
        }

        void DoFireWard(GUnit Target)
        {
            if (FireWard.IsReady &&
               ((UseFireWard == "Always") ||
                (UseFireWard == "With Caster" && Target.Mana > 0) ||
                (UseFireWard == "With Elemental" && Target.CreatureType == GCreatureType.Elemental)) &&
               IsKeyReady("UberMage.FireWard"))
            {
                CastSpell("UberMage.FireWard");
                FireWard.Reset();
            }
        }

        void DoIcyVeins()
        {
            if (UseIcyVeins && IcyVeinsCooldown.IsReady && IsKeyReady("UberMage.IcyVeins"))
            {
                CastSpell("UberMage.IcyVeins");
                IcyVeinsCooldown.Reset();
            }
        }

        #endregion

        #region Pet Logic
 
        void SummonWaterElemental()
        {
            //string strResponse = "";
            //string strError = "";
            if (!IsKeyReady("UberMage.WaterElemental")) return;
            //Start Spell
            CastSpell("UberMage.WaterElemental", false);
            Thread.Sleep(2001);
            SendKey("Common.PetAttack");
            //Thread.Sleep(250);
            //Position Cursor
            //strResponse = RemoteCommand("/setmouse 0.500/0.500", strError);
            //if (strError != "")
            //{
            //    Context.Log("ERROR with setmouse:" + strError);
            //    return;
            //}
            //Fire Spell
            //strResponse = RemoteCommand("/clickmouse left", strError);
            //if (strError != "")
            //{
            //    Context.Log("ERROR with clickmouse:" + strError);
            //    return;
            //}
            WaterElemental.Reset();
        }

        #endregion

        #region Heal & Mana Logic

        void CheckHealth()
        {
            EatSomething();
        }

        void CheckMana()
        {
            DrinkSomething();
        }

        protected override void DoEmergencyHeal(GUnit Target)
        {
            if (NeverPanic) return;

            double mana=Me.Mana;
            double health=Me.Health;

            Context.Log("Panic! vs \"" + Target.Name + "\"");
            Context.Log("Mana: " + mana.ToString() + " Health: " + health.ToString());
            bool DidBarrier = false;
            //Do Target Poly
            if (POLYINPANIC && Polyd.IsReady && SmartHeal()) PolyTarget(Target);
            //Apply Ice Barrier
            if (ShieldMode == IceBarrierMode.Always || ShieldMode == IceBarrierMode.Panic)
            {
                if (CanUseMana() && IceBarrier.IsReady)
                {
                    CastSpell("UberMage.IceBarrier");
                    IceBarrier.Reset();
                    DidBarrier = true;
                }
            }
            //Otherwise do FrostNova
            if (!DidBarrier && ShouldFrostNova(Target)) DoFrostNova(Target);
        }

        bool DoingEvocation = false;
        protected override void GetExtraMana(GUnit Target)
        {
            // Consider using Mana Tap
            if (BloodElf && Target.ManaPoints > 0 && ManaTap.IsReady)
            {
                ManaTap.Reset();
                CastSpell("UberMage.ManaTap", false);
                ManaTapCharges++;
            }
            if (Me.Mana < 0.20 && BloodElf && ManaTapCharges > 0 && ArcaneTorrent.IsReady)
            {
                // we might cash in on that free mana we get as a belf
                CastSpell("UberMage.ArcaneTorrent", false);
                ManaTapCharges = 0;
            }
            if (LowMana() && UseManastones)
            {
                GotStone = false;
                if (UseStoneInv)        // Jam flag with value from game.
                    GotStone = GetActionInventory("UberMage.UseManastone") > 0;

                // Mana stone?
                if (GotStone && Manastone.IsReady &&
                    ((Target != null && Target.IsValid && Target.Health > .20 && Me.Mana < .20) ||
                     Me.Mana < .10))
                {
                    CastSpell("UberMage.UseManastone");
                    Manastone.Reset();
                    GotStone = false;
                }
            }
            if (Me.Mana < EVOCATIONTRIGGER && UseEvocation && Evocation.IsReady && IsKeyReady("UberMage.Evocation"))
            {
                DoingEvocation = true;
                if (UseFNwithEvocation && ShouldFrostNova(Target)) { DoFrostNova(Target); BackUp(Target); }
                if (UseMSwithEvocation) CastSpell("UberMage.ManaShield", true);
                Thread.Sleep(500);
                Evocation.Reset();
                CastSpell("UberMage.Evocation", false, true, false, 2000);
                DoingEvocation = false;
            }
            //Check For Frostbite
            CheckFrostbite(Target);
        }

        #endregion

        #region UberLibrary Callbacks

        protected override string UberClassName
        {
            get { return "UberMage"; }
        }

        protected override bool PreCastSpell(string Spell)
        {
            Face(Me.Target);
            if (!bIsClearCasting)
            {
                CheckClearcasting();
            }
            if (!bIsPOM)
            {
                if (("UberMage." + POMWITH) == Spell && POMCooldown.IsReady && IsKeyReady("UberMage.PresenceOfMind"))
                {
                    bIsPOM = true;
                    if (USEARCANEPOWER == "With Presence of Mind" && APCooldown.IsReady && IsKeyReady("UberMage.ArcanePresence"))
                    {
                        CastSpell("UberMage.ArcanePower");
                    }
                    CastSpell("UberMage.PresenceOfMind");
                    POMCooldown.Reset();
                    bIsPOM = false;
                }
            }
            return true;
        }

        protected override void PostCastSpell(string Spell)
        {
            if (!bIsClearCasting)
            {
                CheckClearcasting();
            }
        }

        protected override bool CheckBuffs(bool bApplyOne)
        {
            if (Me.IsDead) return true;
            bool brtn;
            //Apply Proper Armor
            brtn = ChooseArmor();
            if (brtn && bApplyOne) return true;
            //Apply Mana shield
            if (Me.Health < ManaShieldLife && !Me.HasBuff(MANASHIELD))
            {
                CastSpell("UberMage.ManaShield");
                if (bApplyOne) return true;
            }
            if (!Me.IsUnderAttack)
            {
                //Apply Arcane Intellect
                if (CanUseMana() && UseArcaneIntellect && !Me.HasBuff(ARCANEINTELLECT))
                {
                    CastSpell("UberMage.ArcaneIntellect");
                    if (bApplyOne) return true;
                }
                //Apply Dampen Magic
                if (CanUseMana() && UseDampen && !Me.HasBuff(DAMPENMAGIC) && IsKeyReady("UberMage.DampenMagic"))
                {
                    CastSpell("UberMage.DampenMagic");
                    if (bApplyOne) return true;
                }
                //Apply Amplify Magic
                if (CanUseMana() && USEAMPLIFYMAGIC && !Me.HasBuff(AMPLIFYMAGIC) && IsKeyReady("UberMage.AmplifyMagic"))
                {
                    CastSpell("UberMage.AmplifyMagic");
                    if (bApplyOne) return true;
                }
                //Apply Combustion
                if (UseCombustion && IsKeyReady("UberMage.Combustion") && !Me.HasBuff(BUFFID_COMBUSTION))
                {
                    CastSpell("UberMage.Combustion");
                    if (bApplyOne) return true;
                }
            }
            //Apply Ice Barrier
            if ((Me.Health < StartLife && ShieldMode == IceBarrierMode.OnHit) ||
                (Me.Health < ShieldLife && ShieldMode != IceBarrierMode.None) ||
                ShieldMode == IceBarrierMode.Always)
            {
                if (!IsMounted() && CanUseMana() && IceBarrier.IsReady)
                {
                    CastSpell("UberMage.IceBarrier");
                    IceBarrier.Reset();
                    StartLife = Me.Health;  // Remember this, just in case.
                    if (bApplyOne) return true;
                }
            }
            //Apply Arcane Power
            if (USEARCANEPOWER == "Always" && APCooldown.IsReady && IsKeyReady("UberMage.ArcanePresence"))
            {
                CastSpell("UberMage.ArcanePower");
            }
            return false;
        }

        protected override void HandleRunners(GUnit Target)
        {
            if (CanUseMana() && IsKeyReady("UberMage.Fireblast") && SaveFireblast)
            {
                Context.Log("Target is running away!");
                //Context.Log("UberMage.Fireblast");
                //Context.CastSpell("UberMage.Fireblast", true, false);
                CastSpell("UberMage.Fireblast", false, true, false);
            }
        }

        protected override void InterruptCasters(GUnit Target)
        {
            if(Target==null) return;
            if(!Target.IsValid) return;
            Target.Refresh();
            if (!Target.IsCasting) return;
            // Counterspell!
            if (CanUseMana() && UseCounterspell && Target.Health < CounterspellLife &&
                IsKeyReady("UberMage.Counterspell") && Target.DistanceToSelf <= COUNTERSPELL_RANGE)
            {
                Context.Log("Target is casting!");
                //Context.Log("UberMage.Counterspell");
                //Context.CastSpell("UberMage.Counterspell", true, false);
                CastSpell("UberMage.Counterspell", false, true, false);
                TrackAttack();
            }
            if (!Target.IsCasting) return;
            if (BloodElf && ArcaneTorrent.IsReady && Target.DistanceToSelf <= 8)
            {
                ArcaneTorrent.Reset();
                CastSpell("UberMage.ArcaneTorrent", false);
                ManaTapCharges = 0;
                TrackAttack();
            }
        }

        protected override void DealWithAdds(GUnit Target)
        {
            OOberLog("Deal With Adds....");

            //Water Elemental
            if (CanUseMana() && UseWaterElemental == "Only on Adds" && WaterElemental.IsReady)
                SummonWaterElemental();

            // Dragons Breath
            if (CanUseMana() && UseDragonsBreath == "Only on Adds" &&
                DragonsBreath.IsReady &&
                Target != null &&
                Target.IsValid &&
                Target.DistanceToSelf <= Context.MeleeDistance &&
                IsKeyReady("UberMage.DragonsBreath"))
            {
                CastSpell("UberMage.DragonsBreath");
                DragonsBreath.Reset();
            }

            // Arcane Explosion time?
            if (CanUseMana() && AttackersInRange(8) > 0 && USEARCANEEXPLOSION && IsKeyReady("UberMage.ArcaneExplosion"))
            {
                CastSpell("UberMage.ArcaneExplosion");
                TrackAttack();
                if (AllDone(Target, false)) return;
            }

            // Flamestrike time?
            if (CanUseMana() && AttackersInRange(8) > 0 && UseFlamestrikeAdds && Flamestrike.IsReady && IsKeyReady("UberMage.FlameStrike"))
            {
                CastFlamestrike();
                TrackAttack();
                if (AllDone(Target, false)) return;
            }

            // Blast Wave time?
            if (CanUseMana() && AttackersInRange(8) > 0 && UseBlastwaveAdds && Blastwave.IsReady && IsKeyReady("UberMage.Blastwave"))
            {
                CastSpell("UberMage.BlastWave");
                Blastwave.Reset();
                TrackAttack();
                if (AllDone(Target, false)) return;
            }

            // Blizzard time?
            if (CanUseMana() && AttackersInRange(8) > 0 && UseBlizzardAdds && Blizzard.IsReady && IsKeyReady("UberMage.Blizzard"))
            {
                CastBlizzard();
                TrackAttack();
                if (AllDone(Target, false)) return;
            }

            // If we got 1 add, poly it!
            if (Polyd.IsReady) PolyAdd();
        }

        protected override GCombatResult DoEndCombat(GCombatResult CombatResult)
        {
            // If we poly'd someone, try to set it up as the next target and possibly grab some health/mana
            // before the next fight.  We won't be able to rest, so it has to be now:
            if (CombatResult == GCombatResult.Success)
            {
                if (PolyGUID == 0) return GCombatResult.Success;
                GUnit Add = GObjectList.FindUnit(PolyGUID);

                if (Add == null) return GCombatResult.Success;

                if (!Add.SetAsTarget(false))
                {
                    Context.Log("! Could not target poly'd unit after combat, name = \"" + Add.Name + "\", id = " + Add.GUID.ToString("x"));
                    return GCombatResult.Success;
                }
                // Tell Glider to immediately begin wasting this guy and not rest:
                return GCombatResult.SuccessWithAdd;
            }
            return CombatResult;
        }

        protected override bool CheckCastInterrupt()
        {
            if (PULLING && Me.IsUnderAttack) return true;
            return false;
        }

        #endregion

    }

    // 03/05/2008
    public class OOberClass : PPather
    {

        #region Virtuals
        protected override string UberClassName
        {
            get { return "OOberClass"; }
        }

        public override string DisplayName
        {
            get { return "UberLibrary Class"; }
        }

        protected virtual bool PreCastSpell(string Spell)
        {
            return true;
        }

        protected virtual void PostCastSpell(string Spell)
        {
        }

        protected virtual bool CheckBuffs(bool bApplyOne)
        {
            return false;
        }

        protected virtual void HandleRunners(GUnit Target)
        {
        }

        protected virtual void InterruptCasters(GUnit Target)
        {
        }

        protected virtual void DealWithAdds(GUnit CurrentTarget)
        {
        }

        protected virtual GCombatResult DoEndCombat(GCombatResult CombatResult)
        {
            return CombatResult;
        }

        protected virtual void DoHeal(GUnit Target)
        {
        }

        protected virtual void DoEmergencyHeal(GUnit Target)
        {
        }

        protected virtual void DoExtraHeal(GUnit Target)
        {
        }

        protected virtual void GetExtraMana(GUnit Target)
        {
        }

        protected virtual void PreDrink()
        {
        }

        protected virtual bool BeforeEatorDrink()
        {
            return true;
        }

        protected virtual bool BuffFriend(GUnit Target)
        {
            return false;
        }

        protected virtual bool CheckCastInterrupt()
        {
            return false;
        }

        #endregion

        #region GRemote Stuff

        bool REMOTEWASUSED = false;
        object GRemoteDLLobj;
        Type GRemoteDLL;
        PropertyInfo GRemoteCommand;
        PropertyInfo GRemoteResponse;
        PropertyInfo GRemoteError;

        bool BindToRemoteDLL()
        {
            bool vrtn = true;
            if (GRemoteDLLobj != null) return vrtn;
            Assembly asm = System.Reflection.Assembly.LoadFile(
                AppDomain.CurrentDomain.BaseDirectory + "\\Classes\\GRemote.dll");
            foreach (Type loadedType in asm.GetTypes())
            {
                if (loadedType.Name == "GRemote")
                {
                    GRemoteDLLobj = loadedType.GetConstructor(new Type[] { }).Invoke(new object[] { });
                    GRemoteDLL = GRemoteDLLobj.GetType();
                    GRemoteCommand = GRemoteDLL.GetProperty("RemoteCommand");
                    if (GRemoteCommand == null) vrtn = false;
                    GRemoteResponse = GRemoteDLL.GetProperty("RemoteResponse");
                    if (GRemoteResponse == null) vrtn = false;
                    GRemoteError = GRemoteDLL.GetProperty("RemoteError");
                    if (GRemoteError == null) vrtn = false;
                }
            }
            if (!vrtn)
            {
                GRemoteDLLobj = null;
                GRemoteDLL = null;
                GRemoteCommand = null;
                GRemoteResponse = null;
                GRemoteError = null;
            }
            return vrtn;
        }

        protected string RemoteCommand(string pCommand, string pError)
        {
            string vrtn;
            //Check For Binding
            pError = "";
            if (!BindToRemoteDLL())
            {
                OOberLog("Can't Bind To DLL");
                pError = "Couldn't attach to GRemote DLL";
                return "";
            }
            REMOTEWASUSED = true;
            //Send Command
            //OOberLog("RemoteCommand:" + pCommand);
            GRemoteCommand.SetValue(GRemoteDLLobj, pCommand, null);
            //Get Response
            vrtn = (GRemoteResponse.GetValue(GRemoteDLLobj, null)).ToString();
            //OOberLog("RemoteResponse:" + vrtn);
            if (vrtn == "")
            {
                OOberLog("Getting Error...");
                pError = (GRemoteError.GetValue(GRemoteDLLobj, null)).ToString();
                OOberLog("RemoteError: " + pError);
            }
            return vrtn;
        }

        protected bool CastSpellAOE(string pSpell)
        {
            string strResponse = "";
            string strError = "";
            if (!Interface.IsKeyReady(pSpell)) return false;
            //Start Spell
            CastSpell(pSpell, false);
            Thread.Sleep(250);
            //Position Cursor
            strResponse = RemoteCommand("/setmouse 0.500/0.500", strError);
            if (strError != "")
            {
                OOberLog("ERROR with setmouse:" + strError);
                return false;
            }
            //Fire Spell
            strResponse = RemoteCommand("/clickmouse left", strError);
            if (strError != "")
            {
                OOberLog("ERROR with clickmouse:" + strError);
                return false;
            }
            return true;
        }

        #endregion

        #region UberLibrary
        bool bInterrupted = false;
        public override void OnStopGlide()
        {
            OOberLog("Got Stop Command!");
            bInterrupted = true;
            mover.Stop();
            string strResponse = "";
            string strError = "";
            if (REMOTEWASUSED)
            {
                strResponse = RemoteCommand("DISCONNECT", strError);
                OOberLog("Remote:" + strResponse + strError);
            }
            OOberLog("Saving Terrain...");
            Thread.Sleep(101);
            base.OnStopGlide();
            OOberLog("Fully Stopped.");
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // SMART HEAL
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GSpellTimer SmartHealTicks = new GSpellTimer(10 * 60 * 1000, true);
        double MyLastHealth = 0;
        double TargetLastHealth = 0;
        protected bool SMARTHEAL = false;

        protected bool SmartHeal()
        {
            // SmartHeal Version 1.02
            double MyHealthRate;
            double TargetHealthRate;
            double MyTicksTilDeath;
            double TargetTicksTilDeath;
            double TotalTicks;
            double MaxHealth;
            GUnit[] Attackers;
            GUnit Target;
            int x;

            Me.Refresh(true);
            if (Me.IsDead) return false; //I'm Dead
            if (Me.TargetGUID == 0) return true; //no target
            Target = Me.Target;
            if (Target == null) return true; //no target
            if (!Target.IsValid) return true; //no target
            if (Target.IsDead) return true; //target is dead

            if (SMARTHEAL)
            {
                if (SmartHealTicks.IsReady || Me.Health > MyLastHealth)
                {
                    //Start Tracking Process
                    SmartHealTicks.Reset();
                    MyLastHealth = Me.Health;
                    TargetLastHealth = Target.Health;
                }
                else
                {
                    TotalTicks = SmartHealTicks.TicksSinceLastReset;
                    if (TotalTicks > 0)
                    {
                        //Figure out how much percent per tick we are losing
                        MyHealthRate = (MyLastHealth - Me.Health) / TotalTicks;
                        //Use it to calc how long til death
                        if (MyHealthRate == 0) MyTicksTilDeath = 999999;
                        else MyTicksTilDeath = Me.Health / MyHealthRate;
                        //little buffer against the player to be sure we don't cut too close
                        MyTicksTilDeath = MyTicksTilDeath - 2000;
                        //Factor In Adds
                        MaxHealth = 0;
                        GObjectList.SetCacheDirty();
                        Attackers = GObjectList.GetAttackers();
                        for (x = 0; x < Attackers.Length; x++)
                            if (MaxHealth < Attackers[x].Health) MaxHealth = Attackers[x].Health;
                        //Figure out how much percent per tick target losing
                        TargetHealthRate = (TargetLastHealth - MaxHealth) / TotalTicks;
                        //Use it to calc how long til death
                        if (TargetHealthRate == 0) TargetTicksTilDeath = 999999;
                        else TargetTicksTilDeath = MaxHealth / TargetHealthRate;
                        //If target is set to die before me, don't bother healing
                        //OOberLog("Smart Heal -------------------------");
                        //OOberLog("MyTicksTilDeath      : " + (int)MyTicksTilDeath);
                        //OOberLog("TargetTicksTilDeath: " + (int)TargetTicksTilDeath);
                        if (TargetTicksTilDeath < MyTicksTilDeath)
                        {
                            //OOberLog("Recommendation: DON'T HEAL!");
                            return false;
                        }
                        else
                        {
                            //OOberLog("Recommendation: HEAL!");
                            return true;
                        }
                    }
                }
            }

            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // BuffNearbyFriends - Buffs and/or Heals Nearby Friends
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GSpellTimer WaitToBuff = new GSpellTimer(1 * 1000, true);
        protected double FRIENDSCANDIST = 20;
        protected bool BuffNearbyFriends()
        {
            if (!WaitToBuff.IsReady) return false;
            bool brtn = false;
            MajorFaction MyMajorFaction = GetMajorFaction(Me);
            GObjectList.SetCacheDirty();
            GUnit[] Units = GObjectList.GetUnits();
            for (int x = 0; x < Units.Length; x++)
            {
                if (Units[x].IsValid &&
                    Units[x].Health > .01 &&
                    Units[x].GUID != Me.GUID &&
                    !IsMounted(Units[x]) &&
                    GetMajorFaction(Units[x]) == MyMajorFaction &&
                    (Units[x].IsPlayer || IsPet(Units[x])) &&
                    Units[x].DistanceToSelf < FRIENDSCANDIST &&
                    !TooHigh(Units[x]) &&
                    !Me.IsUnderAttack &&
                    !Me.IsDead)
                {
                    if (BuffFriend(Units[x])) brtn = true;
                }
            }
            if (brtn && Me.TargetGUID != 0) SendKey("Common.TargetSelf");
            if (brtn) WaitToBuff.Reset();
            return brtn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Combat Result Routines
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool TriedAttack;
        GSpellTimer DeathCheck = new GSpellTimer(15 * 1000, true);
        protected void TrackAttack()
        {
            if (!TriedAttack)
            {
                TriedAttack = true;
                DeathCheck.Reset();
            }
        }

        long LastApproachGUID = 0;
        long LastApproachCount = 0;
        protected GCombatResult CheckCommonCombatResult(GUnit Target, bool IsAmbush)
        {
            Me.Refresh(true);
            if (Me.IsDead)
            {
                OOberLog("Combat Result: Player Dead");
                return GCombatResult.Died;
            }
            if (Target == null)
            {
                OOberLog("Combat Result: Invalid Target");
                return GCombatResult.Vanished;
            }
            if (!Target.IsValid)
            {
                OOberLog("Combat Result: Invalid Target");
                return GCombatResult.Vanished;
            }
            if (FailedApproach)
            {
                OOberLog("Combat Result: Failed Target Approach");
                if (LastApproachGUID == Target.GUID)
                {
                    LastApproachCount++;
                    if (LastApproachCount >= 3)
                        return GCombatResult.Bugged;
                    return GCombatResult.Retry;
                }
                else
                {
                    LastApproachGUID = Target.GUID;
                    LastApproachCount = 1;
                    return GCombatResult.Retry;
                }
            }
            Target.Refresh(true);
            if (Target.IsDead)
            {
                if (HasAttackers())
                {
                    OOberLog("Combat Result: Target Dead with Adds");
                    return GCombatResult.SuccessWithAdd;
                }
                GUnit Pet = Me.Pet;
                if (Pet != null && Pet.Refresh(true))
                {
                    GUnit PTarget = Pet.Target;
                    if (PTarget != null && PTarget.Refresh(true))
                    {
                        OOberLog("Combat Result: Target Dead with Adds (Pet in Combat)");
                        return GCombatResult.SuccessWithAdd;
                    }
                }
                OOberLog("Combat Result: Target Dead");
                return GCombatResult.Success;
            }
            if (Target.IsPlayer)
            {
                GLocation closestWP = Context.Profile.FindClosestWaypoint(Me.Location);
                if (Context.CurrentMode != GGlideMode.OneKill && closestWP != null && closestWP.DistanceToSelf > MaxWander)
                {
                    OOberLog("Combat Result: Player Too Far");
                    return GCombatResult.Success;
                }
                if (TooHigh(Target))
                {
                    OOberLog("Combat Result: Player Too High");
                    return GCombatResult.Bugged;
                }
                if (CLOSERPVP)
                {
                    GPlayer topwn = GetClosestPvPPlayer();
                    if (topwn != null && topwn.GUID != Target.GUID && Target.DistanceToSelf > 5)
                    {
                        if (topwn.SetAsTarget(false)) return GCombatResult.SuccessWithAdd;
                    }
                }
                return GCombatResult.Unknown;
            }
            if (IsPet(Target))
            {
                OOberLog("Combat Result: Stupid Pet!");
                return GCombatResult.Bugged;
            }
            if (DeathCheck.IsReady && TriedAttack && (Target.TicksSinceHealthDrop > 15000 || Target.Health == 1))
            {
                OOberLog("Combat Result: Not Dying! (Bugged)");
                return GCombatResult.Bugged;
            }

            if (!Target.IsTargetingMe)
            {
                if (IsOurs(Target)) return GCombatResult.Unknown; //Attacking someone/something in my party
                OOberLog("Combat Result: Not My Target");
                return GCombatResult.OtherPlayerTag;
            }

            return GCombatResult.Unknown;
        }

        protected bool AllDone(GUnit Target, bool IsAmbush)
        {
            Thread.Sleep(10);
            GCombatResult CommonResult = CheckCommonCombatResult(Target, IsAmbush);
            if (CommonResult != GCombatResult.Unknown) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // FinalState - Responsible for sending combat finish state
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GCombatResult FinalState(GUnit Target, bool IsAmbush)
        {
            if (bInterrupted) OOberLog(UberClassName + " KillTarget Stopped By User");
            GCombatResult CommonResult = CheckCommonCombatResult(Target, IsAmbush);
            if (startLocation.DistanceToSelf > MaxWander)
            {
                Movement.MoveToLocation(startLocation, 20, false);
                CommonResult = GCombatResult.Success;
            }
            if (CommonResult == GCombatResult.Unknown) CommonResult = GCombatResult.Success;
            if (CommonResult == GCombatResult.Success ||
                CommonResult == GCombatResult.SuccessWithAdd)
            {
                CommonResult = DoEndCombat(CommonResult);
                ResetBTMTimer();
                CheckTrinkets("After Combat");
            }
            OOberLog(UberClassName + " KillTarget Finished");
            FailedApproach = false;
            mover.Stop();
            if (Context.CurrentMode == GGlideMode.OneKill)
            {
                GUnit MOB = GObjectList.GetNearestHostile();
                if (MOB != null && MOB.DistanceToSelf < PullDistance) CommonResult = KillTarget(MOB, false);
            }
            return CommonResult;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ActivePVP - Actively attacks a PVP Player
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool PVPENABLED = false;
        //double PVPLEVELDIFFERENCE = 10;
        protected bool ActivePVP()
        {
            // check if we can initiate attacks
            if (!PVPENABLED) return false;
            // Look for a killable...
            OOberLog("Looking for PVP Target...");
            GPlayer topwn = GetClosestPvPPlayer();
            do
            {
                if (topwn != null) OOberLog("Closest Target:" + topwn.Name + " (" + topwn.DistanceToSelf + "yds vs Pull Dist: " + PullDistance.ToString() + ")");
                if (topwn != null && !topwn.IsDead &&
                    topwn.DistanceToSelf < PullDistance)
                {
                    if (!topwn.SetAsTarget(false))
                    {
                        OOberLog("can not target player " + topwn.Name);
                    }
                    else
                    {
                        //OOberLog("I will not kill " + topwn.Name + ". Lucky him");
                        OOberLog("kill " + topwn.Name + " dead: " + topwn.IsDead);
                        KillTarget(topwn, false);
                        return true;
                    }
                }
                topwn = GetClosestPvPPlayer();
            } while (topwn != null && !topwn.IsDead &&
                    topwn.DistanceToSelf < PullDistance);
            //No Target Found
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ToggleCombat - enable/disable combat
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void ToggleCombat()
        {
            OOberLog("ToggleCombat");
            //SendKey("Common.ToggleCombat");
            Context.CastSpell("Common.ToggleCombat", false, true);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // StopWand - Stops Firing the wand
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool USESWAND = false;
        protected void StopWand()
        {
            if (!USESWAND) return;
            GSpellTimer Wait = new GSpellTimer(3000, true);
            OOberLog("Checking Wand for Stop");
            if (!Context.Interface.IsKeyFiring(UberClassName + ".Wand"))  // Not firing, screw it.
                return;
            OOberLog("StopWand");
            Context.SendKey(UberClassName + ".Wand");
            Wait.Reset();
            while (Context.Interface.IsKeyFiring(UberClassName + ".Wand") && !Wait.IsReady) Thread.Sleep(100);
            Wait.Reset();
            while (!IsKeyReady(UberClassName + ".Wand") && !Wait.IsReady) Thread.Sleep(100);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // StartWand - Starts Firing the wand
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void StartWand()
        {
            if (!USESWAND) return;
            GSpellTimer Wait = new GSpellTimer(5000, true);
            OOberLog("Checking Wand for Start");
            if (Context.Interface.IsKeyFiring(UberClassName + ".Wand")) //Already firing, screw it.
                return;
            OOberLog("StartWand");
            Context.SendKey(UberClassName + ".Wand");
            Wait.Reset();
            while (!Context.Interface.IsKeyFiring(UberClassName + ".Wand") && !Wait.IsReady) Thread.Sleep(100);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CastSpell - CastSpell Replacement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool InPreCast = false;
        bool InPostCast = false;
        GSpellTimer OOberCooldown = new GSpellTimer(75, true);
        protected bool USEOOBERCAST = true;

        protected bool CastSpell(string pCommand)
        {
            bool brtn;
            brtn = CastSpell(pCommand, false, true, false, 1000, true);
            return brtn;
        }

        protected bool CastSpell(string pCommand, bool CheckFirst)
        {
            bool brtn;
            brtn = CastSpell(pCommand, CheckFirst, true, false, 1000, true);
            return brtn;
        }

        protected bool CastSpell(string pCommand, bool CheckFirst, bool WaitGCD, bool FastReturn)
        {
            return CastSpell(pCommand, CheckFirst, WaitGCD, FastReturn, 1000, true);
        }

        protected bool CastSpell(string pCommand, bool CheckFirst, bool WaitGCD, bool FastReturn, int ChannelWaitTime)
        {
            return CastSpell(pCommand, CheckFirst, WaitGCD, FastReturn, ChannelWaitTime, true);
        }

        protected bool CastSpell(string pCommand, bool CheckFirst, bool WaitGCD, bool FastReturn, int ChannelWaitTime, bool FaceWhileCasting)
        {
            bool brtn;
            bool breakcast;
            string reallycast;
            GSpellTimer ChannelWaitTimer = new GSpellTimer(ChannelWaitTime, true);
            if (CheckFirst && !IsKeyReady(pCommand)) return false;
            OOberLog("OOberCast: " + pCommand);
            if (!InPreCast)
            {
                InPreCast = true;
                if (!PreCastSpell(pCommand)) { InPreCast = false; return false; }
                InPreCast = false;
            }
            //Turn off Our Wand
            StopWand();
            //Cast The Spell
            if (USEOOBERCAST)
            {
                GUnit Target = Me.Target;
                reallycast = SmartCastReplace(pCommand);
                if (WaitGCD) WaitForGCD(reallycast, 1500);
                if (Target != null && Target.IsValid && Target.GUID != Me.GUID) Face(Target);
                OOberCooldown.Wait();
                Context.SendKey(reallycast);
                OOberCooldown.Reset();
                //Channeling Wait with Aim
                brtn = false;
                if (!FastReturn)
                {
                    ChannelWaitTimer.Reset();
                    breakcast = false;
                    while (!ChannelWaitTimer.IsReady && !breakcast)
                    {
                        Thread.Sleep(100);
                        if (Me.IsCasting)
                        {
                            brtn = true;
                            while (Me.IsCasting && !breakcast)
                            {
                                if (FaceWhileCasting && Target != null && Target.IsValid && Target.GUID != Me.GUID) Face(Target);
                                Thread.Sleep(10);
                                breakcast = CheckCastInterrupt();
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                reallycast = SmartCastReplace(pCommand);
                brtn = Context.CastSpell(reallycast, WaitGCD, FastReturn, ChannelWaitTime);
            }
            SmartCastLearn();
            if (!InPostCast)
            {
                InPostCast = true;
                PostCastSpell(pCommand);
                InPostCast = false;
            }
            Me.SetBuffsDirty();
            return brtn;
        }

        protected bool CastBuff(string pCommand)
        {
            bool brtn;
            brtn = CastSpell(pCommand, false, true, false, 1000, false);
            return brtn;
        }

        protected bool CastBuff(string pCommand, bool CheckFirst)
        {
            bool brtn;
            brtn = CastSpell(pCommand, CheckFirst, true, false, 1000, false);
            return brtn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CastSpellAndWaitForRage
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool CastSpellAndWaitForRage(string name)
        {
            return CastSpellAndWaitForRage(name, 1500);
        }

        protected bool CastSpellAndWaitForRage(string name, int time)
        {
            if (!WaitForGCD(name, 1500)) return false;
            SendKey(name);
            return WaitForRageLoss(time);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // SendKey - SendKey Replacement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void SendKey(string pCommand)
        {
            SendKey(pCommand, false, false);
        }

        protected void SendKey(string pCommand, bool ResetGCD, bool WaitForGCD)
        {
            if (WaitForGCD) OOberCooldown.Wait();
            OOberLog("SendKey: " + pCommand);
            if (ResetGCD) OOberCooldown.Reset();
            Context.SendKey(pCommand);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // VendorInteract - Handles all Vendor Interaction
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected string VENDORNAME = null;
        protected bool VENDORREPAIR = true;
        protected bool VENDORSELL = true;
        protected string VENDORQUALITY = "Common";
        protected string VENDORITEMSTOKEEP = "";
        GSpellTimer Selling = new GSpellTimer(10 * 60 * 1000, true);

        protected bool SellToVendor()
        {
            if (Selling.IsReady)
            {
                GObjectList.SetCacheDirty();
                GUnit vendor = GObjectList.FindUnit(VENDORNAME);
                if (vendor != null && vendor.DistanceToSelf < 15)
                {
                    OOberLog("Selling Stuff");
                    mover.Stop();
                    VendorInteract();
                    Selling.Reset();
                    return true;
                }
            }
            return false;
        }

        void VendorInteract()
        {
            int maxquality;
            int thisquality;
            string vUpperName;
            if (!VENDORREPAIR && !VENDORSELL) return;
            VENDORITEMSTOKEEP = VENDORITEMSTOKEEP.ToUpper();
            maxquality = 0;
            if (VENDORQUALITY == "Poor") maxquality = 1;
            if (VENDORQUALITY == "Common") maxquality = 2;
            if (VENDORQUALITY == "Uncommon") maxquality = 3;
            if (VENDORQUALITY == "Rare") maxquality = 4;
            if (VENDORQUALITY == "Epic") maxquality = 5;
            if (VENDORQUALITY == "Legendary") maxquality = 6;
            if (VENDORQUALITY == "Artifact") maxquality = 7;
            GObjectList.SetCacheDirty();
            GUnit guy = GObjectList.FindUnit(VENDORNAME);
            if (guy == null)
            {
                GContext.Main.Log("Never found vendor");
                return;
            }
            if (!Approach(guy, 3.0)) return;   // Get extra close to make sure.  
            guy.Interact();
            if (GPlayerSelf.Me.Target != guy)
            {
                GContext.Main.Log("Never managed to click on vendor");
                return;
            }
            GMerchant Merchant = new GMerchant();
            if (Merchant.IsVisible)
            {
                if (Merchant.IsRepairEnabled && VENDORREPAIR)   // Might as well fix it up while we're here.  
                    Merchant.ClickRepairButton();
                OOberLog("Opening Bags");
                if (VENDORSELL)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        GInterfaceObject CurBag = Context.Interface.GetByName("CharacterBag" + b + "Slot");
                        CurBag.ClickMouse(false);
                        Thread.Sleep(100);
                        if (CurBag == null)
                        {
                            OOberLog("Bag not opening, skipping");
                            continue;
                        }
                    }
                    long[] AllBags = GPlayerSelf.Me.Bags;
                    int cb = 0;
                    foreach (long One in AllBags)
                    {
                        cb++;
                        GContainer bag = (GContainer)GObjectList.FindObject(One);
                        if (bag != null)
                        {
                            OOberLog("Opening Bag: " + bag.Name);
                            long[] Contents = bag.BagContents;
                            for (int i = 0; i < Contents.Length; i++)
                            {
                                bool Skip = false;
                                if (Contents[i] == 0)
                                    continue;
                                GItem CurItem = (GItem)GObjectList.FindObject(Contents[i]);
                                OOberLog("Checking: " + CurItem.Name);
                                //Check for Safe Item
                                vUpperName = (string)(CurItem.Name).ToUpper();
                                vUpperName = "\"" + vUpperName + "\"";
                                if (VENDORITEMSTOKEEP.Contains(vUpperName))
                                {
                                    OOberLog("Not Selling Item: " + CurItem.Name + " Reason=\"Is on safe list\"");
                                    Skip = true;
                                    break;
                                }
                                //Check for Keeps
                                thisquality = 0;
                                if (CurItem.Definition.Quality == GItemQuality.Poor) thisquality = 1;
                                if (CurItem.Definition.Quality == GItemQuality.Common) thisquality = 2;
                                if (CurItem.Definition.Quality == GItemQuality.Uncommon) thisquality = 3;
                                if (CurItem.Definition.Quality == GItemQuality.Rare) thisquality = 4;
                                if (CurItem.Definition.Quality == GItemQuality.Epic) thisquality = 5;
                                if (CurItem.Definition.Quality == GItemQuality.Legendary) thisquality = 6;
                                if (CurItem.Definition.Quality == GItemQuality.Artifact) thisquality = 7;
                                if (thisquality > maxquality)
                                {
                                    OOberLog("Not Selling Item: " + CurItem.Name + " Reason=\"Quality too high\"");
                                    Skip = true;
                                }

                                //If we got here, we plan on selling the item
                                if (!Skip)
                                {
                                    OOberLog("Selling Item: " + CurItem.Name);
                                    GInterfaceObject CurItemObj = Context.Interface.GetByName("ContainerFrame" + (cb + 1) + "Item" + (bag.SlotCount - i));
                                    CurItemObj.ClickMouse(true);
                                    Thread.Sleep(500);
                                }
                            }
                        }
                    }
                }
                Merchant.Close();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CheckTrinkets - Handles all Trinket Interaction
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GSpellTimer Trinket1;
        GSpellTimer Trinket2;
        GSpellTimer Trinket3;
        GSpellTimer Trinket4;
        GSpellTimer Trinket5;
        GSpellTimer Trinket6;
        protected string USETRINKET1 = "Never";
        protected string USETRINKET2 = "Never";
        protected string USETRINKET3 = "Never";
        protected string USETRINKET4 = "Never";
        protected string USETRINKET5 = "Never";
        protected string USETRINKET6 = "Never";

        protected void CheckTrinkets(string pSituation)
        {
            if ((USETRINKET1 == pSituation && Trinket1.IsReady))
            {
                CastSpell(UberClassName + ".Trinket1", false);
                Trinket1.Reset();
            }
            if ((USETRINKET2 == pSituation && Trinket2.IsReady))
            {
                CastSpell(UberClassName + ".Trinket2", false);
                Trinket2.Reset();
            }
            if ((USETRINKET3 == pSituation && Trinket3.IsReady))
            {
                CastSpell(UberClassName + ".Trinket3", false);
                Trinket3.Reset();
            }
            if ((USETRINKET4 == pSituation && Trinket4.IsReady))
            {
                CastSpell(UberClassName + ".Trinket4", false);
                Trinket4.Reset();
            }
            if ((USETRINKET5 == pSituation && Trinket5.IsReady))
            {
                CastSpell(UberClassName + ".Trinket5", false);
                Trinket5.Reset();
            }
            if ((USETRINKET6 == pSituation && Trinket6.IsReady))
            {
                CastSpell(UberClassName + ".Trinket6", false);
                Trinket6.Reset();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ChaseTarget - Handles Chasing runners
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        double CHASEGAPMAX = 80;
        double CHASETRAVELMAX = 30;
        protected void ChaseTarget(GUnit Target)
        {
            Approach(Target, 4, true, 25000);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ForceRest - Handles Resting up to proper levels
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool FORCEREST = false;
        protected void ForcedRest()
        {
            bool showmsg = true;
            if (FORCEREST)
            {
                Me.Refresh(true);
                while (!Me.IsDead && !Me.IsUnderAttack && ((Me.Mana < Context.RestMana) || (Me.Health < Context.RestHealth)))
                {
                    if (showmsg)
                    {
                        OOberLog("Forcing Rest...Waiting for Health/Mana");
                        SendKey("Common.Sit");
                    }
                    showmsg = false;
                    Thread.Sleep(101);
                    Me.Refresh(true);
                }
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // BetweenTargetMode - Handles Mount between targets
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected string TRAVELFORM = "Default";
        protected GSpellTimer TRAVELFORMDELAYTIMER = new GSpellTimer(5 * 1000, false);
        protected int TRAVELFORMDELAY;

        protected void ResetBTMTimer()
        {
            if (TRAVELFORM == "Distance Mount")
                TRAVELFORMDELAYTIMER = new GSpellTimer(5 * 1000, false);
            else
                TRAVELFORMDELAYTIMER = new GSpellTimer(TRAVELFORMDELAY * 1000, false);
        }

        protected bool BetweenTargetMode(string classname)
        {
            bool bRdy;
            bRdy = TRAVELFORMDELAYTIMER.IsReady;
            if (TRAVELFORM == "Delay Mount" && bRdy && !IsMounted())
            {
                OOberLog("Mounting:" + TRAVELFORM);
                mover.Stop();
                Thread.Sleep(500);
                LeaveForm();
                Thread.Sleep(500);
                CastSpell(classname + ".Mount");
                int futile = 30;
                while (futile > 0)
                {
                    Thread.Sleep(101);
                    futile--;
                    if (IsMounted()) futile = 0;
                }
                if (!IsMounted())
                {
                    //Didn't change try again in 15 seconds
                    TRAVELFORMDELAYTIMER = new GSpellTimer(15 * 1000, false);
                    return false;
                }
                return true;
            }
            if (TRAVELFORM == "Distance Mount" && bRdy && !IsMounted())
            {
                OOberLog("Mounting:" + TRAVELFORM);
                GObjectList.SetCacheDirty();
                GUnit MOB = GObjectList.GetNearestHostile();
                if (MOB == null || (MOB != null && MOB.DistanceToSelf > TRAVELFORMDELAY))
                {
                    mover.Stop();
                    Thread.Sleep(500);
                    LeaveForm();
                    Thread.Sleep(500);
                    CastSpell(classname + ".Mount");
                    int futile = 30;
                    while (futile > 0)
                    {
                        Thread.Sleep(101);
                        futile--;
                        if (IsMounted()) futile = 0;
                    }
                    if (!IsMounted())
                    {
                        //Didn't change try again in 15 seconds
                        TRAVELFORMDELAYTIMER = new GSpellTimer(15 * 1000, false);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // LowMana - Tells us if we are getting low on mana
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool bINLOWMANA = false;
        protected double LOWMANA = .30;
        protected double LOWMANARESET = .50;
        protected bool LowMana()
        {
            Me.Refresh(true);
            if (bINLOWMANA)
            {
                if (Me.Mana < LOWMANARESET) return true;
            }
            else
            {
                if (Me.Mana < LOWMANA)
                {
                    bINLOWMANA = true;
                    return true;
                }
            }
            bINLOWMANA = false;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CanUseMana - Returns True if we can use mana for NON-HEALING Spells
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected double MANA_HEALRESERVE = 0;
        protected double MANA_HEALRESERVE_ADDS = -1;
        protected bool CanUseMana()
        {
            double manalevel;
            manalevel = MANA_HEALRESERVE;
            if (HasAdds() && MANA_HEALRESERVE_ADDS > -1) manalevel = MANA_HEALRESERVE_ADDS;
            Me.Refresh(true);
            if (Me.Mana < manalevel) return false;
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CheckState - Responsible for handling various checks after each step
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        int CheckStateThrottle = 0;
        GSpellTimer CheckStateDelay;
        protected bool CheckState(GUnit Target, bool IsAmbush)
        {
            if (bInterrupted) return true;
            if (FailedApproach) return true;
            if (AllDone(Target, IsAmbush)) return true;
            if (CheckStateThrottle > 0)
            {
                if (CheckStateThrottle > 3000) CheckStateThrottle = 3000;
                if (CheckStateDelay == null) CheckStateDelay = new GSpellTimer(CheckStateThrottle, false);
                if (!CheckStateDelay.IsReady) return AllDone(Target, IsAmbush);
                CheckStateDelay.Reset();
            }
            Me.SetBuffsDirty();
            Me.Refresh(true);
            if (AllDone(Target, IsAmbush)) return true;
            CheckCombatHealth(Target);
            if (AllDone(Target, IsAmbush)) return true;
            CheckCombatMana(Target);
            if (AllDone(Target, IsAmbush)) return true;
            TweakMeleePosition(Target);
            if (AllDone(Target, IsAmbush)) return true;
            if (Target.IsCasting) { InterruptCasters(Target); if (AllDone(Target, IsAmbush)) return true; }
            if (IsRunningAway(Target)) { HandleRunners(Target); if (AllDone(Target, IsAmbush)) return true; }
            ConsiderAvoidAdds(Target);
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // KillTargetExtras - Responsible for sending combat finish state
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool KillTargetExtras(GUnit Target, bool IsAmbush)
        {
            CheckTrinkets("Always");
            if (AllDone(Target, IsAmbush)) return true;
            if (HasAdds())
            {
                CheckTrinkets("Only on Adds");
                if (AllDone(Target, IsAmbush)) return true;
                DealWithAdds(Target);
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // WaitForSnack - Wait til we're done eating and/or drinking
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GSpellTimer EatOrDrinkWait = new GSpellTimer(30 * 1000, true);
        bool bIsEating;
        bool bIsDrinking;
        protected bool ALWAYS_EATANDDRINK_TOGETHER = false;
        protected void WaitForSnack()
        {
            while (!EatOrDrinkWait.IsReady)
            {
                Me.Refresh(true);
                Thread.Sleep(101);
                if (Me.IsDead)
                {
                    EatOrDrinkWait.ForceReady(); //Jump Out
                }
                if (Me.IsUnderAttack)
                {
                    EatOrDrinkWait.ForceReady(); //Jump Out
                }
                else if (bIsEating && !bIsDrinking)
                {
                    if (Me.Health == 1.0) EatOrDrinkWait.ForceReady();
                }
                else if (!bIsEating && bIsDrinking)
                {
                    if (Me.Mana == 1.0) EatOrDrinkWait.ForceReady();
                }
                else
                {
                    if (Me.Health == 1.0 && Me.Mana == 1.0) EatOrDrinkWait.ForceReady();
                }
            }
            bIsEating = false;
            bIsDrinking = false;
            if (Me.IsSitting && !Me.IsDead) { SendKey("Common.Sit"); Thread.Sleep(401); }
        }

        protected void EatSomething()
        {
            if (Me.IsDead) return;
            if (Me.Health < Context.RestHealth && !Me.IsUnderAttack && GetActionInventory(UberClassName + ".Eat") > 0)
            {
                PreDrink();
                DoEat();
                if (ALWAYS_EATANDDRINK_TOGETHER) DoDrink();
            }
        }

        void DoEat()
        {
            int[] EatingFood =
            {433,434,435,1127,1129,1131,2639,5004,5005,5006,5007,
             6410,7737,10256,10257,18229,18230,18231,18232,18233,
             18234,22731,24005,24707,24800,24869,25660,25695,25700,
             25702,25886,25888,26260,26401,26472,26474,27094,28616,
             29008,29073,32112,33253,33255,33258,33260,33262,33264,
             33266,33269,33725,33773,35270,35271,40543,40745,40768,
             41030,42311};

            Me.Refresh(true);
            if (Me.HasBuff(EatingFood)) return;

            OOberLog("Time to Eat!");
            if (!BeforeEatorDrink()) return;
            int Wait = 15;
            while (Wait > 0)
            {
                CastSpell(UberClassName + ".Eat", false);
                Thread.Sleep(100);
                Me.Refresh(true);
                if (Me.IsDead) Wait = 0;
                if (Me.IsUnderAttack) Wait = 0;
                if (Me.HasBuff(EatingFood)) Wait = 0;
                Wait--;
            }
            EatOrDrinkWait.Reset();
            bIsEating = true;
        }

        protected void DrinkSomething()
        {
            if (Me.IsDead) return;
            if (Me.Mana < Context.RestMana && !Me.IsUnderAttack && GetActionInventory(UberClassName + ".Drink") > 0)
            {
                PreDrink();
                DoDrink();
                if (ALWAYS_EATANDDRINK_TOGETHER) DoEat();
            }
        }

        protected void DoDrink()
        {
            int[] DrinkingDrink =
            {430,431,432,1133,1135,1137,10250,22734,24355,
             25696,26261,26402,26473,26475,27089,29007,
             30024,34291,43154,43155};

            Me.Refresh(true);
            if (Me.HasBuff(DrinkingDrink)) return;

            OOberLog("Time to Drink!");
            if (!BeforeEatorDrink()) return;
            int Wait = 15;
            while (Wait > 0)
            {
                CastSpell(UberClassName + ".Drink", true);
                Thread.Sleep(100);
                Me.Refresh(true);
                if (Me.IsDead) Wait = 0;
                if (Me.IsUnderAttack) Wait = 0;
                if (Me.HasBuff(DrinkingDrink)) Wait = 0;
                Wait--;
            }
            EatOrDrinkWait.Reset();
            bIsDrinking = true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Miscellaneous Potion Stuffs
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        GSpellTimer DrinkCooldown = new GSpellTimer(2 * 60 * 1000, true);
        protected double USE_MANA_POTION = .10;
        protected double USE_HEALTH_POTION = .10;

        protected void DrinkManaPotion()
        {
            Me.Refresh(true);
            if (Me.IsDead) return;
            if (Me.Mana < USE_MANA_POTION && DrinkCooldown.IsReady)
            {
                PreDrink();
                CastSpell(UberClassName + ".ManaPotion", true);
                DrinkCooldown.Reset();
            }
        }

        public void DrinkHealthPotion()
        {
            Me.Refresh(true);
            if (Me.IsDead) return;
            if (Me.Health < USE_HEALTH_POTION && DrinkCooldown.IsReady)
            {
                PreDrink();
                CastSpell(UberClassName + ".HealthPotion", true);
                DrinkCooldown.Reset();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Combat Routines - Stay alive in combat
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected double HEAL_TRIGGER = .50;
        protected double QUICKHEAL_TRIGGER = .35;
        protected double HEAL_TRIGGER_ADDS = -1;
        protected double QUICKHEAL_TRIGGER_ADDS = -1;

        protected void CheckCombatMana(GUnit Target)
        {
            if (AllDone(Target, false)) return;
            // GetMana 
            GetExtraMana(Target);
            if (AllDone(Target, false)) return;
            // Try Trinkets
            if (LowMana())
            {
                CheckTrinkets("When Low Mana");
                if (AllDone(Me.Target, false)) return;
            }
            DrinkManaPotion();
        }

        protected void CheckCombatHealth(GUnit Target)
        {
            double healtrig = HEAL_TRIGGER;
            double quicktrig = QUICKHEAL_TRIGGER;
            if (HasAdds() && HEAL_TRIGGER_ADDS > -1) healtrig = HEAL_TRIGGER_ADDS;
            if (HasAdds() && QUICKHEAL_TRIGGER_ADDS > -1) quicktrig = QUICKHEAL_TRIGGER_ADDS;
            if (AllDone(Target, false)) return;
            if (!SmartHeal()) return;
            // Consider Emergency Healing:
            if (Me.Health < quicktrig) { DoEmergencyHeal(Target); if (AllDone(Target, false)) return; }
            // Consider Emergency Healing Trinket
            if (Me.Health < quicktrig) { CheckTrinkets("In Emergency Heal"); if (AllDone(Target, false)) return; }
            // Consider Healing:
            if (Me.Health < healtrig) { DoHeal(Target); if (AllDone(Target, false)) return; }
            // Consider Healing Trinket
            if (Me.Health < healtrig) { CheckTrinkets("In Combat Heal"); if (AllDone(Target, false)) return; }
            // Extra Heal
            DoExtraHeal(Target);
            if (AllDone(Target, false)) return;
            // Still Need Health? Drink up!
            DrinkHealthPotion();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // KillTargetInit - Prepare Uber Library for Combat
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        int SPELL_DELAY = 75;
        protected void KillTargetInit(GUnit Target, bool IsAmbush)
        {
            bInterrupted = false;
            FailedApproach = false;
            startLocation = Me.Location;
            LoadConfig();
            OOberLog("==========================================");
            if (PVPENABLED) { OOberLog("PVP: Enabled"); } else { OOberLog("PVP: Disabled"); }
            if (CLOSERPVP) { OOberLog("PVP Closer Targets: Enabled"); } else { OOberLog("PVP Closer Targets: Disabled"); }
            OOberLog("BTF: " + TRAVELFORM);
            if (USEOOBERFACE) { OOberLog("OOberFace: Enabled"); } else { OOberLog("OOberFace: Disabled"); }
            if (USEOOBERAPPROACH) { OOberLog("OOberApproach: Enabled"); } else { OOberLog("OOberApproach: Disabled"); }
            OOberLog("==========================================");
            OOberLog(UberClassName + ".KillTarget invoked, isAmbush = " + IsAmbush + ", Target = " + Target.ToString() + ", distance = " + Target.DistanceToSelf);
            OOberCooldown = new GSpellTimer(SPELL_DELAY, true);
            TriedAttack = false;
            bINLOWMANA = false;
            if (IsMounted())
            {
                mover.Stop();
                CastSpell(UberClassName + ".Mount");
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // KillTargetReady - Prepare Uber Library for Combat
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool AVOIDGROUPS = false;
        double GROUPRANGECHECK = 15;
        protected bool KillTargetReady(GUnit Target, bool IsAmbush)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            Target.Refresh(true);
            Me.Refresh(true);
            if (Target.IsTargetingMe) IsAmbush = true;
            if (Context.CurrentMode != GGlideMode.OneKill &&
                HasNonPetAttackers() &&
                !Target.IsTargetingMe &&
                !Target.IsPlayer &&
                Target.TargetGUID != Me.PetGUID)
            {
                OOberLog("Ignoring Player Pet");
                return false;
            }
            Face(Target);
            Target.Refresh(true);
            if (CheckState(Target, IsAmbush)) return false;
            if (AVOIDGROUPS &&
                TargetHasFriends(Target, GROUPRANGECHECK)
                && !IsTargettingUs(Target)
                && Context.CurrentMode != GGlideMode.OneKill)
            {
                OOberLog("Target has Friends Nearby");
                return false;
            }
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // StopLeveling - Decides if Glider Should Stop Leveling
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool EXPSTOPENABLED = false;
        double EXPSTOPVALUE = 0;
        bool LEVELSTOPENABLED = false;
        double LEVELSTOPVALUE = 0;

        protected bool StopLeveling()
        {
            bool hearth = false;
            if (EXPSTOPENABLED && Me.Experience >= EXPSTOPVALUE)
            {
                if (LEVELSTOPENABLED == false) hearth = true;
                else if (Me.Level >= LEVELSTOPVALUE) hearth = true;
            }
            else if (LEVELSTOPENABLED && Me.Level >= LEVELSTOPVALUE && !EXPSTOPENABLED)
            {
                hearth = true;
            }
            //Burned
            if (hearth)
            {
                OOberLog("Target Exp/level reached");
                GContext.Main.HearthAndExit();
            }
            return hearth;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // OOberReset - do all the start glide stuff
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void OOberReset()
        {
            LoadConfig();
            WaitToBuff.Reset();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // UberCreateDefaultConfig - Create the uber library default config values
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void UberCreateDefaultConfig()
        {
            Context.SetConfigValue(UberClassName + ".SmartHeal", "False", false);
            Context.SetConfigValue(UberClassName + ".AvoidAdds", "True", false);
            Context.SetConfigValue(UberClassName + ".AvoidAddDistance", "30", false);
            Context.SetConfigValue(UberClassName + ".ForceRest", "True", false);
            Context.SetConfigValue(UberClassName + ".HealTrigger", "50", false);
            Context.SetConfigValue(UberClassName + ".QuickHealTrigger", "35", false);
            Context.SetConfigValue(UberClassName + ".ManaHealReserve", "30", false);
            Context.SetConfigValue(UberClassName + ".HealTriggerAdds", "60", false);
            Context.SetConfigValue(UberClassName + ".QuickHealTriggerAdds", "45", false);
            Context.SetConfigValue(UberClassName + ".ManaHealReserveAdds", "40", false);
            Context.SetConfigValue(UberClassName + ".LowMana", "30", false);
            Context.SetConfigValue(UberClassName + ".LowManaReset", "50", false);
            Context.SetConfigValue(UberClassName + ".VendorName", "", false);
            Context.SetConfigValue(UberClassName + ".VendorRepair", "True", false);
            Context.SetConfigValue(UberClassName + ".VendorSell", "True", false);
            Context.SetConfigValue(UberClassName + ".VendorQuality", "Common", false);
            Context.SetConfigValue(UberClassName + ".VendorItemsToKeep", "", false);
            Context.SetConfigValue(UberClassName + ".UseManaPotion", "10", false);
            Context.SetConfigValue(UberClassName + ".UseHealthPotion", "10", false);
            Context.SetConfigValue(UberClassName + ".ActivePVP", "False", false);
            Context.SetConfigValue(UberClassName + ".FightBack", "False", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket1", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket1Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket2", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket2Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket3", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket3Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket4", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket4Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket5", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket5Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".UseTrinket6", "Never", false);
            Context.SetConfigValue(UberClassName + ".Trinket6Cooldown", "0", false);
            Context.SetConfigValue(UberClassName + ".TravelForm", "Default", false);
            Context.SetConfigValue(UberClassName + ".TravelFormDelay", "15", false);
            Context.SetConfigValue(UberClassName + ".LevelStopEnabled", "False", false);
            Context.SetConfigValue(UberClassName + ".LevelStopValue", "0", false);
            Context.SetConfigValue(UberClassName + ".ExpStopEnabled", "False", false);
            Context.SetConfigValue(UberClassName + ".ExpStopValue", "0", false);
            Context.SetConfigValue(UberClassName + ".ChaseTravelMax", "30", false);
            Context.SetConfigValue(UberClassName + ".ChaseGapMax", "80", false);
            Context.SetConfigValue(UberClassName + ".SpellDelay", "75", false);
            Context.SetConfigValue(UberClassName + ".MountName", "ZZZ", false);
            Context.SetConfigValue(UberClassName + ".Logging", "Debug", false);
            Context.SetConfigValue(UberClassName + ".CheckStateThrottle", "1500", false);
            Context.SetConfigValue(UberClassName + ".CloserPVP", "True", false);
            Context.SetConfigValue(UberClassName + ".UseOOberFace", "True", false);
            Context.SetConfigValue(UberClassName + ".UseOOberApproach", "True", false);
            Context.SetConfigValue(UberClassName + ".UseOOberCast", "True", false);
            Context.SetConfigValue(UberClassName + ".DAMMelee", "True", false);
            Context.SetConfigValue(UberClassName + ".AvoidGroups", "False", false);
            Context.SetConfigValue(UberClassName + ".GroupRangeCheck", "15", false);
            base.UberCreateDefaultConfig();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // UberLoadConfig - Load the uber library config values
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void UberLoadConfig()
        {
            int Temp;
            try { AVOIDADDS = Context.GetConfigBool(UberClassName + ".AvoidAdds"); }
            catch { OOberLog("ERROR Loading AvoidAdds"); AVOIDADDS = false; }
            try { AVOIDADDSDISTANCE = Context.GetConfigInt(UberClassName + ".AvoidAddDistance"); }
            catch { OOberLog("ERROR Loading AvoidAddDistance"); AVOIDADDSDISTANCE = 0; }
            try { FORCEREST = Context.GetConfigBool(UberClassName + ".ForceRest"); }
            catch { OOberLog("ERROR Loading Force Rest"); FORCEREST = false; }
            try { HEAL_TRIGGER = Context.GetConfigDouble(UberClassName + ".HealTrigger") / 100; }
            catch { OOberLog("ERROR Loading Heal Trigger"); HEAL_TRIGGER = .35; }
            try { QUICKHEAL_TRIGGER = Context.GetConfigDouble(UberClassName + ".QuickHealTrigger") / 100; }
            catch { OOberLog("ERROR Loading Quick Heal Trigger"); QUICKHEAL_TRIGGER = .15; }
            try { MANA_HEALRESERVE = Context.GetConfigDouble(UberClassName + ".ManaHealReserve") / 100; }
            catch { OOberLog("ERROR Loading Mana Heal Reserve"); MANA_HEALRESERVE = 0; }
            try { HEAL_TRIGGER_ADDS = Context.GetConfigDouble(UberClassName + ".HealTriggerAdds") / 100; }
            catch { OOberLog("ERROR Loading Heal Trigger"); HEAL_TRIGGER_ADDS = 45; }
            try { QUICKHEAL_TRIGGER_ADDS = Context.GetConfigDouble(UberClassName + ".QuickHealTriggerAdds") / 100; }
            catch { OOberLog("ERROR Loading Quick Heal Trigger"); QUICKHEAL_TRIGGER_ADDS = .25; }
            try { MANA_HEALRESERVE_ADDS = Context.GetConfigDouble(UberClassName + ".ManaHealReserveAdds") / 100; }
            catch { OOberLog("ERROR Loading Mana Heal Reserve"); MANA_HEALRESERVE_ADDS = 0; }
            try { LOWMANA = Context.GetConfigDouble(UberClassName + ".LowMana") / 100; }
            catch { OOberLog("ERROR Loading Low Mana"); LOWMANA = 0; }
            try { LOWMANARESET = Context.GetConfigDouble(UberClassName + ".LowManaReset") / 100; }
            catch { OOberLog("ERROR Loading Low Mana Reset"); LOWMANARESET = 0; }
            try { SMARTHEAL = Context.GetConfigBool(UberClassName + ".SmartHeal"); }
            catch { OOberLog("ERROR Loading SmartHeal"); SMARTHEAL = false; }
            try { VENDORNAME = Context.GetConfigString(UberClassName + ".VendorName"); }
            catch { OOberLog("ERROR Loading VendorName"); VENDORNAME = ""; }
            try { VENDORREPAIR = Context.GetConfigBool(UberClassName + ".VendorRepair"); }
            catch { OOberLog("ERROR Loading Vendor Repair"); VENDORREPAIR = false; }
            try { VENDORSELL = Context.GetConfigBool(UberClassName + ".VendorSell"); }
            catch { OOberLog("ERROR Loading Vendor Sell"); VENDORSELL = false; }
            try { VENDORQUALITY = Context.GetConfigString(UberClassName + ".VendorQuality"); }
            catch { OOberLog("ERROR Loading Vendor Quality"); VENDORQUALITY = ""; }
            try { VENDORITEMSTOKEEP = Context.GetConfigString(UberClassName + ".VendorItemsToKeep"); }
            catch { OOberLog("ERROR Loading Vendor Items To Keep"); VENDORITEMSTOKEEP = ""; }
            try { USE_MANA_POTION = Context.GetConfigDouble(UberClassName + ".UseManaPotion") / 100; }
            catch { OOberLog("ERROR Loading Use Mana Potion"); USE_MANA_POTION = .10; }
            try { USE_HEALTH_POTION = Context.GetConfigDouble(UberClassName + ".UseHealthPotion") / 100; }
            catch { OOberLog("ERROR Loading Use Health Potion"); USE_HEALTH_POTION = .10; }
            try { PVPENABLED = Context.GetConfigBool(UberClassName + ".ActivePVP"); }
            catch { OOberLog("ERROR Loading Initiate PVP"); PVPENABLED = false; }
            try { CLOSERPVP = Context.GetConfigBool(UberClassName + ".CloserPVP"); }
            catch { OOberLog("ERROR Loading CloserPVP"); CLOSERPVP = true; }
            try { USETRINKET1 = Context.GetConfigString(UberClassName + ".UseTrinket1"); }
            catch { OOberLog("ERROR Loading Use Trinket1"); USETRINKET1 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket1Cooldown") * 1000;
                if (Trinket1 == null || (Trinket1 != null && Trinket1.Duration != Temp)) Trinket1 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket1 Cooldown"); Trinket1 = new GSpellTimer(60 * 60 * 1000); }
            try { USETRINKET2 = Context.GetConfigString(UberClassName + ".UseTrinket2"); }
            catch { OOberLog("ERROR Loading Use Trinket2"); USETRINKET2 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket2Cooldown") * 1000;
                if (Trinket2 == null || (Trinket2 != null && Trinket2.Duration != Temp)) Trinket2 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket2 Cooldown"); Trinket2 = new GSpellTimer(60 * 60 * 1000); }
            try { USETRINKET3 = Context.GetConfigString(UberClassName + ".UseTrinket3"); }
            catch { OOberLog("ERROR Loading Use Trinket3"); USETRINKET3 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket3Cooldown") * 1000;
                if (Trinket3 == null || (Trinket3 != null && Trinket3.Duration != Temp)) Trinket3 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket3 Cooldown"); Trinket3 = new GSpellTimer(60 * 60 * 1000); }
            try { USETRINKET4 = Context.GetConfigString(UberClassName + ".UseTrinket4"); }
            catch { OOberLog("ERROR Loading Use Trinket4"); USETRINKET4 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket4Cooldown") * 1000;
                if (Trinket4 == null || (Trinket4 != null && Trinket4.Duration != Temp)) Trinket4 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket4 Cooldown"); Trinket4 = new GSpellTimer(60 * 60 * 1000); }
            try { USETRINKET5 = Context.GetConfigString(UberClassName + ".UseTrinket5"); }
            catch { OOberLog("ERROR Loading Use Trinket5"); USETRINKET5 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket5Cooldown") * 1000;
                if (Trinket5 == null || (Trinket5 != null && Trinket5.Duration != Temp)) Trinket5 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket5 Cooldown"); Trinket5 = new GSpellTimer(60 * 60 * 1000); }
            try { USETRINKET6 = Context.GetConfigString(UberClassName + ".UseTrinket6"); }
            catch { OOberLog("ERROR Loading Use Trinket6"); USETRINKET6 = "Never"; }
            try
            {
                Temp = Context.GetConfigInt(UberClassName + ".Trinket6Cooldown") * 1000;
                if (Trinket6 == null || (Trinket6 != null && Trinket6.Duration != Temp)) Trinket6 = new GSpellTimer(Temp, true);
            }
            catch { OOberLog("ERROR Loading Trinket6 Cooldown"); Trinket6 = new GSpellTimer(60 * 60 * 1000); }
            try { TRAVELFORM = Context.GetConfigString(UberClassName + ".TravelForm"); }
            catch { OOberLog("ERROR Loading TravelForm"); TRAVELFORM = "Default"; }
            try { TRAVELFORMDELAY = Context.GetConfigInt(UberClassName + ".TravelFormDelay"); }
            catch { OOberLog("ERROR Loading TravelFormDelay"); TRAVELFORMDELAY = 5; }
            try { LEVELSTOPENABLED = Context.GetConfigBool(UberClassName + ".LevelStopEnabled"); }
            catch { OOberLog("ERROR Loading LevelStopEnabled"); LEVELSTOPENABLED = false; }
            try { LEVELSTOPVALUE = Context.GetConfigInt(UberClassName + ".LevelStopValue"); }
            catch { OOberLog("ERROR Loading LevelStopValue"); LEVELSTOPVALUE = 0; }
            try { EXPSTOPENABLED = Context.GetConfigBool(UberClassName + ".ExpStopEnabled"); }
            catch { OOberLog("ERROR Loading ExpStopEnabled"); EXPSTOPENABLED = false; }
            try { EXPSTOPVALUE = Context.GetConfigInt(UberClassName + ".ExpStopValue"); }
            catch { OOberLog("ERROR Loading ExpStopValue"); EXPSTOPVALUE = 0; }
            try { CHASETRAVELMAX = Context.GetConfigInt(UberClassName + ".ChaseTravelMax"); }
            catch { OOberLog("ERROR Loading ChaseTravelMax"); CHASETRAVELMAX = 30; }
            try { CHASEGAPMAX = Context.GetConfigInt(UberClassName + ".ChaseGapMax"); }
            catch { OOberLog("ERROR Loading ChaseGapMax"); CHASEGAPMAX = 80; }
            try { SPELL_DELAY = Context.GetConfigInt(UberClassName + ".SpellDelay"); }
            catch { OOberLog("ERROR Loading SpellDelay"); SPELL_DELAY = 75; }
            try { MOUNTNAME = Context.GetConfigString(UberClassName + ".MountName"); }
            catch { OOberLog("ERROR Loading MountName"); MOUNTNAME = "ZZZ"; }
            try { SENDLOGTO = Context.GetConfigString(UberClassName + ".Logging"); }
            catch { OOberLog("ERROR Loading Logging"); SENDLOGTO = "Debug"; }
            try { CheckStateThrottle = Context.GetConfigInt(UberClassName + ".CheckStateThrottle"); CheckStateDelay = null; }
            catch { OOberLog("ERROR Loading CheckStateThrottle"); CheckStateThrottle = 0; }
            try { USEOOBERFACE = Context.GetConfigBool(UberClassName + ".UseOOberFace"); }
            catch { OOberLog("ERROR Loading UseOOberFace"); USEOOBERFACE = true; }
            try { USEOOBERAPPROACH = Context.GetConfigBool(UberClassName + ".UseOOberApproach"); }
            catch { OOberLog("ERROR Loading UseOOberApproach"); USEOOBERAPPROACH = true; }
            try { USEOOBERCAST = Context.GetConfigBool(UberClassName + ".UseOOberCast"); }
            catch { OOberLog("ERROR Loading UseOOberCast"); USEOOBERCAST = true; }
            try { USEDODGEANDMOVE = Context.GetConfigBool(UberClassName + ".DAMMelee"); }
            catch { OOberLog("ERROR Loading DAMMelee"); USEDODGEANDMOVE = true; }
            try { AVOIDGROUPS = Context.GetConfigBool(UberClassName + ".AvoidGroups"); }
            catch { OOberLog("ERROR Loading AvoidGroups"); AVOIDGROUPS = false; }
            try { GROUPRANGECHECK = Context.GetConfigDouble(UberClassName + ".GroupRangeCheck"); }
            catch { OOberLog("ERROR Loading GroupRangeCheck"); GROUPRANGECHECK = 30; }
            base.UberLoadConfig();
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // UberSendToDialog - Send the uber library config values to GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void UberSendToDialog(object configDialog)
        {
            SendToDialog(configDialog, UberClassName + ".SmartHeal");
            SendToDialog(configDialog, UberClassName + ".AvoidAdds");
            SendToDialog(configDialog, UberClassName + ".AvoidAddDistance");
            SendToDialog(configDialog, UberClassName + ".ForceRest");
            SendToDialog(configDialog, UberClassName + ".HealTrigger");
            SendToDialog(configDialog, UberClassName + ".QuickHealTrigger");
            SendToDialog(configDialog, UberClassName + ".ManaHealReserve");
            SendToDialog(configDialog, UberClassName + ".HealTriggerAdds");
            SendToDialog(configDialog, UberClassName + ".QuickHealTriggerAdds");
            SendToDialog(configDialog, UberClassName + ".ManaHealReserveAdds");
            SendToDialog(configDialog, UberClassName + ".LowMana");
            SendToDialog(configDialog, UberClassName + ".LowManaReset");
            SendToDialog(configDialog, UberClassName + ".VendorName");
            SendToDialog(configDialog, UberClassName + ".VendorRepair");
            SendToDialog(configDialog, UberClassName + ".VendorSell");
            SendToDialog(configDialog, UberClassName + ".VendorQuality");
            SendToDialog(configDialog, UberClassName + ".VendorItemsToKeep");
            SendToDialog(configDialog, UberClassName + ".UseHealthPotion");
            SendToDialog(configDialog, UberClassName + ".UseManaPotion");
            SendToDialog(configDialog, UberClassName + ".ActivePVP");
            SendToDialog(configDialog, UberClassName + ".CloserPVP");
            SendToDialog(configDialog, UberClassName + ".FightBack");
            SendToDialog(configDialog, UberClassName + ".UseTrinket1");
            SendToDialog(configDialog, UberClassName + ".Trinket1Cooldown");
            SendToDialog(configDialog, UberClassName + ".UseTrinket2");
            SendToDialog(configDialog, UberClassName + ".Trinket2Cooldown");
            SendToDialog(configDialog, UberClassName + ".UseTrinket3");
            SendToDialog(configDialog, UberClassName + ".Trinket3Cooldown");
            SendToDialog(configDialog, UberClassName + ".UseTrinket4");
            SendToDialog(configDialog, UberClassName + ".Trinket4Cooldown");
            SendToDialog(configDialog, UberClassName + ".UseTrinket5");
            SendToDialog(configDialog, UberClassName + ".Trinket5Cooldown");
            SendToDialog(configDialog, UberClassName + ".UseTrinket6");
            SendToDialog(configDialog, UberClassName + ".Trinket6Cooldown");
            SendToDialog(configDialog, UberClassName + ".TravelForm");
            SendToDialog(configDialog, UberClassName + ".TravelFormDelay");
            SendToDialog(configDialog, UberClassName + ".LevelStopEnabled");
            SendToDialog(configDialog, UberClassName + ".LevelStopValue");
            SendToDialog(configDialog, UberClassName + ".ExpStopEnabled");
            SendToDialog(configDialog, UberClassName + ".ExpStopValue");
            SendToDialog(configDialog, UberClassName + ".ChaseTravelMax");
            SendToDialog(configDialog, UberClassName + ".ChaseGapMax");
            SendToDialog(configDialog, UberClassName + ".SpellDelay");
            SendToDialog(configDialog, UberClassName + ".MountName");
            SendToDialog(configDialog, UberClassName + ".Logging");
            SendToDialog(configDialog, UberClassName + ".CheckStateThrottle");
            SendToDialog(configDialog, UberClassName + ".UseOOberFace");
            SendToDialog(configDialog, UberClassName + ".UseOOberApproach");
            SendToDialog(configDialog, UberClassName + ".UseOOberCast");
            SendToDialog(configDialog, UberClassName + ".DAMMelee");
            SendToDialog(configDialog, UberClassName + ".AvoidGroups");
            SendToDialog(configDialog, UberClassName + ".GroupRangeCheck");
            base.UberSendToDialog(configDialog);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // UberGetFromDialog - Load the uber library config values from GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected override void UberGetFromDialog(object configDialog)
        {
            GetFromDialog(configDialog, UberClassName + ".SmartHeal");
            GetFromDialog(configDialog, UberClassName + ".AvoidAdds");
            GetFromDialog(configDialog, UberClassName + ".AvoidAddDistance");
            GetFromDialog(configDialog, UberClassName + ".ForceRest");
            GetFromDialog(configDialog, UberClassName + ".HealTrigger");
            GetFromDialog(configDialog, UberClassName + ".QuickHealTrigger");
            GetFromDialog(configDialog, UberClassName + ".ManaHealReserve");
            GetFromDialog(configDialog, UberClassName + ".HealTriggerAdds");
            GetFromDialog(configDialog, UberClassName + ".QuickHealTriggerAdds");
            GetFromDialog(configDialog, UberClassName + ".ManaHealReserveAdds");
            GetFromDialog(configDialog, UberClassName + ".LowMana");
            GetFromDialog(configDialog, UberClassName + ".LowManaReset");
            GetFromDialog(configDialog, UberClassName + ".VendorName");
            GetFromDialog(configDialog, UberClassName + ".VendorRepair");
            GetFromDialog(configDialog, UberClassName + ".VendorSell");
            GetFromDialog(configDialog, UberClassName + ".VendorQuality");
            GetFromDialog(configDialog, UberClassName + ".VendorItemsToKeep");
            GetFromDialog(configDialog, UberClassName + ".UseHealthPotion");
            GetFromDialog(configDialog, UberClassName + ".UseManaPotion");
            GetFromDialog(configDialog, UberClassName + ".ActivePVP");
            GetFromDialog(configDialog, UberClassName + ".CloserPVP");
            GetFromDialog(configDialog, UberClassName + ".FightBack");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket1");
            GetFromDialog(configDialog, UberClassName + ".Trinket1Cooldown");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket2");
            GetFromDialog(configDialog, UberClassName + ".Trinket2Cooldown");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket3");
            GetFromDialog(configDialog, UberClassName + ".Trinket3Cooldown");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket4");
            GetFromDialog(configDialog, UberClassName + ".Trinket4Cooldown");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket5");
            GetFromDialog(configDialog, UberClassName + ".Trinket5Cooldown");
            GetFromDialog(configDialog, UberClassName + ".UseTrinket6");
            GetFromDialog(configDialog, UberClassName + ".Trinket6Cooldown");
            GetFromDialog(configDialog, UberClassName + ".TravelForm");
            GetFromDialog(configDialog, UberClassName + ".TravelFormDelay");
            GetFromDialog(configDialog, UberClassName + ".LevelStopEnabled");
            GetFromDialog(configDialog, UberClassName + ".LevelStopValue");
            GetFromDialog(configDialog, UberClassName + ".ExpStopEnabled");
            GetFromDialog(configDialog, UberClassName + ".ExpStopValue");
            GetFromDialog(configDialog, UberClassName + ".ChaseTravelMax");
            GetFromDialog(configDialog, UberClassName + ".ChaseGapMax");
            GetFromDialog(configDialog, UberClassName + ".SpellDelay");
            GetFromDialog(configDialog, UberClassName + ".MountName");
            GetFromDialog(configDialog, UberClassName + ".Logging");
            GetFromDialog(configDialog, UberClassName + ".CheckStateThrottle");
            GetFromDialog(configDialog, UberClassName + ".UseOOberFace");
            GetFromDialog(configDialog, UberClassName + ".UseOOberApproach");
            GetFromDialog(configDialog, UberClassName + ".UseOOberCast");
            GetFromDialog(configDialog, UberClassName + ".DAMMelee");
            GetFromDialog(configDialog, UberClassName + ".AvoidGroups");
            GetFromDialog(configDialog, UberClassName + ".GroupRangeCheck");
            base.UberGetFromDialog(configDialog);
        }

        #endregion

        #region SmartCast
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // SmartCast - Routines to do Smart Casting
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public enum eSpellType
        {
            Heal, Attack, DoT, Other
        };
        public class tSpell
        {
            public string SpellName;
            public eSpellType SpellType;
            public double MinDist = 0;
            public double MaxDist = 30;
            public double MinInstant = 0;
            public double MaxInstant = 0;
            public double MinOvertime = 0;
            public double MaxOvertime = 0;
            public int CDSecs = 0;
        }
        public tSpell[] HEALSPELLS;
        public tSpell[] ATTACKSPELLS;
        public tSpell[] DOTSPELLS;

        bool LEARNSPELL;
        //int LASTSPELL;
        double LastMyHealth;
        double LastMyMana;
        long LastMyPet;
        GBuff[] LastMyBuffs;
        double LastTargetHealth;
        GBuff[] LastTargetBuffs;

        void SmartCastAddSpell(
            string SpellName,
            eSpellType SpellType,
            double MinDist,
            double MaxDist,
            double MinInstant,
            double MaxInstant,
            double MinOvertime,
            double MaxOvertime,
            int CDSecs
        )
        {

        }

        string SmartCastReplace(string pSpell)
        {
            LEARNSPELL = false;
            /*
            int x = -1;
            for (x = 0; x < KNOWNSPELLS.Length; x++)
            {
                if (KNOWNSPELLS[x].SpellName == pSpell) LASTSPELL = x;
            }
            if (x == -1)
            {
                x=KNOWNSPELLS.Length;
                KNOWNSPELLS[x].SpellName = pSpell;
                KNOWNSPELLS[x].SpellType = CastType.Unknown;
                KNOWNSPELLS[x].MinAmount = -1;
                KNOWNSPELLS[x].MaxAmount = -1;
             * */
            //Set up to learn this spell
            LEARNSPELL = false;
            //LASTSPELL = x;
            LastMyHealth = Me.Health;
            LastMyMana = Me.Mana;
            LastMyPet = Me.PetGUID;
            LastMyBuffs = Me.GetBuffSnapshot();
            try
            {
                Me.Target.Refresh(true);
                LastTargetHealth = Me.Target.Health;
                LastTargetBuffs = Me.Target.GetBuffSnapshot();
            }
            catch
            {
                LastTargetHealth = -1;
            }
            //}
            return pSpell;
        }

        void SmartCastLearn()
        {
            //double newval;
            double TargetHealth = 0;
            GBuff[] TargetBuffs;
            int MeBuffDiff = 0;
            int TargetBuffDiff = 0;

            if (LEARNSPELL)
            {
                Thread.Sleep(201);
                GBuff[] MyBuffs = Me.GetBuffSnapshot();
                MeBuffDiff = (MyBuffs.Length - LastMyBuffs.Length);
                if (LastTargetHealth != -1)
                {
                    try
                    {
                        Me.Target.Refresh(true);
                        TargetHealth = Me.Target.Health;
                        TargetBuffs = Me.Target.GetBuffSnapshot();
                        TargetBuffDiff = (TargetBuffs.Length - LastTargetBuffs.Length);
                    }
                    catch
                    {
                        TargetHealth = LastTargetHealth;
                        TargetBuffDiff = 0;
                    }
                }
                //OOberLog("Learning Spell..." + KNOWNSPELLS[LASTSPELL].SpellName);
                OOberLog(LastTargetHealth.ToString() + "..." + TargetHealth.ToString());
                if (Me.Health - LastMyHealth > .05)
                {
                    OOberLog("---> Healing");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.AddHealth;
                }
                else if (Me.Mana - LastMyMana > .05)
                {
                    OOberLog("---> Mana Generation");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.AddMana;
                }
                else if (LastMyPet == 0 && Me.PetGUID != 0)
                {
                    OOberLog("---> Summon Pet");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.Summon;
                }
                else if (LastMyPet != 0 && Me.PetGUID == 0)
                {
                    OOberLog("---> Release Pet");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.UnSummon;
                }
                else if (TargetBuffDiff > 0)
                {
                    OOberLog("---> Damage Over Time");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.DoT;
                }
                else if (TargetHealth != -1 && LastTargetHealth != -1 && LastTargetHealth - TargetHealth > .02)
                {
                    OOberLog("---> Attack");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.Attack;
                }
                else if (MeBuffDiff > 0)
                {
                    OOberLog("---> Buff");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.AddBuff;
                }
                else if (MeBuffDiff < 0)
                {
                    OOberLog("---> DeBuff");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.DeBuff;
                }
                else if (TargetBuffDiff > 0 && TargetHealth == LastTargetHealth)
                {
                    OOberLog("---> DeBuff");
                    //KNOWNSPELLS[LASTSPELL].SpellType = CastType.DeBuff;
                }
                else
                {
                    OOberLog("---> Unknown");
                }
            }

        }

        #endregion

    }

#if PATHERENABLED
    public class PPather : OOberGameClass
    {
        public string PATHERVERSION ="0.31";

    #region Variables
        public const double PI = Math.PI;
        public static Random random = new Random();
        public static UnitRadar radar;
        public static CultureInfo numberFormat = System.Globalization.CultureInfo.InvariantCulture;

        bool BGMode = false;

        public PullTask CurrentPullTask = null;
        public string CurrentContinent = null;
        public PathGraph world = null;
        Spot WasAt = null;

        public enum RunState_e { Stopped, Paused, Running };
        public RunState_e RunState = RunState_e.Stopped;
        public RunState_e WantedState = RunState_e.Stopped;
        public NPCDatabase NPCs = new NPCDatabase();

        public static ToonState ToonData = new ToonState();

        Thread glideThread = null;
        
        GSpellTimer SaveTimer = new GSpellTimer(60 * 1000);
        int XPInitial;
        int XPCurrent;
        GSpellTimer GliderStart;
        int Kills = 0;
        int Deaths = 0;
        int Loots = 0;
        int Harvests = 0;
        int TTL = 0; // time to level in minutes
        int XPh = 0; // XP/h since last level/start
        int KPh = 0;

        PatherForm form;

        private GSpellTimer ChunkLoadT = new GSpellTimer(5000, true);

        #endregion

    #region Startup/Shutdown
        public override void OnStartGlide()
        {

            glideThread = Thread.CurrentThread;

            RunState = RunState_e.Paused;
            WantedState = RunState_e.Running;
            CurrentPullTask = null;

            base.OnStartGlide();
            Context.Log("TotalMemory before " + System.GC.GetTotalMemory(true) / (1024 * 1024) + " MB");

            WasAt = null;
            CurrentPullTask = null;

            string zone = FigureOutZone();

            MPQTriangleSupplier mpq = new MPQTriangleSupplier();
            CurrentContinent = mpq.SetZone(zone);

            BGMode = false;
            Context.Log("Zone is : " + zone);
            Context.Log("Continent is : " + CurrentContinent);
            if (CurrentContinent == null)
            {
                Context.KillAction("Unknown zone " + zone, false);
            }
            else if (CurrentContinent.StartsWith("PVPZone"))
            {
                BGMode = true;
            }

            string myFaction = "Unknown";
            if (IsHordePlayerFaction(Me)) myFaction = "Horde";
            if (IsAlliancePlayerFaction(Me)) myFaction = "Alliance";
            NPCs.SetContinent(CurrentContinent, myFaction);
            ToonData.SetToonName(Me.Name);



            ChunkedTriangleCollection triangleWorld = new ChunkedTriangleCollection(512);
            triangleWorld.SetMaxCached(9);
            triangleWorld.AddSupplier(mpq);

            world = new PathGraph(CurrentContinent, triangleWorld, null);
            //world.locationHeuristics = radar;
            //newMap = new AdvancedMap.Map();
            //newMap.RunMap();

        }

        private void SaveAllState()
        {
            NPCs.Save();
            ToonData.Save();
            if (world != null)
            {
                world.Save();
            }

        }

        public override void OnStopGlide()
        {
            Context.Log("Inside OnStopGlider()");

            //newMap.StopMap();

            /*
            if (Thread.CurrentThread != glideThread && glideThread != null)
            {
                // kill glide thread first
                GSpellTimer timeout = new GSpellTimer(15000);
                GContext.Main.Log("kill glide thread");
                
                glideThread.Abort();
                while (glideThread.IsAlive)
                {
                    GContext.Main.Log("wait for glide thread to stop");
                    Thread.Sleep(500);
                    if (timeout.IsReady) break; 
                }
                Context.Log("glide thread state: " + glideThread.ThreadState); 
            }
            glideThread = null;
            */
            WantedState = RunState_e.Stopped;
            RunState = RunState_e.Stopped;

            SaveAllState();

            if (ToonData != null)
                ToonData.SetToonName(null);
            if (NPCs != null)
                NPCs.SetContinent(null, null); // stop tracking

            if (world != null)
                world.Close();
            world = null;
            CurrentPullTask = null;
            Context.Log("TotalMemory " + System.GC.GetTotalMemory(false) / (1024 * 1024) + " MB");
            //world = null; // release RAM

            Context.Log("TotalMemory after GC " + System.GC.GetTotalMemory(true) / (1024 * 1024) + " MB");
            base.OnStopGlide();
        }

        public override void Startup()
        {
            GContext.Main.Log("Startup in PPather");
            mover = new Mover(Context);
            radar = new UnitRadar();
            form = new PatherForm(this);

            form.ShowInTaskbar = false;
            form.Show();
            base.Startup();
            GContext.Main.ChatLog += new GContext.GChatLogHandler(Pather_ChatLog);
            GContext.Main.CombatLog += new GContext.GCombatLogHandler(Pather_CombatLog);


            /*
                        string []ui = GInterfaceHelper.GetAllInterfaceObjectNames();
                        System.IO.StreamWriter fileout = null;
                        fileout = System.IO.File.CreateText("GossipUIObjects");            
                        int i = 0;
                        foreach(string s in ui)
                        {
                          if(s == null) continue;
                            if(s.IndexOf("Quest") != -1 || s.IndexOf("quest") != -1 ||
                               s.IndexOf("Gossip") != -1 || s.IndexOf("gossip") != -1 )
                            {
                                GInterfaceObject obj  = Context.Interface.GetByName(s);
                                if(obj == null)
                                {
                                }
                                else
                                {
                                    if(obj.IsVisible)
                                        fileout.WriteLine("V " + s);
                                    //else
                                    //    fileout.WriteLine("  " + s);
                                }
                                i++; 
                            }
                        }
                        Context.Log("wrote " + i + " ui objects");
                        fileout.Flush();
                        fileout.Close();
            */

        }

        public override void Shutdown()
        {
            GContext.Main.CombatLog -= new GContext.GCombatLogHandler(Pather_CombatLog);
            GContext.Main.ChatLog -= new GContext.GChatLogHandler(Pather_ChatLog);
            form.Dispose();
            base.Shutdown();
        }

        #endregion

    #region Patroller Entry Point
        public override void Patrol()
        {
            OnStartGlide();

            Kills = 0;
            Loots = 0;
            Harvests = 0;

            XPInitial = Me.Experience;
            GliderStart = new GSpellTimer(0);

            if (!Me.IsInCombat && !Me.IsDead)
                Rest();
            while (true)
            {
                MyPather();
                Thread.Sleep(1000);
            }
        }
        #endregion

    #region Pathing Logic
        private void DoPatrolerLearnTravelMode()
        {

            while (true)
            {
                Thread.Sleep(1000);

                GUnit target = Me.Target;

                if (target != null)
                {
                    Context.Log("Target GUID: " + target.GUID);
                }
            }
        }
        private void MyPather()
        {
            System.IO.TextReader reader = System.IO.File.OpenText("tasks.psc");

            TaskParser t = new TaskParser(reader);
            NodeTask astRoot = t.ParseTask(null);
            reader.Close();


            RootNode root = new RootNode();
            root.AddTask(astRoot);
            root.BindSymbols(); // Just to make it a tad faster



            Task rootTask = CreateTaskFromNode(root, null);
            form.CreateTreeFromTasks(rootTask);
            Activity activity = null;
            GSpellTimer taskTimer = new GSpellTimer(300);
            GSpellTimer updateStatusTimer = new GSpellTimer(2000);
            GSpellTimer nothingToDoTimer = new GSpellTimer(3 * 1000);
            bool exit = false;
            GSpellTimer Tick = new GSpellTimer(100);
            do
            {
                if (RunState != WantedState)
                {
                    if (RunState == RunState_e.Running)
                    {
                        if (activity != null)
                            activity.Stop();
                    }
                    RunState = WantedState;
                }

                if (updateStatusTimer.IsReady)
                {
                    UpdateXP();
                    form.SetStatus(Kills, KPh, Loots, XPh, Harvests, TTL, Deaths);
                    updateStatusTimer.Reset();
                }
                if (RunState == RunState_e.Stopped)
                {
                    Context.Log("Stop wanted. Stopping glide");
                    Context.KillAction("PPather wants to stop", false);
                    Thread.Sleep(500); // pause
                }
                else if (RunState == RunState_e.Paused)
                {
                    UpdateMyPos();
                    Thread.Sleep(100); // pause
                }
                else if (RunState == RunState_e.Running)
                {
                    UpdateMyPos();
                    if (Me.IsDead)
                    {
                        Thread.Sleep(1000);
                        activity = null;
                        GhostRun();
                        Thread.Sleep(1500);
                        if (Me.IsDead)
                        {
                            //!!!
                        }
                        else
                        {
                            Deaths++;
                            Rest();
                        }
                    }




                    if (activity == null || taskTimer.IsReady)
                    {
                        // Reevaluate what to do
                        Location l = new Location(Me.Location);
                        taskTimer.Reset();

                        Activity newActivity = null;
                        if (rootTask.WantToDoSomething())
                        {
                            newActivity = rootTask.GetActivity();
                            nothingToDoTimer.Reset();
                        }

                        if (newActivity != activity)
                        {
                            if (activity != null)
                            {
                                // change activity before it was finished
                                activity.Stop();
                                Task tr = activity.task;
                                while (tr != null)
                                {
                                    tr.isActive = false;
                                    tr = tr.parent;
                                }
                            }
                            activity = newActivity;
                            {
                                Task tr = activity.task;
                                while (tr != null)
                                {
                                    tr.isActive = true;
                                    tr = tr.parent;
                                }
                            }

                            form.SetActivity(activity);
                            if (activity != null)
                            {
                                Context.Log("Got a new activity " + activity);
                                if (SaveTimer.IsReady)
                                {
                                    SaveAllState();
                                    SaveTimer.Reset();
                                }
                                activity.Start();
                            }
                        }
                        if (newActivity == null) activity = null;

                    }

                    if (activity == null)
                    {
                        if (nothingToDoTimer.IsReady)
                        {
                            Context.Log("Script ended. Stopping glide");
                            Context.KillAction("PPather, nothing more to do", false);
                            return;
                        }
                    }
                    else
                        nothingToDoTimer.Reset();
                    //form.SetTask(task); 

                    if (activity != null)
                    {
                        bool done = activity.Do();
                        nothingToDoTimer.Reset(); // did something
                        if (done)
                        {
                            //Context.Log("Finished activity " + activity);
                            activity.task.ActivityDone(activity);
                            Task tr = activity.task;
                            while (tr != null)
                            {
                                tr.isActive = false;
                                tr = tr.parent;
                            }
                            activity = null;
                        }
                    }


                    Tick.Wait();
                    Thread.Sleep(10); // min sleep time
                    Tick.Reset();
                    RunningAction();
                }
            } while (!exit);
        }
        #endregion

    #region Special Moves
        public bool Face(GNode node)
        {
            return Face(node, PI / 8);
        }

        public bool Face(GUnit monster, double tolerance)
        {
            int timeout = 3000;
            if (monster == null) return false;
            GSpellTimer approachTimeout = new GSpellTimer(timeout, false);
            if (Math.Abs(monster.Bearing) < tolerance) return true;
            bool wasDead = monster.IsDead;
            do
            {
                if (Me.IsDead || wasDead != monster.IsDead) { mover.Stop(); return false; }

                double b = monster.Bearing;
                if (b < -tolerance)
                {
                    // to the left
                    mover.RotateLeft(true);
                }
                else if (b > tolerance)
                {
                    // to the rigth
                    mover.RotateRight(true);
                }
                else
                {
                    // ahead
                    mover.Stop();
                    return true;
                }

                UpdateMyPos();
            } while (!approachTimeout.IsReadySlow);

            mover.Stop();
            Context.Log("Face timed out");
            return false;

        }
        public bool Face(GNode monster, double tolerance)
        {

            if (monster == null) return false;
            int timeout = 3000;

            if (mover == null) GContext.Main.Log("mover is null");
            GSpellTimer approachTimeout = new GSpellTimer(timeout, false);
            if (Math.Abs(monster.Location.Bearing) < tolerance) return true;
            do
            {
                if (Me.IsDead) { mover.Stop(); return false; }

                double b = monster.Location.Bearing;
                if (b < -tolerance)
                {
                    // to the left
                    mover.RotateLeft(true);
                }
                else if (b > tolerance)
                {
                    // to the rigth
                    mover.RotateRight(true);
                }
                else
                {
                    // ahead
                    mover.Stop();
                    return true;
                }

                UpdateMyPos();
            } while (!approachTimeout.IsReadySlow);

            mover.Stop();
            Context.Log("Face timed out");
            return false;

        }

        public bool Approach(GUnit monster, bool AbortIfUnsafe)
        {
            return Approach(monster, AbortIfUnsafe, 10000);
        }

        public bool Approach(GUnit monster, bool AbortIfUnsafe, int timeout)
        {
            return WalkTo(monster.Location, AbortIfUnsafe, timeout, false);
        }

        public bool WalkTo(GLocation loc, bool AbortIfUnsafe, int timeout, bool AllowDead)
        {
            if (loc.DistanceToSelf < Context.MeleeDistance &&
                Math.Abs(loc.Bearing) < PI / 8)
            {
                mover.Stop();
                return true;
            }

            GSpellTimer approachTimeout = new GSpellTimer(timeout, false);
            StuckDetecter sd = new StuckDetecter(this, 1, 2);
            GSpellTimer t = new GSpellTimer(0);
            bool doJump = random.Next(4) == 0;
            EasyMover em = null;
            do
            {
                UpdateMyPos();

                // Check for stuck
                if (sd.checkStuck())
                {
                    Context.Log("Major stuck on approach. Giving up");
                    mover.Stop();
                    return false;
                }


                double distance = loc.DistanceToSelf;
                bool moved;
                if (distance < 8)
                {
                    moved = mover.moveTowardsFacing(Me, loc, Context.MeleeDistance, loc);
                }
                else
                {
                    if (em == null)
                        em = new EasyMover(this, new Location(loc), false, AbortIfUnsafe);
                    EasyMover.MoveResult mr = em.move();

                    moved = true;
                    if (mr != EasyMover.MoveResult.Moving)
                    {
                        moved = false;
                    }
                }

                if (!moved)
                {
                    mover.Stop();
                    Context.Log("did not move");
                    return true;
                }

            } while (!approachTimeout.IsReadySlow && (!Me.IsDead || AllowDead));
            mover.Stop();
            Context.Log("Approach timed out");
            return false;
        }

        #endregion

    #region Ghost Run
        private void GhostRun()
        {
            Context.Log("I died. Let's resurrect");
            GLocation CorpseLocation = null;
            // 1. Release
            while (Me.IsDead && !Me.IsGhost)
            {
                if (CorpseLocation == null)
                    CorpseLocation = Me.Location;
                for (int n = 1; n <= 4; n++)
                {
                    if (Popup.IsVisible(n))
                    {
                        String text = PPather.Popup.GetText(n);
                        if (text.Contains("until release"))
                        {
                            Context.Log("Found the release dialog, #" + n);
                            Popup.ClickButton(n, 1);
                        }
                    }
                }
                Thread.Sleep(1000);
            }

            if (BGMode)
            {
                GSpellTimer s = new GSpellTimer(1000 * 60); // 1 minute
                Context.Log("BGMode, waiting for res");
                while (Me.IsDead)
                {
                    Thread.Sleep(500);
                }
                Context.Log("Alive!");
            }
            else
            {

                GLocation gloc = Me.CorpseLocation;
                if (CorpseLocation != null) gloc = CorpseLocation;

                Location target = null;
                GLocation gtarget;
                Context.Log("Corpse is at " + gloc);

                if (gloc.Z == 0)
                {
                    Context.Log("hmm, corpse Z == 0");
                    target = new Location(gloc);
                    for (int q = 0; q < 50; q += 5)
                    {
                        float stand_z = 0;
                        int flags = 0;
                        float x = gloc.X + random.Next(20) - 10;
                        float y = gloc.Y + random.Next(20) - 10;
                        bool ok = world.triangleWorld.FindStandableAt(x, y,
                                                                      -5000,
                                                                      5000,
                                                                      out stand_z, out flags, 0, 0);
                        if (ok)
                        {
                            target = new Location(x, y, stand_z);
                            break;
                        }
                    }
                }
                else
                {
                    target = new Location(gloc);

                }
                gtarget = new GLocation(target.X, target.Y, target.Z);

                Context.Log("Corpse is at " + target);
                Context.Log(" me is at " + new Location(Me.Location));
                EasyMover em = new EasyMover(this, target, false, false);

                // 2. Run to corpse
                while (Me.IsDead && Me.GetDistanceTo(gloc) > 20)
                {
                    EasyMover.MoveResult mr = em.move();
                    if (mr != EasyMover.MoveResult.Moving) return; // buhu
                    UpdateMyPos();
                    Thread.Sleep(50);

                }
                mover.Stop();

                // 3. Find a safe place to res
                // is within 20 yds of corpse now, dialog must be up
                float SafeDistance = 25.0f;
                while (true)
                {
                    // some brute force :p
                    GMonster[] monsters = GObjectList.GetMonsters();
                    GContext.Main.Log("Look for safe spot");
                    float best_score = 1E30f;
                    float best_distance = 1E30f;
                    Location best_loc = null;
                    for (float x = -35; x <= 35; x += 5)
                    {
                        for (float y = -35; y <= 35; y += 5)
                        {
                            float rx = target.X + x;
                            float ry = target.Y + y;
                            GLocation xxx = new GLocation(rx, ry, 0);
                            if (xxx.GetDistanceTo(gtarget) < 35)
                            {
                                float stand_z = 0;
                                int flags = 0;
                                bool ok = world.triangleWorld.FindStandableAt(rx, ry,
                                                                              target.Z - 20,
                                                                              target.Z + 20,
                                                                              out stand_z, out flags, 0, 0);
                                if (ok)
                                {
                                    float score = 0.0f;
                                    GLocation l = new GLocation(rx, ry, stand_z);
                                    foreach (GMonster monster in monsters)
                                    {
                                        if (monster != null && monster.Reaction == GReaction.Hostile && !monster.IsDead && !PPather.IsStupidItem(monster))
                                        {
                                            float d = l.GetDistanceTo(monster.Location);
                                            if (d < 35)
                                            {
                                                // one point per yard 
                                                score += 35 - d;
                                            }
                                        }
                                    }
                                    float this_d = Me.GetDistanceTo(l);
                                    if (score <= best_score && this_d < best_distance)
                                    {
                                        best_score = score;
                                        best_distance = this_d;
                                        best_loc = new Location(l);
                                    }
                                }
                            }
                        }
                    }
                    if (best_loc != null)
                    {
                        GLocation best_gloc = new GLocation(best_loc.X, best_loc.Y, best_loc.Z);
                        GContext.Main.Log("Looks safe at " + best_gloc + " score " + best_score + " i am at " + Me.Location);
                        // walk over there
                        WalkTo(best_gloc, false, 10000, true);

                        // Check if I am safe
                        bool safe = true;
                        GMonster unsafe_monster = null;
                        foreach (GMonster monster in monsters)
                        {
                            if (monster.Reaction == GReaction.Hostile && !monster.IsDead && !PPather.IsStupidItem(monster))
                            {
                                float d = Me.GetDistanceTo(monster);
                                if (d < SafeDistance)
                                    if (Math.Abs(monster.Location.Z - Me.Location.Z) < 15)
                                    {
                                        safe = false;
                                        unsafe_monster = monster;
                                    }

                            }
                        }
                        if (safe)
                        {
                            GContext.Main.Log("It was safe. resurrect");
                            break; // yeah
                        }
                        else
                        {
                            if (unsafe_monster != null)
                                GContext.Main.Log(unsafe_monster.Name + " is around there.");
                            else
                                GContext.Main.Log("unknown monster is around there.");
                        }
                    }

                    // hmm, look again
                    GContext.Main.Log("It was not safe, wait a little and lower standards. safe distance now is: " + SafeDistance);
                    Thread.Sleep(2000);
                    SafeDistance -= 0.5f;
                }

                // 4. Accept

                // dialog should be up now
                while (Me.IsDead)
                {
                    for (int n = 1; n <= 4; n++)
                    {
                        if (Popup.IsVisible(n))
                        {
                            String text = PPather.Popup.GetText(n);
                            if (text == "Resurrect now?")
                            {
                                Context.Log("Found the accept dialog, #" + n);
                                Popup.ClickButton(n, 1);
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }
        #endregion

    #region Blacklist Routines
        private Dictionary<string, GSpellTimer> blacklisted = new Dictionary<string, GSpellTimer>();
        public void Blacklist(string name, int howlong_seconds)
        {
            GSpellTimer t = null;
            if (blacklisted.TryGetValue(name, out t))
            {
                t.Reset();
            }
            else
            {
                t = new GSpellTimer(howlong_seconds * 1000);
                blacklisted.Add(name, t);
            }
            Context.Log("Blacklist " + name + " for " + howlong_seconds + "s");
        }
        public void Blacklist(long GUID, int howlong_seconds)
        {
            Blacklist("GUID" + GUID, howlong_seconds);
        }
        public void Blacklist(GUnit unit)
        {
            Blacklist(unit.GUID, 15 * 60); // 15 minutes
        }
        public void Blacklist(GUnit unit, int howlong_seconds)
        {
            Blacklist(unit.GUID, howlong_seconds);
        }
        public void Blacklist(String name)
        {
            Blacklist(name, 15 * 60); // 15 minutes
        }
        public void UnBlacklist(string name)
        {
            blacklisted.Remove(name);
            Context.Log("UnBlacklist " + name);
        }
        public void UnBlacklist(long GUID)
        {
            UnBlacklist("GUID" + GUID);
        }
        public void UnBlacklist(GUnit u)
        {
            UnBlacklist(u.GUID);
        }
        public bool IsBlacklisted(string name)
        {
            GSpellTimer t = null;
            if (!blacklisted.TryGetValue(name, out t))
                return false;

            return !t.IsReady;
        }
        public bool IsBlacklisted(long GUID)
        {
            return IsBlacklisted("GUID" + GUID);
        }
        public bool IsBlacklisted(GUnit unit)
        {
            return IsBlacklisted(unit.GUID);
        }
        #endregion

    #region Quest Routines
        public static string GetQuestStatus(string quest)
        {
            string val = ToonData.Get("Quest:" + quest);
            return val;
        }
        // Quest have 4 states:  
        //  accepted   - picked up
        //  failed     - failed for some reason
        //  goaldone   - goal done, need handin
        //  completed  - completed and handed in
        public void QuestAccepted(string name)
        {
            Context.Log("Quest accepted: '" + name + "'");
            ToonData.Set("Quest:" + name, "accepted");
        }
        public void QuestFailed(string name)
        {
            Context.Log("Quest failed: '" + name + "'");
            ToonData.Set("Quest:" + name, "failed");
        }
        public void QuestGoalDone(string name)
        {
            Context.Log("Quest goal done: '" + name + "'");
            ToonData.Set("Quest:" + name, "goaldone");
        }
        public void QuestCompleted(string name)
        {
            Context.Log("Quest completed: '" + name + "'");
            ToonData.Set("Quest:" + name, "completed");
        }
        // completed or failed
        public bool IsQuestDone(string name)
        {
            string val = ToonData.Get("Quest:" + name);
            if (val == null) return false;
            if (val == "failed" || val == "completed") return true;
            return false;
        }
        public bool IsQuestFailed(string name)
        {
            string val = ToonData.Get("Quest:" + name);
            if (val == null) return false;
            if (val == "failed") return true;
            return false;
        }
        public bool IsQuestAccepted(string name)
        {
            string val = ToonData.Get("Quest:" + name);
            if (val == null) return false;
            if (val == "accepted") return true;
            return false;
        }
        public bool IsQuestGoalDone(string name)
        {
            string val = ToonData.Get("Quest:" + name);
            if (val == null) return false;
            if (val == "goaldone") return true;
            return false;
        }
        #endregion

    #region Utilities
            public void Killed(GUnit unit)
            {
                //Context.Log("Killed unit " + unit.Name);
                Kills++;
            }
            public void TargetIs(GUnit unit)
            {
                form.SetTarget(unit);
            }
            public void Looted(GUnit unit)
            {
                Context.Log("Looted unit " + unit.Name);
                Loots++;
            }
            public void PickedUp(GNode node)
            {
                Context.Log("Picked up node " + node.Name);
                Harvests++;
            }
            private void UpdateXP()
            {
                XPCurrent = Me.Experience;
                if (XPCurrent < XPInitial)
                {
                    Context.Log("GZ! ding");
                    XPInitial = Me.Experience;
                    XPCurrent = XPInitial;
                    GliderStart = new GSpellTimer(0);
                }
                else
                {
                    double XPGained = (double)(XPCurrent - XPInitial);
                    double time = (double)(-GliderStart.TicksLeft) / 3600000.0; // hours
                    if (time != 0.0)
                    {
                        int XpNeeded = Me.NextLevelExperience - Me.Experience;
                        int XPPerHour = (int)(XPGained / time);
                        KPh = (int)((double)Kills / time);

                        int minsToLvl = XPPerHour == 0 ? 0 : (60 * XpNeeded) / XPPerHour;
                        //Context.Log("Kills: " + Kills + " Kills/h: " + KillsPerHour + " XP/h: " + XPPerHour + " TTL: " + minsToLvl + " min");
                        TTL = minsToLvl;
                        XPh = XPPerHour;
                    }
                }
            }
            public static bool IsStupidItem(GUnit unit)
            {
                if (unit.CreatureType == GCreatureType.Totem) return true;
                // Filter out all stupid sting found in outland
                string name = unit.Name.ToLower();
                if (name.Contains("target") || name.Contains("trigger") ||
                    name.Contains("flak cannon") || name.Contains("trip wire") ||
                    name.Contains("infernal rain") || name.Contains("anilia") ||
                    name.Contains("teleporter credit") || name.Contains("door fel cannon") ||
                    name.Contains("ethereum glaive") || name.Contains("orb flight"))
                    return true;
                return false;
            }
            public bool IsItSafeAt(GUnit ignore, GUnit u)
            {
                return IsItSafeAt(ignore, u.Location);
            }
            public bool IsItSafeAt(GUnit ignore, Location l)
            {
                return IsItSafeAt(ignore, new GLocation(l.X, l.Y, l.Z));
            }
            public bool IsItSafeAt(GUnit ignore, GLocation l)
            {
                return true;
                /*
                            GMonster[] adds = GObjectList.GetMonsters();
                            if (adds.Length == 0) return true;



                            foreach (GMonster Add in adds)
                            {
                                if ((ignore == null || Add != ignore) && !IsStupidItem(Add) && !IsBlacklisted(Add))
                                {
                                    GLocation loc = PredictedLocation(Add);
                                    double dangerd = 20 + Add.Level - Me.Level;
                                    if (!Add.IsDead &&
                                        Add.Reaction == GReaction.Hostile &&
                                        !Add.IsTagged &&
                                        Add.DistanceToSelf < dangerd) // TODO need to be a setting
                                    {
                                        //return true;
                                        return false;
                                    }
                                }
                            }
                            return true;
                */
            }
            public void ResetMyPos()
            {
                WasAt = null;
            }
            protected override void UpdateMyPos()
            {
                radar.Update();
                if (world != null)
                {
                    GLocation loc = GContext.Main.Me.Location;
                    Location isAt = new Location(loc.X, loc.Y, loc.Z);
                    //if(WasAt != null)  Context.Log("was " + WasAt.location);
                    //Context.Log("isAt " + isAt); 
                    if (WasAt != null)
                    {
                        if (WasAt.GetLocation().GetDistanceTo(isAt) > 20)
                            WasAt = null;
                    }
                    WasAt = world.TryAddSpot(WasAt, isAt);
                }
            }
        #endregion

    #region Zone Logic
        private string FigureOutZone()
        {
            // danbopes supplies these 2 lines to remove the macro
            GInterfaceObject ZoneTextString = GContext.Main.Interface.GetByName("ZoneTextFrame").GetChildObject("ZoneTextString");
            GInterfaceObject SubZoneTextString = GContext.Main.Interface.GetByName("SubZoneTextFrame").GetChildObject("SubZoneTextString");
            return SubZoneTextString.LabelText + ":" + ZoneTextString.LabelText;
        }
        #endregion

    #region Log Handlers
        void Pather_ChatLog(string RawText, string ParsedText)
        {

            if (ParsedText.StartsWith("HotSpot"))
            {
                GLocation loc = GContext.Main.Me.Location;
                //Location isAt2 = new Location(loc.X, loc.Y, loc.Z);
                //Context.Log("Add new hotspot");
                //hotSpots.Add(isAt2);
                Context.Log(String.Format(PPather.numberFormat, "[ {0,2:#0.0}, {1,2:#0.0}, {2,2:#0.0}]", loc.X, loc.Y, loc.Z));
            }
            else if (ParsedText.StartsWith("Dump"))
            {
                GNode[] nodes = GObjectList.GetNodes();
                foreach (GNode node in nodes)
                {
                    node.Refresh(true);
                    Context.Log("node: " + node.Name + " at " + node.Location.Z);
                }
                GUnit[] units = GObjectList.GetUnits();
                foreach (GUnit unit in units)
                {
                    Context.Log("unit: " + unit.Name);
                }


            }
            else if (ParsedText.Contains("The Horde wins!") ||
                    ParsedText.Contains("The Alliance wins!"))
            {
                Context.Log("BG ended. Stop glider");
                Context.KillAction("BG ended", false);
            }

        }
        void Pather_CombatLog(string rawText)
        {
            if (rawText == null) return;
            if (rawText.StartsWith("You have slain"))
            {
                int start = rawText.IndexOf("slain") + 6;
                int end = rawText.IndexOf("!");
                String mob = rawText.Substring(start, end - start);
                //Context.Log("Killed monster '" + mob + "'");
                if (CurrentPullTask != null)
                    CurrentPullTask.KilledMob(mob);
            }

        }
        #endregion

    #region GUI Windows
        public class MerchantFrame
        {
            public static GInterfaceObject GetFrame()
            {
                return GContext.Main.Interface.GetByName("MerchantFrame");
            }

            public static bool IsVisible()
            {
                GInterfaceObject obj = GetFrame();
                if (obj != null && obj.IsVisible) return true;
                return false;
            }
        }
        public class GossipFrame
        {
            /*
             V GossipFrame
V GossipNpcNameFrame
V GossipFrameCloseButton
V GossipFrameGreetingPanel
V GossipFrameGreetingGoodbyeButton
V GossipGreetingScrollFrame
V GossipGreetingScrollChildFrame
V GossipTitleButton1
  GossipTitleButton2
...
  GossipTitleButton32
V GossipSpacerFrame
V GossipGreetingScrollFrameScrollBar
V GossipGreetingScrollFrameScrollBarScrollUpButton
V GossipGreetingScrollFrameScrollBarScrollDownButton
*/
            public static GInterfaceObject GetFrame()
            {
                return GContext.Main.Interface.GetByName("GossipFrame");
            }

            public static bool IsVisible()
            {
                GInterfaceObject obj = GetFrame();
                if (obj != null && obj.IsVisible) return true;
                return false;
            }

            public static int[] VisibleOptions()
            {
                List<int> options = new List<int>();
                for (int i = 1; i <= 32; i++)
                {
                    GInterfaceObject btn = GContext.Main.Interface.GetByName("GossipTitleButton" + i);
                    if (btn != null && btn.IsVisible) options.Add(i);
                }
                return options.ToArray();
            }

            public static string[] VisibleOptionsText()
            {
                List<string> options = new List<string>();
                for (int i = 1; i <= 32; i++)
                {
                    GInterfaceObject btn = GContext.Main.Interface.GetByName("GossipTitleButton" + i);
                    if (btn != null && btn.IsVisible) 
                    {
                        options.Add(btn.LabelText);
                        GInterfaceObject text = btn.GetChildObject("GossipTitleButton" + i + "Text");
                        if(text == null)                         
                            options.Add("");
                        else
                            options.Add(text.LabelText);
                    }
                }
                return options.ToArray();
            }

            public static void ClickOption(int i)
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("GossipTitleButton" + i);
                if (btn != null && btn.IsVisible) 
                    btn.ClickMouse(false); // left click
            }

            public static void Close()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("GossipFrameCloseButton");
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);
            }
        }
        public class TrainerFrame
        {
            public static GInterfaceObject GetFrame()
            {
                return GContext.Main.Interface.GetByName("ClassTrainerFrame");
            }

            public static bool IsVisible()
            {
                GInterfaceObject obj = GetFrame();
                if (obj != null && obj.IsVisible) return true;
                return false;
            }

            public static int[] AvailableSkills()
            {
                List<int> options = new List<int>();
                for (int i = 1; i <= 11; i++)
                {
                    GInterfaceObject btn = GContext.Main.Interface.GetByName("ClassTrainerSkill" + i);
                    if (btn != null && btn.IsVisible) 
                    {
                        GInterfaceObject textObj = btn.GetChildObject("ClassTrainerSkill"+i+"Text");
                        string text = textObj.LabelText;
                        //GContext.Main.Log("Item " + i + " label '" + text + "'");
                        if(text.StartsWith("  "))
                            options.Add(i);
                    }
                }
                return options.ToArray();
            }

            public static void LearnAllSkills()
            {
                //GContext.Main.Log("------------ START TRAIN -------");
                int[] skills = AvailableSkills();
                int x = 0;
                while (x < skills.Length)                                    
                {
                    ClickSkill(skills[x]);
                    Thread.Sleep(100);
                    if(IsTrainEnabled())                        
                    {
                        //GContext.Main.Log("Train item " + x + " number " + skills[x]);
                        ClickTrain();
                        Thread.Sleep(500);
                        //GContext.Main.Log("------------ REFRESH TRAIN -------");
                        skills = AvailableSkills(); x = 0;
                    }
                    else
                        x++;
                    Thread.Sleep(200);
                    // Check if the frams lines are updated, if so stay on the same item
                    
                }
            }

            public static void ClickSkill(int i)
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("ClassTrainerSkill" + i);
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false); // left click
            }


            public static void ClickTrain()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("ClassTrainerTrainButton");
                btn.ClickMouse(false);
            }

            public static bool IsTrainEnabled()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("ClassTrainerTrainButton");
                return btn.IsEnabledInFrame;
            }

            public static string GetSkillName(int i)
            {
                return GContext.Main.Interface.GetByName("ClassTrainerSkill" + i + "Text").LabelText;
            }
        }
        public class QuestFrame
        {
            /*

Pickup quest (many optioss): 
V QuestLogMicroButton
V QuestFrame
V QuestNpcNameFrame
V QuestFrameCloseButton
V QuestFrameGreetingPanel
V QuestFrameGreetingGoodbyeButton
V QuestGreetingScrollFrame
V QuestGreetingScrollChildFrame
V QuestTitleButton1
V QuestTitleButton2
V QuestTitleButton3
V QuestGreetingScrollFrameScrollBar
V QuestGreetingScrollFrameScrollBarScrollUpButton
V QuestGreetingScrollFrameScrollBarScrollDownButton
V dQuestWatch



Hand in items: 

QuestFrame
QuestNpcNameFrame
QuestFrameCloseButton
QuestFrameProgressPanel
QuestFrameGoodbyeButton
QuestFrameCompleteButton
QuestProgressScrollFrame
QuestProgressScrollChildFrame
QuestProgressItem1
QuestProgressScrollFrameScrollBar
QuestProgressScrollFrameScrollBarScrollUpButton
QuestProgressScrollFrameScrollBarScrollDownButton
QuestWatchFrame

Complete Quest: (no reward selection)

QuestFrame
QuestNpcNameFrame
QuestFrameCloseButton
QuestFrameRewardPanel
QuestFrameCancelButton
QuestFrameCompleteQuestButton
QuestRewardScrollFrame
QuestRewardScrollChildFrame
QuestRewardItem1
QuestRewardMoneyFrame
QuestRewardMoneyFrameCopperButton
QuestRewardScrollFrameScrollBar
QuestRewardScrollFrameScrollBarScrollUpButton
QuestRewardScrollFrameScrollBarScrollDownButton
QuestWatchFrame

Complete Quest: (2 rewards selection)

V QuestFrame
V QuestNpcNameFrame
V QuestFrameCloseButton
V QuestFrameRewardPanel
V QuestFrameCancelButton
V QuestFrameCompleteQuestButton
V QuestRewardScrollFrame
V QuestRewardScrollChildFrame
V QuestRewardItem1
V QuestRewardItem2
V QuestRewardScrollFrameScrollBar
V QuestRewardScrollFrameScrollBarScrollUpButton
V QuestRewardScrollFrameScrollBarScrollDownButton
V QuestWatchFrame

             */

            public static GInterfaceObject GetFrame()
            {
                return GContext.Main.Interface.GetByName("QuestFrame");
            }

            public static string GetCompleteTitle()
            {
              GInterfaceObject QuestDetailScrollChildFrame = GContext.Main.Interface.GetByName("QuestRewardScrollChildFrame"); 
              GInterfaceObject QuestTitle =                  QuestDetailScrollChildFrame.GetChildObject("QuestRewardTitleText"); 
              GContext.Main.Log("Reward title: " + QuestTitle.LabelText + " v: " + QuestTitle.IsVisible);
              return QuestTitle.LabelText;
            }
          
            public static string GetAcceptTitle()
            {
                GInterfaceObject QuestDetailScrollChildFrame = GContext.Main.Interface.GetByName("QuestDetailScrollChildFrame"); 
                GInterfaceObject QuestTitle =                  QuestDetailScrollChildFrame.GetChildObject("QuestTitleText"); 
                GContext.Main.Log("Quest title: " + QuestTitle.LabelText + " v: " + QuestTitle.IsVisible);
                return QuestTitle.LabelText;
            }

            public static bool IsVisible()
            {
                GInterfaceObject obj = GetFrame();
                if (obj != null && obj.IsVisible) return true;
                return false;
            }

            public static bool IsSelect()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestTitleButton1");
                if (btn != null && btn.IsVisible) return true;
                return false;
            }

            public static bool IsAccept()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameAcceptButton");
                if (btn != null && btn.IsVisible) return true;
                return false;
            }

            public static bool IsContinue()
            {
                 GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCompleteButton");
                 if (btn != null && btn.IsVisible) return true;
                 return false;
            }

            public static bool IsComplete()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCompleteQuestButton");
                if (btn != null && btn.IsVisible) return true;
                return false;
            }

            public static int[] AvailableRewards()
            {
                List<int> options = new List<int>();
                for (int i = 1; i <= 10; i++)
                {
                    GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestRewardItem" + i);
                    if (btn != null && btn.IsVisible) options.Add(i);
                }
                return options.ToArray();
            }

            public static void SelectReward(int nr)
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestRewardItem" + nr);
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);
            }

            public static void Accept()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameAcceptButton");
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);
            }

            public static void Continue()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCompleteButton");
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);

            }

            public static void Complete()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCompleteQuestButton");
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);
            }

            public static void Close()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCloseButton");
                if (btn != null && btn.IsVisible)
                    btn.ClickMouse(false);
            }

            public static void Cancel()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameCancelButton");
                if (btn != null && btn.IsVisible)
                {
                    GContext.Main.Log("  click QuestFrameCancelButton");
                    btn.ClickMouse(false);
                }
                else
                    GContext.Main.Log("  can't find cancel button");
                    
            }

            public static void Goodbye()
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestFrameGoodbyeButton");
                if (btn != null && btn.IsVisible)
                {
                    GContext.Main.Log("  click QuestFrameGoodbyeButton");
                    btn.ClickMouse(false);
                }
                else
                    GContext.Main.Log("  can't find goodbye button");
                    
            }

            public static int[] VisibleOptions()
            {
                List<int> options = new List<int>();
                for (int i = 1; i <= 32; i++)
                {
                    GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestTitleButton" + i);
                    if (btn != null && btn.IsVisible) options.Add(i);
                }
                return options.ToArray();
            }

            public static void ClickOption(int i)
            {
                GInterfaceObject btn = GContext.Main.Interface.GetByName("QuestTitleButton" + i);
                if (btn != null && btn.IsVisible) 
                    btn.ClickMouse(false); // left click
            }

        }
		public class BattlefieldFrame
		{
			public static GInterfaceObject GetFrame()
			{
				return GContext.Main.Interface.GetByName("BattlefieldFrame");
			}

			public static bool IsVisible()
			{
				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible) return true;
				return false;
			}

			public static bool IsJoin()
			{
				GInterfaceObject btn = GContext.Main.Interface.GetByName("BattlefieldFrameJoinButton");
				if (btn != null && btn.IsVisible) return true;
				return false;
			}

			public static void Join()
			{
				GInterfaceObject btn = GContext.Main.Interface.GetByName("BattlefieldFrameJoinButton");
				if (btn != null && btn.IsVisible)
					btn.ClickMouse(false);
			}

			public static void Close()
			{
				GInterfaceObject btn = GContext.Main.Interface.GetByName("BattlefieldFrameCloseButton");
				if (btn != null && btn.IsVisible)
					btn.ClickMouse(false);
			}
		}
		public class MiniMapBattlefieldFrame
		{
			public static GInterfaceObject GetFrame()
			{
				return GContext.Main.Interface.GetByName("MiniMapBattlefieldFrame");
			}

			public static bool IsVisible()
			{
				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible) return true;
				return false;
			}

			public static void RightClick()
			{
				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible)
				{
					obj.ClickMouse(true);
				}
			}
		}
		public class MiniMapBattlefieldDropDownFrame
		{
			public static GInterfaceObject GetFrame()
			{
				return GContext.Main.Interface.GetByName("MiniMapBattlefieldDropDown");
			}

			public static bool IsVisible()
			{
				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible) return true;
				return false;
			}
		}
		public class TaxiFrame
		{
			public static GInterfaceObject GetFrame()
			{
				return GContext.Main.Interface.GetByName("TaxiFrame");
			}

			public static GInterfaceObject GetButton(int buttonId)
			{
				return GContext.Main.Interface.GetByName("TaxiButton" + buttonId);
			}

			public static bool IsVisible()
			{
				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible) return true;
				return false;
			}

			public static bool HasTaxiButton(int buttonId)
			{

				GInterfaceObject obj = GetFrame();
				if (obj != null && obj.IsVisible)
				{
					GInterfaceObject subObj = GetButton(buttonId);
					if (subObj != null && subObj.IsVisible) return true;
				}

				return false;
			}

			public static void ClickTaxiButton(int buttonId)
			{
				GInterfaceObject obj = GetButton(buttonId);
				if (obj != null && obj.IsVisible)
				{
					obj.Hover();
					Thread.Sleep(1000);
					
					// and off we go!
					obj.ClickMouse(false);
				}
			}

			public static int GetButtonId(String destination)
			{
				// lets hope there's never more than 64 flight paths :)
				for (int i = 1; i < 65; i++)
				{
					if (HasTaxiButton(i) && CheckTaxiButton(i, destination))
					{
						return i;
					}
				}

				return 0;
			}

			public static bool CheckTaxiButton(int buttonId, String destination)
			{
				GInterfaceObject btnObj = GetButton(buttonId);
				if (btnObj != null && btnObj.IsVisible)
				{
					btnObj.Hover();
					Thread.Sleep(1000);

					String ttText = CheckToolTip();  // jea, why not?

					if (ttText != null && destination != null &&
						destination.Length > 0 && ttText.Length > 0 &&
						ttText.ToLower().Contains(destination.ToLower()))
					{
						return true;
					}
				}

				return false;
			}

			public static String CheckToolTip()
			{
				GInterfaceObject btn = GContext.Main.Interface.GetByName("GameTooltip");
				if (btn != null && btn.IsVisible)
				{
					GInterfaceObject text = btn.GetChildObject("GameTooltipTextLeft1");

					if (text != null)
					{
						return text.LabelText;
					}
				}
				
				return null;
			}
		}
		public class MacrolessZoneInfo
		{
			public static String GetZoneText()
			{
				GInterfaceObject formZone = GContext.Main.Interface.GetByName("ZoneTextFrame");
				if (formZone != null)
				{
					GInterfaceObject textZone = formZone.GetChildObject("ZoneTextString");

					if (textZone != null)
					{
						return textZone.LabelText;
					}
				}

				return null;
			}

			public static String GetSubZoneText()
			{
				GInterfaceObject formSubZone = GContext.Main.Interface.GetByName("SubZoneTextFrame");
				if (formSubZone != null)
				{
					GInterfaceObject textSubZone = formSubZone.GetChildObject("SubZoneTextString");

					if (textSubZone != null)
					{
						return textSubZone.LabelText;
					}
				}

				return null;
			}
		}
        #endregion

    #region ToonState
        public class ToonState
        {
            // Simple saved storage or key=>value pairs

            Dictionary<string, string> dic = new Dictionary<string, string>();
            string toonName = null;
            bool changed = false;

            public void Save()
            {
                lock (this)
                {
                    if (!changed) return;
                    if (toonName == null) return;
                    string filename = "pathing2\\" + toonName;
                    try
                    {
                        System.IO.TextWriter s = System.IO.File.CreateText(filename);
                        foreach (string key in dic.Keys)
                        {
                            string val = dic[key];
                            s.WriteLine(key + "|" + val);
                        }
                        s.Close();
                    }
                    catch (Exception e)
                    {
                        GContext.Main.Log("Exception writing toon state data: " + e);
                    }
                    changed = false;
                }

            }

            public void Load()
            {
                lock (this)
                {
                    if (toonName == null) return;
                    dic = new Dictionary<string, string>();

                    // Load from file
                    try
                    {
                        GContext.Main.Log("Load toon data for " + toonName);
                        string filename = "pathing2\\" + toonName;
                        System.IO.TextReader s = System.IO.File.OpenText(filename);

                        int nr = 0;
                        string line;
                        while ((line = s.ReadLine()) != null)
                        {
                            char[] splitter = { '|' };
                            string[] st = line.Split(splitter);
                            if (st.Length == 2)
                            {
                                string key = st[0];
                                string val = st[1];
                                Set(key, val);
                                nr++;
                            }
                        }
                        GContext.Main.Log("Loaded " + nr + " toon state data");

                        s.Close();
                    }
                    catch (Exception)
                    {
                        //GContext.Main.Log("Exception reading toon state: " + e);
                        GContext.Main.Log("*** Failed reading toon state data");
                    }
                    changed = false;

                }

            }

            public void SetToonName(string name)
            {
                Save();
                toonName = name;
                Load();
            }

            public string Get(string key)
            {
                string val;
                if (dic.TryGetValue(key, out val))
                {
                    return val;
                }
                return null;
            }

            public void Set(string key, string name)
            {
                if (dic.ContainsKey(key))
                    dic.Remove(key);
                dic.Add(key, name);
                changed = true;
            }
        }
        #endregion

    #region NPC Management
        public class NPCDatabase
        {
            public class NPC
            {
                public String name;
                public GLocation location;
                public int faction;
                public GReaction reaction;

                public override string ToString()
                {
                    return String.Format(PPather.numberFormat, "{0}|{1},{2},{3}|{4}|{5}",
                                         name, location.X, location.Y, location.Z, faction, reaction);
                }

                public bool FromString(string s)
                {
                    char[] splitter = { '|' };
                    string[] sp = s.Split(splitter);
                    if (sp.Length < 4) return false;
                    name = sp[0];
                    string locs = sp[1];
                    char[] splitter2 = { ',' };
                    string[] coords = locs.Split(splitter2);
                    if (coords.Length == 3)
                    {

                        float x = float.Parse(coords[0], PPather.numberFormat);
                        float y = float.Parse(coords[1], PPather.numberFormat);
                        float z = float.Parse(coords[2], PPather.numberFormat);
                        location = new GLocation(x, y, z);
                    }
                    else return false;
                    faction = Int32.Parse(sp[2], PPather.numberFormat);
                    string rs = sp[3];
                    if (rs == "Friendly")
                        reaction = GReaction.Friendly;
                    if (rs == "Hostile")
                        reaction = GReaction.Hostile;
                    if (rs == "Neutral")
                        reaction = GReaction.Neutral;
                    if (rs == "Unknown")
                        reaction = GReaction.Unknown;

                    return true;
                }
            }

            Dictionary<string, NPC> NPCs;
            string continent = null;
            string myFaction = "";
            bool changed = false;

            public void SetContinent(string continent, string myFaction)
            {

                lock (this)
                {
                    // Continent change
                    Save();

                    this.continent = continent;
                    this.myFaction = myFaction;

                    Load();
                }


            }


            public void Update()
            {

                lock (this)
                {
                    if (continent == null) return;
                    if (NPCs == null) return;
                    GUnit[] units = GObjectList.GetUnits();
                    foreach (GUnit unit in units)
                    {
                        if ((unit.Reaction == GReaction.Friendly || unit.Reaction == GReaction.Neutral)
                            && !unit.IsPlayer &&
                              unit.CreatureType != GCreatureType.Critter &&
                              unit.CreatureType != GCreatureType.Totem &&
                              !PPather.IsPlayerFaction(unit))
                        {
                            string name = unit.Name;
                            NPC n = null;
                            if (!NPCs.TryGetValue(name, out n))
                            {
                                n = new NPC();
                                n.name = name;
                                n.faction = unit.FactionID;
                                n.location = unit.Location;
                                n.reaction = unit.Reaction;
                                GContext.Main.Log("New NPC found: " + name);
                                NPCs.Add(name, n);
                                changed = true;
                            }
                        }
                    }
                }
            }

            public void Save()
            {
                if (!changed) return;
                lock (this)
                {
                    if (continent == null) return;
                    string filename = "pathing2\\" + continent + "\\NPC_" + myFaction;
                    try
                    {
                        System.IO.TextWriter s = System.IO.File.CreateText(filename);
                        foreach (string name in NPCs.Keys)
                        {
                            NPC n = NPCs[name];
                            s.WriteLine(n.ToString());
                        }
                        s.Close();
                    }
                    catch (Exception e)
                    {
                        GContext.Main.Log("Exception writing NPC data: " + e);
                    }
                    changed = false;

                }
            }

            public void Load()
            {
                lock (this)
                {
                    if (continent == null) return;
                    NPCs = new Dictionary<string, NPC>();
                    // Load from file
                    try
                    {
                        string filename = "pathing2\\" + continent + "\\NPC_" + myFaction;
                        System.IO.TextReader s = System.IO.File.OpenText(filename);

                        int nr = 0;
                        string line;
                        while ((line = s.ReadLine()) != null)
                        {
                            NPC n = new NPC();
                            if (n.FromString(line))
                            {
                                if (!NPCs.ContainsKey(n.name))
                                {
                                    NPCs.Add(n.name, n);
                                    nr++;
                                }
                            }

                        }
                        GContext.Main.Log("Loaded " + nr + " NPCs");

                        s.Close();
                    }
                    catch (Exception)
                    {
                        //GContext.Main.Log("Exception reading NPC data: " + e);
                        GContext.Main.Log("*** Failed to load NPC data");
                    }
                    changed = false;
                }
            }

            public NPC Find(string name)
            {
                NPC n;
                if (NPCs.TryGetValue(name, out n))
                {
                    return n;
                }
                return null;
            }
        }
        public void UpdateNPCs()
        {
            if (NPCs == null) return;

            NPCs.Update();
        }
        public Location FindNPCLocation(string name)
        {
            if (NPCs == null) return null;
            NPCDatabase.NPC npc = NPCs.Find(name);
            //Context.Log("found '" + name + "' or? " + npc);
            if (npc == null) return null;
            return new Location(npc.location);
        }
        public GLocation PredictedLocation(GUnit mob)
        {
            GLocation currentLocation = mob.Location;
            double x = currentLocation.X;
            double y = currentLocation.Y;
            double z = currentLocation.Z;
            double heading = mob.Heading;
            double dist = 4;

            x += Math.Cos(heading) * dist;
            y += Math.Sin(heading) * dist;

            GLocation predictedLocation = new GLocation((float)x, (float)y, (float)z);

            GLocation closestLocatition = currentLocation;
            if (predictedLocation.DistanceToSelf < closestLocatition.DistanceToSelf)
                closestLocatition = predictedLocation;
            return closestLocatition;
        }
        #endregion

    #region Unit Radar
        public class UnitRadar : ILocationHeuristics
        {
            class UnitData
            {
                public long guid;
                public GUnit unit;
                public GLocation oldLocation;
                public double movementSpeed;

                public UnitData(GUnit u)
                {
                    unit = u;
                    guid = u.GUID;
                    movementSpeed = 0.0;
                    oldLocation = u.Location;
                }
                public void Update(int dt)  // dt is milliseconds
                {
                    if (dt == 0) return;
                    double ds = (double)dt / 1000.0;
                    double d = oldLocation.GetDistanceTo(unit.Location);
                    movementSpeed = d / ds;
                    oldLocation = unit.Location;
                }
            }

            Dictionary<long, UnitData> dic = new Dictionary<long, UnitData>();
            GSpellTimer updateTimer = new GSpellTimer(0);

            public UnitRadar()
            {
            }


            public float Score(float x, float y, float z)
            {
                GLocation l = new GLocation(x, y, z);
                GLocation me = GContext.Main.Me.Location;
                if (l.GetDistanceTo(me) > 100.0) return 0;
                float s = 0;
                foreach (UnitData ud in dic.Values)
                {
                    GUnit unit = ud.unit;
                    if (unit.Reaction == GReaction.Hostile)
                    {

                        float d = unit.Location.GetDistanceTo(l);
                        if (d < 30)
                        {
                            float n = 30 - d;
                            int ld = unit.Level - GContext.Main.Me.Level;
                            //if(ld < 0)
                            //    n /= -ld+2;
                            s += n;
                        }
                    }
                }
                //if(s>0)
                //    GContext.Main.Log("  " + l + " score " + s);
                return s;
            }

            public void Update()
            {
                int dt = -updateTimer.TicksLeft;
                if (dt >= 1000)
                {
                    GUnit[] units = GObjectList.GetUnits();
                    Update(units);
                }
            }

            public void Update(GUnit[] units)
            {
                int dt = -updateTimer.TicksLeft;
                foreach (GUnit u in units)
                {
                    if (!u.IsDead && !PPather.IsStupidItem(u))
                    {
                        UnitData ud;
                        if (dic.TryGetValue(u.GUID, out ud))
                        {
                            ud.Update(dt);
                        }
                        else
                        {
                            // new one
                            ud = new UnitData(u);
                            dic.Add(u.GUID, ud);
                        }
                    }
                }

                List<long> rem = new List<long>();
                foreach (UnitData ud in dic.Values)
                {
                    if (!ud.unit.IsValid) rem.Add(ud.guid);
                }
                foreach (long guid in rem)
                {
                    dic.Remove(guid);
                }
                updateTimer.Reset();
            }

            public double GetSpeed(GUnit u)
            {
                UnitData ud;
                if (dic.TryGetValue(u.GUID, out ud))
                {
                    return ud.movementSpeed;
                }
                return 0.0;
            }
        }
        #endregion

    #region EasyMover
        public class EasyMover
        {
            Location target;
            GPlayerSelf Me;
            GContext Context;
            PathGraph world = null;

            Mover mover;
            PPather pather;
            bool GiveUpIfStuck = false;
            bool GiveUpIfUnsafe = false;

            GSpellTimer PathTimeout = new GSpellTimer(5000); // no path can be older than this
            MoveAlonger MoveAlong;

            public enum MoveResult { Reached, Stuck, CantFindPath, Unsafe, Moving, GotThere };

            public EasyMover(PPather pather, Location target, bool GiveUpIfStuck, bool GiveUpIfUnsafe)
            {
                this.target = target;
                this.Me = GContext.Main.Me;
                this.Context = GContext.Main;
                this.world = pather.world;
                mover = PPather.mover;
                this.GiveUpIfStuck = GiveUpIfStuck;
                this.GiveUpIfUnsafe = GiveUpIfUnsafe;
                this.pather = pather;
            }
            public void SetPathTimeout(int ms)
            {
                PathTimeout = new GSpellTimer(ms); // no path can be older than this                
            }

            public void SetNewTarget(Location target)
            {
                MoveAlong = null;
                this.target = target;
            }

            public MoveResult move()
            {
                if (GiveUpIfUnsafe)
                {
                    if (!pather.IsItSafeAt(Me.Target, Me.Location))
                        return MoveResult.Unsafe;
                }
                if (PathTimeout.IsReady)
                {
                    MoveAlong = null;
                }
                if (MoveAlong == null)
                {
                    Location from = new Location(Me.Location);
                    mover.Stop();
                    Path path = world.CreatePath(from, target, (float)Context.MeleeDistance, PPather.radar);
                    PathTimeout.Reset();
                    if (path == null || path.Count() == 0)
                    {
                        Context.Log("EasyMover: Can not create path . giving up");
                        mover.MoveRandom();
                        Thread.Sleep(200);
                        mover.Stop();
                        return MoveResult.CantFindPath;
                    }
                    else
                    {
                        //Context.Log("Save path to " + pathfile); 
                        //path.Save(pathfile);
                        MoveAlong = new MoveAlonger(pather, path);
                    }
                }

                if (MoveAlong != null)
                {
                    Location from = new Location(Me.Location);

                    if (MoveAlong.path.Count() == 0 || from.GetDistanceTo(target) < (float)Context.MeleeDistance)
                    {
                        //Context.Log("Move along used up");
                        MoveAlong = null;
                        mover.Stop();
                        return MoveResult.GotThere;
                    }
                    else if (!MoveAlong.MoveAlong())
                    {
                        MoveAlong = null; // got stuck!
                        if (GiveUpIfStuck) return MoveResult.Stuck;
                    }
                }
                return MoveResult.Moving;
            }
        }
        #endregion

    #region MoveAlonger
        public class MoveAlonger
        {
            public Path path;
            StuckDetecter sd;
            GPlayerSelf Me;
            GContext Context;
            Location prev;
            Location current;
            Location next;
            Mover mover;
            PathGraph world = null;
            int blockCount = 0;

            public MoveAlonger(PPather pather, Path path)
            {

                this.Context = GContext.Main;
                this.Me = Context.Me;
                this.path = path;
                this.world = pather.world;
                mover = PPather.mover;
                sd = new StuckDetecter(pather, 1, 2);
                prev = null;
                current = path.GetFirst();
                next = path.GetSecond();
            }

            public bool MoveAlong()
            {
                double max = 3.0;
                GLocation loc = GContext.Main.Me.Location;
                Location isAt = new Location(loc.X, loc.Y, loc.Z);
                /*
                while (isAt.GetDistanceTo(current) < max && next != null)
                {
                    //Context.Log(current + " - " + next);
                    path.RemoveFirst();
                    if (path.Count() == 0)
                    {
                        //Context.Log("ya");
                        //return true; // good in some way
                    }
                    else
                    {
                        prev = current;
                        current = path.GetFirst();
                        next = path.GetSecond();
                    }
                }
    */
                bool consume = false;
                do
                {

                    bool blocked = false;

                    consume = false;
                    if (next != null)
                        world.triangleWorld.IsStepBlocked(loc.X, loc.Y, loc.Z, next.X, next.Y, next.Z,
                                                          PathGraph.toonHeight, PathGraph.toonSize, null);
                    double d = isAt.GetDistanceTo(current);
                    if ((d < max && !blocked) ||
                       d < 1.5)
                        consume = true;

                    if (consume)
                    {
                        //GContext.Main.Log("Consume spot " + current + " d " + d + " block " + blocked);
                        path.RemoveFirst();
                        if (path.Count() == 0)
                        {
                            break;
                        }
                        else
                        {
                            prev = current;
                            current = path.GetFirst();
                            next = path.GetSecond();
                        }
                    }

                } while (consume);

                {
                    //Context.Log("Move towards " + current);
                    GLocation gto = new GLocation((float)current.X, (float)current.Y, (float)current.Z);
                    GLocation face;
                    if (next != null)
                        face = new GLocation(next.X, next.Y, next.Z);
                    else
                        face = gto;

                    if (!mover.moveTowardsFacing(Me, gto, 0.5, face))
                    {
                        Context.Log("Can't move " + current);
                        world.BlacklistStep(prev, current);
                        //world.MarkStuckAt(loc, Me.Heading);                        
                        mover.MoveRandom();
                        Thread.Sleep(500);
                        mover.Stop();
                        return false;
                        // hmm, mover does not want to move, must be up or down
                    }

                    {
                        double h; double speed;
                        h = mover.GetMoveHeading(out speed);
                        float stand_z = 0.0f;
                        int flags = 0;
                        float x = isAt.X + (float)Math.Cos(h) * 1.0f;
                        float y = isAt.Y + (float)Math.Sin(h) * 1.0f;
                        float z = isAt.Z;
                        bool aheadOk = world.triangleWorld.FindStandableAt(x, y,
                                                                           z - 4,
                                                                           z + 6,
                                                                           out stand_z, out flags, 0, 0);
                        if (!aheadOk)
                        {
                            blockCount++;
                            GContext.Main.Log("Heading into a wall or off a cliff " + blockCount);
                            world.MarkStuckAt(isAt, (float)Me.Heading);

                            if (prev != null)
                            {
                                GLocation gprev = new GLocation((float)prev.X, (float)prev.Y, (float)prev.Z);

                                if (!mover.moveTowardsFacing(Me, gprev, 0.5, face))
                                {
                                    mover.Stop();
                                    return false;
                                }
                            }
                            if (blockCount > 1)
                            {
                                world.BlacklistStep(prev, current);
                                return false;
                            }

                            return true;
                        }
                        else
                            blockCount = 0;
                    }


                    if (sd.checkStuck())
                    {
                        Context.Log("Stuck at " + isAt);
                        world.MarkStuckAt(isAt, (float)Me.Heading);
                        world.BlacklistStep(prev, current);
                        mover.Stop();
                        return false;
                    }
                }
                return true;
            }
        }
        #endregion

    #region Stuck Detector
        public class StuckDetecter
        {
            GLocation oldLocation = null;
            float predictedDX;
            float predictedDY;

            GSpellTimer StuckTimeout = new GSpellTimer(333); // Check every 333ms
            GPlayerSelf Me;
            GContext Context;
            Mover mover;
            int stuckSensitivity;
            int abortSensitivity;
            int stuckMove = 0;
            GSpellTimer lastStuckCheck = new GSpellTimer(0);
            bool firstStuckCheck = true;
            //GLocation StuckLocation = null;

            public StuckDetecter(PPather pather, int stuckSensitivity, int abortSensitivity)
            {
                this.Me = GContext.Main.Me;
                this.Context = GContext.Main;
                this.stuckSensitivity = stuckSensitivity;
                this.abortSensitivity = abortSensitivity;
                this.mover = PPather.mover;
                firstStuckCheck = true;
            }

            public bool checkStuck()
            {
                if (firstStuckCheck)
                {
                    oldLocation = GContext.Main.Me.Location;
                    predictedDX = 0;
                    predictedDY = 0;
                    firstStuckCheck = false;
                    lastStuckCheck.Reset();
                }
                else
                {
                    // update predicted location
                    double h; double speed;
                    h = mover.GetMoveHeading(out speed);

                    float dt = (float)-lastStuckCheck.TicksLeft / 1000f;
                    float dx = (float)Math.Cos(h) * (float)speed * dt;
                    float dy = (float)Math.Sin(h) * (float)speed * dt;
                    //GContext.Main.Log("speed: " + speed + " dt: " + dt + " dx: " + dx + " dy : " + dy);
                    predictedDX += dx;
                    predictedDY += dy;

                    lastStuckCheck.Reset();
                    if (StuckTimeout.IsReady)
                    {
                        // Check stuck
                        GLocation loc = Me.Location;
                        float realDX = loc.X - oldLocation.X;
                        float realDY = loc.Y - oldLocation.Y;
                        //GContext.Main.Log(" dx: " + predictedDX + " dy : " + predictedDY + " Real dx: " + realDX + " dy : " + realDY );

                        float predictDist = (float)Math.Sqrt(predictedDX * predictedDX + predictedDY * predictedDY);
                        float realDist = (float)Math.Sqrt(realDX * realDX + realDY * realDY);

                        //GContext.Main.Log(" pd " + predictDist + " rd " + realDist);


                        if (predictDist > realDist * 2)
                        {
                            // moving a lot slower than predicted
                            // check direction
                            GLocation excpected = new GLocation(loc.X + predictedDX, loc.Y + predictedDY);

                            Context.Log("I am stuck " + stuckMove); //. Jumping to get free");
                            if (stuckMove == 0)
                            {
                                mover.Forwards(false);
                                mover.Forwards(true);
                                mover.StrafeLeft(true);
                                //mover.Jump();
                                //mover.StrafeRight(false);
                            }
                            else if (stuckMove == 1)
                            {
                                mover.Forwards(false);
                                mover.Forwards(true);
                                mover.StrafeLeft(true);
                                //Context.Log("  strafe left"); 
                                //mover.Jump();
                                //mover.StrafeLeft(false);
                            }
                            else if (stuckMove == 2)
                            {
                                mover.Forwards(false);
                                mover.Forwards(true);
                                mover.StrafeRight(true);
                                //Context.Log("  strafe left"); 
                                //mover.StrafeLeft(true);
                            }
                            else if (stuckMove == 2)
                            {
                                mover.Forwards(false);
                                mover.Forwards(true);
                                mover.StrafeRight(true);
                                //Context.Log("  strafe left"); 
                                //mover.StrafeLeft(true);

                            }
                            stuckMove++;
                            if (stuckMove >= abortSensitivity)
                            {
                                return true;
                            }

                        }
                        else
                        {
                            stuckMove = 0;

                        }
                        predictedDX = 0;
                        predictedDY = 0;
                        oldLocation = loc;
                        StuckTimeout.Reset();
                    }


                }
                return false;
            }

        }
        #endregion

    #region Task Management
        public Task CreateTaskFromNode(NodeTask node, Task parent)
        {
            Task n = null;
            // Built in Tasks
            if (node.type == "When")
            {
                n = new WhenTask(this, node);
            }
            else if (node.type == "If")
            {
                n = new IfTask(this, node);
            }
            else if (node.type == "Until")
            {
                n = new UntilTask(this, node);
            }
            else if (node.type == "Oneshot")
            {
                n = new OneshotTask(this, node);
            }
            else if (node.type == "Parallel" || node.type == "Par")
            {
                n = new ParTask(this, node);
            }
            else if (node.type == "Sequence" || node.type == "Seq")
            {
                n = new SeqTask(this, node);
            }
            else if (node.type == "Rest")
            {
                n = new RestTask(this, node);
            }
            else if (node.type == "Defend")
            {
                n = new DefendTask(this, node);
            }
            else if (node.type == "Danger")
            {
                n = new DangerTask(this, node);
            }
            else if (node.type == "Pull")
            {
                n = new PullTask(this, node);
            }
            else if (node.type == "Loot")
            {
                n = new LootTask(this, node);
            }
            else if (node.type == "Harvest")
            {
                n = new HarvestTask(this, node);
            }
            else if (node.type == "Hotspots")
            {
                n = new HotspotTask(this, node);
            }
            else if (node.type == "Walk")
            {
                n = new WalkTask(this, node);
            }
            else if (node.type == "QuestPickup")
            {
                n = new QuestPickupTask(this, node);
            }
            else if (node.type == "QuestHandin")
            {
                n = new QuestHandinTask(this, node);
            }
            else if (node.type == "QuestGoal")
            {
                n = new QuestGoalTask(this, node);
            }
            else if (node.type == "Vendor")
            {
                n = new VendorTask(this, node);
            }
            else if (node.type == "BGQueue")
            {
                n = new BGQueueTask(this, node);

            }
            else if (node.type == "Taxi")
            {
                n = new TaxiTask(this, node);
            }
            else if (node.type == "Train")
            {
                n = new TrainTask(this, node);
            }
            else if (node.type == "Mail")
            {
                n = new MailTask(this, node);

            }
            else
            {
                Context.Log("Unknown task type " + node.type);
            }


            if (n != null)
                n.parent = parent;
            else
                Context.KillAction("PPather, script corrupt", false);
            return n;
        }
        // TASK CONTAINERS
        public abstract class Task
        {
            public enum State_e { Idle, Want, Active, Done };
            public bool isActive;

            public Task parent;

            public virtual bool IsParserTask() { return false; }
            public virtual State_e State
            {
                get
                {
                    if (isActive) return State_e.Active;
                    if (IsFinished()) return State_e.Done;
                    return State_e.Idle;
                }
            }


            public PPather ppather;
            public Task(PPather pather)
            {
                ppather = pather;
            }

            public abstract Location GetLocation();

            public virtual void Restart()
            {

            }

            public virtual Task[] GetChildren()
            {
                return null;
            }

            public abstract bool WantToDoSomething();
            public abstract bool IsFinished();

            public abstract Activity GetActivity();
            public abstract bool ActivityDone(Activity task); // called when activity is done

            public virtual void GetParams(List<string> l) { }

        }
        public abstract class ParserTask : Task
        {
            public NodeTask nodetask;
            public ParserTask(PPather pather, NodeTask nodetask)
                : base(pather)
            {
                this.nodetask = nodetask;
            }
            public override bool IsParserTask() { return true; }
        }
        public class OneshotTask : ParserTask
        {
            Task childTask;
            public OneshotTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                childTask = pather.CreateTaskFromNode(node.subTasks[0], this);
            }


            public override Task[] GetChildren()
            {
                return new Task[] { childTask };
            }

            public override Location GetLocation()
            {
                return childTask.GetLocation();
            }

            public override void Restart()
            {
                childTask.Restart();
            }

            public override bool IsFinished()
            {
                return childTask.IsFinished();
            }

            public override bool WantToDoSomething()
            {
                return childTask.WantToDoSomething();
            }

            public override Activity GetActivity()
            {
                return childTask.GetActivity();
            }

            public override bool ActivityDone(Activity task)
            {
                bool childDone = childTask.ActivityDone(task);
                return childDone;
            }
            public override void GetParams(List<string> l) { }
        }
        public class WhenTask : ParserTask
        {
            Task childTask;
            public WhenTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                childTask = pather.CreateTaskFromNode(node.subTasks[0], this);
            }

            public override void GetParams(List<string> l)
            {
                l.Add("cond");
                base.GetParams(l);
            }

            public override bool IsFinished()
            {
                return childTask.IsFinished();
            }

            public override Location GetLocation()
            {
                return childTask.GetLocation();
            }

            public override Task[] GetChildren()
            {
                return new Task[] { childTask };
            }


            public override void Restart()
            {
                childTask.Restart(); // restart my baby
            }

            public override bool WantToDoSomething()
            {
                bool want;

                want = nodetask.GetBoolValueOfId("cond");
                if (want)
                {
                    want = childTask.WantToDoSomething();
                }

                return want;
            }

            public override Activity GetActivity()
            {
                return childTask.GetActivity();
            }

            public override bool ActivityDone(Activity task)
            {
                bool childDone = childTask.ActivityDone(task);
                if (childDone)
                {
                    // TODO hmm, my child is done... cool
                }
                return childDone;
            }


        }
        public class IfTask : ParserTask
        {
            Task childTask;
            public IfTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                childTask = pather.CreateTaskFromNode(node.subTasks[0], this);
            }

            public override void GetParams(List<string> l)
            {
                l.Add("cond");
                base.GetParams(l);
            }

            public override bool IsFinished()
            {
                bool want = nodetask.GetBoolValueOfId("cond");
                if (!want) return true;
                return childTask.IsFinished();
            }

            public override Location GetLocation()
            {
                return childTask.GetLocation();
            }

            public override Task[] GetChildren()
            {
                return new Task[] { childTask };
            }


            public override void Restart()
            {
                childTask.Restart(); // restart my baby
            }

            public override bool WantToDoSomething()
            {
                bool want;

                want = nodetask.GetBoolValueOfId("cond");
                if (want)
                {
                    want = childTask.WantToDoSomething();
                }

                return want;
            }

            public override Activity GetActivity()
            {
                return childTask.GetActivity();
            }

            public override bool ActivityDone(Activity task)
            {
                bool childDone = childTask.ActivityDone(task);
                if (childDone)
                {
                    //  hmm, my child is done... cool
                }
                return childDone;
            }


        }
        public class UntilTask : ParserTask
        {
            Task childTask;
            public UntilTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                if (node.subTasks.Count == 1)
                    childTask = pather.CreateTaskFromNode(node.subTasks[0], this);
            }


            public override void GetParams(List<string> l)
            {
                l.Add("cond");
                base.GetParams(l);
            }

            public override Location GetLocation()
            {
                if (childTask == null) return null;
                return childTask.GetLocation();
            }

            public override Task[] GetChildren()
            {
                if (childTask == null) return null;
                return new Task[] { childTask };
            }


            public override bool IsFinished()
            {
                bool done = nodetask.GetBoolValueOfId("cond");
                if (!done)
                {
                    if (childTask != null && childTask.IsFinished())
                        childTask.Restart(); // Try to restart it
                }
                return done || (childTask != null && childTask.IsFinished());
            }

            public override void Restart()
            {
                childTask.Restart(); // restart my baby
            }

            public override bool WantToDoSomething()
            {

                bool done = nodetask.GetBoolValueOfId("cond");
                //GContext.Main.Log("Until  cond = " + done);
                if (done)
                    return false;

                if (childTask == null) return false;

                bool child = childTask.WantToDoSomething();
                //GContext.Main.Log("Until child is " + child);

                return child;
            }

            public override Activity GetActivity()
            {
                if (childTask == null) return null;

                return childTask.GetActivity();
            }

            public override bool ActivityDone(Activity task)
            {

                // cool
                return false;
            }
        }
        public class ParTask : ParserTask
        {
            SortedList<int, List<Task>> orderedChildTasks = new SortedList<int, List<Task>>();
            bool done = false;


            public ParTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                foreach (NodeTask nt in node.subTasks)
                {
                    Task t = pather.CreateTaskFromNode(nt, this);
                    if (t != null)
                    {
                        int prio = nt.GetPrio();
                        List<Task> l;
                        if (orderedChildTasks.TryGetValue(prio, out l))
                        {
                            l.Add(t);
                        }
                        else
                        {
                            l = new List<Task>();
                            l.Add(t);
                            orderedChildTasks.Add(prio, l);
                        }
                        //GContext.Main.Log("Par add prio " + prio + " task " + t);

                    }
                }
            }


            public override bool IsFinished()
            {
                if (done) return true;
                foreach (List<Task> l in orderedChildTasks.Values)
                {
                    foreach (Task t in l)
                    {
                        if (!t.IsFinished()) return false;
                    }
                }
                done = true;
                return true;
            }

            public override void GetParams(List<string> l)
            {
                base.GetParams(l);
            }


            public override Task[] GetChildren()
            {
                List<Task> ts = new List<Task>();
                foreach (int prio in orderedChildTasks.Keys)
                {
                    List<Task> l;
                    orderedChildTasks.TryGetValue(prio, out l);
                    foreach (Task t in l)
                    {
                        ts.Add(t);
                    }
                }
                return ts.ToArray();
            }


            public override void Restart()
            {
                foreach (List<Task> l in orderedChildTasks.Values)
                {
                    foreach (Task t in l)
                    {
                        t.Restart();
                    }
                }
                done = false;

            }

            private Task GetBestTask()
            {
                Location meLoc = new Location(GContext.Main.Me.Location);
                Task bestFound = null;
                float bestFoundDistance = 1E30f;
                foreach (int prio in orderedChildTasks.Keys)
                {
                    List<Task> l;
                    orderedChildTasks.TryGetValue(prio, out l);
                    foreach (Task t in l)
                    {
                        //GContext.Main.Log("Consider " + t);
                        // GContext.Main.Log("  f: "  + t.IsFinished() + " wtd " + t.WantToDoSomething());
                        if (!t.IsFinished() && t.WantToDoSomething())
                        {
                            float d = 0;
                            Location loc = t.GetLocation();
                            if (loc != null)
                                d = loc.GetDistanceTo(meLoc);
                            if (d < bestFoundDistance)
                            {
                                bestFound = t;
                                bestFoundDistance = d;
                            }
                        }
                    }
                    if (bestFound != null)
                    {
                        return bestFound; // Found one
                    }
                }
                return bestFound;
            }

            public override Location GetLocation()
            {
                return GetBestTask().GetLocation();
            }

            public override bool WantToDoSomething()
            {
                Task bestFound = GetBestTask();
                return bestFound != null;
            }

            public override Activity GetActivity()
            {
                Task bestFound = GetBestTask();
                //GContext.Main.Log("par beast task: " + bestFound);
                if (bestFound == null) return null; // huh?
                Activity a = bestFound.GetActivity();
                //GContext.Main.Log("par beast a: " + a);
                return a;
            }

            public override bool ActivityDone(Activity task)
            {
                Task bestFound = GetBestTask();
                if (bestFound == null) return false; // huh?
                bestFound.ActivityDone(task);
                return false; // I am never done
            }
        }
        public class SeqTask : ParserTask
        {
            List<Task> sequence;
            int currentSequence = 0;
            public SeqTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                sequence = new List<Task>();
                foreach (NodeTask nt in node.subTasks)
                {
                    Task t = pather.CreateTaskFromNode(nt, this);
                    if (t != null)
                    {
                        sequence.Add(t);
                    }
                }
                currentSequence = 0;
            }

            public override void GetParams(List<string> l)
            {
                base.GetParams(l);
            }

            public override Task[] GetChildren()
            {
                return sequence.ToArray();
            }

            private void PickChild()
            {
                if (currentSequence < sequence.Count)
                {
                    do
                    {
                        Task child = sequence[currentSequence];
                        if (child.IsFinished())
                        {
                            //GContext.Main.Log("Seq " + currentSequence + " is done. " + " " + child);
                            currentSequence++;
                        }
                        else
                            return;
                    } while (currentSequence < sequence.Count);
                }
            }
            public override void Restart()
            {
                currentSequence = 0;
                foreach (Task t in sequence)
                {
                    t.Restart();
                }
            }
            public override bool IsFinished()
            {
                PickChild();
                if (currentSequence >= sequence.Count)
                {
                    return true;
                }
                return false;
            }
            public override bool WantToDoSomething()
            {
                PickChild();
                if (currentSequence >= sequence.Count) return false; // all done
                return sequence[currentSequence].WantToDoSomething();
            }

            public override Location GetLocation()
            {
                PickChild();
                return sequence[currentSequence].GetLocation();
            }

            public override Activity GetActivity()
            {
                PickChild();
                if (currentSequence >= sequence.Count)
                {
                    GContext.Main.Log("all seqeuences done. no activity");
                    return null; // doh!
                }
                Activity a = sequence[currentSequence].GetActivity();
                //GContext.Main.Log("seq a " + currentSequence + " : " + a);
                return a;
            }

            public override bool ActivityDone(Activity task)
            {
                bool childDone = sequence[currentSequence].ActivityDone(task);

                PickChild();

                return currentSequence >= sequence.Count;
            }
        }
        public class RestTask : ParserTask
        {
            double RestHealth;
            double RestMana;


            public RestTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                RestHealth = GContext.Main.RestHealth;
                RestMana = GContext.Main.RestMana;

                GContext.Main.Log("Rest  health: " + RestHealth + " mana: " + RestMana);
            }
            public override string ToString()
            {
                return "Rest";
            }

            public override Location GetLocation()
            {
                return null; // anywhere
            }

            public override void GetParams(List<string> l)
            {
                base.GetParams(l);
            }

            public override bool IsFinished()
            {
                return false;
            }


            public override bool WantToDoSomething()
            {

                if (ppather.FindAttacker() != null) return false; // can't rest while attacked
                if (GContext.Main.Me.IsInCombat) return false;
                bool wantRest = false;
                double hp = GContext.Main.Me.Health;
                if (hp < RestHealth)
                {
                    wantRest = true;
                }
                if (ppather.CanDrink)
                {
                    double mana = GContext.Main.Me.Mana;
                    if (mana < RestMana)
                    {
                        wantRest = true;
                    }
                }
                // TODO: check for safety
                return wantRest;
            }

            public override Activity GetActivity()
            {
                Activity restTask = new ActivityRest(this);

                return restTask;
            }

            public override bool ActivityDone(Activity task)
            {
                task.Stop();

                return false; // never done
            }

        }
        public class DefendTask : ParserTask
        {
            GUnit monster = null;


            public DefendTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
            }

            public override Location GetLocation()
            {
                return null; // anywhere
            }

            public override void GetParams(List<string> l)
            {
                base.GetParams(l);
            }

            public override string ToString()
            {
                return "Defend";
            }

            public override bool IsFinished()
            {
                return false;
            }
            public override bool WantToDoSomething()
            {
                monster = ppather.FindAttacker();
                return monster != null;
            }

            public override Activity GetActivity()
            {
                Activity attackTask = new ActivityAttack(this, monster);

                return attackTask;
            }

            public override bool ActivityDone(Activity task)
            {
                task.Stop();

                return false; // never done
            }
        }
        public class DangerTask : ParserTask
        {
            GUnit monster = null;
            float DangerDistance;

            public DangerTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                DangerDistance = node.GetValueOfId("DangerDistance").GetFloatValue();
                if (DangerDistance == 0) DangerDistance = 20;
            }

            public override Location GetLocation()
            {
                return null; // anywhere
            }
            public override void GetParams(List<string> l)
            {
                l.Add("DangerDistance");
                base.GetParams(l);
            }

            public override string ToString()
            {
                return "Danger";
            }

            public override bool IsFinished()
            {
                return false;
            }

            GUnit FindMobToPull()
            {
                // Find stuff to pull
                GUnit closest = null;
                GMonster[] monsters = GObjectList.GetMonsters();
                foreach (GMonster monster in monsters)
                {
                    if (!monster.IsDead &&
              (!monster.IsTagged || monster.IsTargetingMe || monster.IsTargetingMyPet) &&
                        !ppather.IsBlacklisted(monster) &&
                        !PPather.IsStupidItem(monster))
                    {
                        double dangerd = (double)DangerDistance + monster.Level - GContext.Main.Me.Level;
                        if (monster.Reaction == GReaction.Hostile &&
                            monster.DistanceToSelf < dangerd &&
                            Math.Abs(monster.Location.Z - GContext.Main.Me.Location.Z) < 15.0 &&
                            !PPather.IsPlayerFaction(monster))
                        {
                            if (closest == null || monster.DistanceToSelf < closest.DistanceToSelf)
                            {
                                closest = monster;
                            }
                        }
                    }
                }
                return closest;
            }

            public override bool WantToDoSomething()
            {
                GUnit prevMonster = monster;
                monster = FindMobToPull();
                if (monster != prevMonster)
                {
                    attackTask = null;

                }
                return monster != null;
            }

            private Activity attackTask = null;
            public override Activity GetActivity()
            {
                if (attackTask == null)
                    attackTask = new ActivityAttack(this, monster);

                return attackTask;
            }

            public override bool ActivityDone(Activity task)
            {
                task.Stop();

                return false;
            }
        }
        public class PullTask : ParserTask
        {
            GUnit monster = null;
            int MinLevel = 0;
            int MaxLevel = 1000;
            float Distance = 1E30f;
            List<String> names;
            List<int> factions;
            Dictionary<string, int> killedMobs = new Dictionary<string, int>();


            public override void GetParams(List<string> l)
            {
                l.Add("Names");
                l.Add("Factions");
                l.Add("MinLevel");
                l.Add("MaxLevel");
                l.Add("Distance");
                base.GetParams(l);
            }

            public PullTask(PPather pather, NodeTask node)
                : base(pather, node)
            {


                Value v_names = node.GetValueOfId("Names");
                if (v_names != null)
                {
                    names = v_names.GetStringCollectionValues();
                    if (names.Count == 0) names = null;


                }

                Value v_factions = node.GetValueOfId("Factions");
                if (v_factions != null)
                {
                    factions = v_factions.GetIntCollectionValues();
                    if (factions.Count == 0) factions = null;
                    if (factions != null) foreach (int faction in factions)
                        {
                            GContext.Main.Log("  faction '" + faction + "'");
                        }
                }

                MinLevel = node.GetValueOfId("MinLevel").GetIntValue();
                MaxLevel = node.GetValueOfId("MaxLevel").GetIntValue();

                Distance = node.GetValueOfId("Distance").GetFloatValue();
                if (Distance == 0.0f) Distance = 1E30f;

                if (MaxLevel == 0) MaxLevel = 10000;
                //GContext.Main.Log("  Max level " + MaxLevel);
                //GContext.Main.Log("  Min level " + MinLevel);
                SetKillCount();

            }

            private void SetKillCount()
            {
                Value v = new Value(killedMobs);
                nodetask.SetValueOfId("KillCount", v);
            }

            public void KilledMob(String name)
            {
                // called my combat log parser
                if (IsValidTargetName(name))
                {
                    // one of mine


                    int count = 0;
                    killedMobs.TryGetValue(name, out count);
                    count++;
                    killedMobs.Remove(name);
                    killedMobs.Add(name, count);

                    GContext.Main.Log("Killed " + count + " " + name);
                    SetKillCount();
                }

            }

            public override void Restart()
            {
                // ActualKillCount = 0;
            }

            public override string ToString()
            {
                String s = "Pull ";
                if (monster != null)
                    s += monster.Name;
                return s;
            }

            public override Location GetLocation()
            {
                if (monster != null)
                    return new Location(monster.Location);
                return null;
            }

            private bool IsValidTargetName(String name)
            {
                if (names == null) return true;
                foreach (string tst_name in names)
                {
                    if (tst_name == name) return true;
                }
                return false;
            }

            private bool IsValidTarget(GUnit monster)
            {
                bool ok = true;
                if (monster.Level < MinLevel || monster.Level > MaxLevel) return false;
                if (factions != null)
                {
                    ok = false;
                    // Faction must match
                    foreach (int faction in factions)
                    {
                        if (monster.FactionID == faction) ok = true;
                    }
                }

                if (ok == false) return false;

                ok = IsValidTargetName(monster.Name);
                if (ok == false) return false;


                return ok;
            }

            GUnit FindMobToPull()
            {
                // Find stuff to pull
                GUnit closest = null;
                GMonster[] monsters = GObjectList.GetMonsters();
                float me_z = GContext.Main.Me.Location.Z;
                foreach (GMonster monster in monsters)
                {
                    if (!monster.IsDead &&
                        (!monster.IsTagged || monster.IsTargetingMe || monster.IsTargetingMyPet) &&
                        monster.DistanceToSelf < Distance &&
                        !ppather.IsBlacklisted(monster) && IsValidTarget(monster) &&
                        !PPather.IsStupidItem(monster))
                    {
                        Location ml = new Location(monster.Location);
                        float dz = (float)Math.Abs(ml.Z - me_z);
                        if (dz < 30.0f)
                        {
                            if (ppather.world.IsUnderwaterOrInAir(ml))
                            {
                                GContext.Main.Log(monster.Name + " is underwater or flying");
                                ppather.Blacklist(monster);
                            }
                            else
                            {
                                if (closest == null || monster.DistanceToSelf < closest.DistanceToSelf)
                                {
                                    closest = monster;
                                }
                            }
                        }
                    }
                }
                return closest;
            }

            public override bool IsFinished()
            {
                return false;
            }

            public override bool WantToDoSomething()
            {
                MinLevel = nodetask.GetValueOfId("MinLevel").GetIntValue();
                MaxLevel = nodetask.GetValueOfId("MaxLevel").GetIntValue();

                GUnit prevMonster = monster;
                monster = FindMobToPull();
                if (monster != prevMonster)
                {
                    if (prevMonster != null && prevMonster.IsValid && !prevMonster.IsDead)
                    {
                        GContext.Main.Log("new monster to attack. ban old one:  " + prevMonster.Name + "");
                        ppather.Blacklist(prevMonster.GUID, 45); // ban for 45 seconds
                    }
                    attackTask = null;
                    walkTask = null;
                }
                if (monster == null)
                {
                    attackTask = null;
                    walkTask = null;
                }
                return monster != null;
            }

            private Activity attackTask = null;
            private ActivityApproach walkTask = null;
            public override Activity GetActivity()
            {

                if (walkTask != null)
                {
                    // check result of walking
                    if (walkTask.MoveResult != EasyMover.MoveResult.Moving &&
                        walkTask.MoveResult != EasyMover.MoveResult.GotThere)
                    {
                        GContext.Main.Log("Can't reach " + monster.Name + ". blacklist. " + walkTask.MoveResult);
                        ppather.Blacklist(monster);
                        return null;
                    }

                }
                // check distance
                if (monster.DistanceToSelf < ppather.PullDistance)
                {


                    PPather.mover.Stop();
                    if (attackTask == null)
                        attackTask = new ActivityAttack(this, monster);
                    walkTask = null;
                    ppather.CurrentPullTask = this;
                    return attackTask;
                }
                else
                {
                    // walk over there
                    if (walkTask == null)
                        walkTask = new ActivityApproach(this, monster, 2.0f);
                    attackTask = null;
                    return walkTask;
                }
            }

            public override bool ActivityDone(Activity task)
            {

                if (task == attackTask)
                {
                    monster = null;
                    attackTask = null;
                    walkTask = null;

                }

                task.Stop();

                return false;
            }
        }
        public class LootTask : ParserTask
        {
            GUnit monster = null;
            bool Skin = false;

            public LootTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Value or = node.GetValueOfId("Skin");
                Skin = or.GetBoolValue();
            }

            public override void GetParams(List<string> l)
            {
                l.Add("Skin");
                base.GetParams(l);
            }

            public override string ToString()
            {
                String s = "Loot ";
                if (monster != null)
                    s += monster.Name;
                return s;
            }

            public override bool IsFinished()
            {
                return false;
            }

            public override Location GetLocation()
            {
                if (monster != null)
                    return new Location(monster.Location);
                return null;
            }

            private bool ShouldLoot(GUnit u)
            {
                bool looted = ppather.IsBlacklisted(u.GUID);  // hmm, blacklisted mob
                // Check for safety
                return !looted;
            }

            private void DidLoot(GUnit u)
            {
                ppather.Blacklist(u.GUID, 5 * 60);
            }

            GUnit FindMobToLoot()
            {
                // Find stuff to loot
                GUnit closest = null;
                GMonster[] monsters = GObjectList.GetMonsters();
                foreach (GMonster monster in monsters)
                {
                    if ((monster.IsLootable || (monster.IsSkinnable && Skin)) &&
                         ShouldLoot(monster))
                    {
                        if (closest == null || monster.DistanceToSelf < closest.DistanceToSelf)
                        {
                            closest = monster;
                        }
                    }
                }
                return closest;
            }

            public override bool WantToDoSomething()
            {
                if (GObjectList.GetNearestAttacker(0) != null) return false;

                GUnit prevMonster = monster;
                monster = FindMobToLoot();
                if (monster != prevMonster)
                {
                    lootTask = null;
                    walkTask = null;
                }

                if (walkTask != null)
                {
                    // check result of walking
                    if (walkTask.MoveResult != EasyMover.MoveResult.Moving &&
                        walkTask.MoveResult != EasyMover.MoveResult.GotThere)
                    {
                        GContext.Main.Log("Can't reach " + monster.Name + ". blacklist. " + walkTask.MoveResult);
                        ppather.Blacklist(monster);
                        return false;
                    }
                }


                // at my pos and at target pos
                if (monster != null && !ppather.IsItSafeAt(null, monster))
                {
                    GContext.Main.Log("It is not safe at: " + monster.Name);
                    DidLoot(monster); // ignore that              
                    monster = null;
                }
                if (monster != null && !ppather.IsItSafeAt(null, GContext.Main.Me))
                {
                    monster = null;
                }

                return monster != null;
            }

            private Activity lootTask = null;
            private ActivityApproach walkTask = null;
            public override Activity GetActivity()
            {

                // check distance
                if (monster.DistanceToSelf < 5.0)
                {
                    if (walkTask != null)
                        walkTask.Stop();
                    if (lootTask == null)
                        lootTask = new ActivityLoot(this, monster, Skin);
                    walkTask = null;
                    return lootTask;
                }
                else
                {
                    // walk over there
                    if (walkTask == null)
                        walkTask = new ActivityApproach(this, monster, 2f);
                    lootTask = null;
                    return walkTask;
                }
            }

            public override bool ActivityDone(Activity task)
            {
                if (task == lootTask)
                {
                    DidLoot(monster);
                    monster = null;
                }

                task.Stop();
                return false; // never done
            }

        }
        public class VendorTask : NPCInteractTask
        {
            public VendorTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                if (NPC == null || NPC == "")
                {
                    NPC = node.GetValueOfId("RepairNPC").GetStringValue();
                    if (NPC == null || NPC == "")
                    {
                        NPC = node.GetValueOfId("SellNPC").GetStringValue();
                    }
                }
            }


            public override void GetParams(List<string> l)
            {
                l.Add("MinDurability");
                l.Add("MinFreeBagSlots");
                l.Add("SellGrey"); l.Add("SellGray");
                l.Add("SellWhite"); l.Add("SellGreen");
                l.Add("Protected");
                l.Add("BlacklistTime");
                base.GetParams(l);
            }


            private float GetMinDurabillity()
            {
                Value v = nodetask.GetValueOfId("MinDurability");
                if (v == null) return -1.0f;
                return v.GetFloatValue();
            }

            private float GetDurabillity()
            {
                return nodetask.GetFloatValueOfId("MyDurability");
            }

            private int GetMinFreeBagslots()
            {
                Value v = nodetask.GetValueOfId("MinFreeBagSlots");
                if (v == null) return -1;
                return v.GetIntValue();
            }

            private int GetBlacklistTime()
            {
                Value v = nodetask.GetValueOfId("BlacklistTime");
                if (v == null) return 300;
                int t = v.GetIntValue();
                if (t == 0) t = 300;
                return t;
            }

            private float GetFreeBagslots()
            {
                return nodetask.GetIntValueOfId("FreeBagSlots");
            }

            private List<string> GetProtectedItems()
            {
                Value v = nodetask.GetValueOfId("Protected");
                if (v == null) return null;
                List<string> prot = v.GetStringCollectionValues();
                for (int i = 0; i < prot.Count; i++)
                    prot[i] = prot[i].ToLower();
                return prot;
            }

            private bool GetSellGrey()
            {
                return nodetask.GetBoolValueOfId("SellGrey") || nodetask.GetBoolValueOfId("SellGray");
            }

            private bool GetSellWhite()
            {
                return nodetask.GetBoolValueOfId("SellWhite");
            }

            private bool GetSellGreen()
            {
                return nodetask.GetBoolValueOfId("SellGreen");
            }

            public override bool IsFinished()
            {
                return false;
            }

            private bool wantSell = false;
            private bool wantRepair = false;

            private void UpdateWants()
            {
                wantRepair = false;
                wantSell = false;

                Location l = GetLocationOfNPC();

                if (l == null)
                {
                }
                else
                {
                    bool close = l.GetDistanceTo(new Location(GContext.Main.Me.Location)) < 50.0;
                    if ((GetDurabillity() <= GetMinDurabillity()) || close)
                    {
                        wantRepair = true;
                    }
                    if (GetFreeBagslots() <= GetMinFreeBagslots() || close)
                    {
                        wantSell = true;
                    }
                }
            }

            public override bool WantToDoSomething()
            {
                if (ppather.IsBlacklisted(NPC)) return false;
                UpdateWants();
                if (wantSell || wantRepair) return true;
                return false;
            }

            ActivitySellAndRepair sellActivity;
            public override Activity GetActivity()
            {

                // GContext.Main.Log("Pickup::GetActivity()");
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (sellActivity == null)
                    {
                        sellActivity =
                            new ActivitySellAndRepair(this, FindNPC(),
                                                      GetSellGrey(), GetSellWhite(),
                                                      GetSellGreen(), GetProtectedItems());
                    }
                    return sellActivity;
                }

            }

            public override bool ActivityDone(Activity task)
            {
                if (task == sellActivity)
                {
                    ppather.Blacklist(NPC, GetBlacklistTime());
                    return true;
                }
                return false;
            }
        }
        public class BGQueueTask : NPCInteractTask
        {
            public BGQueueTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                NPC = GetBGNPC();
                if (GetLocationOfNPC() == null)
                    GContext.Main.Log("*** NPC " + NPC + " is unknown");
            }

            private int GetCooldown()
            {
                return 60 * 3; // 3 minutes
            }

            public override void GetParams(List<string> l)
            {
                l.Add("BGNPC");
                base.GetParams(l);
            }

            private string GetBGNPC()
            {
                Value v = nodetask.GetValueOfId("BGNPC");
                if (v == null) return null;
                return v.GetStringValue();
            }

            public override bool IsFinished()
            {
                return false;
            }

            private bool wantQueue = false;

            private void UpdateWants()
            {
                // Check queue
                wantQueue = false;

                NPC = GetBGNPC();
                if (NPC != null && !ppather.IsBlacklisted(NPC))
                {
                    Location l = GetLocationOfNPC();
                    //GContext.Main.Log("BG NPC loc: " + l);
                    //GContext.Main.Log("My dur: " + GetDurabillity());
                    //GContext.Main.Log("min dur: " + GetMinDurabillity());

                    if (l == null)
                    {
                    }
                    else if (!PPather.MiniMapBattlefieldFrame.IsVisible() /* ||
                                                                             l.GetDistanceTo(new Location(GContext.Main.Me.Location)) < 50.0 */
                                                                                                                                               )
                    {
                        //GContext.Main.Log("Want to Queue: " + (wantQueue ? "yes" : "no"));
                        wantQueue = true;
                    }
                }

            }

            public override Location GetLocation()
            {
                Location loc = null;
                UpdateWants();
                if (wantQueue) { NPC = GetBGNPC(); loc = GetLocationOfNPC(); }
                return loc;
            }

            public override bool WantToDoSomething()
            {
                UpdateWants();
                if (wantQueue) return true;
                return false;
            }

            ActivityQueue queueActivity;

            public override Activity GetActivity()
            {

                // GContext.Main.Log("Pickup::GetActivity()");
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (queueActivity == null)
                    {
                        queueActivity = new ActivityQueue(this, FindNPC());
                    }
                    return queueActivity;
                }

            }

            public override bool ActivityDone(Activity task)
            {
                if (task == queueActivity)
                {
                    ppather.Blacklist(GetBGNPC(), 15 * 60);
                    return true;
                }
                return false;
            }

        }
        public class TaxiTask : NPCInteractTask
        {
            bool flied = false;
            public TaxiTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                if (GetLocationOfNPC() == null)
                    GContext.Main.Log("*** NPC " + NPC + " is unknown");
            }

            private int GetCooldown()
            {
                return 60 * 3; // 3 minutes
            }

            public override void GetParams(List<string> l)
            {
                l.Add("Destination");
                base.GetParams(l);
            }


            private String GetTaxiDestination()
            {
                Value v = nodetask.GetValueOfId("Destination");
                if (v == null) return null;
                return v.GetStringValue();
            }

            public override bool IsFinished()
            {
                // Fly just once
                return flied;
            }

            public override void Restart()
            {
                flied = false;
                // ActualKillCount = 0;
            }

            private bool wantTaxi = false;

            private void UpdateWants()
            {
                // Check queue
                wantTaxi = false;

                if (NPC != null && !ppather.IsBlacklisted(NPC))
                {
                    Location l = GetLocationOfNPC();
                    //GContext.Main.Log("BG NPC loc: " + l);
                    //GContext.Main.Log("My dur: " + GetDurabillity());
                    //GContext.Main.Log("min dur: " + GetMinDurabillity());

                    if (l == null)
                    {
                    }
                    else if (true) /* Might be a better way to figure out if we should or not.. I use lowest $prio */
                    //l.GetDistanceTo(new Location(GContext.Main.Me.Location)) < 50.0)
                    {
                        //GContext.Main.Log("Want to Queue: " + (wantQueue ? "yes" : "no"));
                        wantTaxi = true;
                    }
                }

            }

            public override Location GetLocation()
            {
                Location loc = null;
                UpdateWants();
                if (wantTaxi) { loc = GetLocationOfNPC(); }
                return loc;
            }

            public override bool WantToDoSomething()
            {
                UpdateWants();
                if (wantTaxi) return true;
                return false;
            }

            ActivityTaxi taxiActivity;

            public override Activity GetActivity()
            {

                // GContext.Main.Log("Pickup::GetActivity()");
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (taxiActivity == null)
                    {
                        taxiActivity = new ActivityTaxi(this, FindNPC(), GetTaxiDestination());
                    }
                    return taxiActivity;
                }

            }

            public override bool ActivityDone(Activity task)
            {
                if (task == taxiActivity)
                {
                    ppather.Blacklist(NPC, 15 * 60);
                    flied = true;
                    return true;
                }
                return false;
            }

        }
        public class MailTask : ParserTask
        {
            public MailTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
            }

            public override Location GetLocation()
            {
                return null;
            }


            public override bool IsFinished()
            {
                return false;
            }

            public override bool WantToDoSomething()
            {
                return false;
            }


            public override Activity GetActivity()
            {
                return null;
            }
            public override bool ActivityDone(Activity task)
            {
                return true;
            }
        }
        public class HarvestTask : ParserTask
        {
            GNode node = null;

            List<String> names;
            bool HarvestFlower = false;
            bool HarvestMineral = false;
            bool HarvestTreasure = false;

            int times = 0;
            int harvest_times = 0;

            public override void GetParams(List<string> l)
            {
                l.Add("Names");
                l.Add("Types");
                l.Add("Times");

                base.GetParams(l);
            }

            public HarvestTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Value v_names = node.GetValueOfId("Names");

                if (v_names != null)
                {
                    names = v_names.GetStringCollectionValues();
                }


                Value v_types = node.GetValueOfId("Types");

                List<Value> types_list = v_types.GetCollectionValue();
                foreach (Value v in types_list)
                {
                    string s = v.GetStringValue();
                    if (s == "Herb" || s == "Flower")
                    {
                        HarvestFlower = true;
                        GContext.Main.Log("Want to harvest flowers");

                    }
                    if (s == "Mine" || s == "Mineral")
                    {
                        HarvestMineral = true;
                        GContext.Main.Log("Want to harvest minerals");
                    }
                    if (s == "Chest" || s == "Treasure")
                    {
                        HarvestTreasure = true;
                        GContext.Main.Log("Want to harvest chests");
                    }
                }
                times = node.GetValueOfId("Times").GetIntValue();
            }


            public override string ToString()
            {
                String s = "Harvest ";
                if (node != null)
                    s += node.Name;
                return s;
            }

            public override bool IsFinished()
            {
                if (times <= 0) return false;
                return harvest_times >= times;
            }
            public override Location GetLocation()
            {
                if (node != null)
                    return new Location(node.Location);
                return null;
            }

            private bool ShouldHarvest(GNode u)
            {
                if (u.IsMineral && HarvestMineral ||
                    u.IsFlower && HarvestFlower ||
                    u.IsTreasure && HarvestTreasure ||
                    names != null && names.Contains(u.Name))
                {
                    return !ppather.IsBlacklisted(u.GUID);
                }
                return false;
            }

            private void DidHarvest(GNode u)
            {
                ppather.Blacklist(u.GUID, 5 * 60); // 5 minutes
                harvest_times++;
            }

            GNode FindItemToHarvest()
            {
                // Find stuff to loot
                GNode closest = null;
                GNode[] nodes = GObjectList.GetNodes();
                foreach (GNode node in nodes)
                {
                    if (ShouldHarvest(node))
                    {
                        if (closest == null || node.DistanceToSelf < closest.DistanceToSelf)
                        {
                            closest = node;
                        }
                    }
                }
                return closest;
            }

            public override bool WantToDoSomething()
            {
                GNode prevNode = node;
                node = FindItemToHarvest();
                if (prevNode != null && node == null)
                {
                    // hmmm, lost a node
                    GContext.Main.Log("Lost " + prevNode.Name + ". blacklist");

                    ppather.Blacklist(prevNode.GUID, 60); // ban for 1 mins
                }

                if (node != prevNode || prevNode == null || node == null)
                {
                    // new target
                    lootTask = null;
                    walkTask = null;
                }
                if (walkTask != null)
                {
                    // check result of walking
                    if (walkTask.MoveResult != EasyMover.MoveResult.Moving &&
                        walkTask.MoveResult != EasyMover.MoveResult.GotThere)
                    {
                        GContext.Main.Log("Can't reach " + node.Name + ". blacklist. " + walkTask.MoveResult);
                        ppather.Blacklist(node.GUID, 60 * 10);
                        return false;
                    }
                }

                // at my pos and at target pos
                if (node != null && !ppather.IsItSafeAt(null, node.Location))
                {
                    GContext.Main.Log("Unsafe at " + node.Name + ".");
                    ppather.Blacklist(node.GUID, 60 * 10); // 10 mins
                    node = null;
                }
                if (node != null && !ppather.IsItSafeAt(null, GContext.Main.Me))
                {
                    node = null;
                }
                return node != null;
            }

            private Activity lootTask = null;
            private ActivityWalkTo walkTask = null;
            public override Activity GetActivity()
            {
                // check distance
                if (node.DistanceToSelf < 5.0)
                {
                    if (walkTask != null)
                        walkTask.Stop();
                    if (lootTask == null)
                        lootTask = new ActivityPickup(this, node);
                    walkTask = null;
                    return lootTask;
                }
                else
                {
                    // walk over there
                    if (walkTask == null)
                    {
                        walkTask = new ActivityWalkTo(this, new Location(node.Location), 2f);
                        GContext.Main.Log("new walk task to node " + node.Name);
                    }

                    else
                    {
                        // check status of mover
                    }
                    lootTask = null;
                    return walkTask;
                }
            }

            public override bool ActivityDone(Activity task)
            {
                if (task == lootTask)
                {
                    DidHarvest(node);
                    node = null;
                }

                task.Stop();
                return false;
            }
        }
        public abstract class NPCInteractTask : ParserTask
        {
            public string NPC;
            GUnit npcUnit;
            Location location = null;

            public NPCInteractTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                NPC = node.GetValueOfId("NPC").GetStringValue();
                location = node.GetValueOfId("Location").GetLocationValue();
            }


            public override void GetParams(List<string> l)
            {
                l.Add("NPC");
                l.Add("Location");
                base.GetParams(l);
            }

            public GUnit FindNPC()
            {
                if (npcUnit == null || !npcUnit.IsValid)
                    npcUnit = GObjectList.FindUnit(NPC);
                return npcUnit;
            }


            public override Location GetLocation()
            {
                if (location != null) return location;
                Location loc = GetLocationOfNPC();
                return loc;
            }

            public bool KnowNPCLocation()
            {
                return GetLocationOfNPC() != null;
            }
            public bool CanSeeNPC()
            {

                return FindNPC() != null;
            }

            public bool IsCloseToNPC()
            {
                GUnit npc = FindNPC();
                if (npc == null) return false;
                Location mel = new Location(GContext.Main.Me.Location);
                Location npcl = new Location(npc.Location);

                float d = mel.GetDistanceTo(npcl);
                if (d < GContext.Main.MeleeDistance && Math.Abs(mel.Z - npcl.Z) < 2.0) return true;
                return false;
            }

            public Location GetLocationOfNPC()
            {
                GUnit npc = FindNPC();
                if (npc == null)
                    return ppather.FindNPCLocation(NPC); ;
                Location l = new Location(npc.Location);
                return l;
            }

            protected ActivityApproach approachTask;
            protected ActivityWalkTo walkToTask;

            string prevNPC = "";
            public Activity GetWalkToActivity()
            {

                GUnit npc = FindNPC();
                if (npc == null)
                {
                    Location l = GetLocationOfNPC();
                    if (l == null)
                        return null;
                    if (walkToTask == null || NPC != prevNPC)
                        walkToTask = new ActivityWalkTo(this, l, 2f);
                    prevNPC = NPC;
                    return walkToTask;

                }
                else
                {
                    if (approachTask == null || NPC != prevNPC)
                        approachTask = new ActivityApproach(this, npc, 2f);
                    prevNPC = NPC;
                    return approachTask;
                }

            }
        }
        public class QuestPickupTask : NPCInteractTask
        {
            String Name;
            String ID;


            public QuestPickupTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Name = node.GetValueOfId("Name").GetStringValue();
                ID = node.GetValueOfId("ID").GetStringValue();
                if (ID == null || ID == "") ID = Name;
            }

            public override string ToString()
            {
                return "Pickup " + Name + " " + ID;
            }

            public override void GetParams(List<string> l)
            {
                l.Add("Name");
                l.Add("ID");
                base.GetParams(l);
            }

            public override bool IsFinished()
            {
                if (ppather.IsQuestDone(ID)) return true;
                if (ppather.IsQuestAccepted(ID)) return true;
                if (ppather.IsQuestGoalDone(ID)) return true;
                return false;
            }

            public override bool WantToDoSomething()
            {
                if (IsFinished()) return false;
                if (!KnowNPCLocation()) return false;
                return true;
            }

            ActivityPickupQuest gossipActivity;
            public override Activity GetActivity()
            {

                // GContext.Main.Log("Pickup::GetActivity()");
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (gossipActivity == null)
                        gossipActivity = new ActivityPickupQuest(this, FindNPC(), Name, ID);
                    return gossipActivity;
                }

            }

            public override bool ActivityDone(Activity task)
            {
                if (task == approachTask)
                {
                    ActivityApproach wt = (ActivityApproach)task;
                    EasyMover.MoveResult mr = wt.MoveResult;
                    if (mr != EasyMover.MoveResult.GotThere)
                    {
                        GContext.Main.Log("Can't reach guy that hands out quest. Quest failed");
                        ppather.QuestFailed(ID);
                    }

                }

                if (task == walkToTask)
                {
                    ActivityWalkTo wt = (ActivityWalkTo)task;
                    EasyMover.MoveResult mr = wt.MoveResult;
                    if (mr != EasyMover.MoveResult.GotThere)
                    {
                        GContext.Main.Log("Can't reach guy that hands out quest. Quest failed");
                        ppather.QuestFailed(ID);
                    }
                }

                if (task == gossipActivity)
                {
                    // The gossip is done
                    return true;
                }
                return false;
            }
        }
        public class QuestGoalTask : ParserTask
        {

            String Name;
            String ID;
            Task childTask;

            public QuestGoalTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Name = node.GetValueOfId("Name").GetStringValue();
                ID = node.GetValueOfId("ID").GetStringValue();
                if (ID == null || ID == "") ID = Name;
                childTask = pather.CreateTaskFromNode(node.subTasks[0], this);
            }


            public override void GetParams(List<string> l)
            {
                l.Add("Name");
                l.Add("ID");
            }

            public override string ToString()
            {
                return "Goal " + Name + " " + ID;
            }

            public override Task[] GetChildren()
            {
                return new Task[] { childTask };
            }

            public override Location GetLocation()
            {
                return childTask.GetLocation();
            }

            public override void Restart() // doh!
            {
                childTask.Restart();
            }

            public override bool IsFinished()
            {
                if (ppather.IsQuestDone(ID)) return true;
                if (ppather.IsQuestGoalDone(ID)) return true;
                bool f = childTask.IsFinished();
                if (f && ppather.IsQuestAccepted(ID) && !ppather.IsQuestGoalDone(ID))
                    ppather.QuestGoalDone(ID);
                return f;
            }

            public override bool WantToDoSomething()
            {
                if (!ppather.IsQuestAccepted(ID)) return false;
                if (ppather.IsQuestDone(ID)) return false;
                if (ppather.IsQuestGoalDone(ID)) return false;
                return childTask.WantToDoSomething();
            }
            public override Activity GetActivity()
            {
                return childTask.GetActivity();
            }

            public override bool ActivityDone(Activity task)
            {
                bool childDone = childTask.ActivityDone(task);
                if (childTask.IsFinished())
                    ppather.QuestGoalDone(ID);
                return childDone;
            }


        }
        public class QuestHandinTask : NPCInteractTask
        {

            String Name;
            String ID;
            int Reward;

            public QuestHandinTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Name = node.GetValueOfId("Name").GetStringValue();
                ID = node.GetValueOfId("ID").GetStringValue();
                if (ID == null || ID == "") ID = Name;

                Reward = node.GetValueOfId("Reward").GetIntValue();
                if (Reward == 0) Reward = 1;
            }

            public override string ToString()
            {
                return "Handin " + Name + " " + ID;
            }

            public override void GetParams(List<string> l)
            {
                l.Add("Name");
                l.Add("ID");
                l.Add("Reward");
                base.GetParams(l);
            }
            public override bool IsFinished()
            {
                if (ppather.IsQuestDone(ID)) return true;
                return false;
            }

            public override bool WantToDoSomething()
            {
                if (ppather.IsQuestDone(ID)) return false;
                if (!KnowNPCLocation()) return false;
                if (ppather.IsQuestGoalDone(ID)) return true;
                return false;
            }

            ActivityHandinQuest gossipActivity;
            public override Activity GetActivity()
            {
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (gossipActivity == null)
                        gossipActivity = new ActivityHandinQuest(this, FindNPC(), Name, ID, Reward);
                    return gossipActivity;
                }

            }

            public override bool ActivityDone(Activity task)
            {
                if (task == gossipActivity)
                {
                    return true;
                }

                return false;
            }
        }
        public class TrainTask : NPCInteractTask
        {
            public TrainTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
            }
            public override bool WantToDoSomething()
            {
                if (!KnowNPCLocation() || ppather.IsBlacklisted(NPC)) return false;
                return true;
            }

            ActivityTrain gossipActivity;
            public override Activity GetActivity()
            {
                if (!IsCloseToNPC())
                {
                    return GetWalkToActivity();
                }
                else
                {
                    if (gossipActivity == null)
                        gossipActivity = new ActivityTrain(this, FindNPC());
                    return gossipActivity;
                }
            }

            public override bool ActivityDone(Activity task)
            {
                if (task == gossipActivity)
                {
                    ppather.Blacklist(NPC);
                    return true;
                }
                return false;
            }

            public override bool IsFinished()
            {
                return false;
            }
        }
        public abstract class RunnerTask : ParserTask
        {
            public List<Location> Locations;
            Location currentHotSpot = null;
            ActivityWalkTo currentWalker = null;


            public override void GetParams(List<string> l)
            {
                l.Add("Locations");
                base.GetParams(l);
            }
            public RunnerTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
                Locations = new List<Location>();

                Value hs = node.GetValueOfId("Locations");

                List<Value> hs_list = hs.GetCollectionValue();

                foreach (Value v in hs_list)
                {
                    Location l = v.GetLocationValue();
                    Locations.Add(l);
                }
            }

            public abstract Location GetNextLocation();


            public override Location GetLocation()
            {
                if (currentHotSpot == null)
                {
                    currentHotSpot = GetNextLocation();
                    GContext.Main.Log("GetLoc need next . got " + currentHotSpot);
                }
                return currentHotSpot;
            }

            public override bool WantToDoSomething()
            {
                if (GetLocation() == null) return false;
                return true; // always want to run
            }

            public override Activity GetActivity()
            {

                if (currentHotSpot == null)
                {
                    GContext.Main.Log("GetAct need next");
                    currentHotSpot = GetNextLocation();
                }
                if (currentWalker == null)
                    currentWalker = new ActivityWalkTo(this, currentHotSpot, 10.0f);
                return currentWalker;
            }

            public override bool ActivityDone(Activity task)
            {
                GContext.Main.Log("ActDone need next");
                currentHotSpot = GetNextLocation();
                currentWalker = null;
                task.Stop();
                return false;
            }

        }
        public class HotspotTask : RunnerTask
        {
            int currentHotSpotIndex = 0;
            String order;

            public HotspotTask(PPather pather, NodeTask node)
                : base(pather, node)
            {


                Value or = node.GetValueOfId("Order");
                order = or.GetStringValue();

            }

            public override void GetParams(List<string> l)
            {
                l.Add("Order");
                base.GetParams(l);
            }

            public override bool IsFinished()
            {
                return false;
            }

            public override string ToString()
            {
                return "Go to hotspot";
            }

            public override Location GetNextLocation()
            {
                if (order == "Order" || order == "order")
                {
                    currentHotSpotIndex++;
                    if (currentHotSpotIndex >= Locations.Count)
                        currentHotSpotIndex = 0;
                }
                else
                {
                    currentHotSpotIndex = PPather.random.Next(Locations.Count);
                }
                return Locations[currentHotSpotIndex];
            }
        }
        public class WalkTask : RunnerTask
        {
            int currentHotSpotIndex = -1;

            public WalkTask(PPather pather, NodeTask node)
                : base(pather, node)
            {
            }

            public override void GetParams(List<string> l)
            {

                base.GetParams(l);
            }
            public override void Restart()
            {
                currentHotSpotIndex = 0;
            }

            public override bool IsFinished()
            {
                return currentHotSpotIndex >= Locations.Count;
            }

            public override string ToString()
            {
                return "Go to";
            }

            public override Location GetNextLocation()
            {
                GContext.Main.Log("Walk " + currentHotSpotIndex + " " + Locations.Count);
                currentHotSpotIndex++;
                if (currentHotSpotIndex >= Locations.Count) return null;
                Location l = Locations[currentHotSpotIndex];
                return l;
            }
        }
        #endregion

    #region Activity Management
        public abstract class Activity
        {
            public string name;
            public PPather ppather;
            public Task task; // Who produced me

            public Activity(Task task, String name)
            {
                this.name = name;
                this.task = task;
                ppather = task.ppather;
            }

            public override string ToString()
            {
                return name;
            }
            public abstract Location GetLocation(); // return the target location for this task
            public virtual void Start() { } // Task selected for execution
            public abstract bool Do();    // Called periodically when this task is activated, return true if task is done
            public virtual void Stop() { }  // 
        }
        public class ActivityHearth : Activity
        {
            public ActivityHearth(Task t)
                : base(t, "Hearth")
            {
            }
            public override Location GetLocation()
            {
                return null;
            }


            public override bool Do()
            {
                GContext.Main.CastSpell("Common.Hearth");
                return true; // !?!?
            }

        }
        public class ActivityRest : Activity
        {
            public ActivityRest(Task t)
                : base(t, "Rest")
            {
            }
            public override Location GetLocation()
            {
                return null;
            }


            public override bool Do()
            {
                ppather.Rest();
                return true; // !?!?
            }

        }
        public class ActivityAttack : Activity
        {
            GUnit monster;
            public ActivityAttack(Task t, GUnit monster)
                : base(t, "Attack " + monster.Name)
            {
                this.monster = monster;
            }

            public override Location GetLocation()
            {
                return new Location(monster.Location);
            }

            public override bool Do()
            {

                GPlayerSelf Me = GContext.Main.Me;

                ppather.Face(monster);

                if (monster.SetAsTarget(false))
                {
            GUnit target = monster;
            GCombatResult res; 
            do
            {
                ppather.UnBlacklist(target);
                ppather.TargetIs(target);
                target.TouchHealthDrop();
                    ppather.StartCombat();
                res = ppather.KillTarget(target, Me.IsInCombat);
                    if (res == GCombatResult.Bugged || res == GCombatResult.OtherPlayerTag)
                        {
                            // TODO make sure to wait out evaders that are attackign us, they usually stop after a few seconds
                            if(res == GCombatResult.Bugged)
                            {
                                GSpellTimer t = new GSpellTimer(3000);
                                while(Me.IsInCombat && !t.IsReadySlow);
                            }
                    ppather.Blacklist(target);
                        }
                    if (res == GCombatResult.Died)
                    {
                        return true; // sigh
                    }
                    if (res == GCombatResult.Success ||
                       res == GCombatResult.SuccessWithAdd)
                    {
                    ppather.Killed(target);
                    }
                
                if(res == GCombatResult.SuccessWithAdd)
                    {
                    target = Me.Target;
                    }
                else
                {
                    target.Refresh(true);
                    Thread.Sleep(100);

                    // wait for combat flag to expire unless we have attackers
                    {
                        GSpellTimer t = new GSpellTimer(2000);
                        while (Me.IsInCombat && GObjectList.GetNearestAttacker(0) == null && !t.IsReadySlow) ;
                                //GContext.Main.Log("t: " + (2000 - t.TicksLeft));
                    }
                    if(ppather.IsItSafeAt(null, GContext.Main.Me) && !Me.IsInCombat)
                    {
                      ppather.Rest();
                    }
                }
            } while(res == GCombatResult.SuccessWithAdd && target != null);
        }
                else
                {
                    GContext.Main.Log("Can not target monster " + monster.Name);
                    ppather.Blacklist(monster);
                }

                return true; // !?!?
            }

        }
        public class ActivityLoot : Activity
        {
            GUnit monster;
            bool Skin;
            public ActivityLoot(Task t, GUnit monster, bool Skin)
                : base(t, "Loot " + monster.Name)
            {
                this.monster = monster;
                this.Skin = Skin;
            }

            public override Location GetLocation()
            {
                return null; // I will not move
            }

            public override bool Do()
            {
        ppather.Face(monster);
                if(monster.IsLootable)
                {
                monster.Interact();
                GSpellTimer bop = new GSpellTimer(500);
                do
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        if (PPather.Popup.IsVisible(i))
                        {
                            String text = PPather.Popup.GetText(i);
                            GContext.Main.Log("Got a loot popup ('" + text + "')");
                            if(text == "Looting this item will bind it to you.")
                            {
                            PPather.Popup.ClickButton(i, 1);
                        }
                            else
                            {
                                PPather.Popup.ClickButton(i, 2);                                
                            }
                        }
                    }
                } while (!bop.IsReadySlow);
                Thread.Sleep(500);
                    }

                /*Skinning start*/
                if(Skin)
                {
                    int attempt = 1;
                    GSpellTimer futile = new GSpellTimer(3000); futile.Reset(); // is 3s enough for skinning to be done?!
                    GContext.Main.Log("Want to skin");
                    while (monster.IsLootable && !futile.IsReadySlow); //Waiting for looting to finish
                Thread.Sleep(500);
                    GContext.Main.Log("Skinnable: " + monster.IsSkinnable );
                    while (monster.IsValid && monster.IsSkinnable && attempt <= 3)
                    {
                      GContext.Main.Log("Skin. Attempt #" + attempt);
                        monster.Interact();

                        //Waiting for skinning to finish (we always have target while skinning+looting afterwards)
                        futile.Reset();
                        while (GPlayerSelf.Me.Target != null && !futile.IsReadySlow);
                        attempt ++;
                        if(GPlayerSelf.Me.Target == null) break; // done
                    }
                }
                /*Skinning end*/
                ppather.Looted(monster);

                return true;
            }
        }
        public class ActivityPickupQuest : Activity
        { 
            GUnit unit;
            String QuestName;
            String QuestID;

            public ActivityPickupQuest(Task t, GUnit unit, String QuestName, String QuestID)
                : base(t, "PickupQuest " + QuestName)
            {
                this.unit = unit;
                this.QuestName = QuestName;
                this.QuestID = QuestID;
            }

            public override Location GetLocation()
            {
                return null; // I will not move
            }
            public override bool Do()
            {
                ppather.Face(unit);
                int option = 0; 
                while(true)
                {
                    bool got_option = false;
                    if(ppather.IsQuestAccepted(QuestID)) return true; // weee

            ppather.Face(unit);
                    unit.Interact();
                    Thread.Sleep(2000);
                    if (PPather.GossipFrame.IsVisible())
                    {
                        GContext.Main.Log("Got a gossip frame");
                        got_option = true;
                        int[] options = PPather.GossipFrame.VisibleOptions();
                        if(option >= options.Length) 
                        {
                            GContext.Main.Log("Can not find the quest option in the gossip frame");
                            ppather.QuestFailed(QuestID);
                            return true; // cry
                        }
                        PPather.GossipFrame.ClickOption(options[option]);
                        option++; 
                        Thread.Sleep(1000);
                    }

                    if (PPather.QuestFrame.IsVisible() && PPather.QuestFrame.IsSelect())
                    {
                        GContext.Main.Log("Got a quest select frame");
                        got_option = true;
                        int[] options = PPather.QuestFrame.VisibleOptions();
                        if(option >= options.Length) 
                        {
                            GContext.Main.Log("Can not find the quest option in the quest select frame");
                            ppather.QuestFailed(QuestID);
                                return true; // cry
                        }
                        PPather.QuestFrame.ClickOption(options[option]);
                        option++; 
                        Thread.Sleep(1000);
                        
                    }
                    if (PPather.QuestFrame.IsVisible() && PPather.QuestFrame.IsAccept())
                    {                        
                        GContext.Main.Log("Great! An accept frame");
                        string quest = PPather.QuestFrame.GetAcceptTitle(); 
                        if (quest.Contains(QuestName))
                        {
                            GContext.Main.Log("Names matched on quest pickup " + quest);
                            ppather.QuestAccepted(QuestID);
                            PPather.QuestFrame.Accept();
                            Thread.Sleep(3000);
                            return true;
                        }
                        else
                        {
                            GContext.Main.Log("Wrong quest");
                            GContext.Main.SendKey("Common.Escape");
                            Thread.Sleep(1000);
                            if(!got_option)
                            {
                                ppather.QuestFailed(QuestID);
                                return true; // cry                        
                            }                            
                        }
                    }
                    else
                    {
                        GContext.Main.Log("hmm, what strange frame was that?!");
                        GContext.Main.SendKey("Common.Escape");
                        Thread.Sleep(1000);
                        if(!got_option)
                        {
                            ppather.QuestFailed(QuestID);
                            return true; // cry                        
                        }
                    }
                }
            }    
        }
        public class ActivityHandinQuest : Activity
        {
            GUnit unit;
            String QuestName;
            String QuestID;
            int Reward;

            public ActivityHandinQuest(Task t, GUnit unit, String QuestName, String QuestID, int Reward)
                : base(t, "HandinQuest " + QuestName)
            {
                this.unit = unit;
                this.QuestName = QuestName;
                this.QuestID = QuestID;
                this.Reward = Reward;
            }

            public override Location GetLocation()
            {
                return null; // I will not move
            }


/*
  hmm dialog navigation: 
   
    If there are many options you will get either a
        GossipFrame or a QuestFrame.IsSelect
 
    After that was selected you want to get a
       QuestFrame.IsContinue followed by a
       QuestFrame.IsComplete
    or 
       QuestFrame.IsComplete

 */

            public override bool Do()
            { 
                ppather.Face(unit);
                int option = 0; 
                while(true)
                {
                    if(ppather.IsQuestDone(QuestID)) return true; // weee
                    
                    bool got_option = false;
                    unit.Interact();
                    Thread.Sleep(2000);
                    if (PPather.GossipFrame.IsVisible())
                    {
                        GContext.Main.Log("Got a gossip frame");
                        got_option = true;

                        int[] options = PPather.GossipFrame.VisibleOptions();
                        if(option >= options.Length) 
                        {
                            GContext.Main.Log("Can not find the quest option in the gossip frame");
                            ppather.QuestFailed(QuestID);
                            return true; // cry
                        }
                        PPather.GossipFrame.ClickOption(options[option]);
                        option++; 
                        Thread.Sleep(1000);
                    }

                    if (PPather.QuestFrame.IsVisible())
                    {
                        if(PPather.QuestFrame.IsSelect())
                        {
                            got_option = true;
                            GContext.Main.Log("Got a quest select frame");
                            int[] options = PPather.QuestFrame.VisibleOptions();
                            if(option >= options.Length) 
                            {
                                GContext.Main.Log("Can not find the quest option in the quest select frame");
                                ppather.QuestFailed(QuestID);
                                return true; // cry
                            }
                            PPather.QuestFrame.ClickOption(options[option]);
                            option++; 
                            Thread.Sleep(1000);                            
                        }
                    }                    

                    if (PPather.QuestFrame.IsVisible() && PPather.QuestFrame.IsContinue())
                    {
                        GContext.Main.Log("Hmm, its a continue frame");
                        PPather.QuestFrame.Continue();
                        Thread.Sleep(1000); 
                    }
                    
                    if(PPather.QuestFrame.IsVisible() && PPather.QuestFrame.IsComplete())
                    {
                        GContext.Main.Log("Great! A quest complete frame");
                        string quest = PPather.QuestFrame.GetCompleteTitle(); 
                        if (quest.Contains(QuestName))
                        {
                            GContext.Main.Log("Complete quest name match for " + quest);
                            PPather.QuestFrame.SelectReward(Reward);
                            Thread.Sleep(300); 
                            PPather.QuestFrame.Complete();
                            ppather.QuestCompleted(QuestID);
                            Thread.Sleep(3000);
                            return true;
                        }
                        else
                        {
                            GContext.Main.Log("Not the right quest");
                            GContext.Main.SendKey("Common.Escape");
                            Thread.Sleep(1000);
                            if (!got_option)
                            {
                                ppather.QuestFailed(QuestID);
                                return true; // cry                        
                            }
                        }
                    }
                    else
                    {
                        GContext.Main.Log("hmm, what strange frame was that?!");
                        GContext.Main.SendKey("Common.Escape");
                        Thread.Sleep(1000);
                        if(!got_option)
                        {
                            ppather.QuestFailed(QuestID);
                            return true; // cry       
                        }
                    }

                }

            }
        }
        public class ActivityPickup : Activity
        {
            GNode node;
            public ActivityPickup(Task t, GNode node)
                : base(t, "Pickup " + node.Name)
            {
                this.node = node;
            }

            public override Location GetLocation()
            {
                return null; // I will not move
            }

            public override bool Do()
            {
                ppather.Face(node);
                int n = 3;
                // Todo, special for mines
                if (node.IsMineral)
                    n = 6;
                do
                {
            ppather.Face(node);
                    node.Interact();
                    if(GContext.Main.Me.IsInCombat) return false;

                    Thread.Sleep(500);
                    while (GContext.Main.Me.IsCasting)
                        Thread.Sleep(200);

                    if (GContext.Main.Me.IsInCombat) return false;
                    GSpellTimer bop = new GSpellTimer(500);
                    do
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            if (PPather.Popup.IsVisible(i))
                            {
                                String text = PPather.Popup.GetText(i);
                                GContext.Main.Log("Got a loot popup ('" + text + "')");
                                if(text == "Looting this item will bind it to you.")
                                {
                                PPather.Popup.ClickButton(i, 1);
                            }
                                else
                                {
                                    PPather.Popup.ClickButton(i, 2);                                
                        }
                            }
                        }
                    } while (!bop.IsReadySlow);
                    if (GContext.Main.Me.IsInCombat) return false;
                    Thread.Sleep(2500);
                    if (GContext.Main.Me.IsInCombat) return false;
                    n--;
                } while (node.IsValid && n > 0);
                ppather.PickedUp(node);


                return true;
            }
        }
        public class ActivitySellAndRepair : Activity
        {
            GUnit npc;
            bool SellGrey; 
            bool SellWhite; 
            bool SellGreen;
            List<string> Protected; 

            public ActivitySellAndRepair(Task t, GUnit npc, 
                        bool SellGrey, bool SellWhite, bool SellGreen, 
                        List<string> Protected)
                : base(t, "SellRepair")
            {
                this.npc = npc;
                this.SellGrey = SellGrey; 
                this.SellWhite= SellWhite; 
                this.SellGreen = SellGreen;
                this.Protected = Protected; 
            }

            public override Location GetLocation()
            {
                return null; // I will not move
            }


            /*
              This will not work if you have "holes" in your bag slots. 
              All bags must be packed to the right 
            */
            bool SellStuff(int bagNr)
            {
                // cb=0 default bag
                // cb=1 bar #1 ...
                long[] AllBags = GPlayerSelf.Me.Bags;
                long[] Contents;
                int SlotCount;
                bool SellAnything = false;
                if (bagNr == 0)
                {
                    Contents = GContext.Main.Me.BagContents;
                    SlotCount = 16;
                }
                else
                {
                    GContainer bag = (GContainer)GObjectList.FindObject(AllBags[bagNr - 1]);
                    if (bag != null)
                    {
                        Contents = bag.BagContents;
                        SlotCount = bag.SlotCount;
                    }
                    else
                        return false;
                }
                if(Contents == null) return false;
                
                for (int i = 0; i < Contents.Length; i++)
                {
                    bool Skip = false;
                    if (Contents[i] == 0)
                        continue;
                    
                    GItem CurItem = (GItem)GObjectList.FindObject(Contents[i]);
                    //Context.Log("Checking: " + CurItem.Name);
                    if(CurItem != null)
                    {
                    string ItemName = CurItem.Name.ToLower();
                    foreach (string ProtItem in Protected)
                    {
                        if (ProtItem != "" && ItemName.Contains(ProtItem))
                        {
                            //Context.Log("Not Selling Item: " + CurItem.Name + " Reason=\"Is on safe list\"");
                            Skip = true;
                            break;
                        }
                    }
                    //GContext.Main.Log("quality: " + CurItem.Definition.Quality);
                    //GContext.Main.Log(" gray " + SellGrey + " white " + SellWhite + " green" + SellGrey);
                    if ((CurItem.Definition.Quality == GItemQuality.Poor && SellGrey) ||
                        (CurItem.Definition.Quality == GItemQuality.Common && SellWhite) ||
                        (CurItem.Definition.Quality == GItemQuality.Uncommon && SellGreen))
                    {
                        // Sell the crap
                    }
                    else
                        Skip = true;
                    
                    //If we got here, we plan on selling the item
                    if (!Skip)
                    {
                        GContext.Main.Log("  Will sell item: " + CurItem.Name);
                        SellAnything = true;

                        GInterfaceObject CurItemObj = GContext.Main.Interface.GetByName("ContainerFrame" + (bagNr + 1) + "Item" + (SlotCount - i));
                        CurItemObj.ClickMouse(true);
                        Thread.Sleep(500);
                        }
                    }
                }
                return SellAnything;
            }


            bool CheckBags()
            {
              bool sell = false;
              for (int i = 0; i < 5; i++)
              {
                  if (SellStuff(i))
                      sell = true;
              }
              return sell;
            }


            public override bool Do()
            {
                ppather.Face(npc);
                int option = 0; 
                
                while(true)
                {
                npc.Interact();
                    Thread.Sleep(2000);

                    if (PPather.GossipFrame.IsVisible())
                  {
                        GContext.Main.Log("Got a gossip frame");

                        int[] options = PPather.GossipFrame.VisibleOptions();
                        if(option >= options.Length) 
                  {
                            GContext.Main.Log("Can not find a merchant option in the gossip frame");
                            return true; // cry
                        }
                        PPather.GossipFrame.ClickOption(options[option]);
                        option++; 
                        Thread.Sleep(1000);
                  }
                
                    if (PPather.MerchantFrame.IsVisible())
                { 
                GMerchant Merchant = new GMerchant();
                
                    // TODO. add a close all bags right here

                    // and the open them all again, including the base backpack
                    for (int b = 0; b < 4; b++)
                    {
                        GInterfaceObject CurBag = GContext.Main.Interface.GetByName("CharacterBag" + b + "Slot");
                        if (CurBag != null )
                        {
                            CurBag.ClickMouse(false);
                            Thread.Sleep(100);
                        }
                    }
                    
                    CheckBags();
                    
                    
                    if (Merchant.IsRepairEnabled)   // Might as well fix it up while we're here.  
                    {
                        GContext.Main.Log("  Reparing");
                        Merchant.ClickRepairButton();
                    }
                    
                    Merchant.Close();
                }
             		else
                       GContext.Main.SendKey("Common.Escape"); // Close whatever frame popped up
                        return true;
                }
	
            }
        }
        public class ActivityQueue : Activity
        {
            GUnit npc;
            
            public ActivityQueue(Task t, GUnit npc)
		: base(t, "Queue")
            {
		this.npc = npc;
            }
            
            public override Location GetLocation()
            {
                return null; // I will not move
            }
            
            public override bool Do()
            {
		ppather.Face(npc);
		npc.Interact();
		Thread.Sleep(5000);
                
		if (PPather.BattlefieldFrame.IsVisible() && PPather.BattlefieldFrame.IsJoin())
		{
                    GContext.Main.Log("Hmm, its a battleground frame");
                    PPather.BattlefieldFrame.Join();
                    Thread.Sleep(3000);
                    PPather.BattlefieldFrame.Close();
                    Thread.Sleep(1000);
		}
                
		return true;
            }
        }
        public class ActivityTaxi : Activity
        {
            GUnit npc;
            String destination;
            
            public ActivityTaxi(Task t, GUnit npc, String destination)
                : base(t, "Taxi")
            {
		this.npc = npc;
		this.destination = destination;
            }
            
            public override Location GetLocation()
            {
		return null; // I will not move
            }
            
            public void EnjoyFlight()
            {
		bool isFlying = true;
                
		while (isFlying)
		{
                    GLocation loc1 = GContext.Main.Me.Location, loc2 = GContext.Main.Me.Location;
                    
                    Thread.Sleep(5000);
                    
                    GContext.Main.Me.Refresh();
                    Thread.Sleep(1500);
                    loc2 = GContext.Main.Me.Location;
                    
                    // if we aren't moving.. we aren't in flight
                    if (((loc1.X - loc2.X) == 0) && ((loc1.Y - loc2.Y) == 0) && ((loc1.Z - loc2.Z) == 0)) isFlying = false;
		}
                
		GContext.Main.Log("Taxi should have landed, EnjoyFlight() done!");
            }
            
            public override bool Do()
            {
		ppather.Face(npc);
		npc.Interact();
		Thread.Sleep(5000);
		GContext.Main.Log("PPather.TaxiFrame.IsVisible:" + (PPather.TaxiFrame.IsVisible() ? "yes" : "no"));

		if (PPather.TaxiFrame.IsVisible())
		{
                    GContext.Main.Log("Got Taxi Frame - Time to Fly?");
                    int buttonId = PPather.TaxiFrame.GetButtonId(destination);
                    
                    if (buttonId > 0)
                    {
                        ppather.ResetMyPos();
                        
                        PPather.TaxiFrame.ClickTaxiButton(buttonId);
                        Thread.Sleep(2000);
                        
                        EnjoyFlight();
                    }
                }
                
                return true;
            }
        }
        public class ActivityWalkTo : Activity
        {
            private Location to;
            private EasyMover em;
            private float howClose;
            public EasyMover.MoveResult MoveResult = EasyMover.MoveResult.Moving;

            public ActivityWalkTo(Task t, Location to, float howClose)
                : base(t, "Walk to " + to)
            {
                this.to = to;
                this.howClose = howClose;
            }

            public override Location GetLocation()
            {
                return to;
            }

            public override void Start()
            {
                // Create a path
                em = new EasyMover(ppather, to, false, true);
            }

            public override bool Do()
            {
                if (em == null) return true; // WTF!

                MoveResult = em.move();
                if (MoveResult != EasyMover.MoveResult.Moving) return true; // done, can't do more

                Location meLocation = new Location(GContext.Main.Me.Location);
                if (meLocation.GetDistanceTo(to) < howClose)
                {
                    PPather.mover.Stop();
                    return true;
                }
                return false;
            }

            public override void Stop()
            {
                PPather.mover.Stop();
                em = null;

            }
        }
        public class ActivityApproach : Activity
        {
            private GUnit monster;
            private EasyMover em;
            private Location to;
            private float howClose;
            public EasyMover.MoveResult MoveResult = EasyMover.MoveResult.Moving;

            public ActivityApproach(Task t, GUnit monster, float howClose)
                : base(t, "Approach " + monster.Name)
            {
                this.monster = monster;
                this.howClose = howClose;
            }

            public override Location GetLocation()
            {
                return new Location(monster.Location);
            }

            public override void Start()
            {
                // Create a path
                to = GetLocation();
                em = new EasyMover(ppather, to, false, true);
            }

    GSpellTimer tabSpam = new GSpellTimer(600);
            public override bool Do()
            {
                if (em == null) return true; // WTF!

                if (GContext.Main.Me.Target != monster && tabSpam.IsReady && monster.DistanceToSelf < 50)
                {
                    GContext.Main.SendKey("Common.Target");
                    tabSpam.Reset();
                }

        if (GetLocation().GetDistanceTo(to) > GContext.Main.MeleeDistance)
                {
                    // need a new path, monster moved
                    to = GetLocation();
                    em = new EasyMover(ppather, to, false, true);
                }

                MoveResult = em.move();
                if (MoveResult != EasyMover.MoveResult.Moving) return true; // done, can't do more

                Location meLocation = new Location(GContext.Main.Me.Location);
                if (meLocation.GetDistanceTo(to) < howClose)
                {
                    PPather.mover.Stop();
                    return true;
                }
                return false;
            }

            public EasyMover.MoveResult GetMoveResult()
            {
                return MoveResult;
            }
            
            public override void Stop()
            {
                PPather.mover.Stop();
                em = null;

            }
        }
        public class ActivityTrain : Activity
        {
            GUnit unit;

            public ActivityTrain(Task t, GUnit unit)
                : base(t, "Train")
            {
                this.unit = unit;
            }
            
            public override Location GetLocation()
            {
                return null;
            }
            
            public override bool Do()
            {
                ppather.Face(unit);
                
                unit.Interact();
                Thread.Sleep(2000);
                
                if (PPather.GossipFrame.IsVisible())
                {
                    int[] options = PPather.GossipFrame.VisibleOptions();
                    GContext.Main.SendKey("Common.Escape");
                    for (int x = 0; x < options.Length; x++)
                    {
                        unit.Interact();
                        Thread.Sleep(1000);
                        PPather.GossipFrame.ClickOption(options[x]);
                        Thread.Sleep(500);
                        if (PPather.TrainerFrame.IsVisible())
                        {
                            if (PPather.TrainerFrame.AvailableSkills().Length < 1)
                            {
                                GContext.Main.Log("No skills to train.");
                                GContext.Main.SendKey("Common.Escape");
                                return true;
                            }
                            else
                            {
                                PPather.TrainerFrame.LearnAllSkills();
                                GContext.Main.SendKey("Common.Escape");
                                return true;
                            }
                        }
                        else
                        {
                            GContext.Main.SendKey("Common.Escape");
                        }
                    }
                }                    
                else if (PPather.TrainerFrame.IsVisible())
                {
                    if (PPather.TrainerFrame.AvailableSkills().Length < 1)
                    {
                        GContext.Main.Log("No skills to train.");
                        GContext.Main.SendKey("Common.Escape");
                        ppather.Blacklist(unit.Name);
                        return true;
                    }
                    else
                    {
                        PPather.TrainerFrame.LearnAllSkills();
                        GContext.Main.SendKey("Common.Escape");
                        return true;
                    }
                }
                GContext.Main.Log("Trainer frame not found");
                return true;
            }
        }
        #endregion

    #region Pathgraph
        public class Location
        {
            private float x;
            private float y;
            private float z;

            public Location(GLocation l)
            {
                this.x = l.X; this.y = l.Y; this.z = l.Z;
            }


            public Location(float x, float y, float z)
            {
                this.x = x; this.y = y; this.z = z;
            }

            public float X { get { return x; } }
            public float Y { get { return y; } }
            public float Z { get { return z; } }
            public float GetDistanceTo(Location l)
            {
                float dx = x - l.X;
                float dy = y - l.Y;
                float dz = z - l.Z;
                return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public override String ToString()
            {
                //String s = String.Format(
                String s = "{" + x + ":" + y + ":" + z + "}";
                return s;
            }


            public Location InFrontOf(float heading, float d)
            {
                float nx = x + (float)Math.Cos(heading) * d;
                float ny = y + (float)Math.Sin(heading) * d;
                float nz = z;
                return new Location(nx, ny, nz);
            }

            public ulong GUID()
            {
                ulong ix = (ulong)(x + 100000.0);
                ulong iy = (ulong)(y + 100000.0);
                ulong iz = (ulong)(z + 100000.0);
                ulong g = ix | (iy << 24) | (iz << 48);
                return g;
            }
        }

        public class GraphChunk
        {
            public const int CHUNK_SIZE = 512;


            float base_x, base_y;
            public int ix, iy;
            public bool modified = false;
            public long LRU = 0;

            Spot[,] spots;

            public GraphChunk(float base_x, float base_y, int ix, int iy)
            {
                this.base_x = base_x;
                this.base_y = base_y;
                this.ix = ix;
                this.iy = iy;
                spots = new Spot[CHUNK_SIZE, CHUNK_SIZE];
                modified = false;
            }

            public void Clear()
            {
                foreach (Spot s in spots)
                    if (s != null) s.traceBack = null;

                spots = null;
            }

            private void LocalCoords(float x, float y, out int ix, out int iy)
            {
                ix = (int)(x - base_x);
                iy = (int)(y - base_y);
            }

            public Spot GetSpot2D(float x, float y)
            {
                int ix, iy;
                LocalCoords(x, y, out ix, out iy);
                Spot s = spots[ix, iy];
                return s;
            }

            public Spot GetSpot(float x, float y, float z)
            {
                Spot s = GetSpot2D(x, y);

                while (s != null && !s.IsCloseZ(z))
                {
                    s = s.next;
                }

                return s;
            }

            // return old spot at conflicting poision
            // or the same as passed the function if all was ok
            public Spot AddSpot(Spot s)
            {
                Spot old = GetSpot(s.X, s.Y, s.Z);
                if (old != null) return old;
                int x, y;

                s.chunk = this;

                LocalCoords(s.X, s.Y, out x, out y);

                s.next = spots[x, y];
                spots[x, y] = s;
                modified = true;
                return s;
            }




            public List<Spot> GetAllSpots()
            {
                List<Spot> l = new List<Spot>();
                for (int x = 0; x < CHUNK_SIZE; x++)
                {
                    for (int y = 0; y < CHUNK_SIZE; y++)
                    {
                        Spot s = spots[x, y];
                        while (s != null)
                        {
                            l.Add(s);
                            s = s.next;
                        }
                    }
                }
                return l;
            }

            private string FileName()
            {
                return String.Format("c_{0,3:000}_{1,3:000}.bin", ix, iy);
            }

            private const uint FILE_MAGIC = 0x12341234;
            private const uint FILE_ENDMAGIC = 0x43214321;
            private const uint SPOT_MAGIC = 0x53504f54;


            // Per spot: 
            // uint32 magic
            // uint32 reserved;
            // uint32 flags;
            // float x;
            // float y;
            // float z;
            // uint32 no_paths
            //   for each path
            //     float x;
            //     float y;
            //     float z;


            public bool Load(string baseDir)
            {
                string fileName = FileName();
                string filenamebin = baseDir + fileName;

                System.IO.Stream stream = null;
                System.IO.BinaryReader file = null;
                int n_spots = 0;
                int n_steps = 0;
                try
                {
                    stream = System.IO.File.OpenRead(filenamebin);
                    if (stream != null)
                    {
                        file = new System.IO.BinaryReader(stream);
                        if (file != null)
                        {
                            uint magic = file.ReadUInt32();
                            if (magic == FILE_MAGIC)
                            {

                                uint type;
                                while ((type = file.ReadUInt32()) != FILE_ENDMAGIC)
                                {
                                    n_spots++;
                                    uint reserved = file.ReadUInt32();
                                    uint flags = file.ReadUInt32();
                                    float x = file.ReadSingle();
                                    float y = file.ReadSingle();
                                    float z = file.ReadSingle();
                                    uint n_paths = file.ReadUInt32();
                                    Spot s = new Spot(x, y, z);
                                    s.flags = flags;

                                    for (uint i = 0; i < n_paths; i++)
                                    {
                                        n_steps++;
                                        float sx = file.ReadSingle();
                                        float sy = file.ReadSingle();
                                        float sz = file.ReadSingle();
                                        s.AddPathTo(sx, sy, sz);
                                    }
                                    AddSpot(s);
                                }
                            }
                        }
                    }
                }
                catch { }
                if (file != null)
                {
                    file.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }


                Log("Loaded " + fileName + " " + n_spots + " spots " + n_steps + " steps");

                modified = false;
                return false;
            }




            public bool Save(string baseDir)
            {
                if (!modified) return true; // doh

                string fileName = FileName();
                string filename = baseDir + fileName;

                System.IO.Stream fileout = null;
                System.IO.BinaryWriter file = null;

                try
                {
                    System.IO.Directory.CreateDirectory(baseDir);
                }
                catch { };

                int n_spots = 0;
                int n_steps = 0;
                try
                {

                    fileout = System.IO.File.Create(filename + ".new");

                    if (fileout != null)
                    {
                        file = new System.IO.BinaryWriter(fileout);

                        if (file != null)
                        {
                            file.Write(FILE_MAGIC);

                            List<Spot> spots = GetAllSpots();
                            foreach (Spot s in spots)
                            {
                                file.Write(SPOT_MAGIC);
                                file.Write((uint)0); // reserved
                                file.Write((uint)s.flags);
                                file.Write((float)s.X);
                                file.Write((float)s.Y);
                                file.Write((float)s.Z);
                                uint n_paths = (uint)s.n_paths;
                                file.Write((uint)n_paths);
                                for (uint i = 0; i < n_paths; i++)
                                {
                                    uint off = i * 3;
                                    file.Write((float)s.paths[off]);
                                    file.Write((float)s.paths[off + 1]);
                                    file.Write((float)s.paths[off + 2]);
                                    n_steps++;
                                }
                                n_spots++;

                            }

                            file.Write(FILE_ENDMAGIC);
                        }

                        if (file != null)
                        {
                            file.Close(); file = null;
                        }

                        if (fileout != null)
                        {
                            fileout.Close(); fileout = null;
                        }

                        String old = filename + ".bak";

                        if (System.IO.File.Exists(old))
                            System.IO.File.Delete(old);
                        if (System.IO.File.Exists(filename))
                            System.IO.File.Move(filename, old);
                        System.IO.File.Move(filename + ".new", filename);
                        if (System.IO.File.Exists(old))
                            System.IO.File.Delete(old);

                        modified = false;
                    }
                    else
                    {
                        Log("Save failed");
                    }
                }
                catch (Exception e)
                {
                    Log("Save failed " + e);
                }

                if (file != null)
                {
                    file.Close(); file = null;
                }

                if (fileout != null)
                {
                    fileout.Close(); fileout = null;
                }

                Log("Saved " + fileName + " " + n_spots + " spots " + n_steps + " steps");

                return false;
            }

            private void Log(String s)
            {
                Console.WriteLine(s);
                //GContext.Main.Log(s);
            }
        }

        public class Spot
        {
            public const float Z_RESOLUTION = 2.0f; // Z spots max this close

            public const uint FLAG_VISITED = 0x0001;
            public const uint FLAG_BLOCKED = 0x0002;
            public const uint FLAG_MPQ_MAPPED = 0x0004;
            public const uint FLAG_WATER = 0x0008;

            public float X, Y, Z;
            public uint flags;


            public int n_paths = 0;
            public float[] paths; // 3 floats per outgoing path


            public GraphChunk chunk = null;
            public Spot next;  // list on same x,y, used by chunk

            public int searchID = 0;
            public Spot traceBack; // Used by search
            public float score; // Used by search
            public bool closed, scoreSet;


            public Spot(float x, float y, float z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public Spot(Location l)
            {
                this.X = l.X;
                this.Y = l.Y;
                this.Z = l.Z;
            }

            public bool IsBlocked()
            {
                return GetFlag(FLAG_BLOCKED);
            }

            public Location location { get { return new Location(X, Y, Z); } }
            public float GetDistanceTo(Location l)
            {
                float dx = l.X - X;
                float dy = l.Y - Y;
                float dz = l.Z - Z;
                return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public float GetDistanceTo(Spot s)
            {
                float dx = s.X - X;
                float dy = s.Y - Y;
                float dz = s.Z - Z;
                return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public bool IsCloseZ(float z)
            {
                float dz = z - this.Z;
                if (dz > Z_RESOLUTION) return false;
                if (dz < -Z_RESOLUTION) return false;
                return true;
            }

            public void SetFlag(uint flag, bool val)
            {
                uint old = flags;
                if (val)
                    flags |= flag;
                else
                    flags &= ~flag;
                if (chunk != null && old != flags) chunk.modified = true;
            }

            public bool GetFlag(uint flag)
            {
                return (flags & flag) != 0;
            }

            public void SetLocation(Location l)
            {
                X = l.X;
                Y = l.Y;
                Z = l.Z;
                if (chunk != null) chunk.modified = true;
            }

            public Location GetLocation()
            {
                return new Location(X, Y, Z);
            }

            public bool GetPath(int i, out float x, out float y, out float z)
            {
                x = y = z = 0;
                if (i > n_paths) return false;
                int off = i * 3;
                x = paths[off];
                y = paths[off + 1];
                z = paths[off + 2];
                return true;
            }


            public Spot GetToSpot(PathGraph pg, int i)
            {
                float x, y, z;
                GetPath(i, out x, out y, out z);
                return pg.GetSpot(x, y, z);

            }

            public List<Spot> GetPathsToSpots(PathGraph pg)
            {
                List<Spot> list = new List<Spot>(n_paths);
                for (int i = 0; i < n_paths; i++)
                {
                    list.Add(GetToSpot(pg, i));
                }
                return list;
            }

            public List<Location> GetPaths()
            {
                List<Location> l = new List<Location>();
                if (paths == null) return l;
                for (int i = 0; i < n_paths; i++)
                {
                    int off = i * 3;
                    Location loc = new Location(paths[off], paths[off + 1], paths[off + 2]);
                    l.Add(loc);
                }
                return l;
            }

            public bool HasPathTo(PathGraph pg, Spot s)
            {
                for (int i = 0; i < n_paths; i++)
                {
                    Spot to = GetToSpot(pg, i);
                    if (to == s) return true;
                }
                return false;
            }

            public bool HasPathTo(Location l)
            {
                return HasPathTo(l.X, l.Y, l.Z);
            }



            public bool HasPathTo(float x, float y, float z)
            {
                if (paths == null) return false;
                for (int i = 0; i < n_paths; i++)
                {
                    int off = i * 3;
                    if (x == paths[off] &&
                       y == paths[off + 1] &&
                       z == paths[off + 2])
                        return true;
                }
                return false;
            }

            public void AddPathTo(Spot s)
            {
                AddPathTo(s.X, s.Y, s.Z);
            }

            public void AddPathTo(Location l)
            {
                AddPathTo(l.X, l.Y, l.Z);
            }

            public void AddPathTo(float x, float y, float z)
            {
                if (HasPathTo(x, y, z)) return;
                int old_size;
                if (paths == null) old_size = 0; else old_size = paths.Length / 3;
                if (n_paths + 1 > old_size)
                {
                    int new_size = old_size * 2;
                    if (new_size < 4) new_size = 4;
                    Array.Resize<float>(ref paths, new_size * 3);
                }

                int off = n_paths * 3;
                paths[off] = x;
                paths[off + 1] = y;
                paths[off + 2] = z;
                n_paths++;
                if (chunk != null) chunk.modified = true;
            }

            public void RemovePathTo(Location l)
            {
                RemovePathTo(l.X, l.Y, l.Z);
            }

            public void RemovePathTo(float x, float y, float z)
            {
                // look for it
                int found_index = -1;
                for (int i = 0; i < n_paths && found_index == -1; i++)
                {
                    int off = i * 3;
                    if (paths[off] == x &&
                       paths[off + 1] == y &&
                       paths[off + 2] == z)
                    {
                        found_index = i;
                    }
                }
                if (found_index != -1)
                {
                    GContext.Main.Log("Remove path (" + found_index + ") to " + x + " " + y + " " + n_paths);
                    for (int i = found_index; i < n_paths - 1; i++)
                    {
                        int off = i * 3;
                        paths[off] = paths[off + 3];
                        paths[off + 1] = paths[off + 4];
                        paths[off + 2] = paths[off + 5];
                    }
                    n_paths--;
                    if (chunk != null) chunk.modified = true;
                }
                else
                {
                    GContext.Main.Log("Found not path to remove (" + found_index + ") to " + x + " " + y + " ");

                }
            }

            // search stuff

            public bool SetSearchID(int id)
            {
                if (searchID != id)
                {
                    closed = false;
                    scoreSet = false;
                    searchID = id;
                    return true;
                }
                return false;
            }

            public bool SearchIsClosed(int id)
            {
                if (id == searchID) return closed;
                return false;
            }

            public void SearchClose(int id)
            {
                SetSearchID(id);
                closed = true;
            }

            public bool SearchScoreIsSet(int id)
            {
                if (id == searchID) return scoreSet;
                return false;
            }

            public float SearchScoreGet(int id)
            {
                return score;
            }

            public void SearchScoreSet(int id, float score)
            {
                SetSearchID(id);
                this.score = score;
                scoreSet = true;
            }
        }

        class SpotData<T>
        {
            Dictionary<Spot, T> data = new Dictionary<Spot, T>();

            public T Get(Spot s)
            {
                T t = default(T);
                data.TryGetValue(s, out t);
                return t;
            }

            public void Set(Spot s, T t)
            {
                if (data.ContainsKey(s))
                    data.Remove(s);
                data.Add(s, t);
            }

            public bool IsSet(Spot s)
            {
                return data.ContainsKey(s);
            }

        }

        public class Path
        {
            List<Location> locations = new List<Location>();

            public Path()
            {
            }

            public Path(List<Spot> steps)
            {
                foreach (Spot s in steps)
                {
                    AddLast(s.location);
                }
            }

            public int Count()
            {
                return locations.Count;
            }

            public Location GetFirst()
            {
                return Get(0);

            }
            public Location GetSecond()
            {
                if (locations.Count > 1)
                    return Get(1);
                return null;
            }

            public Location GetLast()
            {
                return locations[locations.Count - 1];
            }

            public Location RemoveFirst()
            {
                Location l = Get(0);
                locations.RemoveAt(0);
                return l;
            }

            public Location Get(int index)
            {
                return locations[index];
            }

            public void AddFirst(Location l)
            {
                locations.Insert(0, l);
            }

            public void AddFirst(Path l)
            {
                locations.InsertRange(0, l.locations);
            }

            public void AddLast(Location l)
            {
                locations.Add(l);
            }


            public void AddLast(Path l)
            {
                locations.AddRange(l.locations);
            }
        }

        public interface ILocationHeuristics
        {
          float Score(float x, float y, float z); 
        }

        public class PathGraph
        {
            public const float toonHeight = 2.0f;
            public const float toonSize = 0.5f;


            public const float MinStepLength = 2f;
            public const float WantedStepLength = 3f;
            public const float MaxStepLength = 5f;

            public const float CHUNK_BASE = 100000.0f; // Always keep positive
            string BaseDir = "pathing2";
            string Continent;
            SparseMatrix2D<GraphChunk> chunks;


    public ChunkedTriangleCollection triangleWorld;
            public TriangleCollection paint;

            List<GraphChunk> ActiveChunks = new List<GraphChunk>();
            long LRU = 0;


            public PathGraph(string continent,
                             ChunkedTriangleCollection triangles,
                             TriangleCollection paint)
            {
                this.Continent = continent;
                this.triangleWorld = triangles;
                this.paint = paint;
                Clear();
            }

            public void Close()
            {
                triangleWorld.Close();
            }

            public void Clear()
            {
                chunks = new SparseMatrix2D<GraphChunk>(8);
            }

            private void GetChunkCoord(float x, float y, out int ix, out int iy)
            {
                ix = (int)((CHUNK_BASE + x) / GraphChunk.CHUNK_SIZE);
                iy = (int)((CHUNK_BASE + y) / GraphChunk.CHUNK_SIZE);
            }

            private void GetChunkBase(int ix, int iy, out float bx, out float by)
            {
                bx = (float)ix * GraphChunk.CHUNK_SIZE - CHUNK_BASE;
                by = (float)iy * GraphChunk.CHUNK_SIZE - CHUNK_BASE;
            }

            private GraphChunk GetChunkAt(float x, float y)
            {
                int ix, iy;
                GetChunkCoord(x, y, out ix, out iy);
                GraphChunk c = chunks.Get(ix, iy);
                if (c != null) c.LRU = LRU++;
                return c;
            }

            private void CheckForChunkEvict()
            {
                lock(this)
                {
                    if (ActiveChunks.Count < 25) return;
                    
                    GraphChunk evict = null;
                    foreach (GraphChunk gc in ActiveChunks)
                    {
                        if (evict == null || gc.LRU < evict.LRU)
                        {
                            evict = gc;
                        }
                    }
                    
                    // It is full!
                    evict.Save(BaseDir + "\\" + Continent + "\\");
                    ActiveChunks.Remove(evict);
                    chunks.Clear(evict.ix, evict.iy);
                    evict.Clear();
                }
            }



            public void Save()
            {
                lock(this)
                {
                    ICollection<GraphChunk> l = chunks.GetAllElements();
                    foreach (GraphChunk gc in l)
                    {
                        if (gc.modified)
                        {
                            gc.Save(BaseDir + "\\" + Continent + "\\");
                        }
                    }
                }
            }

            // Create and load from file if exisiting
            private void LoadChunk(float x, float y)
            {
                GraphChunk gc = GetChunkAt(x, y);
                if (gc == null)
                {
                    int ix, iy;
                    GetChunkCoord(x, y, out ix, out iy);

                    float base_x, base_y;
                    GetChunkBase(ix, iy, out base_x, out base_y);

                    gc = new GraphChunk(base_x, base_y, ix, iy);
                    gc.LRU = LRU++;


                    CheckForChunkEvict();

                    gc.Load(BaseDir + "\\" + Continent + "\\");
                    chunks.Set(ix, iy, gc);
                    ActiveChunks.Add(gc);

                }
            }

            public Spot AddSpot(Spot s)
            {
                LoadChunk(s.X, s.Y);
                GraphChunk gc = GetChunkAt(s.X, s.Y);
                return gc.AddSpot(s);
            }

            // Connect according to MPQ data
            public Spot AddAndConnectSpot(Spot s)
            {
                s = AddSpot(s);
                List<Spot> close = FindAllSpots(s.location, MaxStepLength);
                if (!s.GetFlag(Spot.FLAG_MPQ_MAPPED))
                {

                    foreach (Spot cs in close)
                    {
                        if (cs.HasPathTo(this, s) && s.HasPathTo(this, cs) ||
                            cs.IsBlocked())
                        {
                        }
                        else if (!triangleWorld.IsStepBlocked(s.X, s.Y, s.Z, cs.X, cs.Y, cs.Z,
                                                         toonHeight, toonSize, null))
                        {
                            float mid_x = (s.X + cs.X) / 2;
                            float mid_y = (s.Y + cs.Y) / 2;
                            float mid_z = (s.Z + cs.Z) / 2;
                            float stand_z;
                            int flags;
                            if (triangleWorld.FindStandableAt(mid_x, mid_y,
                                                              mid_z - WantedStepLength * .75f, mid_z + WantedStepLength * .75f,
                                                              out stand_z, out flags, toonHeight, toonSize))
                            {
                                s.AddPathTo(cs);
                                cs.AddPathTo(s);
                            }
                        }
                    }
                }
                return s;
            }

            public Spot GetSpot(float x, float y, float z)
            {
                LoadChunk(x, y);
                GraphChunk gc = GetChunkAt(x, y);
                return gc.GetSpot(x, y, z);
            }

            public Spot GetSpot2D(float x, float y)
            {
                LoadChunk(x, y);
                GraphChunk gc = GetChunkAt(x, y);
                return gc.GetSpot2D(x, y);
            }

            public Spot GetSpot(Location l)
            {
                if (l == null) return null;
                return GetSpot(l.X, l.Y, l.Z);
            }



            // this can be slow...

            public Spot FindClosestSpot(Location l_d)
            {
                return FindClosestSpot(l_d, 30.0f, null);
            }

            public Spot FindClosestSpot(Location l_d, Set<Spot> Not)
            {
                return FindClosestSpot(l_d, 30.0f, Not);
            }


            public Spot FindClosestSpot(Location l, float max_d)
            {
                return FindClosestSpot(l, max_d, null);
            }

            // this can be slow...
            public Spot FindClosestSpot(Location l, float max_d, Set<Spot> Not)
            {
                Spot closest = null;
                float closest_d = 1E30f;
                int d = 0;
                while ((float)d <= max_d + 0.1f)
                {
                    for (int i = -d; i <= d; i++)
                    {
                        float x_up = l.X + (float)d;
                        float x_dn = l.X - (float)d;
                        float y_up = l.Y + (float)d;
                        float y_dn = l.Y - (float)d;

                        Spot s0 = GetSpot2D(x_up, l.Y + i);
                        Spot s2 = GetSpot2D(x_dn, l.Y + i);

                        Spot s1 = GetSpot2D(l.X + i, y_dn);
                        Spot s3 = GetSpot2D(l.X + i, y_up);
                        Spot[] sv = { s0, s1, s2, s3 };
                        foreach (Spot s in sv)
                        {
                            Spot ss = s;
                            while (ss != null)
                            {
                                float di = ss.GetDistanceTo(l);
                                if (di < max_d && !ss.IsBlocked() &&
                                    (di < closest_d))
                                {
                                    closest = ss;
                                    closest_d = di;
                                }
                                ss = ss.next;
                            }
                        }
                    }

                    if (closest_d < d) // can't get better
                    {
                        //Log("Closest2 spot to " + l + " is " + closest);
                        return closest;
                    }
                    d++;
                }
                //Log("Closest1 spot to " + l + " is " + closest);
                return closest;
            }

            public List<Spot> FindAllSpots(Location l, float max_d)
            {
                List<Spot> sl = new List<Spot>();

                int d = 0;
                while ((float)d <= max_d + 0.1f)
                {
                    for (int i = -d; i <= d; i++)
                    {
                        float x_up = l.X + (float)d;
                        float x_dn = l.X - (float)d;
                        float y_up = l.Y + (float)d;
                        float y_dn = l.Y - (float)d;

                        Spot s0 = GetSpot2D(x_up, l.Y + i);
                        Spot s2 = GetSpot2D(x_dn, l.Y + i);

                        Spot s1 = GetSpot2D(l.X + i, y_dn);
                        Spot s3 = GetSpot2D(l.X + i, y_up);
                        Spot[] sv = { s0, s1, s2, s3 };
                        foreach (Spot s in sv)
                        {
                            Spot ss = s;
                            while (ss != null)
                            {
                                float di = ss.GetDistanceTo(l);
                                if (di < max_d)
                                {
                                    sl.Add(ss);
                                }
                                ss = ss.next;
                            }
                        }
                    }
                    d++;
                }
                return sl;
            }

            public List<Spot> FindAllSpots(float min_x, float min_y, float max_x, float max_y)
            {
                // hmm, do it per chunk
                List<Spot> l = new List<Spot>();
                for (float mx = min_x; mx <= max_x + GraphChunk.CHUNK_SIZE - 1; mx += GraphChunk.CHUNK_SIZE)
                {
                    for (float my = min_y; my <= max_y + GraphChunk.CHUNK_SIZE - 1; my += GraphChunk.CHUNK_SIZE)
                    {
                        LoadChunk(mx, my);
                        GraphChunk gc = GetChunkAt(mx, my);
                        List<Spot> sl = gc.GetAllSpots();
                        foreach (Spot s in sl)
                        {
                            if (s.X >= min_x && s.X <= max_x &&
                               s.Y >= min_y && s.Y <= max_y)
                            {
                                l.Add(s);
                            }
                        }
                    }
                }
                return l;
            }



            public Spot TryAddSpot(Spot wasAt, Location isAt)
            {
                Spot isAtSpot = FindClosestSpot(isAt, WantedStepLength);
                if (isAtSpot == null)
                {
                    isAtSpot = GetSpot(isAt);
                    if (isAtSpot == null)
                    {
                        Spot s = new Spot(isAt);
                        s = AddSpot(s);
                        isAtSpot = s;
                    }
                    if (isAtSpot.GetFlag(Spot.FLAG_BLOCKED))
                    {
                        isAtSpot.SetFlag(Spot.FLAG_BLOCKED, false);
                        Log("Cleared blocked flag");
                    }
                    if (wasAt != null)
                    {
                        wasAt.AddPathTo(isAtSpot);
                        isAtSpot.AddPathTo(wasAt);
                    }

                    List<Spot> sl = FindAllSpots(isAtSpot.location, MaxStepLength);
                    Log("Learned a new spot at " + isAtSpot.location + " connected to " + sl.Count + " other spots");
                    foreach (Spot other in sl)
                    {
                        if (other != isAtSpot)
                        {
                            other.AddPathTo(isAtSpot);
                            isAtSpot.AddPathTo(other);
                            Log("  connect to " + other.location);
                        }
                    }

                    wasAt = isAtSpot;
                }
                else
                {
                    if (wasAt != null && wasAt != isAtSpot)
                    {
                        // moved to an old spot, make sure they are connected
                        wasAt.AddPathTo(isAtSpot);
                        isAtSpot.AddPathTo(wasAt);
                    }
                    wasAt = isAtSpot;
                }

                return wasAt;
            }

            private bool LineCrosses(Location line0, Location line1, Location point)
            {
                float LineMag = line0.GetDistanceTo(line1); // Magnitude( LineEnd, LineStart );

                float U =
                    (((point.X - line0.X) * (line1.X - line0.X)) +
                      ((point.Y - line0.Y) * (line1.Y - line0.Y)) +
                      ((point.Z - line0.Z) * (line1.Z - line0.Z))) /
                    (LineMag * LineMag);

                if (U < 0.0f || U > 1.0f) return false;

                float InterX = line0.X + U * (line1.X - line0.X);
                float InterY = line0.Y + U * (line1.Y - line0.Y);
                float InterZ = line0.Z + U * (line1.Z - line0.Z);

                float Distance = point.GetDistanceTo(new Location(InterX, InterY, InterZ));
                if (Distance < 0.5f) return true;
                return false;
            }

            public void MarkBlockedAt(Location loc)
            {
                Spot s = new Spot(loc);
                s = AddSpot(s);
                s.SetFlag(Spot.FLAG_BLOCKED, true);
                // Find all paths leading though this one

                List<Spot> sl = FindAllSpots(loc, 5.0f);
                foreach (Spot sp in sl)
                {
                    List<Location> paths = sp.GetPaths();
                    foreach (Location to in paths)
                    {
                        if (LineCrosses(sp.location, to, loc))
                        {
                            sp.RemovePathTo(to);
                        }
                    }
                }

            }

            public void BlacklistStep(Location from, Location to)
            {
                Spot froms = GetSpot(from);
                if (froms != null)
                    froms.RemovePathTo(to);
            }

            public void MarkStuckAt(Location loc, float heading)
            {
                // TODO another day...
                Location inf = loc.InFrontOf(heading, 1.0f);
                MarkBlockedAt(inf);

                // TODO
            }


            //////////////////////////////////////////////////////
            // Searching
            //////////////////////////////////////////////////////



            public Path InterpolatePath(Location from, Location to)
            {
                Path p = new Path();

                //Log("Interpolate from " + from + " to " + to);
                Location prev = from;

                int maxSteps = 100; // max 100 steps
                for (int i = 0; i <= maxSteps; i++)
                {
                    float distance = prev.GetDistanceTo(to);
                    int ss = (int)(distance / WantedStepLength);
                    if (ss == 0) return p;

                    float dx = (to.X - prev.X) / (float)ss;
                    float dy = (to.Y - prev.Y) / (float)ss;
                    float dz = (to.Z - prev.Z) / (float)ss;

                    Location rover = new Location(
                        prev.X + dx,
                        prev.Y + dy,
                        prev.Z + dz);

                    Spot closest = FindClosestSpot(rover, MaxStepLength);
                    if (closest != null && closest.GetDistanceTo(rover) <= WantedStepLength)
                    {
                        // something is there
                        // TODO do something
                    }
                    prev = rover;
                    p.AddLast(rover);
                }
                return p;
            }

            public void Paint()
            {
                if (paint == null) return;
                ICollection<GraphChunk> l = chunks.GetAllElements();
                foreach (GraphChunk gc in l)
                {
                    List<Spot> spots = gc.GetAllSpots();
                    foreach (Spot s in spots)
                    {
                        PaintSpot(s);

                        for (int i = 0; i < s.n_paths; i++)
                        {
                            float x, y, z;
                            s.GetPath(i, out x, out y, out z);
                            paint.PaintPath(s.X, s.Y, s.Z, x, y, z);
                        }
                    }
                }
            }

            void PaintSpot(Spot s)
            {
                if (paint != null)
                    paint.AddMarker(s.X, s.Y, s.Z);
            }

            void PaintBigSpot(Spot s)
            {
                if (paint != null)
                    paint.AddBigMarker(s.X, s.Y, s.Z);
            }


            float TurnCost(Spot from, Spot to)
            {
                Spot prev = from.traceBack;
                if (prev == null) return 0.0f;
                return TurnCost(prev.X, prev.Y, prev.Z, from.X, from.Y, from.Z, to.X, to.Y, to.Z);

            }

            float TurnCost(float x0, float y0, float z0, float x1, float y1, float z1, float x2, float y2, float z2)
            {
                float v1x = x1 - x0;
                float v1y = y1 - y0;
                float v1z = z1 - z0;
                float v1l = (float)Math.Sqrt(v1x * v1x + v1y * v1y + v1z * v1z);
                v1x /= v1l;
                v1y /= v1l;
                v1z /= v1l;

                float v2x = x2 - x1;
                float v2y = y2 - y1;
                float v2z = z2 - z1;
                float v2l = (float)Math.Sqrt(v2x * v2x + v2y * v2y + v2z * v2z);
                v2x /= v2l;
                v2y /= v2l;
                v2z /= v2l;

                float ddx = v1x - v2x;
                float ddy = v1y - v2y;
                float ddz = v1z - v2z;
                return (float)Math.Sqrt(ddx * ddx + ddy * ddy + ddz * ddz);
            }

            // return null if failed or the last spot in the path found

            int searchID = 0;
            private Spot search(Spot src, Spot dst,
                                Location realDst,
                                float minHowClose, bool AllowInvented, 
                                ILocationHeuristics locationHeuristics)
            {
                searchID++;
                int count = 0;
                int prevCount = 0;
                int currentSearchID = searchID;
                float heuristicsFactor = 1.3f;
                System.DateTime pre = System.DateTime.Now;
                System.DateTime lastSpam = pre;

                // lowest first queue
                PriorityQueue<Spot, float> q = new PriorityQueue<Spot, float>(); // (new SpotSearchComparer(dst, score)); ;
                q.Enqueue(src, -src.GetDistanceTo(dst) * heuristicsFactor);
                Spot BestSpot = null;

                //Set<Spot> closed      = new Set<Spot>();
                //SpotData<float> score = new SpotData<float>();

                src.SearchScoreSet(currentSearchID, 0.0f);
                src.traceBack = null;

                // A* -ish algorithm

                while (q.Count != 0) // && count < 100000)
                {
                    float prio;
                    Spot spot = q.Dequeue(out prio); // .Value; 
                    //q.Remove(spot);


                    if (spot.SearchIsClosed(currentSearchID)) continue;
                    spot.SearchClose(currentSearchID);

                    if (count % 100 == 0)
                    {
                        System.TimeSpan span = System.DateTime.Now.Subtract(lastSpam);
                        if (span.Seconds != 0 && BestSpot != null)
                        {
                            Thread.Sleep(50); // give glider a chance to stop us
                            int t = span.Seconds * 1000 + span.Milliseconds;
                            if (t == 0)
                                Log("searching.... " + (count + 1) + " d: " + BestSpot.location.GetDistanceTo(realDst));
                            else
                                Log("searching.... " + (count + 1) + " d: " + BestSpot.location.GetDistanceTo(realDst) + " " + (count - prevCount) * 1000 / t + " steps/s");
                            lastSpam = System.DateTime.Now;
                            prevCount = count;
                        }
                    }
                    count++;


                    if (spot.Equals(dst) || spot.location.GetDistanceTo(realDst) < minHowClose)
                    {
                        System.TimeSpan ts = System.DateTime.Now.Subtract(pre);
                        int t = ts.Seconds * 1000 + ts.Milliseconds;
                        /*if(t == 0)
                            Log("  search found the way there. " + count); 
                        else
                            Log("  search found the way there. " + count + " " + (count * 1000) / t + " steps/s");
                          */
                        return spot; // got there
                    }

                    if (BestSpot == null ||
                       spot.location.GetDistanceTo(realDst) < BestSpot.location.GetDistanceTo(realDst))
                    {
                        BestSpot = spot;
                    }
                    {
                        System.TimeSpan ts = System.DateTime.Now.Subtract(pre);
                        if (ts.Seconds > 15)
                        {
                            Log("too long search, aborting");
                            break;
                        }
                    }

                    float src_score = spot.SearchScoreGet(currentSearchID);

                    //GContext.Main.Log("inspect: " + c + " score " + s);


                    int new_found = 0;
                    List<Spot> ll = spot.GetPathsToSpots(this);
                    foreach (Spot to in ll)
                    {
                        //Spot to = GetSpot(l);

                        if (to != null && !to.IsBlocked() && !to.SearchIsClosed(currentSearchID))
                        {
                            float old_score = 1E30f;

                            float new_score = src_score + spot.GetDistanceTo(to) + TurnCost(spot, to);
                            if(locationHeuristics != null)
                              new_score += locationHeuristics.Score(spot.X, spot.Y, spot.Z);
                            if (to.GetFlag(Spot.FLAG_WATER))
                                new_score += 30;

                            if (to.SearchScoreIsSet(currentSearchID))
                            {
                                old_score = to.SearchScoreGet(currentSearchID);
                            }

                            if (new_score < old_score)
                            {
                                // shorter path to here found
                                to.traceBack = spot;
                                //if (q.Contains(to)) 
                                //   q.Remove(to); // very sloppy to not dequeue it
                                to.SearchScoreSet(currentSearchID, new_score);
                                q.Enqueue(to, -(new_score + to.GetDistanceTo(dst) * heuristicsFactor));
                                new_found++;
                            }
                        }
                    }

                    //hmm search the triangles :p
                    if (!spot.GetFlag(Spot.FLAG_MPQ_MAPPED))
                    {

                        float PI = (float)Math.PI;

                        spot.SetFlag(Spot.FLAG_MPQ_MAPPED, true);
                        for (float a = 0; a < PI * 2; a += PI / 8)
                        {
                            float nx = spot.X + (float)Math.Sin(a) * WantedStepLength;// *0.8f;
                            float ny = spot.Y + (float)Math.Cos(a) * WantedStepLength;// *0.8f;
                            Spot s = GetSpot(nx, ny, spot.Z);
                            if (s == null)
                                s = FindClosestSpot(new Location(nx, ny, spot.Z), MinStepLength); // TODO: this is slow
                            if (s != null)
                            {

                            }
                            else
                            {
                                float new_z;
                                int flags;
                                // gogo find a new one
                                //GContext.Main.Log("gogo brave new world");
                                if (!triangleWorld.FindStandableAt(nx, ny,
                                                                   spot.Z - WantedStepLength * .75f, spot.Z + WantedStepLength * .75f,
                                                                   out new_z, out flags, toonHeight, toonSize))
                                {
                                    Spot blocked = new Spot(nx, ny, spot.Z);
                                    blocked.SetFlag(Spot.FLAG_BLOCKED, true);
                                    AddSpot(blocked);
                                }
                                else
                                {
                                    s = FindClosestSpot(new Location(nx, ny, new_z), MinStepLength);
                                    if (s == null)
                                    {
                                        if (!triangleWorld.IsStepBlocked(spot.X, spot.Y, spot.Z,nx,ny,new_z,
                                                                         toonHeight, toonSize, null))
                                        {

                                        Spot n = new Spot(nx, ny, new_z);
                                        Spot to = AddAndConnectSpot(n);
                                        if ((flags & ChunkedTriangleCollection.TriangleFlagDeepWater) != 0)
                                        {
                                            to.SetFlag(Spot.FLAG_WATER, true);
                                        }
                                        if (to != n || to.SearchIsClosed(currentSearchID))
                                        {
                                            // GContext.Main.Log("/sigh");
                                        }
                                        else
                                        {
                                            // There should be a path from source to this one now
                                            if (spot.HasPathTo(to.location))
                                            {
                                                float old_score = 1E30f;

                                                float new_score = src_score + spot.GetDistanceTo(to) + TurnCost(spot, to);
                                                if(locationHeuristics != null)
                                                  new_score += locationHeuristics.Score(spot.X, spot.Y, spot.Z);


                                                if (to.GetFlag(Spot.FLAG_WATER))
                                                    new_score += 30;

                                                if (to.SearchScoreIsSet(currentSearchID))
                                                {
                                                    old_score = to.SearchScoreGet(currentSearchID);
                                                }

                                                if (new_score < old_score)
                                                {
                                                    // shorter path to here found
                                                    to.traceBack = spot;
                                                    //if (q.Contains(to)) 
                                                    //    q.Remove(to);
                                                    to.SearchScoreSet(currentSearchID, new_score);
                                                    q.Enqueue(to, -(new_score + to.GetDistanceTo(dst) * heuristicsFactor));
                                                    new_found++;
                                                }
                                            }
                                            else
                                            {
                                                // woot! I added a new one and it is not connected!?!?
                                                //GContext.Main.Log("/cry");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        }

                    }

                }
                {
                    System.TimeSpan ts = System.DateTime.Now.Subtract(pre);
                    int t = ts.Seconds * 1000 + ts.Milliseconds; if (t == 0) t = 1;
                    Log("  search failed. " + (count * 1000) / t + " steps/s");
                    PaintBigSpot(BestSpot);
                }
                return BestSpot; // :(
            }


            private List<Spot> FollowTraceBack(Spot from, Spot to)
            {
                List<Spot> path = new List<Spot>();
                int count = 0;

                Spot r = to;
                path.Insert(0, to); // add last
                while (r != null)
                {
                    Spot s = r.traceBack;

                    if (s != null)
                    {
                        path.Insert(0, s); // add first
                        r = s;
                        if (r == from) r = null;  // fount source
                    }
                    else
                        r = null;
                    count++;
                }
                path.Insert(0, from); // add first
                return path;

            }

            public bool IsUnderwaterOrInAir(Location l)
            {
                int flags;
                float z;
                if (triangleWorld.FindStandableAt(l.X, l.Y, l.Z - 50.0f, l.Z + 5.0f, out z, out  flags, toonHeight, toonSize))
                {
                    if ((flags & ChunkedTriangleCollection.TriangleFlagDeepWater) != 0) 
                      return true; 
                    else
                        return false;
                }
                //return true; 
                return false;
            }

            public Path CreatePath(Spot from, Spot to, Location realDst,
                                   float minHowClose, bool AllowInvented, 
                                   ILocationHeuristics locationHeuristics)
            {

                Spot newTo = search(from, to, realDst, minHowClose, AllowInvented, 
                                    locationHeuristics);
                if (newTo != null)
                {
                    if (newTo.GetDistanceTo(to) <= minHowClose)
                    {
                        List<Spot> path = FollowTraceBack(from, newTo);
                        return new Path(path);
                    }
                }
                return null;
            }

            public Path CreatePath(Location fromLoc, Location toLoc,
                                   float howClose)
            {
                return CreatePath(fromLoc, toLoc, howClose, null);
            }

            public Path CreatePath(Location fromLoc, Location toLoc,
                                   float howClose, 
                                   ILocationHeuristics locationHeuristics)
            {
                GSpellTimer t = new GSpellTimer(0);
                Spot from = FindClosestSpot(fromLoc, MinStepLength);
                Spot to = FindClosestSpot(toLoc, MinStepLength);

                if (from == null)
                {
                    from = AddAndConnectSpot(new Spot(fromLoc));
                }
                if (to == null)
                {
                    to = AddAndConnectSpot(new Spot(toLoc));
                }

                Path rawPath = CreatePath(from, to, to.location, howClose, true, locationHeuristics);


                if (rawPath != null && paint != null)
                {
                    Location prev = null;
                    for (int i = 0; i < rawPath.Count(); i++)
                    {
                        Location l = rawPath.Get(i);
                        paint.AddBigMarker(l.X, l.Y, l.Z);
                        if (prev != null)
                        {
                            paint.PaintPath(l.X, l.Y, l.Z + 3, prev.X, prev.Y, prev.Z + 3);
                        }
                        prev = l;
                    }
                }
                GContext.Main.Log("CreatePath took " + -t.TicksLeft);
                if (rawPath == null)
                {
                    return null;
                }
                else
                {
                    Location last = rawPath.GetLast();
                    if(last.GetDistanceTo(toLoc) > 1.0)
                        rawPath.AddLast(toLoc);
                }
                return rawPath;
            }

            private void Log(String s)
            {
                //Console.WriteLine(s); 
                GContext.Main.Log(s);
            }
        }
        #endregion

    #region PatherForm
        public class PatherForm : Form
        {
            private PPather pather;
            TreeNode rootNode = null;

            public PatherForm(PPather pather)
            {
                this.pather = pather;
                InitializeComponent();
            }


            private TreeNode CreateNodeFromTask(Task task)
            {
                Task[] children = task.GetChildren();
                TreeNode[] childNodes = null;
                if (children != null)
                {
                    childNodes = new TreeNode[children.Length];
                    for (int i = 0; i < children.Length; i++)
                    {
                        childNodes[i] = CreateNodeFromTask(children[i]);
                    }
                }

                TreeNode n;
                if (childNodes != null)
                    n = new TreeNode(task.ToString(), childNodes);
                else
                    n = new TreeNode(task.ToString());
                n.Tag = task;
                return n;
            }

            private Color white = System.Drawing.Color.FromArgb(255, 255, 255);
            private Color yellow = System.Drawing.Color.FromArgb(255, 255, 128);
            private Color red = System.Drawing.Color.FromArgb(255, 128, 128);
            private Color green = System.Drawing.Color.FromArgb(128, 255, 128);
            private Color blue = System.Drawing.Color.FromArgb(155, 165, 255);

            private void UpdateTreeNodeStatus(TreeNode n)
            {
                Task t = (Task)n.Tag;

                if (t != null)
                {
                    Task.State_e state = t.State;
                    if (state == Task.State_e.Idle)
                        n.BackColor = white;
                    else if (state == Task.State_e.Done)
                        n.BackColor = blue;
                    else if (state == Task.State_e.Active)
                        n.BackColor = green;
                    else if (state == Task.State_e.Want)
                        n.BackColor = yellow;

                }

                TreeNode child = n.FirstNode;
                while (child != null)
                {
                    UpdateTreeNodeStatus(child);
                    child = child.NextNode;
                }
            }

            public void CreateTreeFromTasks(Task rootTask)
            {
                rootNode = CreateNodeFromTask(rootTask);
            }

            public void SetStatus(int kills, int KPh, int loots, int XPh, int harvests, int ttl, int deaths)
            {
                lbl_kills.Text = "" + kills + ",  " + KPh + "K/h";
                lbl_loots.Text = "" + loots;
                lbl_XPh.Text = "" + XPh;
                lbl_harvest.Text = "" + harvests;
                int mins = ttl % 60;
                int hs = (ttl - mins) / 60;
                lbl_ttl.Text = "" + hs + "h " + mins + "m";
                lbl_deaths.Text = "" + deaths;
            }


            public void SetTarget(GUnit target)
            {
                if (target == null)
                {
                    lbl_name.Text = "";
                    lbl_reaction.Text = "";
                    lbl_level.Text = "";
                    lbl_faction.Text = "";
                }
                else
                {
                    lbl_name.Text = target.Name;
                    lbl_reaction.Text = target.Reaction.ToString();
                    string lvl = target.Level.ToString();
                    if (target.IsMonster)
                    {
                        GMonster m = (GMonster)target;
                        if (m.IsElite) lvl += "elite";
                    }
                    lbl_level.Text = lvl;
                    lbl_faction.Text = target.FactionID.ToString();
                }
            }


            public void SetActivity(Activity activity)
            {
                if (activity == null)
                {
                    lbl_activity.Text = "";
                }
                else
                {
                    lbl_activity.Text = activity.ToString();
                }
            }

            private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
                TreeNode n = e.Node;
                lb_defs.Items.Clear();
                lb_params.Items.Clear();
                if (n == null) return;
                Task t = (Task)n.Tag;
                if (t == null)
                {

                }
                else
                {
                    if (!t.IsParserTask())
                    {

                    }
                    else
                    {
                        //GContext.Main.Log("marked a task " + t);
                        ParserTask pt = (ParserTask)t;
                        List<string> parms = new List<string>();
                        pt.GetParams(parms);
                        NodeTask tn = pt.nodetask;

                        foreach (string par in parms)
                        {
                            Value v = tn.GetValueOfId(par);
                            string val = "undefined";
                            if (v != null) val = v.GetStringValue();
                            lb_params.Items.Add(par + " = " + val);
                        }

                    }
                }
            }

            private void btn_go_Click(object sender, EventArgs e)
            {
                pather.WantedState = PPather.RunState_e.Running;
            }

            private void btn_pause_Click(object sender, EventArgs e)
            {
                pather.WantedState = PPather.RunState_e.Paused;
            }

            private void btn_stop_Click(object sender, EventArgs e)
            {
                pather.WantedState = PPather.RunState_e.Stopped;
            }

            private GSpellTimer npc_update = new GSpellTimer(3000);

            private void timer1_Tick(object sender, EventArgs e)
            {
                if (GContext.Main != null && GContext.Main.Me != null && GContext.Main.Me.IsValid)
                {
                    GUnit target = GContext.Main.Me.Target;
                    SetTarget(target);
                    if (npc_update.IsReady)
                    {
                        pather.UpdateNPCs();
                        npc_update.Reset();
                    }
                }
                if (pather.RunState != pather.WantedState)
                {
                    lbl_state.Text = pather.RunState.ToString() + " (" + pather.WantedState.ToString() + ")";
                }
                else
                {
                    lbl_state.Text = pather.RunState.ToString();
                }
                if (GContext.Main.CurrentMode == GGlideMode.Glide)
                {
                    if (rootNode != null)
                    {
                        treeView1.Nodes.Clear();
                        treeView1.Nodes.Add(rootNode);
                        rootNode = null;
                    }

                    foreach (TreeNode n in treeView1.Nodes)
                    {
                        UpdateTreeNodeStatus(n);
                    }
                }
            }

            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

    #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.label1 = new System.Windows.Forms.Label();
                this.lbl_name = new System.Windows.Forms.Label();
                this.label3 = new System.Windows.Forms.Label();
                this.lbl_reaction = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.lbl_level = new System.Windows.Forms.Label();
                this.lbl_faction = new System.Windows.Forms.Label();
                this.label12 = new System.Windows.Forms.Label();
                this.grpBox = new System.Windows.Forms.GroupBox();
                this.groupBox2 = new System.Windows.Forms.GroupBox();
                this.lbl_deaths = new System.Windows.Forms.Label();
                this.label16 = new System.Windows.Forms.Label();
                this.lbl_ttl = new System.Windows.Forms.Label();
                this.label18 = new System.Windows.Forms.Label();
                this.lbl_harvest = new System.Windows.Forms.Label();
                this.label14 = new System.Windows.Forms.Label();
                this.lbl_XPh = new System.Windows.Forms.Label();
                this.label11 = new System.Windows.Forms.Label();
                this.lbl_loots = new System.Windows.Forms.Label();
                this.label8 = new System.Windows.Forms.Label();
                this.lbl_kills = new System.Windows.Forms.Label();
                this.label6 = new System.Windows.Forms.Label();
                this.treeView1 = new System.Windows.Forms.TreeView();
                this.timer1 = new System.Windows.Forms.Timer(this.components);
                this.btn_pause = new System.Windows.Forms.Button();
                this.btn_go = new System.Windows.Forms.Button();
                this.btn_stop = new System.Windows.Forms.Button();
                this.lb_params = new System.Windows.Forms.ListBox();
                this.label4 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.lb_defs = new System.Windows.Forms.ListBox();
                this.label10 = new System.Windows.Forms.Label();
                this.label2 = new System.Windows.Forms.Label();
                this.lbl_activity = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.lbl_state = new System.Windows.Forms.Label();
                this.grpBox.SuspendLayout();
                this.groupBox2.SuspendLayout();
                this.SuspendLayout();
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.BackColor = System.Drawing.SystemColors.Control;
                this.label1.Location = new System.Drawing.Point(9, 16);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(35, 13);
                this.label1.TabIndex = 0;
                this.label1.Text = "Name";
                // 
                // lbl_name
                // 
                this.lbl_name.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_name.Location = new System.Drawing.Point(50, 16);
                this.lbl_name.Name = "lbl_name";
                this.lbl_name.Size = new System.Drawing.Size(197, 13);
                this.lbl_name.TabIndex = 1;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.BackColor = System.Drawing.SystemColors.Control;
                this.label3.Location = new System.Drawing.Point(9, 29);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(44, 13);
                this.label3.TabIndex = 2;
                this.label3.Text = "Rection";
                // 
                // lbl_reaction
                // 
                this.lbl_reaction.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_reaction.Location = new System.Drawing.Point(50, 29);
                this.lbl_reaction.Name = "lbl_reaction";
                this.lbl_reaction.Size = new System.Drawing.Size(91, 13);
                this.lbl_reaction.TabIndex = 3;
                // 
                // label9
                // 
                this.label9.AutoSize = true;
                this.label9.BackColor = System.Drawing.SystemColors.Control;
                this.label9.Location = new System.Drawing.Point(144, 29);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(33, 13);
                this.label9.TabIndex = 8;
                this.label9.Text = "Level";
                // 
                // lbl_level
                // 
                this.lbl_level.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_level.Location = new System.Drawing.Point(183, 29);
                this.lbl_level.Name = "lbl_level";
                this.lbl_level.Size = new System.Drawing.Size(64, 13);
                this.lbl_level.TabIndex = 9;
                // 
                // lbl_faction
                // 
                this.lbl_faction.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_faction.Location = new System.Drawing.Point(50, 42);
                this.lbl_faction.Name = "lbl_faction";
                this.lbl_faction.Size = new System.Drawing.Size(91, 13);
                this.lbl_faction.TabIndex = 11;
                // 
                // label12
                // 
                this.label12.AutoSize = true;
                this.label12.BackColor = System.Drawing.SystemColors.Control;
                this.label12.Location = new System.Drawing.Point(9, 42);
                this.label12.Name = "label12";
                this.label12.Size = new System.Drawing.Size(42, 13);
                this.label12.TabIndex = 10;
                this.label12.Text = "Faction";
                // 
                // grpBox
                // 
                this.grpBox.Controls.Add(this.label1);
                this.grpBox.Controls.Add(this.lbl_name);
                this.grpBox.Controls.Add(this.lbl_reaction);
                this.grpBox.Controls.Add(this.lbl_level);
                this.grpBox.Controls.Add(this.lbl_faction);
                this.grpBox.Controls.Add(this.label12);
                this.grpBox.Controls.Add(this.label3);
                this.grpBox.Controls.Add(this.label9);
                this.grpBox.Location = new System.Drawing.Point(12, 74);
                this.grpBox.Name = "grpBox";
                this.grpBox.Size = new System.Drawing.Size(265, 65);
                this.grpBox.TabIndex = 15;
                this.grpBox.TabStop = false;
                this.grpBox.Text = "Target";
                // 
                // groupBox2
                // 
                this.groupBox2.Controls.Add(this.lbl_deaths);
                this.groupBox2.Controls.Add(this.label16);
                this.groupBox2.Controls.Add(this.lbl_ttl);
                this.groupBox2.Controls.Add(this.label18);
                this.groupBox2.Controls.Add(this.lbl_harvest);
                this.groupBox2.Controls.Add(this.label14);
                this.groupBox2.Controls.Add(this.lbl_XPh);
                this.groupBox2.Controls.Add(this.label11);
                this.groupBox2.Controls.Add(this.lbl_loots);
                this.groupBox2.Controls.Add(this.label8);
                this.groupBox2.Controls.Add(this.lbl_kills);
                this.groupBox2.Controls.Add(this.label6);
                this.groupBox2.Location = new System.Drawing.Point(12, 6);
                this.groupBox2.Name = "groupBox2";
                this.groupBox2.Size = new System.Drawing.Size(265, 62);
                this.groupBox2.TabIndex = 17;
                this.groupBox2.TabStop = false;
                this.groupBox2.Text = "Status";
                // 
                // lbl_deaths
                // 
                this.lbl_deaths.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_deaths.Location = new System.Drawing.Point(173, 42);
                this.lbl_deaths.Name = "lbl_deaths";
                this.lbl_deaths.Size = new System.Drawing.Size(74, 13);
                this.lbl_deaths.TabIndex = 26;
                // 
                // label16
                // 
                this.label16.AutoSize = true;
                this.label16.BackColor = System.Drawing.SystemColors.Control;
                this.label16.Location = new System.Drawing.Point(132, 42);
                this.label16.Name = "label16";
                this.label16.Size = new System.Drawing.Size(41, 13);
                this.label16.TabIndex = 25;
                this.label16.Text = "Deaths";
                // 
                // lbl_ttl
                // 
                this.lbl_ttl.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_ttl.Location = new System.Drawing.Point(50, 42);
                this.lbl_ttl.Name = "lbl_ttl";
                this.lbl_ttl.Size = new System.Drawing.Size(74, 13);
                this.lbl_ttl.TabIndex = 24;
                // 
                // label18
                // 
                this.label18.AutoSize = true;
                this.label18.BackColor = System.Drawing.SystemColors.Control;
                this.label18.Location = new System.Drawing.Point(9, 42);
                this.label18.Name = "label18";
                this.label18.Size = new System.Drawing.Size(27, 13);
                this.label18.TabIndex = 23;
                this.label18.Text = "TTL";
                // 
                // lbl_harvest
                // 
                this.lbl_harvest.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_harvest.Location = new System.Drawing.Point(173, 29);
                this.lbl_harvest.Name = "lbl_harvest";
                this.lbl_harvest.Size = new System.Drawing.Size(74, 13);
                this.lbl_harvest.TabIndex = 22;
                // 
                // label14
                // 
                this.label14.AutoSize = true;
                this.label14.BackColor = System.Drawing.SystemColors.Control;
                this.label14.Location = new System.Drawing.Point(132, 29);
                this.label14.Name = "label14";
                this.label14.Size = new System.Drawing.Size(44, 13);
                this.label14.TabIndex = 21;
                this.label14.Text = "Harvest";
                // 
                // lbl_XPh
                // 
                this.lbl_XPh.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_XPh.Location = new System.Drawing.Point(50, 29);
                this.lbl_XPh.Name = "lbl_XPh";
                this.lbl_XPh.Size = new System.Drawing.Size(74, 13);
                this.lbl_XPh.TabIndex = 20;
                // 
                // label11
                // 
                this.label11.AutoSize = true;
                this.label11.BackColor = System.Drawing.SystemColors.Control;
                this.label11.Location = new System.Drawing.Point(9, 29);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(32, 13);
                this.label11.TabIndex = 19;
                this.label11.Text = "XP/h";
                // 
                // lbl_loots
                // 
                this.lbl_loots.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_loots.Location = new System.Drawing.Point(173, 16);
                this.lbl_loots.Name = "lbl_loots";
                this.lbl_loots.Size = new System.Drawing.Size(74, 13);
                this.lbl_loots.TabIndex = 18;
                // 
                // label8
                // 
                this.label8.AutoSize = true;
                this.label8.BackColor = System.Drawing.SystemColors.Control;
                this.label8.Location = new System.Drawing.Point(132, 16);
                this.label8.Name = "label8";
                this.label8.Size = new System.Drawing.Size(33, 13);
                this.label8.TabIndex = 17;
                this.label8.Text = "Loots";
                // 
                // lbl_kills
                // 
                this.lbl_kills.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_kills.Location = new System.Drawing.Point(50, 16);
                this.lbl_kills.Name = "lbl_kills";
                this.lbl_kills.Size = new System.Drawing.Size(74, 13);
                this.lbl_kills.TabIndex = 16;
                // 
                // label6
                // 
                this.label6.AutoSize = true;
                this.label6.BackColor = System.Drawing.SystemColors.Control;
                this.label6.Location = new System.Drawing.Point(9, 16);
                this.label6.Name = "label6";
                this.label6.Size = new System.Drawing.Size(25, 13);
                this.label6.TabIndex = 15;
                this.label6.Text = "Kills";
                // 
                // treeView1
                // 
                this.treeView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                    | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
                this.treeView1.Location = new System.Drawing.Point(283, 22);
                this.treeView1.Name = "treeView1";
                this.treeView1.Size = new System.Drawing.Size(253, 242);
                this.treeView1.TabIndex = 18;
                this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
                // 
                // timer1
                // 
                this.timer1.Enabled = true;
                this.timer1.Interval = 333;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                // 
                // btn_pause
                // 
                this.btn_pause.Location = new System.Drawing.Point(65, 203);
                this.btn_pause.Name = "btn_pause";
                this.btn_pause.Size = new System.Drawing.Size(49, 27);
                this.btn_pause.TabIndex = 19;
                this.btn_pause.Text = "Pause";
                this.btn_pause.UseVisualStyleBackColor = true;
                this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
                // 
                // btn_go
                // 
                this.btn_go.Location = new System.Drawing.Point(15, 203);
                this.btn_go.Name = "btn_go";
                this.btn_go.Size = new System.Drawing.Size(44, 27);
                this.btn_go.TabIndex = 20;
                this.btn_go.Text = "Go";
                this.btn_go.UseVisualStyleBackColor = true;
                this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
                // 
                // btn_stop
                // 
                this.btn_stop.Location = new System.Drawing.Point(120, 203);
                this.btn_stop.Name = "btn_stop";
                this.btn_stop.Size = new System.Drawing.Size(49, 27);
                this.btn_stop.TabIndex = 21;
                this.btn_stop.Text = "Stop";
                this.btn_stop.UseVisualStyleBackColor = true;
                this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
                // 
                // lb_params
                // 
                this.lb_params.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.lb_params.FormattingEnabled = true;
                this.lb_params.Location = new System.Drawing.Point(546, 22);
                this.lb_params.Name = "lb_params";
                this.lb_params.Size = new System.Drawing.Size(179, 108);
                this.lb_params.TabIndex = 22;
                // 
                // label4
                // 
                this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.label4.AutoSize = true;
                this.label4.BackColor = System.Drawing.SystemColors.Control;
                this.label4.Location = new System.Drawing.Point(546, 6);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(60, 13);
                this.label4.TabIndex = 8;
                this.label4.Text = "Parameters";
                // 
                // label7
                // 
                this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.label7.AutoSize = true;
                this.label7.BackColor = System.Drawing.SystemColors.Control;
                this.label7.Location = new System.Drawing.Point(546, 140);
                this.label7.Name = "label7";
                this.label7.Size = new System.Drawing.Size(56, 13);
                this.label7.TabIndex = 23;
                this.label7.Text = "Interesting";
                // 
                // lb_defs
                // 
                this.lb_defs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
                this.lb_defs.FormattingEnabled = true;
                this.lb_defs.Location = new System.Drawing.Point(546, 156);
                this.lb_defs.Name = "lb_defs";
                this.lb_defs.Size = new System.Drawing.Size(179, 108);
                this.lb_defs.TabIndex = 24;
                // 
                // label10
                // 
                this.label10.AutoSize = true;
                this.label10.BackColor = System.Drawing.SystemColors.Control;
                this.label10.Location = new System.Drawing.Point(283, 6);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(34, 13);
                this.label10.TabIndex = 25;
                this.label10.Text = "Script";
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.BackColor = System.Drawing.SystemColors.Control;
                this.label2.Location = new System.Drawing.Point(14, 143);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(41, 13);
                this.label2.TabIndex = 28;
                this.label2.Text = "Activity";
                // 
                // lbl_activity
                // 
                this.lbl_activity.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_activity.Location = new System.Drawing.Point(55, 143);
                this.lbl_activity.Name = "lbl_activity";
                this.lbl_activity.Size = new System.Drawing.Size(197, 13);
                this.lbl_activity.TabIndex = 29;
                // 
                // label5
                // 
                this.label5.AutoSize = true;
                this.label5.BackColor = System.Drawing.SystemColors.Control;
                this.label5.Location = new System.Drawing.Point(14, 187);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(32, 13);
                this.label5.TabIndex = 26;
                this.label5.Text = "State";
                // 
                // lbl_state
                // 
                this.lbl_state.BackColor = System.Drawing.SystemColors.Info;
                this.lbl_state.Location = new System.Drawing.Point(55, 187);
                this.lbl_state.Name = "lbl_state";
                this.lbl_state.Size = new System.Drawing.Size(197, 13);
                this.lbl_state.TabIndex = 27;
                // 
                // PatherForm
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(733, 273);
                this.ControlBox = false;
                this.Controls.Add(this.label2);
                this.Controls.Add(this.lbl_activity);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.lbl_state);
                this.Controls.Add(this.label10);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.lb_defs);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.lb_params);
                this.Controls.Add(this.btn_stop);
                this.Controls.Add(this.btn_go);
                this.Controls.Add(this.btn_pause);
                this.Controls.Add(this.treeView1);
                this.Controls.Add(this.groupBox2);
                this.Controls.Add(this.grpBox);
                this.MaximumSize = new System.Drawing.Size(741, 1000);
                this.MinimumSize = new System.Drawing.Size(290, 262);
                this.Name = "PatherForm";
                this.Text = "Form1";
                this.grpBox.ResumeLayout(false);
                this.grpBox.PerformLayout();
                this.groupBox2.ResumeLayout(false);
                this.groupBox2.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.Label lbl_name;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label lbl_reaction;
            private System.Windows.Forms.Label label9;
            private System.Windows.Forms.Label lbl_level;
            private System.Windows.Forms.Label lbl_faction;
            private System.Windows.Forms.Label label12;
            private System.Windows.Forms.GroupBox grpBox;
            private System.Windows.Forms.GroupBox groupBox2;
            private System.Windows.Forms.Label lbl_deaths;
            private System.Windows.Forms.Label label16;
            private System.Windows.Forms.Label lbl_ttl;
            private System.Windows.Forms.Label label18;
            private System.Windows.Forms.Label lbl_harvest;
            private System.Windows.Forms.Label label14;
            private System.Windows.Forms.Label lbl_XPh;
            private System.Windows.Forms.Label label11;
            private System.Windows.Forms.Label lbl_loots;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.Label lbl_kills;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.TreeView treeView1;
            private System.Windows.Forms.Timer timer1;
            private System.Windows.Forms.Button btn_pause;
            private System.Windows.Forms.Button btn_go;
            private System.Windows.Forms.Button btn_stop;
            private System.Windows.Forms.ListBox lb_params;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.ListBox lb_defs;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label lbl_activity;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Label lbl_state;
        }
        #endregion

    #region TaskParser
        public class RootNode : NodeTask
        {
            public RootNode()
                : base(null)
            {
                type = "Oneshot";
            }


            public override Value GetValueOfFcall(string def, List<Value> parms)
            {
                Console.WriteLine("fcall " + def + "(" + parms + ")");

                if (def == "QuestStatus")
                {
                    String q = parms[0].GetStringValue();
                    String status = PPather.GetQuestStatus(q);
                    //GContext.Main.Log("Quest status of '" + q + "' is " + status);
                    return new Value(status);
                }
                return null;
            }


            private int CountFreeBagSlots()
            {
                int count = 0;
                int totalslots = 0;
                long[] AllBags = GPlayerSelf.Me.Bags;

                for (int bagNr = 0; bagNr < 5; bagNr++)
                {
                    long[] Contents;
                    int SlotCount;
                    if (bagNr == 0)
                    {
                        Contents = GContext.Main.Me.BagContents;
                        SlotCount = 16;
                    }
                    else
                    {
                        GContainer bag = (GContainer)GObjectList.FindObject(AllBags[bagNr - 1]);
                        if (bag != null)
                        {
                            Contents = bag.BagContents;
                            SlotCount = bag.SlotCount;
                        }
                        else
                        {
                            SlotCount = 0;
                            Contents = null;
                        }
                    }
                    totalslots += SlotCount;
                    for (int i = 0; i < SlotCount; i++)
                    {
                        if (Contents[i] == 0)
                            count++;
                    }
                }
                return count;
            }



            private Value CreateItemCount()
            {
                Dictionary<String, int> items = new Dictionary<String, int>();
                long[] AllBags = GPlayerSelf.Me.Bags;

                for (int bagNr = 0; bagNr < 5; bagNr++)
                {
                    long[] Contents;
                    int SlotCount;
                    if (bagNr == 0)
                    {
                        Contents = GContext.Main.Me.BagContents;
                        SlotCount = 16;
                    }
                    else
                    {
                        GContainer bag = (GContainer)GObjectList.FindObject(AllBags[bagNr - 1]);
                        if (bag != null)
                        {
                            Contents = bag.BagContents;
                            SlotCount = bag.SlotCount;
                        }
                        else
                        {
                            SlotCount = 0;
                            Contents = null;
                        }
                    }
                    for (int i = 0; i < SlotCount; i++)
                    {
                        if (Contents[i] == 0)
                            continue;
                        GItem CurItem = (GItem)GObjectList.FindObject(Contents[i]);
                        if (CurItem != null)
                        {
                            string ItemName = CurItem.Name;
                            int ItemCount = CurItem.StackSize;
                            int OldCount = 0;
                            items.TryGetValue(ItemName, out OldCount);
                            items.Remove(ItemName);
                            items.Add(ItemName, OldCount + ItemCount);
                        }
                    }
                }

                Value res = new Value(items);
                return res;
            }

            // compute the works equipped item durability
            float GetDurability()
            {
                float worst = 1.0f;

                GItem[] items = GObjectList.GetEquippedItems();
                foreach (GItem item in items)
                {
                    if (item.DurabilityMax > 0)
                    {
                        float dur = (float)item.Durability;
                        if (dur < worst) worst = dur;
                    }
                }

                return worst;
            }

            public override Value GetValueOfId(string def)
            {
                String val = null;
                if (def == "MyLevel")
                {
                    val = GContext.Main.Me.Level.ToString();
                }
                else if (def == "MyZone")
                {
                    val = PPather.MacrolessZoneInfo.GetZoneText();
                }
                else if (def == "MySubZone")
                {
                    val = PPather.MacrolessZoneInfo.GetSubZoneText();
                }
                else if (def == "BGQueued")
                {
                    val = PPather.MiniMapBattlefieldFrame.IsVisible() ? "1" : "0";
                }
                else if (def == "ItemCount")
                {
                    // Update the item count assoc array from bags
                    return CreateItemCount();
                }

                else if (def == "FreeBagSlots")
                {
                    //GContext.Main.Log("FreeBagSlots not implemented yet");
                    return new Value(CountFreeBagSlots());
                }
                else if (def == "MyDurability")
                {
                    float dur = GetDurability();
                    return new Value(dur);
                }
                else
                {
                    val = GContext.Main.GetConfigString(def);
                }
                //    Console.WriteLine("GetValue " + def + " = " + val);
                return new Value(val);
            }

            public override NodeExpression GetExpressionOfId(string def)
            {
                return null; // dynamic value, not defined my expression
            }
        }
        public class Value
        {
            string value; // for scalars
            List<Value> values; // for collections
            Dictionary<String, Value> dic; // for associative arrays

            public Value(string val)
            {
                value = val;
                values = null;
            }

            public Value(int val)
            {
                value = val.ToString();
                values = null;
            }

            public Value(float val)
            {
                value = val.ToString();
                values = null;
            }

            public Value(List<Value> val)
            {
                values = null;
                values = val;
            }

            public Value(Dictionary<String, Value> val)
            {
                values = null;
                values = null;
                dic = val;
            }

            // handy utility function 
            public Value(Dictionary<String, int> val)
            {
                values = null;
                values = null;
                dic = new Dictionary<string, Value>();
                foreach (string key in val.Keys)
                {
                    int c = 0;
                    val.TryGetValue(key, out c);
                    Value v = new Value(c);
                    SetAssocValue(key, v);
                }
            }

            public static Value NilValue = new Value("");
            public static Value FalseValue = new Value("false");
            public static Value TrueValue = new Value("true");
            public static Value ZeroValue = new Value("0");

            public bool GetBoolValue()
            {
                string s = GetStringValue();
                if (s == "false" || s == "False") return false;
                if (s == "0") return false;
                if (s == "") return false;
                return true;
            }

            public string GetStringValue()
            {
                if (value != null) return value;
                if (values != null)
                {
                    String vs = "[";
                    foreach (Value v in values)
                    {
                        vs += v.GetStringValue() + ", ";
                    }
                    return vs + "]";
                }
                if (dic != null)
                {
                    String vs = "{";
                    foreach (String s in dic.Keys)
                    {
                        Value val = dic[s];
                        vs += s + " => " + val + ", ";
                    }

                    return vs + "}";
                }
                return "";
            }

            public bool IsInt()
            {
                if (this == NilValue) return true;
                try
                {
                    Int32.Parse(GetStringValue());
                    return true;
                }
                catch { }
                return false;
            }

            public bool IsFloat()
            {
                if (this == NilValue) return true;
                try
                {
                    Single.Parse(GetStringValue());
                    return true;
                }
                catch { }
                return false;
            }
            public bool IsCollection()
            {
                return values != null;
            }
            public bool IsAssocArray()
            {
                return dic != null;
            }

            public void SetAssocValue(string key, Value value)
            {
                if (dic == null)
                    dic = new Dictionary<string, Value>();
                this.value = null;
                this.values = null;

                dic.Remove(key);
                dic.Add(key, value);
            }

            public Value GetAssocValue(string key)
            {
                Value val = null;
                if (dic == null) return null;
                dic.TryGetValue(key, out val);
                if (val == null) return NilValue;
                return val;
            }

            public int GetIntValue()
            {
                if (this == NilValue) return 0;
                try
                {
                    return Int32.Parse(GetStringValue());
                }
                catch { }
                return 0;
            }

            public float GetFloatValue()
            {
                if (this == NilValue) return 0;
                try
                {
                    return Single.Parse(GetStringValue());
                }
                catch { }
                return 0.0f;
            }

            public List<string> GetStringCollectionValues()
            {
                List<string> vals = new List<string>();
                if (values == null)
                {
                    if (value != null && this != NilValue)
                        vals.Add(GetStringValue()); // not a collection 
                }
                else
                {
                    foreach (Value v in values)
                    {
                        vals.Add(v.GetStringValue());
                    }
                }
                return vals;
            }

            public List<int> GetIntCollectionValues()
            {
                List<int> vals = new List<int>();
                if (values == null)
                {
                    if (value != null && this != NilValue)
                        vals.Add(GetIntValue()); // not a collection 
                }
                else
                {
                    foreach (Value v in values)
                    {
                        vals.Add(v.GetIntValue());
                    }
                }
                return vals;
            }


            // this has to be a collection of floats with at least 3 items
            public Location GetLocationValue()
            {
                float x = 0, y = 0, z = 0;
                if (values == null) return null;

                int i = 0;
                foreach (Value v in values)
                {
                    float f = v.GetFloatValue();
                    if (i == 0) x = f;
                    if (i == 1) y = f;
                    if (i == 2) z = f;
                    i++;
                }
                return new Location(x, y, z);
            }

            public List<Value> GetCollectionValue()
            {
                if (values != null) return values;
                List<Value> c = new List<Value>();
                if (value != null)
                    c.Add(new Value(value));
                return c;
            }
            public override string ToString()
            {
                return GetStringValue();
            }
        }
        public abstract class ASTNode
        {
            public void Error(string err)
            {
                Console.WriteLine("Error: " + err);
            }
            public abstract void dump(int d);
            public string prefix(int d)
            {
                String s = "";
                while (d-- > 0)
                    s += "  ";
                return s;
            }
        }
        public abstract class NodeExpression : ASTNode
        {
            protected NodeTask task;

            public NodeExpression(NodeTask task)
            {
                this.task = task;
            }
            public abstract Value GetValue();

            public abstract bool BindSymbols();

        }
        public class LiteralExpression : NodeExpression
        {
            Value val;
            public LiteralExpression(NodeTask task, string val)
                : base(task)
            {
                this.val = new Value(val);
            }
            public LiteralExpression(NodeTask task, Value val)
                : base(task)
            {
                this.val = val;
            }
            public override Value GetValue()
            {
                return val;
            }
            public override void dump(int d)
            {
                Console.Write(val);
            }

            public override bool BindSymbols() { return true; }
        }
        public class IDExpression : NodeExpression
        {
            string id;
            NodeExpression expression;
            public IDExpression(NodeTask task, string id)
                : base(task)
            {
                this.id = id;
            }
            public override Value GetValue()
            {
                if (expression != null)
                {
                    // know where it is
                    expression.GetValue();
                }

                return task.GetValueOfId(id);
            }
            public override void dump(int d)
            {
                Console.Write("$" + id);
            }

            public override bool BindSymbols()
            {
                expression = task.GetExpressionOfId(id);
                return expression != null;
            }
        }
        public class FcallExpression : NodeExpression
        {
            string id;
            List<NodeExpression> parms;
            public FcallExpression(NodeTask task, string id, List<NodeExpression> parms)
                : base(task)
            {
                this.id = id;
                this.parms = parms;
            }
            public override Value GetValue()
            {
                List<Value> vals = new List<Value>(parms.Count);
                foreach (NodeExpression e in parms)
                {
                    Value v = e.GetValue();
                    if (v == null) return null;
                    vals.Add(v);
                }

                return task.GetValueOfFcall(id, vals);
            }
            public override void dump(int d)
            {
                Console.Write("call " + id + "(");
                foreach (NodeExpression e in parms)
                {
                    e.dump(d);
                    Console.Write(", ");
                }
                Console.Write(")");
            }

            public override bool BindSymbols()
            {
                bool ok = true;
                foreach (NodeExpression e in parms)
                {
                    ok &= e.BindSymbols();
                }
                // TODO check fcall name
                return ok;
            }
        }
        public class CollectionExpression : NodeExpression
        {
            List<NodeExpression> expressions;
            public CollectionExpression(NodeTask task, List<NodeExpression> expressions)
                : base(task)
            {
                this.expressions = expressions;
            }
            public override Value GetValue()
            {
                List<Value> vals = new List<Value>();
                foreach (NodeExpression e in expressions)
                {
                    vals.Add(e.GetValue());
                }
                return new Value(vals);
            }
            public override void dump(int d)
            {
                Console.Write("[");
                foreach (NodeExpression e in expressions)
                {
                    e.dump(d);
                    Console.Write(", ");
                }
                Console.Write("]");
            }
            public override bool BindSymbols()
            {
                bool ok = true;
                foreach (NodeExpression e in expressions)
                {
                    ok &= e.BindSymbols();
                }
                return ok;
            }
        }
        public class NegExpression : NodeExpression
        {
            NodeExpression e;
            public NegExpression(NodeTask task, NodeExpression e)
                : base(task)
            {
                this.e = e;
            }
            public override Value GetValue()
            {
                Value v = e.GetValue();
                if (v.IsInt())
                {
                    int i = -v.GetIntValue();
                    v = new Value(i.ToString());
                }
                else if (v.IsFloat())
                {
                    float f = -v.GetFloatValue();
                    v = new Value(f.ToString());
                }
                else
                {
                    Error("Negating non numerical value " + v);
                }
                return v;
            }
            public override void dump(int d)
            {
                Console.Write("-"); e.dump(d);
            }

            public override bool BindSymbols()
            {
                return e.BindSymbols();
            }
        }
        public abstract class BinExpresssion : NodeExpression
        {
            protected NodeExpression left;
            protected NodeExpression right;
            public BinExpresssion(NodeTask task, NodeExpression left, NodeExpression right)
                : base(task)
            {
                this.left = left;
                this.right = right;
            }
            public abstract string OpName();
            public override void dump(int d)
            {
                Console.Write("(");
                left.dump(d);
                Console.Write(OpName());
                right.dump(d);
                Console.Write(")");
            }

            public override bool BindSymbols()
            {
                return left.BindSymbols() && right.BindSymbols();
            }
        }
        public class AssocReadExpression : BinExpresssion
        {
            public AssocReadExpression(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override Value GetValue()
            {
                Value assoc = left.GetValue();
                Value key = right.GetValue();
                if (assoc == null || key == null) return null;


                String key_s = key.GetStringValue();
                Value val = assoc.GetAssocValue(key_s);
                //GContext.Main.Log("lookup " + key + " in "+ assoc + " found "+ val);

                return val;

            }
            public override string OpName() { return null; } // not used

            public override void dump(int d)
            {
                left.dump(d);
                Console.Write("{");
                right.dump(d);
                Console.Write("}");

            }

        }
        public abstract class BoolBinExpression : BinExpresssion
        {
            public BoolBinExpression(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override Value GetValue()
            {
                Value val0 = left.GetValue();
                Value val1 = right.GetValue();

                if (val0 == null || val1 == null) return null;
                bool c0 = val0.GetBoolValue();
                bool c1 = val1.GetBoolValue();

                bool res = BoolOp(c0, c1);
                if (res) return Value.TrueValue;
                else return Value.FalseValue;

            }
            public abstract bool BoolOp(bool a, bool b);

        }
        public class ExprAnd : BoolBinExpression
        {
            public ExprAnd(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool BoolOp(bool a, bool b) { return a && b; }
            public override string OpName() { return "&&"; }
        }
        public class ExprOr : BoolBinExpression
        {
            public ExprOr(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            {

            }
            public override bool BoolOp(bool a, bool b) { return a || b; }
            public override string OpName() { return "||"; }
        }
        public abstract class ArithBinExpression : BinExpresssion
        {
            public ArithBinExpression(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override Value GetValue()
            {
                Value val0 = left.GetValue();
                Value val1 = right.GetValue();
                if (val0.IsInt() && val1.IsInt())
                {
                    int c0 = val0.GetIntValue();
                    int c1 = val1.GetIntValue();
                    return new Value(IntOp(c0, c1).ToString());

                }
                if ((val0.IsFloat() && val1.IsFloat()) ||
                    (val0.IsInt() && val1.IsFloat()) ||
                    (val0.IsFloat() && val1.IsInt()))
                {
                    float c0 = val0.GetFloatValue();
                    float c1 = val1.GetFloatValue();
                    float sum = c0 + c1;
                    return new Value(FloatOp(c0, c1).ToString());
                }
                return GenericOp(val0, val1);
            }

            public abstract float FloatOp(float a, float b);
            public abstract int IntOp(int a, int b);
            public virtual Value GenericOp(Value a, Value b)
            {
                Error("op " + this + " can not handle " + a + " and " + b);
                return null;
            }

        }
        public abstract class CmpExpression : BinExpresssion
        {
            public CmpExpression(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override Value GetValue()
            {
                Value val0 = left.GetValue();
                Value val1 = right.GetValue();
                if (val0.IsInt() && val1.IsInt())
                {
                    int c0 = val0.GetIntValue();
                    int c1 = val1.GetIntValue();
                    bool v = IntOp(c0, c1);
                    if (v)
                        return Value.TrueValue;
                    else
                        return Value.FalseValue;

                }
                if ((val0.IsFloat() && val1.IsFloat()) ||
                    (val0.IsInt() && val1.IsFloat()) ||
                    (val0.IsFloat() && val1.IsInt()))
                {
                    float c0 = val0.GetFloatValue();
                    float c1 = val1.GetFloatValue();
                    bool v = FloatOp(c0, c1);
                    if (v)
                        return Value.TrueValue;
                    else
                        return Value.FalseValue;
                }

                bool sv = StringOp(val0.GetStringValue(), val1.GetStringValue());
                if (sv)
                    return Value.TrueValue;
                else
                    return Value.FalseValue;
            }

            public abstract bool FloatOp(float a, float b);
            public abstract bool IntOp(int a, int b);
            public abstract bool StringOp(string a, string b);

        }
        public class ExprAdd : ArithBinExpression
        {
            public ExprAdd(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override float FloatOp(float a, float b) { return a + b; }
            public override int IntOp(int a, int b) { return a + b; }
            public override string OpName() { return "+"; }
        }
        public class ExprSub : ArithBinExpression
        {
            public ExprSub(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override float FloatOp(float a, float b) { return a - b; }
            public override int IntOp(int a, int b) { return a - b; }
            public override string OpName() { return "-"; }
        }
        public class ExprMul : ArithBinExpression
        {
            public ExprMul(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override float FloatOp(float a, float b) { return a * b; }
            public override int IntOp(int a, int b) { return a * b; }
            public override string OpName() { return "*"; }
        }
        public class ExprDiv : ArithBinExpression
        {
            public ExprDiv(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override float FloatOp(float a, float b) { return a / b; }
            public override int IntOp(int a, int b) { return a / b; }
            public override string OpName() { return "/"; }
        }
        public class ExprCmpGt : CmpExpression
        {
            public ExprCmpGt(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a > b; }
            public override bool IntOp(int a, int b) { return a > b; }
            public override bool StringOp(string a, string b) { return a.CompareTo(b) > 0; }
            public override string OpName() { return ">"; }
        }
        public class ExprCmpGe : CmpExpression
        {
            public ExprCmpGe(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a >= b; }
            public override bool IntOp(int a, int b)
            {
                return a >= b;
            }
            public override bool StringOp(string a, string b) { return a.CompareTo(b) >= 0; }
            public override string OpName() { return ">="; }
        }
        public class ExprCmpEq : CmpExpression
        {
            public ExprCmpEq(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a == b; }
            public override bool IntOp(int a, int b) { return a == b; }
            public override bool StringOp(string a, string b) { return a == b; }
            public override string OpName() { return "=="; }
        }
        public class ExprCmpLe : CmpExpression
        {
            public ExprCmpLe(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a <= b; }
            public override bool IntOp(int a, int b) { return a <= b; }
            public override bool StringOp(string a, string b) { return a.CompareTo(b) <= 0; }
            public override string OpName() { return "<="; }
        }
        public class ExprCmpLt : CmpExpression
        {
            public ExprCmpLt(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a < b; }
            public override bool IntOp(int a, int b)
            {
                return a < b;
            }
            public override bool StringOp(string a, string b) { return a.CompareTo(b) < 0; }
            public override string OpName() { return "<"; }
        }
        public class ExprCmpNe : CmpExpression
        {

            public ExprCmpNe(NodeTask task, NodeExpression a0, NodeExpression a1)
                : base(task, a0, a1)
            { }
            public override bool FloatOp(float a, float b) { return a != b; }
            public override bool IntOp(int a, int b) { return a != b; }
            public override bool StringOp(string a, string b) { return a.CompareTo(b) != 0; }
            public override string OpName() { return "!="; }
        }
        public class NodeDefinition : ASTNode
        {
            NodeTask task;
            string name;
            NodeExpression expression;
            public NodeDefinition(NodeTask task, string name, NodeExpression expression)
            {
                this.task = task;
                this.name = name;
                this.expression = expression;
            }

            public bool IsNamed(string s)
            {
                if (String.Compare(s, name) == 0) return true;
                return false;
            }

            public NodeExpression GetExpression()
            {
                return expression;
            }
            public override void dump(int d)
            {
                Console.Write(prefix(d) + "$" + name + " = ");
                expression.dump(d);
                Console.WriteLine(";");
            }

        }
        public abstract class FuncDefinition
        {
            public abstract bool IsNamed(string s);
            public abstract Value call(List<Value> parms);
        }
        public class NodeTask : ASTNode
        {
            public NodeTask parent;
            public string type;
            public string name; // might be null
            List<NodeDefinition> definitions = new List<NodeDefinition>();
            List<FuncDefinition> funcDefinitions = new List<FuncDefinition>();
            public List<NodeTask> subTasks = new List<NodeTask>();

            public NodeTask(NodeTask parent)
            {
                this.parent = parent;
            }

            public void AddDefinition(NodeDefinition def)
            {
                definitions.Add(def);
            }

            public void AddTask(NodeTask task)
            {
                subTasks.Add(task);
                task.parent = this;
            }

            public int GetPrio()
            {
                Value val = GetValueOfId("Prio");
                if (!val.IsInt())
                    Error("$Prio has bad value " + val);
                return val.GetIntValue();
            }

            public void AddFunction(FuncDefinition fd)
            {
                funcDefinitions.Add(fd);
            }

            public virtual Value GetValueOfFcall(string def, List<Value> parms)
            {
                int dotIndex = def.IndexOf('.');
                if (dotIndex != -1)
                {
                    // dot in name, search in named chilren tasks for it
                    String cname = def.Substring(0, dotIndex);
                    String cdef = def.Substring(dotIndex + 1);
                    foreach (NodeTask t in subTasks)
                    {
                        if (t.name != null && t.name == cname)
                        {
                            Value v = t.GetValueOfFcall(cdef, parms);
                            return v;
                        }
                    }
                }
                else
                {
                    foreach (FuncDefinition d in funcDefinitions)
                    {
                        if (d.IsNamed(def))
                        {
                            Value val = d.call(parms);
                            return val;
                        }
                    }
                    if (parent != null)
                        return parent.GetValueOfFcall(def, parms);
                }

                Error("Undfined function " + def);
                return null;
            }

            public bool GetBoolValueOfId(string id)
            {
                Value v = GetValueOfId(id);
                return v.GetBoolValue();
            }

            public float GetFloatValueOfId(string id)
            {
                Value v = GetValueOfId(id);
                return v.GetFloatValue();
            }

            public int GetIntValueOfId(string id)
            {
                Value v = GetValueOfId(id);
                return v.GetIntValue();
            }

            public void SetValueOfId(string def, Value val)
            {
                NodeDefinition n = null;
                foreach (NodeDefinition d in definitions)
                {
                    if (d.IsNamed(def)) n = d;
                }
                if (n != null)
                    definitions.Remove(n);

                n = new NodeDefinition(this, def, new LiteralExpression(this, val));
                definitions.Add(n);

            }

            public virtual Value GetValueOfId(string def)
            {
                int dotIndex = def.IndexOf('.');
                if (dotIndex != -1)
                {
                    // dot in name, search in named chilren tasks for it
                    String cname = def.Substring(0, dotIndex);
                    String cdef = def.Substring(dotIndex + 1);
                    foreach (NodeTask t in subTasks)
                    {
                        if (t.name != null && t.name == cname)
                        {
                            Value v = t.GetValueOfId(cdef);
                            return v;
                        }
                    }
                }
                else
                {
                    foreach (NodeDefinition d in definitions)
                    {
                        if (d.IsNamed(def))
                        {
                            NodeExpression e = d.GetExpression();
                            Value val = e.GetValue();

                            //  GContext.Main.Log(" def: " + def + " got e " + e + " and val " + val);

                            return val;
                        }
                    }
                    if (parent != null)
                    {
                        Value e = parent.GetValueOfId(def);
                        return e;
                    }
                }
                Error("No definition of idenfifier " + def);
                return null;
            }

            public virtual NodeExpression GetExpressionOfId(string def)
            {
                /*int dotIndex = def.IndexOf('.'); 
                if (dotIndex != -1)
                {
                    // dot in name, search in named chilren tasks for it
                    String cname = def.Substring(0, dotIndex);
                    String cdef  = def.Substring(dotIndex + 1);
                    foreach (
                        NodeTask t in subTasks)
                    {
                        if (t.name != null && t.name == cname)
                            return t.GetExpressionOfId(def); 
                    }
                }
                else*/
                {
                    foreach (NodeDefinition d in definitions)
                    {
                        if (d.IsNamed(def))
                        {
                            return d.GetExpression();
                        }
                    }
                }
                if (parent != null)
                {
                    NodeExpression e = parent.GetExpressionOfId(def);
                    return e;
                }
                Error("No definition of idenfifier " + def);
                return null;
            }

            public override void dump(int d)
            {
                Console.WriteLine(prefix(d) + type);
                Console.WriteLine(prefix(d) + "{");

                foreach (NodeDefinition nd in definitions)
                {
                    nd.dump(d + 1);
                }
                foreach (NodeTask task in subTasks)
                {
                    task.dump(d + 1);
                }
                Console.WriteLine(prefix(d) + "}");


            }


            public bool BindSymbols()
            {
                bool ok = true;
                // Traverse the tree and connect ID expression to their expression
                foreach (NodeDefinition d in definitions)
                {
                    NodeExpression e = d.GetExpression();
                    ok &= e.BindSymbols();
                }
                foreach (NodeTask t in subTasks)
                {
                    ok &= t.BindSymbols();
                }
                return ok;
            }
        }
        class RootTask : NodeTask
        {
            public RootTask()
                : base(null)
            {
            }
            public override Value GetValueOfId(string def)
            {
                Error("Someone is getting value of " + def);
                return null;
            }


        }
        public class TaskParser
        {


            Tokenizer tn;
            public TaskParser(System.IO.TextReader reader)
            {
                tn = new Tokenizer(reader);
            }


            public void Error(string msg)
            {
                GContext.Main.Log("Line " + tn.line + ": " + msg);
            }

            private bool Expect(Token.Type type, string val)
            {
                Token t = tn.Next();
                if (t.type != type || t.val != val)
                {
                    Error("Exprected " + val + " found " + t.val);
                    return false;
                }
                return true;
            }

            private NodeExpression ParseExpressionP(NodeTask t)
            {
                Token next = tn.Peek();
                if (next.type == Token.Type.Literal)
                {
                    // literal expression
                    tn.Next();
                    Token lpar = tn.Peek();
                    if (lpar.type == Token.Type.Keyword && lpar.val == "(")
                    {
                        //fcall

                        List<NodeExpression> exprs = new List<NodeExpression>();
                        Token comma = null;
                        do
                        {
                            tn.Next(); // eat ( or , 
                            NodeExpression n = ParseExpression(t);
                            exprs.Add(n);
                            comma = tn.Peek();
                        } while (comma.type == Token.Type.Keyword && comma.val == ",");

                        Expect(Token.Type.Keyword, ")");

                        NodeExpression e = new FcallExpression(t, next.val, exprs);
                        return e;
                    }
                    else
                    {
                        NodeExpression e = new LiteralExpression(t, next.val);

                        return e;
                    }
                }
                else if (next.type == Token.Type.ID)
                {
                    // ID expression
                    tn.Next();

                    Token lpar = tn.Peek();

                    // assoc lookup
                    if (lpar.type == Token.Type.Keyword && lpar.val == "{")
                    {
                        tn.Next(); // eat {
                        NodeExpression id = new IDExpression(t, next.val);

                        NodeExpression key = ParseExpression(t);

                        Expect(Token.Type.Keyword, "}");


                        NodeExpression e = new AssocReadExpression(t, id, key);
                        return e;
                    }
                    else
                    {
                        NodeExpression e = new IDExpression(t, next.val);

                        return e;
                    }

                }
                else if (next.type == Token.Type.Keyword && next.val == "(")
                {
                    // par expressions
                    tn.Next();
                    NodeExpression n = ParseExpressionE(t);
                    Expect(Token.Type.Keyword, ")");
                    return n;
                }
                else if (next.type == Token.Type.Keyword && next.val == "[")
                {
                    // collection expressions

                    List<NodeExpression> exprs = new List<NodeExpression>();
                    Token comma = null;
                    do
                    {
                        tn.Next();
                        Token p = tn.Peek();
                        if (p.type == Token.Type.Keyword && p.val == "]") break; // empty collection
                        NodeExpression n = ParseExpressionE(t);
                        exprs.Add(n);
                        comma = tn.Peek();
                    } while (comma.type == Token.Type.Keyword && comma.val == ",");

                    Expect(Token.Type.Keyword, "]");
                    CollectionExpression ce = new CollectionExpression(t, exprs);
                    return ce;
                }
                else if (next.type == Token.Type.Keyword && next.val == "-")
                {
                    // unary neg
                    Token neg = tn.Next();
                    NodeExpression P = ParseExpressionP(t);
                    NodeExpression e = new NegExpression(t, P);
                    return e;
                }
                else
                {
                    Error("Currupt expression");
                }
                return null;
            }


            private NodeExpression ParseExpressionT(NodeTask t)
            {
                // this is the hard one
                NodeExpression o0 = ParseExpressionP(t);

                Token next = tn.Peek();
                while (next.type == Token.Type.Keyword &&
                    (next.val == "*" || next.val == "/"))
                {
                    Token op = tn.Next();
                    NodeExpression o1 = ParseExpressionP(t);
                    if (op.val == "*")
                    {
                        o0 = new ExprMul(t, o0, o1);

                    }
                    if (op.val == "/")
                    {
                        o0 = new ExprDiv(t, o0, o1);
                    }
                    next = tn.Peek();
                }
                return o0;
            }

            private NodeExpression ParseExpressionE(NodeTask t)
            {
                // this is the hard one
                NodeExpression o0 = ParseExpressionT(t);

                Token next = tn.Peek();
                while (next.type == Token.Type.Keyword &&
                    (next.val == "+" || next.val == "-"))
                {
                    Token op = tn.Next();
                    NodeExpression o1 = ParseExpressionT(t);
                    if (op.val == "+")
                    {
                        o0 = new ExprAdd(t, o0, o1);
                    }
                    if (op.val == "-")
                    {
                        o0 = new ExprSub(t, o0, o1);
                    }
                    next = tn.Peek();
                }
                return o0;
            }

            private NodeExpression ParseExpressionC(NodeTask t)
            {
                NodeExpression o0 = ParseExpressionE(t);

                Token next = tn.Peek();
                while (next.type == Token.Type.Keyword &&
                    (next.val == "<" || next.val == "<=" || next.val == "==" ||
                     next.val == ">=" || next.val == ">" || next.val == "!="))
                {
                    Token op = tn.Next();
                    NodeExpression o1 = ParseExpressionE(t);
                    if (op.val == "<")
                        o0 = new ExprCmpLt(t, o0, o1);
                    else if (op.val == "<=")
                        o0 = new ExprCmpLe(t, o0, o1);
                    else if (op.val == "==")
                        o0 = new ExprCmpEq(t, o0, o1);
                    else if (op.val == ">=")
                        o0 = new ExprCmpGe(t, o0, o1);
                    else if (op.val == ">")
                        o0 = new ExprCmpGt(t, o0, o1);
                    else if (op.val == "!=")
                        o0 = new ExprCmpNe(t, o0, o1);

                    next = tn.Peek();
                }
                return o0;
            }

            private NodeExpression ParseExpressionBAnd(NodeTask t)
            {
                NodeExpression o0 = ParseExpressionC(t);

                Token next = tn.Peek();
                while (next.type == Token.Type.Keyword &&
                    (next.val == "&&"))
                {
                    Token op = tn.Next();
                    NodeExpression o1 = ParseExpressionBOr(t);
                    if (op.val == "&&")
                        o0 = new ExprAnd(t, o0, o1);
                    next = tn.Peek();
                }
                return o0;
            }
            private NodeExpression ParseExpressionBOr(NodeTask t)
            {
                NodeExpression o0 = ParseExpressionBAnd(t);

                Token next = tn.Peek();
                while (next.type == Token.Type.Keyword &&
                    (next.val == "||"))
                {
                    Token op = tn.Next();
                    NodeExpression o1 = ParseExpressionBAnd(t);
                    if (op.val == "||")
                        o0 = new ExprOr(t, o0, o1);
                    next = tn.Peek();
                }
                return o0;
            }



            private NodeExpression ParseExpression(NodeTask t)
            {
                // this is the hard one
                NodeExpression e = ParseExpressionBOr(t);

                Token next = tn.Peek();
                if (next.type == Token.Type.Keyword && next.val == ";")
                {
                    // all fine
                }
                else
                {

                }

                return e;
            }

            public NodeTask ParseTask(NodeTask parent)
            {
                NodeTask t = new NodeTask(parent);
                Token r = tn.Peek();
                if (r.type == Token.Type.EOF) return null;

                String s_name = null;
                String s_type = null;

                // Type (or name)
                Token t1 = tn.Next();
                if (t1.type != Token.Type.Literal) // !!!
                {
                    Error("Task must have a type or name");
                    return null;
                }

                Token colon = tn.Peek();
                if (colon.type == Token.Type.Keyword && colon.val == ":")
                {
                    tn.Next(); // eat colon
                    Token t2 = tn.Next(); // type
                    if (t2.type != Token.Type.Literal) // !!!
                    {
                        Error("Expected task type after : in task definition");
                        return null;
                    }
                    s_name = t1.val;
                    s_type = t2.val;
                }
                else
                {
                    s_name = null;
                    s_type = t1.val;
                }

                t.type = s_type;
                t.name = s_name;

                // {            

                if (!Expect(Token.Type.Keyword, "{"))
                    return null;



                // definitions
                Token next = tn.Peek();
                while (next.type == Token.Type.ID)
                {
                    Token ID = tn.Next(); // chomp ID


                    if (!Expect(Token.Type.Keyword, "="))
                        return null;
                    NodeExpression expr = ParseExpression(t);


                    if (!Expect(Token.Type.Keyword, ";"))
                        return null;
                    t.AddDefinition(new NodeDefinition(t, ID.val, expr));
                    next = tn.Peek();
                }

                // child tasks
                next = tn.Peek();
                while (next.type == Token.Type.Literal)
                {
                    NodeTask child = ParseTask(t);

                    t.AddTask(child);
                    next = tn.Peek();
                }

                // }

                if (!Expect(Token.Type.Keyword, "}"))
                    return null;

                return t;
            }


        }
        class Token
        {
            public enum Type { ID, Literal, Newline, Keyword, EOF };
            public Type type;
            public string val;

            public Token(string s)
            {
                if (s[0] == '$')
                {
                    type = Type.ID;
                    val = s.Substring(1);
                }
                else
                {
                    type = Type.Literal;
                    val = s;
                }
            }

            private bool IsIDChar(char c)
            {
                if ((c >= 'a' && c <= 'z') ||
                   (c >= 'A' && c <= 'Z') ||
                   (c >= '0' && c <= '9') ||
                   c == '.' ||
                   c == '_'
                   )
                    return true;
                return false;
            }

            public Token(System.IO.TextReader reader)
            {
                type = Type.EOF;
                try
                {
                    bool done = false;
                    bool foundNonWhite = false;
                    do
                    {
                        int c = reader.Peek();
                        if (c == -1) break;
                        if (!foundNonWhite && Char.IsWhiteSpace((char)c))
                        {
                            reader.Read();
                            if ((char)c == '\n')
                            {
                                type = Type.Newline;
                                return;
                            }
                        }
                        else
                        {
                            foundNonWhite = true;
                            if (c == '$')
                            {
                                reader.Read(); // chomp $
                                readLiteral(reader);
                                type = Type.ID;
                                return;
                            }
                            if (c == '"')
                            {
                                readString(reader);
                                return;
                            }
                            else if (IsKeyChar(c))
                            {
                                if (readKeyWord(reader))
                                {
                                    // a comment, keep on reading
                                    foundNonWhite = false;
                                    type = Type.Newline;
                                    return;
                                }
                                else
                                    return;
                            }
                            else
                            {
                                readLiteral(reader);
                                type = Type.Literal;
                                return;
                            }
                        }
                    } while (!done);
                }
                catch (ObjectDisposedException)
                {
                    type = Type.EOF;
                }
                catch (System.IO.IOException)
                {
                    type = Type.EOF;
                }
                type = Type.EOF;
            }


            private bool IsKeyChar(int c)
            {
                if (c == '+') return true;
                if (c == '-') return true;
                if (c == '*') return true;
                if (c == '/') return true;
                if (c == '>') return true;
                if (c == '=') return true;
                if (c == '!') return true;
                if (c == '<') return true;
                if (c == '{') return true;
                if (c == '}') return true;
                if (c == ':') return true;
                if (c == ';') return true;
                if (c == '(') return true;
                if (c == ')') return true;
                if (c == ',') return true;
                if (c == ']') return true;
                if (c == '[') return true;
                if (c == '&') return true;
                if (c == '|') return true;
                if (c == '^') return true;
                return false;
            }

            // return true if it is a comment
            private bool readKeyWord(System.IO.TextReader reader)
            {
                int i = reader.Read();
                char c = (char)i;
                type = Type.Keyword;
                // some are 2 chars
                char c2 = (char)reader.Peek();

                if (c == '>' && c2 == '=')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '<' && c2 == '=')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '=' && c2 == '=')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '!' && c2 == '=')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '&' && c2 == '&')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '|' && c2 == '|')
                {
                    reader.Read();
                    val = "" + c + c2;
                }
                else if (c == '/' && c2 == '/')
                {
                    reader.ReadLine();
                    return true;
                }
                else
                    val = "" + c;
                return false;
            }

            private void readString(System.IO.TextReader reader)
            {
                val = "";
                type = Type.Literal;
                int c = reader.Read(); // read "
                bool esc = false;
                do
                {
                    c = reader.Read();
                    if (c == '\\' && !esc)
                    {
                        esc = true;
                    }
                    else
                    {
                        val += (char)c;
                        esc = false;
                    }
                    c = reader.Peek();
                } while (c != -1 && (c != '"' || esc == true));
                if (c == '"')
                    reader.Read(); // read "
            }

            private void readLiteral(System.IO.TextReader reader)
            {
                val = "";
                type = Type.Literal;
                int c = -1;
                do
                {
                    c = reader.Read();
                    val += (char)c;
                    c = reader.Peek();
                } while (IsIDChar((char)c) && c != -1);
            }



        }
        class Tokenizer
        {
            public int line;
            System.IO.TextReader reader;
            public Tokenizer(System.IO.TextReader reader)
            {
                this.reader = reader;
                line = 1;
            }
            Token current = null;

            public Token Peek()
            {
                if (current == null)
                    current = Next();
                return current;
            }

            public Token Next()
            {
                if (current != null)
                {
                    Token t = current;
                    current = null;
                    return t;
                }
                Token r = null;
                do
                {
                    r = new Token(reader);
                    if (r.type == Token.Type.Newline) line++;
                } while (r.type == Token.Type.Newline);
                return r;
            }
        }
        #endregion
    }
#else
    public class PPather : OOberGameClass
    {
    }
#endif

    public class OOberGameClass : GGameClass
    {
        #region Startup
        public override void Startup()
        {
            mover = new Mover(Context);
            popup = new Popup();
        }

        #endregion

        #region virtuals
        protected virtual string UberClassName
        {
            get { return "OOberClass"; }
        }

        protected virtual bool IsStuck(GLocation Loc)
        {
            return false;
        }

        protected virtual void RecordLocation(GLocation Loc)
        {
        }

        protected virtual void UberCreateDefaultConfig()
        {
        }

        protected virtual void UberLoadConfig()
        {
        }

        protected virtual void UberSendToDialog(object configDialog)
        {
        }

        protected virtual void UberGetFromDialog(object configDialog)
        {
        }

        protected virtual void UpdateMyPos()
        {
        }

        #endregion

        #region Special Moves
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Approach - Approaches a GUnit
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool USEOOBERAPPROACH = true;
        protected bool FailedApproach = false;
        protected bool CLOSERPVP = true;
        protected double MaxWander = 60;
        protected GLocation startLocation;
        protected bool Approach(GUnit Target)
        {
            return Approach(Target, 4.5, true, 5000);
        }

        protected bool Approach(GUnit Target, double MinDistGiven)
        {
            return Approach(Target, MinDistGiven, true, 5000);
        }

        protected bool Approach(GUnit Target, double MinDistGiven, bool bStopWhenDone)
        {
            return Approach(Target, MinDistGiven, bStopWhenDone, 5000);
        }

        GSpellTimer CheckAlts = new GSpellTimer(1000, true);
        GSpellTimer CheckApproach = new GSpellTimer(1000, true);
        protected bool Approach(GUnit Target, double MinDistGiven, bool bStopWhenDone, int Timeout)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;

            if (USEOOBERAPPROACH)
            {
                double MinDist = 4.5;
                if (MinDistGiven > MinDist) MinDist = MinDistGiven;
                Me.Refresh(true);
                Target.Refresh(true);
                if (Target.DistanceToSelf <= MinDist) return true;
                OOberLog("Approaching...");
                OOberLog("Target Dist:" + Target.DistanceToSelf + " vs " + MinDist);
                //if (mover == null) mover = new Mover(Context); 
                GLocation closestWP;
                FailedApproach = false;
                GSpellTimer Futile = new GSpellTimer(Timeout, false);
                int bDone = 0;
                //if (Target.DistanceToSelf > MinDist) mover.Forwards(true);
                while (bDone == 0)
                {
                    Me.Refresh(true);
                    Target.Refresh(true);
                    if (Futile.IsReady) bDone = 2;
                    if (Me.IsDead) bDone = 8;
                    if (Target.IsDead) bDone = 3;
                    if (!Target.IsValid) bDone = 6;
                    if (Target.DistanceToSelf <= MinDist) bDone = 1;
                    if (Target.DistanceToSelf > (PullDistance + 15)) bDone = 7;
                    closestWP = Context.Profile.FindClosestWaypoint(Me.Location);
                    if (Context.CurrentMode != GGlideMode.OneKill && closestWP != null && closestWP.DistanceToSelf > MaxWander) bDone = 4;
                    if (IsStuck(Me.Location)) bDone = 5;
                    if (Target.IsPlayer && CLOSERPVP && CheckAlts.IsReady)
                    {
                        GPlayer topwn = GetClosestPvPPlayer();
                        if (topwn != null && topwn.GUID != Target.GUID && Target.DistanceToSelf > 5)
                        {
                            if (topwn.SetAsTarget(false)) bDone = 9;
                        }
                        CheckAlts.Reset();
                    }
                    if (bDone == 0)
                    {
                        if (Math.Abs(Target.Bearing) > (Math.PI / 12))
                        {
                            OOberLog("AntiCircle.  Target Bearing:" + Target.Bearing);
                            mover.Forwards(false);
                        }
                        Face(Target, 250, (Math.PI / 12));
                        RecordLocation(Me.Location);
                        if (CheckApproach.IsReady)
                        {
                            ApproachingTarget(Target);
                            CheckApproach.Reset();
                        }
                        Thread.Sleep(10);
                        if (Math.Abs(Target.Bearing) < (Math.PI / 12))
                        {
                            //OOberLog("AntiCircle disabled");
                            mover.Forwards(true);
                        }
                        OOberLog("Target Dist:" + Target.DistanceToSelf + " vs " + MinDist);
                    }
                }
                if (bStopWhenDone) mover.Forwards(false);
                if (bDone > 1)
                {
                    FailedApproach = true;
                    mover.Stop();
                }
                if (bDone == 2) { OOberLog("Approach: Timeout"); return false; }
                if (bDone == 3) { OOberLog("Approach: Target Died."); return false; }
                if (bDone == 4) { OOberLog("Approach: Target too far from closest waypoint"); return false; }
                if (bDone == 5) { OOberLog("Approach: I'm Stuck"); return false; }
                if (bDone == 6) { OOberLog("Approach: Target Invalid"); return false; }
                if (bDone == 7) { OOberLog("Approach: Target too far from me"); return false; }
                if (bDone == 8) { OOberLog("Approach: I'm Dead!"); return false; }
                if (bDone == 9) { OOberLog("Approach: Found Closer PvP Target"); return false; }
                return true;
            }

            //Standard Approach
            Target.Approach(MinDistGiven, !bStopWhenDone);
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // BackUp - Backup from a monster
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void BackUp(GUnit Target)
        {
            BackUp(Target, false);
        }

        protected void BackUp(GUnit Target, bool WithJump)
        {
            if (Target == null) return;
            if (!Target.IsValid) return;
            TargetWasClose = false;
            Face(Target);
            mover.Backwards(true);
            if (WithJump) mover.Jump();
            GSpellTimer DoBackup = new GSpellTimer(1000);
            DoBackup.Wait();
            mover.Backwards(false);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetInFrontOfMe - Repositions to get target in front
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool GetInFrontOfMe(GUnit Target)
        {
            double bearing = Target.Bearing;
            Target.Refresh(true);
            Me.Refresh(true);
            if (IsInFrontOfMe(Target)) return true;
            OOberLog("Target not in front of me!");
            if (Target.DistanceToSelf < 10)
            {
                mover.Backwards(true);
                mover.Jump();
                Thread.Sleep(300);
                Target.Refresh(true);
                Me.Refresh(true);
                if (bearing < 0) mover.RotateLeft(true);
                else mover.RotateRight(true);
                Thread.Sleep(300);
                mover.StopRotate();
                Thread.Sleep(300);
                mover.Backwards(false);
            }
            else return Face(Target);
            return IsInFrontOfMe(Target);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // MoveToGetThemInFront
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public bool MoveToGetThemInFront(GUnit Target, GUnit Add)
        {
            double bearing = Add.Bearing;
            if (!IsInFrontOfMe(Add))
            {
                Context.Log("Got the add " + Add.Name + " behind me");
                /*
                  hmm, just back up? or turn a bit too?
                */

                mover.Backwards(true);
                if (bearing < 0)
                {
                    Context.Log("  back up left");
                    mover.RotateLeft(true);
                }
                else
                {
                    Context.Log("  back up right");
                    mover.RotateRight(true);
                }
                Thread.Sleep(300);
                mover.RotateLeft(false);
                mover.RotateRight(false);
                Thread.Sleep(300);
                mover.Backwards(false);
                return true;
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetIntoMeleeSight - Repositions to get target into Melee Sight
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool GetIntoMeleeSight(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            Target.Refresh(true);
            Me.Refresh(true);
            if (!GetInFrontOfMe(Target)) return false;
            if (Target.DistanceToSelf > 4)
                if (!Approach(Target, 4)) return false;
            DodgeAndMove(Target);
            if (!GetInFrontOfMe(Target)) return false;
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // ConsiderAvoidAdds - Avoid Adds
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //const double AVOID_ADD_HEADING_TOLERANCE = 1.04;  // About 120 (60 each way = PI/3) degree arc in front of us.
        GSpellTimer AddBackup = new GSpellTimer(4 * 1000, true);
        protected bool AVOIDADDS = false;
        protected int AVOIDADDSDISTANCE = 30;
        protected void ConsiderAvoidAdds(GUnit Target)
        {
            if (!AVOIDADDS) return;
            GObjectList.SetCacheDirty();
            GUnit[] adds = GObjectList.GetLikelyAdds();
            //OOberLog("Potential Adds:"+adds.Length);
            if (adds.Length == 0) return;

            GUnit closestAdd = (GUnit)GObjectList.GetClosest(adds);
            if (closestAdd == null) return;
            if (closestAdd.GUID == Target.GUID) return;

            // Somebody is close enough to maybe jump in.  If the monster is in front of us and close
            // enough, might be time to back it up.

            if (closestAdd.DistanceToSelf < AVOIDADDSDISTANCE &&
                closestAdd.IsApproaching)//&&
            //Math.Abs(closestAdd.Bearing) < AVOID_ADD_HEADING_TOLERANCE)
            {
                OOberLog("Possible add: \"" + closestAdd.Name + "\" (distance = " + closestAdd.DistanceToSelf + ", bearing = " + closestAdd.Bearing + "), backing up combat");
                TargetWasClose = true;  //don't think its a runner
                AddBackup.Reset();
                GSpellTimer Futility = new GSpellTimer(3000);

                TargetWasClose = false;
                mover.Backwards(true);
                //closestAdd.StartSpinTowards();
                Face(closestAdd);

                while (!Futility.IsReadySlow)
                {
                    //if (Math.Abs(closestAdd.Bearing) < (Math.PI / 10))  // Fairly straight on.
                    //mover.Stop();
                    Face(closestAdd);

                    if (closestAdd.DistanceToSelf > AVOIDADDSDISTANCE + 6.0)  // Slack space.
                        break;
                }

                //mover.Stop();
                mover.Backwards(false);

                if (Futility.IsReady)
                    OOberLog("Backed up for max time, stopping");

                //Thread.Sleep(601);

                AddBackup.Reset();
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsRunningAway - Runner Detection
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        bool TargetWasClose;
        Int64 LastTargetGUID;
        GLocation TargetAnchor;
        protected bool IsRunningAway(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            bool TargetIsClose;
            bool IsRunning = false;
            //Reset Flag as Needed
            if (LastTargetGUID != Target.GUID)
            {
                LastTargetGUID = Target.GUID;
                TargetWasClose = false;
                TargetAnchor = Target.Location;
            }

            //Figure out if Target IS Close
            TargetIsClose = false;
            if (Target.DistanceToSelf < Context.MeleeDistance)
            {
                TargetIsClose = true;
            }

            //Figure out if Target is Running
            if (TargetWasClose && (TargetAnchor != null && TargetAnchor.GetDistanceTo(Target.Location) > Context.MeleeDistance))
            {
                IsRunning = true;
                TargetWasClose = false;
            }

            //Reset for next time
            if (TargetIsClose)
            {
                TargetAnchor = Target.Location;
                TargetWasClose = true;
            }

            return IsRunning;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // DodgeAndMove - Repositions to get target into Melee Sight
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool USEDODGEANDMOVE = true;
        Random DAMrandom = new Random();
        protected void DodgeAndMove(GUnit Target)
        {
            if (!USEDODGEANDMOVE) return;
            if (!Target.IsPlayer) return;
            TargetWasClose = false;
            int dir = DAMrandom.Next(1, 2);
            int dur = DAMrandom.Next(250, 2000);
            OOberLog("Dodge & Move!");
            if (dir == 1)
            {
                mover.StrafeLeft(true);
                mover.RotateRight(true);
            }
            else
            {
                mover.StrafeLeft(true);
                mover.RotateRight(true);
            }
            Thread.Sleep(dur);
            if (dir == 1)
            {
                mover.StrafeLeft(false);
                mover.RotateRight(false);
            }
            else
            {
                mover.StrafeLeft(false);
                mover.RotateRight(false);
            }
            UpdateMyPos();
        }

        #endregion

        #region Mover Class

        protected static Mover mover;

        public class Mover
        {

            private bool runForwards = false;
            private bool runBackwards = false;
            private bool strafeLeft = false;
            private bool strafeRight = false;
            private bool rotateLeft = false;
            private bool rotateRight = false;

            private const float PI = (float)Math.PI;
            private GContext Context;

            public Mover(GContext Context)
            {
                this.Context = Context;
            }

            private GSpellTimer KeyT = new GSpellTimer(50);
            private bool old_runForwards = false;
            private bool old_runBackwards = false;
            private bool old_strafeLeft = false;
            private bool old_strafeRight = false;
            private bool old_rotateLeft = false;
            private bool old_rotateRight = false;


            void PushKeys()
            {

                if (old_runForwards != runForwards)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (runForwards)
                        PressKey("Common.Forward");
                    else
                        ReleaseKey("Common.Forward");
                    //Context.Log("Forwards: " + runForwards);
                }
                /*

                                if(runForwards)
                                {
                                    GContext.Main.StartRun(); // 
                                }
                                else
                                {
                                    GContext.Main.ReleaseRun(); // 
                                }
                */
                if (old_runBackwards != runBackwards)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (runBackwards)
                        PressKey("Common.Back");
                    else
                        ReleaseKey("Common.Back");
                    //Context.Log("Backwards: " + runBackwards);
                }
                if (old_strafeLeft != strafeLeft)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (strafeLeft)
                        PressKey("Common.StrafeLeft");
                    else
                        ReleaseKey("Common.StrafeLeft");
                    //Context.Log("StrageLeft: " + strafeLeft);
                }
                if (old_strafeRight != strafeRight)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (strafeRight)
                        PressKey("Common.StrafeRight");
                    else
                        ReleaseKey("Common.StrafeRight");
                    //Context.Log("StrageRight: " + strafeRight);
                }

                /*
                                if(rotateRight || rotateLeft)
                                {
                                    double head = GContext.Main.Me.Heading;
                                    if(rotateRight) head -= Math.PI/2;
                                    else if(rotateLeft)  head += Math.PI/2;
                                    GContext.Main.StartSpinTowards(head);
                                }
                                else
                                {
                                    GContext.Main.ReleaseSpin();
                                }
                */

                if (old_rotateLeft != rotateLeft)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (rotateLeft)
                        PressKey("Common.RotateLeft");
                    else
                        ReleaseKey("Common.RotateLeft");
                    //Context.Log("RotateLeft: " + rotateLeft);
                }
                if (old_rotateRight != rotateRight)
                {
                    KeyT.Wait();
                    KeyT.Reset();
                    if (rotateRight)
                        PressKey("Common.RotateRight");
                    else
                        ReleaseKey("Common.RotateRight");
                    //Context.Log("RotateRight: " + rotateRight);
                }

                old_runForwards = runForwards;
                old_runBackwards = runBackwards;
                old_strafeLeft = strafeLeft;
                old_strafeRight = strafeRight;
                old_rotateLeft = rotateLeft;
                old_rotateRight = rotateRight;
            }

            void PressKey(string name)
            {
                //Context.Log("Press : " + name);
                Context.PressKey(name);
            }

            void ReleaseKey(string name)
            {
                //Context.Log("Release: " + name);
                Context.ReleaseKey(name);
            }

            void SendKey(string name)
            {
                //Context.Log("Send: " + name);
                Context.SendKey(name);
            }


            public void Jump()
            {
                SendKey("Common.Jump");
            }

            public void SwimUp(bool go)
            {
                if (go)
                    PressKey("Common.Jump");
                else
                    ReleaseKey("Common.Jump");
            }

            public void ResyncKeys()
            {
                KeyT.ForceReady();
                PushKeys();
            }

            Random random = new Random();
            public void MoveRandom()
            {
                int d = random.Next(4);
                if (d == 0) Forwards(true);
                if (d == 1) StrafeRight(true);
                if (d == 2) Backwards(true);
                if (d == 3) StrafeLeft(true);
            }

            public void StrafeLeft(bool go)
            {
                strafeLeft = go;
                if (go) strafeRight = false;
                PushKeys();
            }

            public void StrafeRight(bool go)
            {
                strafeRight = go;
                if (go) strafeLeft = false;
                PushKeys();
            }

            public void RotateLeft(bool go)
            {
                rotateLeft = go;
                if (go) rotateRight = false;
                PushKeys();
            }


            public void RotateRight(bool go)
            {
                rotateRight = go;
                if (go) rotateLeft = false;
                PushKeys();
            }


            public void Forwards(bool go)
            {
                runForwards = go;
                if (go) runBackwards = false;
                PushKeys();
            }

            public void Backwards(bool go)
            {
                runBackwards = go;
                if (go) runForwards = false;
                PushKeys();
            }

            public void StopRotate()
            {
                rotateLeft = false;
                rotateRight = false;
                PushKeys();
            }

            public void StopMove()
            {
                runForwards = false;
                runBackwards = false;
                strafeLeft = false;
                strafeRight = false;
                rotateLeft = false;
                rotateRight = false;
                SwimUp(false);
                PushKeys();
            }


            public void Stop()
            {
                StopMove();
                StopRotate();
                Context.ReleaseSpinRun();
            }

            public bool IsMoving()
            {
                return runForwards || runBackwards || strafeLeft || strafeRight;
            }


            public bool IsRotating()
            {
                return rotateLeft || rotateRight;
            }

            public bool IsRotatingLeft()
            {
                return rotateLeft;
            }
            public bool IsRotatingRight()
            {
                return rotateLeft;
            }


            /*
              1 - location is front
              2 - location is right
              3 - location is back
              4 - location is left
            */
            int GetLocationDirection(GLocation loc)
            {
                int dir = 0;
                double b = loc.Bearing;
                if (b > -PI / 4 && b <= PI / 4)  // Front
                {
                    dir = 1;
                }
                if (b > -3 * PI / 4 && b <= -PI / 4) // Left
                {
                    dir = 4;
                }
                if (b <= -3 * PI / 4 || b > 3 * PI / 4) //  Back   
                {
                    dir = 3;
                }
                if (b > PI / 4 && b <= 3 * PI / 4) //  Right  
                {
                    dir = 2;
                }
                if (dir == 0)
                    Context.Log("Odd, no known direction");

                return dir;
            }

            public static double GetDistance3D(GLocation l0, GLocation l1)
            {
                double dx = l0.X - l1.X;
                double dy = l0.Y - l1.Y;
                double dz = l0.Z - l1.Z;
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }

            public bool moveTowardsFacing(GPlayerSelf Me, GLocation to, double distance, GLocation facing)
            {
                bool moving = false;
                double d = Me.Location.GetDistanceTo(to);
                if (d > distance)
                {
                    int dir = GetLocationDirection(to);
                    if (dir != 0) moving |= true;
                    if (dir == 1 || dir == 3 || dir == 0) { StrafeLeft(false); StrafeRight(false); };
                    if (dir == 2 || dir == 4 || dir == 0) { Forwards(false); Backwards(false); };
                    if (dir == 1) Forwards(true);
                    if (dir == 2) StrafeRight(true);
                    if (dir == 3) Backwards(true);
                    if (dir == 4) StrafeLeft(true);
                    //Context.Log("Move dir: " + dir);
                }
                else
                {
                    //Context.Log("Move is close");
                    StrafeLeft(false);
                    StrafeRight(false);
                    Forwards(false);
                    Backwards(false);
                }
                double bearing = Me.GetHeadingDelta(facing);
                if (bearing < -PI / 8)
                {
                    moving |= true;
                    RotateLeft(true);
                }
                else if (bearing > PI / 8)
                {
                    moving |= true;
                    RotateRight(true);
                }
                else
                    StopRotate();

                return moving;
            }

            public double GetMoveHeading(out double speed)
            {
                double head = GContext.Main.Me.Heading;
                double r = 0; ;
                speed = 0.0;
                if (runForwards)
                {
                    speed = 7.0; r = head;
                    if (strafeRight) r += PI / 2;
                    if (strafeLeft) r -= PI / 2;
                    if (runBackwards) speed = 0.0;
                }
                else if (runBackwards)
                {
                    speed = 4.5; r = head + PI;
                    if (strafeRight) r -= PI / 2;
                    if (strafeLeft) r += PI / 2;
                    if (runBackwards) speed = 0.0;
                }
                else if (strafeLeft)
                {
                    speed = 7.0; r = head + PI * 3.0 / 4.0;
                    if (strafeRight) speed = 0;
                }
                else if (strafeRight)
                {
                    speed = 7.0; r = head + PI / 4;
                }

                if (head >= 2 * PI) head -= 2 * PI;
                return head;
            }
        }

        #endregion

        #region Popup Window Control

        protected static Popup popup;

        // static methods to handle popups
        public class Popup
        {
            // 1-4
            public static bool IsVisible(int popNr)
            {
                String name = "StaticPopup" + popNr;
                GInterfaceObject obj = GContext.Main.Interface.GetByName(name);
                if (obj != null && obj.IsVisible) return true;
                return false;
            }


            public static bool IsCloseable(int popNr)
            {
                String name = "StaticPopup" + popNr + "CloseButton";
                GInterfaceObject obj = GContext.Main.Interface.GetByName(name);
                if (obj != null && obj.IsVisible) return true;
                return false;
            }


            public static string GetText(int popNr)
            {
                String name = "StaticPopup" + popNr;
                GInterfaceObject obj = GContext.Main.Interface.GetByName(name);
                if (obj == null || !obj.IsVisible) return null;
                GInterfaceObject text = obj.GetChildObject(name + "Text");
                if (text == null) return null;
                return text.LabelText;

            }

            public static bool ClickButton(int popNr, int buttonNr)
            {
                String name = "StaticPopup" + popNr + "Button" + buttonNr;
                GInterfaceObject obj = GContext.Main.Interface.GetByName(name);
                if (obj != null && obj.IsVisible)
                {
                    obj.ClickMouse(false);
                    return true;
                }
                return false;
            }

            public static bool ClickClose(int popNr)
            {
                String name = "StaticPopup" + popNr + "CloseButton";
                GInterfaceObject obj = GContext.Main.Interface.GetByName(name);
                if (obj != null && obj.IsVisible)
                {
                    obj.ClickMouse(false);
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region Config Routines
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetConfigValue - Get Config Value from GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void SendToDialog(object configDialog, string vParameter)
        {
            SetConfigValue(configDialog, vParameter, Context.GetConfigString(vParameter));
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetConfigValue - Get Config Value from GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void GetFromDialog(object configDialog, string vParameter)
        {
            Context.SetConfigValue(vParameter, GetConfigValue(configDialog, vParameter), true);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // SetConfigValue - Set Config Value in GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void SetConfigValue(object configDialog, string vKey, string vValue)
        {
            PropertyInfo pKey;
            PropertyInfo pValue;
            Type type = configDialog.GetType();
            //Setup Entry Points to pass Values
            pKey = type.GetProperty("ConfigKey");
            pValue = type.GetProperty("ConfigValue");
            if (pKey != null && pValue != null)
            {
                pKey.SetValue(configDialog, vKey, null);
                pValue.SetValue(configDialog, vValue, null);
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetConfigValue - Get Config Value from GConfig
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private string GetConfigValue(object configDialog, string vKey)
        {
            PropertyInfo pKey;
            PropertyInfo pValue;
            Type type = configDialog.GetType();
            //Setup Entry Points to pass Values
            pKey = type.GetProperty("ConfigKey");
            pValue = type.GetProperty("ConfigValue");
            if (pKey != null && pValue != null)
            {
                pKey.SetValue(configDialog, vKey, null);
                return (pValue.GetValue(configDialog, null)).ToString();
            }
            return "";
        }

        #endregion

        #region Glider Enhancements
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // OOberLog - Sends Message to appropriate Output
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected string SENDLOGTO = "Debug";
        protected void OOberLog(string Message)
        {
            if (SENDLOGTO == "Debug") Context.Debug(Message);
            if (SENDLOGTO == "Log") Context.Log(Message);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasAdds - Checks if you have Adds
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GSpellTimer AddsCheckDelay = new GSpellTimer(15000, true);
        protected bool HasAdds()
        {
            if (!AddsCheckDelay.IsReady) return true;
            GObjectList.SetCacheDirty();
            GUnit[] attackers = GObjectList.GetAttackers();
            if (attackers.Length > 1)
            {
                AddsCheckDelay.Reset();
                return true;
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TooHigh - Checks if target is too high
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool TooHigh(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            if (Target.Location.Z - Me.Location.Z > 8) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsPlayerFaction - Checks if a unit is alliance or horde
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsPlayerFaction(int faction)
        {
            if (GetMajorFaction(faction) == MajorFaction.Unknown) return false;
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetMajorFaction - Checks if a unit is alliance or horde
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected enum MajorFaction { Unknown, Alliance, Horde };
        protected MajorFaction GetMajorFaction(GUnit Target)
        {
            return GetMajorFaction(Target.FactionID);
        }

        protected MajorFaction GetMajorFaction(int FactionID)
        {
            if (FactionID == 2) return MajorFaction.Horde;  //Orc
            if (FactionID == 5) return MajorFaction.Horde;  //Forsaken (UD)
            if (FactionID == 6) return MajorFaction.Horde;  //Tauren
            if (FactionID == 116) return MajorFaction.Horde;  //Troll
            if (FactionID == 1610) return MajorFaction.Horde;  //Blood Elf

            if (FactionID == 1) return MajorFaction.Alliance;  //Human
            if (FactionID == 3) return MajorFaction.Alliance;  //Dwarf
            if (FactionID == 4) return MajorFaction.Alliance;  //Night Elf
            if (FactionID == 115) return MajorFaction.Alliance;  //Gnome
            if (FactionID == 1629) return MajorFaction.Alliance;  //Dranei

            return MajorFaction.Unknown;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Is Pet - Checks if a unit is a pet
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsPet(GUnit Target)
        {
            if (GetMajorFaction(Target) == MajorFaction.Horde || GetMajorFaction(Target) == MajorFaction.Alliance)
            {
                if (Target.IsMonster && Target.CreatedBy != 0 && Target.CreatureType != GCreatureType.Totem) return true;
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CheckWeaponEnchant - Applies a weapon enchant
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void CheckWeaponEnchant(string Key, string EnchantHas, string Slot)
        {
            //Find Weapon
            long ItemGUID = Context.Items.GetEquippedGUID(Slot);
            if (ItemGUID == 0)
            {
                OOberLog("No item equipped in \"" + Slot + "\"... !?");
                return;
            }

            //Check if Already Enchanted
            int[] Enchants = Context.Items.GetItemEnchants(ItemGUID);
            foreach (int OneEnchant in Enchants)
            {
                string EnchantName = Context.Items.GetEnchantName(OneEnchant);
                if (EnchantName != null && (EnchantName.ToLower().IndexOf(EnchantHas) >= 0)) return;
            }

            OOberLog("Weapon needs enchant in slot: " + Slot);

            //Check if materials ready
            int InvLeft = GetActionInventory(Key);
            if (InvLeft > 1)
            {
                //Select Weapon
                GInterfaceObject CharFrame = Context.Interface.GetByName("CharacterFrame");
                GInterfaceObject SlotSpot = Context.Interface.GetByName("Character" + Slot);

                if (CharFrame == null || SlotSpot == null)
                {
                    OOberLog("Interface angry, couldn't get CharacterFrame or Character" + Slot + "!");
                    return;
                }

                if (!CharFrame.IsVisible)
                {
                    Context.SendKey("Common.Character");

                    Thread.Sleep(1200);

                    if (!CharFrame.IsVisible)
                    {
                        OOberLog("CharFrame never became visible after keystroke!");
                        return;
                    }
                }

                //Apply Enchant:
                Context.SendKey(Key);
                Thread.Sleep(1000);
                SlotSpot.ClickMouse(false);
                Thread.Sleep(1000);

                // Get rid of the character screen and wait for channeling:
                Context.SendKey("Common.Character");
                Thread.Sleep(1000);

                GSpellTimer FutileEnch = new GSpellTimer(9000, false);

                while (!FutileEnch.IsReadySlow && Me.IsCasting && !Me.IsInCombat)
                {
                    if (!Me.IsCasting)
                    {
                        Context.Log("Never entered channeling after oil application!");
                        Context.SendKey("Common.Escape");
                        break;
                    }
                }
                Context.SendKey("Common.Escape");
            }
            else if (InvLeft == 1)
            {
                Context.Log("One or no oil left. Assume it is a macro and click it anyway");
                Context.CastSpell(Key);
                Context.SendKey("Common.Escape"); // to remove the apply oil move, if all is ok glider will handle the dialog popup
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // WaitForGCD - Waits for Cooldown on a specific key
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool WaitForGCD(string name, int time)
        {
            GSpellTimer timeout = new GSpellTimer(time, false);
            while (!Interface.IsKeyReady(name) && !timeout.IsReadySlow) ;
            return Interface.IsKeyReady(name);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // WaitForRageLoss - Waits for Cooldown on a specific key
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool WaitForRageLoss(int time)
        {
            //if (keymasher) return true;
            GSpellTimer timeout = new GSpellTimer(time, false);
            int OldRage = Me.Rage;
            do
            {
                int e = Me.Rage;
                if (e > OldRage)
                {
                    OldRage = e; // Got some rage
                }
                if (e != OldRage)
                {
                    return true;
                }
            }
            while (!timeout.IsReadySlow);
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasBuffType - Returns true if target has a buff of a particular type
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool HasBuffType(GUnit Target, GBuffType BuffType)
        {
            return HasBuffType(Target, BuffType, true);
        }

        protected bool HasBuffType(GUnit Target, GBuffType BuffType, bool OnlyHarmful)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            GBuff[] Buffs = Target.GetBuffSnapshot();
            for (int x = 0; x < Buffs.Length; x++)
            {
                if ((Buffs[x].IsHarmful || !OnlyHarmful) && Buffs[x].BuffType == BuffType) return true;
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsTargettingUs - Returns true if target is attacking you or your party members
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsTargettingUs(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            Target.Refresh(true);
            //Targetting Me?
            if (Target.IsTargetingMe) return true;
            //Targetting My Pet or My Party?
            GUnit SubTarget = Target.Target;
            if (SubTarget != null)
            {
                if (SubTarget.GUID == Target.GUID) return true;                     //Targetting self (aka healer)
                if (SubTarget.CreatedBy == Me.GUID) return true;                    //Targetting something I own
                foreach (GPlayer Guy in Context.Party.GetPartyMemberObjects())
                {
                    //Attacking Party Member?
                    if (SubTarget.GUID == Guy.GUID) return true;                    //Targetting Party Member
                    //Attacking Party Member Pet?
                    if (SubTarget.GUID == Guy.PetGUID) return true;                 //Targetting Party Member Pet
                }
                return false; //someone else got it
            }
            return false; //no one else got it
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsOurs - Returns true if target is attacking you or your party members
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsOurs(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            Target.Refresh(true);
            //Targetting Me?
            if (Target.IsTargetingMe) return true;
            //Targetting My Pet or My Party?
            GUnit SubTarget = Target.Target;
            if (SubTarget != null)
            {
                if (SubTarget.GUID == Target.GUID) return true;                     //Targetting self (aka healer)
                if (SubTarget.CreatedBy == Me.GUID) return true;                    //Targetting something I own
                foreach (GPlayer Guy in Context.Party.GetPartyMemberObjects())
                {
                    //Attacking Party Member?
                    if (SubTarget.GUID == Guy.GUID) return true;                    //Targetting Party Member
                    //Attacking Party Member Pet?
                    if (SubTarget.GUID == Guy.PetGUID) return true;                 //Targetting Party Member Pet
                }
                return false; //someone else got it
            }
            return true; //no one else got it
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CheckForPull - Returns true if target was pulled
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool CheckForPull(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            if (Target.DistanceToSelf > (PullDistance * 1.20)) return false; // Too Far
            if (IsOurs(Target)) return true;
            if (Target.IsPlayer) return true; //Don't care with PVP
            if (IsPet(Target)) return false;  //Don't want to pull pets
            //if (!TriedAttack) return true;
            OOberLog("Failed CheckForPull");
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsImmobilized - returns true if target is immobilized
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsImmobilized(GUnit unit)
        {
            int[] IMMOBILE = {
            339,790,1062,1063,1435,1436,2919,2920,5195,5196,
            5309,9852,9853,9854,9855,11922,12747,19970,19971,
            19972,19973,19974,19975,20654,20699,21331,22127,
            22415,22800,24648,26071,26989,27010,27303,28858,
            31287,32173,33844,37823,40363, //Entangling Roots
            6533,12024,31290,38338,38661,41580, //Net
            122,497,865,866,1194,1225,6131,6132,6644,9915,10230,
            10231,11831,12674,12748,14907,15063,15531,15532,22645,
            27088,27387,29849,30094,31250,32192,32365,34326,36989,
            38033,39035,39063, //Frost Nova
            3355,14308,14309,31932, //Freezing Trap Effect
            2132,5276,9454,16350,18763,18798,18799,27867,
            27868,33395,37871,38035,40875  //Freeze
            };
            unit.Refresh(true);
            unit.SetBuffsDirty();
            if (unit.HasBuff(IMMOBILE)) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // AttackersInRange - returns number of attackers within a specified distance
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected int AttackersInRange(double pRangeToCheck)
        {
            int vrtn = 0;
            GObjectList.SetCacheDirty();
            GUnit[] attackers = GObjectList.GetAttackers();
            foreach (GUnit attacker in attackers)
                if (attacker.DistanceToSelf < pRangeToCheck) vrtn++;
            return vrtn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TargetHasFriends
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool TargetHasFriends(GUnit Target, double ScanDist)
        {
            GObjectList.SetCacheDirty();
            GUnit NextClosest = GObjectList.GetNearestHostile(Target.Location, Target.GUID, false);
            if (NextClosest != null && NextClosest.Location.GetDistanceTo(Target.Location) < ScanDist)
                return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // InFrontOf
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public GLocation InFrontOf(GUnit unit, double d)
        {
            double x = unit.Location.X;
            double y = unit.Location.Y;
            double z = unit.Location.Z;
            double heading = unit.Heading;
            x += Math.Cos(heading) * d;
            y += Math.Sin(heading) * d;

            return new GLocation((float)x, (float)y, (float)z);
        }

        public GLocation InFrontOf(GLocation loc, double heading, double d)
        {
            double x = loc.X;
            double y = loc.Y;
            double z = loc.Z;

            x += Math.Cos(heading) * d;
            y += Math.Sin(heading) * d;

            return new GLocation((float)x, (float)y, (float)z);
        }


        #endregion

        #region Glider Replacements

        public override string DisplayName
        {
            get { return "OOberGameClass"; }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Face - Face a particular Target
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool USEOOBERFACE = true;

        protected bool Face(GUnit Target)
        {
            return Face(Target, 3000, Math.PI / 8);
        }

        protected bool Face(GUnit Target, int timeout)
        {
            return Face(Target, timeout, Math.PI / 8);
        }

        protected bool Face(GUnit Target, int timeout, double tolerance)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;

            if (USEOOBERFACE)
            {
                //GSpellTimer HCTimer = new GSpellTimer(250, false);
                GSpellTimer approachTimeout = new GSpellTimer(timeout, false);
                if (Math.Abs(Target.Bearing) < tolerance) return true;
                do
                {
                    Me.Refresh(true);
                    Target.Refresh(true);
                    if (Me.IsDead || Target.IsDead)
                    {
                        mover.StopRotate();
                        return false;
                    }

                    double b = Target.Bearing;
                    if (b < -tolerance)
                    {
                        mover.RotateLeft(true);
                    }
                    if (b > tolerance)
                    {
                        mover.RotateRight(true);
                    }
                    if (b > -tolerance && b < tolerance)
                    {
                        mover.StopRotate();
                        return true;
                    }
                    UpdateMyPos();
                    Thread.Sleep(5);
                } while (!approachTimeout.IsReady && !Me.IsDead);

                mover.StopRotate();
                OOberLog("Face timed out");
                return false;
            }

            //Standard Face
            Target.Face(tolerance);
            return true;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsInFrontOfMe - Tells us if target is front of you
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsInFrontOfMe(GUnit unit)
        {
            unit.Refresh(true);
            double bearing = unit.Bearing;
            return bearing < Math.PI / 5.0 && bearing > (Math.PI * -1) / 5.0;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasBuffByName - Checks if the player has the buff named
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool HasBuffByName(string Buff)
        {
            int x;
            GBuff[] CurrBuffs = Me.GetBuffSnapshot();
            for (x = CurrBuffs.Length - 1; x >= 0; x--)
                if (CurrBuffs[x].SpellName == Buff) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasSpell - Checks if the player knows the particular spell
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool HasSpell(int SpellID)
        {
            foreach (int SPID in Me.KnownSpells)
                if (SPID == SpellID) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetActionInventory - Check if we got stuff
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected int GetActionInventory(string Item)
        {
            int vrtn = 0;
            try { vrtn = Interface.GetActionInventory(Item); }
            catch { OOberLog("GetActionInventory Can't Read " + Item); vrtn = -1; }
            return vrtn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsKeyReady - IsKeyReady Replacement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsKeyReady(string pCommand)
        {
            bool bRtn = Interface.IsKeyReady(pCommand);
            Thread.Sleep(20);
            bRtn = Interface.IsKeyReady(pCommand); // Checking twice gives the correct result
            if (!bRtn) OOberLog(pCommand + " key NOT ready");
            return bRtn;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsKeyEnabled - IsKeyEnabled Replacement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsKeyEnabled(String key)
        {
            Interface.IsKeyEnabled(key);
            Thread.Sleep(20);
            bool pop = Interface.IsKeyEnabled(key); // Checking twice gives the correct result
            return pop;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsKeyPopulated - IsKeyPopulated Replacement
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsKeyPopulated(String key)
        {
            Interface.IsKeyPopulated(key);
            Thread.Sleep(100);
            return Interface.IsKeyPopulated(key);  // Checking twice gives the correct result
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetNumAdds - tells you how many adds you have
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected int GetNumAdds()
        {
            GObjectList.SetCacheDirty();
            int Extras = GObjectList.GetAttackers().Length - 1;
            return Extras;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetNumAttackers - tells you how many attackers you have
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected int GetNumAttackers()
        {
            GObjectList.SetCacheDirty();
            int Extras = GObjectList.GetAttackers().Length;
            return Extras;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasAttackers - tells you if you have attackers
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool HasAttackers()
        {
            GObjectList.SetCacheDirty();
            GUnit[] attackers = GObjectList.GetAttackers();
            if (attackers.Length > 0) return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // HasNonPetAttackers - tells you if you have attackers
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool HasNonPetAttackers()
        {
            GObjectList.SetCacheDirty();
            GUnit[] attackers = GObjectList.GetAttackers();
            foreach (GUnit Attacker in attackers)
            {
                if (Attacker.CreatedBy == 0) return true;
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsMounted - Mount Detection
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected string MOUNTNAME = "ZZZ";

        protected bool IsMounted()
        {
            return IsMounted(Me);
        }

        protected bool IsMounted(GUnit Unit)
        {
            Unit.SetBuffsDirty();
            GBuff[] buffs = Unit.GetBuffSnapshot();
            for (int i = 0; i < buffs.Length; i++)
            {
                GBuff b = buffs[i];
                string s = b.SpellName;
                //OOberLog(" buff " + s);
                if (
                   s.Contains(MOUNTNAME) ||
                   s.Contains("Horse") ||
                   s.Contains("Warhorse") ||
                   s.Contains("Raptor") ||
                   s.Contains("Kodo") ||
                   s.Contains("Wolf") ||
                   s.Contains("Saber") ||
                   s.Contains("Ram") ||
                   s.Contains("Mechanostrider") ||
                   s.Contains("Hawkstrider") ||
                   s.Contains("Elekk") ||
                   s.Contains("Steed") ||
                   s.Contains("Tiger") ||
                   s.Contains("Talbuk") ||
                   s.Contains("Frostsaber") ||
                   s.Contains("Nightsaber") ||
                   s.Contains("Battle Tank") ||
                   s.Contains("Charger") ||
                   s.Contains("Frostwolf") ||
                   s.Contains("Reins") || // yeah right
                   s.Contains("Turtle")  // lol
                    )
                {
                    if (s != "Ghost Wolf") return true;
                }
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TweakMeleePosition - Adjust 
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void TweakMeleePosition(GUnit Target)
        {
            if (Target == null) return;
            if (!Target.IsValid) return;
            Target.Refresh(true);
            Me.Refresh(true);
            Face(Target);
            if (Target.DistanceToSelf < 1.25)
            {
                mover.Backwards(true);
                GSpellTimer DoBackup = new GSpellTimer(250);
                DoBackup.Wait();
                mover.Backwards(false);
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TweakMelee
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void TweakMelee(GUnit Monster)
        {
            double Distance = Monster.DistanceToSelf;
            double sensitivity = 2.5; // default melee distance is 4.8 - 2.5 = 2.3, no monster will chase us at 2.3
            double min = Context.MeleeDistance - sensitivity;
            if (min < 1.0) min = 1.0;

            if (Distance > Context.MeleeDistance)
            {
                // Too far
                //Spam("Tweak forwards. "+ Distance + " > " + Context.MeleeDistance);
                mover.Forwards(true);
                Thread.Sleep(100);
                mover.Forwards(false);
            }
            else if (Distance < min)
            {
                // Too close
                //Spam("Tweak backwards. "+ Distance + " < " + min);
                mover.Backwards(true);
                Thread.Sleep(200);
                mover.Backwards(false);
            }
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetClosestPvPPlayer - Find the closest PVP player
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GPlayer GetClosestPvPPlayer()
        {
            GObjectList.SetCacheDirty();
            GPlayer[] plys = GObjectList.GetPlayers();
            GPlayer ClosestPlayer = null;
            MajorFaction MyMajorFaction = GetMajorFaction(Me);
            OOberLog("Checking " + plys.Length.ToString() + " Players...");
            foreach (GPlayer p in plys)
            {
                if (GetMajorFaction(p) != MyMajorFaction && !IsPet(p))
                {
                    if (ClosestPlayer == null || p.GetDistanceTo(Me) < ClosestPlayer.GetDistanceTo(Me))
                        ClosestPlayer = p;
                }
            }
            return ClosestPlayer;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetClosestPvPPlayerAttackingMe - Find the closest PVP player
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GPlayer GetClosestPvPPlayerAttackingMe()
        {
            GPlayer[] plys = GObjectList.GetPlayers();
            GPlayer ClosestPlayer = null;

            foreach (GPlayer p in plys)
            {
                if (!p.IsSameFaction && p.Target == Me)
                {
                    if (ClosestPlayer == null || p.GetDistanceTo(Me) < ClosestPlayer.GetDistanceTo(Me))
                        ClosestPlayer = p;
                }
            }
            return ClosestPlayer;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // DistanceToClosestHostileFrom - Find the closest hostile distance
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public double DistanceToClosestHostileFrom(GUnit target)
        {

            GMonster m = GObjectList.GetNearestHostile(target.Location, target.GUID, false);
            if (m != null)
                return m.GetDistanceTo(target);
            else
                return 1E100;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // FindAttacker - Find Mob attacking me
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public GUnit FindAttacker()
        {
            // Find attackers
            GUnit attacker = GObjectList.GetNearestAttacker(0);
            if (attacker != null)
            {
                if (attacker.IsPlayer)
                {
                    // hmmm
                    if (attacker.IsInCombat &&
                        attacker.Target != null &&
                        attacker.Target == GContext.Main.Me)
                    {
                        // looks like this sucker is attacking me!
                        return attacker;
                    }
                }
                else
                {
                    return attacker; // a monster
                }
            }
            return null;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetClosestFriendlyPlayer - Find the closest friendly player
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GPlayer GetClosestFriendlyPlayer()
        {
            GObjectList.SetCacheDirty();
            GPlayer[] plys = GObjectList.GetPlayers();
            GPlayer ClosestPlayer = null;
            MajorFaction MyMajorFaction = GetMajorFaction(Me);

            foreach (GPlayer p in plys)
            {
                if (GetMajorFaction(p) == MyMajorFaction && p != Me && !IsPet(p))
                {
                    if (ClosestPlayer == null || p.GetDistanceTo(Me) < ClosestPlayer.GetDistanceTo(Me))
                        ClosestPlayer = p;
                }
            }
            return ClosestPlayer;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // GetClosestFriendlyPlayer - Find the closest friendly player
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected GPlayer GetClosestPlayer()
        {
            GObjectList.SetCacheDirty();
            GPlayer[] plys = GObjectList.GetPlayers();
            GPlayer ClosestPlayer = null;

            foreach (GPlayer p in plys)
            {
                if (p != Me)
                {
                    if (ClosestPlayer == null || p.GetDistanceTo(Me) < ClosestPlayer.GetDistanceTo(Me))
                        ClosestPlayer = p;
                }
            }
            return ClosestPlayer;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TargetUnit - Targets a specified Unit
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected void TargetUnit(GUnit Target, bool FirstTarget)
        {
            if (Target == null) return;
            if (!Target.IsValid) return;
            Target.Refresh(true);
            if (Target.IsDead || (Me.TargetGUID == Target.GUID)) return;
            Face(Target);
            Target.SetAsTarget(FirstTarget);
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // TargetFriendly - Targets a friendly Unit
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool TargetFriendly(GUnit Target)
        {
            if (Target == null) return false;
            if (!Target.IsValid) return false;
            Target.Refresh(true);
            if (Target.IsDead) return false;
            GSpellTimer Timeout = new GSpellTimer(3000, false);
            long FirstUnit = Me.TargetGUID;
            while (!Timeout.IsReady)
            {
                Me.Refresh(true);
                if (Me.TargetGUID == Target.GUID) { Face(Target); return true; }
                if (FirstUnit == 0)
                {
                    FirstUnit = Me.TargetGUID;
                }
                else
                {
                    if (Me.TargetGUID == FirstUnit && Me.TargetGUID != 0) return false; //Went through all friendlies
                }
                Context.SendKey("Common.TargetFriendly");
                Thread.Sleep(20);
            }
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // BearingToMe - returns the bearing of a target from me
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected double BearingToMe(GUnit unit)
        {
            GLocation MyLocation = Me.Location;
            float bearing = (float)unit.GetHeadingDelta(MyLocation);
            return bearing;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsFacingAway - returns true if target is facing away
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected bool IsFacingAway(GUnit unit)
        {
            Me.Refresh(true);
            unit.Refresh(true); // we can at least try to have glider give me correct information
            double b = BearingToMe(unit);
            if (b > Math.PI * 3.0 / 5.0 || b < (-1 * Math.PI) * 3.0 / 5.0)
                return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsHordePlayerFaction
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected static bool IsHordePlayerFaction(GUnit u)
        {
            int f = u.FactionID;
            if (f == 2 ||
                f == 5 ||
                f == 6 ||
                f == 116 ||
                f == 1610)
                return true;
            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsAlliancePlayerFaction
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected static bool IsAlliancePlayerFaction(GUnit u)
        {
            int f = u.FactionID;
            if (f == 1 ||
                f == 3 ||
                f == 4 ||
                f == 115 ||
                f == 1629)
                return true;

            return false;
        }

        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // IsPlayerFaction
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        protected static bool IsPlayerFaction(GUnit u)
        {
            return IsHordePlayerFaction(u) || IsAlliancePlayerFaction(u);
        }

        #endregion

    }

}