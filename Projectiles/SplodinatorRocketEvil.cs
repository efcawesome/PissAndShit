// kindly ignore the using abomination
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles
{
	public class SplodinatorRocketEvil : ModProjectile
	{   
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("deaths meme kaboom cylinder");
			Main.projFrames[projectile.type] = 2;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.RocketIII);
			aiType = ProjectileID.RocketIII;
			projectile.width = 26;               //The width of projectile hitbox
			projectile.height = 10;              //The height of projectile hitbox
//			projectile.aiStyle = 16;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = false;         //Can the projectile deal damage to enemies?
			projectile.hostile = true;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.tileCollide = false;          //Can the projectile collide with tiles?
			projectile.penetrate = 1;
			
		}

	        public override bool PreKill(int timeLeft) {
		    projectile.type = ProjectileID.RocketIII;
		    return true;
		}

	        public override void AI()
	        {
		    bool flag = false;
		    int num13 = 6;
		    if (projectile.timeLeft <= 3)
		    {
			projectile.tileCollide = false;
			projectile.ai[1] = 0f;
			projectile.alpha = 255;
		    }
		    else
		    {	
			if (Math.Abs(projectile.velocity.X) >= 8f || Math.Abs(projectile.velocity.Y) >= 8f)
			{
			    for (int n = 0; n < 2; n++)
			    {
				float num28 = 0f;
				float num29 = 0f;
				if (n == 1)
				{
				    num28 = projectile.velocity.X * 0.5f;
				    num29 = projectile.velocity.Y * 0.5f;
				}
				int num30 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num28, projectile.position.Y + 3f + num29) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, num13, 0f, 0f, 100);
				Main.dust[num30].scale *= 2f + (float)Main.rand.Next(10) * 0.1f;
				Main.dust[num30].velocity *= 0.2f;
				Main.dust[num30].noGravity = true;
				if (Main.dust[num30].type == 152)
				{
				    Main.dust[num30].scale *= 0.5f;
				    Main.dust[num30].velocity += projectile.velocity * 0.1f;
				}
				else if (Main.dust[num30].type == 35)
				{
				    Main.dust[num30].scale *= 0.5f;
				    Main.dust[num30].velocity += projectile.velocity * 0.1f;
				}
				else if (Main.dust[num30].type == Dust.dustWater())
				{
				    Main.dust[num30].scale *= 0.65f;
				    Main.dust[num30].velocity += projectile.velocity * 0.1f;
				}
				
				num30 = Dust.NewDust(new Vector2(projectile.position.X + 3f + num28, projectile.position.Y + 3f + num29) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, 31, 0f, 0f, 100, default(Color), 0.5f);
				Main.dust[num30].fadeIn = 1f + (float)Main.rand.Next(5) * 0.1f;
				Main.dust[num30].velocity *= 0.05f;
			    }
			}
			if (Math.Abs(projectile.velocity.X) < 15f && Math.Abs(projectile.velocity.Y) < 15f)
			{
			    projectile.velocity *= 1.1f;
			}
			
			int num33 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100);
			Main.dust[num33].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
			Main.dust[num33].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
			Main.dust[num33].noGravity = true;
			Main.dust[num33].position = projectile.Center + new Vector2(0f, -projectile.height / 2).RotatedBy(projectile.rotation) * 1.1f;
			int num34 = 6;
			
			Dust dust8 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, num34, 0f, 0f, 100);
			dust8.scale = 1f + (float)Main.rand.Next(5) * 0.1f;
			dust8.noGravity = true;
			dust8.position = projectile.Center + new Vector2(0f, -projectile.height / 2 - 6).RotatedBy(projectile.rotation) * 1.1f;
			
		    }
		    projectile.ai[0] += 1f;
	
		    if (projectile.velocity != Vector2.Zero)
		    {
			projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
		    }

		    float num165 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
		    float num166 = projectile.localAI[0];
		    if (num166 == 0f)
		    {
			projectile.localAI[0] = num165;
			num166 = num165;
		    }
		}
	
		    
		   
	

	        public override bool OnTileCollide(Vector2 oldVelocity)
	        {
		    projectile.penetrate--;
		    if (projectile.penetrate <= 0) {
			projectile.Kill();
		    }
		    return false;
		}

	        public override void Kill(int timeLeft)
	        {
		    Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		    Main.PlaySound(SoundID.Item10, projectile.position);
		}

	        private void Resize(int newWidth, int newHeight)
	        {
		    projectile.position = projectile.Center;
		    projectile.width = newWidth;
		    projectile.height = newHeight;
		    projectile.Center = projectile.position;
		}

	        
	}
}


