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
        public bool cursedMedallion = false;
        public bool exoskeletonBad = false;
        public bool exoskeletonGood = false;
        public int stormbowStormbowType = 0;
        public int stormbowStormbowDamage = 0;
        public float stormbowStormbowKnockback = 0f;

        public override void ResetEffects()
        {
            kamra = false;
            soaped = false;
            ancientIdol = false;
            cursedMedallion = false;
            exoskeletonBad = false;
            exoskeletonGood = false;
            stormbowStormbowType = 0;
            stormbowStormbowDamage = 0;
            stormbowStormbowKnockback = 0f;
        }

        public override void UpdateBadLifeRegen()
        {
            if (kamra)
            {
                player.lifeRegenTime = 0;
                player.lifeRegen = player.lifeRegen > 0 ? -25 : player.lifeRegen - 25;
            }
        }
        
        public override void PreUpdate()
        {
            if (PaSWorld.endlessModeSave){
                if (player.ZoneSnow)
                {
                    player.AddBuff(BuffID.Chilled, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneDesert)
                {
                    player.AddBuff(BuffID.Slow, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneCorrupt)
                {
                    player.AddBuff(BuffID.Darkness, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneCrimson)
                {
                    player.AddBuff(BuffID.Ichor, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneJungle)
                {
                    player.AddBuff(BuffID.Bleeding, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneDungeon)
                {
                    player.AddBuff(BuffID.WaterCandle, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneBeach)
                {
                    player.AddBuff(BuffID.BrokenArmor, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneGlowshroom)
                {
                    player.AddBuff(BuffID.Confused, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneHoly)
                {
                    player.AddBuff(BuffID.ChaosState, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneUnderworldHeight)
                {
                    player.AddBuff(BuffID.Blackout, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneSkyHeight)
                {
                    player.AddBuff(BuffID.VortexDebuff, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneRockLayerHeight)
                {
                    player.AddBuff(BuffID.Rabies, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
                if (player.ZoneDirtLayerHeight)
                {
                    player.AddBuff(BuffID.Rabies, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2);
                }
            }
        }

        public override void PostUpdateBuffs()
        {
            if (PaSWorld.endlesserModeSave)
            {
                if (player.HasBuff(BuffID.MoonLeech))
                {
                    player.wingTimeMax = player.rocketTimeMax = 0;
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
        public override void PostUpdateRunSpeeds()
        {
            if(exoskeletonBad)
            {
                player.maxRunSpeed *= 0.5f;
                player.accRunSpeed *= 0.5f;
                player.moveSpeed *= 0.5f;
            }
            if(exoskeletonGood)
            {
                player.maxRunSpeed *= 0.5f;
                player.accRunSpeed *= 0.5f;
                player.moveSpeed *= 0.5f;
            }
            if(exoskeletonBad && exoskeletonGood)
            {
                player.maxRunSpeed *= 0.01f;
                player.accRunSpeed *= 0.01f;
                player.moveSpeed *= 0.01f;
            }
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (ancientIdol)
            {
                int projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;
            }
        }

        public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
        {
            if (ancientIdol)
            {
                int projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X + 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X, player.Center.Y + 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, 15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y, 0, -15, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, 15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;

                projectile = Projectile.NewProjectile(player.Center.X - 5, player.Center.Y - 5, -15, 0, ProjectileID.EyeBeam, 150, 3f, player.whoAmI);

                Main.projectile[projectile].hostile = false;
                Main.projectile[projectile].friendly = true;
            }
        }
    }
}
