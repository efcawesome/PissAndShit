using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
	class YoungDuke : ModNPC
	{
		public override string Texture => "Terraria/NPC_" + NPCID.DukeFishron;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Young Duke");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DukeFishron];
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DukeFishron);
			aiType = NPCID.DukeFishron;
			animationType = NPCID.DukeFishron;
		}
	}
}
