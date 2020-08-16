using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using PissAndShit.Items.Consumables;

namespace PissAndShit.NPCs
{
    class ConfettiSlime : ModNPC
    {
	private int frameNum = 0;
	private int frameTimer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Confetti Slime");
            Main.npcFrameCount[npc.type] = 2;
        }


        public override void SetDefaults()
        {
            npc.height = 139;
            npc.width = 224;
            npc.damage = 50;
            npc.lifeMax = 5000;
            npc.defense = 10;
            npc.knockBackResist = 0;
            npc.value = 20000f;
            npc.aiStyle = 1;
            animationType = NPCID.GreenSlime;
        }

        public override void AI()
        {
	    Dust.NewDust(npc.position, npc.width, npc.height, 139);
	    Dust.NewDust(npc.position, npc.width, npc.height, 140);
	    Dust.NewDust(npc.position, npc.width, npc.height, 141);
	    Dust.NewDust(npc.position, npc.width, npc.height, 142);
	    frameTimer++;
	}

	public override void FindFrame(int frameHeight)
        {

            if (frameTimer == 6)
            {
                frameNum++;
                frameTimer = 0;
            }

            if (frameNum == 2)
            {
                frameNum = 0;
            }

            npc.frame.Y = frameNum * frameHeight;
	}
	
    }
}
