using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using System;

namespace PissAndShit.NPCs
{
    class GasterBlaster : ModNPC
    {
        private int frameTimer = 0;
        private int frameNum = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Duke's Trusty Blaster");
            Main.npcFrameCount[npc.type] = 5;
            NPCID.Sets.MustAlwaysDraw[npc.type] = true;
        }

        public override void SetDefaults()
        {
            npc.height = 60;
            npc.width = 50;
            npc.timeLeft = 300;
            npc.lifeMax = 1;
            npc.knockBackResist = 1f;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.noGravity = true;
            npc.spriteDirection = 0;
            npc.rotation = 0;
            npc.dontTakeDamage = true;

        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;

            if (frameTimer == 2)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 5)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
        }

        public override void AI()
        {
            npc.ai[2]++;
            if (npc.ai[2] >= 3)
            {
                npc.ai[2] = 0f;
                npc.netUpdate = true;
                frameTimer++;
            }
            Player player = Main.player[npc.target];
            Vector2 center = npc.Center;
            Vector2 Velocity = npc.velocity;
            if (++npc.frameCounter >= 5)
            {
                npc.frameCounter = 0;
                npc.frameCounter = ++npc.frameCounter % Main.npcFrameCount[npc.type];

            }
            npc.ai[1] += 1f;
            if (npc.ai[1] >= 300f)
            {
                for (int i = 0; i < 20; i++)
                {
                    int KillDust = Dust.NewDust(npc.position, npc.width, npc.height, 212, npc.direction * 2, 0f, 100, default, 1.4f);
                    Dust DustExample = Main.dust[KillDust];
                    DustExample.color = Color.LightPink;
                    DustExample.color = Color.Lerp(DustExample.color, Color.White, 0.3f);
                    DustExample.noGravity = true;
                }
                npc.life = 0;
            }
            Vector2 vectoridk = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float playerX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vectoridk.X;
            float playerY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vectoridk.Y;
            if (playerX > 0f)
            {
                npc.spriteDirection = player.direction;
                npc.rotation = (float)Math.Atan2(playerX, -playerY) + 3.14f;


            }
            if (playerX < 0f)
            {
                npc.spriteDirection = -player.direction;
                npc.rotation = (float)Math.Atan2(playerX, -playerY) + -3.14f;

            }
            npc.ai[0] += 1f;
            if (npc.ai[0] >= 15f)
            {
                // Half a second has passed. Reset timer, etc.
                npc.ai[0] = 0f;
                npc.netUpdate = true;
                // Do something here, maybe change to a new state.
                //NPC.NewNPC((int)center.X, (int)center.Y, NPCType<NPCs.SoapBubble>());


                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float velocityX = npc.rotation;
                    float velocityY = npc.rotation;
                    Vector2 vector3 = Vector2.Normalize(player.Center - center) * (npc.width + 20) / 2f + center;
                    //int bubble = Projectile.NewProjectile(center.X, center.Y, velocityX, -velocityY, ProjectileType<SlightlyLessSoapyBubble>(), 35, 3f, 0, 0f, 0f);
                    int bubble = NPC.NewNPC((int)vector3.X, (int)vector3.Y + 45, NPCType<SoapBubble>());

                }

            }
        }
    }
}
