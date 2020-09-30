using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using System;

namespace PissAndShit.NPCs.Bosses.OddityBoss
{
    class SuperGasterBlaster : ModNPC
    {
        private int frameTimer = 0;
        private int frameNum = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Oddity Blaster");
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
        private Vector2 LaserBoxPosition;
        private Vector2 LaserBoxValueFixer;
        private Vector2 playerCenter;
        public override void AI()
        {

            npc.ai[2]++;
            if (npc.ai[2] >= 3)
            {
                npc.ai[2] = 0f;
                npc.netUpdate = true;
                
            }
            Player player = Main.player[npc.target];
            Vector2 center = npc.Center;
            Vector2 Velocity = npc.velocity;
            
            npc.ai[1] += 1f;
            if (npc.ai[1] <= 150f)
            {
                
                Vector2 vectoridk = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float playerX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vectoridk.X;
                float playerY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vectoridk.Y;
                npc.spriteDirection = playerX > 0f ? player.direction : -player.direction;
                npc.rotation = playerX > 0f ? (float)Math.Atan2(playerX, -playerY) + 3.14f : (float)Math.Atan2(playerX, -playerY) + -3.14f;
                
            } else
            {
                
                if (npc.ai[0] == 0f)
                {
                   playerCenter  = Main.player[npc.target].Center;
                }
                npc.ai[0]++;
                
                if (npc.ai[0] == 20f)
                {
                    
                    LaserBoxPosition = npc.Center;
                    LaserBoxValueFixer = new Vector2(LaserBoxPosition.X + 1, LaserBoxPosition.Y + 1);
                    LaserBoxPosition = new Vector2(LaserBoxValueFixer.X - 1, LaserBoxValueFixer.Y - 1);
                    npc.TargetClosest(faceTarget: false);
                    Vector2 targerplayer = playerCenter - npc.Center;
                    targerplayer.Normalize();
                    //float yOffset = LaserBoxPosition.X < 0f ? 25f : -25f;
                    Projectile.NewProjectile(LaserBoxPosition + new Vector2(0,0), new Vector2(targerplayer.X, targerplayer.Y), ModContent.ProjectileType<Projectiles.Deathrays.GasterDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                }
                if (npc.ai[0] >= 20f)
                {
                    frameTimer++;
                    if (++npc.frameCounter >= 5)
                    {
                        npc.frameCounter = 0;
                        npc.frameCounter = ++npc.frameCounter % Main.npcFrameCount[npc.type];

                    }
                }
                
            }
            if (npc.ai[1] >= 300f)
            {

                for (int i = 0; i < 20; i++)
                {
                    int KillDust = Dust.NewDust(npc.position, npc.width, npc.height, 212, npc.direction * 2, 0f, 100, default(Color), 1.4f);
                    Dust DustExample = Main.dust[KillDust];
                    DustExample.color = Color.LightPink;
                    DustExample.color = Color.Lerp(DustExample.color, Color.White, 0.3f);
                    DustExample.noGravity = true;
                }
                npc.life = 0;
            }
            
            
        }
    }
}
