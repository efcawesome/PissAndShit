using Terraria.ID;
using PissAndShit.Items.Consumables;
using System;
using Terraria;
using Terraria.ModLoader;

namespace PissAndShit
{
    public class PissAndShit : Mod
    {
        internal static Mod BossChecklist;

        public override void Load()
        {
            BossChecklist = ModLoader.GetMod("BossChecklist");

            if (!Main.dedServ)
            {
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/heavenly_bullshit"), ItemType("GodSlimeMusicBox"), TileType("GodSlimeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/YungDook_2"), ItemType("YoungDukeMusicBox"), TileType("YoungDukeMusicBox"));
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/GRANDDAD"), ItemType("GrandDadMusicBox"), TileType("GrandDadMusicBox"));
            }

            //TomatoLoader.AddMod(this);
        }

        public override void PostSetupContent()
        {
            if (BossChecklist != null)
            {
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "Young Duke",
                        5.5f,
                        (Func<bool>)(() => PaSWorld.downedYoungDuke),
                        "Use a [i:" + ModContent.ItemType<YoungWorm>() + "] in the ocean"
                    );
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "God Slime",
                        16f,
                        (Func<bool>)(() => PaSWorld.downedGodSlime),
                        "Use a [i:" + ModContent.ItemType<HeavenlyChalice>() + "]"
                    );
                BossChecklist.Call(
                        "AddBossWithInfo",
                        "GRAND DAD",
                        18f,
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
                        17f,
                        (Func<bool>)(() => PaSWorld.downedHive),
                        "Use an [i:" + ModContent.ItemType<HiveSummon>() + "]"
                    );
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
        public override void Unload() => BossChecklist = null;
    }
}
