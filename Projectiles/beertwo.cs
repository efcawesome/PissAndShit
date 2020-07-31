using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace PissAndShit.Projectiles
{
	class beertwo : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beer or Grog");
		}

		public override void SetDefaults()
		{
			projectile.arrow = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.magic = true;
			aiType = ProjectileID.WoodenArrowFriendly;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(new LegacySoundStyle(13, 1, Terraria.Audio.SoundType.Sound));
			Gore.NewGore(projectile.Center, projectile.velocity * 0.8f, mod.GetGoreSlot("Gores/beertwo_gore"), 1f);
			Gore.NewGore(projectile.Center, projectile.velocity * 0.9f, mod.GetGoreSlot("Gores/beertwo_gore2"), 1f);
		}


		public override void AI()
		{
			projectile.rotation += 0.2f * (float)projectile.direction;
			projectile.velocity.X = projectile.velocity.X * 0.95f;

			projectile.velocity.X = projectile.velocity.X + 0.5f;
		}
	}
}
