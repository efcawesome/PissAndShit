using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class DeathGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shiny.");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.value = 10000;
            item.rare = ItemRarityID.Lime;
            item.defense = 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DeathChestplate>() && legs.type == ItemType<DeathGreaves>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<DeathMetal>(), 35);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}