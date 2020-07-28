using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class poop : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Smells like poop");
			DisplayName.SetDefault("Festering Great Blade");
		}

		public override void SetDefaults() 
		{
			item.damage = 420;
			item.melee = true;
			item.width = 86;
			item.height = 80;
			item.useTime = 1;
			item.useAnimation = 5;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 30;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
	}
}
