using PissAndShit.Items.Accessories;
using PissAndShit.Items.Weapons;
using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.BossBags
{
    public class DeathBossBag : ModItem
    {
	public override string Texture => "PissAndShit/Items/BossBags/BoozeshrumeBag"; // placeholder
	
        public override int BossBagNPC => ModContent.NPCType<DeathItself>();

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
	    int rollDevSetDrop = Main.rand.Next(20);
	    int rollDevSet = Main.rand.Next();
            player.QuickSpawnItem(ItemID.PlatinumCoin, Main.rand.Next(5, 12));
            player.QuickSpawnItem(ItemID.SuperHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ModContent.ItemType<Exoultimagigahypersplosionator>(), 1);
            switch((int)bossWeapon) //godslimepog case switching
	    {
		case 0:
		    player.QuickSpawnItem(ModContent.ItemType<BeerBook>(), 1);
		    break;
		case 1:
		    break;
		case 2:
		    break;
		case 3:
		    break;
            }
	    if (rollDevSetDrop == 0)
	    {
		
	    }
        }
    }
}
