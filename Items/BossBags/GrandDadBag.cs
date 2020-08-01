using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    class GrandDadBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<GrandDad>();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            int bossWeapon = Main.rand.Next(4);
            player.QuickSpawnItem(ItemID.PlatinumCoin, 50);
            player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(10, 20));
            if (bossWeapon == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<SevenShortsword>(), 1);
            }
            if (bossWeapon == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<DaedalusSevenbow>(), 1);
            }
            if (bossWeapon == 2)
            {

            }
            if (bossWeapon == 3)
            {

            }
        }
    }
}
