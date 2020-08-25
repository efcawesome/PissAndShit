using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles
{
    public class YoungDukeSharknado : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Duke's Sharknado");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            projectile.width = 150;
            projectile.height = 42;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.alpha = 255;
            projectile.timeLeft = 540;
        }

        public override void Kill(int timeLeft)
        {
            for (int num282 = 0; num282 < 20; num282++)
            {
                int num283 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 212, projectile.direction * 2, 0f, 100, default, 1.4f);

                Dust dust218 = Main.dust[num283];

                dust218.color = Color.LightPink;
                dust218.color = Color.Lerp(dust218.color, Color.White, 0.3f);
                dust218.noGravity = true;
            }
        }

        public override void AI()
        {
            int num771 = 8;
            int num772 = 8;
            float num773 = 1.5f;
            int num775 = 150;
            int num776 = 42;

            if (projectile.velocity.X != 0f)
            {
                projectile.direction = (projectile.spriteDirection = -Math.Sign(projectile.velocity.X));
            }

            projectile.frameCounter++;

            if (projectile.frameCounter > 2)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
            }

            if (projectile.frame >= 6)
            {
                projectile.frame = 0;
            }

            if (projectile.localAI[0] == 0f && Main.myPlayer == projectile.owner)
            {
                projectile.localAI[0] = 1f;
                projectile.position.X += projectile.width / 2;
                projectile.position.Y += projectile.height / 2;
                projectile.scale = (num771 + num772 - projectile.ai[1]) * num773 / (num772 + num771);
                projectile.width = (int)(num775 * projectile.scale);
                projectile.height = (int)(num776 * projectile.scale);
                projectile.position.X -= projectile.width / 2;
                projectile.position.Y -= projectile.height / 2;
                projectile.netUpdate = true;
            }

            if (projectile.ai[1] != -1f)
            {
                projectile.scale = (num771 + num772 - projectile.ai[1]) * num773 / (num772 + num771);
                projectile.width = (int)(num775 * projectile.scale);
                projectile.height = (int)(num776 * projectile.scale);
            }

            if (!Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
            {
                projectile.alpha -= 30;

                if (projectile.alpha < 60)
                {
                    projectile.alpha = 60;
                }
                if (projectile.type == 386 && projectile.alpha < 100)
                {
                    projectile.alpha = 100;
                }
            }
            else
            {
                projectile.alpha += 30;
                if (projectile.alpha > 150)
                {
                    projectile.alpha = 150;
                }
            }

            if (projectile.ai[0] > 0f)
            {
                projectile.ai[0]--;
            }

            if (projectile.ai[0] == 1f && projectile.ai[1] > 0f && projectile.owner == Main.myPlayer)
            {
                projectile.netUpdate = true;

                Vector2 center = projectile.Center;

                center.Y -= num776 * projectile.scale / 2f;

                float num777 = (num771 + num772 - projectile.ai[1] + 1f) * num773 / (num772 + num771);

                center.Y -= num776 * num777 / 2f;
                center.Y += 2f;

                Projectile.NewProjectile(center.X, center.Y, projectile.velocity.X, projectile.velocity.Y, projectile.type, projectile.damage, projectile.knockBack, projectile.owner, 10f, projectile.ai[1] - 1f);
                int num778 = 4;

                if (projectile.type == 386)
                {
                    num778 = 2;
                }

                if ((int)projectile.ai[1] % num778 == 0 && projectile.ai[1] != 0f)
                {
                    int num780 = NPC.NewNPC((int)center.X, (int)center.Y, NPCType<NPCs.BabyShark>());

                    Main.npc[num780].velocity = projectile.velocity;
                    Main.npc[num780].netUpdate = true;

                    if (projectile.type == 386)
                    {
                        Main.npc[num780].ai[2] = projectile.width;
                        Main.npc[num780].ai[3] = -1.5f;
                    }
                }
            }
            if (projectile.ai[0] <= 0f)
            {
                float num781 = (float)Math.PI / 30f;
                float num782 = projectile.width / 5f;

                if (projectile.type == 386)
                {
                    num782 *= 2f;
                }

                float num783 = (float)(Math.Cos(num781 * (0f - projectile.ai[0])) - 0.5) * num782;

                projectile.position.X -= num783 * -projectile.direction;
                projectile.ai[0]--;
                num783 = (float)(Math.Cos(num781 * (0f - projectile.ai[0])) - 0.5) * num782;
                projectile.position.X += num783 * -projectile.direction;
            }
        }
    }
}