using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.Items.Misc
{
    public class YoungDukeMusicBoxTwo : ModItem
    {
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.MusicBoxes.YoungDukeMusicBoxTwo>();
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.LightRed;
            item.value = 100000;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Young Duke Phase 2)");
        }
    }
}