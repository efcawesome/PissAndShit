using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FesteringLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festering Leggings");
            Tooltip.SetDefault("it smells like poop."
                + "\nGives a ton of DR and defense'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = ItemRarityID.Purple;
            item.defense = 60;
        }

        public override void UpdateEquip(Player player)
        {
            player.statDefense += 135;
            player.endurance += 110;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SolarFlareLeggings, 1);
            recipe.AddIngredient(ItemID.NebulaLeggings, 1);
            recipe.AddIngredient(ItemID.StardustLeggings, 1);
            recipe.AddIngredient(ItemID.VortexLeggings, 1);
            recipe.AddIngredient(ItemID.LunarBar, 100);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}