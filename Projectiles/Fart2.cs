using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
	public class Fart2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 18;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 136;
			projectile.alpha = 85;
			projectile.tileCollide = false; 			
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] >= 5f)
			{
			// Half a second has passed. Reset timer, etc.
			projectile.ai[0] = 0f;
			projectile.netUpdate = true;
			projectile.rotation += 0.05f * (float)projectile.direction;		
			projectile.velocity.X /= 1.61f;
			projectile.velocity.Y /= 1.61f;			
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCHit1, projectile.position);
			
			for (int i = 0; i < 6; i++)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-5 , 5), Main.rand.Next(-5 , 5), ModContent.ProjectileType<Fart>(), 30, 5, 0, 18, 1);
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 1.35f;
		}
	}
}
