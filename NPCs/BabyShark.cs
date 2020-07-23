using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    class BabyShark : ModNPC
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Young Sharkron");
			Main.npcFrameCount[npc.type] = 4;
		}
        public override void SetDefaults()
        {
			npc.noGravity = true;
			npc.width = 120;
			npc.height = 24;
			npc.aiStyle = 71;
			npc.damage = 100;
			npc.defense = 100;
			npc.lifeMax = 100;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0f;
			npc.alpha = 255;
		}

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
			npc.lifeMax = (int)((double)npc.lifeMax * 0.75);
			npc.damage = (int)((double)npc.damage * 0.75);
		}

        public override void HitEffect(int hitDirection, double damage)
        {
			/*
			 This will be uncommented when gores added
			Gore.NewGore(base.position, base.velocity, 372);
			*/

			if (npc.life > 0)
			{
				for (int num117 = 0; (double)num117 < npc.damage / (double)npc.lifeMax * 100.0; num117++)
				{
					Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f);
				}
			}
			else
			{
				for (int num118 = 0; num118 < 75; num118++)
				{
					int num119 = Dust.NewDust(npc.Center - Vector2.One * 25f, 50, 50, 5, 2 * hitDirection, -2f);
					Dust dust2 = Main.dust[num119];
					Dust dust160 = dust2;
					dust160.velocity /= 2f;
				}
				/*
				 This will be uncommented when gores are added
				 
				
				Gore.NewGore(base.Center, base.velocity * 0.8f, 583);
				Gore.NewGore(base.Center, base.velocity * 0.8f, 577);
				Gore.NewGore(base.Center, base.velocity * 0.9f, 578);
				Gore.NewGore(base.Center, base.velocity, 579);
				*/
			}

			
		}

        public override void AI()
        {
			npc.noTileCollide = true;
			int num39 = 90;
			if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead)
			{
				npc.TargetClosest(faceTarget: false);
				npc.direction = 1;
				npc.netUpdate = true;
			}
			if (npc.ai[0] == 0f)
			{
				npc.ai[1]++;
				_ = npc.type;
				npc.noGravity = true;
				npc.dontTakeDamage = true;
				npc.velocity.Y = npc.ai[3];
				if (npc.type == NPCID.Sharkron2)
				{
					float num40 = (float)Math.PI / 30f;
					float num41 = npc.ai[2];
					float num42 = (float)(Math.Cos(num40 * npc.localAI[1]) - 0.5) * num41;
					npc.position.X -= num42 * (float)(-npc.direction);
					npc.localAI[1]++;
					num42 = (float)(Math.Cos(num40 * npc.localAI[1]) - 0.5) * num41;
					npc.position.X += num42 * (float)(-npc.direction);
					if (Math.Abs(Math.Cos(num40 * npc.localAI[1]) - 0.5) > 0.25)
					{
						npc.spriteDirection = ((!(Math.Cos(num40 * npc.localAI[1]) - 0.5 >= 0.0)) ? 1 : (-1));
					}
					npc.rotation = npc.velocity.Y * (float)npc.spriteDirection * 0.1f;
					if ((double)npc.rotation < -0.2)
					{
						npc.rotation = -0.2f;
					}
					if ((double)npc.rotation > 0.2)
					{
						npc.rotation = 0.2f;
					}
					npc.alpha -= 6;
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
				}
				if (npc.ai[1] >= (float)num39)
				{
					npc.ai[0] = 1f;
					npc.ai[1] = 0f;
					if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						npc.ai[1] = 1f;
					}
					Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
					npc.TargetClosest();
					npc.spriteDirection = npc.direction;
					Vector2 vector28 = Main.player[npc.target].Center - npc.Center;
					vector28.Normalize();
					npc.velocity = vector28 * 16f;
					npc.rotation = npc.velocity.ToRotation();
					if (npc.direction == -1)
					{
						npc.rotation += (float)Math.PI;
					}
					npc.netUpdate = true;
				}
			}
			else
			{
				if (npc.ai[0] != 1f)
				{
					return;
				}
				npc.noGravity = true;
				if (!Collision.SolidCollision(npc.position, npc.width, npc.height))
				{
					if (npc.ai[1] < 1f)
					{
						npc.ai[1] = 1f;
					}
				}
				else
				{
					npc.alpha -= 15;
					if (npc.alpha < 150)
					{
						npc.alpha = 150;
					}
				}
				if (npc.ai[1] >= 1f)
				{
					npc.alpha -= 60;
					if (npc.alpha < 0)
					{
						npc.alpha = 0;
					}
					npc.dontTakeDamage = false;
					npc.ai[1]++;
					if (Collision.SolidCollision(npc.position, npc.width, npc.height))
					{
						if (npc.DeathSound != null)
						{
							Main.PlaySound(npc.DeathSound, npc.position);
						}
						npc.life = 0;
						npc.HitEffect();
						npc.active = false;
						return;
					}
				}
				if (npc.ai[1] >= 60f)
				{
					npc.noGravity = false;
				}
				npc.rotation = npc.velocity.ToRotation();
				if (npc.direction == -1)
				{
					npc.rotation += (float)Math.PI;
				}
			}
		}
	}

    }

