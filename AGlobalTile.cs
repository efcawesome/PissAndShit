using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit

{
    public class AGlobalTile : GlobalTile
    {
        public override bool Drop(int a, int b, int type)
        {	
			Player player = Main.LocalPlayer;
            if (Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Trees && Main.tile[a, b + 1].type == TileID.Grass)
                {
					if (Main.rand.Next(3) == 0)
					{
						NPC.NewNPC((int)player.position.X, (int)player.position.Y - 75, ModContent.NPCType<CoochieSnatcher>());
					}
                }
			}
			return base.Drop(a, b, type);
        }

    }

}
