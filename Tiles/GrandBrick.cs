using Microsoft.Xna.Framework;
using PissAndShit.Items.Placeables;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Tiles
{
	public class GrandBrick : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;;
			Main.tileBrick[Type] = true;
			dustType = DustID.BlueCrystalShard;
			drop = ModContent.ItemType<GrandBrickItem>();
			AddMapEntry(new Color(140, 184, 255));
			// Set other values here
		}
	}
}