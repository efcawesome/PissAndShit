using PissAndShit.items.weapons;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class Pan : ModItem
	{
		public override void SetStaticDefaults()
		{
			
			Tooltip.SetDefault("From the egg lord");
		}

		public override void SetDefaults()
		{
			item.damage = 22;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 12;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10000);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
