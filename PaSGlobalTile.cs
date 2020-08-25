using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit
{
    public class PaSGlobalTile : GlobalTile
    {
        public override bool Drop(int a, int b, int type)
        {
            Player player = Main.LocalPlayer;

            if (Main.netMode != NetmodeID.MultiplayerClient && !WorldGen.noTileActions && !WorldGen.gen)
            {
                if (type == TileID.Trees && Main.tile[a, b + 1].type == TileID.Grass)
                {
                    if (Main.rand.NextBool(3))
                    {
                        NPC.NewNPC((int)player.position.X, (int)player.position.Y - 75, ModContent.NPCType<CoochieSnatcher>());
                    }
                }
            }

            return true;
        }
    }
}