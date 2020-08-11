using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.NPCLoader;
using static Terraria.Projectile;
using System;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;

namespace PissAndShit.Projectiles
{	
	public class MagmaShardBall : ModProjectile
	{
		
	
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 5;
		}
		public override void SetDefaults()
		{
		
			projectile.width = 12;
			projectile.height = 12;
			
			projectile.friendly = true;
			projectile.melee = true;
			projectile.timeLeft = 300;
			projectile.penetrate = 2;
			drawOffsetX = -19;
			drawOriginOffsetY = -19;
			drawOriginOffsetX = -19;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
			
		}
		//bool to ensure explosion projectile only shoots one shard
		bool hasShot = false;
		
		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			//adds On Fire! debuff to hit enemies, original enemy hit with sword is inflicted with oiled
			target.AddBuff(24, 600);
		}
		
		public override void AI()
		{
			//uses same animation as solar eruption's explosion
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
			}
				
			if (projectile.frame == 5)
			{
				projectile.Kill();
			}
			
			projectile.ai[0] += 1f;
			//adding dusts and light
			if (Main.rand.NextFloat() < 0.5526316f)
			{
				Dust dust;
				
				Vector2 position190 = new Vector2(projectile.position.X - 19f, projectile.position.Y - 19f);
				dust = Terraria.Dust.NewDustDirect(position190, 73, 68, 31, 0f, 0.5263162f, 0, new Color(255,176,0), 1.184211f);
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(23, Main.LocalPlayer);
				dust.fadeIn = 0.9473684f;
				Vector2 position191 = new Vector2(projectile.Center.X - 19f, projectile.Center.Y - 19f);
				Lighting.AddLight(position191, 0.9f, 0.8f, 0.6f);
				if (Main.rand.NextFloat() < 0.2105263f)
				{
					Dust dust1;
	// 
					
					dust = Main.dust[Terraria.Dust.NewDust(position190, 50, 50, 35, 0f, 0f, 0, new Color(255,255,255), 1.513158f)];
					dust.noGravity = true;
					dust.fadeIn = 1.263158f;
				}

			}

			
			if (projectile.owner == Main.myPlayer) 
			{
				for(int i = 0; i < Main.npc.Length; i++)
				{
       //Enemy NPC variable being set
					NPC target = Main.npc[i];

       //Getting the shooting trajectory
					float shootToX = target.Center.X + (float)target.width * 0.5f - projectile.Center.X;
					float shootToY = target.Center.Y - projectile.Center.Y;
					float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

       //If the distance between the projectile and the live target is active
					if(distance < 480f && target.lifeMax > 5 && (target.active || target.type == 488) && !hasShot)
					{
					
						{
               //Dividing the factor of the desired velocity by distance
							distance = 4f / distance;
   
               //Multiplying the shoot trajectory with distance times a multiplier if you so choose to
							shootToX *= distance * 5;
							shootToY *= distance * 5;
   
               //Shoot projectile and set ai back to 0
							Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ModContent.ProjectileType<MagmaShard>(), 1, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile
						
							projectile.ai[0] = 0f;
							//ensures explosion only shoots once
							hasShot = true;
						
						}
					
					
					}
					projectile.ai[0] += 1f;

				}
			}

			
            
		}
		
	}
	public class MagmaShard :ModProjectile
	
	{
		int targetsHit = 0;
		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 7;
			
			projectile.friendly = true;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 300;
			projectile.damage = 1;
			projectile.penetrate = 2;
		
		}
		public override void AI()
		{
			//pierces enemies during the first frames in order to avoid hitting the same enemy
			if (projectile.timeLeft < 299)
			{
				projectile.penetrate =1;
			}
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(112.5f);
			projectile.spriteDirection = projectile.direction + (int)MathHelper.ToRadians(112.5f);
			
			Vector2 move = Vector2.Zero;
			
			
		}
		public override void OnHitNPC (NPC target, int damage, float knockback, bool crit)
		{
			
			damage = 1;
			
			if (target.life > 0)
				
			{
				//only creates an explosion if less than 4 explosions are active to avoid an infinite chain reaction
				if (Main.player[Main.myPlayer].ownedProjectileCounts[ModContent.ProjectileType<MagmaShardBall>()] < 4)
				{
					Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<MagmaShardBall>(), 64, 0f, Main.myPlayer, 0f, 0f);
				}
			}
			
			
			
			projectile.Kill();
			
		}
		private void AdjustMagnitude(ref Vector2 vector) 
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f) 
			{
				vector *= 6f / magnitude;
			}
		}
		
	
			
	
				
	}
}
	