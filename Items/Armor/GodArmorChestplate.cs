using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class GodArmorChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Godly Greaves");
            Tooltip.SetDefault("Increases damage by 10%.\nIncreases damage resistance by 30%.");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Red;
            item.defense = 60;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage *= 1.1f;
            player.endurance *= 1.3f;
        }
    }
}
