using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Body)]
    public class DevShardionSuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shardion's Scorching Suit");
	    Tooltip.SetDefault("'Imagine having power over Death while wearing this'");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 18;
            item.vanity = true;
            item.rare = -12;
        }
    }
}
