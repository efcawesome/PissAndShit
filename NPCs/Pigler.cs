using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class Pigler : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 8;
            DisplayName.SetDefault("Pigler");
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;
            npc.damage = 18;
            npc.defense = 12;
            npc.lifeMax = 150;
            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 31f;
            npc.knockBackResist = 0.2f;
            npc.aiStyle = 26;
            npc.noGravity = false;
            npc.noTileCollide = false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneJungle)
                return SpawnCondition.Overworld.Chance * 0.12f;
            else return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }

        public override void NPCLoot()
        {

        }
    }
}
