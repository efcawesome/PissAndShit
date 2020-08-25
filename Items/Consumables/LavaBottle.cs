using Terraria.ID;
using Terraria.ModLoader;
using PissAndShit.Items.Misc;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables
{
    public class LavaBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottled Lava");
            Tooltip.SetDefault("It burns the tongue");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = BuffID.Burning;
            item.buffTime = 1800;
            item.height = 26;
            item.width = 20;
            item.rare = ItemRarityID.Green;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ObsidianBottle>());
            recipe.needLava = true;
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
