using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    class YoungTyphoon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whirlpool");
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            projectile.aiStyle = 71;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 360;
            projectile.tileCollide = true;
            projectile.extraUpdates = 2;
            projectile.magic = true;
            projectile.hostile = false;
            projectile.scale = 1;
        }

        public override void AI()
        {
        }
    }
    //yes I like to put comments on every code I do
}
