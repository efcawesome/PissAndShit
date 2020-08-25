using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    class PossessedSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Sometimes there's only one way out");
        }
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 52;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }
        public override bool UseItem(Player player)
        {
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was bad"), 10000, 1, false);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddIngredient(ItemID.GoldCoin, 5);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe1 = new ModRecipe(mod);
            recipe1.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe1.AddIngredient(ItemID.RottenChunk, 5);
            recipe1.AddIngredient(ItemID.GoldCoin, 5);
            recipe1.AddTile(TileID.DemonAltar);
            recipe1.SetResult(this);
            recipe1.AddRecipe();
        }
    }
}
