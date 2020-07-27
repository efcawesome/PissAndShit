using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items
{
    public class MoneyPants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Money Pants");
            Tooltip.SetDefault("Mmm yes shiny on pant");
        }
        public override void SetDefaults()
        {
            item.rare = 5;
            item.width = 18;
            item.height = 13;
            item.maxStack = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GoldCoin, 50);
            recipe.AddIngredient(ItemType<MoneyBar>(), 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
