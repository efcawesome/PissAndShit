using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles { 
	public class YoungSharknadoBolt : ModProjectile
	{




		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("YoungSharknadoBolt");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 65;
			projectile.alpha = 255;
			projectile.timeLeft = 300;
		}

        public override void AI()
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
					int num256 = Projectile.NewProjectile(projectile.Center.X - (float)(projectile.direction * 30), projectile.Center.Y - 4f, (float)(-projectile.direction) * 0.01f, 0f, ProjectileID.Sharknado, num255, 4f, projectile.owner, 16f, 15f);
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
	}
    }

