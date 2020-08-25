using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.Items
{
    public class BigChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Chunk");
            Tooltip.SetDefault("large");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.rare = ItemRarityID.LightPurple;
            item.width = 26;
            item.height = 28;
            item.scale = 10;
        }
    }
}