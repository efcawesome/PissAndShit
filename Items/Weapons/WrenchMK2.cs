using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class WrenchMK2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wrench MK2");
		}
		
		public override void SetDefaults()
		{
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = false;
			item.width = 30;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.damage = 30;
			item.knockBack = 2f;
			item.value = Item.sellPrice(silver: 80);
			item.rare = 4; // Not on VS so rip intelisense
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
		}
	}
}