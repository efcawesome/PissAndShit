using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles.Deathrays
{
    public abstract class BaseDeathray : ModProjectile
    {
        private readonly float maxTime;
        private readonly string texture;

        protected BaseDeathray(float maxTime, string texture)
        {
            this.maxTime = maxTime;
            this.texture = texture;
        }

        public override void SetDefaults() //MAKE SURE YOU CALL BASE.SETDEFAULTS IF OVERRIDING
        {
            projectile.width = 48;
            projectile.height = 48;
            projectile.hostile = true;
            projectile.alpha = 255;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft = 600;

            cooldownSlot = 1; //not in warning line, test?

            projectile.hide = true; //fixes weird issues on spawn with scaling
        }

        public override void PostAI() => projectile.hide = false;

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.velocity != Vector2.Zero)
            {
                Texture2D projectileTexture = Main.projectileTexture[projectile.type];
                Texture2D deathrayTexture2 = ModContent.GetTexture("PissAndShit/Projectiles/Deathrays/" + texture + "2");
                Texture2D deathrayTexture3 = ModContent.GetTexture("PissAndShit/Projectiles/Deathrays/" + texture + "3");
                float num = projectile.localAI[1];
                Color color = new Color(255, 255, 255, 0) * 0.9f;
                Texture2D projectileTexture2 = projectileTexture;
                Vector2 projCenter = projectile.Center - Main.screenPosition;
                Rectangle? sourceRectangle = null;

                spriteBatch.Draw(projectileTexture2, projCenter, sourceRectangle, color, projectile.rotation, projectileTexture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);

                num -= (projectileTexture.Height / 2 + deathrayTexture3.Height) * projectile.scale;

                Vector2 projectileCenter = projectile.Center;
                projectileCenter += projectile.velocity * projectile.scale * projectileTexture.Height / 2f;

                if (num > 0f)
                {
                    float num2 = 0f;
                    Rectangle rectangle = new Rectangle(0, 16 * (projectile.timeLeft / 3 % 5), deathrayTexture2.Width, 16);

                    while (num2 + 1f < num)
                    {
                        if (num - num2 < rectangle.Height)
                        {
                            rectangle.Height = (int)(num - num2);
                        }

                        spriteBatch.Draw(deathrayTexture2, projectileCenter - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(rectangle), color, projectile.rotation, new Vector2(rectangle.Width / 2, 0f), projectile.scale, SpriteEffects.None, 0f);

                        num2 += rectangle.Height * projectile.scale;
                        projectileCenter += projectile.velocity * rectangle.Height * projectile.scale;
                        rectangle.Y += 16;

                        if (rectangle.Y + rectangle.Height > deathrayTexture2.Height)
                        {
                            rectangle.Y = 0;
                        }
                    }
                }

                projectileCenter -= Main.screenPosition;
                sourceRectangle = null;

                spriteBatch.Draw(deathrayTexture3, projectileCenter, sourceRectangle, color, projectile.rotation, deathrayTexture3.Frame(1, 1, 0, 0).Top(), projectile.scale, SpriteEffects.None, 0f);
            }

            return false;
        }

        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 unit = projectile.velocity;
            Utils.PlotTileLine(projectile.Center, projectile.Center + unit * projectile.localAI[1], projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CutTiles));
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (projHitbox.Intersects(targetHitbox))
            {
                return true;
            }
            float num6 = 0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], 22f * projectile.scale, ref num6))
            {
                return true;
            }
            return false;
        }
    }
}