using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items
{
    public class MoneyHatScrap : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Money Hat Scrap");
            Tooltip.SetDefault("Mmm yes shiny on piece of hat");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Pink;
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
