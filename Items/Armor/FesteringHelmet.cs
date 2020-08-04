using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FesteringHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Festering Helmet");
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

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<FesteringBreastPlate>() && legs.type == ItemType<FesteringLeggings>();
        }

        public override void UpdateEquip(Player player)
        {
            player.statDefense += 125;
            player.endurance += 110;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.statLifeMax2 += 500;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SolarFlareHelmet, 1);
            recipe.AddIngredient(ItemID.NebulaHelmet, 1);
            recipe.AddIngredient(ItemID.StardustHelmet, 1);
            recipe.AddIngredient(ItemID.VortexHelmet, 1);
            recipe.AddIngredient(ItemID.LunarBar, 100);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
