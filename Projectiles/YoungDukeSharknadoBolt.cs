
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
	class YoungDukeSharknadoBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Young Duke's Sharknado Bolt");
			Main.projFrames[projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			projectile.width = 54;
			projectile.height = 54;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 65;
			projectile.alpha = 255;
			projectile.timeLeft = 300;
			aiType = ProjectileID.SharknadoBolt;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;

			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = ++projectile.frame % Main.projFrames[projectile.type];
			}
		}
		public static int maxAI = 2;

		public float[] localAI = new float[maxAI];
		public override void Kill(int timeLeft)
		{

		}
		public override void AI()
		{
			if (projectile.ai[1] > 0f)
			{
				int num784 = (int)projectile.ai[1] - 1;
				if (num784 < 255)
				{
					localAI[0]++;
					if (localAI[0] > 10f)
					{
						int num786 = 6;
						for (int num787 = 0; num787 < num786; num787++)
						{
							Vector2 spinningpoint = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, projectile.height) * 0.75f;
							spinningpoint = spinningpoint.RotatedBy((double)(num787 - (num786 / 2 - 1)) * Math.PI / (double)(float)num786) + projectile.Center;
							Vector2 value6 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
							int num788 = Dust.NewDust(spinningpoint + value6, 0, 0, 172, value6.X * 2f, value6.Y * 2f, 100, default(Color), 1.4f);
							Main.dust[num788].noGravity = true;
							Main.dust[num788].noLight = true;
							Dust dust119 = Main.dust[num788];
							Dust dust189 = dust119;
							dust189.velocity /= 4f;
							dust119 = Main.dust[num788];
							dust189 = dust119;
							dust189.velocity -= projectile.velocity;
						}
						projectile.alpha -= 5;
						if (projectile.alpha < 100)
						{
							projectile.alpha = 100;
						}
						projectile.rotation += projectile.velocity.X * 0.1f;
						projectile.frame = (int)(localAI[0] / 3f) % 3;
					}
					Vector2 value7 = Main.player[num784].Center - projectile.Center;
					float num789 = 4f;
					num789 += localAI[0] / 20f;
					projectile.velocity = Vector2.Normalize(value7) * num789;
					if (value7.Length() < 50f)
					{
						projectile.Kill();
					}
				}
			}
		}
	}
}

