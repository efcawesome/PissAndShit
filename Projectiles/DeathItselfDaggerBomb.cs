// kindly ignore the using abomination
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace PissAndShit.Projectiles
{
    public class DeathItselfDaggerBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("deaths meme stabber kaboomer");
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.damage = 400;
            projectile.hostile = true;
            projectile.knockBack = 2;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.width = 38;
            projectile.height = 24;
            projectile.scale *= 1.3f;
            projectile.timeLeft = 30;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
            int num13 = 6;

            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.ai[1] = 0f;
                projectile.alpha = 255;
                Resize(128, 128);
                projectile.damage = 800;
                projectile.knockBack = 8f;
            }
            else
            {
                projectile.damage = 0;
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
        }

        private void Resize(int newWidth, int newHeight)
        {
            projectile.position = projectile.Center;
            projectile.width = newWidth;
            projectile.height = newHeight;
            projectile.Center = projectile.position;
        }

        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.DeathItselfDagger>(), 400, 0f, Main.myPlayer, 0f, projectile.owner);
            Projectile.NewProjectile(new Vector2(projectile.position.X - 50, projectile.position.Y), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.DeathItselfDagger>(), 400, 0f, Main.myPlayer, 0f, projectile.owner);
            Projectile.NewProjectile(new Vector2(projectile.position.X + 50, projectile.position.Y), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.DeathItselfDagger>(), 400, 0f, Main.myPlayer, 0f, projectile.owner);
            Projectile.NewProjectile(new Vector2(projectile.position.X - 100, projectile.position.Y), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.DeathItselfDagger>(), 400, 0f, Main.myPlayer, 0f, projectile.owner);
            Projectile.NewProjectile(new Vector2(projectile.position.X + 100, projectile.position.Y), new Vector2(0, 25), ModContent.ProjectileType<Projectiles.DeathItselfDagger>(), 400, 0f, Main.myPlayer, 0f, projectile.owner);

            return;
        }
    }
}
