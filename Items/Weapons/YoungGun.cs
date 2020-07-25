using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace PissAndShit.Items.Weapons
{
	public class YoungGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cyclone");
			Tooltip.SetDefault("This gun embodies the speed of the young duke");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(2624);
			item.damage = 5;
			item.ranged = true;
			item.width = 44;
			item.height = 32;
			item.useTime = 2;
			item.useAnimation = 2;
			item.UseSound = SoundID.Item11;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.value = 23000;
			item.rare = 2;
			item.autoReuse = true;
			item.shoot = 10;
			item.useAmmo = AmmoID.Bullet;
			item.shootSpeed = 19f;
		}

		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .38f;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}