using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace testmod.Projectiles
{
	public class Fart : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 165;
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
			projectile.velocity.X /= 1.43f;
			projectile.velocity.Y /= 1.43f;			
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCHit1, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 1.25f;
		}
	}
}