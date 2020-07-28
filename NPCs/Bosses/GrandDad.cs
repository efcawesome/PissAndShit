using Microsoft.Xna.Framework;
using PissAndShit.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    class GrandDad : ModNPC
    {
        private int frameNum = 0;
        private bool canTeleport = true;
        private int teleportTimer = 0;
        private bool secondPhase = false;
        private int projectileShoot = 0;
        private int projectileTimer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GRAND DAD");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 122;
            npc.height = 240;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.npcSlots = 5;

            npc.lifeMax = 500000;
            npc.damage = 500;
            npc.defense = 777;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(platinum: 20);

            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.Underground;

            bossBag = mod.ItemType("GrandDadBag");
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
            Vector2 targetPosition = Main.player[npc.target].position;
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            if (canTeleport == true)
            {
                teleportTimer++;
            }
            if (secondPhase == true)
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
                Main.PlaySound(SoundID.Item6);
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
                        Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-20, 20), shootPos.Y - (float)Main.rand.Next(-20, 20), shootVel.X, shootVel.Y, mod.ProjectileType("SevenProj"), npc.damage / 3, 5f);
                    }
                    if (projectileShoot == 1)
                    {
                        //needs wario apparition
                    }
                    if (projectileShoot == 2)
                    {
                        //needs personalized copies
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
            if (targetPosition.X > npc.position.X && secondPhase == false)
            {
                frameNum = 0;
            }
            else if (targetPosition.X < npc.position.X && secondPhase == false)
            {
                frameNum = 1;
            }
            else if (targetPosition.X > npc.position.X && secondPhase == true)
            {
                frameNum = 2;
            }
            else if (targetPosition.X < npc.position.X && secondPhase == true)
            {
                frameNum = 3;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frame.Y = frameNum * frameHeight;
        }

        public override void NPCLoot()
        {
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
            }
        }
    }
}
