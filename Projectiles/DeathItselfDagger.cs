using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace PissAndShit.Projectiles
{
    public class DeathItselfDagger : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("deaths meme stabber");
        }

        public override void SetDefaults()
        {
            projectile.damage = 400;
            projectile.hostile = true;
            projectile.knockBack = 2;
            projectile.ranged = true;
            projectile.aiStyle = 2;
            projectile.penetrate = 1;
            projectile.width = 11;
	    projectile.height = 26;
            projectile.scale *= 1.3f;
        }

	public override void AI()
	{
	    projectile.velocity = projectile.velocity / 2;
	}
    }
}
