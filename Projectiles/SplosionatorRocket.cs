// kindly ignore the using abomination
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace PissAndShit.Projectiles
{
    public class SplosionatorRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exoultimagigahypersplosionator Rocket");
            Main.projFrames[projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.RocketIII);
            aiType = ProjectileID.RocketIII;
            projectile.width = 26;               //The width of projectile hitbox
            projectile.height = 10;              //The height of projectile hitbox
                                                 //			projectile.aiStyle = 16;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.penetrate = 1;

        }

        public override bool PreKill(int timeLeft)
        {
            projectile.type = ProjectileID.RocketIII;
            return true;
        }

        public override void AI()
        {
            bool flag = false;
            int num13 = 6;
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.ai[1] = 0f;
                projectile.alpha = 255;
            }
            else
            {
                if (Math.Abs(projectile.velocity.X) >= 8f || Math.Abs(projectile.velocity.Y) >= 8f)
                {
                    for (int n = 0; n < 2; n++)
                    {
                        float num28 = 0f;
                        float num29 = 0f;
                        if (n == 1)
                        {
                            num28 = projectile.velocity.X * 0.5f;
                            num29 = projectile.velocity.Y * 0.5f;
                        }
                        int num30 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num28, projectile.position.Y + 3f + num29) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, num13, 0f, 0f, 100);
                        Main.dust[num30].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
                        Main.dust[num30].velocity *= 0.2f;
                        Main.dust[num30].noGravity = true;
                        if (Main.dust[num30].type == 152)
                        {
                            Main.dust[num30].scale *= 0.5f;
                            Main.dust[num30].velocity += projectile.velocity * 0.1f;
                        }
                        else if (Main.dust[num30].type == 35)
                        {
                            Main.dust[num30].scale *= 0.5f;
                            Main.dust[num30].velocity += projectile.velocity * 0.1f;
                        }
                        else if (Main.dust[num30].type == Dust.dustWater())
                        {
                            Main.dust[num30].scale *= 0.65f;
                            Main.dust[num30].velocity += projectile.velocity * 0.1f;
                        }

                        num30 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num28, projectile.position.Y + 3f + num29) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 31, 0f, 0f, 100, default, 0.5f);
                        Main.dust[num30].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
                        Main.dust[num30].velocity *= 0.05f;
                    }
                }
                if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
                {
                    projectile.velocity *= 1.1f;
                }

                int num33 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100);
                Main.dust[num33].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[num33].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
                Main.dust[num33].noGravity = true;
                Main.dust[num33].position = projectile.Center + new Vector2(0f, -projectile.height / 2).RotatedBy(projectile.rotation) * 1.1f;
                int num34 = 6;

                Dust dust8 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, num34, 0f, 0f, 100);
                dust8.scale = 1f + (float)Main.rand.Next(5) * 0.1f;
                dust8.noGravity = true;
                dust8.position = projectile.Center + new Vector2(0f, -projectile.height / 2 - 6).RotatedBy(projectile.rotation) * 1.1f;

            }
            projectile.ai[0] += 1f;

            if (projectile.velocity != Vector2.Zero)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }

            float num165 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            float num166 = projectile.localAI[0];
            if (num166 == 0f)
            {
                projectile.localAI[0] = num165;
                num166 = num165;
            }

            // end rocket code

            float num1652 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
            float num1662 = projectile.localAI[0];
            if (num1662 == 0f)
            {
                projectile.localAI[0] = num1652;
                num1662 = num1652;
            }

            /*if (projectile.alpha > 0) projectile.alpha -= 25;
		    if (projectile.alpha < 0) projectile.alpha = 0;*/
            float num167 = projectile.position.X;
            float num168 = projectile.position.Y;
            float num169 = 300f;
            bool flag4 = false;
            int num170 = 0;
            if (projectile.ai[1] == 0f)
            {
                for (int num171 = 0; num171 < 200; num171++)
                {
                    if (!Main.npc[num171].CanBeChasedBy(projectile) || projectile.ai[1] != 0f && projectile.ai[1] != num171 + 1) continue;
                    float num172 = Main.npc[num171].position.X + Main.npc[num171].width / 2f;
                    float num173 = Main.npc[num171].position.Y + Main.npc[num171].height / 2f;
                    float num174 = Math.Abs(projectile.position.X + projectile.width / 2f - num172) + Math.Abs(projectile.position.Y + projectile.height / 2f - num173);
                    if (!(num174 < num169) || !Collision.CanHit(new Vector2(projectile.position.X + projectile.width / 2f, projectile.position.Y + projectile.height / 2f), 1, 1,
                                        Main.npc[num171].position, Main.npc[num171].width, Main.npc[num171].height)) continue;
                    num169 = num174;
                    num167 = num172;
                    num168 = num173;
                    flag4 = true;
                    num170 = num171;
                }

                if (flag4) projectile.ai[1] = num170 + 1;
                flag4 = false;
            }

            if (projectile.ai[1] > 0f)
            {
                int num175 = (int)(projectile.ai[1] - 1f);
                if (Main.npc[num175].active && Main.npc[num175].CanBeChasedBy(projectile, true) && !Main.npc[num175].dontTakeDamage)
                {
                    float num176 = Main.npc[num175].position.X + Main.npc[num175].width / 2;
                    float num177 = Main.npc[num175].position.Y + Main.npc[num175].height / 2;
                    float num178 = Math.Abs(projectile.position.X + projectile.width / 2 - num176) + Math.Abs(projectile.position.Y + projectile.height / 2 - num177);
                    if (num178 < 1000f)
                    {
                        flag4 = true;
                        num167 = Main.npc[num175].position.X + Main.npc[num175].width / 2;
                        num168 = Main.npc[num175].position.Y + Main.npc[num175].height / 2;
                    }
                }
                else
                {
                    projectile.ai[1] = 0f;
                }
            }

            if (!projectile.friendly) flag4 = false;
            if (flag4)
            {
                float num179 = num1662;
                Vector2 vector19 = new Vector2(projectile.position.X + projectile.width * 0.5f, projectile.position.Y + projectile.height * 0.5f);
                float num180 = num167 - vector19.X;
                float num181 = num168 - vector19.Y;
                float num182 = (float)Math.Sqrt(num180 * num180 + num181 * num181);
                num182 = num179 / num182;
                num180 *= num182;
                num181 *= num182;
                int num183 = 8;
                projectile.velocity.X = (projectile.velocity.X * (num183 - 1) + num180) / num183;
                projectile.velocity.Y = (projectile.velocity.Y * (num183 - 1) + num181) / num183;
            }
        }





        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

        private void Resize(int newWidth, int newHeight)
        {
            projectile.position = projectile.Center;
            projectile.width = newWidth;
            projectile.height = newHeight;
            projectile.Center = projectile.position;
        }


    }
}


