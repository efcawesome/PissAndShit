using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs
{
    public class BigMan : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Man");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
        }
        public override void SetDefaults()
        {
            npc.width = 380;
            npc.height = 460;
            npc.damage = 75;
            npc.defense = 25;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit41;
            npc.DeathSound = SoundID.NPCDeath14;
            aiType = NPCID.Zombie;
            npc.aiStyle = 3;
            animationType = NPCID.Zombie;
            npc.knockBackResist = 1;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
        }
        public override void NPCLoot()
        {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BigChunk"), 3);
            }
    }
}
