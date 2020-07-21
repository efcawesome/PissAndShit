using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{

	public class Head : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Siren Head");
			Main.npcFrameCount[npc.type] = 1;
		}

		public override void SetDefaults()
		{
			npc.width = 188;
			npc.height = 175;
			npc.aiStyle = 38;
			npc.damage = 30;
			npc.defense = 5;
			npc.lifeMax = 1500;
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCDeath59;
			npc.value = 25f;
			npc.knockBackResist = 0.5f;
			npc.scale = 1f;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.SolarEclipse.Chance * 0.05f;

		}
	}
}
