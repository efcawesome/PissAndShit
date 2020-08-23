using PissAndShit.Items.BossBags;
using PissAndShit.Items.Consumables;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs;
using PissAndShit.NPCs.Bosses;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit
{
    public class PissAndShit : Mod
    {
        public override void PostSetupContent()
        {
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if(bossChecklist != null)
            {
                bossChecklist.Call(
                        "AddBossWithInfo",
                        "Young Duke",
                        5.5f,
                        (Func<bool>)(() => PaSWorld.downedYoungDuke),
                        "Use a [i:" + ModContent.ItemType<YoungWorm>() + "] in the ocean"
                    );
                bossChecklist.Call(
                        "AddBossWithInfo",
                        "God Slime",
                        16f,
                        (Func<bool>)(() => PaSWorld.downedGodSlime),
                        "Use a [i:" + ModContent.ItemType<HeavenlyChalice>() + "]"
                    );
                bossChecklist.Call(
                        "AddBossWithInfo",
                        "GRAND DAD",
                        18f,
                        (Func<bool>)(() => PaSWorld.downedGrandDad),
                        "Use a [i:" + ModContent.ItemType<Mario7>() + "]"
                    );
                bossChecklist.Call(
                        "AddBossWithInfo",
                        "Boozeshrume.exe",
                        6.5f,
                        (Func<bool>)(() => PaSWorld.downedBoozeshrume),
                        "Use a [i:" + ModContent.ItemType<SuspiciousAle>() + "]"
                    );
                bossChecklist.Call(
                        "AddBossWithInfo",
                        "The Hive",
                        17f,
                        (Func<bool>)(() => PaSWorld.downedHive),
                        "Use an [i:" + ModContent.ItemType<HiveSummon>() + "]"
                    );
            }
        }
        public override void Close()
        {
            var slots = new int[] {
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
            foreach (var slot in slots)
            {
                if (Main.music.IndexInRange(slot) && Main.music[slot]?.IsPlaying == true)
                {
                    Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
                }
            }

            base.Close();
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if(PaSWorld.endlesserModeSave == true)
            {
                if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active)
                {
                    return;
                }
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/boss");
                priority = MusicPriority.BossHigh;
            }
        }
    }
}
