using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class poop : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("death");
			DisplayName.SetDefault("God blade");
		}

		public override void SetDefaults() 
		{
			item.damage = 420;
			item.melee = true;
			item.width = 86;
			item.height = 80;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 3;
			item.knockBack = 30;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse =false;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 999);
			recipe.AddIngredient(ItemID.CopperBrick, 999);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
