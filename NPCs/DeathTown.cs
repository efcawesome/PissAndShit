using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.NPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class DeathTown : ModNPC
    {
	public override string Texture => "PissAndShit/NPCs/DeathTown";
	
	public override bool Autoload(ref string name)
	{
	    name = "Death Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish";
	    return mod.Properties.Autoload;
	}
	
	public override void SetStaticDefaults()
	{
	    // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
	    DisplayName.SetDefault("Death Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
	    NPCID.Sets.AttackAverageChance[npc.type] = 30;
	}
	
	public override void SetDefaults()
	{
	    npc.townNPC = true;
	    npc.friendly = true;
	    npc.width = 40;
	    npc.height = 46;
	    npc.aiStyle = 7;
	    npc.damage = 10;
	    npc.defense = 15;
	    npc.lifeMax = 250;
	    npc.HitSound = SoundID.NPCHit1;
	    npc.DeathSound = SoundID.NPCDeath1;
	    npc.knockBackResist = 0.5f;
	    animationType = NPCID.Guide;
	}
	
	public override string TownNPCName()
	{
	    switch (WorldGen.genRand.Next(4))
	    {
		case 0:
		    return "Arnie";
		case 1:
		    return "E.F.C. Lame";
		case 2:
		    return "Soundperson";
		case 3:
		    return "Enterium";
		default:
		    return "Fragment-ion";
	    }
	}
	
	public override void FindFrame(int frameHeight)
	{
	    /*npc.frame.Width = 40;
	      if (((int)Main.time / 10) % 2 == 0)
	      {
	      npc.frame.X = 40;
	      }
	      else
	      {
	      npc.frame.X = 0;
	      }*/
	}
	
	public override string GetChat()
	{
	    switch (Main.rand.Next(8))
	    {
		case 0:
		    return "Death and entropy are the only constants of this world, but your fragile form is important, soup?";
		    
		case 1:
		    return "I could really do with some pizza rolls right now...";
		    
		case 2:
		    return "Let me show you how to scratch it! *incomprehensible beatboxing*";
		    
		case 3:  
		    return "What's your favorite color? My favorite colors are blood and gore. what do you mean those are not colors?";

		case 4:  
		    return "Reality is an illusion and the universe is a hologram! Buy gold!";
		    
		case 5:  
		    return "How do I make an egg salad... sandwich? Is that what those are called?";
		    
		case 6:  
		    return "YOU FOOL! YOU’VE FALLEN INTO- oh wait it’s just you.";

		case 7:
		    return "Thanatos can’t do his job properly. I always have to cover for him.";
		    
		default:
		    return "There is only 2 things inevitable in life, Death, and the Tax Collector.";
	    }
	}
    }
}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/
