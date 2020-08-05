using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    class GodSlimeTreasureBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<GodSlime>();

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("<right> to open");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override void OpenBossBag(Player player)
        {
            int bossWeapon = Main.rand.Next(2);
            player.QuickSpawnItem(ItemID.PlatinumCoin, 5);
            player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.Gel, 999);
            player.QuickSpawnItem(ModContent.ItemType<GodSlimesGel>(), 1);
            if (bossWeapon == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<GodlyCross>(), 1);
            }
            if (bossWeapon == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<HolyShower>(), 1);
            }
        }
    }
}
