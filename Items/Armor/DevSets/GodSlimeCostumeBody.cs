using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Body)]
    public class GodSlimeCostumeBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slime Chain Mail");
            Tooltip.SetDefault("The holy slime is with you\nPart of efcawesome's dev set");
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