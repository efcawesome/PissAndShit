using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.IO;

namespace PissAndShit.NPCs.Bosses.BallsOfFlesh
{
	public class JawbrawnCorrupt : ModNPC
    {
        private Player player;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jawbrawn Corrupt");
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.lifeMax = 80000;
            npc.damage = 220;
            npc.defense = 125; // Not specified on wiki
            npc.width = 100;
            npc.height = 100;
            npc.aiStyle = -1;
            aiType = -1;
            npc.knockBackResist = 0f;
            npc.npcSlots = 20f;
            npc.value = Item.sellPrice(gold: 30);
            for (int k = 0; k < npc.buffImmune.Length; k++)
            { // Tell me whats the file name and where it should be (Folder)
                npc.buffImmune[k] = true;
            }
            music = MusicID.Boss2;
            musicPriority = MusicPriority.BossMedium;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
            if (++npc.frameCounter > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
            {
                npc.frame.Y = 0;
                return;
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JawbrawnCorruptGore1"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JawbrawnCorruptGore2"));
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/JawbrawnCorruptGore3"));
            }
        }

        // States (Phases etc...) NO NOT ATTACKS DONT FUCKING USE IT FOR ATTACKS
        public float State
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        // Attacks 
        public float Attack
        {
            get => npc.ai[1];
            set => npc.ai[1] = value;
        }

        // Use this to change attacks etc...
        public float AttackTimer
        {
            get => npc.ai[2];
            set => npc.ai[2] = value;
        }

        public const float FirstPhase = 0f;

        public const float Idle = 0f;
        public const float FlailTongue = 1f;
        public const float CursedFlames = 2f;

        private int shootTimer;
        private int moveTimer;

        public override void AI()
        {
            Target();

            DespawnHandler();

            if (State == FirstPhase)
            {
                if (Attack == Idle)
                {
                    npc.TargetClosest(true);
                    moveTimer++; // The twins dont constantly move so im gonna add a cooldown to moving
                    if (moveTimer >= 60)
                    {
                        npc.velocity = Vector2.Normalize(player.Center - npc.Center) * 8f;

                        moveTimer = 0;
                        npc.netUpdate = true;
                    }

                    AttackTimer++;
                    if (AttackTimer >= 300)
                    {
                        Attack = CursedFlames; // For testing while flail tongue isnt done
                        AttackTimer = 0f;
                        npc.netUpdate = true;
                    }
                }

                // Jawbrawn has a flail-like tounge attack that inflicts Poison on contact(10 seconds)
                else if (Attack == FlailTongue)
                {
                    AttackTimer++;
                    if (AttackTimer >= 300)
                    {
                        Attack = CursedFlames;
                        AttackTimer = 0f;
                        npc.netUpdate = true;
                    }
                }

                // Jawbrawn will also shoot Cursed Flames at the player, In the same way The Twins do.
                else if (Attack == CursedFlames)
                {
                    npc.TargetClosest(true);

                    if (!npc.WithinRange(npc.Center, 20f * 16f)) // If NPC is 20 tiles far move close to the player
                    {
                        npc.velocity = Vector2.Normalize(player.Center - npc.Center) * 12f;
                        npc.netUpdate = true; // Updating position shit
                    }

                    shootTimer++;
                    if (shootTimer >= 60) // A projectile each second
                    {
                        Vector2 speed = Vector2.Normalize(player.Center - npc.Center) * 8f;
                        Projectile.NewProjectile(npc.position, speed, ProjectileID.CursedFlameHostile, npc.damage / 2, 2f);
                        shootTimer = 0;
                        npc.netUpdate = true;
                    }

                    AttackTimer++;
                    if (AttackTimer >= 300)
                    {
                        Attack = Idle;
                        npc.netUpdate = true;
                    }
                }
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                }
                return;
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(shootTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            shootTimer = reader.ReadInt32();
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
    }
}