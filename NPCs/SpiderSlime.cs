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
    class SpiderSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Slime");
        }

        public override void SetDefaults()
        {
            npc.width = 158;
            npc.height = 115;

            npc.lifeMax = 55;
            npc.damage = 20;
            npc.defense = 5;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.aiStyle = 1;
            aiType = NPCID.GreenSlime;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.SpiderCave.Chance * 0.1f;
        }
    }
}
