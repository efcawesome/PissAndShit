using PissAndShit.Items.BossBags;
using PissAndShit.Items.Weapons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
    [AutoloadBossHead]
    public class GodSlime : ModNPC
    {
        private int frameNum = 0;
        private int frameTimer = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slime");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 390;
            npc.height = 220;

            npc.boss = true;
            npc.aiStyle = 1;
            aiType = 1;

            npc.npcSlots = 5;

            npc.lifeMax = 10000000;
            npc.damage = 400;
            npc.defense = 175;
            npc.knockBackResist = 0f;

            npc.value = Item.buyPrice(platinum: 15);

            npc.lavaImmune = false;
            npc.noTileCollide = false;
            npc.noGravity = false;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/heavenly_bullshit");
            musicPriority = MusicPriority.BossHigh;

            bossBag = ModContent.ItemType<GodSlimeTreasureBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale);
            npc.damage = (int)(npc.damage * 1.3f);
        }

        public override void NPCLoot()
        {
            PaSWorld.downedGodSlime = true;
            int bossWeapon = Main.rand.Next(4);
            if (Main.expertMode)
            {
                npc.DropBossBags();
                for (int i = 0; i < 49; i++)
                {
                    NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), ModContent.NPCType<GodSlimeWorshipper>(), npc.whoAmI);
                }
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.Gel, 999);
                if (bossWeapon == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<GodlyCross>());
                }

                for (int i = 0; i < 61;  i++)
                {
                    NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-1000, 1000), (int)npc.Center.Y + Main.rand.Next(-1000, 1000), ModContent.NPCType<GodSlimeWorshipper>(), npc.whoAmI);
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        public override void AI()
        {
            frameTimer++;
        }

        public override void FindFrame(int frameHeight)
        {
            if (frameTimer == 6)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 4)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.expertMode)
            {
                if (Main.rand.NextBool(5))
                {
                    NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-100, 100), (int)npc.Center.Y + Main.rand.Next(-100, 100), ModContent.NPCType<GodSlimeWorshipper>(), npc.whoAmI);
                }
            }
        }
    }
}