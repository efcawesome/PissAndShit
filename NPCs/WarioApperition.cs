using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
	class WarioApperition : ModNPC
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("WarioApperition");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DungeonGuardian];
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DungeonGuardian);
			aiType = NPCID.DungeonGuardian;
			animationType = NPCID.DungeonGuardian;
		}
	}
}
