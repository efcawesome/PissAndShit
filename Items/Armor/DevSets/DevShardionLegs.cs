using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Legs)]
    public class DevShardionLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shardion's Burning Bolters");
	    Tooltip.SetDefault("'Run awaaaaay!'");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.vanity = true;
            item.rare = -12;
        }
    }
}
