using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs
{
	internal class Sanswormhead : ModNPC
	{
		public static int health = 0;
		public bool flies = true;
		public float speed = 60f;
		public float turnSpeed = 30f;
		public int minLength = 20;
		public int maxLength = 20;
		bool TailSpawned = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater Of Sins");
		}


		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = 6;
			npc.damage = 7;
			npc.defense = 2;
			npc.lifeMax = 25000;
			npc.width = 50;
			npc.height = 50;
			npc.lavaImmune = true;
			npc.value = Item.buyPrice(0, 1, 75, 0);
			npc.boss = true;
		}
		public override bool PreAI()
		{
			if (Main.netMode != 1)
			{
				
				if (npc.ai[0] == 0)
				{
					
					npc.realLife = npc.whoAmI;
					
					int latestNPC = npc.whoAmI;

					
					for (int i = 0; i < maxLength; ++i)
					{
						
						latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Sanswormbody"), npc.whoAmI, 0, latestNPC);
						Main.npc[(int)latestNPC].realLife = npc.whoAmI;
						Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
					}
					
					latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Sanswormtail"), npc.whoAmI, 0, latestNPC);
					Main.npc[(int)latestNPC].realLife = npc.whoAmI;
					Main.npc[(int)latestNPC].ai[3] = npc.whoAmI;
					TailSpawned = true;

					npc.ai[0] = 1;
					npc.netUpdate = true;
				}
			}
			return true;
		}

		internal class Sanswormbody : ModNPC
		{
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Eater Of Sins");
			}
			public override void SetDefaults()
			{
				npc.CloneDefaults(NPCID.DiggerBody);
				npc.aiStyle = 6;
				npc.damage = 7;
				npc.defense = 2;
				npc.width = 50;
				npc.height = 50;
				npc.lavaImmune = true;
				npc.boss = true;

			}
		}

		internal class Sanswormtail : ModNPC
		{
			public override void SetStaticDefaults()
			{
				DisplayName.SetDefault("Eater Of Sins");
			}
			public override void SetDefaults()
			{
				npc.CloneDefaults(NPCID.DiggerTail);
				npc.aiStyle = 6;
				npc.damage = 7;
				npc.defense = 2;
				npc.width = 50;
				npc.height = 50;
				npc.lavaImmune = true;
				npc.boss = true;
			}
		}
	}
}