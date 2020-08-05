using PissAndShit.Items.BossBags;
using PissAndShit.Items.Consumables;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs;
using PissAndShit.NPCs.Bosses;
using System;
using System.Collections.Generic;
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
    }
}
