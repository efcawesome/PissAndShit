using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class poop : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Smells like poop");
            DisplayName.SetDefault("Festering Great Blade");
        }

        public override void SetDefaults()
        {
            item.damage = 420;
            item.melee = true;
            item.width = 86;
            item.height = 80;
            item.useTime = 1;
            item.useAnimation = 5;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 30;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade, 1);
            recipe.AddIngredient(3063, 1);
            recipe.AddIngredient(ItemID.StarWrath, 1);
            recipe.AddIngredient(ItemID.InfluxWaver, 1);
            recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
            recipe.AddIngredient(ItemID.Seedler, 1);
            recipe.AddIngredient(ItemID.Starfury, 1);
            recipe.AddIngredient(ItemID.BeeKeeper, 1);
            recipe.AddIngredient(ItemID.EnchantedSword, 1);
            recipe.AddIngredient(ItemID.CopperShortsword, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
