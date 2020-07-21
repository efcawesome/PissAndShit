using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit
{
	public class TornJacket : ModItem
	{
	    
	    public override void SetStaticDefaults()
	    {
			Tooltip.SetDefault("Summons the blue-eyes white skeleton"
			+ "\n'You've been busy, huh?'");
	    }
	    
	    public override void SetDefaults()
	    {
		item.width = 24;
		item.height = 24;
		item.maxStack = 99;
		item.consumable = false;
		item.rare = -11;
		item.value = Item.buyPrice(gold: 25);
	    }
	    
	}
}
