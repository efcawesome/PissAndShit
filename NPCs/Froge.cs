using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class Froge : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;
        //int timer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Froge");
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
            Main.npcFrameCount[npc.type] = 53;
        }

        public override void SetDefaults()
        {
            npc.width = 112;
            npc.height = 112;
            npc.damage = 1;
            npc.defense = 10;
            npc.lifeMax = 2000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCHit2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            npc.aiStyle = 5;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }

        public override void AI()
        {
            frameTimer++;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;

            if (frameTimer == 2)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 53)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
        }
    }
}
