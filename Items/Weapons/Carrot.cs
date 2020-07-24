using PissAndShit.Projectiles;
using PissAndShit.Items.Weapons;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
	public class Carrot : ModItem
	{
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("tastes good, can i eat it?");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.melee = true;
			item.width = 80;
			item.height = 80;
			item.useTime = 52;
			item.useAnimation = 26;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 10003;
			item.rare = 6;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("CarrotBeam");
			item.shootSpeed =13f;
		}

		
	}
}
