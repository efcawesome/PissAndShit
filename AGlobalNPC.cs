using Microsoft.Xna.Framework;
using PissAndShit.Items.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        static int enemyEnrageChance = 0;
        static int enemyRegenerateChance = 0;
        static int enemyDefenseChance = 0;
        public static bool hardDifficulty = false;
        public override void SetDefaults(NPC npc)
        {
            if (hardDifficulty == true)
            {
                npc.lifeMax *= 10;
                npc.life *= 10;
                npc.damage *= 4;
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
