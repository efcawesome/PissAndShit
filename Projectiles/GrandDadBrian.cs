using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    public class GrandDadBrian : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("GrandDadBrian");

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 92;
            projectile.aiStyle = 107;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
        }

        //public override void AI() => projectile.CloneDefaults(ProjectileID.DesertDjinnCurse);
    }
}