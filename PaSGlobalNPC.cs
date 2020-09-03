using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class PaSGlobalNPC : GlobalNPC
    {
        private static int eyeSpawnTimer = 0;
        private static int brainRegenTimer = 0;
        private static int corrupterTimer = 0;
        private static int worldFeederTimer = 0;
        private static int stingerShootTimer = 0;
        private static int boneShootTimer = 0;
        private static int destroyerShootTimer = 0;
        private static int dungeonEnemySpawnTimer = 0;
        private static int planteraDespawnTimer = 0;
        private static int leftFistShootTimer = 0;
        private static int rightFistShootTimer = 0;
        private static int headShootTimer = 0;
        private static int headFireballTimer = 0;
        private static int bodyLaserTimer = 0;
        private static int lunarEnemySpawnTimer = 0;
        private static int eyeballTimer = 0;
        private static int handEyeShootTimer = 0;
        private static bool wanderingEyeSpawned = false;
        private static bool extraCreeperSpawn = false;
        private static bool planteraStatusBool = false;
        private static bool golemLowLife = false;
        private static bool ancientDragonSpawned = false;
        private static bool lunarEnemySpawn = false;

        public static bool hardDifficulty = PaSWorld.endlessModeSave;
        public static bool endlesserMode = PaSWorld.endlesserModeSave;

        public static bool cursedMedallionSpawn = false;

        public override void SetDefaults(NPC npc)
        {
            if (hardDifficulty)
            {
                switch (npc.type)
                {
                    case NPCID.TheDestroyerBody:
                        npc.defense = 10000;
                        break;

                    case NPCID.SkeletronPrime:
                        npc.damage = 100000;
                        break;

                    case NPCID.PrimeCannon:
                    case NPCID.PrimeSaw:
                    case NPCID.PrimeVice:
                    case NPCID.PrimeLaser:
                    case NPCID.PlanterasTentacle:
                    case NPCID.GolemFistLeft:
                    case NPCID.GolemFistRight:
                        npc.immortal = true;
                        break;

                    case NPCID.CultistDragonHead:
                    case NPCID.CultistDragonBody1:
                    case NPCID.CultistDragonBody2:
                    case NPCID.CultistDragonBody3:
                    case NPCID.CultistDragonBody4:
                    case NPCID.CultistDragonTail:
                        if (NPC.AnyNPCs(NPCID.CultistBoss))
                        {
                            npc.immortal = true;
                        }
                        break;

                    case NPCID.SolarCrawltipedeTail:
                    case NPCID.NebulaBrain:
                    case NPCID.VortexHornetQueen:
                    case NPCID.StardustJellyfishBig:
                        if (NPC.AnyNPCs(NPCID.CultistBoss) && endlesserMode)
                        {
                            npc.immortal = true;
                        }
                        break;
                }

                npc.life = npc.lifeMax *= 2;
            }
        }

        public override void AI(NPC npc)
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 targetPositionDifficult1 = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            Vector2 shootPos1 = npc.Center;
            float accuracy = 5f * (npc.life / npc.lifeMax);
            Vector2 shootVel1 = targetPositionDifficult1 - shootPos1 + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));

            npc.netAlways = true;
            shootVel1.Normalize();
            shootVel1 *= 14.5f;

            if (npc.life > npc.lifeMax)
            {
                npc.life = npc.lifeMax;
            }

            switch (npc.type)
            {
                case NPCID.Zombie:
                    if (Main.rand.NextBool(2))
                    {
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie1").WithPitchVariance(.45f), npc.position);
                                break;

                            case 1:
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie2").WithPitchVariance(.45f), npc.position);
                                break;

                            case 2:
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie3").WithPitchVariance(.45f), npc.position);
                                break;

                            case 3:
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie4").WithPitchVariance(.45f), npc.position);
                                break;

                            default:
                                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie5").WithPitchVariance(.45f), npc.position);
                                break;
                        }
                    }
                    break;
            }

            if (hardDifficulty)
            {
                switch (npc.type)
                {
                    case NPCID.EyeofCthulhu:
                        if (npc.life >= npc.lifeMax / 2)
                        {
                            eyeSpawnTimer++;

                            if (eyeSpawnTimer >= 10)
                            {
                                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.ServantofCthulhu, npc.whoAmI);

                                eyeSpawnTimer = 0;
                            }
                        }

                        if (npc.life <= npc.lifeMax / 2 && !wanderingEyeSpawned)
                        {
                            for (int k = 0; k < 10; k++)
                            {
                                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.WanderingEye, npc.whoAmI);
                            }

                            wanderingEyeSpawned = true;
                        }

                        if (npc.life <= 100)
                        {
                            npc.damage = 10000;
                        }
                        break;

                    case NPCID.BrainofCthulhu:
                        brainRegenTimer++;

                        if (brainRegenTimer >= 15)
                        {
                            npc.life += 5;
                            brainRegenTimer = 0;
                        }

                        if (!extraCreeperSpawn)
                        {
                            for (int j = 0; j < 50; j++)
                            {
                                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.Creeper, npc.whoAmI);
                            }

                            extraCreeperSpawn = true;
                        }
                        break;

                    case NPCID.EaterofWorldsHead:
                        corrupterTimer++;
                        worldFeederTimer++;

                        if (corrupterTimer >= 300)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Corruptor, npc.whoAmI);
                            corrupterTimer = 0;
                        }

                        if (worldFeederTimer >= 600)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 98, npc.whoAmI);
                            worldFeederTimer = 0;
                        }
                        break;

                    case NPCID.QueenBee:
                        stingerShootTimer++;

                        if (stingerShootTimer >= 2)
                        {
                            Projectile.NewProjectile(shootPos1.X + Main.rand.Next(-20, 20), shootPos1.Y + Main.rand.Next(-20, 20), shootVel1.X, shootVel1.Y, ProjectileID.Stinger, npc.damage / 4, 5f);
                            stingerShootTimer = 0;
                        }
                        break;

                    case NPCID.SkeletronHead:
                        boneShootTimer++;

                        if (boneShootTimer >= 45)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Projectile.NewProjectile(shootPos1.X + Main.rand.Next(-20, 20), shootPos1.Y + Main.rand.Next(-20, 20), shootVel1.X, shootVel1.Y, ProjectileID.SkeletonBone, npc.damage / 4, 5f);
                            }

                            boneShootTimer = 0;
                        }
                        break;

                    case NPCID.TheDestroyerBody:
                        destroyerShootTimer++;

                        if (destroyerShootTimer >= 20 && Main.rand.NextBool(3))
                        {
                            Projectile.NewProjectile(shootPos1.X + Main.rand.Next(-200, 200), shootPos1.Y + Main.rand.Next(-200, 200), shootVel1.X, shootVel1.Y, ProjectileID.DeathLaser, npc.damage / 4, 5f);
                            destroyerShootTimer = 0;
                        }
                        break;

                    case NPCID.SkeletronPrime:
                        dungeonEnemySpawnTimer++;

                        if (dungeonEnemySpawnTimer >= 600 + Main.rand.Next(-300, 300))
                        {
                            switch (Main.rand.Next(11))
                            {
                                case 0:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.HellArmoredBones, npc.whoAmI);
                                    break;

                                case 1:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RustyArmoredBonesAxe, npc.whoAmI);
                                    break;

                                case 2:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BoneLee, npc.whoAmI);
                                    break;

                                case 3:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RaggedCaster, npc.whoAmI);
                                    break;

                                case 4:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.TacticalSkeleton, npc.whoAmI);
                                    break;

                                case 5:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SkeletonSniper, npc.whoAmI);
                                    break;

                                case 6:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Necromancer, npc.whoAmI);
                                    break;

                                case 7:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DiabolistRed, npc.whoAmI);
                                    break;

                                case 8:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DiabolistWhite, npc.whoAmI);
                                    break;

                                case 9:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GiantCursedSkull, npc.whoAmI);
                                    break;

                                case 10:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonSpirit, npc.whoAmI);
                                    break;
                            }

                            dungeonEnemySpawnTimer = 0;
                        }

                        if (endlesserMode)
                        {
                            dungeonEnemySpawnTimer++;

                            if (dungeonEnemySpawnTimer >= 600 + Main.rand.Next(-300, 300))
                            {
                                switch (Main.rand.Next(11))
                                {
                                    case 0:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.HellArmoredBones, npc.whoAmI);
                                        break;

                                    case 1:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RustyArmoredBonesAxe, npc.whoAmI);
                                        break;

                                    case 2:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.BoneLee, npc.whoAmI);
                                        break;

                                    case 3:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.RaggedCaster, npc.whoAmI);
                                        break;

                                    case 4:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.TacticalSkeleton, npc.whoAmI);
                                        break;

                                    case 5:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SkeletonSniper, npc.whoAmI);
                                        break;

                                    case 6:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.Necromancer, npc.whoAmI);
                                        break;

                                    case 7:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DiabolistRed, npc.whoAmI);
                                        break;

                                    case 8:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DiabolistWhite, npc.whoAmI);
                                        break;

                                    case 9:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.GiantCursedSkull, npc.whoAmI);
                                        break;

                                    case 10:
                                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonSpirit, npc.whoAmI);
                                        break;
                                }
                            }
                        }
                        break;

                    case NPCID.Spazmatism:
                        npc.position.Y = player.position.Y;
                        break;

                    case NPCID.Retinazer:
                        npc.position.X = player.position.X;
                        break;

                    case NPCID.Plantera:
                        if (player.Distance(npc.Center) > 400)
                        {
                            planteraStatusBool = false;

                            if (planteraDespawnTimer == 0)
                            {
                                Main.NewText("You are too far away from plantera!", 42, 173, 40);
                            }

                            planteraDespawnTimer++;

                            if (planteraDespawnTimer == 60)
                            {
                                Main.NewText("Plantera will despawn in 2 seconds", 42, 173, 40);
                            }

                            if (planteraDespawnTimer == 120)
                            {
                                Main.NewText("Plantera will despawn in 1 seconds", 42, 173, 40);
                            }

                            if (planteraDespawnTimer > 180)
                            {
                                npc.active = false;
                                Main.NewText("Plantera despawned", 42, 173, 40);
                                planteraDespawnTimer = 0;
                            }
                        }
                        else
                        {
                            if (planteraStatusBool)
                            {
                                Main.NewText("You are close enough to plantera!", 42, 173, 40);
                                planteraStatusBool = true;
                            }

                            planteraDespawnTimer = 0;
                        }
                        break;

                    case NPCID.GolemFistLeft:
                        leftFistShootTimer++;

                        if (leftFistShootTimer >= 20)
                        {
                            int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 0, 0, ProjectileID.DeathSickle, npc.damage / 4, 5f);
                            Main.projectile[projectile].hostile = true;
                            Main.projectile[projectile].friendly = false;
                            leftFistShootTimer = 0;
                        }
                        break;

                    case NPCID.GolemFistRight:
                        rightFistShootTimer++;

                        if (rightFistShootTimer >= 20)
                        {
                            int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 0, 0, ProjectileID.DeathSickle, npc.damage / 4, 5f);
                            Main.projectile[projectile].hostile = true;
                            Main.projectile[projectile].friendly = false;
                            rightFistShootTimer = 0;
                        }
                        break;

                    case NPCID.GolemHeadFree:
                        headShootTimer++;

                        if (headShootTimer >= 40 + Main.rand.Next(-20, 20))
                        {
                            int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.DeathSickle, npc.damage / 4, 5f);
                            Main.projectile[projectile].hostile = true;
                            Main.projectile[projectile].friendly = false;
                            headShootTimer = 0;
                        }

                        if (golemLowLife)
                        {
                            headFireballTimer++;

                            if (headFireballTimer >= 90)
                            {
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y, -10, -10, ProjectileID.Fireball, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 10, -10, ProjectileID.Fireball, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y, -10, 10, ProjectileID.Fireball, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 10, 10, ProjectileID.Fireball, npc.damage / 4, 5f);
                                headFireballTimer = 0;
                            }
                        }
                        break;

                    case NPCID.Golem:
                        if (npc.life <= npc.lifeMax / 4)
                        {
                            golemLowLife = true;
                        }

                        bodyLaserTimer++;

                        if (bodyLaserTimer >= 10)
                        {
                            if (npc.life > npc.lifeMax / 2)
                            {
                                Projectile.NewProjectile(shootPos1.X - 10, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X + 10, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                            }
                            else if (npc.life <= npc.lifeMax / 2)
                            {
                                Projectile.NewProjectile(shootPos1.X - 20, shootPos1.Y, 0, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X + 20, shootPos1.Y, 0, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X - 20, shootPos1.Y, 0, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X + 20, shootPos1.Y, 0, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X - 20, shootPos1.Y, -15, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X + 20, shootPos1.Y, -15, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X - 20, shootPos1.Y, 15, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X + 20, shootPos1.Y, 15, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y - 20, -15, 0, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y + 20, -15, 0, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y - 20, 15, 0, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y + 20, 15, 0, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y - 20, 15, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y + 20, 15, -15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y - 20, -15, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                                Projectile.NewProjectile(shootPos1.X, shootPos1.Y + 20, -15, 15, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                            }

                            bodyLaserTimer = 0;
                        }
                        break;

                    case NPCID.CultistBoss:
                        lunarEnemySpawnTimer++;

                        if (ancientDragonSpawned)
                        {
                            NPC.NewNPC((int)npc.Center.X + 100, (int)npc.Center.Y + 100, NPCID.CultistDragonHead, npc.whoAmI);
                            NPC.NewNPC((int)npc.Center.X - 100, (int)npc.Center.Y - 100, NPCID.CultistDragonHead, npc.whoAmI);
                            ancientDragonSpawned = true;
                        }

                        if (lunarEnemySpawnTimer >= 900)
                        {
                            switch (Main.rand.Next(4))
                            {
                                case 0:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarCrawltipedeHead, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarDrakomireRider, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarDrakomire, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarSroller, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarCorite, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarSolenian, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarSpearman, npc.whoAmI);
                                    break;

                                case 1:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexSoldier, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexHornetQueen, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexHornet, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexRifleman, npc.whoAmI);
                                    break;

                                case 2:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaBrain, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaHeadcrab, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaBeast, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaSoldier, npc.whoAmI);
                                    break;

                                case 3:
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.StardustCellBig, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.StardustJellyfishBig, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.StardustSoldier, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.StardustSpiderBig, npc.whoAmI);
                                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.StardustWormHead, npc.whoAmI);
                                    break;
                            }

                            lunarEnemySpawnTimer = 0;
                        }

                        if (endlesserMode)
                        {
                            if (lunarEnemySpawn)
                            {
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarCrawltipedeHead, npc.whoAmI);
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaBrain, npc.whoAmI);
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexHornetQueen, npc.whoAmI);
                                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 407, npc.whoAmI);
                                lunarEnemySpawn = true;
                            }
                        }
                        break;

                    case NPCID.MoonLordCore:
                        eyeballTimer++;

                        if (eyeballTimer >= 180 + Main.rand.Next(-60, 60))
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 0, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 0, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, -10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, -10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 5, 10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -5, 10, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -5, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -5, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 5, ProjectileID.PhantasmalSphere, 100, 5f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 5, ProjectileID.PhantasmalSphere, 100, 5f);
                            eyeballTimer = 0;
                        }

                        handEyeShootTimer++;

                        if (handEyeShootTimer >= 120 + Main.rand.Next(-30, 30))
                        {
                            for (int u = 0; u < 20; u++)
                            {
                                Projectile.NewProjectile(shootPos1.X + Main.rand.Next(-1000, 1000), shootPos1.Y + Main.rand.Next(-1000, 1000), shootVel1.X, shootVel1.Y, ProjectileID.PhantasmalEye, 50, 5f);
                            }
                            handEyeShootTimer = 0;
                        }
                        break;
                }
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (endlesserMode)
            {
                if (Main.rand.NextBool(15))
                {
                    npc.damage *= 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has become enraged", dramatic: true);
                }

                if (Main.rand.NextBool(25))
                {
                    npc.life += npc.lifeMax / 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has regenerated some of its health", dramatic: true);
                }

                if (Main.rand.NextBool(20))
                {
                    npc.defense *= 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has increased their defense", dramatic: true);
                }

                if (npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
                {
                    target.AddBuff(BuffID.Stoned, 60, false);
                }
            }

            if (hardDifficulty)
            {
                if (npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
                {
                    target.AddBuff(BuffID.Slow, 120, false);
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (hardDifficulty)
            {
                switch (npc.type)
                {
                    case NPCID.TheHungryII:
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.TheHungry, npc.whoAmI);
                        break;

                    case NPCID.LeechHead:
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 10, NPCID.LeechHead, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, NPCID.LeechHead, npc.whoAmI);
                        break;

                    case NPCID.EyeofCthulhu:
                        wanderingEyeSpawned = false;
                        break;

                    case NPCID.BrainofCthulhu:
                        extraCreeperSpawn = false;
                        break;

                    case NPCID.SkeletronHead:
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonGuardian, npc.whoAmI);
                        break;

                    case NPCID.CultistBoss:
                        ancientDragonSpawned = false;

                        for (int i = 0; i < Main.maxNPCs; i++)
                        {
                            NPC npc1 = Main.npc[i];
                            if (npc1.active && npc1.type == NPCID.CultistDragonHead)
                            {
                                npc1.active = false;
                            }
                        }

                        if (endlesserMode)
                        {
                            lunarEnemySpawn = false;

                            for (int i = 0; i < Main.maxNPCs; i++)
                            {
                                NPC npc1 = Main.npc[i];
                                if (npc1.active && npc1.type == NPCID.SolarCrawltipedeHead)
                                {
                                    npc1.active = false;
                                }

                                if (npc1.active && npc1.type == NPCID.NebulaBrain)
                                {
                                    npc1.active = false;
                                }

                                if (npc1.active && npc1.type == NPCID.VortexHornetQueen)
                                {
                                    npc1.active = false;
                                }

                                if (npc1.active && npc1.type == NPCID.StardustJellyfishBig)
                                {
                                    npc1.active = false;
                                }
                            }
                        }
                        break;
                }
            }
            if(cursedMedallionSpawn && Main.rand.Next(3) == 0)
            {
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CursedSoul>(), npc.whoAmI);
            }
            if (npc.type == NPCID.MoonLordCore)
            {
                float bossweapon = Main.rand.Next(10);
                if (bossweapon == 10) {
                    Item.NewItem(npc.getRect(), ModContent.ItemType<Commemoration>());
                }
            }
        }

        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if (hardDifficulty)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (Main.rand.NextBool(5))
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), NPCID.SpikedIceSlime, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), NPCID.SpikedJungleSlime, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), NPCID.SlimeSpiked, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), NPCID.CorruptSlime, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), NPCID.Crimslime, npc.whoAmI);
                    }
                }
            }
        }
    }
}
