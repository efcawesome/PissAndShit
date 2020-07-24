using PissAndShit.NPCs;
using PissAndShit.Items.Weapons;
using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class BigChungus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Chungus");

        }
        private int beeTimer = 0;
        private int beeType;
        public override void SetDefaults()
        {
            npc.width = 220;
            npc.height = 420;

            npc.boss = true;
            npc.aiStyle = 1;
            aiType = 5;

            npc.npcSlots = 5;

            npc.lifeMax = 2400;
            npc.damage = 22;
            npc.defense = 12;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(gold: 15);

            npc.lavaImmune = false;
            npc.noTileCollide = false;
            npc.noGravity = false;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = MusicID.LunarBoss;

            bossBag = mod.ItemType("BigChungusTreasureBag");
        }
        public override void AI()
        {
            beeTimer++;
            if (beeTimer >= 300)
            {
                beeTimer = 0;
                beeType = Main.rand.Next(2);
                if (!Main.expertMode)
                {
                    if (beeType == 0)
                    {
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        Main.NewText("you are very chungy");
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), mod.NPCType("ChungusMinion"), npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), mod.NPCType("ChungusMinion"), npc.whoAmI);
                    }
                    if (beeType == 1)
                    {
                        Main.NewText("haha bunny go grr grr");
                        Main.NewText("haha bunny go grr grr");
                        Main.NewText("haha bunny go grr grr");
                        Main.NewText("haha bunny go grr grr");
                        Main.NewText("haha bunny go grr grr");
                        Main.NewText("haha bunny go grr grr");

                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);

                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), NPCID.BunnySlimed, npc.whoAmI);


                    }
                }
            }
        }
        public override void NPCLoot()
        {
            int bossWeapon = Main.rand.Next(2);
            if (bossWeapon == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChungusAssaultRifle"));
            }
            if (bossWeapon == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Carrot"));
            }
        }
    }
}
