using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons
{
    public class StonePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone destruction tool");
            Tooltip.SetDefault("Made of stone");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = ItemRarityID.Green;
            item.damage = 10;
            item.crit = 4;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.melee = true;
            item.pick = 50;
            item.axe = 75;
            item.hammer = 75;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StoneBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}