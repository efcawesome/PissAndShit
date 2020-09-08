using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
	public class GalileoFury : DaedalusDamageItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Shoots stars from the sky!");
		}
		public override void SafeSetDefaults()
		{
			item.height = 50;
			item.width = 50;
			item.UseSound = SoundID.Item9;
			item.damage = 20;
			item.useTime = 35;
			item.useAnimation = 35;
			item.noMelee = true;
			item.crit = 5;
			item.knockBack = 2;
			item.rare = ItemRarityID.Green;
			item.shootSpeed = 22f;
			item.autoReuse = false;
			item.value = Item.sellPrice(gold: 1, silver: 50);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shoot = ProjectileID.Starfury;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(1);
			for (int index = 0; index < numberProjectiles; ++index)
			{
				Vector2 vector2_1 = new Vector2((float)(player.position.X + player.width * 0.5 + Main.rand.Next(201) * -player.direction + (Main.mouseX + (double)Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));
				vector2_1.X = (float)((vector2_1.X + (double)player.Center.X) / 2.0) + Main.rand.Next(-200, 201);
				vector2_1.Y -= 100 * index;
				float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
				float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if (num13 < 0.0)
				{
					num13 *= -1f;
				}

				if (num13 < 20.0)
				{
					num13 = 20f;
				}

				float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
				float num15 = item.shootSpeed / num14;
				float num16 = num12 * num15;
				float num17 = num13 * num15;
				float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.02f;
				float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
				Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, Main.rand.Next(5));
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBow, 1);
			recipe.AddIngredient(ItemID.SunplateBlock, 15);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TungstenBow, 1);
			recipe.AddIngredient(ItemID.SunplateBlock, 15);
			recipe.AddIngredient(ItemID.FallenStar, 10);
			recipe.AddTile(TileID.SkyMill);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
