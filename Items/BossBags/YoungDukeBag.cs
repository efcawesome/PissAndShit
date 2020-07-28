using IL.Terraria.GameContent.UI;
using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
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
            	int wingsDrop = Main.rand.Next(15);
            	player.QuickSpawnItem(ItemID.GoldCoin, 30);
            	player.QuickSpawnItem(ItemID.HealingPotion, Main.rand.Next(5, 10));
        	if(bossWeapon == 0)
		{
			player.QuickSpawnItem(ModContent.ItemType<YoungRazorTyphoon>());
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
			else if(bossWeapon == 4)
		{
			
		}
			
		if(wingsDrop == 0)
		{
			player.QuickSpawnItem(ModContent.ItemType<YoungFishronWings>(), 1);
		}
        }
    }
}
