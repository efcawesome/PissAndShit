using Microsoft.Xna.Framework;
using PissAndShit.Items.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Exceptions;

namespace PissAndShit.NPCs
{
    public class AGLobalNPC : GlobalNPC
    {
        static int eyeSpawnTimer = 0;
        static bool wanderingEyeSpawned = false;

        static int brainRegenTimer = 0;
        static bool extraCreeperSpawn = false;

        static int corrupterTimer = 0;
        static int worldFeederTimer = 0;

        static int stingerShootTimer = 0;

        static int boneShootTimer = 0;

        static int destroyerShootTimer = 0;

        static int dungeonEnemySpawnTimer = 0;

        static int planteraDespawnTimer = 0;
        static bool planteraStatusBool = false;

        static int leftFistShootTimer = 0;
        static int rightFistShootTimer = 0;
        static int headShootTimer = 0;
        static int headFireballTimer = 0;
        static int bodyLaserTimer = 0;
        static bool golemLowLife = false;

        static bool lunarEnemySpawn = false;

        static int enemyEnrageChance = 0;
        static int enemyRegenerateChance = 0;
        static int enemyDefenseChance = 0;
        public static bool hardDifficulty = PaSWorld.endlessModeSave;
        public override void SetDefaults(NPC npc)
        {
            if (hardDifficulty == true)
            {
                npc.life = npc.lifeMax *= 2;
                npc.damage *= 2;
                if (npc.type == NPCID.TheDestroyerBody)
                {
                    npc.defense = 10000;
                }
                if (npc.type == NPCID.SkeletronPrime)
                {
                    npc.damage = 1000000;
                }
                if (npc.type == NPCID.PrimeCannon || npc.type == NPCID.PrimeSaw || npc.type == NPCID.PrimeVice || npc.type == NPCID.PrimeLaser || npc.type == NPCID.PlanterasTentacle || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
                {
                    npc.immortal = true;
                }
                if(NPC.AnyNPCs(NPCID.CultistBoss))
                {
                    if(npc.type == NPCID.SolarCrawltipedeTail || npc.type == NPCID.NebulaBrain || npc.type == NPCID.VortexHornetQueen || npc.type == NPCID.StardustJellyfishBig) 
                    {
                        npc.immortal = true;
                    }
                }
            }
        }
        public override void AI(NPC npc)
        {
            npc.TargetClosest(true);
            Player player1 = Main.player[npc.target];
            Vector2 targetPositionDifficult1 = npc.HasPlayerTarget ? player1.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            Vector2 shootPos1 = npc.Center;
            float accuracy1 = 5f * (npc.life / npc.lifeMax);
            Vector2 shootVel1 = targetPositionDifficult1 - shootPos1 + new Vector2(Main.rand.NextFloat(-accuracy1, accuracy1), Main.rand.NextFloat(-accuracy1, accuracy1));
            shootVel1.Normalize();
            shootVel1 *= 14.5f;
            if (npc.type == NPCID.Zombie && Main.rand.Next(2) == 0)
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
            if (hardDifficulty == true)
            {
                if (npc.life > npc.lifeMax)
                {
                    npc.life = npc.lifeMax;
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    if (npc.life >= npc.lifeMax / 2)
                    {
                        eyeSpawnTimer++;
                        if (eyeSpawnTimer >= 10)
                        {
                            NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.ServantofCthulhu, npc.whoAmI);
                            eyeSpawnTimer = 0;
                        }
                    }
                    if (npc.life <= npc.lifeMax / 2 && wanderingEyeSpawned == false)
                    {
                        for(int k = 0; k < 10; k++)
                        {
                            NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.WanderingEye, npc.whoAmI);
                        }
                        wanderingEyeSpawned = true;
                    }
                    if (npc.life <= 100)
                    {
                        npc.damage = 10000;
                    }
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    brainRegenTimer++;
                    if (brainRegenTimer >= 15)
                    {
                        npc.life += 5;
                        brainRegenTimer = 0;
                    }
                    if (extraCreeperSpawn == false)
                    {
                        for (int j = 0; j < 50; j++)
                        {
                            NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), NPCID.Creeper, npc.whoAmI);
                        }
                        extraCreeperSpawn = true;
                    }
                }
                if(npc.type == NPCID.EaterofWorldsHead)
                {
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
                }
                if(npc.type == NPCID.QueenBee)
                {
                    stingerShootTimer++;
                    if (stingerShootTimer >= 2)
                    {
                        Projectile.NewProjectile(shootPos1.X + (float)Main.rand.Next(-20, 20), shootPos1.Y + (float)Main.rand.Next(-20, 20), shootVel1.X, shootVel1.Y, ProjectileID.Stinger, npc.damage / 4, 5f);
                        stingerShootTimer = 0;
                    }
                }
                if (npc.type == NPCID.SkeletronHead)
                {
                    boneShootTimer++;
                    if (boneShootTimer >= 45)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Projectile.NewProjectile(shootPos1.X + (float)Main.rand.Next(-20, 20), shootPos1.Y + (float)Main.rand.Next(-20, 20), shootVel1.X, shootVel1.Y, ProjectileID.SkeletonBone, npc.damage / 4, 5f);
                        }
                        boneShootTimer = 0;
                    }
                }
                if(npc.type == NPCID.TheDestroyerBody)
                {
                    destroyerShootTimer++;
                    if(destroyerShootTimer >= 20 && Main.rand.Next(3) == 0)
                    {
                        Projectile.NewProjectile(shootPos1.X + (float)Main.rand.Next(-200, 200), shootPos1.Y + (float)Main.rand.Next(-200, 200), shootVel1.X, shootVel1.Y, ProjectileID.DeathLaser, npc.damage / 4, 5f);
                        destroyerShootTimer = 0;
                    }
                }
                if(npc.type == NPCID.SkeletronPrime)
                {
                    dungeonEnemySpawnTimer++;
                    if(dungeonEnemySpawnTimer >= 600 + Main.rand.Next(-300, 300))
                    {
                        switch(Main.rand.Next(11))
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
                if(npc.type == NPCID.Spazmatism)
                {
                    npc.position.Y = player1.position.Y;
                }
                if(npc.type == NPCID.Retinazer)
                {
                    npc.position.X = player1.position.X;
                }
                if(npc.type == NPCID.Plantera)
                {
                    if(player1.Distance(npc.Center) > 400)
                    {
                        planteraStatusBool = false;
                        if(planteraDespawnTimer == 0)
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
                        if(planteraStatusBool == false)
                        {
                            Main.NewText("You are close enough to plantera!", 42, 173, 40);
                            planteraStatusBool = true;
                        }
                        planteraDespawnTimer = 0;
                    }
                }
                if(npc.type == NPCID.GolemFistLeft)
                {
                    leftFistShootTimer++;
                    if(leftFistShootTimer >= 20)
                    {
                        int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 0, 0, ProjectileID.DeathSickle, npc.damage / 4, 5f);
                        Main.projectile[projectile].hostile = true;
                        Main.projectile[projectile].friendly = false;
                        leftFistShootTimer = 0;
                    }
                }
                if (npc.type == NPCID.GolemFistRight)
                {
                    rightFistShootTimer++;
                    if (rightFistShootTimer >= 20)
                    {
                        int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, 0, 0, ProjectileID.DeathSickle, npc.damage / 4, 5f);
                        Main.projectile[projectile].hostile = true;
                        Main.projectile[projectile].friendly = false;
                        rightFistShootTimer = 0;
                    }
                }
                if(npc.type == NPCID.GolemHeadFree)
                {
                    headShootTimer++;
                    if(headShootTimer >= 40 + Main.rand.Next(-20, 20))
                    {
                        int projectile = Projectile.NewProjectile(shootPos1.X, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.DeathSickle , npc.damage / 4, 5f);
                        Main.projectile[projectile].hostile = true;
                        Main.projectile[projectile].friendly = false;
                        headShootTimer = 0;
                    }
                    if (golemLowLife == true)
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
                }
                if(npc.type == NPCID.Golem)
                {
                    if (npc.life <= npc.lifeMax / 4) golemLowLife = true;
                    bodyLaserTimer++;
                    if (bodyLaserTimer >= 10)
                    {
                        if(npc.life > npc.lifeMax / 2)
                        {
                            Projectile.NewProjectile(shootPos1.X - 10, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                            Projectile.NewProjectile(shootPos1.X + 10, shootPos1.Y, shootVel1.X, shootVel1.Y, ProjectileID.EyeBeam, npc.damage / 4, 5f);
                        }
                        else if(npc.life <= npc.lifeMax/2)
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
                }
                if(npc.type == NPCID.CultistBoss)
                {
                    if(lunarEnemySpawn == false)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.SolarCrawltipedeHead, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.NebulaBrain, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.VortexHornetQueen, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 407, npc.whoAmI);
                        lunarEnemySpawn = true;
                    }
                }
            }
        }

        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (hardDifficulty == true)
            {
                enemyEnrageChance = Main.rand.Next(15);
                if (enemyEnrageChance == 0)
                {
                    npc.damage *= 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has become enraged", dramatic: true);
                }
                enemyRegenerateChance = Main.rand.Next(25);
                if (enemyRegenerateChance == 0)
                {
                    npc.life += npc.lifeMax / 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has regenerated some of its health", dramatic: true);
                }
                enemyDefenseChance = Main.rand.Next(20);
                if (enemyDefenseChance == 0)
                {
                    npc.defense *= 2;
                    CombatText.NewText(npc.Hitbox, Color.OrangeRed, npc.FullName + " has increased their defense", dramatic: true);
                }
            }
            if(hardDifficulty == true)
            {
                if (npc.type == NPCID.Golem || npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
                {
                    target.AddBuff(BuffID.Stoned, 60, false);
                }
            }

        }
        public override void NPCLoot(NPC npc)
        {
            if(hardDifficulty == true)
            {
                if (npc.type == NPCID.TheHungryII)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.TheHungry, npc.whoAmI);
                }
                if (npc.type == NPCID.LeechHead)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 10, NPCID.LeechHead, npc.whoAmI);
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 10, NPCID.LeechHead, npc.whoAmI);
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    wanderingEyeSpawned = false;
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    extraCreeperSpawn = false;
                }
                if(npc.type == NPCID.SkeletronHead)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCID.DungeonGuardian, npc.whoAmI);
                }
                if(npc.type == NPCID.CultistBoss)
                {
                    lunarEnemySpawn = true;
                }
            }
        }
        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if(hardDifficulty == true)
            {
                if (npc.type == NPCID.KingSlime)
                {
                    if (Main.rand.Next(5) == 0)
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
