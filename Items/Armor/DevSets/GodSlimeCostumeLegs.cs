using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Legs)]
    public class GodSlimeCostumeLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slime Pants");
            Tooltip.SetDefault("May the slimes guide your way\nPart of efcawesome's dev set");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 24;
            item.vanity = true;
            item.rare = ItemRarityID.Red;
            item.maxStack = 1;
        }
    }
}