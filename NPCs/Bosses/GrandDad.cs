using Microsoft.Xna.Framework;
using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class GrandDad : ModNPC
    {
        private bool canTeleport = true;
        private int teleportTimer = 0;
        private bool secondPhase = false;
        private int projectileShoot = 0;
        private int projectileTimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GRAND DAD");
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults()
        {
            npc.width = 122;
            npc.height = 181;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.npcSlots = 5;

            npc.lifeMax = 7777777;
            npc.damage = 500;
            npc.defense = 777;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(platinum: 20);

            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/GRANDDAD");
            musicPriority = MusicPriority.BossHigh;

            bossBag = ModContent.ItemType<GrandDadBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.3f);
        }

        public override void AI()
        {
            Player player = Main.player[npc.target];
            npc.TargetClosest(true);
            npc.direction = npc.spriteDirection = npc.Center.X < player.Center.X ? -1 : 1;
            Vector2 targetPosition = Main.player[npc.target].position;
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            if (canTeleport)
            {
                teleportTimer++;
            }
            if (secondPhase)
            {
                projectileTimer++;
            }
            if (npc.life <= npc.lifeMax / 2)
            {
                secondPhase = true;
            }
            if (teleportTimer >= 30)
            {
                npc.position.X = targetPosition.X + Main.rand.Next(-500, 500);
                npc.position.Y = targetPosition.Y + Main.rand.Next(-500, 500);
                teleportTimer = 0;
            }
            if (projectileTimer >= 180)
            {
                Vector2 shootPos = npc.Center;
                float accuracy = 5f * (npc.life / npc.lifeMax);
                Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                shootVel.Normalize();
                shootVel *= 14.5f;
                projectileShoot = Main.rand.Next(3);
                for (int i = 0; i < (Main.expertMode ? 2 : 1); i++)
                {
                    if (projectileShoot == 0)
                    {
                        Projectile.NewProjectile(shootPos.X + -100 * npc.direction + Main.rand.Next(-20, 20), shootPos.Y - Main.rand.Next(-20, 20), shootVel.X, shootVel.Y, ModContent.ProjectileType<SevenProj>(), npc.damage / 3, 5f);
                    }
                    if (projectileShoot == 1)
                    {
                        //needs wario apparition
                    }
                    if (projectileShoot == 2)
                    {
                        Projectile.NewProjectile(shootPos.X + -100 * npc.direction + Main.rand.Next(-20, 20), shootPos.Y - Main.rand.Next(-20, 20), shootVel.X, shootVel.Y, ModContent.ProjectileType<GrandDadBrian>(), npc.damage / 2, 5f);
                    }
                }
                projectileTimer = 0;
            }
            if (player.dead)
            {
                canTeleport = false;
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 5)
                {
                    npc.timeLeft = 5;
                    return;
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            /*if (secondPhase)
            {
                if (++npc.frameCounter > 15)
                {
                    npc.frameCounter = 6;
                    npc.frame.Y += frameHeight;
                    if (npc.frame.Y >= 15 * frameHeight)
                    {
                        npc.frame.Y = 6;
                    }
                }
            }
            else {
                if (++npc.frameCounter > 5)
                {
                    npc.frameCounter = 0;
                    npc.frame.Y += frameHeight;
                    if (npc.frame.Y >= 5 * frameHeight)
                    {
                        npc.frame.Y = 0;
                    }
                }
            } */
            npc.frameCounter += 1.0;
            if (npc.frameCounter < 5.0)
            {
                npc.frame.Y = 0;
                if (secondPhase)
                {
                    npc.frame.Y += frameHeight * 5;
                }
            }
            else if (npc.frameCounter < 10.0)
            {
                npc.frame.Y = frameHeight;
                if (secondPhase)
                {
                    npc.frame.Y += frameHeight * 5;
                }
            }
            else if (npc.frameCounter < 15.0)
            {
                npc.frame.Y = frameHeight * 2;
                if (secondPhase)
                {
                    npc.frame.Y += frameHeight * 5;
                }
            }
            else if (npc.frameCounter < 20.0)
            {
                npc.frame.Y = frameHeight * 3;
                if (secondPhase)
                {
                    npc.frame.Y += frameHeight * 5;
                }
            }
            else if (npc.frameCounter < 25.0)
            {
                npc.frame.Y = frameHeight * 4;
                if (secondPhase)
                {
                    npc.frame.Y += frameHeight * 5;
                }
            }
            /*else if (npc.frameCounter < 42.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 9;
            }*/
            else if (npc.frameCounter < 30.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 10;
            }
            else if (npc.frameCounter < 35.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 11;
            }
            else if (npc.frameCounter < 40.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 12;
            }
            else if (npc.frameCounter < 45.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 13;
            }
            else if (npc.frameCounter < 50.0 && secondPhase)
            {
                npc.frame.Y = frameHeight * 14;
            }
            else
            {
                npc.frameCounter = 0.0;
                npc.frame.Y = 0;
            }
        }

        public override void NPCLoot()
        {
            PaSWorld.downedGrandDad = true;
            int bossWeapon = Main.rand.Next(4);
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (bossWeapon == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<SevenShortsword>());
                }
                if (bossWeapon == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DaedalusSevenbow>());
                }
            }
        }
    }
}