using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    public class DeathItself : ModNPC
    {
        private int DeathAttkCounter1 = 0;
        private int DeathAttkCounter2 = 0;
        private int DeathAttkCounter3 = 0;
        private int DeathAttkCounter4 = 0;
        private int DeathAttkChangeTimer = 0;
        private int DeathRocketShootOffset = 0;
        private int DeathRocketShootOffset2 = 0;
        private int DeathRocketsShot = 0;
        private Vector2 DeathLaserBoxPosition;
        private Vector2 DeathLaserBoxValueFixer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish");
            Main.npcFrameCount[npc.type] = 3;
        }

        public override void SetDefaults()
        {
            npc.width = 48;
            npc.height = 48;
            npc.damage = 400;
            npc.defense = 70;
            npc.lifeMax = 220000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 6000000f;
            npc.knockBackResist = 0f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/LastDance");
            musicPriority = MusicPriority.BossHigh;
            npc.dontTakeDamage = true;
            npc.scale = 1f;
	        bossBag = ModContent.ItemType<Items.BossBags.DeathBossBag>();
            for (int i = 1; i < 1000; i++)
            {
                npc.ai[0] = 0;
            }
        }

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            npc.direction = npc.spriteDirection = npc.Center.X < player.Center.X ? 1 : -1;
            Vector2 targetPos;
            float speedModifier;

            switch ((int)npc.ai[0])
            {
                case 0: // initial charge for when summoned by item
		    if (!AliveCheck(player))
			break;
                    targetPos = player.Center;
                    targetPos.X += 500 * (npc.Center.X < targetPos.X ? -1 : 1);
                    npc.ai[1]++;
                    DeathAttkCounter3++;
                    if (DeathAttkCounter3 > 120)
                    {
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                    }
                    else
                    {
                        if (npc.Distance(targetPos) > 50)
                        {
                            speedModifier = npc.localAI[3] > 0 ? 0.5f : 2f;
                            if (npc.Center.X < targetPos.X)
                            {
                                npc.velocity.X += speedModifier;
                                if (npc.velocity.X < 0)
                                {
                                    npc.velocity.X += speedModifier * 2;
                                }
                            }
                            else
                            {
                                npc.velocity.X -= speedModifier;
                                if (npc.velocity.X > 0)
                                {
                                    npc.velocity.X -= speedModifier * 2;
                                }
                            }
                            if (npc.Center.Y < targetPos.Y)
                            {
                                npc.velocity.Y += speedModifier;
                                if (npc.velocity.Y < 0)
                                {
                                    npc.velocity.Y += speedModifier * 2;
                                }
                            }
                            else
                            {
                                npc.velocity.Y -= speedModifier;
                                if (npc.velocity.Y > 0)
                                {
                                    npc.velocity.Y -= speedModifier * 2;
                                }
                            }
                            if (npc.localAI[3] > 0)
                            {
                                if (Math.Abs(npc.velocity.X) > 24)
                                {
                                    npc.velocity.X = 24 * Math.Sign(npc.velocity.X);
                                }

                                if (Math.Abs(npc.velocity.Y) > 24)
                                {
                                    npc.velocity.Y = 24 * Math.Sign(npc.velocity.Y);
                                }
                            }
                        }
                        npc.ai[1] = 0;
                    }

                    if (npc.ai[1] == 30)
                    {
                        DeathRocketShootOffset = -10;
                        for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
                        {
                            Projectile.NewProjectile(npc.position, new Vector2(14, -DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        }
                        DeathAttkCounter1 = DeathAttkCounter1 + 1;
                    }
                    if (npc.ai[1] == 60)
                    {
                        DeathRocketShootOffset = -10;
                        for (DeathRocketShootOffset = -10; DeathRocketShootOffset < 10; DeathRocketShootOffset++)
                        {
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y + 12), new Vector2(-14, DeathRocketShootOffset), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        }
                        DeathAttkCounter1 = DeathAttkCounter1 + 1;

                        npc.ai[1] = 0;
                    }
                    if (DeathAttkCounter1 == 4)
                    {
                        DeathRocketsShot = 0;
                        DeathRocketShootOffset = 0;
                        DeathAttkCounter3 = 0;
                        npc.ai[1] = 0;
                        npc.ai[0] = 1;
                    }
                    break;

                case 1: // shoot loads of rockets above player
		    if (!AliveCheck(player))
			break;
                    for (DeathRocketShootOffset2 = 0; DeathRocketShootOffset2 < 800; DeathRocketShootOffset2 = DeathRocketShootOffset2 + 20)
                    {
                        if (DeathRocketsShot >= 200)
                        {
                            DeathAttkCounter2 = 0;
                            DeathAttkCounter1 = 0;
                            npc.ai[0] = 2;
                        }
                        Projectile.NewProjectile(new Vector2(npc.position.X - 400 + DeathRocketShootOffset2 * 6, player.position.Y - 800), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        DeathRocketsShot = DeathRocketsShot + 1;
                    }
                    break;

                case 2: // YEET SELF AT PLAYER AND THROW LOTS OF ROCKETS
		    if (!AliveCheck(player))
			break;
                    npc.dontTakeDamage = false;

                    targetPos = player.Center;
                    targetPos.X += 500 * (npc.Center.X < targetPos.X ? -1 : 1);
                    npc.ai[1]++;

                    if (npc.Distance(targetPos) > 50)
                    {
                        speedModifier = npc.localAI[3] > 0 ? 0.5f : 2f;
                        if (npc.Center.X < targetPos.X)
                        {
                            npc.velocity.X += speedModifier;
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X += speedModifier * 2;
                            }
                        }
                        else
                        {
                            npc.velocity.X -= speedModifier;
                            if (npc.velocity.X > 0)
                            {
                                npc.velocity.X -= speedModifier * 2;
                            }
                        }
                        if (npc.Center.Y < targetPos.Y)
                        {
                            npc.velocity.Y += speedModifier;
                            if (npc.velocity.Y < 0)
                            {
                                npc.velocity.Y += speedModifier * 2;
                            }
                        }
                        else
                        {
                            npc.velocity.Y -= speedModifier;
                            if (npc.velocity.Y > 0)
                            {
                                npc.velocity.Y -= speedModifier * 2;
                            }
                        }
                        if (npc.localAI[3] > 0)
                        {
                            if (Math.Abs(npc.velocity.X) > 24)
                            {
                                npc.velocity.X = 24 * Math.Sign(npc.velocity.X);
                            }

                            if (Math.Abs(npc.velocity.Y) > 24)
                            {
                                npc.velocity.Y = 24 * Math.Sign(npc.velocity.Y);
                            }
                        }
                    }

                    if (npc.ai[1] >= 30)
                    {
                        DeathAttkCounter1++;
                        for (int i = 0; i < 5 + Main.rand.Next(20); i++)
                        {
                            if (npc.direction == 1)
                            {
                                Projectile.NewProjectile(npc.Center, new Vector2(32, 0) + -Vector2.UnitX.RotatedBy(Main.rand.NextDouble() * 10), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            }
                            else
                            {
                                Projectile.NewProjectile(npc.Center, -new Vector2(32, 0) + Vector2.UnitX.RotatedBy(Main.rand.NextDouble() * 10), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            }

                            npc.ai[1] = 0;
                        }
                    }

                    if (DeathAttkCounter1 >= 5)
                    {
                        AttkChange(3);
                    }
                    break;

                case 3: // throw dagger bomb
		    if (!AliveCheck(player))
			break;
                    npc.ai[1]++;
                    if (npc.ai[1] > 60)
                    {
                        if (npc.direction == 1)
                        {
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(20, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(10, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(30, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        }
                        else
                        {
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(-20, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(-10, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                            Projectile.NewProjectile(new Vector2(npc.position.X, npc.position.Y), new Vector2(-30, -15), ModContent.ProjectileType<Projectiles.DeathItselfDaggerBomb>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        }
                        npc.ai[1] = 0;
                    }
                    targetPos = player.Center;
                    targetPos.X += 500 * (npc.Center.X < targetPos.X ? -1 : 1);
                    DeathAttkCounter4++;
                    speedModifier = npc.localAI[3] > 0 ? 0.5f : 2f;
                    if (DeathAttkCounter4 >= 60)
                    {
                        targetPos.Y = targetPos.Y - 0;
                        AttkChange(4);
                    }
                    else
                    {
                        targetPos.Y = targetPos.Y + 120;
                    }

                    if (npc.Distance(targetPos) > 50)
                    {
                        speedModifier = npc.localAI[3] > 0 ? 0.5f : 2f;
                        if (npc.Center.X < targetPos.X)
                        {
                            npc.velocity.X += speedModifier;
                            if (npc.velocity.X < 0)
                            {
                                npc.velocity.X += speedModifier * 2;
                            }
                        }
                        else
                        {
                            npc.velocity.X -= speedModifier;
                            if (npc.velocity.X > 0)
                            {
                                npc.velocity.X -= speedModifier * 2;
                            }
                        }
                        if (npc.Center.Y < targetPos.Y)
                        {
                            npc.velocity.Y += speedModifier;
                            if (npc.velocity.Y < 0)
                            {
                                npc.velocity.Y += speedModifier * 2;
                            }
                        }
                        else
                        {
                            npc.velocity.Y -= speedModifier;
                            if (npc.velocity.Y > 0)
                            {
                                npc.velocity.Y -= speedModifier * 2;
                            }
                        }
                        if (npc.localAI[3] > 0)
                        {
                            if (Math.Abs(npc.velocity.X) > 24)
                            {
                                npc.velocity.X = 24 * Math.Sign(npc.velocity.X);
                            }

                            if (Math.Abs(npc.velocity.Y) > 24)
                            {
                                npc.velocity.Y = 24 * Math.Sign(npc.velocity.Y);
                            }
                        }
                    }
                    DeathAttkCounter2++;
                    if (DeathAttkCounter2 >= 120)
                    {
                        AttkChange(4);
                    }

                    break;

                case 4: // lasers
		    if (!AliveCheck(player))
			break;
                    npc.velocity.X = 0f;
                    npc.velocity.Y = 0f;
                    npc.ai[1]++;

                    player.wingTimeMax = 999999;
                    player.wingTime = player.wingTimeMax;
                    player.onHitDodge = false;
                    player.shadowDodge = false;
                    player.blackBelt = false;
                    if (player.HasBuff(88))
                    {
                        player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " tried to escape under Death's watch."), 1.0, 0);
                    }
                    if (player.HasBuff(59))
                    {
                        player.ClearBuff(59);
                    }

                    if (npc.ai[1] == 60)
                    {
                        DeathLaserBoxPosition = player.Center;
                        //hear ye hear ye, code below is massive spaghetti and we could do it better. it works though
                        DeathLaserBoxValueFixer = new Vector2(DeathLaserBoxPosition.X + 1, DeathLaserBoxPosition.Y + 1);
                        DeathLaserBoxPosition = new Vector2(DeathLaserBoxValueFixer.X - 1, DeathLaserBoxValueFixer.Y - 1);
                        //ok no more spaghetti

                        //left and right lasers
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(-250, 0), new Vector2(0, 1), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(250, 0), new Vector2(0, 1), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(-250, 0), new Vector2(0, -1), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(250, 0), new Vector2(0, -1), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        //top and bottom lasers
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(0, -250), new Vector2(1, 0), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(0, 250), new Vector2(1, 0), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(0, -250), new Vector2(-1, 0), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                        Projectile.NewProjectile(DeathLaserBoxPosition + new Vector2(0, 250), new Vector2(-1, 0), ModContent.ProjectileType<Projectiles.Deathrays.DeathDeathray>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
                    }
                    if (npc.ai[1] == 180)
                    {
                        for (int i = -250; i > 0; i = i - 10)
			{
			    Projectile.NewProjectile(new Vector2(DeathLaserBoxPosition.X, DeathLaserBoxPosition.Y - 800) + new Vector2(i, -250), new Vector2(0, -10), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
                    }
                    if (npc.ai[1] == 240)
                    {
                        for (int i = 250; i > 0; i = i + 10)
			{
			    Projectile.NewProjectile(new Vector2(DeathLaserBoxPosition.X, DeathLaserBoxPosition.Y + 800) + new Vector2(i, 250), new Vector2(0, 10), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
		    }
                    if (npc.ai[1] == 300)
		    {
			// right rockets
			for (int i = -250; i < 0; i = i + 10)
			{
			    Projectile.NewProjectile(new Vector2(DeathLaserBoxPosition.X - 800, DeathLaserBoxPosition.Y) + new Vector2(-250, i), new Vector2(10, 0), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
		    }
		    if (npc.ai[1] == 360)
		    {	
			for (int i = 250; i > 0; i = i - 10)
			{
			    Projectile.NewProjectile(new Vector2(DeathLaserBoxPosition.X + 800, DeathLaserBoxPosition.Y) + new Vector2(250, i), new Vector2(-10, 0), ModContent.ProjectileType<Projectiles.SplodinatorRocketEvil>(), 400, 0f, Main.myPlayer, 0f, npc.whoAmI);
			}
		    }
                    break;
	    }
	}
		    
    

        public override void FindFrame(int frameHeight)
        {
            if (++npc.frameCounter > 3)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= 3 * frameHeight)
                {
                    npc.frame.Y = 0;
                }
            }
        }

	private bool AliveCheck(Player player)
	{
	    if (player.dead)
	    {
		if (npc.timeLeft > 30)
		    npc.timeLeft = 30;
		npc.velocity.Y -= 1f;
		return false;
	    }
	    return true;
	}
	
        private void AttkChange(int changeTo)
        {
            for (int i = 0; i < 120; i++)
            {
                npc.ai[1] = 0;
                DeathAttkChangeTimer = 0;
                DeathAttkChangeTimer++;
                DeathAttkCounter1 = 0;
                DeathAttkCounter2 = 0;
                DeathAttkCounter3 = 0;
                DeathRocketShootOffset = 0;
                DeathRocketShootOffset2 = 0;
                DeathRocketsShot = 0;
                npc.ai[0] = changeTo;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;
            Vector2 origin2 = rectangle.Size() / 2f;

            Color color26 = lightColor;
            color26 = npc.GetAlpha(color26);

            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(lightColor), npc.rotation, origin2, npc.scale, effects, 0f);
            return false;
        }

	public override void BossLoot(ref string name, ref int potionType)
        {
	    PaSWorld.downedDeathHimself = true;
            potionType = ItemID.SuperHealingPotion;
	    if (Main.expertMode)
	    {
		npc.DropBossBags();
	    }
	    else
	    {
		//handle drops manually?
	    }
        }
    }
}
