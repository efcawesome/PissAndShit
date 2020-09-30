using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class DeathHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shiny.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.value = 10000;
            item.rare = ItemRarityID.Lime;
            item.defense = 25;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<DeathChestplate>() && legs.type == ItemType<DeathGreaves>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Endless flight time\nAll weapons deal 45% more damage";
            player.allDamage = player.allDamage * 4.5f;
            player.maxRunSpeed += 5;
            player.wingTimeMax = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<DeathMetal>(), 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}