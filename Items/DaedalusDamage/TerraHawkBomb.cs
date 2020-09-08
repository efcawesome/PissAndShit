using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
    public class TerraHawkBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Nuke");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.tileCollide = true;
            projectile.hostile = false;
            projectile.scale = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void AI() 
        {
            projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            Dust dust;
            Vector2 position = projectile.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 15, 0f, 0f, 0, new Color(58, 255, 28), 1f)];
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            for (int i = 0; i < 50; i++)
            {
                Vector2 position = projectile.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 50 * i)) * 30;
                Dust dust = Dust.NewDustPerfect(position, 15, new Vector2(0, 0), 0, new Color(58, 255, 28));
                dust.noGravity = true;
                dust.velocity = Vector2.Normalize(dust.position - projectile.Center) * 4;
                dust.noLight = false;
                dust.fadeIn = 1f;
            }
        }
    }
}