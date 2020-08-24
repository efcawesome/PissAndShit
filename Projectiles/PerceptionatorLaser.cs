using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    class PerceptionatorLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Laser");
        }

        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 42;
            aiType = ProjectileID.Bullet;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.hostile = true;
            projectile.scale = 1;
            projectile.light = 3;
            projectile.alpha = 150;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
    }
}
