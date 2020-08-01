using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class YoungDuke : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Duke");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 192;
            npc.height = 130;
            npc.aiStyle = 69;
            npc.damage = 25;
            npc.defense = 16;
            npc.lifeMax = 6500;
            npc.knockBackResist = 0f;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.npcSlots = 10f;
            npc.HitSound = SoundID.NPCHit14;
            npc.DeathSound = SoundID.NPCDeath20;
            npc.value = 10000f;
            npc.boss = true;
            npc.netAlways = true;
            npc.timeLeft = 22500;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[31] = true;
            npc.buffImmune[44] = true;
            animationType = NPCID.DukeFishron;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/YungDook_2");
            musicPriority = MusicPriority.BossHigh;

            bossBag = ModContent.ItemType<YoungDukeBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)((double)npc.lifeMax * 0.6 * (double)1f);
            npc.damage = (int)((double)npc.damage * 0.7);
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life > 0)
            {
                for (int num123 = 0; (double)num123 < npc.damage / (double)npc.lifeMax * 100.0; num123++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, hitDirection, -1f);
                }
            }
            else
            {
                for (int num125 = 0; num125 < 150; num125++)
                {
                    Dust.NewDust(npc.position, npc.width, npc.height, 5, 2 * hitDirection, -2f);
                }
                Gore.NewGore(npc.Center - Vector2.UnitX * 20f * npc.direction, npc.velocity, mod.GetGoreSlot("Gores/younggore_4"), npc.scale);
                Gore.NewGore(npc.Center - Vector2.UnitY * 30f, npc.velocity, mod.GetGoreSlot("Gores/younggore_3"), npc.scale);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/younggore_(1)"), npc.scale);
                Gore.NewGore(npc.Center - Vector2.UnitY * 30f, npc.velocity, mod.GetGoreSlot("Gores/younggore_3"), npc.scale);
                Gore.NewGore(npc.Center, npc.velocity, mod.GetGoreSlot("Gores/younggore_2"), npc.scale);
            }
        }

        public void SimpleFlyMovement(Vector2 desiredVelocity, float moveSpeed)
        {
            if (npc.velocity.X < desiredVelocity.X)
            {
                npc.velocity.X += moveSpeed;
                if (npc.velocity.X < 0f && desiredVelocity.X > 0f)
                {
                    npc.velocity.X += moveSpeed;
                }
            }
            else if (npc.velocity.X > desiredVelocity.X)
            {
                npc.velocity.X -= moveSpeed;
                if (npc.velocity.X > 0f && desiredVelocity.X < 0f)
                {
                    npc.velocity.X -= moveSpeed;
                }
            }
            if (npc.velocity.Y < desiredVelocity.Y)
            {
                npc.velocity.Y += moveSpeed;
                if (npc.velocity.Y < 0f && desiredVelocity.Y > 0f)
                {
                    npc.velocity.Y += moveSpeed;
                }
            }
            else if (npc.velocity.Y > desiredVelocity.Y)
            {
                npc.velocity.Y -= moveSpeed;
                if (npc.velocity.Y > 0f && desiredVelocity.Y < 0f)
                {
                    npc.velocity.Y -= moveSpeed;
                }
            }
        }

        public override void AI()
        {
            bool expertMode = Main.expertMode;
            float num = expertMode ? (0.6f * Main.damageMultiplier) : 1f;
            bool flag = (double)npc.life <= (double)npc.lifeMax * 0.5;
            bool flag2 = expertMode && (double)npc.life <= (double)npc.lifeMax * 0.15;
            bool flag3 = npc.ai[0] > 4f;
            bool flag4 = npc.ai[0] > 9f;
            bool flag5 = npc.ai[3] < 10f;
            if (flag4)
            {
                npc.damage = (int)((float)npc.defDamage * 1.1f * num);
                npc.defense = 0;
            }
            else if (flag3)
            {
                npc.damage = (int)((float)npc.defDamage * 1.2f * num);
                npc.defense = (int)((float)npc.defDefense * 0.8f);
            }
            else
            {
                npc.damage = npc.defDamage;
                npc.defense = npc.defDefense;
            }
            int num12 = expertMode ? 40 : 60;
            float num23 = expertMode ? 0.55f : 0.45f;
            float scaleFactor = expertMode ? 8.5f : 7.5f;
            if (flag4)
            {
                num23 = 0.7f;
                scaleFactor = 12f;
                num12 = 30;
            }
            else if (flag3 && flag5)
            {
                num23 = (expertMode ? 0.6f : 0.5f);
                scaleFactor = (expertMode ? 10f : 8f);
                num12 = (expertMode ? 40 : 20);
            }
            else if (flag5 && !flag3 && !flag4)
            {
                num12 = 30;
            }
            int num31 = expertMode ? 28 : 30;
            float num32 = expertMode ? 17f : 16f;
            if (flag4)
            {
                num31 = 25;
                num32 = 27f;
            }
            else if (flag5 && flag3)
            {
                num31 = (expertMode ? 27 : 30);
                if (expertMode)
                {
                    num32 = 21f;
                }
            }
            int num33 = 80;
            int num34 = 4;
            float num35 = 0.3f;
            float scaleFactor2 = 5f;
            int num36 = 90;
            int num2 = 180;
            int num3 = 180;
            int num4 = 30;
            int num5 = 120;
            int num6 = 4;
            float scaleFactor3 = 6f;
            float scaleFactor4 = 20f;
            float num7 = (float)Math.PI * 2f / (float)(num5 / 2);
            int num8 = 75;
            Vector2 center = npc.Center;
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest();
                player = Main.player[npc.target];
                npc.netUpdate = true;
            }
            if (player.dead || Vector2.DistanceSquared(player.Center, center) > 5600f * 5600f)
            {
                npc.velocity.Y -= 0.4f;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                if (npc.ai[0] > 4f)
                {
                    npc.ai[0] = 5f;
                }
                else
                {
                    npc.ai[0] = 0f;
                }
                npc.ai[2] = 0f;
            }
            if (player.position.Y < 800f || (double)player.position.Y > Main.worldSurface * 16.0 || (player.position.X > 6400f && player.position.X < (float)(Main.maxTilesX * 16 - 6400)))
            {
                num12 = 20;
                npc.damage = npc.defDamage * 2;
                npc.defense = npc.defDefense * 2;
                npc.ai[3] = 0f;
                num32 += 6f;
            }
            if (npc.localAI[0] == 0f)
            {
                npc.localAI[0] = 1f;
                npc.alpha = 255;
                npc.rotation = 0f;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    npc.ai[0] = -1f;
                    npc.netUpdate = true;
                }
            }
            float num9 = (float)Math.Atan2(player.Center.Y - center.Y, player.Center.X - center.X);
            if (npc.spriteDirection == 1)
            {
                num9 += (float)Math.PI;
            }
            if (num9 < 0f)
            {
                num9 += (float)Math.PI * 2f;
            }
            if (num9 > (float)Math.PI * 2f)
            {
                num9 -= (float)Math.PI * 2f;
            }
            if (npc.ai[0] == -1f)
            {
                num9 = 0f;
            }
            if (npc.ai[0] == 3f)
            {
                num9 = 0f;
            }
            if (npc.ai[0] == 4f)
            {
                num9 = 0f;
            }
            if (npc.ai[0] == 8f)
            {
                num9 = 0f;
            }
            float num10 = 0.04f;
            if (npc.ai[0] == 1f || npc.ai[0] == 6f)
            {
                num10 = 0f;
            }
            if (npc.ai[0] == 7f)
            {
                num10 = 0f;
            }
            if (npc.ai[0] == 3f)
            {
                num10 = 0.01f;
            }
            if (npc.ai[0] == 4f)
            {
                num10 = 0.01f;
            }
            if (npc.ai[0] == 8f)
            {
                num10 = 0.01f;
            }
            if (npc.rotation < num9)
            {
                if ((double)(num9 - npc.rotation) > Math.PI)
                {
                    npc.rotation -= num10;
                }
                else
                {
                    npc.rotation += num10;
                }
            }
            if (npc.rotation > num9)
            {
                if ((double)(npc.rotation - num9) > Math.PI)
                {
                    npc.rotation += num10;
                }
                else
                {
                    npc.rotation -= num10;
                }
            }
            if (npc.rotation > num9 - num10 && npc.rotation < num9 + num10)
            {
                npc.rotation = num9;
            }
            if (npc.rotation < 0f)
            {
                npc.rotation += (float)Math.PI * 2f;
            }
            if (npc.rotation > (float)Math.PI * 2f)
            {
                npc.rotation -= (float)Math.PI * 2f;
            }
            if (npc.rotation > num9 - num10 && npc.rotation < num9 + num10)
            {
                npc.rotation = num9;
            }
            if (npc.ai[0] != -1f && npc.ai[0] < 9f)
            {
                if (Collision.SolidCollision(npc.position, npc.width, npc.height))
                {
                    npc.alpha += 15;
                }
                else
                {
                    npc.alpha -= 15;
                }
                if (npc.alpha < 0)
                {
                    npc.alpha = 0;
                }
                if (npc.alpha > 150)
                {
                    npc.alpha = 150;
                }
            }
            if (npc.ai[0] == -1f)
            {
                npc.velocity *= 0.98f;
                int num11 = Math.Sign(player.Center.X - center.X);
                if (num11 != 0)
                {
                    npc.direction = num11;
                    npc.spriteDirection = -npc.direction;
                }
                if (npc.ai[2] > 20f)
                {
                    npc.velocity.Y = -2f;
                    npc.alpha -= 5;
                    if (Collision.SolidCollision(npc.position, npc.width, npc.height))
                    {
                        npc.alpha += 15;
                    }
                    if (npc.alpha < 0)
                    {
                        npc.alpha = 0;
                    }
                    if (npc.alpha > 150)
                    {
                        npc.alpha = 150;
                    }
                }
                if (npc.ai[2] == (float)(num36 - 30))
                {
                    int num13 = 36;
                    for (int i = 0; i < num13; i++)
                    {
                        Vector2 value6 = (Vector2.Normalize(npc.velocity) * new Vector2((float)npc.width / 2f, npc.height) * 0.75f * 0.5f).RotatedBy((float)(i - (num13 / 2 - 1)) * ((float)Math.PI * 2f) / (float)num13) + npc.Center;
                        Vector2 value2 = value6 - npc.Center;
                        int num14 = Dust.NewDust(value6 + value2, 0, 0, 172, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
                        Main.dust[num14].noGravity = true;
                        Main.dust[num14].noLight = true;
                        Main.dust[num14].velocity = Vector2.Normalize(value2) * 3f;
                    }
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num8)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 0f && !player.dead)
            {
                if (npc.ai[1] == 0f)
                {
                    npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
                }
                Vector2 vector = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
                if (npc.velocity.X < vector.X)
                {
                    npc.velocity.X += num23;
                    if (npc.velocity.X < 0f && vector.X > 0f)
                    {
                        npc.velocity.X += num23;
                    }
                }
                else if (npc.velocity.X > vector.X)
                {
                    npc.velocity.X -= num23;
                    if (npc.velocity.X > 0f && vector.X < 0f)
                    {
                        npc.velocity.X -= num23;
                    }
                }
                if (npc.velocity.Y < vector.Y)
                {
                    npc.velocity.Y += num23;
                    if (npc.velocity.Y < 0f && vector.Y > 0f)
                    {
                        npc.velocity.Y += num23;
                    }
                }
                else if (npc.velocity.Y > vector.Y)
                {
                    npc.velocity.Y -= num23;
                    if (npc.velocity.Y > 0f && vector.Y < 0f)
                    {
                        npc.velocity.Y -= num23;
                    }
                }
                int num15 = Math.Sign(player.Center.X - center.X);
                if (num15 != 0)
                {
                    if (npc.ai[2] == 0f && num15 != npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.direction = num15;
                    if (npc.spriteDirection != -npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.spriteDirection = -npc.direction;
                }
                npc.ai[2] += 1f;
                if (!(npc.ai[2] >= (float)num12))
                {
                    return;
                }
                int num16 = 0;
                switch ((int)npc.ai[3])
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        num16 = 1;
                        break;
                    case 10:
                        npc.ai[3] = 1f;
                        num16 = 2;
                        break;
                    case 11:
                        npc.ai[3] = 0f;
                        num16 = 3;
                        break;
                }
                if (flag)
                {
                    num16 = 4;
                }
                switch (num16)
                {
                    case 1:
                        npc.ai[0] = 1f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.velocity = Vector2.Normalize(player.Center - center) * num32;
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
                        if (num15 != 0)
                        {
                            npc.direction = num15;
                            if (npc.spriteDirection == 1)
                            {
                                npc.rotation += (float)Math.PI;
                            }
                            npc.spriteDirection = -npc.direction;
                        }
                        break;
                    case 2:
                        npc.ai[0] = 2f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                    case 3:
                        npc.ai[0] = 3f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                    case 4:
                        npc.ai[0] = 4f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                }
                npc.netUpdate = true;
            }
            else if (npc.ai[0] == 1f)
            {
                int num17 = 7;
                for (int j = 0; j < num17; j++)
                {
                    Vector2 value7 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(j - (num17 / 2 - 1)) * Math.PI / (double)(float)num17) + center;
                    Vector2 value3 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num18 = Dust.NewDust(value7 + value3, 0, 0, 172, value3.X * 2f, value3.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num18].noGravity = true;
                    Main.dust[num18].noLight = true;
                    Main.dust[num18].velocity /= 4f;
                    Main.dust[num18].velocity -= npc.velocity;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num31)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] += 2f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 2f)
            {
                if (npc.ai[1] == 0f)
                {
                    npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
                }
                Vector2 vector2 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor2;
                if (npc.velocity.X < vector2.X)
                {
                    npc.velocity.X += num35;
                    if (npc.velocity.X < 0f && vector2.X > 0f)
                    {
                        npc.velocity.X += num35;
                    }
                }
                else if (npc.velocity.X > vector2.X)
                {
                    npc.velocity.X -= num35;
                    if (npc.velocity.X > 0f && vector2.X < 0f)
                    {
                        npc.velocity.X -= num35;
                    }
                }
                if (npc.velocity.Y < vector2.Y)
                {
                    npc.velocity.Y += num35;
                    if (npc.velocity.Y < 0f && vector2.Y > 0f)
                    {
                        npc.velocity.Y += num35;
                    }
                }
                else if (npc.velocity.Y > vector2.Y)
                {
                    npc.velocity.Y -= num35;
                    if (npc.velocity.Y > 0f && vector2.Y < 0f)
                    {
                        npc.velocity.Y -= num35;
                    }
                }
                if (npc.ai[2] == 0f)
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                if (npc.ai[2] % (float)num34 == 0f)
                {
                    Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 vector3 = Vector2.Normalize(player.Center - center) * (npc.width + 20) / 2f + center;
                        NPC.NewNPC((int)vector3.X, (int)vector3.Y + 45, NPCType<SoapBubble>());
                    }
                }
                int num19 = Math.Sign(player.Center.X - center.X);
                if (num19 != 0)
                {
                    npc.direction = num19;
                    if (npc.spriteDirection != -npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.spriteDirection = -npc.direction;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num33)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 3f)
            {
                npc.velocity *= 0.98f;
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
                if (npc.ai[2] == (float)(num36 - 30))
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 9);
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num36 - 30))
                {
                    Vector2 vector4 = npc.rotation.ToRotationVector2() * (Vector2.UnitX * npc.direction) * (npc.width + 20) / 2f + center;
                    Projectile.NewProjectile(vector4.X, vector4.Y, npc.direction * 2, 8f, ProjectileType<Projectiles.YoungDukeSharknadoBolt>(), 0, 0f, Main.myPlayer);
                    Projectile.NewProjectile(vector4.X, vector4.Y, -npc.direction * 2, 8f, ProjectileType<Projectiles.YoungDukeSharknadoBolt>(), 0, 0f, Main.myPlayer);
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num36)
                {
                    npc.ai[0] = 0f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 4f)
            {
                npc.velocity *= 0.98f;
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
                if (npc.ai[2] == (float)(num2 - 60))
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num2)
                {
                    npc.ai[0] = 5f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 5f && !player.dead)
            {
                if (npc.ai[1] == 0f)
                {
                    npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
                }
                Vector2 vector5 = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
                if (npc.velocity.X < vector5.X)
                {
                    npc.velocity.X += num23;
                    if (npc.velocity.X < 0f && vector5.X > 0f)
                    {
                        npc.velocity.X += num23;
                    }
                }
                else if (npc.velocity.X > vector5.X)
                {
                    npc.velocity.X -= num23;
                    if (npc.velocity.X > 0f && vector5.X < 0f)
                    {
                        npc.velocity.X -= num23;
                    }
                }
                if (npc.velocity.Y < vector5.Y)
                {
                    npc.velocity.Y += num23;
                    if (npc.velocity.Y < 0f && vector5.Y > 0f)
                    {
                        npc.velocity.Y += num23;
                    }
                }
                else if (npc.velocity.Y > vector5.Y)
                {
                    npc.velocity.Y -= num23;
                    if (npc.velocity.Y > 0f && vector5.Y < 0f)
                    {
                        npc.velocity.Y -= num23;
                    }
                }
                int num20 = Math.Sign(player.Center.X - center.X);
                if (num20 != 0)
                {
                    if (npc.ai[2] == 0f && num20 != npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.direction = num20;
                    if (npc.spriteDirection != -npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.spriteDirection = -npc.direction;
                }
                npc.ai[2] += 1f;
                if (!(npc.ai[2] >= (float)num12))
                {
                    return;
                }
                int num21 = 0;
                switch ((int)npc.ai[3])
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        num21 = 1;
                        break;
                    case 6:
                        npc.ai[3] = 1f;
                        num21 = 2;
                        break;
                    case 7:
                        npc.ai[3] = 0f;
                        num21 = 3;
                        break;
                }
                if (flag2)
                {
                    num21 = 4;
                }
                switch (num21)
                {
                    case 1:
                        npc.ai[0] = 6f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.velocity = Vector2.Normalize(player.Center - center) * num32;
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
                        if (num20 != 0)
                        {
                            npc.direction = num20;
                            if (npc.spriteDirection == 1)
                            {
                                npc.rotation += (float)Math.PI;
                            }
                            npc.spriteDirection = -npc.direction;
                        }
                        break;
                    case 2:
                        npc.velocity = Vector2.Normalize(player.Center - center) * scaleFactor4;
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
                        if (num20 != 0)
                        {
                            npc.direction = num20;
                            if (npc.spriteDirection == 1)
                            {
                                npc.rotation += (float)Math.PI;
                            }
                            npc.spriteDirection = -npc.direction;
                        }
                        npc.ai[0] = 7f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                    case 3:
                        npc.ai[0] = 8f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                    case 4:
                        npc.ai[0] = 9f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                }
                npc.netUpdate = true;
            }
            else if (npc.ai[0] == 6f)
            {
                int num22 = 7;
                for (int k = 0; k < num22; k++)
                {
                    Vector2 value8 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(k - (num22 / 2 - 1)) * Math.PI / (double)(float)num22) + center;
                    Vector2 value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num24 = Dust.NewDust(value8 + value4, 0, 0, 172, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num24].noGravity = true;
                    Main.dust[num24].noLight = true;
                    Main.dust[num24].velocity /= 4f;
                    Main.dust[num24].velocity -= npc.velocity;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num31)
                {
                    npc.ai[0] = 5f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] += 2f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 7f)
            {
                if (npc.ai[2] == 0f)
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                if (npc.ai[2] % (float)num6 == 0f)
                {
                    Main.PlaySound(SoundID.NPCKilled, (int)npc.Center.X, (int)npc.Center.Y, 19);
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 vector6 = Vector2.Normalize(npc.velocity) * (npc.width + 20) / 2f + center;
                        int num25 = NPC.NewNPC((int)vector6.X, (int)vector6.Y + 45, NPCType<SoapBubble>());
                        Main.npc[num25].target = npc.target;
                        Main.npc[num25].velocity = Vector2.Normalize(npc.velocity).RotatedBy((float)Math.PI / 2f * (float)npc.direction) * scaleFactor3;
                        Main.npc[num25].netUpdate = true;
                    }
                }
                npc.velocity = npc.velocity.RotatedBy((0f - num7) * (float)npc.direction);
                npc.rotation -= num7 * (float)npc.direction;
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num5)
                {
                    npc.ai[0] = 5f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 8f)

            {
                npc.velocity *= 0.98f;
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
                if (npc.ai[2] == (float)(num36 - 30))
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num36 - 30))
                {
                    Projectile.NewProjectile(center.X, center.Y, npc.direction * 2, 4f, ProjectileType<Projectiles.GasterBlaster>(), 0, 0f, Main.myPlayer);
                    Projectile.NewProjectile(center.X, center.Y, -npc.direction * 2, 4f, ProjectileType<Projectiles.GasterBlaster>(), 0, 0f, Main.myPlayer);
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num36)
                {
                    npc.ai[0] = 5f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 9f)
            {
                if (npc.ai[2] < (float)(num3 - 90))
                {
                    if (Collision.SolidCollision(npc.position, npc.width, npc.height))
                    {
                        npc.alpha += 15;
                    }
                    else
                    {
                        npc.alpha -= 15;
                    }
                    if (npc.alpha < 0)
                    {
                        npc.alpha = 0;
                    }
                    if (npc.alpha > 150)
                    {
                        npc.alpha = 150;
                    }
                }
                else if (npc.alpha < 255)
                {
                    npc.alpha += 4;
                    if (npc.alpha > 255)
                    {
                        npc.alpha = 255;
                    }
                }
                npc.velocity *= 0.98f;
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
                if (npc.ai[2] == (float)(num3 - 60))
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num3)
                {
                    npc.ai[0] = 10f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] = 0f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 10f && !player.dead)
            {
                npc.dontTakeDamage = false;
                npc.chaseable = false;
                if (npc.alpha < 255)
                {
                    npc.alpha += 25;
                    if (npc.alpha > 255)
                    {
                        npc.alpha = 255;
                    }
                }
                if (npc.ai[1] == 0f)
                {
                    npc.ai[1] = 360 * Math.Sign((center - player.Center).X);
                }
                Vector2 desiredVelocity = Vector2.Normalize(player.Center + new Vector2(npc.ai[1], -200f) - center - npc.velocity) * scaleFactor;
                SimpleFlyMovement(desiredVelocity, num23);
                int num26 = Math.Sign(player.Center.X - center.X);
                if (num26 != 0)
                {
                    if (npc.ai[2] == 0f && num26 != npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                        for (int l = 0; l < npc.oldPos.Length; l++)
                        {
                            npc.oldPos[l] = Vector2.Zero;
                        }
                    }
                    npc.direction = num26;
                    if (npc.spriteDirection != -npc.direction)
                    {
                        npc.rotation += (float)Math.PI;
                    }
                    npc.spriteDirection = -npc.direction;
                }
                npc.ai[2] += 1f;
                if (!(npc.ai[2] >= (float)num12))
                {
                    return;
                }
                int num27 = 0;
                switch ((int)npc.ai[3])
                {
                    case 0:
                    case 2:
                    case 3:
                    case 5:
                    case 6:
                    case 7:
                        num27 = 1;
                        break;
                    case 1:
                    case 4:
                    case 8:
                        num27 = 2;
                        break;
                }
                switch (num27)
                {
                    case 1:
                        npc.ai[0] = 11f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        npc.velocity = Vector2.Normalize(player.Center - center) * num32;
                        npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X);
                        if (num26 != 0)
                        {
                            npc.direction = num26;
                            if (npc.spriteDirection == 1)
                            {
                                npc.rotation += (float)Math.PI;
                            }
                            npc.spriteDirection = -npc.direction;
                        }
                        break;
                    case 2:
                        npc.ai[0] = 12f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                    case 3:
                        npc.ai[0] = 13f;
                        npc.ai[1] = 0f;
                        npc.ai[2] = 0f;
                        break;
                }
                npc.netUpdate = true;
            }
            else if (npc.ai[0] == 11f)
            {
                npc.dontTakeDamage = false;
                npc.chaseable = true;
                npc.alpha -= 25;
                if (npc.alpha < 0)
                {
                    npc.alpha = 0;
                }
                int num28 = 7;
                for (int m = 0; m < num28; m++)
                {
                    Vector2 value9 = (Vector2.Normalize(npc.velocity) * new Vector2((float)(npc.width + 50) / 2f, npc.height) * 0.75f).RotatedBy((double)(m - (num28 / 2 - 1)) * Math.PI / (double)(float)num28) + center;
                    Vector2 value5 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - (float)Math.PI / 2f).ToRotationVector2() * Main.rand.Next(3, 8);
                    int num29 = Dust.NewDust(value9 + value5, 0, 0, 172, value5.X * 2f, value5.Y * 2f, 100, default(Color), 1.4f);
                    Main.dust[num29].noGravity = true;
                    Main.dust[num29].noLight = true;
                    Main.dust[num29].velocity /= 4f;
                    Main.dust[num29].velocity -= npc.velocity;
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num31)
                {
                    npc.ai[0] = 10f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] += 1f;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 12f)
            {
                npc.dontTakeDamage = true;
                npc.chaseable = false;
                if (npc.alpha < 255)
                {
                    npc.alpha += 17;
                    if (npc.alpha > 255)
                    {
                        npc.alpha = 255;
                    }
                }
                npc.velocity *= 0.98f;
                npc.velocity.Y = MathHelper.Lerp(npc.velocity.Y, 0f, 0.02f);
                if (npc.ai[2] == (float)(num4 / 2))
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                if (Main.netMode != NetmodeID.MultiplayerClient && npc.ai[2] == (float)(num4 / 2))
                {
                    if (npc.ai[1] == 0f)
                    {
                        npc.ai[1] = 300 * Math.Sign((center - player.Center).X);
                    }
                    Vector2 vector7 = player.Center + new Vector2(0f - npc.ai[1], -200f);
                    Vector2 vector9 = npc.Center = vector7;
                    center = vector9;
                    int num30 = Math.Sign(player.Center.X - center.X);
                    if (num30 != 0)
                    {
                        if (npc.ai[2] == 0f && num30 != npc.direction)
                        {
                            npc.rotation += (float)Math.PI;
                            for (int n = 0; n < npc.oldPos.Length; n++)
                            {
                                npc.oldPos[n] = Vector2.Zero;
                            }
                        }
                        npc.direction = num30;
                        if (npc.spriteDirection != -npc.direction)
                        {
                            npc.rotation += (float)Math.PI;
                        }
                        npc.spriteDirection = -npc.direction;
                    }
                }
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num4)
                {
                    npc.ai[0] = 10f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] += 1f;
                    if (npc.ai[3] >= 9f)
                    {
                        npc.ai[3] = 0f;
                    }
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 13f)
            {
                if (npc.ai[2] == 0f)
                {
                    Main.PlaySound(SoundID.Zombie, (int)center.X, (int)center.Y, 20);
                }
                npc.velocity = npc.velocity.RotatedBy((0f - num7) * (float)npc.direction);
                npc.rotation -= num7 * (float)npc.direction;
                npc.ai[2] += 1f;
                if (npc.ai[2] >= (float)num5)
                {
                    npc.ai[0] = 10f;
                    npc.ai[1] = 0f;
                    npc.ai[2] = 0f;
                    npc.ai[3] += 1f;
                    npc.netUpdate = true;
                }
            }
        }
    }
}
