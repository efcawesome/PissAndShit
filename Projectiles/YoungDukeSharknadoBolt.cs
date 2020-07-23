
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace PissAndShit.Projectiles
{
	class YoungDukeSharknadoBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Young Sharknado Bolt");
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
			ProjectileID.Sets.MinionShot[projectile.type] = true;
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
			Main.PlaySound(SoundID.NPCKilled, (int)projectile.Center.X, (int)projectile.Center.Y, 19);
			int num252 = 36;
			for (int num253 = 0; num253 < num252; num253++)
			{
				Vector2 spinningpoint2 = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, projectile.height) * 0.75f;
				spinningpoint2 = spinningpoint2.RotatedBy((float)(num253 - (num252 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num252) + projectile.Center;
				Vector2 vector6 = spinningpoint2 - projectile.Center;
				int num254 = Dust.NewDust(spinningpoint2 + vector6, 0, 0, 172, vector6.X * 2f, vector6.Y * 2f, 100, default(Color), 1.4f);
				Main.dust[num254].noGravity = true;
				Main.dust[num254].noLight = true;
				Main.dust[num254].velocity = vector6;
			}
			if (projectile.owner == Main.myPlayer)
			{
				if (projectile.ai[1] < 1f)
				{
					int num255 = Main.expertMode ? 25 : 40;
					int num256 = Projectile.NewProjectile(projectile.Center.X - (float)(projectile.direction * 30), projectile.Center.Y - 4f, (float)(-projectile.direction) * 0.01f, 0f, ProjectileType<Projectiles.YoungDukeSharknado>(), num255, 4f, projectile.owner, 16f, 15f);
					Main.projectile[num256].netUpdate = true;
				}
				else
				{
					int num258 = (int)(projectile.Center.Y / 16f);
					int num259 = (int)(projectile.Center.X / 16f);
					int num260 = 100;
					if (num259 < 10)
					{
						num259 = 10;
					}
					if (num259 > Main.maxTilesX - 10)
					{
						num259 = Main.maxTilesX - 10;
					}
					if (num258 < 10)
					{
						num258 = 10;
					}
					if (num258 > Main.maxTilesY - num260 - 10)
					{
						num258 = Main.maxTilesY - num260 - 10;
					}
					for (int num261 = num258; num261 < num258 + num260; num261++)
					{
						Tile tile = Main.tile[num259, num261];
						if (tile.active() && (Main.tileSolid[tile.type] || tile.liquid != 0))
						{
							num258 = num261;
							break;
						}
					}
					int num262 = Main.expertMode ? 50 : 80;
					int num263 = Projectile.NewProjectile(num259 * 16 + 8, num258 * 16 - 24, 0f, 0f, ProjectileID.Cthulunado, num262, 4f, Main.myPlayer, 16f, 24f);
					Main.projectile[num263].netUpdate = true;
				}
			}
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
			else
			{
				float num790 = (float)Math.PI / 15f;
				float num791 = 4f;
				float num792 = (float)(Math.Cos(num790 * projectile.ai[0]) - 0.5) * num791;
				projectile.velocity.Y -= num792;
				projectile.ai[0]++;
				num792 = (float)(Math.Cos(num790 * projectile.ai[0]) - 0.5) * num791;
				projectile.velocity.Y += num792;
				localAI[0]++;
				if (localAI[0] > 10f)
				{
					projectile.alpha -= 5;
					if (projectile.alpha < 100)
					{
						projectile.alpha = 100;
					}
					projectile.rotation += projectile.velocity.X * 0.1f;
					projectile.frame = (int)(localAI[0] / 3f) % 3;
				}
			}
			if (projectile.wet)
			{
				projectile.position.Y -= 16f;
				projectile.Kill();
			}

			if (Main.rand.Next(2) == 0)
			{
				int num234 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 14);
				Main.dust[num234].velocity.X *= 0.4f;
			}

		}
	}
	}
	


