using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items
{
    public class MoneySleeves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Money Pants");
            Tooltip.SetDefault("Mmm yes shiny on pant");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Pink;
            item.width = 30;
            item.height = 20;
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
