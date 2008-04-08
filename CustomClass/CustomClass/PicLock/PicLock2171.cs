using System;
using System.Threading;
using Glider.Common.Objects;
using System.Collections.Generic;
using System.Reflection;


// Notes for next release: 2.18 - we need to add SearingPain and Howl of Terror logic
// Need to add combat log parsing for new spell resists
// Add debug option for log entries
// Add new dump target logic
// Fix logic for SoulLink ( if the demon is banished we spam soullink)

/* Adding in change notes versioning reference so that if searched one can find
 * all references with the following find.
 * 2.17.1 A - This will get you the changes as follows:
 * change set =  2.17.1 
 * change set fix = A
 */

/* 2.17.1 - RecursiveBot
 * Overall Update: 
 * This update is for fixes and tests to a few tweaked systems and has only been tested in PVE.
 * Casting Additions:
 * A. added randomizer to options and implemented bool to control this.
 * 
 * Issues Fixed:
 * B. quick fix implemented for summon pet while mounted problems
 * D. fixed a problem with the pet logic on casting that would 
 *    not send in the pet after dismounting and starting to cast.(quickfix)
 * E. Fix for Mount key nameing convention ( aka Piclock.Mount -> PL.Mount )
 *    1. You must change Piclock.Mount -> PL.Mount in Keys.xml
 * H. DrainLife() function shouldn't cause an exception that will stop gliding now.
 * 
 * 
 * Additions:
 * C. Added Bloodfury option to options (PicLock.xml)
 * F. Additional securing of logic to ensure that we don't mount in front of a 
 *    non hostile profile mob then dismount immediately. ( This checks if a faction of your profile
 *    is atleast within range set in the Distance mount option so there is 
 *    Questionable performance if in a BG and You don't have the faction of a target to kill.
 *    aka set it to delay mount and be done.)
 *    1. If you use Distance Mount, YOU MUST set this to be the range from your character to check
 *       for ProfileTargets before mounting. 
 *       EX. Setting "Delay In (s) OR Distance In (yds) for BTM" in the options to 100 will check 
 *           for any target within 100units that is specified in your profile options.
 * G. Fix for multiple pet attacks being sent with recent additions. 
 */

namespace Glider.Common.Objects
{
     public class PicLock : GGameClass
    {
        string classname = "Piclock";
        string version = "2.17.1 ";

        #region Variables and Declarations

        //Timer Group 1 (Mostly support/buffs/setup)
        GSpellTimer Potion = new GSpellTimer(2 * 60 * 1000, true);
        GSpellTimer Healthstone = new GSpellTimer(2 * 60 * 1000, true);
        GSpellTimer EatOrDrinkWait = new GSpellTimer(30 * 1000, true);
        GSpellTimer AmplifyCurse = new GSpellTimer(180 * 1000, false);
        GSpellTimer BloodFury = new GSpellTimer(120 * 1000, false);
        GSpellTimer ArmorBuff = new GSpellTimer(20 * 60 * 1000, true);
        GSpellTimer FelDomination = new GSpellTimer(15 * 60 * 1000, false);
        GSpellTimer VoidwalkerSacrifice = new GSpellTimer(60 * 1000, true);
        GSpellTimer ConsumeShadows = new GSpellTimer(8 * 1000, true);
        GSpellTimer TwoSecTimer = new GSpellTimer(2 * 1000, true);
        GSpellTimer OneSecTimer = new GSpellTimer(1 * 1000, true);
        GSpellTimer PVPTimer = new GSpellTimer(2 * 60 * 1000, false);
        GSpellTimer GlobalCooldown;
        
        
        //Timer Group 2 (Mostly Offense/Combat)
        GSpellTimer CurseOfRecklessness = new GSpellTimer(2 * 60 * 1000, true);
        GSpellTimer UnstableAffliction = new GSpellTimer(18 * 1000, true);
        GSpellTimer Corruption = new GSpellTimer(18 * 1000, true);
        GSpellTimer CurseOfAgony = new GSpellTimer(24 * 1000, true);
        GSpellTimer SiphonLife = new GSpellTimer(30 * 1000, true);
        GSpellTimer Immolate = new GSpellTimer(15 * 1000, true);
        GSpellTimer Fear = new GSpellTimer(10 * 1000, true);
        //GSpellTimer HowlOfTerror = new GSpellTimer(40 * 1000, true);
        GSpellTimer DeathCoil = new GSpellTimer(2 * 60 * 1000, true);
        GSpellTimer Shadowburn = new GSpellTimer(15 * 1000, true);
        GSpellTimer Conflagurate = new GSpellTimer(10 * 1000, true);
        GSpellTimer ShadowBolt = new GSpellTimer(1 * 1000 , true);
        GSpellTimer Incinerate = new GSpellTimer(1 * 1000, true);
        GSpellTimer SearingPain = new GSpellTimer(1 * 1000, true);
        
        //Declarations
         /// <summary>
         /// This bool will be used in the calculation of needtoloot. 
         /// True = there is a target within range. This implies do not mount
         /// False = there is not a target within range. This implies mount.
         /// </summary>
         bool ProfileTargetIsWithinRange = true;
        bool bIsEating;
        bool bIsDrinking;
        public bool ForceCurseOfAgony = false;
        public bool ForceCorruption = false;
        public bool ForceSiphonLife = false;
        public bool ForceCurseOfRecklessness = false;
        public bool ForceImmolate = false;
        public bool ForceUnstableAffliction = false;
        public bool ForceConflagurate = false;
        public bool ForceIncinerate = false;
        public bool ForceDeathcoil = false;
        public bool ForceShadowBolt = false;
        public bool ForceShadowburn = false;

        long[] CastedAdds = new long[50];               
        int CastedAddsIndex = 0;                       
        bool HasWrongPet = false;			       
        bool DoReturnPet = true;			           
        int SoulShardCount = 0;
        int[] ShadowTranceSpellID = { 17941, 33219 };	
        int[] SoulLinkSpellID = { 19028, 25228 }; 		
        double PullDistanceTemp = 25;		          

        //Limit Variables
        double ShadowBoltRange = 30;		//Max range at which to cast Shadow Bolt
        double FearRange = 25;			    //Max range at which to cast Fear
        //double DeathCoilRange = 30;         //Max range at which to cast Death Coil     
        //double HOTRange = 10;               //Max range at which to cast Howl of Terror    
        //double ShadowburnRange = 20;        //Max range at which to cast Shadowburn    
        //double IncinerateRange = 30;        //Max range at which to cast Incinerate
        //double ConflagurateRange = 30;      //Max range at which to cast Conflagurate
        //double SearingPainRange = 30;       //Max range at which to cast Searing Pain
        double HealthFunnelRange = 20;		//Max range at which to cast Health Funnel
        double MaintainPetMana = 0.2;		//Pet mana to maintain (only used for Dark Pact)
        double HealthToReturnPet = 0.4;		//Target health to return pet
        int MISCDELAY = 250;                //Misc Delay used for several waits
        int PET_AGGRO_DELAY = 10; //Time to wait for Pet to pick up Aggro default = 1 second (1000)

        //UI variables
        bool USE_SPELLSHUFFLE = true;       //Randomize Spells
        bool INITIATE_PVP = false;          //Initiate PvP
        int LEVEL_DIFFERENCE = 5;           //Level difference to PvP
        bool USE_CONSUMESHADOWS = false;    //Use Consume Shadows
        double CONSUMESHADOWS_PCT = 70;     //Pet health % at which to do Consume Shadows
        bool CAST_ADDS = false;             //Do CastSequence on adds before Fear
        string LAST_RESORT = "Wand";        //If nothing can cast, what to do... ("Wand", "Melee", "None")
        bool WAIT_FOR_PET_AGGRO = false;	//Wait for pet to approach/attack the target first
        bool FIGHT_BACK = false;			//Fight back against players (Might not work well)
        bool RETURN_PET = false;			//After building aggro, make pet follow, drawing mob back
        bool USE_DARKPACT = false;			//Use Dark Pact
        bool SIT_TO_REGEN = false;			//Sit if there is no food or drink
        string PRIMARY_ATTACK = "Wand";     //Primary attack: "Drain Life", "Wand", "Shadow Bolt"
        double EMERGENCY_HEALTH = 20;	    //Health % at which to use potion or healhstone
        double MIN_HEALTH_PCT = .60;		    //Health % to keep (Life Tap, Funnel Health, etc)
        double MIN_MANA_PCT = .20;		    //Mana % to keep (spells)
        bool USE_FOOD = true;			    //Use food
        bool USE_DRINK = true;			    //Use drink
        bool USE_HEALTHPOTION = false;	    //Use health potion
        bool USE_HEALTHSTONE = true;	    //Use Healthstone
        int SPELL_DELAY = 75;				//Time (ms) to sleep after Interface.WaitForReady before sending key (avoid spell not ready)
        string SUMMON_DEMON = "Voidwalker";	//Voidwalker, Imp, Felguard, Succubus, Felhunter
        bool USE_HEALTHFUNNEL = false;		//Health Funnel
        double HEALTHFUNNEL_PCT = 50;		//Pet Health % at which to Health Funnel
        bool PET_ATTACK = true;				//Pet attack
        int WAIT_FOR_PET = 0;				//Time (ms) to wait between sending pet to attack and casting spells
        bool USE_FELDOMINATION = false;		//Use Fel Domination
        bool USE_SOULLINK = false;			//Use Soul Link
        string USE_SACRIFICE = "None";	    //Use Sacrifice ("Demonic" - Demonic Sacrifice, "Void" - Voidwalker Sacrifice, "None" - None)
        double SACRIFICE_PCT = 10;			//Pet Health % at which to sacrifice
        double MIN_MOB_HEALTH_PCT = .20;		//Minimum amount of health to cast any spell (except Drain Soul & Wand)
        int SOULSHARDS_MAX = 3;				//Number of Soul Shards to maintain
        double DRAINSOUL_PCT = 30;			//Health % to Drain Soul
        bool USE_ARMORBUFF = true;			//Use Armor Buff (Demon Armor, Fel Armor, etc.)
        bool USE_DRAINLIFE = true;			//Use Drain Life
        double DRAINLIFE_PCT = 80;			//Health % to Drain Life
        bool USE_DRAINMANA = false;			//Drain Mana
        double DRAINMANA_PCT = 60;			//Mana % to Drain Mana
        bool USE_FEEDMANA = false;			//Use Feed Mana
        double FEEDMANA_PCT = 20;			//Pet Mana % at which to Drain Mana or Life Tap
        bool USE_LIFETAP = true;			//Use Life Tap
        bool USE_NIGHTFALL = false;			//Use Nightfall
        bool USE_BLOODFURY = false;			//Use Blood Fury
        bool DEAL_WITH_ADDS = false;		//Fight adds
        bool USE_FEAR = false;				//Fear adds
        bool RESUMMON_IN_COMBAT = true;		//Resummon demon in combat
        bool USE_UNSTABLEAFFLICTION = false;    //Use Unstable Affliction
        bool USE_CORRUPTION = false;            //Use Corruption  
        bool USE_CURSEOFAGONY = false;          //Use Curse of Agony
        bool USE_SIPHONLIFE = false;            //Use Siphon Life
        bool USE_IMMOLATE = false;              //Use Immolate
        bool USE_SHADOWBURN = false;            //Use Shadowburn
        bool USE_SHADOWBOLT = true;             //Use ShadowBolt
        //bool USE_HOWLOFTERROR = false;      //Use Howl of Terror
        bool USE_DEATHCOIL = false;         //Use Death Coil
        bool USE_CONFLAGURATE = false;         //Use Conflagurate (Destruction)
        bool USE_INCINERATE = false;         //Use Incinerate (Everyone)
        bool USE_AMPLIFYCURSE = false;		//Use Amplify Curse 

        //Target Dump Distance
        int TARGET_DUMP_DISTANCE = 15;      //Distance moved from start point of combat to dump target
        
        //Combat Spell order array
        string[] SPELL_ORDER = new string[15];
        
        #endregion Variables and Declarations

        #region Custom Config Dialog


