using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.Projectiles
{
    public class rum : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("rum");
        }

        public override void SetDefaults()
        {
            projectile.damage = 35;
            projectile.hostile = true;
            projectile.knockBack = 2;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.width = projectile.height = 14;
        }

        public override void AI()
        {
            projectile.velocity.Y += 0.4f;
            projectile.rotation = projectile.velocity.ToRotation();
        }

        public override void Kill(int timeLeft)
        {
            Dust.NewDust(projectile.Center, 10, 10, DustID.ToxicBubble, 14, 14);
            Projectile.NewProjectile(projectile.position, -projectile.velocity * 0.1f, ModContent.ProjectileType<Projectiles.RumCloud>(), 40, 3);
        }
    }
}