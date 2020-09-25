using Terraria.ID;
using PissAndShit.Items.Consumables;
using System;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace PissAndShit
{
    public class PissAndShit : Mod
    {
	Mod bossChecklist;
	Mod FargosMutantMod;

        public override void Load()
        {     
            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/heavenly_bullshit"), ItemType("GodSlimeMusicBox"), TileType("GodSlimeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/YungDook_2"), ItemType("YoungDukeMusicBox"), TileType("YoungDukeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/GRANDDAD"), ItemType("GrandDadMusicBox"), TileType("GrandDadMusicBox"));
		AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Staying_As_a_1.14"), ItemType("BoozeshrumeMusicBox"), TileType("BoozeshrumeMusicBoxSheet"));
		AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Young_Dook_Phase_2"), ItemType("YoungDukeMusicBoxTwo"), TileType("YoungDukeMusicBoxTwo"));
            }

        }

        public override void PostSetupContent()
        {
	    bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                "AddBoss",
			    5.5f,
			    ModContent.NPCType<NPCs.Bosses.YoungDuke>(),
			    this,
			    "Young Duke",
                (Func<bool>)(() => PaSWorld.downedYoungDuke),
			    ModContent.ItemType<YoungWorm>(),
			    new List<int> { ModContent.ItemType<Items.Misc.YoungDukeMusicBox>() },
			    new List<int> { ModContent.ItemType<Items.Weapons.YoungBow>(), ModContent.ItemType<Items.Weapons.YoungGun>(), ModContent.ItemType<Items.Weapons.youngdukeyoyo>(), ModContent.ItemType<Items.Weapons.YoungRazorTyphoon>() },
			    "Spawn by using [i:" + ModContent.ItemType<YoungWorm>() + "] at the Ocean.",
			    "Young Duke has outsped everyone!",
			    "PissAndShit/NPCs/Bosses/YoungDuke_Still",
			    "PissAndShit/NPCs/Bosses/YoungDuke_Head_Boss"
                );
		
                bossChecklist.Call(
                "AddBoss",
			    6.5f,
			    ModContent.NPCType<NPCs.Bosses.boozeshrume>(),
			    this,
			    "boozeshrume.exe",
                (Func<bool>)(() => PaSWorld.downedBoozeshrume),
			    ModContent.ItemType<SuspiciousAle>(),
			    new List<int> { ModContent.ItemType<Items.Misc.BoozeshrumeMusicBox>() },
			    new List<int> { ModContent.ItemType<Items.BossBags.BoozeshrumeBag>(), ModContent.ItemType<Items.Misc.ScrumpyCiderRedwineTequillaWhiskeyVodkaRumArrackSpiritPureEthanolDrinkMix>(), ModContent.ItemType<Items.Weapons.BeerBook>(), ModContent.ItemType<Items.Weapons.BeerBow>() },
			    "Spawn by using [i:" + ModContent.ItemType<SuspiciousAle>() + "].",
			    "boozeshrume.exe has completed successfully.",
			    "PissAndShit/NPCs/Bosses/boozeshrume",
			    "PissAndShit/NPCs/Bosses/boozeshrume_Head_Boss"
                );

                bossChecklist.Call(
                "AddBoss",
			    6.5f,
			    ModContent.NPCType<NPCs.Bosses.GrandDad>(),
			    this,
			    "Grand Dad",
                (Func<bool>)(() => PaSWorld.downedGrandDad),
			    ModContent.ItemType<Mario7>(),
			    new List<int> { ModContent.ItemType<Items.Misc.GrandDadMusicBox>() },
			    new List<int> { ModContent.ItemType<Items.BossBags.GrandDadBag>(), ModContent.ItemType<Items.Weapons.the7>(), ModContent.ItemType<Items.Weapons.DaedalusSevenbow>(), ModContent.ItemType<Items.Weapons.SevenShortsword>() },
			    "Spawn by using [i:" + ModContent.ItemType<Mario7>() + "].",
			    "Grand Dad has turned everyone into flint and stones...",
			    "PissAndShit/NPCs/Bosses/GrandDad_Still",
			    "PissAndShit/NPCs/Bosses/GrandDad_Head_Boss"
                );

                bossChecklist.Call(
                "AddBoss",
			    6.5f,
			    ModContent.NPCType<NPCs.Bosses.Hive>(),
			    this,
			    "Hive",
                (Func<bool>)(() => PaSWorld.downedHive),
			    ModContent.ItemType<HiveSummon>(),
			    0,
			    new List<int> { ModContent.ItemType<Items.BossBags.HiveBag>(), ModContent.ItemType<Items.Weapons.BeeBook>(), ModContent.ItemType<Items.Weapons.BeeBasher>(), ModContent.ItemType<Items.Weapons.BeeTime>() },
			    "Spawn by using [i:" + ModContent.ItemType<HiveSummon>() + "].",
			    "The Hive's minions have stung everyone to death...",
			    "PissAndShit/NPCs/Bosses/Hive",
			    "PissAndShit/NPCs/Bosses/Hive_Head_Boss"
                );
            }
	        FargosMutantMod = ModLoader.GetMod("Fargowiltas");
            if (FargosMutantMod != null)
            {
	        	FargosMutantMod.Call("AddSummon", 5.5f, "PissAndShit", "YoungWorm", (Func<bool>)(() => PaSWorld.downedYoungDuke), 150000);
                FargosMutantMod.Call("AddSummon", 6.5f, "PissAndShit", "SuspiciousAle", (Func<bool>)(() => PaSWorld.downedBoozeshrume), 300000);
	        	FargosMutantMod.Call("AddSummon", 17f, "PissAndShit", "HeavenlyChalice", (Func<bool>)(() => PaSWorld.downedGodSlime), 12000000);
                FargosMutantMod.Call("AddSummon", 18f, "PissAndShit", "HiveSummon", (Func<bool>)(() => PaSWorld.downedHive), 1);
	    }
	}
			   

        public override void Close()
        {
            int[] slots = new int[] {
                GetSoundSlot(SoundType.Music, "Sounds/Music/BallsOfFlesh"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/CHUNGUS"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/GRANDDAD"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/heavenly_bullshit"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/POOP_WORM"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/Staying_As_a_1.14"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/Young_Dook_Phase_2"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/YungDook_2"),
                GetSoundSlot(SoundType.Music, "Sounds/Music/boss")
            };
            foreach (int slot in slots)
            {
                if (Main.music.IndexInRange(slot) && (bool)(Main.music[slot]?.IsPlaying))
                {
                    Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
                }
            }

            base.Close();
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (PaSWorld.endlesserModeSave)
            {
                if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                {
                    return;
                }
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/boss");
                priority = MusicPriority.BossHigh;
            }
        }
        public override void Unload() => bossChecklist = null;
    }
}
