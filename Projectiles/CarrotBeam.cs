using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
	public class CarrotBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Carrot Beam");
		}

		public override void SetDefaults()
		{
			projectile.arrow = false;
			projectile.width = 60;
			projectile.height = 30;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.melee = true;
			aiType = ProjectileID.Bullet;
		}
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.localAI[0] += 1f;
			projectile.alpha = (int)projectile.localAI[0] * 2;


		}

		// Additional hooks/methods here.
	}
}
