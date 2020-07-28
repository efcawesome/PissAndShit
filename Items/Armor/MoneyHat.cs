using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MoneyHat: ModItem
    {
			public override void SetStaticDefaults()
			{
				Tooltip.SetDefault("Shiny.");
			}

			public override void SetDefaults()
			{
				item.width = 24;
				item.height = 22;
				item.value = 10000;
				item.rare = 7;
				item.defense = 25;
			}

			public override bool IsArmorSet(Item head, Item body, Item legs)
			{
				return body.type == ItemType<MoneyChestplate>() && legs.type == ItemType<MoneyGreaves>();
			}

			public override void UpdateArmorSet(Player player)
			{
				player.setBonus = "Dobble damage, more speed and flight time and money powers";
				player.allDamage += 1f;
			    player.maxRunSpeed += 5;
			    player.wingTimeMax += 5; 
				player.goldRing = true;
				player.discount = true;

			}

			public override void AddRecipes()
			{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ItemType<MoneyHatScrap>(), 3);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		
	}
}

