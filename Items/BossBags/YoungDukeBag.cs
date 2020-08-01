using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    class YoungDukeBag : ModItem
    {
        public override int BossBagNPC => ModContent.NPCType<YoungDuke>();
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
            int bossWeapon = Main.rand.Next(5);
            player.QuickSpawnItem(ItemID.GoldCoin, 30);
            player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ModContent.ItemType<YoungFishronWings>(), 1);
            if (bossWeapon == 0)
            {
                player.QuickSpawnItem(ModContent.ItemType<YoungRazorTyphoon>());
            }
            if (bossWeapon == 1)
            {
                player.QuickSpawnItem(ModContent.ItemType<YoungBow>());
            }
            if (bossWeapon == 2)
            {
                player.QuickSpawnItem(ModContent.ItemType<youngdukeyoyo>());
            }
            if (bossWeapon == 3)
            {
                player.QuickSpawnItem(ModContent.ItemType<YoungGun>());
            }
        }
    }
}
