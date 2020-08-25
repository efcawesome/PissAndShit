using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class Inflated : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fat Gamer Pig");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.aiStyle = 26;
            npc.damage = 7;
            npc.defense = 2;
            npc.lifeMax = 25;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 25f;
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