        //Create all of the custom config values to be stored in Glider.config.xml
        public override void CreateDefaultConfig()
        {
            Context.SetConfigValue("PicLock.USE_SPELLSHUFFLE", USE_SPELLSHUFFLE.ToString(), false);
            Context.SetConfigValue("PicLock.MISCDELAY", MISCDELAY.ToString(), false);
            Context.SetConfigValue("PicLock.PULL_DISTANCE", PullDistanceTemp.ToString(), false);
            Context.SetConfigValue("PicLock.WAIT_FOR_PET", WAIT_FOR_PET.ToString(), false);
            Context.SetConfigValue("PicLock.SPELL_DELAY", SPELL_DELAY.ToString(), false);
            Context.SetConfigValue("PicLock.USE_FOOD", USE_FOOD.ToString(), false);
            Context.SetConfigValue("PicLock.USE_DRINK", USE_DRINK.ToString(), false);
            Context.SetConfigValue("PicLock.USE_HEALTHPOTION", USE_HEALTHPOTION.ToString(), false);
            Context.SetConfigValue("PicLock.USE_HEALTHSTONE", USE_HEALTHSTONE.ToString(), false);
            Context.SetConfigValue("PicLock.EMERGENCY_HEALTH", EMERGENCY_HEALTH.ToString(), false);
            Context.SetConfigValue("PicLock.MIN_HEALTH_PCT", MIN_HEALTH_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.MIN_MANA_PCT", MIN_MANA_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.PRIMARY_ATTACK", PRIMARY_ATTACK, false);
            Context.SetConfigValue("PicLock.SUMMON_DEMON", SUMMON_DEMON, false);
            Context.SetConfigValue("PicLock.MIN_MOB_HEALTH_PCT", MIN_MOB_HEALTH_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.PET_ATTACK", PET_ATTACK.ToString(), false);
            Context.SetConfigValue("PicLock.USE_FELDOMINATION", USE_FELDOMINATION.ToString(), false);
            Context.SetConfigValue("PicLock.USE_SOULLINK", USE_SOULLINK.ToString(), false);
            Context.SetConfigValue("PicLock.USE_ARMORBUFF", USE_ARMORBUFF.ToString(), false);
            Context.SetConfigValue("PicLock.USE_NIGHTFALL", USE_NIGHTFALL.ToString(), false);
            Context.SetConfigValue("PicLock.USE_BLOODFURY", USE_BLOODFURY.ToString(), false);
            Context.SetConfigValue("PicLock.USE_AMPLIFYCURSE", USE_AMPLIFYCURSE.ToString(), false);
            Context.SetConfigValue("PicLock.DEAL_WITH_ADDS", DEAL_WITH_ADDS.ToString(), false);
            Context.SetConfigValue("PicLock.USE_FEAR", USE_FEAR.ToString(), false);
            Context.SetConfigValue("PicLock.USE_HEALTHFUNNEL", USE_HEALTHFUNNEL.ToString(), false);
            Context.SetConfigValue("PicLock.HEALTHFUNNEL_PCT", HEALTHFUNNEL_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.USE_DRAINLIFE", USE_DRAINLIFE.ToString(), false);
            Context.SetConfigValue("PicLock.DRAINLIFE_PCT", DRAINLIFE_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.USE_DRAINMANA", USE_DRAINMANA.ToString(), false);
            Context.SetConfigValue("PicLock.DRAINMANA_PCT", DRAINMANA_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.USE_LIFETAP", USE_LIFETAP.ToString(), false);
            Context.SetConfigValue("PicLock.USE_FEEDMANA", USE_FEEDMANA.ToString(), false);
            Context.SetConfigValue("PicLock.FEEDMANA_PCT", FEEDMANA_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.USE_SACRIFICE", USE_SACRIFICE.ToString(), false);
            Context.SetConfigValue("PicLock.SACRIFICE_PCT", SACRIFICE_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.SOULSHARDS_MAX", SOULSHARDS_MAX.ToString(), false);
            Context.SetConfigValue("PicLock.DRAINSOUL_PCT", DRAINSOUL_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.RESUMMON_IN_COMBAT", RESUMMON_IN_COMBAT.ToString(), false);
            Context.SetConfigValue("PicLock.SIT_TO_REGEN", SIT_TO_REGEN.ToString(), false);
            Context.SetConfigValue("PicLock.USE_DARKPACT", USE_DARKPACT.ToString(), false);
            Context.SetConfigValue("PicLock.RETURN_PET", RETURN_PET.ToString(), false);
            Context.SetConfigValue("PicLock.FIGHT_BACK", FIGHT_BACK.ToString(), false);
            Context.SetConfigValue("PicLock.WAIT_FOR_PET_AGGRO", WAIT_FOR_PET_AGGRO.ToString(), false);
            Context.SetConfigValue("PicLock.LAST_RESORT", LAST_RESORT.ToString(), false);
            Context.SetConfigValue("PicLock.CAST_ADDS", CAST_ADDS.ToString(), false);
            Context.SetConfigValue("PicLock.USE_CONSUMESHADOWS", USE_CONSUMESHADOWS.ToString(), false);
            Context.SetConfigValue("PicLock.CONSUMESHADOWS_PCT", CONSUMESHADOWS_PCT.ToString(), false);
            Context.SetConfigValue("PicLock.LEVEL_DIFFERENCE", LEVEL_DIFFERENCE.ToString(), false);
            Context.SetConfigValue("PicLock.INITIATE_PVP", INITIATE_PVP.ToString(), false);
//Need to add to Glider.Config.XML
            Context.SetConfigValue("PicLock.USE_UNSTABLEAFFLICTION", USE_UNSTABLEAFFLICTION.ToString(), false);
            Context.SetConfigValue("PicLock.USE_CORRUPTION", USE_CORRUPTION.ToString(), false);
            Context.SetConfigValue("PicLock.USE_CURSEOFAGONY", USE_CURSEOFAGONY.ToString(), false);
            Context.SetConfigValue("PicLock.USE_SIPHONLIFE", USE_SIPHONLIFE.ToString(), false);
            Context.SetConfigValue("PicLock.USE_IMMOLATE", USE_IMMOLATE.ToString(), false);
            Context.SetConfigValue("PicLock.USE_SHADOWBURN", USE_SHADOWBURN.ToString(), false);
            Context.SetConfigValue("PicLock.USE_SHADOWBOLT", USE_SHADOWBOLT.ToString(), false);
            //Context.SetConfigValue("PicLock.USE_HOWLOFTERROR", USE_HOWLOFTERROR.ToString(), false);
            Context.SetConfigValue("PicLock.USE_DEATHCOIL", USE_DEATHCOIL.ToString(), false);
            Context.SetConfigValue("PicLock.USE_CONFLAGURATE", USE_CONFLAGURATE.ToString(), false);
            Context.SetConfigValue("PicLock.USE_INCINERATE", USE_INCINERATE.ToString(), false);
            Context.SetConfigValue("PicLock.PET_AGGRO_DELAY", PET_AGGRO_DELAY.ToString(), false);
            
            //RAGE - Begin
            Context.SetConfigValue("PicLock.TravelForm", "None", false);
            Context.SetConfigValue("PicLock.TravelFormDelay", "45", false);
            Context.SetConfigValue("PicLock.MountName", "", false);
            //RAGE - End
        }

        //Load all custom config values from Glider.config.xml
        public override void LoadConfig()
        {
            USE_SPELLSHUFFLE = Context.GetConfigBool("PicLock.USE_SPELLSHUFFLE");
            MISCDELAY = Context.GetConfigInt("PicLock.MISCDELAY");
            WAIT_FOR_PET = Context.GetConfigInt("PicLock.WAIT_FOR_PET");
            SPELL_DELAY = Context.GetConfigInt("PicLock.SPELL_DELAY");
            USE_FOOD = Context.GetConfigBool("PicLock.USE_FOOD");
            USE_DRINK = Context.GetConfigBool("PicLock.USE_DRINK");
            USE_HEALTHPOTION = Context.GetConfigBool("PicLock.USE_HEALTHPOTION");
            USE_HEALTHSTONE = Context.GetConfigBool("PicLock.USE_HEALTHSTONE");
            EMERGENCY_HEALTH = Context.GetConfigDouble("PicLock.EMERGENCY_HEALTH") / 100;
            MIN_HEALTH_PCT = Context.GetConfigDouble("PicLock.MIN_HEALTH_PCT") / 100;
            MIN_MANA_PCT = Context.GetConfigDouble("PicLock.MIN_MANA_PCT") / 100;
            PRIMARY_ATTACK = Context.GetConfigString("PicLock.PRIMARY_ATTACK");
            SUMMON_DEMON = Context.GetConfigString("PicLock.SUMMON_DEMON");
            MIN_MOB_HEALTH_PCT = Context.GetConfigDouble("PicLock.MIN_MOB_HEALTH_PCT") / 100;
            PET_ATTACK = Context.GetConfigBool("PicLock.PET_ATTACK");
            USE_FELDOMINATION = Context.GetConfigBool("PicLock.USE_FELDOMINATION");
            USE_SOULLINK = Context.GetConfigBool("PicLock.USE_SOULLINK");
            USE_ARMORBUFF = Context.GetConfigBool("PicLock.USE_ARMORBUFF");
            USE_NIGHTFALL = Context.GetConfigBool("PicLock.USE_NIGHTFALL");
            USE_BLOODFURY = Context.GetConfigBool("PicLock.USE_BLOODFURY");
            USE_AMPLIFYCURSE = Context.GetConfigBool("PicLock.USE_AMPLIFYCURSE");
            DEAL_WITH_ADDS = Context.GetConfigBool("PicLock.DEAL_WITH_ADDS");
            USE_FEAR = Context.GetConfigBool("PicLock.USE_FEAR");
            USE_HEALTHFUNNEL = Context.GetConfigBool("PicLock.USE_HEALTHFUNNEL");
            HEALTHFUNNEL_PCT = Context.GetConfigDouble("PicLock.HEALTHFUNNEL_PCT") / 100;
            USE_DRAINLIFE = Context.GetConfigBool("PicLock.USE_DRAINLIFE");
            DRAINLIFE_PCT = Context.GetConfigDouble("PicLock.DRAINLIFE_PCT") / 100;
            USE_DRAINMANA = Context.GetConfigBool("PicLock.USE_DRAINMANA");
            DRAINMANA_PCT = Context.GetConfigDouble("PicLock.DRAINMANA_PCT") / 100;
            USE_LIFETAP = Context.GetConfigBool("PicLock.USE_LIFETAP");
            USE_FEEDMANA = Context.GetConfigBool("PicLock.USE_FEEDMANA");
            FEEDMANA_PCT = Context.GetConfigDouble("PicLock.FEEDMANA_PCT") / 100;
            USE_SACRIFICE = Context.GetConfigString("PicLock.USE_SACRIFICE");
            SACRIFICE_PCT = Context.GetConfigDouble("PicLock.SACRIFICE_PCT") / 100;
            SOULSHARDS_MAX = Context.GetConfigInt("PicLock.SOULSHARDS_MAX");
            DRAINSOUL_PCT = Context.GetConfigDouble("PicLock.DRAINSOUL_PCT") / 100;
            RESUMMON_IN_COMBAT = Context.GetConfigBool("PicLock.RESUMMON_IN_COMBAT");
            SIT_TO_REGEN = Context.GetConfigBool("PicLock.SIT_TO_REGEN");
            USE_DARKPACT = Context.GetConfigBool("PicLock.USE_DARKPACT");
            RETURN_PET = Context.GetConfigBool("PicLock.RETURN_PET");
            FIGHT_BACK = Context.GetConfigBool("PicLock.FIGHT_BACK");
            WAIT_FOR_PET_AGGRO = Context.GetConfigBool("PicLock.WAIT_FOR_PET_AGGRO");
            LAST_RESORT = Context.GetConfigString("PicLock.LAST_RESORT");
            CAST_ADDS = Context.GetConfigBool("PicLock.CAST_ADDS");
            USE_CONSUMESHADOWS = Context.GetConfigBool("PicLock.USE_CONSUMESHADOWS");
            CONSUMESHADOWS_PCT = Context.GetConfigDouble("PicLock.CONSUMESHADOWS_PCT") / 100;
            LEVEL_DIFFERENCE = Context.GetConfigInt("PicLock.LEVEL_DIFFERENCE");
            INITIATE_PVP = Context.GetConfigBool("PicLock.INITIATE_PVP");

            USE_UNSTABLEAFFLICTION = Context.GetConfigBool("PicLock.USE_UNSTABLEAFFLICTION");
            USE_CORRUPTION = Context.GetConfigBool("PicLock.USE_CORRUPTION");
            USE_CURSEOFAGONY = Context.GetConfigBool("PicLock.USE_CURSEOFAGONY");
            USE_SIPHONLIFE = Context.GetConfigBool("PicLock.USE_SIPHONLIFE");
            USE_IMMOLATE = Context.GetConfigBool("PicLock.USE_IMMOLATE");
            USE_SHADOWBURN = Context.GetConfigBool("PicLock.USE_SHADOWBURN");
            USE_SHADOWBOLT = Context.GetConfigBool("PicLock.USE_SHADOWBOLT");
            //USE_HOWLOFTERROR = Context.GetConfigBool("PicLock.USE_HOWLOFTERROR");
            USE_DEATHCOIL = Context.GetConfigBool("PicLock.USE_DEATHCOIL");
            USE_CONFLAGURATE = Context.GetConfigBool("PicLock.USE_CONFLAGURATE");
            USE_INCINERATE = Context.GetConfigBool("PicLock.USE_INCINERATE");

            PET_AGGRO_DELAY = Context.GetConfigInt("PicLock.PET_AGGRO_DELAY");

            GSpellTimer GlobalCooldown = new GSpellTimer(1500 + SPELL_DELAY, true);

            //RAGE - Begin
            try { TRAVELFORM = Context.GetConfigString("PicLock.TravelForm"); }
            catch { Context.Log("ERROR Loading TravelForm"); TRAVELFORM = "Default"; }
            try { TRAVELFORMDELAY = Context.GetConfigInt("PicLock.TravelFormDelay"); }
            catch { Context.Log("ERROR Loading TravelFormDelay"); TRAVELFORMDELAY = 5; }
            try { MOUNTNAME = Context.GetConfigString("PicLock.MountName"); }
            catch { Context.Log("ERROR Loading MountName"); MOUNTNAME = ""; }
            //RAGE - End
        }

        //Setup the custom config display
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
                    SetConfigValue(configDialog, "PicLock.USE_SPELLSHUFFLE", Context.GetConfigString("PicLock.USE_SPELLSHUFFLE"));
                    SetConfigValue(configDialog, "PicLock.MISCDELAY", Context.GetConfigString("PicLock.MISCDELAY"));
                    SetConfigValue(configDialog, "PicLock.PULL_DISTANCE", Context.GetConfigString("PicLock.PULL_DISTANCE"));
                    SetConfigValue(configDialog, "PicLock.WAIT_FOR_PET", Context.GetConfigString("PicLock.WAIT_FOR_PET"));
                    SetConfigValue(configDialog, "PicLock.SPELL_DELAY", Context.GetConfigString("PicLock.SPELL_DELAY"));
                    SetConfigValue(configDialog, "PicLock.USE_FOOD", Context.GetConfigString("PicLock.USE_FOOD"));
                    SetConfigValue(configDialog, "PicLock.USE_DRINK", Context.GetConfigString("PicLock.USE_DRINK"));
                    SetConfigValue(configDialog, "PicLock.USE_HEALTHPOTION", Context.GetConfigString("PicLock.USE_HEALTHPOTION"));
                    SetConfigValue(configDialog, "PicLock.USE_HEALTHSTONE", Context.GetConfigString("PicLock.USE_HEALTHSTONE"));
                    SetConfigValue(configDialog, "PicLock.EMERGENCY_HEALTH", Context.GetConfigString("PicLock.EMERGENCY_HEALTH"));
                    SetConfigValue(configDialog, "PicLock.MIN_HEALTH_PCT", Context.GetConfigString("PicLock.MIN_HEALTH_PCT"));
                    SetConfigValue(configDialog, "PicLock.MIN_MANA_PCT", Context.GetConfigString("PicLock.MIN_MANA_PCT"));
                    SetConfigValue(configDialog, "PicLock.PRIMARY_ATTACK", Context.GetConfigString("PicLock.PRIMARY_ATTACK"));
                    SetConfigValue(configDialog, "PicLock.SUMMON_DEMON", Context.GetConfigString("PicLock.SUMMON_DEMON"));
                    SetConfigValue(configDialog, "PicLock.MIN_MOB_HEALTH_PCT", Context.GetConfigString("PicLock.MIN_MOB_HEALTH_PCT"));
                    SetConfigValue(configDialog, "PicLock.PET_ATTACK", Context.GetConfigString("PicLock.PET_ATTACK"));
                    SetConfigValue(configDialog, "PicLock.USE_FELDOMINATION", Context.GetConfigString("PicLock.USE_FELDOMINATION"));
                    SetConfigValue(configDialog, "PicLock.USE_SOULLINK", Context.GetConfigString("PicLock.USE_SOULLINK"));
                    SetConfigValue(configDialog, "PicLock.USE_ARMORBUFF", Context.GetConfigString("PicLock.USE_ARMORBUFF"));
                    SetConfigValue(configDialog, "PicLock.USE_NIGHTFALL", Context.GetConfigString("PicLock.USE_NIGHTFALL"));
                    SetConfigValue(configDialog, "PicLock.USE_BLOODFURY", Context.GetConfigString("PicLock.USE_BLOODFURY"));
                    SetConfigValue(configDialog, "PicLock.USE_AMPLIFYCURSE", Context.GetConfigString("PicLock.USE_AMPLIFYCURSE"));
                    SetConfigValue(configDialog, "PicLock.DEAL_WITH_ADDS", Context.GetConfigString("PicLock.DEAL_WITH_ADDS"));
                    SetConfigValue(configDialog, "PicLock.USE_FEAR", Context.GetConfigString("PicLock.USE_FEAR"));
                    SetConfigValue(configDialog, "PicLock.USE_HEALTHFUNNEL", Context.GetConfigString("PicLock.USE_HEALTHFUNNEL"));
                    SetConfigValue(configDialog, "PicLock.HEALTHFUNNEL_PCT", Context.GetConfigString("PicLock.HEALTHFUNNEL_PCT"));
                    SetConfigValue(configDialog, "PicLock.USE_DRAINLIFE", Context.GetConfigString("PicLock.USE_DRAINLIFE"));
                    SetConfigValue(configDialog, "PicLock.DRAINLIFE_PCT", Context.GetConfigString("PicLock.DRAINLIFE_PCT"));
                    SetConfigValue(configDialog, "PicLock.USE_DRAINMANA", Context.GetConfigString("PicLock.USE_DRAINMANA"));
                    SetConfigValue(configDialog, "PicLock.DRAINMANA_PCT", Context.GetConfigString("PicLock.DRAINMANA_PCT"));
                    SetConfigValue(configDialog, "PicLock.USE_LIFETAP", Context.GetConfigString("PicLock.USE_LIFETAP"));
                    SetConfigValue(configDialog, "PicLock.USE_FEEDMANA", Context.GetConfigString("PicLock.USE_FEEDMANA"));
                    SetConfigValue(configDialog, "PicLock.FEEDMANA_PCT", Context.GetConfigString("PicLock.FEEDMANA_PCT"));
                    SetConfigValue(configDialog, "PicLock.USE_SACRIFICE", Context.GetConfigString("PicLock.USE_SACRIFICE"));
                    SetConfigValue(configDialog, "PicLock.SACRIFICE_PCT", Context.GetConfigString("PicLock.SACRIFICE_PCT"));
                    SetConfigValue(configDialog, "PicLock.SOULSHARDS_MAX", Context.GetConfigString("PicLock.SOULSHARDS_MAX"));
                    SetConfigValue(configDialog, "PicLock.DRAINSOUL_PCT", Context.GetConfigString("PicLock.DRAINSOUL_PCT"));
                    SetConfigValue(configDialog, "PicLock.RESUMMON_IN_COMBAT", Context.GetConfigString("PicLock.RESUMMON_IN_COMBAT"));
                    SetConfigValue(configDialog, "PicLock.SIT_TO_REGEN", Context.GetConfigString("PicLock.SIT_TO_REGEN"));
                    SetConfigValue(configDialog, "PicLock.USE_DARKPACT", Context.GetConfigString("PicLock.USE_DARKPACT"));
                    SetConfigValue(configDialog, "PicLock.RETURN_PET", Context.GetConfigString("PicLock.RETURN_PET"));
                    SetConfigValue(configDialog, "PicLock.FIGHT_BACK", Context.GetConfigString("PicLock.FIGHT_BACK"));
                    SetConfigValue(configDialog, "PicLock.WAIT_FOR_PET_AGGRO", Context.GetConfigString("PicLock.WAIT_FOR_PET_AGGRO"));
                    SetConfigValue(configDialog, "PicLock.LAST_RESORT", Context.GetConfigString("PicLock.LAST_RESORT"));
                    SetConfigValue(configDialog, "PicLock.CAST_ADDS", Context.GetConfigString("PicLock.CAST_ADDS"));
                    SetConfigValue(configDialog, "PicLock.USE_CONSUMESHADOWS", Context.GetConfigString("PicLock.USE_CONSUMESHADOWS"));
                    SetConfigValue(configDialog, "PicLock.CONSUMESHADOWS_PCT", Context.GetConfigString("PicLock.CONSUMESHADOWS_PCT"));
                    SetConfigValue(configDialog, "PicLock.LEVEL_DIFFERENCE", Context.GetConfigString("PicLock.LEVEL_DIFFERENCE"));
                    SetConfigValue(configDialog, "PicLock.INITIATE_PVP", Context.GetConfigString("PicLock.INITIATE_PVP"));

                    SetConfigValue(configDialog, "PicLock.USE_UNSTABLEAFFLICTION", Context.GetConfigString("PicLock.USE_UNSTABLEAFFLICTION"));
                    SetConfigValue(configDialog, "PicLock.USE_CORRUPTION", Context.GetConfigString("PicLock.USE_CORRUPTION"));
                    SetConfigValue(configDialog, "PicLock.USE_CURSEOFAGONY", Context.GetConfigString("PicLock.USE_CURSEOFAGONY"));
                    SetConfigValue(configDialog, "PicLock.USE_SIPHONLIFE", Context.GetConfigString("PicLock.USE_SIPHONLIFE"));
                    SetConfigValue(configDialog, "PicLock.USE_IMMOLATE", Context.GetConfigString("PicLock.USE_IMMOLATE"));
                    SetConfigValue(configDialog, "PicLock.USE_SHADOWBURN", Context.GetConfigString("PicLock.USE_SHADOWBURN"));
                    SetConfigValue(configDialog, "PicLock.USE_SHADOWBOLT", Context.GetConfigString("PicLock.USE_SHADOWBOLT"));
                    //SetConfigValue(configDialog, "PicLock.USE_HOWLOFTERROR", Context.GetConfigString("PicLock.USE_HOWLOFTERROR"));
                    SetConfigValue(configDialog, "PicLock.USE_DEATHCOIL", Context.GetConfigString("PicLock.USE_DEATHCOIL"));
                    SetConfigValue(configDialog, "PicLock.USE_CONFLAGURATE", Context.GetConfigString("PicLock.USE_CONFLAGURATE"));
                    SetConfigValue(configDialog, "PicLock.USE_INCINERATE", Context.GetConfigString("PicLock.USE_INCINERATE"));

                    SetConfigValue(configDialog, "PicLock.PET_AGGRO_DELAY", Context.GetConfigString("PicLock.PET_AGGRO_DELAY"));

                    //RAGE - Begin
                    SetConfigValue(configDialog, "PicLock.TravelForm", Context.GetConfigString("PicLock.TravelForm"));
                    SetConfigValue(configDialog, "PicLock.TravelFormDelay", Context.GetConfigString("PicLock.TravelFormDelay"));
                    SetConfigValue(configDialog, "PicLock.MountName", Context.GetConfigString("PicLock.MountName"));
                    //RAGE - End

                    //Set Config File
                    pi = type.GetProperty("ConfigXML");
                    if (pi != null) pi.SetValue(configDialog, "PicLock.XML", null);

                    //Popup Dialog
                    object modalResult = showDialogMethod.Invoke(configDialog, new object[] { });
                    if ((int)modalResult == 1)
                    {
                        //Get Current Values
                        Context.SetConfigValue("PicLock.USE_SPELLSHUFFLE", GetConfigValue(configDialog, "PicLock.USE_SPELLSHUFFLE"), true);
                        Context.SetConfigValue("PicLock.MISCDELAY", GetConfigValue(configDialog, "PicLock.MISCDELAY"), true);
                        Context.SetConfigValue("PicLock.PULL_DISTANCE", GetConfigValue(configDialog, "PicLock.PULL_DISTANCE"), true);
                        Context.SetConfigValue("PicLock.WAIT_FOR_PET", GetConfigValue(configDialog, "PicLock.WAIT_FOR_PET"), true);
                        Context.SetConfigValue("PicLock.SPELL_DELAY", GetConfigValue(configDialog, "PicLock.SPELL_DELAY"), true);
                        Context.SetConfigValue("PicLock.USE_FOOD", GetConfigValue(configDialog, "PicLock.USE_FOOD"), true);
                        Context.SetConfigValue("PicLock.USE_DRINK", GetConfigValue(configDialog, "PicLock.USE_DRINK"), true);
                        Context.SetConfigValue("PicLock.USE_HEALTHPOTION", GetConfigValue(configDialog, "PicLock.USE_HEALTHPOTION"), true);
                        Context.SetConfigValue("PicLock.USE_HEALTHSTONE", GetConfigValue(configDialog, "PicLock.USE_HEALTHSTONE"), true);
                        Context.SetConfigValue("PicLock.EMERGENCY_HEALTH", GetConfigValue(configDialog, "PicLock.EMERGENCY_HEALTH"), true);
                        Context.SetConfigValue("PicLock.MIN_HEALTH_PCT", GetConfigValue(configDialog, "PicLock.MIN_HEALTH_PCT"), true);
                        Context.SetConfigValue("PicLock.MIN_MANA_PCT", GetConfigValue(configDialog, "PicLock.MIN_MANA_PCT"), true);
                        Context.SetConfigValue("PicLock.PRIMARY_ATTACK", GetConfigValue(configDialog, "PicLock.PRIMARY_ATTACK"), true);
                        Context.SetConfigValue("PicLock.SUMMON_DEMON", GetConfigValue(configDialog, "PicLock.SUMMON_DEMON"), true);
                        Context.SetConfigValue("PicLock.MIN_MOB_HEALTH_PCT", GetConfigValue(configDialog, "PicLock.MIN_MOB_HEALTH_PCT"), true);
                        Context.SetConfigValue("PicLock.PET_ATTACK", GetConfigValue(configDialog, "PicLock.PET_ATTACK"), true);
                        Context.SetConfigValue("PicLock.USE_FELDOMINATION", GetConfigValue(configDialog, "PicLock.USE_FELDOMINATION"), true);
                        Context.SetConfigValue("PicLock.USE_SOULLINK", GetConfigValue(configDialog, "PicLock.USE_SOULLINK"), true);
                        Context.SetConfigValue("PicLock.USE_ARMORBUFF", GetConfigValue(configDialog, "PicLock.USE_ARMORBUFF"), true);
                        Context.SetConfigValue("PicLock.USE_NIGHTFALL", GetConfigValue(configDialog, "PicLock.USE_NIGHTFALL"), true);
                        Context.SetConfigValue("PicLock.USE_BLOODFURY", GetConfigValue(configDialog, "PicLock.USE_BLOODFURY"), true);
                        Context.SetConfigValue("PicLock.USE_AMPLIFYCURSE", GetConfigValue(configDialog, "PicLock.USE_AMPLIFYCURSE"), true);
                        Context.SetConfigValue("PicLock.DEAL_WITH_ADDS", GetConfigValue(configDialog, "PicLock.DEAL_WITH_ADDS"), true);
                        Context.SetConfigValue("PicLock.USE_FEAR", GetConfigValue(configDialog, "PicLock.USE_FEAR"), true);
                        Context.SetConfigValue("PicLock.USE_HEALTHFUNNEL", GetConfigValue(configDialog, "PicLock.USE_HEALTHFUNNEL"), true);
                        Context.SetConfigValue("PicLock.HEALTHFUNNEL_PCT", GetConfigValue(configDialog, "PicLock.HEALTHFUNNEL_PCT"), true);
                        Context.SetConfigValue("PicLock.USE_DRAINLIFE", GetConfigValue(configDialog, "PicLock.USE_DRAINLIFE"), true);
                        Context.SetConfigValue("PicLock.DRAINLIFE_PCT", GetConfigValue(configDialog, "PicLock.DRAINLIFE_PCT"), true);
                        Context.SetConfigValue("PicLock.USE_DRAINMANA", GetConfigValue(configDialog, "PicLock.USE_DRAINMANA"), true);
                        Context.SetConfigValue("PicLock.DRAINMANA_PCT", GetConfigValue(configDialog, "PicLock.DRAINMANA_PCT"), true);
                        Context.SetConfigValue("PicLock.USE_LIFETAP", GetConfigValue(configDialog, "PicLock.USE_LIFETAP"), true);
                        Context.SetConfigValue("PicLock.USE_FEEDMANA", GetConfigValue(configDialog, "PicLock.USE_FEEDMANA"), true);
                        Context.SetConfigValue("PicLock.FEEDMANA_PCT", GetConfigValue(configDialog, "PicLock.FEEDMANA_PCT"), true);
                        Context.SetConfigValue("PicLock.USE_SACRIFICE", GetConfigValue(configDialog, "PicLock.USE_SACRIFICE"), true);
                        Context.SetConfigValue("PicLock.SACRIFICE_PCT", GetConfigValue(configDialog, "PicLock.SACRIFICE_PCT"), true);
                        Context.SetConfigValue("PicLock.SOULSHARDS_MAX", GetConfigValue(configDialog, "PicLock.SOULSHARDS_MAX"), true);
                        Context.SetConfigValue("PicLock.DRAINSOUL_PCT", GetConfigValue(configDialog, "PicLock.DRAINSOUL_PCT"), true);
                        Context.SetConfigValue("PicLock.RESUMMON_IN_COMBAT", GetConfigValue(configDialog, "PicLock.RESUMMON_IN_COMBAT"), true);
                        Context.SetConfigValue("PicLock.SIT_TO_REGEN", GetConfigValue(configDialog, "PicLock.SIT_TO_REGEN"), true);
                        Context.SetConfigValue("PicLock.USE_DARKPACT", GetConfigValue(configDialog, "PicLock.USE_DARKPACT"), true);
                        Context.SetConfigValue("PicLock.RETURN_PET", GetConfigValue(configDialog, "PicLock.RETURN_PET"), true);
                        Context.SetConfigValue("PicLock.FIGHT_BACK", GetConfigValue(configDialog, "PicLock.FIGHT_BACK"), true);
                        Context.SetConfigValue("PicLock.WAIT_FOR_PET_AGGRO", GetConfigValue(configDialog, "PicLock.WAIT_FOR_PET_AGGRO"), true);
                        Context.SetConfigValue("PicLock.LAST_RESORT", GetConfigValue(configDialog, "PicLock.LAST_RESORT"), true);
                        Context.SetConfigValue("PicLock.CAST_ADDS", GetConfigValue(configDialog, "PicLock.CAST_ADDS"), true);
                        Context.SetConfigValue("PicLock.USE_CONSUMESHADOWS", GetConfigValue(configDialog, "PicLock.USE_CONSUMESHADOWS"), true);
                        Context.SetConfigValue("PicLock.CONSUMESHADOWS_PCT", GetConfigValue(configDialog, "PicLock.CONSUMESHADOWS_PCT"), true);
                        Context.SetConfigValue("PicLock.LEVEL_DIFFERENCE", GetConfigValue(configDialog, "PicLock.LEVEL_DIFFERENCE"), true);
                        Context.SetConfigValue("PicLock.INITIATE_PVP", GetConfigValue(configDialog, "PicLock.INITIATE_PVP"), true);

                        Context.SetConfigValue("PicLock.USE_UNSTABLEAFFLICTION", GetConfigValue(configDialog, "PicLock.USE_UNSTABLEAFFLICTION"), true);
                        Context.SetConfigValue("PicLock.USE_CORRUPTION", GetConfigValue(configDialog, "PicLock.USE_CORRUPTION"), true);
                        Context.SetConfigValue("PicLock.USE_CURSEOFAGONY", GetConfigValue(configDialog, "PicLock.USE_CURSEOFAGONY"), true);
                        Context.SetConfigValue("PicLock.USE_SIPHONLIFE", GetConfigValue(configDialog, "PicLock.USE_SIPHONLIFE"), true);
                        Context.SetConfigValue("PicLock.USE_IMMOLATE", GetConfigValue(configDialog, "PicLock.USE_IMMOLATE"), true);
                        Context.SetConfigValue("PicLock.USE_SHADOWBURN", GetConfigValue(configDialog, "PicLock.USE_SHADOWBURN"), true);
                        Context.SetConfigValue("PicLock.USE_SHADOWBOLT", GetConfigValue(configDialog, "PicLock.USE_SHADOWBOLT"), true);
                        //Context.SetConfigValue("PicLock.USE_HOWLOFTERROR", GetConfigValue(configDialog, "PicLock.USE_HOWLOFTERROR"), true);
                        Context.SetConfigValue("PicLock.USE_DEATHCOIL", GetConfigValue(configDialog, "PicLock.USE_DEATHCOIL"), true);
                        Context.SetConfigValue("PicLock.USE_CONFLAGURATE", GetConfigValue(configDialog, "PicLock.USE_CONFLAGURATE"), true);
                        Context.SetConfigValue("PicLock.USE_INCINERATE", GetConfigValue(configDialog, "PicLock.USE_INCINERATE"), true);

                        Context.SetConfigValue("PicLock.PET_AGGRO_DELAY", GetConfigValue(configDialog, "PicLock.PET_AGGRO_DELAY"), true);

                        //RAGE - Begin
                        Context.SetConfigValue("PicLock.TravelForm", GetConfigValue(configDialog, "PicLock.TravelForm"), true);
                        Context.SetConfigValue("PicLock.TravelFormDelay", GetConfigValue(configDialog, "PicLock.TravelFormDelay"), true);
                        Context.SetConfigValue("PicLock.MountName", GetConfigValue(configDialog, "PicLock.MountName"), true);
                        //RAGE - End
                        return GConfigResult.Accept;
                    }
                    return GConfigResult.Cancel;
                }
            }
            return GConfigResult.Cancel;
        }

        //Custom SetConfigValue
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

        #endregion Custom Config Dialog

        #region Non-Combat Overrides

        //Start operations
        public override void OnStartGlide()
        {
            Context.Log("Started " + classname + " " + version);
            SpellList();  //added in 2.15 to build the spell list from config
            
            GlobalCooldown = new GSpellTimer(1500 + SPELL_DELAY, true);
            Context.CombatLog += new GContext.GCombatLogHandler(Context_CombatLog);
            //Context.ChatLog += new GContext.GChatLogHandler(Context_ChatLog);

            //Run start functions
            SoulShardCount = CountSoulShards();
            PostCombat();
            base.OnStartGlide();
        }


        public override void OnStopGlide()
        {
            Context.Log("Stopped " + classname + " " + version);

            Context.CombatLog -= new GContext.GCombatLogHandler(Context_CombatLog);
            
            //Context.ChatLog -= new GContext.GChatLogHandler(Context_ChatLog);
        }

        //Resurrect operations
        public override void OnResurrect()
        {
            ArmorBuff.ForceReady();
            Thread.Sleep(SPELL_DELAY * 3);
            PostCombat();
        }

        //Rest operations
        public override bool Rest()
        {
            PostCombat();
            return false;
        }

        //Approaching opeartions
        public override void ApproachingTarget(GUnit Target)
        {

        }

        //Running operations
        public override void RunningAction()
        {
            if (INITIATE_PVP && !Me.IsInCombat && Me.Health > 0.6 && Me.Mana > 0.6)
            {
                ActivePVP();
            }
            //RAGE - Begin

            ProfileTargetIsWithinRange = ProfileTargetWithinRange();
            if (BetweenTargetMode(classname)) return;
            //RAGE - End
        }

        //Setup Combat Log watchers
        public override void Startup()
        {
        }

        public override void Shutdown()
        {
        }

        public override int PullDistance
        {
            get
            {
                return Context.GetConfigInt("PicLock.PULL_DISTANCE");
            }
        }

        public override string DisplayName 
        { 
            get 
            { 
                return classname+" "+version; 
            }
        }

        #endregion Non-Combat Overrides

        //Combat Log watcher to discover resisted spells and reset timer
        public void Context_CombatLog(string RawText)
        {
            RawText = RawText.ToLower();
            if (RawText.Contains("your curse of agony was resisted"))
            {
                Context.Log("Curse of Agony resisted");
                ForceCurseOfAgony = true;
                CurseOfAgony.ForceReady();
            }
            else if (RawText.Contains("your corruption was resisted"))
            {
                Context.Log("Corruption resisted");
                ForceCorruption = true;
                Corruption.ForceReady();
            }
            else if (RawText.Contains("your immolate was resisted"))
            {
                Context.Log("Immolate resisted");
                ForceImmolate = true;
                Immolate.ForceReady();
            }
            else if (RawText.Contains("your siphon life was resisted"))
            {
                Context.Log("Siphon Life resisted");
                ForceSiphonLife = true;
                SiphonLife.ForceReady();
            }
            else if (RawText.Contains("your curse of recklessness was resisted"))
            {
                Context.Log("Curse of Recklessness resisted");
                ForceCurseOfRecklessness = true;
                CurseOfRecklessness.ForceReady();
            }
            else if (RawText.Contains("your unstable affliction was resisted"))
            {
                Context.Log("Unstable Affliction resisted");
                ForceUnstableAffliction = true;
                UnstableAffliction.ForceReady();
            }
        }

        //Chat Log watcher to discover created Soul Shards and Healthstones
        public void Context_ChatLog(string RawText, string ParsedText)
        {

        }

        //Combat overrride
        public override GCombatResult KillTarget(GUnit Target, bool IsAmbush)
        {
            //Stop walking/turning
            Context.ReleaseSpinRun();
            /* RecursiveBot 2.17.1 A
             * the following is the logical switch to control if the spell
             * shuffle function is called. This removes the randomizing of spells
             * but does not give the ability to cast them in any order.
             */
            if (USE_SPELLSHUFFLE)
            {
                SpellShuffle(ref SPELL_ORDER);
            }
            SoulShardCount = CountSoulShards();
            Reset();

            //Call function to wait for player death
            if (Target.IsPlayer)
            {
                if (((GPlayer)Target).IsSameFaction)
                {
                    Context.ClearTarget();
                    return GCombatResult.Success;
                }
                else if (FIGHT_BACK)
                {
                    Context.Log("Attempting PVP...");
                    return PVP(Target);
                }
                else
                {
                    Context.Log("No PVP");
                    WaitForPlayerDeath();
                    return GCombatResult.Died;
                }
            }

            //Send in pet and wait for predefined amount of time
            /* RecursiveBot 2.17.1 G
             * The following change was to ensure that multiple Petattacks weren't sent
             * due to the logic flow.
             */
            if (Me.HasLivePet && PET_ATTACK && !Me.Pet.IsInCombat)
            {
                SendKey("Common.PetAttack");
              //Context.Log("DBG - KillTarget Send Pet routine started!");
                if (WAIT_FOR_PET_AGGRO)
                {
                    Context.Log("Waiting for pet to approach target");
                    bool temp;
                    temp = WaitForEngage(Target,(PET_AGGRO_DELAY * 1000));
                    if (temp)
                    {
                        Context.Log("Pet aggroed target");
                    }
                    else
                    {
                        Context.Log("Pet failed to aggro target");
                    }
                }
                Thread.Sleep(500);
            }

            while (true)
            {
                //Refresh the target
                Target.Refresh(true);

                //Check the current GCombatResult
                GCombatResult CommonResult = Context.CheckCommonCombatResult((GMonster)Target, IsAmbush);

                //Return the GCombatResult
                if (CommonResult != GCombatResult.Unknown)
                {
                    SoulShardCount = CountSoulShards();
                    if (USE_CONSUMESHADOWS)
                    {
                        TwoSecTimer.Reset();
                        while (!TwoSecTimer.IsReady)
                        {
                            Thread.Sleep(150);
                            if (!Me.IsInCombat)
                            {
                                TwoSecTimer.ForceReady();
                            }
                        }
                        PetHealth();
                    }
                    return CommonResult;
                }
                else if (Target.IsDead)
                {
                    SoulShardCount = CountSoulShards();
                    if (USE_CONSUMESHADOWS)
                    {
                        TwoSecTimer.Reset();
                        while (!TwoSecTimer.IsReady)
                        {
                            Thread.Sleep(100);
                            if (!Me.IsInCombat)
                            {
                                TwoSecTimer.ForceReady();
                            }
                        }
                        // PetHealth(); //Moved to outside of If statement to resolve pet deaths
                    }
                    return GCombatResult.Success;
                }

                PetHealth();
                Target.Face();

                if (Me.HasLivePet && PET_ATTACK && RETURN_PET && DoReturnPet && Target.Health < HealthToReturnPet && Target.DistanceToSelf > 10 && Target.Target == Me.Pet)
                {
                    Context.Log("Returning the pet to me! Come to papa!");
                    SendKey("Common.PetFollow");
                    DoReturnPet = false;
                }

                if (Target.DistanceToSelf > PullDistance && Target.DistanceToSelf < (PullDistance + TARGET_DUMP_DISTANCE))
                {
                    Target.Approach(PullDistance - 2, false);
                }

                if (Target.DistanceToSelf > (PullDistance + TARGET_DUMP_DISTANCE))
                {
                    Context.ClearTarget();
                    return GCombatResult.Success;
                }


                //Stop Walking, Face
                Context.ReleaseSpinRun();

                TargetUnit(Target, false);

                //Deal with players
                if (FIGHT_BACK)
                {
                    //Decide what to do depending on what is returned
                    switch (CheckPlayers(Target))
                    {
                        case 0:
                            break;
                        case 1:
                            Context.Log("Targeted by enemy faction, fighting back!");
                            return GCombatResult.SuccessWithAdd;
                        case -1:
                            Context.Log("Target by enemy faction but unable to target them");
                            break;
                    }
                }

                //Deal with adds
                //Context.Log("DBG - Are we set to deal with adds?" + DEAL_WITH_ADDS);
                if (DEAL_WITH_ADDS)
                {
                   // Context.Log("DBG - Starting Check Add's function call");
                    CheckAdds(Target);
                }

                //Check health
                //Context.Log("DBG - Me.IsInCombat is returning" + Me.IsInCombat);
                CheckHealth(Me.IsInCombat); //Changed Parameter from true to Me.IsInCombat
                //Check pet

                /* RecursiveBot 2.17.1 B
                 * The following was changed to check if the player is mounted before running 
                 * CheckPet() due to the fact that checkpet would call for a resummon upon 
                 * finding a target and not having a pet.
                 * This is a quick fix. Logic for checking a pet might need rework.
                 */
                if (!IsMounted(Me))
                {
                    CheckPet();
                }
                if (!Target.IsDead)
                {
                    //Cast Debuffs
                    //Context.Log("DBG - Test Target Not Dead code initiated");

                    CastSequence(Target, false);
                    ShadowCheck(Target);
                    //Check various things
                    if (PetHealth())
                    {
                    }
                    else if (DrainSoul(Target))
                    {
                    }
                    else if (DrainLife(Target, false))
                    {
                    }
                    else if (PrimaryAttack(Target))
                    {
                    }
                    else if (CheckMana(Target) && !IsMounted())
                    {
                    }
                    else LastResort(Target);
                }
                Thread.Sleep(150);
            }
        }

        void CheckAdds(GUnit Target)  
         {
            bool temp = true;
            //Context.Log("CheckAdd code initialized");
            while (!Me.IsDead && temp)
            {
                try
                {
                    //Find all adds
                    //Context.Log("DBG - Finding all Adds");
                    GUnit[] Attackers = GObjectList.GetAttackers();
                    //Context.Log("DBG - Checking Adds - found " + Attackers.Length);
                    if (Attackers.Length <= 1) return;
                    foreach (GUnit Add in Attackers)
                    {
                        if (Me.IsDead) return;
                        //Checks current Add - Makes sure its alive, not current target, checks fear
                        //Context.Log("DBG - Is Fear ready? " + Fear.IsReady);
                        if ((USE_FEAR && Fear.IsReady || CAST_ADDS) && Add.IsMonster && Add.Refresh(true) && !Add.IsDead && Add != Target && Add.DistanceToSelf < 40)
                        {
                            if (CAST_ADDS && !ArrayContains(CastedAdds, Add.GUID))
                            {
                                Context.Log("Dealing with add");
                                if (Add.DistanceToSelf < PullDistance) Add.Approach(PullDistance - 2, false);
                                Add.Face();
                                Context.ReleaseSpinRun();
                                TargetUnit(Add, false);
                                if (USE_FEAR && Fear.IsReady)
                                {
                                    if (Add.DistanceToSelf > FearRange) Add.Approach(FearRange, false);
                                    CastSpell("PL.Fear", Add);
                                    Fear.Reset();
                                }
                                if (!Me.Pet.IsInCombat)
                                {
                                    SendKey("Common.PetAttack");
                                }
                                CastSequence(Add, true);
                                CastedAdds[CastedAddsIndex++] = Add.GUID;
                            }
                            if (USE_FEAR && Fear.IsReady)
                            {
                                if (Add.DistanceToSelf > FearRange) Add.Approach(FearRange, false);
                                Add.Face();
                                Context.ReleaseSpinRun();
                                TargetUnit(Add, false);
                                CastSpell("PL.Fear", Add);
                                Fear.Reset();
                            }
                        }
                    }
                    Target.Refresh();
                    TargetUnit(Target, false);
                    SendKey("Common.PetAttack");
                    temp = false;
                }
                catch (Exception e) 
                {
                    Context.Log("Exception caught in CheckAdds. This is probably due to dieing while in the inner loop.");
                    Context.Log(e.ToString());
                }
            }
            return;
        }

        int CheckPlayers(GUnit Target)
        {
            //Find all nearby players
            GPlayer[] Players = GObjectList.GetPlayers();
            if (Players.Length < 1) return 0; //No players
            foreach (GPlayer Player in Players) //Check every player...
            {
                //Check if player is targeting me and if player is opposite faction
                if (Player != Me && Player.Refresh(true) && Player != Target && !Target.IsPlayer && Player.DistanceToSelf < (PullDistance + TARGET_DUMP_DISTANCE) && Player.IsTargetingMe && !Player.IsSameFaction)
                {
                    if (Player.Level < Me.Level + LEVEL_DIFFERENCE && Player.Level > Me.Level - LEVEL_DIFFERENCE)
                    {
                        TargetUnit(Player, false);
                        if (Me.Target == Player)
                        {
                            return 1; //Will return GCombatResult.SuccessWithAdd with Player as target
                        }
                        else return -1; //Failed to target player, will display a message that couldnt target
                    }
                }
            }
            Target.Refresh();
            TargetUnit(Target, false);
            return 0;
        }

        void ActivePVP()
        {
            //Find all nearby players
            GPlayer[] Players = GObjectList.GetPlayers();
            if (Players.Length < 1) return; //No players
            foreach (GPlayer Player in Players) //Check every player...
            {
                //Check if player is targeting me and if player is opposite faction
                if (Player != Me && Player.Refresh(true) && Player.DistanceToSelf < (PullDistance + TARGET_DUMP_DISTANCE) && !Player.IsSameFaction)
                {
                    if (Player.Level < Me.Level + LEVEL_DIFFERENCE && Player.Level > Me.Level - LEVEL_DIFFERENCE)
                    {
                        Player.Approach(PullDistance, false);
                        TargetUnit(Player, false);
                        if (Me.Target == Player)
                        {
                            Context.Log("Initiating Combat with " + Player.Name + " at " + Player.DistanceToSelf + " yards");
                            KillTarget(Player, false);
                            return;
                        }
                    }
                }
            }
        }

        //Checks pet health and use Health Funnel, Void Sacrifice, and Demonic Sacrifice
        bool PetHealth()
        {
            if (Me.HasLivePet)
            {
                if (USE_CONSUMESHADOWS && Me.Pet.Mana > MaintainPetMana && ConsumeShadows.IsReady && Me.Pet.Health < CONSUMESHADOWS_PCT && !Me.IsInCombat && SUMMON_DEMON == "Voidwalker" && !HasWrongPet)
                {
                    SendKey("PL.ConsumeShadows");
                    ConsumeShadows.Reset();
                }
                else if (USE_SACRIFICE == "Void" && Me.Pet.Health < SACRIFICE_PCT && SUMMON_DEMON == "Voidwalker" && !HasWrongPet)
                {
                    SendKey("PL.VoidwalkerSacrifice");
                    return true;
                }
                else if (USE_SACRIFICE == "Demonic" && Me.Pet.Health < SACRIFICE_PCT)
                {
                    SendKey("PL.DemonicSacrifice");
                    return true;
                }
                else if (USE_HEALTHFUNNEL && Me.Pet.Health < HEALTHFUNNEL_PCT && Me.Health > MIN_HEALTH_PCT)
                {
                    Context.Log("Time to Heal my pet! Health Funnel time!");
                    if (Me.Pet.DistanceToSelf > HealthFunnelRange) Me.Pet.Approach(HealthFunnelRange, false);
                    CastSpell("PL.HealthFunnel");
                    return true;
                }
            }
            return false;
        }

        //If not enough Soul Shards, Soul Drain
                bool DrainSoul(GUnit Target)
        {
            //if (Me.IsDead) return;
            //Context.Log("Drain Soul - Yes or No");
            //Context.Log("DrainSoul SS check - My current SS count is " + SoulShardCount + " with a max of " + SOULSHARDS_MAX);
            if (SoulShardCount < SOULSHARDS_MAX && Target.Health < DRAINSOUL_PCT && !Target.IsDead)
            {
                if (SoulShardCount < 1)
                {
                    SoulShardCount = 0;
                }
                CastSpell("PL.DrainSoul");
                Thread.Sleep(100);
                return true;
            }
            return false;
        }
        
                void CheckMana()
                {

                    if (Me.IsInCombat)
                    {
                        while (USE_DARKPACT && Me.HasLivePet && (Me.Mana < MIN_MANA_PCT) && (Me.Pet.Mana > MaintainPetMana))
                        {
                            CastSpell("PL.DarkPact");
                        }
                        while (USE_LIFETAP && (Me.Health > MIN_HEALTH_PCT) && (Me.Mana < MIN_MANA_PCT))
                        {
                            CastSpell("PL.Lifetap");
                            Thread.Sleep(250);
                        }
                    }
                    else
                    {
                        while (USE_DARKPACT && Me.HasLivePet && (Me.Mana < MIN_MANA_PCT) && (Me.Pet.Mana > MaintainPetMana))
                        {
                            CastSpell("PL.DarkPact");
                        }

                        if (USE_DRINK && Me.Mana < Context.RestMana && Interface.GetActionInventory("Common.Drink") > 0)
                        {
                            SendKey("Common.Drink");
                            EatOrDrinkWait.Reset();
                            bIsDrinking = true;
                        }

                        else if (SIT_TO_REGEN && Me.Mana < Context.RestMana)
                        {
                            if (!Me.IsSitting)
                            {
                                SendKey("Common.Sit");
                            }
                            EatOrDrinkWait.Reset();
                            bIsDrinking = true;
                        }

                        while (USE_LIFETAP && (Me.Health > MIN_HEALTH_PCT) && (Me.Mana < MIN_MANA_PCT))
                        {
                            CastSpell("PL.Lifetap");
                            Thread.Sleep(250);
                        }
                    }
                }


        //Checks mana (Overloaded) - First check Drain Mana, Second check Life Tap
        bool CheckMana(GUnit Target)
        {
            if (USE_DRAINMANA && Target.Mana > .5 && Me.Mana > .1 && Me.Health > MIN_HEALTH_PCT && (Me.Mana < DRAINMANA_PCT || (USE_FEEDMANA && Me.HasLivePet && Me.Pet.Mana < FEEDMANA_PCT)))
            {
             //   Context.Log("CheckMana SS Check - My current SS count is " + SoulShardCount + " with a max of " + SOULSHARDS_MAX);
                if (SoulShardCount < SOULSHARDS_MAX)
                {
                    if (SoulShardCount < 1)
                    {
                        SoulShardCount = 0;
                    }
                    Target.Face();
                    CastSwitchSpell("PL.DrainMana", "PL.DrainSoul", Target, DRAINSOUL_PCT);
                }
                else
                {
                    Target.Face();
                    CastSpell("PL.DrainMana");
                }
                return true;
            }
            else if (USE_DARKPACT && Me.HasLivePet && Me.Mana < MIN_MANA_PCT && Me.Pet.Mana > MaintainPetMana)
            {
                CastSpell("PL.DarkPact");
                return true;
            }
            else if (USE_LIFETAP && (Me.Health > MIN_HEALTH_PCT) && (Me.Mana < MIN_MANA_PCT || (USE_FEEDMANA && Me.HasLivePet && Me.Pet.Mana < FEEDMANA_PCT)))
            {
                CastSpell("PL.Lifetap");
                return true;
            }
            return false;
        }

        //Checks for and casts Drain Life
        bool DrainLife(GUnit Target, bool ForceUse)
        {
            //Added logging to Drainlife for testing  BEANS
            //Context.Log("DrainLife function check on ForceUse is " + ForceUse);
            //Context.Log("My health pct is "+Me.Health+" and my mana pct is " + Me.Mana);
            CheckHealth(Me.IsInCombat);
            if ((USE_DRAINLIFE && (Me.Health < DRAINLIFE_PCT) || ForceUse))
            {
                //Because its channeling it will often kill before we have a chance to drain soul so we do castspellwithinterrupt to fix it
                //Context.Log("DrainLife SS Check - My current SS count is " + SoulShardCount + " with a max of " + SOULSHARDS_MAX);
                if (SoulShardCount < SOULSHARDS_MAX && (Target.Health < MIN_MOB_HEALTH_PCT))
                {
                    ShadowCheck(Target);
                    if (USE_LIFETAP && (Me.Health > EMERGENCY_HEALTH))
                    {
                        //Context.Log("Casting Lifetap from within DrainLife function");
                        CastSpell("PL.Lifetap");
                        Thread.Sleep(250);
                    }
                    if (SoulShardCount < 1)
                    {
                        SoulShardCount = 0;
                    }
                    Target.Face();
                    if (!Target.IsDead)
                    {
                        CastSwitchSpell("PL.DrainLife", "PL.DrainSoul", Target, DRAINSOUL_PCT);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {

                    ShadowCheck(Target);
                    //Context.Log("Use Lifetap is " + USE_LIFETAP);
                    if (USE_LIFETAP && (Me.Health > MIN_HEALTH_PCT) && (Me.Mana < MIN_MANA_PCT))
                    {
                        //Context.Log("Casting Lifetap from within DrainLife function");
                        CastSpell("PL.Lifetap");
                        Thread.Sleep(250);
                    }
                    try
                    {
                        Target.Face();
                        if (!Target.IsDead)
                        {
                            CastSpell("PL.DrainLife");
                            Thread.Sleep(250);
                        }
                        if ((Me.Health < MIN_HEALTH_PCT) && (Me.Mana > .3)&&(!Target.IsDead)) //If we are low on health and have at least 30% lets throw another Drain Life
                        {
                            Target.Face();
                            CastSpell("PL.DrainLife");
                            Thread.Sleep(250);
                        }
                    }
                    catch (Exception e)
                    {
                        if (Target == null)
                            Context.Log("You errored out during DrainLife - Notes Target = null so I tried to bomb out.");
                        else
                            Context.Log("You Errored out during DrainLife - \r\n " + e.ToString());
                    }
                    return true;
                }
            }
            return false;
        }

        //Checks for and casts ShadowBolt
        bool CastShadowBolt(GUnit Target)
        {
            if (Target.Health > MIN_MOB_HEALTH_PCT && Me.Mana > MIN_MANA_PCT)
            {
                //Context.Log("DBG - ShadowBolt code!");
                if (Target.DistanceToSelf > ShadowBoltRange) Target.Approach(ShadowBoltRange, false);
                Target.Face();
                CastSpell("PL.ShadowBolt", Target);
                Thread.Sleep(250);
                return true;
            }
            return false;
        }

        //Initiate primary attack
        bool PrimaryAttack(GUnit Target)
        {
            switch (PRIMARY_ATTACK)
            {
                case "Drain Life":
                    return DrainLife(Target, true);
                case "Shadow Bolt":
                    return CastShadowBolt(Target);
                case "Wand":
                    Wand(Target);
                    return true;
                case "Melee":
                    return Melee(Target);
            }
            return false;
        }

        bool Melee(GUnit Target)
        {
            if (Target.Approach())
            {
                Movement.TweakMelee(Target);
                return true;
            }
            return false;
        }

        //Target a specified unit if not already targeted
        void TargetUnit(GUnit Target, bool FirstTarget)
        {
            Target.Refresh(true);
            if (Target.IsDead || (Me.TargetGUID == Target.GUID)) return;
            Target.Face();
            Target.SetAsTarget(FirstTarget);
        }

        //Checks if pet is alive, if not, summons a pet
        void CheckPet()
        {
            if (!Me.HasLivePet && SUMMON_DEMON != "None")     //This checks for a Pet.  Post Dismount mostly. Will wait up to 3 seconds for it to appear.
            {
                for (int x = 0; (x < 30 && !Me.HasLivePet); x++)
                {
                    Thread.Sleep(100);
                    if (Me.HasLivePet)
                    {
                        break;
                    }
                }
            }

            //If no pet, ...
            if ((!Me.IsInCombat || RESUMMON_IN_COMBAT) && ((!Me.HasLivePet && SUMMON_DEMON != "None") || (!Me.IsInCombat && Me.HasLivePet && HasWrongPet && SoulShardCount > 0)))
            {
                if (USE_FELDOMINATION && FelDomination.IsReady && Me.IsInCombat)
                {
                    CastSpell("PL.FelDomination");
                    FelDomination.Reset();
                }
                //Switch to summon defined demon
                switch (SUMMON_DEMON)
                {
                    case "Voidwalker":
                        SoulShardCount = CountSoulShards();
                        if (SoulShardCount > 0)
                        {
                            CastSpell("PL.SummonVoidwalker");
                            HasWrongPet = false;
                        }
                        break;
                    case "Felguard":
                        SoulShardCount = CountSoulShards();
                        if (SoulShardCount > 0)
                        {
                            CastSpell("PL.SummonFelguard");
                            HasWrongPet = false;
                        }
                        break;
                    case "Succubus":
                        SoulShardCount = CountSoulShards();
                        if (SoulShardCount > 0)
                        {
                            CastSpell("PL.SummonSuccubus");
                            HasWrongPet = false;
                        }
                        break;
                    case "Felhunter":
                        SoulShardCount = CountSoulShards();
                        if (SoulShardCount > 0)
                        {
                            CastSpell("PL.SummonFelhunter");
                            HasWrongPet = false;
                        }
                        break;
                    case "Imp":
                        CastSpell("PL.SummonImp");
                        HasWrongPet = false;
                        break;
                }
                if ((SUMMON_DEMON != "Imp" && SUMMON_DEMON != "None") && SoulShardCount <= 0 && !Me.HasLivePet)
                {
                    Context.Log("No Soul Shards - Calling Imp");
                    CastSpell("PL.SummonImp");
                    HasWrongPet = true;
                }
                SoulShardCount = CountSoulShards();
                Thread.Sleep(MISCDELAY * 3);
            }
        }

        //Checks armor buff (Demon Armor, Fel Armor) and Soul Link
        void CheckBuffs()
        {
            if (!Me.IsInCombat)
            {
                if (USE_ARMORBUFF && ArmorBuff.IsReady)
                {
                    CastSpell("PL.ArmorBuff");
                    ArmorBuff.Reset();
                    Thread.Sleep(500);
                }
                if (USE_SOULLINK && Me.HasLivePet && !Me.HasBuff(SoulLinkSpellID))
                {
                    CastSpell("PL.SoulLink");
                    Thread.Sleep(500);
                }
            }
        }

        //Checks health - Food first (not in combat), then Healthstone, then Health Potion
        void CheckHealth(bool Combat)
        {
            //Context.Log("Checking Health levels...");
            if (USE_FOOD && Me.Health < Context.RestHealth && !Combat && Interface.GetActionInventory("Common.Eat") > 0)
            {
                SendKey("Common.Eat");
                EatOrDrinkWait.Reset();
                bIsEating = true;
            }
            else if (SIT_TO_REGEN && Me.Health < Context.RestHealth && !Combat)
            {
                if (!Me.IsSitting)
                {
                    SendKey("Common.Sit");
                }
                EatOrDrinkWait.Reset();
                bIsEating = true;
            }
            else if (Me.Health < EMERGENCY_HEALTH)
            {
                if (USE_DEATHCOIL && DeathCoil.IsReady)
                {
                    CastSpell("PL.Deathcoil");
                    DeathCoil.Reset();
                }
                if (USE_HEALTHSTONE && Healthstone.IsReady && Interface.GetActionInventory("PL.UseHealthstone") > 0)
                {
                    CastSpell("PL.UseHealthstone");
                    Healthstone.Reset();

                }
                else if (USE_HEALTHPOTION && Potion.IsReady && Interface.GetActionInventory("Common.Potion") > 0)
                {
                    CastSpell("Common.Potion");
                }
                else if (Me.HasLivePet && VoidwalkerSacrifice.IsReady && USE_SACRIFICE == "Void" && SUMMON_DEMON == "Voidwalker" && !HasWrongPet)
                {
                    SendKey("PL.VoidwalkerSacrifice");
                    VoidwalkerSacrifice.Reset();
                }
            }
        }

        //No PVP yet, wait for death
        void WaitForPlayerDeath()
        {
            GSpellTimer WaitTime = new GSpellTimer(30 * 1000);
            Random RandomClass = new Random();
            while (!WaitTime.IsReady)
            {
                SendKey("Common.Jump");
                Thread.Sleep(RandomClass.Next(5000, 10000));
                SendKey("Common.Sit");
                Thread.Sleep(RandomClass.Next(5000, 10000));
            }
        }

        //Debuff cast sequence
        void CastSequence(GUnit Target, bool ForceAll)
        {
            //Check if monster health is great enough to debuff
            SoulShardCount = CountSoulShards();
            if (Target.Health > MIN_MOB_HEALTH_PCT)
            {
                int i;
                //Loop for length of spell array
                for (i = 0; (i < SPELL_ORDER.Length && !Target.IsDead); i++)
                {
                    ShadowCheck(Target);
                    //Check for min mana
                    if (Me.Mana > MIN_MANA_PCT && Me.Health > EMERGENCY_HEALTH && Target.Health > MIN_MOB_HEALTH_PCT && Target.DistanceToSelf < (PullDistance + TARGET_DUMP_DISTANCE))
                    {
                        if (Target.IsDead)
                        {
                            break;
                        }

                        if (USE_BLOODFURY && BloodFury.IsReady)
                        {
                            CastSpell("PL.BloodFury");
                            BloodFury.Reset();
                            GlobalCooldown.ForceReady();
                            Thread.Sleep(MISCDELAY);
                        }
                        //Switch to select correct spell
                        //Context.Log("Casting spell '" + SPELL_ORDER[i] + "' which is spell " + (i+1) + " of " + SPELL_ORDER.Length + "!");
                        Thread.Sleep(250);
                        CheckHealth(Me.IsInCombat);
                        /* RecursiveBot 2.17.1 D
                         * The following is to ensure that we send in the pet after dismounting
                         * and starting to cast.
                         */
                        if (Me.HasLivePet && PET_ATTACK && !Me.Pet.IsInCombat)
                        {
                            //Context.Log("Your pet should being attacking now");
                            SendKey("Common.PetAttack");
                        }
                        switch (SPELL_ORDER[i])
                        {
                            case "UnstableAffliction":
                                //Context.Log("DBG - Unstable Affliction ready check is " + UnstableAffliction.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (UnstableAffliction.IsReady || ForceUnstableAffliction || ForceAll)
                                {
                                    if (ForceUnstableAffliction) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.UnstableAffliction");
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        UnstableAffliction.Reset();
                                        ForceUnstableAffliction = false;
                                    }
                                }
                                break;

                            case "SiphonLife":
                                //Context.Log("DBG - Siphon Life ready check is " + SiphonLife.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (SiphonLife.IsReady || ForceSiphonLife || ForceAll)
                                {
                                    if (ForceSiphonLife) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.SiphonLife");
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        SiphonLife.Reset();
                                        ForceSiphonLife = false;
                                    }
                                }
                                break;

                            case "CurseofAgony":
                                //Context.Log("DBG - Curse of Agony ready check 1 is " + CurseOfAgony.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (CurseOfAgony.IsReady || ForceCurseOfAgony || ForceAll)
                                {
                                    if (USE_AMPLIFYCURSE && AmplifyCurse.IsReady)
                                    {
                                        SendKey("PL.AmplifyCurse");
                                        AmplifyCurse.Reset();
                                        Thread.Sleep(MISCDELAY);
                                    }
                                    if (ForceCurseOfAgony) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.CurseofAgony");
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        CurseOfAgony.Reset();
                                        ForceCurseOfAgony = false;
                                    }
                                }
                                break;

                            case "Corruption":
                                //Context.Log("DBG - Corruption ready check 1 is " + Corruption.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (Corruption.IsReady || ForceCorruption || ForceAll)
                                {
                                    if (ForceCorruption) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.Corruption", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        Corruption.Reset();
                                        ForceCorruption = false;
                                    }
                                }
                                break;

                            case "CurseOfRecklessness":
                                //Context.Log("DBG - CurseOfRecklessness ready check is " + CurseOfRecklessness.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (CurseOfRecklessness.IsReady || ForceCurseOfRecklessness || ForceAll)
                                {
                                    if (ForceCurseOfRecklessness) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.CurseOfRecklessness", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        CurseOfRecklessness.Reset();
                                        ForceCurseOfRecklessness = false;
                                    }
                                }
                                break;

                            case "Immolate":
                               //Context.Log("DBG - Immolate ready check 1 is " + Immolate.IsReady);
                               while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (Immolate.IsReady || ForceImmolate || ForceAll)
                                {
                                    if (ForceImmolate) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.Immolate", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        Immolate.Reset();
                                        ForceImmolate = false;
                                    }
                                }
                                break;

                            case "Shadowburn":
                                //Context.Log("DBG - Shadowburn ready check is " + Shadowburn.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if ((Shadowburn.IsReady || ForceShadowburn || ForceAll) && SoulShardCount > 0 && Target.Health < 20)
                                {
                                    if (ForceShadowburn) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.Shadowburn", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        Shadowburn.Reset();
                                        ForceShadowburn = false;
                                    }
                                }
                                break;

                            case "ShadowBolt":
                                //Context.Log("DBG - ShadowBolt ready check is " + ShadowBolt.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if (ShadowBolt.IsReady || ForceShadowBolt || ForceAll)
                                {
                                    if (ForceShadowBolt) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.ShadowBolt", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        ShadowBolt.Reset();
                                        ForceShadowBolt = false;
                                    }
                                }
                                break;

                            case "Conflagurate":
                                //Context.Log("DBG - Conflagurate ready check is " + Conflagurate.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if ((Conflagurate.IsReady || ForceConflagurate || ForceAll) && (!Immolate.IsReady)) //We only want to cast if Immolate is on target
                                {
                                    if (ForceConflagurate) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.Conflagurate", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        Conflagurate.Reset();
                                        ForceConflagurate = false;
                                    }
                                }
                                break;

                            case "Incinerate":
                                //Context.Log("DBG - Incinerate ready check is " + Conflagurate.IsReady);
                                while (!Interface.IsKeyReady("PL."+SPELL_ORDER[i]))
                                {
                                    Thread.Sleep(150);
                                }
                                if ((Incinerate.IsReady || ForceIncinerate || ForceAll) && (!Immolate.IsReady)) //We only want to cast if Immolate is on target
                                {
                                    if (ForceIncinerate) Context.Log("Recast");
                                    Target.Face();
                                    CastSpell("PL.Incinerate", Target);
                                    Thread.Sleep(150);
                                    if (!ForceAll)
                                    {
                                        Incinerate.Reset();
                                        ForceIncinerate = false;
                                    }
                                }
                                break;
                        }
                         
                    }
                }
            }
        }

        void ShadowCheck(GUnit Target)
        {
                                //If use Nightfall, checks if have shadow trance and cast
                    if (USE_NIGHTFALL && (Me.Mana > .30) && Me.HasBuff(ShadowTranceSpellID))
                    {
                        Context.Log("SHADOWTRANCE! Casting now!");
                        CastShadowBolt(Target);
                        Thread.Sleep(250);
                    }
        }

        //Check to see if have Healthstone, create
        void CheckHealthstone()
        {
            if (USE_HEALTHSTONE && SoulShardCount > 0 && !Me.IsInCombat)
            {
                if (Interface.GetActionInventory("PL.UseHealthstone") < 1)
                {
                    Thread.Sleep(500);
                    CastSpell("PL.CreateHealthstone");
                    Thread.Sleep(500);
                }
            }
        }

        //Reset combat timers after monster dead or after ressurect
        void Reset()
        {
            Corruption.ForceReady();
            CurseOfAgony.ForceReady();
            SiphonLife.ForceReady();
            CurseOfRecklessness.ForceReady();
            Immolate.ForceReady();
            UnstableAffliction.ForceReady();
            Fear.ForceReady();
            DoReturnPet = true;
        }

        //Cast wand
        void Wand(GUnit Target)
        {
            Target.Face();
            if (!Interface.IsKeyFiring("PL.Wand"))
            {
                SendKey("PL.Wand");
                Thread.Sleep(MISCDELAY);
            }
        }

        //Get number of Soul Shards
        int CountSoulShards()
        {
            if (SOULSHARDS_MAX > 0)
            {
                int tempCount = -1;
                if (USE_HEALTHSTONE)
                {
                    tempCount = Interface.GetActionInventory("PL.CreateHealthstone");
                    if (tempCount >= 0)
                    {
                        return tempCount;
                    }
                    else
                    {
                        Context.Log("Error: Can't count Soul Shards on PL.CreateHealthstone, attempting workaround");
                    }
                }

                switch (SUMMON_DEMON)
                {
                    case "Voidwalker":
                        tempCount = Interface.GetActionInventory("PL.SummonVoidwalker");
                        break;
                    case "Felguard":
                        tempCount = Interface.GetActionInventory("PL.SummonFelguard");
                        break;
                    case "Succubus":
                        tempCount = Interface.GetActionInventory("PL.SummonSuccubus");
                        break;
                    case "Felhunter":
                        tempCount = Interface.GetActionInventory("PL.SummonFelhunter");
                        break;
                    case "None":  //adding for debug
                        tempCount = Interface.GetActionInventory("PL.SummonVoidwalker");
                        Context.Log("Although I was not told to use a Pet, I was able to count " + tempCount + " Soulshards!");
                        break;
                }
                if (tempCount >= 0)
                {
                    //Context.Log("I was able to count " + tempCount + " Soulshards!");
                    return tempCount;
                }
                else
                {
                    Context.Log("Error: Can't count Soul Shards");
                }
            }
            return 0;
        }

        void PostCombat()
        {
            Context.Log("starting post combat");
            Me.Refresh(true);
            ResetAddsControl();
            Reset();
             //RAGE - Begin
            ResetBTMTimer();
            //RAGE - End
            int count = 0;
            while (count < 3)
            {
                if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack) CheckHealth(Me.IsInCombat);
                /* RecursiveBot 2.17.1 B
                 * Following check is to ensure that we don't resummon a pet needlessly. Quick fix 
                 * to the summon new pet every time your mounted and have a target.
                 */
                if (!IsMounted(Me))
                {
                    if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack) CheckPet();
                    if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack) PetHealth();
                    if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack && !Me.Pet.IsInCombat) CheckBuffs();
                    if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack && !Me.Pet.IsInCombat) CheckHealthstone();
                }
                else 
                {
                    Context.Log("found the heffer that resummons the pet");
                }
                if (!Me.IsDead && !Me.IsInCombat && !Me.IsUnderAttack) CheckMana();
                while (!EatOrDrinkWait.IsReady || !ConsumeShadows.IsReady)
                {
                    Me.Refresh();
                    Thread.Sleep(100);
                    if (Me.IsUnderAttack || Me.IsInCombat || Me.IsDead)
                    {
                        EatOrDrinkWait.ForceReady();
                        ConsumeShadows.ForceReady();
                    }
                    else if (bIsEating && !bIsDrinking)
                    {
                        if (Me.Health == 1.0) EatOrDrinkWait.ForceReady();
                    }
                    else if (!bIsEating && bIsDrinking)
                    {
                        if (Me.Mana == 1.0) EatOrDrinkWait.ForceReady();
                    }
                    else if (Me.Health == 1.0 && Me.Mana == 1.0) EatOrDrinkWait.ForceReady();
                    else if (Me.Pet.Health == 1.0 && !ConsumeShadows.IsReady)
                    {
                        ConsumeShadows.ForceReady();
                        SendKey("Common.PetFollow");
                    }
                }
                bIsEating = false;
                bIsDrinking = false;
                count++;
            }
        }

        //PVP combat function
        GCombatResult PVP(GUnit Target)
        {
            PVPTimer.Reset();
            //Reset timers
            Reset();
            //Sets an anchor to keep from getting too far away
            GLocation startLocation = Me.Location;
            //Send in pet and wait for predefined amount of time
            if (Me.HasLivePet && PET_ATTACK)
            {
                SendKey("Common.PetAttack");
            }

            if (Target.DistanceToSelf > FearRange) Target.Approach(FearRange - 3, false);
            CastSpell("PL.Fear", Target);

            //While less than PVPTimer seconds passed...
            while (!PVPTimer.IsReady)
            {
                Target.Refresh(true);

                //If target is dead, return to start point and report Success
                if (Target.IsDead)
                {
                    SoulShardCount = CountSoulShards();
                    Context.Log("Killed target, returning to start");
                    Movement.MoveToLocation(startLocation, 20, false);
                    return GCombatResult.Success;
                }
                //If further than 40 away from start, return to start point and report Success
                else if (startLocation.DistanceToSelf > (PullDistance + TARGET_DUMP_DISTANCE))
                {
                    SoulShardCount = CountSoulShards();
                    Context.Log("Straying too far, returning to start");
                    Movement.MoveToLocation(startLocation, 20, false);
                    return GCombatResult.Success;
                }

                Me.Refresh(true);
                if (Me.IsDead)
                {
                    return GCombatResult.Died;
                }

                //If target further than PullDistance and less than 60, approach to PullDistance
                if (Target.DistanceToSelf > PullDistance && Target.DistanceToSelf < (PullDistance + TARGET_DUMP_DISTANCE)) Target.Approach(PullDistance - 3, false);
                
                if (Target.DistanceToSelf > (PullDistance + TARGET_DUMP_DISTANCE)) //Added 2.15 dump target if too far
                {
                    Context.Log("We tried to fight " + Target.Name + " but we travelled > " + TARGET_DUMP_DISTANCE + " to fight him. Resetting!");
                    SendKey("Common.ClearTargetMacro");
                    if (Me.HasLivePet && RETURN_PET) 
                    {
                        Context.Log("Recalling Pet.");
                        SendKey("Common.PetFollow");
                    }
                    return GCombatResult.Success;
                }

                //Stop Walking, Face
                Context.ReleaseSpinRun();
                Target.Face();

                TargetUnit(Target, false);

                //Check health
                CheckHealth(Me.IsInCombat);

                /* RecursiveBot 2.17.1 B
                 * Following check is to ensure that we don't resummon a pet needlessly. Quick fix 
                 * to the summon new pet every time your mounted and have a target.
                 */
                if (!IsMounted(Me))
                {
                    CheckPet();
                }
                if (!Target.IsDead)
                {
                    //Cast Debuffs

                    CastSequence(Target, false);
                    
                    //Cast Fear
                    if (Fear.IsReady)
                    {
                        if (Target.DistanceToSelf > FearRange) Target.Approach(FearRange - 3, false);
                        CastSpell("PL.Fear", Target);
                        Fear.Reset();
                    }
                    ShadowCheck(Target);
                    //Check various things
                    if (PetHealth())
                    {
                    }
                    /*else if (DrainSoul(Target))
                    {
                    }*/
                    else if (CheckMana(Target))
                    {
                    }
                    else if (DrainLife(Target, false))
                    {
                    }
                    else if (PrimaryAttack(Target))
                    {
                    }
                    else LastResort(Target);
                }
                Thread.Sleep(100);
            }
            //If timer runs out, return to start point and report Bugged
            Context.Log("PVP Timer expired, returning to start.");
            Movement.MoveToLocation(startLocation, 20, false);
            return GCombatResult.Success;
        }

        //Modified Context.CastSpell() (Overloaded - nondirectional casting) - turns off wand, waits for key, pause for specified delay, cast
        void CastSpell(string Spell)
        {

            Context.Log(Format(Replace(Replace(Spell, "PL.", "Casting: "), "Common.", "Casting: ")));
            if (Interface.IsKeyFiring("PL.Wand"))
            {
                SendKey("PL.Wand");
                GlobalCooldown.Reset();
            }
            if (Me.IsSitting)
            {
                SendKey("Common.Back");
                Thread.Sleep(200);
            }
            GlobalCooldown.Wait();
            while (!Interface.IsKeyReady(Spell))
            {
                Thread.Sleep(200);
            }
            Context.SendKey(Spell);
            GlobalCooldown.Reset();
            OneSecTimer.Reset();
            while (!OneSecTimer.IsReady)
            {
                Thread.Sleep(100);
                if (Me.IsCasting)
                {
                    while (Me.IsCasting)
                    {
                        Thread.Sleep(100);
                    }
                    break;
                }
            }
        }

        //Modified Context.CastSpell() (Overloaded - directional casting) - turns off wand, waits for key, pause for specified delay, cast - keeps facing target while casting
        void CastSpell(string Spell, GUnit Target)
        {
            Context.Log(Format(Replace(Replace(Spell, "PL.", "Casting: "), "Common.", "Casting: ")));
            if (Interface.IsKeyFiring("PL.Wand"))
            {
                SendKey("PL.Wand");
                GlobalCooldown.Reset();
            }
            if (Me.IsSitting)
            {
                SendKey("Common.Back");
                Thread.Sleep(200);
            }
            GlobalCooldown.Wait();
            while (!Interface.IsKeyReady(Spell))
            {
                Thread.Sleep(200);
            }
            Target.Face();
            //Context.CastSpell(Spell, false, true);
            Context.SendKey(Spell);
            GlobalCooldown.Reset();
            OneSecTimer.Reset();
            while (!OneSecTimer.IsReady)
            {
                Thread.Sleep(100);
                if (Me.IsCasting)
                {
                    while (Me.IsCasting)
                    {
                        Target.Face();
                        Thread.Sleep(100);
                    }
                    break;
                }
            }
        }

        //Takes two spells. First MUST be channeling, second CAN be channeling.
        void CastSwitchSpell(string FirstSpell, string SecondSpell, GUnit Target, double TargetHealthToSwitch)
        {
            Context.Log(Format(Replace(Replace(FirstSpell, "PL.", "Casting: "), "Common.", "Casting: ")));
            if (Interface.IsKeyFiring("PL.Wand"))
            {
                SendKey("PL.Wand");
                GlobalCooldown.Reset();
            }
            if (Me.IsSitting)
            {
                SendKey("Common.Back");
                Thread.Sleep(200);
            }
            GlobalCooldown.Wait();
            Target.Face();
            //Context.CastSpell(FirstSpell, false, true);
            Context.SendKey(FirstSpell);
            GlobalCooldown.Reset();
            OneSecTimer.Reset();
            while (!OneSecTimer.IsReady)
            {
                Thread.Sleep(100);
                if (Me.IsCasting)
                {
                    while (Me.IsCasting)
                    {
                        if (Target.Health < TargetHealthToSwitch)
                        {
                            CastSpell(SecondSpell);
                            break;
                        }
                        Target.Face();
                        Thread.Sleep(100);
                    }
                    break;
                }
            }
        }

        void SendKey(String Key)
        {
            Context.Log(Format(Replace(Replace(Key, "PL.", "Sending Key: "), "Common.", "Sending Key: ")));
            Context.SendKey(Key);
        }

        bool WaitForEngage(GUnit Target, int Time)
        {
            GSpellTimer BreakLoop = new GSpellTimer(Time, false);
            BreakLoop.Reset();
            while (!BreakLoop.IsReady)
            {
                Thread.Sleep(100);
                if (Target.DistanceToSelf > PullDistance) Target.Approach(PullDistance - 5, false);
                if (Target.Target == Me || Target.Target == Me.Pet || Me.Pet.IsInCombat)
                {
                    return true;
                }
                else if (Me.IsUnderAttack) return false;
            }
            return false;
        }

        bool ArrayContains(long[] Array, long Long)
        {
            foreach (long temp in Array)
            {
                if (temp == Long) return true;
            }
            return false;
        }

        void ResetAddsControl()
        {
            Context.Log("Resetting Adds");
            for (int temp = 0; temp < CastedAdds.Length; temp++)
            {
                CastedAdds[temp] = 0;
            }
            CastedAddsIndex = 0;
        }

        void LastResort(GUnit Target)
        {
            switch (LAST_RESORT)
            {
                case "Wand":

                    if (!Interface.IsKeyFiring("PL.Wand"))
                    {
                        SendKey("PL.Wand");
                    }
                    break;
                case "Melee":
                    Target.Approach();
                    Movement.TweakMelee(Target);
                    break;
                default:
                    return;
            }
        }

        void FormatKey(String startKey)
        {
            String returnKey = startKey;
            //returnKey.
        }

        public static String Replace(String strText, String strFind, String strReplace)
        {
            int iPos = strText.IndexOf(strFind);
            String strReturn = "";
            while (iPos != -1)
            {
                strReturn += strText.Substring(0, iPos) + strReplace;
                strText = strText.Substring(iPos + strFind.Length);
                iPos = strText.IndexOf(strFind);
            }
            if (strText.Length > 0)
                strReturn += strText;
            return strReturn;
        }

        public static String Format(String strString)
        {
            Char[] chrReturn = strString.ToCharArray();
            string strReturn = "";
            for (int count = 0; count < strString.Length; count++)
            {
                if (Char.IsUpper(strString, count))
                {
                    strReturn += " " + chrReturn[count];
                }
                else
                {
                    strReturn += chrReturn[count];
                }
            }
            return strReturn;
        }

        #region Casting Update / Randomization

        void SpellList()
        {
            int i=0;
            if (USE_UNSTABLEAFFLICTION)
            {
                SPELL_ORDER[i] = "UnstableAffliction";
                i++;
            }
            
            if (USE_CORRUPTION)
            {
                SPELL_ORDER[i] = "Corruption";
                i++;  
            }

            if (USE_CURSEOFAGONY)
            {
                SPELL_ORDER[i] = "CurseofAgony";
                i++; 
            }

            if (USE_SIPHONLIFE)
            {
                SPELL_ORDER[i] = "SiphonLife";
                i++;
            }

            if (USE_IMMOLATE)
            {
                SPELL_ORDER[i] = "Immolate";
                i++;
            }

            if (USE_SHADOWBOLT)
            {
                SPELL_ORDER[i] = "ShadowBolt";
                i++;
            }
            
            if (USE_SHADOWBURN)
            {
                SPELL_ORDER[i] = "Shadowburn";
                i++;
            }

            if (USE_CONFLAGURATE)
            {
                SPELL_ORDER[i] = "Conflagurate";
                i++;
            }

            if (USE_INCINERATE)
            {
                SPELL_ORDER[i] = "Incinerate";
                i++;
            }
            Array.Resize(ref SPELL_ORDER, i);
        }
        
        void SpellShuffle(ref string[] values)
        {
            Random rand = new Random(); // used to generate random positive integers   
            int n = values.Length;      // length of the array   
            int r = 0;                  // swap index   
            string swap = String.Empty; // copy of string to swap   

            // iterate through each item in the array   
            for (int i = 0; i < n; i++)
            {
                // get random index of an item to swap with the current item   
                r = i + rand.Next(n - i);

                // swap items   
                swap = values[r];
                values[r] = values[i];
                values[i] = swap;
            }
        }

        #endregion Casting Update / Randomization

        #region Mount

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
         /// <summary>
         /// This method is used to check if a profile target is within the TRAVELFORMDELAY specified
         /// in the options. If this is returns true that means we do not need to mount based
         /// on the fact that there is a monster in our profile within range to kill.
         /// Questionable performance if in a BG due to the fact that faction may not be in profile.
         /// 2.17.1 
         /// </summary>
         /// <returns>True = do not mount, False = mount</returns>
         protected bool ProfileTargetWithinRange()
         {   
             //default value incase delay mount is used should be true
             //until we figure out a dealy scheme. AKA REMOVE the outter if
             //once we have a fix for delay mount
             bool PTWR = true;

             //outter if is used to make sure we are in distance mount currently(no fix implemented for delaymount
             if (TRAVELFORM == "Distance Mount")
             {
                 try
                 {
                     //temporary spot to hold the current PullDistance;
                     int ProfileCastingDistance = PullDistance;
                     //set the pulldistance to 100 inorder to get accurate distance to mount with GetNextProfileTarget();
                     Context.SetConfigValue("PicLock.PULL_DISTANCE", "100", true);
                     

                     GMonster NextProfileTarget = GObjectList.GetNextProfileTarget();

                     if (NextProfileTarget != null)
                     {
                         if (TRAVELFORMDELAY < Me.GetDistanceTo(NextProfileTarget.Location))
                         {
                             PTWR = false;
                             //show me the pull distance vs targetdistance
                             Context.Log("Delay " + TRAVELFORMDELAY + " < ProfileTargetDistance " + Me.GetDistanceTo(NextProfileTarget.Location) + " WithinRange : " + ProfileTargetIsWithinRange);
                             
                         }
                         else
                         {
                             //show me the pull distance vs targetdistance
                             //Context.Log("Delay " + TRAVELFORMDELAY + " > ProfileTargetDistance " + Me.GetDistanceTo(NextProfileTarget.Location) + " WithinRange : "+ProfileTargetIsWithinRange);
                         }
                     }
                     //reset the pull distance to the specified distance in options
                     Context.SetConfigValue("PicLock.PULL_DISTANCE", ProfileCastingDistance.ToString(), true);
                 }
                 catch (Exception mount)
                 {
                     //Crazy error if this ever is seen.
                     Context.Log("Exception thrown in check to see if profiletarget is within range.");
                     Context.Log(mount.ToString());
                 }
             }
             return PTWR;
         }
        
        protected bool BetweenTargetMode(string classname)
        {
            bool bRdy;
            /* RecursiveBot 2.17.1 F
             * The following change was needed to ensure that the profile target was not in range before mounting.
             * ProfileTargetIsWithinRange is set equal to the return value of ProfileTargetWithinRange() during running check.
             */
            bool needtoloot = (Context.CurrentMode != GGlideMode.OneKill) && (Context.IsCorpseNearby || ProfileTargetIsWithinRange);
            bRdy = TRAVELFORMDELAYTIMER.IsReady;
            //Context.Log(" TravelTimer, " + bRdy + " !IsMounted() " + (!IsMounted()) + " -> needtoloot, " + (!needtoloot));
            if (TRAVELFORM == "Delay Mount" && bRdy && !IsMounted())
            {
                if (!needtoloot)
                {
                    Context.Log("Mounting:" + TRAVELFORM);
                    Context.ReleaseSpinRun();
                    Thread.Sleep(500);
                    LeaveForm();
                    Thread.Sleep(500);
                    /* RecursiveBot 2.17.1 E
                     *  Fix for Mount Naming difference in the keys.xml
                     *  old call CastSpell(classname + ".Mount");
                     */
                    CastSpell("PL.Mount");
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
                //Context.Log("Need to loot - stopped Mount process.");
            }
            //removed the test for the timer. not needed if controlled
            if (TRAVELFORM == "Distance Mount" && !IsMounted())
            {
                if (!needtoloot)
                {
                    Context.Log("Mounting:" + TRAVELFORM);
                    GObjectList.SetCacheDirty();
                    GUnit MOB = GObjectList.GetNearestHostile();
                    if (MOB == null || (MOB != null && MOB.DistanceToSelf > TRAVELFORMDELAY))
                    {
                        Context.ReleaseSpinRun();
                        Thread.Sleep(500);
                        LeaveForm();
                        Thread.Sleep(500);
                        /* RecursiveBot 2.17.1 E
                         *  Fix for Mount Naming difference in the keys.xml
                         *  old way 
                         *  CastSpell(classname + ".Mount");
                         */
                        CastSpell("PL.Mount");
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
                            //Context.Log(IsMounted() + " we aren't mounted so fixing to wait 15 seconds.");
                            return false;
                        }
                        return true;
                    }
                    //Context.Log("Hostile is within Range of Distance Mount Setting.");
                }
                //Context.Log("Need to loot - stopped Mount process.");
            }
            return false;
        }

        protected string MOUNTNAME = "";

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
                   (MOUNTNAME.Length>0 && s.Contains(MOUNTNAME)) ||
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
                    //Context.Log("buff found : " + s);
                    if (s != "Ghost Wolf") return true;
                }
                
            }
            return false;
        }
        
        #endregion Mount

    }
}