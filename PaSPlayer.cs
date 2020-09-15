using Microsoft.Xna.Framework;
using PissAndShit.Dusts;
using Terraria;
using Terraria.DataStructures;
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
        private int cancerCounter = 0;
        private bool jungleTalked = false;
        private bool spaceTalked = false;
        public override void ResetEffects()
        {
            kamra = false;
            soaped = false;
            ancientIdol = false;
            cursedMedallion = false;
            exoskeletonBad = false;
            exoskeletonGood = false;
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
                    player.AddBuff(BuffID.Chilled, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneDesert)
                {
                    player.AddBuff(BuffID.Slow, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneCorrupt)
                {
                    player.AddBuff(BuffID.Darkness, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneCrimson)
                {
                    player.AddBuff(BuffID.Ichor, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneJungle)
                {
                    player.AddBuff(BuffID.Bleeding, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneDungeon)
                {
                    player.AddBuff(BuffID.WaterCandle, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneBeach)
                {
                    player.AddBuff(BuffID.BrokenArmor, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneGlowshroom)
                {
                    player.AddBuff(BuffID.Confused, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneHoly)
                {
                    player.AddBuff(BuffID.ChaosState, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneUnderworldHeight)
                {
                    player.AddBuff(BuffID.Blackout, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneSkyHeight)
                {
                    player.AddBuff(BuffID.VortexDebuff, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneRockLayerHeight)
                {
                    player.AddBuff(BuffID.Rabies, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
                if (player.ZoneDirtLayerHeight)
                {
                    player.AddBuff(BuffID.Rabies, Main.expertMode && Main.expertDebuffTime > 1 ? 1 : 2, false);
                }
            }
            if (PaSWorld.endlesserModeSave)
            {
                if (player.ZoneCorrupt || player.ZoneCrimson)
                {
                    cancerCounter++;
                    switch (cancerCounter)
                    {
                        case 4500:
                            Main.NewText($"{player.name} is feeling queasy", 50, 237, 21);
                            break;
                        case 9000:
                            Main.NewText($"{player.name}'s hair is falling out in chunks", 39, 194, 16);
                            break;
                        case 13500:
                            Main.NewText($"{player.name} is seeing spots", 28, 143, 11);
                            break;
                        case 18000:
                            player.KillMe(PlayerDeathReason.ByCustomReason($"{player.name} got cancer"), 10000, 1);
                            cancerCounter = 0;
                            break;
                    }
                    if(!NPC.downedSlimeKing)
                    {
                        player.KillMe(PlayerDeathReason.ByCustomReason($"Gelatinous goop covers this evil"), 10000, 1);
                        player.ZoneCrimson = false;
                    }
                }
                else
                {
                    cancerCounter--;
                    if (cancerCounter < 0) cancerCounter = 0;
                }
                if(player.ZoneJungle && (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !NPC.downedBoss1)
                {
                    player.width = 0;
                    player.height = 0;
                    player.velocity.Y -= 10;
                    if(!jungleTalked)
                    {
                        Main.NewText("The eye of cthulhu guards its treasure buried in the jungle", 0, 255, 0);
                        jungleTalked = true;
                    }
                }
                else
                {
                    if(jungleTalked)
                    {
                        jungleTalked = false;
                        player.width = 32;
                        player.height = 48;
                    }
                }
                if (player.ZoneUnderworldHeight && !NPC.downedBoss2)
                {
                    if (WorldGen.crimson) player.KillMe(PlayerDeathReason.ByCustomReason("Brain of Cthulhu watches you as you burn in hell"), 10000, 1);
                    else player.KillMe(PlayerDeathReason.ByCustomReason("Eater of Worlds watches you as you burn in hell"), 10000, 1);

                    player.ZoneUnderworldHeight = false;
                }
                if (player.ZoneSkyHeight && !NPC.downedBoss3)
                {
                    player.velocity.Y += 10;
                    if (!spaceTalked)
                    {
                        Main.NewText("Skeletron throws you out of the sky", 0, 0, 255);
                        spaceTalked = true;
                    }
                }
                else
                {
                    if(spaceTalked)
                    {
                        spaceTalked = false;
                    }
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
