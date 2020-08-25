using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace PissAndShit.Items.Weapons
{
    public class BiggerSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bigger Sword");
            Tooltip.SetDefault("L a r g e r");
        }
        public override void SetDefaults()
        {
            item.width = 150;
            item.height = 150;
            item.rare = 6;
            item.damage = 75;
            item.crit = 50;
            item.useStyle = 1;
            item.UseSound = SoundID.NPCHit41;
            item.useTime = 15;
            item.useAnimation = 15;
            item.autoReuse = true;
            item.melee = true;
            item.scale = 8;
            item.knockBack = 100000000000000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BigSword>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
