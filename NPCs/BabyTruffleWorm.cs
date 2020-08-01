using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    class BabyTruffleWorm : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffle Larva");
        }

        public override void SetDefaults()
        {
            npc.width = 158;
            npc.height = 115;

            npc.lifeMax = 5;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            aiType = NPCID.TruffleWorm;
            npc.aiStyle = 66;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.UndergroundMushroom.Chance * 0.1f;
        }
    }
}
