using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Projectiles
{
    public class GasterBlaster : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Duke's Trusty Blaster");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.height = 60;
            projectile.width = 50;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 20; i++)
            {
                int KillDust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 212, projectile.direction * 2, 0f, 100, default, 1.4f);
                Dust DustExample = Main.dust[KillDust];

                DustExample.color = Color.LightPink;
                DustExample.color = Color.Lerp(DustExample.color, Color.White, 0.3f);
                DustExample.noGravity = true;
            }
        }

        public override void AI()
        {
            Vector2 center = projectile.Center;

            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                projectile.frame = ++projectile.frame % Main.projFrames[projectile.type];
            }

            projectile.ai[0] += 1f;

            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 0f;
                projectile.netUpdate = true;
                // Do something here, maybe change to a new state.
                NPC.NewNPC((int)center.X, (int)center.Y, NPCType<NPCs.SoapBubble>());
            }
        }
    }
}