using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
{
	internal class GlobalRecipes : GlobalRecipe
	{
		public override void OnCraft(Item item, Recipe recipe)
		{
			Player player = Main.LocalPlayer;
			
			bool hasLens = false;
			foreach (var requiredItem in recipe.requiredItem)
			{
				if (requiredItem.stack > 0 && requiredItem.type == ItemID.Lens)
				{
					hasLens = true;
					break;
				}
			}
			
			if (hasLens && Main.rand.NextBool(6))
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
