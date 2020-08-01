using Terraria.ID;
using Terraria.ModLoader;
using PissAndShit.Items.Misc;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables
{
    public class TrueSparklyWater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Sparkly Water");
            Tooltip.SetDefault("Sweet and sour");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = BuffID.VortexDebuff;
            item.buffTime = 600;
            item.height = 36;
            item.width = 28;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SparklyWater>());
            recipe.AddIngredient(ItemType<BrokenHeroBottle>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
