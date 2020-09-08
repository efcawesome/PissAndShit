using PissAndShit.Items.DaedalusDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ExampleMod.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context == "bossBag" && arg == ItemID.MoonLordBossBag)
			{
				int bossweapon = Main.rand.Next(10);
				if (bossweapon == 0)
				{
					player.QuickSpawnItem(ItemType<Commemoration>());
				}
			}
		}
	}
}
