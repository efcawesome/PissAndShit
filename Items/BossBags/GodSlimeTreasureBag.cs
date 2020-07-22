using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    class GodSlimeTreasureBag : ModItem
    {
        int bossWeapon = Main.rand.Next(4);
        public override int BossBagNPC => mod.NPCType("GodSlime");
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
            player.QuickSpawnItem(ItemID.PlatinumCoin, 5);
            player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.Gel, 999);
            player.QuickSpawnItem(mod.ItemType("GodSlimesGel"), 1);
            if(bossWeapon == 0)
            {
                player.QuickSpawnItem(mod.ItemType("GodlyCross"), 1);
            }
            else if(bossWeapon == 1)
            {

            }
            else if(bossWeapon == 2)
            {

            }
            else if(bossWeapon == 3)
            {

            }
        }
    }
}
