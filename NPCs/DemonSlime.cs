using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace PissAndShit.NPCs
{
    class DemonSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Slime");
            Main.npcFrameCount[npc.type] = 2;
        }


        public override void SetDefaults()
        {
            npc.height = 18;
            npc.width = 29;
            npc.damage = 19;
            npc.lifeMax = 125;
            npc.defense = 17;
            npc.knockBackResist = 0;
            npc.value = 69f;
            npc.aiStyle = 14;
            npc.lavaImmune = true;
            npc.buffImmune[24] = true;
            npc.buffImmune[39] = true;
            animationType = NPCID.GreenSlime;
        }

        public override void AI()
        {
            npc.TargetClosest();
            npc.spriteDirection = npc.direction;
            float num1514 = 7f;
            Vector2 vector25 = new Vector2(npc.Center.X + (float)(npc.direction * 20), npc.Center.Y + 6f);
            float num1515 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector25.X;
            float num1516 = Main.player[npc.target].position.Y - vector25.Y;
            float num1517 = (float)Math.Sqrt(num1515 * num1515 + num1516 * num1516);
            float num1518 = num1514 / num1517;
            num1515 *= num1518;
            num1516 *= num1518;
            bool flag61 = Collision.CanHit(npc.Center, 1, 1, Main.player[npc.target].Center, 1, 1);
            if (Main.dayTime)
            {
                int num1519 = 60;
                npc.velocity.X = (npc.velocity.X * (float)(num1519 - 1) - num1515) / (float)num1519;
                npc.velocity.Y = (npc.velocity.Y * (float)(num1519 - 1) - num1516) / (float)num1519;
                if (npc.timeLeft > 10)
                {
                    npc.timeLeft = 10;
                }
                return;
            }
            if (num1517 > 600f || !flag61)
            {
                int num1520 = 60;
                npc.velocity.X = (npc.velocity.X * (float)(num1520 - 1) + num1515) / (float)num1520;
                npc.velocity.Y = (npc.velocity.Y * (float)(num1520 - 1) + num1516) / (float)num1520;
                return;
            }
            npc.velocity *= 0.98f;
            if (Math.Abs(npc.velocity.X) < 1f && Math.Abs(npc.velocity.Y) < 1f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.localAI[0] += 1f;
                if (npc.localAI[0] >= 15f)
                {
                    npc.localAI[0] = 0f;
                    num1515 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector25.X;
                    num1516 = Main.player[npc.target].Center.Y - vector25.Y;
                    num1515 += (float)Main.rand.Next(-35, 36);
                    num1516 += (float)Main.rand.Next(-35, 36);
                    num1515 *= 1f + (float)Main.rand.Next(-20, 21) * 0.015f;
                    num1516 *= 1f + (float)Main.rand.Next(-20, 21) * 0.015f;
                    num1517 = (float)Math.Sqrt(num1515 * num1515 + num1516 * num1516);
                    num1514 = 10f;
                    num1518 = num1514 / num1517;
                    num1515 *= num1518;
                    num1516 *= num1518;
                    num1515 *= 1f + (float)Main.rand.Next(-20, 21) * 0.0125f;
                    num1516 *= 1f + (float)Main.rand.Next(-20, 21) * 0.0125f;
                    int num1522 = Projectile.NewProjectile(vector25.X, vector25.Y, num1515, num1516, ProjectileID.DemonSickle, 32, 0f, Main.myPlayer);
                }
            }
        }






    }
}
