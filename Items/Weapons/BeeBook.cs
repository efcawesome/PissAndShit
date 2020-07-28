using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class BeeBook : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Bee is death");
		}

		public override void SetDefaults()
		{
			item.damage = 3000;
			item.ranged = true;
			item.width = 26;
			item.height = 68;
			item.useTime = 2;
			item.useAnimation = 2;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4.2f;
			item.value = 48000;
			item.rare = ItemRarityID.LightPurple;
			item.mana = 5;
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ProjectileID.Bee;
			item.shootSpeed = 21f;
		}
	}
}