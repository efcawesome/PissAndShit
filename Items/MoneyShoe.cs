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
    public class MoneyShoe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Money Shoe");
            Tooltip.SetDefault("Mmm yes shiny on shoe");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Pink;
            item.width = 12;
            item.height = 12;
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
