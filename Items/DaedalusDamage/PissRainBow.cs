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
	public class PissRainBow :  DaedalusDamageItem
	{
		public override string Texture => "Terraria/Item_3029"; ///Placeholder, delete when sprite gets
		public override void SetStaticDefaults()
		{

			Tooltip.SetDefault("IMMA GO MAKE IT RAIN PISS FROM THE SKY!");
		}
		public override void SafeSetDefaults()
		{
			item.CloneDefaults(ItemID.DaedalusStormbow);
			item.UseSound = SoundID.Item13;
			item.damage = 13;
			item.useTime = 15;
			item.useAnimation = 17;
			item.noMelee = true;
			item.crit = 5;
			item.knockBack = 2;
			item.rare = ItemRarityID.LightRed;
			item.shootSpeed = 18f;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 1, silver: 50);
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 30;
			item.height = 50;
			item.shoot = ProjectileID.GoldenShowerFriendly;
		}
		
		public override Color? GetAlpha(Color lightColor) ///This part needs to be deleted when sprite is submitted
		{
			return new Color(189, 32, 32, 255) * (1f - (float)item.alpha / 255f);
		} ///Up to here
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 10 + Main.rand.Next(2);
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
				float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.05f;
				float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.05f;
				Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, Main.rand.Next(10));
			}
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddIngredient(ItemID.TendonBow, 1);
			recipe.AddIngredient(ItemID.Ichor, 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
