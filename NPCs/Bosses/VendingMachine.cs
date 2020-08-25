using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    public class VendingMachine : ModNPC
    {
        private int spawnTimer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vending Machine");
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.lavaImmune = true;
            npc.width = 544;
            npc.height = 813;
            npc.damage = 40;
            npc.defense = 10;
            npc.lifeMax = 4000;
            npc.knockBackResist = 0f;
            music = MusicID.Boss2;
            musicPriority = MusicPriority.BossMedium;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int k = 0; k < 50; k++)
            {
                Dust.NewDust(npc.position, 0, 0, DustID.t_SteampunkMetal, Main.rand.Next(-4, 4), -4);
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(spawnTimer);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            spawnTimer = reader.ReadInt32();
        }

        public override void AI()
        {
            // npc.ai[value] usages
            // 0 for States (Phases and Stuff)
            // 1 for Attacks
            // 2 for Attack Timers
            // 3 n/a

            if (npc.ai[0] == 0f)
            {
                // Cooldown
                if (npc.ai[1] == 0f)
                {
                    // Falling faster than usual since gravity
                    npc.velocity.Y = 4f;
                    npc.dontTakeDamage = false;

                    spawnTimer++;
                    if (spawnTimer >= 10 * 60) // 10 seconds
                    {
                        npc.ai[1] = 1f;
                    }
                }
                else if (npc.ai[1] == 1f)
                {
                    npc.dontTakeDamage = true;
                    int npcToSpawn = 0;
                    float ySpawnOffset = npc.position.Y += -20f * 16f;

                    switch (Main.rand.Next(1, 5))
                    {
                        case 1:
                            npcToSpawn = NPCID.KingSlime;
                            break;

                        case 2:
                            npcToSpawn = NPCID.EyeofCthulhu;
                            break;

                        case 3:
                            npcToSpawn = NPCID.QueenBee;
                            break;

                        case 4:
                            npcToSpawn = NPCID.SkeletronHead;
                            break;
                    }

                    int bossSpawned = NPC.NewNPC((int)npc.position.X, (int)ySpawnOffset, npcToSpawn);
                    if (!Main.npc[bossSpawned].active)
                    {
                        npc.ai[1] = 0f;
                    }
                    return;
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            PaSWorld.downedVendingMachine = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
            }
        }
    }
}