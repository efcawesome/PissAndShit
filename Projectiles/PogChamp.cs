using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PissAndShit.Projectiles
{
    public class PogChamp : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Pog Champer");

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 92;
            projectile.aiStyle = ProjectileID.Fireball;
            aiType = ProjectileID.Fireball;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 240;
            projectile.tileCollide = true;
            projectile.penetrate = 3;
            projectile.scale = .4f;
            drawOriginOffsetY -= 30;
        }
        public override void AI()
        {
            projectile.velocity.Y = projectile.velocity.Y + 0.15f;
            Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Marble, projectile.velocity.X, projectile.velocity.Y, 0, Colors.CoinCopper, 5f);
            Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.BlueCrystalShard, projectile.velocity.X, projectile.velocity.Y, 0, Colors.CoinGold, 5f);
            Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.SolarFlare, projectile.velocity.X, projectile.velocity.Y, 0, Colors.CoinPlatinum, 5f);
        }
    }
}