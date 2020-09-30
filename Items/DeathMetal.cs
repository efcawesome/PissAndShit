using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
{
    public class DeathMetal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death Metal");
            Tooltip.SetDefault("'This would make a sweet guitar'");
        }

        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Purple;
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
        }
    }
}