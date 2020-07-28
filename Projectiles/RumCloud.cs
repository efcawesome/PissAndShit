using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace PissAndShit.Projectiles
{
    public class RumCloud : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.ToxicCloud;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rum Cloud");
        }

        public override void SetDefaults()
        {
            projectile.damage = 50;
            projectile.knockBack = 2;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.ranged = true;
            projectile.scale *= 1.2f;
            projectile.tileCollide = false;
            projectile.alpha = 2;
            projectile.hostile = true;
            projectile.width = projectile.height = 18;
        }

        public override void AI()
        {
            projectile.velocity.Y = -0.8f;
            projectile.alpha += 8;
            if (projectile.alpha >= 246)
            {
                projectile.Kill();
            }
        }
    }
}