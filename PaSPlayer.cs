using Microsoft.Xna.Framework;
using PissAndShit.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit
{
    public class PaSPlayer : ModPlayer
    {
        public bool kamra = false;
        public bool soaped = false;
        public bool ancientIdol = false;

        public override void ResetEffects()
        {
            kamra = false;
            soaped = false;
            ancientIdol = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (kamra)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 25;
            }
        }

        public override void PostUpdateBuffs()
        {
            if (PaSWorld.endlesserModeSave == true)
            {
                if (player.HasBuff(145))
                {
                    player.wingTimeMax = 0;
                    player.rocketTimeMax = 0;
                }
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (soaped)
            {
                if (Main.rand.NextBool(4) && drawInfo.shadow == 0f)
                {
                    int dust = Dust.NewDust(drawInfo.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, DustType<SoapBubble>(), player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default, 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0.1f;
                g *= 0.5f;
                b *= 0.7f;
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (ancientIdol == true)
            {
                int projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;
                int projectile1 = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile1].hostile = false;
                Main.projectile[projectile1].friendly = true;
                int projectile2 = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile2].hostile = false;
                Main.projectile[projectile2].friendly = true;
                int projectile3 = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile3].hostile = false;
                Main.projectile[projectile3].friendly = true;
                int projectile4 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile4].hostile = false;
                Main.projectile[projectile4].friendly = true;
                int projectile5 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile5].hostile = false;
                Main.projectile[projectile5].friendly = true;
                int projectile6 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile6].hostile = false;
                Main.projectile[projectile6].friendly = true;
                int projectile7 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile7].hostile = false;
                Main.projectile[projectile7].friendly = true;
            }
        }
        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (ancientIdol == true)
            {
                int projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;
                int projectile1 = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile1].hostile = false;
                Main.projectile[projectile1].friendly = true;
                int projectile2 = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile2].hostile = false;
                Main.projectile[projectile2].friendly = true;
                int projectile3 = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile3].hostile = false;
                Main.projectile[projectile3].friendly = true;
                int projectile4 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile4].hostile = false;
                Main.projectile[projectile4].friendly = true;
                int projectile5 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile5].hostile = false;
                Main.projectile[projectile5].friendly = true;
                int projectile6 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile6].hostile = false;
                Main.projectile[projectile6].friendly = true;
                int projectile7 = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);
                Main.projectile[projectile7].hostile = false;
                Main.projectile[projectile7].friendly = true;
            }
        }
    }
}