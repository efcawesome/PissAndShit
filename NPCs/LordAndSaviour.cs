using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs
{
	public class LordAndSaviour : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A Lord and Savior");
			NPCID.Sets.MustAlwaysDraw[npc.type] = true;
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 44;
			npc.damage = 99999;
			npc.lifeMax = 99999;
			npc.width = 128;
			npc.height = 128;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.dontTakeDamage = true;
		}
		public override bool CheckActive()
		{
			return false;
		}

		public override void AI()
		{
			npc.TargetClosest(true);
		}
	}
}

//[redacted] in piss and shit, what war crimes will he commit
