using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Head)]
    public class DevShardionHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shardion's Smissmas Stacker");
	    Tooltip.SetDefault("'It makes you fearful'");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 23;
            item.rare = -12;
            item.vanity = true;
        }

	public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
	{
	    drawAltHair = true;
	}
    }
}
