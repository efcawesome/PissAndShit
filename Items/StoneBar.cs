using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
{
   public class StoneBar: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone bar");
            Tooltip.SetDefault("bar");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.rare = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
