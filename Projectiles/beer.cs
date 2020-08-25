using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    public class beer : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("beer");

        public override void SetDefaults()
        {
            projectile.damage = 60;
            projectile.hostile = true;
            projectile.knockBack = 2;
            projectile.ranged = true;
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.width = projectile.height = 15;
            projectile.scale *= 1.3f;
        }

        public override void AI()
        {
            projectile.velocity.Y += 0.1f;
            projectile.rotation = projectile.velocity.Y * 0.1f;
        }

        public override void Kill(int timeLeft) => Dust.NewDust(projectile.Center, 15, 15, DustID.Tungsten, Main.rand.Next(-1, 1), -10);
    }
}