using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class GDdemon : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;
        //int timer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GDdemon");
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 128;
            npc.height = 117;
            npc.damage = 30;
            npc.defense = 10;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 26;
            npc.lavaImmune = true;
        }

            public override void AI()
        {
            npc.rotation += npc.velocity.X * 0.1f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.OverworldDaySlime.Chance * 0.1f;
        }
    }
}
