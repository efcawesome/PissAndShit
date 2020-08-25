using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class HermesSlime : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;
        private int jumpTimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hermes Boots Slime");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 32;
            npc.height = 26;
            npc.damage = 20;
            npc.lifeMax = 200;
            npc.defense = 15;
            npc.knockBackResist = 0;
            npc.value = 10000;
            npc.aiStyle = -1;
            npc.lavaImmune = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void AI()
        {
            frameTimer++;
            jumpTimer++;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 targetPosition = Main.player[npc.target].position;
            Vector2 position = new Vector2(npc.position.X, npc.position.Y + npc.height);
            if (targetPosition.X < npc.position.X)
            {
                npc.spriteDirection = -1;
            }
            else if (targetPosition.X > npc.position.X)
            {
                npc.spriteDirection = 1;
            }
            if (targetPosition.X < npc.position.X && npc.velocity.X > -15)
            {
                npc.velocity.X -= 0.22f;
            }
            if (targetPosition.X > npc.position.X && npc.velocity.X < 15)
            {
                npc.velocity.X += 0.22f;
            }
            if (jumpTimer >= 60 && Main.rand.NextBool(3) && npc.velocity.Y == 0)
            {
                npc.velocity.Y -= 5f;
                jumpTimer = 0;
            }
            else if (jumpTimer >= 60)
            {
                jumpTimer = 0;
            }
            if (npc.velocity.X > 5 || npc.velocity.X < -5)
            {
                if (npc.velocity.Y == 0)
                {
                    Dust dust;
                    dust = Main.dust[Terraria.Dust.NewDust(position, 30, 0, 16, 0f, 0f, 0, new Color(255, 255, 255), 1.447368f)];
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (frameNum == 2)
            {
                frameNum = 0;
            }
            if (frameTimer == 6)
            {
                frameNum++;
                frameTimer = 0;
            }
            npc.frame.Y = frameNum * frameHeight;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underground.Chance * 0.05f;
        }

        public override void NPCLoot()
        {
            Item.NewItem(new Vector2(npc.Center.X, npc.Center.Y), ItemID.HermesBoots);
        }
    }
}