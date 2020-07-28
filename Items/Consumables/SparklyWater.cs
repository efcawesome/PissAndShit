using Terraria.ID;
using Terraria.ModLoader;
using PissAndShit.Items.Misc;
using static Terraria.ModLoader.ModContent;


namespace PissAndShit.Items.Consumables
{
    public class SparklyWater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparkly Water");
            Tooltip.SetDefault("Somehow tastes sugary");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = (BuffID.Confused);
            item.buffTime = 600;
            item.height = 26;
            item.width = 20;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<HallowedBottle>());
            recipe.AddIngredient(ItemID.CrystalShard, 5);
            recipe.needWater = true;
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
