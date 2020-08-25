using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
{
    public class PaSGlobalRecipe : GlobalRecipe
    {
        public override void OnCraft(Item item, Recipe recipe)
        {
            Player player = Main.LocalPlayer;

            if (player.HasItem(ItemID.Lens) && Main.rand.NextBool(6))
            {
                Main.NewText("u hav lens, u die now >:]", 43, 255, 10);
                for (int i = 0; i < 4; i++)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, NPCID.DemonEye);
                }
            }
        }
    }
}