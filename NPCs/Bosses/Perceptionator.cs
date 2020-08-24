using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    class Perceptionator : ModNPC
    {
        private bool overhead = false;
        private int regularShootTimer = 0;
        public override void SetDefaults()
        {
            npc.width = 106;
            npc.height = 200;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.lifeMax = 75000;
            npc.damage = 160;
            npc.defense = 60;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit12;
            npc.DeathSound = SoundID.NPCDeath12;

            npc.value = Item.buyPrice(platinum: 2);

            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/BallsOfFlesh");
            musicPriority = MusicPriority.BossHigh;
        }
        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 targetPosition = Main.player[npc.target].position;
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.netAlways = true;
            Vector2 shootPos = npc.Center;
            float accuracy = 5f * (npc.life / npc.lifeMax);
            Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
            shootVel.Normalize();
            shootVel *= 14.5f;
            if (player.position.Y - 150 < npc.position.Y && npc.velocity.Y > -12)
            {
                npc.velocity.Y -= 0.2f;
                if(npc.velocity.Y > 0)
                {
                    npc.velocity.Y = 0;
                }
            }
            if(player.position.Y - 400 > npc.position.Y && npc.velocity.Y < 12)
            {
                npc.velocity.Y += 0.2f;
                if(npc.velocity.Y < 0)
                {
                    npc.velocity.Y = 0;
                }
            }
            if(player.position.Y < npc.position.Y && player.position.Y - 400 > npc.position.Y)
            {
                overhead = false;
            }
            else
            {
                overhead = true;
            }
            if(overhead == true)
            {
                if (player.position.X > npc.position.X && npc.velocity.X < 14)
                {
                    npc.velocity.X += 0.3f;
                }
                if (player.position.X < npc.position.X && npc.velocity.X > -14)
                {
                    npc.velocity.X -= 0.3f;
                }
                if (player.position.X < npc.position.X + 400)
                {
                    npc.velocity.X -= 0.2f;
                }
                if (player.position.X > npc.position.X - 400)
                {
                    npc.velocity.X += 0.2f;
                }
            }
            regularShootTimer++;
            if(regularShootTimer >= 120)
            {
                for (int i = 0; i <= 45; i++)
                {
                    switch(i)
                    {
                        case 15:
                            Projectile.NewProjectile(shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, ModContent.ProjectileType<PerceptionatorLaser>(), 100, 5f);
                            break;
                        case 30:
                            Projectile.NewProjectile(shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, ModContent.ProjectileType<PerceptionatorLaser>(), 100, 5f);
                            break;
                        case 45:
                            Projectile.NewProjectile(shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, ModContent.ProjectileType<PerceptionatorLaser>(), 100, 5f);
                            regularShootTimer = 0;
                            break;
                    }
                }
            }
            Vector2 vectoridk = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
            float playerX = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vectoridk.X;
            float playerY = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vectoridk.Y;
            if (playerX > 0f)
            {
                npc.spriteDirection = player.direction;
                npc.rotation = (float)Math.Atan2(playerX, -playerY) + 3.14f;
            }
            if (playerX < 0f)
            {
                npc.spriteDirection = -player.direction;
                npc.rotation = (float)Math.Atan2(playerX, -playerY) + -3.14f;

            }
            if (player.dead || !player.active || Main.dayTime)
            {
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                }
                npc.velocity.X = 0;
                npc.velocity.Y = 0;
                npc.velocity.Y -= 0.2f;
            }
        }
    }
}
