using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    public class DaedalusStormbowStormbowDaedalusStormbow : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Daedalus Stormbow Stormbow Daedalus Stormbow");
        private int daedalusStormbowStormbowDaedalusStormbowUT = 30;
        public override void SetDefaults()
        {
            projectile.damage = 400;
            projectile.hostile = false;
            projectile.friendly = true;
            projectile.knockBack = 2;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.width = 22;
            projectile.height = 52;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            daedalusStormbowStormbowDaedalusStormbowUT--;
            if (daedalusStormbowStormbowDaedalusStormbowUT <= 0)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                if (projectile.velocity.Y > 16f)
	                projectile.velocity.Y = 16f;   

                int numberProjectiles = 4 + Main.rand.Next(4);
                for (int index = 0; index < numberProjectiles; ++index)
                {
                    Vector2 vector2_1 = new Vector2((float)(player.position.X + player.width * 0.5 + Main.rand.Next(201) * -player.direction + (Main.mouseX + (double)Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));
                    vector2_1.X = (float)((vector2_1.X + (double)player.Center.X) / 2.0) + Main.rand.Next(-200, 201);
                    vector2_1.Y -= 100 * index;
                    float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
                    float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                    if (num13 < 0.0)
                    {
                        num13 *= -1f;
                    }

                    if (num13 < 20.0)
                    {
                        num13 = 20f;
                    }   

                    float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
                    float num15 = 9f / num14;
                    float num16 = num12 * num15;
                    float num17 = num13 * num15;
                    float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.02f;
                    float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
                    Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, 91, player.GetModPlayer<PaSPlayer>().stormbowStormbowDamage, player.GetModPlayer<PaSPlayer>().stormbowStormbowKnockback, Main.myPlayer, 0.0f, Main.rand.Next(5));
                    daedalusStormbowStormbowDaedalusStormbowUT = 30;
                }
            }
        }
    }
}