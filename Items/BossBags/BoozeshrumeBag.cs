using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    class BoozeshrumeBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<boozeshrume>();
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            int bossWeapon = Main.rand.Next(4);
            player.QuickSpawnItem(ItemID.GoldCoin, 60);
            player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ModContent.ItemType<BoozeExpertItem>(), Main.rand.Next(5, 10));
            if (bossWeapon == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<BeerBook>(), 1);
            }
            if (bossWeapon == 1)
            {

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
