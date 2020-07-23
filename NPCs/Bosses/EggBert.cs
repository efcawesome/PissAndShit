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
    public class EggBert : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Egg Bert");

        }
        private int eggTimer = 0;
        private int eggType;
        public override void SetDefaults()
        {
            npc.width = 160;
            npc.height = 200;

            npc.boss = true;
            npc.aiStyle = 41;
            aiType = 41;

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

            bossBag = mod.ItemType("EggBertTreasureBag");
        }
        public override void AI()
        {
            eggTimer++;
            if (eggTimer >= 480)
            {
                eggTimer = 0;
                eggType = Main.rand.Next(1);
                if (!Main.expertMode)
                {
                    if (eggType == 0)
                    {
                        NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-200, 200), (int)npc.Center.Y + Main.rand.Next(-200, 200), mod.NPCType("Eggling"), npc.whoAmI);
                    }
                    if (eggType == 1)
                    {
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
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EggK47"));
                }
                if (bossWeapon == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Pan"));
                }
        }
    }
}
