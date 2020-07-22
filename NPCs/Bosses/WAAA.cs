using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs.Bosses
{

	public class WAAA : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wario Appration");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 91;
			npc.height = 83;
			npc.aiStyle = 69;
			npc.damage = 999;
			npc.defense = 999;
			npc.lifeMax = 9999;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 001f;
			npc.knockBackResist = 1f;
			npc.noTileCollide = true;
			npc.knockBackResist = 1f;
		}
	}
}
