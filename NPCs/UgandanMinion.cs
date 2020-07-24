using PissAndShit.Items.Consumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class UgandanMinion : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ugandan Knuckles");
        
        }

        public override void SetDefaults()
        {
            npc.width = 80;
            npc.height = 80;
            npc.lifeMax = 220;
            npc.damage = 28;
            npc.defense = 10;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 10f;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 41;
            aiType = NPCID.Herpling;
            banner = Item.NPCtoBanner(NPCID.Herpling);
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySlime.Chance * 0.15f;
            // You can modify this to offer different scenarios. 
            // For example:
            /*
             * float chance = 0f;
             * if(!Main.dayTime)
             * {
             *     chance += .1f;
             *     if(spawnInfo.spawnTileY <= Main.rockLayer && spawnInfo.spawnTileY >= Main.worldSurface * 0.15)
             *     {
             *         chance += .2f;
             *     }
             * }
             * return chance;
             */
            // In the above example we set a float chance to 0. We then increase it based on conditions.
            // First we check if it is night. If it is, we increase by .1 then we check if the y is between 
            // Main.rockLayer and a bit above WorldSurface. If it is then we add .2.
            // In this example, the enemy is more likely to spawn on surface and underground but can spawn anywhere 
            // if it is night.
        }

        //public override void HitEffect(int hitDirection, double damage)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        int dustType = mod.DustType("TMMCDust");
        //        int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
        //        Dust dust = Main.dust[dustIndex];
        //        dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
        //        dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
        //        dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
        //    }
        //}

        public override void NPCLoot()
        {
            Item.NewItem(npc.position, mod.ItemType("LargeEgg"));
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.position, mod.ItemType("TMMCGenericTile"), 5);
            }
            // This will make the NPC only drop in hardmode
            if (Main.hardMode)
            {
                Item.NewItem(npc.position, ItemID.PlatinumBar, 5);
            }
        }
    }
}
