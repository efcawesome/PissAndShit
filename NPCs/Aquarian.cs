using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class Aquarian : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aquarian");
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 72;
            npc.height = 56;
            npc.damage = 22;
            npc.defense = 9;
            npc.lifeMax = 108;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath7;
            npc.value = 31f;
            npc.knockBackResist = 0.07f;
            npc.aiStyle = 3;
            npc.noGravity = false;
            npc.noTileCollide = false;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.player.ZoneRain)
            {
                return SpawnCondition.Overworld.Chance * 0.12f;
            }
            else if (spawnInfo.player.ZoneBeach)
            {
                return SpawnCondition.Overworld.Chance * 0.18f;
            }
            else
            {
                return 0.1f;
            }
        }

        public override void AI()
        {
            frameTimer++;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Coral, Main.rand.Next(3, 5));
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;

            if (frameTimer == 3)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 4)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
        }
    }
}