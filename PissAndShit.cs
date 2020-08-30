using Terraria.ID;
using PissAndShit.Items.Consumables;
using System;
using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using PissAndShit.UI;
using Terraria.UI;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit
{
    public class PissAndShit : Mod
    {
	Mod bossChecklist;
	Mod FargosMutantMod;

    internal DeathHandPanelDraw deathHandPanelDraw;
    private UserInterface _deathHandPanelDraw;
        public override void Load()
        {     
            if (!Main.dedServ)
            {
                deathHandPanelDraw = new DeathHandPanelDraw();
                deathHandPanelDraw.Activate();
                _deathHandPanelDraw = new UserInterface();
                _deathHandPanelDraw.SetState(deathHandPanelDraw);
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/heavenly_bullshit"), ItemType("GodSlimeMusicBox"), TileType("GodSlimeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/YungDook_2"), ItemType("YoungDukeMusicBox"), TileType("YoungDukeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/GRANDDAD"), ItemType("GrandDadMusicBox"), TileType("GrandDadMusicBox"));
		        AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Staying_As_a_1.14"), ItemType("BoozeshrumeMusicBox"), TileType("BoozeshrumeMusicBoxSheet"));
            }

       }
        public override void UpdateUI(GameTime gameTime)
        {
            _deathHandPanelDraw?.Update(gameTime);
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
			16f,
			ModContent.NPCType<NPCs.Bosses.DeathItself>(),
			this,
			"Death Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish",
                        (Func<bool>)(() => PaSWorld.downedDeathHimself),
			ModContent.ItemType<WirelessRadar>(),
			0,
			new List<int> { ModContent.ItemType<Items.Weapons.Exoultimagigahypersplosionator>() },
			"Spawn by using [i:" + ModContent.ItemType<WirelessRadar>() + "].",
			"Death has reaped all before it.",
			"PissAndShit/NPCs/Bosses/DeathItself_Still",
			"PissAndShit/NPCs/Bosses/DeathItself_Head_Boss"
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
		// TODO: These calls are deprecated! Replace with 1.0 AddBoss.
		/*
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "GRAND DAD",
                        19f,
                        (Func<bool>)(() => PaSWorld.downedGrandDad),
                        "Use a [i:" + ModContent.ItemType<Mario7>() + "]"
                    );
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "Boozeshrume.exe",
                        6.5f,
                        (Func<bool>)(() => PaSWorld.downedBoozeshrume),
                        "Use a [i:" + ModContent.ItemType<SuspiciousAle>() + "]"
                    );
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "The Hive",
                        18f,
                        (Func<bool>)(() => PaSWorld.downedHive),
                        "Use an [i:" + ModContent.ItemType<HiveSummon>() + "]"
                    );
*/
            }
	    FargosMutantMod = ModLoader.GetMod("Fargowiltas");
            if (FargosMutantMod != null)
            {
	        	FargosMutantMod.Call("AddSummon", 5.5f, "PissAndShit", "YoungWorm", (Func<bool>)(() => PaSWorld.downedYoungDuke), 150000);
                FargosMutantMod.Call("AddSummon", 6.5f, "PissAndShit", "SuspiciousAle", (Func<bool>)(() => PaSWorld.downedBoozeshrume), 300000);
                FargosMutantMod.Call("AddSummon", 16f, "PissAndShit", "WirelessRadar", (Func<bool>)(() => PaSWorld.downedDeathHimself), 8000000);
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
        public override void PostUpdateEverything()
        {
            if (PaSWorld.endlesserModeSave)
            {
                Main.instance.LoadNPC(NPCID.EyeofCthulhu);
                Main.npcTexture[NPCID.EyeofCthulhu] = GetTexture("NPCs/VanillaRecolors/EyeOfEndless");
                Main.instance.LoadNPC(NPCID.TheDestroyer);
                Main.npcTexture[NPCID.TheDestroyer] = GetTexture("NPCs/VanillaRecolors/DestroyerOfGodsHead");
                Main.instance.LoadNPC(NPCID.TheDestroyerBody);
                Main.npcTexture[NPCID.TheDestroyerBody] = GetTexture("NPCs/VanillaRecolors/DestroyerOfGodsBody");
                Main.instance.LoadNPC(NPCID.TheDestroyerTail);
                Main.npcTexture[NPCID.TheDestroyerTail] = GetTexture("NPCs/VanillaRecolors/DestroyerOfGodsTail");
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                "The Funny Community Made Content Mod: Now 200% Better!",
                delegate
                {
                        _deathHandPanelDraw.Draw(Main.spriteBatch, new GameTime());
                        return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }

        public override void Unload() => bossChecklist = null;
    }
}
