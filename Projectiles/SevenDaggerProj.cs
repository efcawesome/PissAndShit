using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    public class SevenDaggerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shooting Seven");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 250;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.scale = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void AI() => projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
    }
}