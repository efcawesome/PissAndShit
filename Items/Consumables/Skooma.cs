using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables
{
	public class Skooma : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skooma");
			Tooltip.SetDefault("use at own risk"
				+ "\nApplies the Skooma buff for a short time.");
		}

		public override void SetDefaults()
		{
			item.width = 58;
			item.height = 79;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 12;
			item.useTime = 12;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(silver: 15);
		}
		
		public override bool UseItem(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.Skooma>(), 1080, true);
			return true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Mushroom, 2);
			recipe.AddIngredient(ItemID.MudBlock, 5);
			recipe.AddIngredient(ItemID.CopperCoin, 8);			
			recipe.AddIngredient(ItemID.Bottle);			
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
