using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class SoapBubble : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soap Bubble");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DetonatingBubble];
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 36;
            npc.damage = 100;
            npc.aiStyle = NPCID.DetonatingBubble;
            npc.defense = 0;
            npc.lifeMax = 1;
            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath3;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.alpha = 255;
            NPCID.Sets.NeedsExpertScaling[npc.type] = true;
            NPCID.Sets.ProjectileNPC[npc.type] = true;
        }


        public override void OnHitPlayer(Player target, int damage, bool crit)
        {

            target.AddBuff(mod.BuffType("Soaped"), 300, false);
        }




        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(SoundID.NPCKilled, (int)npc.position.X, (int)npc.position.Y, 3);
            if (npc.life <= 0)
            {
                _ = npc.Center;
                for (int num120 = 0; num120 < 60; num120++)
                {
                    int num121 = 25;
                    _ = ((float)Main.rand.NextDouble() * ((float)Math.PI * 2f)).ToRotationVector2() * Main.rand.Next(24, 41) / 8f;
                    int num122 = Dust.NewDust(npc.Center - Vector2.One * num121, num121 * 2, num121 * 2, 212);
                    Dust dust154 = Main.dust[num122];
                    Vector2 vector7 = Vector2.Normalize(dust154.position - npc.Center);
                    dust154.position = npc.Center + vector7 * 25f * npc.scale;
                    if (num120 < 30)
                    {
                        dust154.velocity = vector7 * dust154.velocity.Length();
                    }
                    else
                    {
                        dust154.velocity = vector7 * Main.rand.Next(45, 91) / 10f;
                    }
                    dust154.color = Main.hslToRgb((float)(0.40000000596046448 + Main.rand.NextDouble() * 0.20000000298023224), 0.9f, 0.5f);
                    dust154.color = Color.Lerp(dust154.color, Color.White, 0.3f);
                    dust154.noGravity = true;
                    dust154.scale = 0.7f;
                }
            }


        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage = 0.0;
            npc.ai[0] = 1f;
            npc.ai[1] = 4f;
            npc.dontTakeDamage = true;
            return false;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {

            npc.damage = (int)((double)npc.damage * 0.75);
        }

        public override void AI()
        {
            if (npc.target == 255)
            {
                npc.TargetClosest();
                npc.ai[3] = (float)Main.rand.Next(80, 121) / 100f;
                float scaleFactor = (float)Main.rand.Next(165, 265) / 15f;
                npc.velocity = Vector2.Normalize(Main.player[npc.target].Center - npc.Center + new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101))) * scaleFactor;
                npc.netUpdate = true;
            }
            Vector2 vector27 = Vector2.Normalize(Main.player[npc.target].Center - npc.Center);
            npc.velocity = (npc.velocity * 40f + vector27 * 20f) / 41f;
            npc.scale = npc.ai[3];
            npc.alpha -= 30;
            if (npc.alpha < 50)
            {
                npc.alpha = 50;
            }
            npc.alpha = 50;
            npc.velocity.X = (npc.velocity.X * 50f + Main.windSpeed * 2f + (float)Main.rand.Next(-10, 11) * 0.1f) / 51f;
            npc.velocity.Y = (npc.velocity.Y * 50f + -0.25f + (float)Main.rand.Next(-10, 11) * 0.2f) / 51f;
            if (npc.velocity.Y > 0f)
            {
                npc.velocity.Y -= 0.04f;
            }
            if (npc.ai[0] == 0f)
            {
                int num37 = 40;
                Rectangle rect = npc.getRect();
                rect.X -= num37 + npc.width / 2;
                rect.Y -= num37 + npc.height / 2;
                rect.Width += num37 * 2;
                rect.Height += num37 * 2;
                for (int num38 = 0; num38 < 255; num38++)
                {
                    Player player2 = Main.player[num38];
                    if (player2.active && !player2.dead && rect.Intersects(player2.getRect()))
                    {
                        npc.ai[0] = 1f;
                        npc.ai[1] = 4f;
                        npc.netUpdate = true;
                        break;
                    }
                }
            }
            if (npc.ai[0] == 0f)
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 150f)
                {
                    npc.ai[0] = 1f;
                    npc.ai[1] = 4f;
                }
            }
            if (npc.ai[0] == 1f)
            {
                npc.ai[1]--;
                if (npc.ai[1] <= 0f)
                {
                    npc.life = 0;
                    npc.HitEffect();
                    npc.active = false;
                    return;
                }
            }
            if (npc.justHit || npc.ai[0] == 1f)
            {
                npc.dontTakeDamage = true;
                npc.position = npc.Center;
                npc.width = (npc.height = 100);
                npc.position = new Vector2(npc.position.X - (float)(npc.width / 2), npc.position.Y - (float)(npc.height / 2));
                if (npc.timeLeft > 3)
                {
                    npc.timeLeft = 3;
                }
            }
        }
    }

}
