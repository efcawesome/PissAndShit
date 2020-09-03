using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
    public class TerraHawkProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Hawk");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            Main.projFrames[projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            projectile.width = 133;
            projectile.height = 45;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.hostile = false;
            projectile.scale = 1;
            aiType = -1;
        }

        public override void AI() 
        {
            if(projectile.velocity.X < 6)
            {
                projectile.velocity.X += 0.2f;
            }
            projectile.velocity.Y = 0;
            Dust dust;
            Vector2 position = projectile.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 133, 45, 15, 0f, 0f, 0, new Color(58, 255, 28), 1f)];
            projectile.ai[0]++;
            if(projectile.ai[0] >= 30)
            {
                Projectile.NewProjectile(projectile.Center, new Vector2(0, 10), ModContent.ProjectileType<TerraHawkBomb>(), 100, 5, Main.myPlayer);
                projectile.ai[0] = 0;
            }
            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 4)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}