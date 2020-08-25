using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class StoneHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Hat.");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.value = 10000;
            item.rare = ItemRarityID.Pink;
            item.defense = 25;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ItemType<StoneHat>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Stone";
            player.maxRunSpeed = 0;
            player.runAcceleration = 0;
            player.wingTimeMax = 0;
            player.lifeRegen = 100;
            player.allDamage = 0.5f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StoneBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}