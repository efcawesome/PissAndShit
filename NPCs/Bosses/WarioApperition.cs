using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{
	class WarioApparition : ModNPC
	{


		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wario Apparition");
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
