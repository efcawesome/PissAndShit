using PissAndShit.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    class Hive : ModNPC
    {
        private int beeTimer = 0;
        private int beeType;
        public override void SetDefaults()
        {
            npc.width = 425;
            npc.height = 375;

            npc.boss = true;
            npc.aiStyle = -1;
            aiType = 94;

            npc.npcSlots = 1;

            npc.lifeMax = 10000;
            npc.defense = 10000;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(platinum: 5);

            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.noGravity = true;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CHUNGUS");
            musicPriority = MusicPriority.BossHigh;
            bossBag = mod.ItemType("HiveBag");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.3f);
        }

        public override void AI()
        {
            beeTimer++;
            if (beeTimer >= 5)
            {
                beeTimer = 0;
                beeType = Main.rand.Next(100);
                if (!Main.expertMode)
                {
                    if (beeType == 0)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                    }
                    else if (beeType >= 1 && beeType <= 5)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                    }
                    else if (beeType >= 6 && beeType <= 15)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                    }
                    else if (beeType >= 16)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Bee, npc.whoAmI);
                    }
                }
                if (Main.expertMode)
                {
                    if (beeType == 0)
                    {
                        Main.NewText("Bee Hell Mode Activated");
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                    }
                    else if (beeType >= 1 && beeType <= 5)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.QueenBee, npc.whoAmI);
                    }
                    else if (beeType >= 6 && beeType <= 15)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.MossHornet, npc.whoAmI);
                    }
                    else if (beeType >= 16)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.Hornet, npc.whoAmI);
                    }
                }
            }
        }
        public override void NPCLoot()
        {
            PaSWorld.downedHive = true;
            int bossWeapon = Main.rand.Next(3);
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            if (!Main.expertMode)
            {
                if (bossWeapon == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BeeBasher>());
                }
                if (bossWeapon == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BeeBook>());
                }
                if (bossWeapon == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BeeTime>());
                }
            }
        }
    }
}
