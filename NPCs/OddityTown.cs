using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class OddityTown : ModNPC
    {
        public override string Texture => "PissAndShit/NPCs/OddityTown";

        public override bool Autoload(ref string name)
        {
            name = "Oddity";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
            // DisplayName.SetDefault("Example Person");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
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
            switch (WorldGen.genRand.Next(10))
            {
                case 0:
                    return "Pyxen";

                case 1:
                    return "Splat";

                case 2:
                    return "Zap";

                case 3:
                    return "Tigershon";

                case 4:
                    return "Moosic";

                case 5:
                    return "Funta";

                default:
                    return "Trevor";
                case 6:
                    return "Airnold";
                case 7:
                    return "Exatium";
                case 8:
                    return "Hulk Hogan";
                case 9:
                    return "Sharidein";
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
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int oddity = NPC.FindFirstNPC(ModContent.NPCType<OddityTown>());
            if (nurse >= 0 && Main.rand.NextBool(32))
            {
                return "Can you please tell " + Main.npc[nurse].GivenName + " to stop it with all the syringe throwing? It creeps me out.";
            }
            if (guide >= 0 && Main.rand.NextBool(32))
            {
                return Main.npc[nurse].GivenName + " is a coward.";
            }
            if (oddity >= 0 && Main.npc[oddity].GivenName == "Hulk Hogan" && Main.rand.NextBool(32))
            {
                return "I am future president Hulk Hogan and I am commiting tax fraud.";
            }
            if (oddity >= 0 && Main.npc[oddity].GivenName == "Airnold" && Main.rand.NextBool(32))
            {
                return "Golf is the best sport.";
            }
            if (oddity >= 0 && Main.npc[oddity].GivenName == "Tigershon" && Main.rand.NextBool(32))
            {
                return "NO JOJO!";
            }
            if (oddity >= 0 && Main.npc[oddity].GivenName == "Sharidien" && Main.rand.NextBool(32))
            {
                return "I hate golf a lot.";
            }
            switch (Main.rand.Next(32))
            {
                case 0:
                    return "Sometimes I feel like I'm different from everyone else here....... wait I am.";

                case 1:
                    return "What's your favorite color? My favorite colors are blood and gore. what do you mean those are not colors?";
                case 2:
                    return "Mutant? No idea who that is";
                case 3:
                    return "Wow this place looks pretty odd to me, if you know what i mean.";
                case 4:
                    return "Hmmm, Are you sure this isnt one of those \"NPC Prisons\" i've been hearing about?";
                case 5:
                    return "This will be terraria bosses in 2013.";
                case 6:
                    return "Where are the female bosses you ask? You do know females arent real right?";
                case 7:
                    return "All these lunatics running around these days, while I just wanna grill for gods sake";
                case 8:
                    return "I dare you no-hit Hive I dare you kiddo if you do it I'll give you my kidney";
                case 9:
                    return "Will this escapade ever end?";
                case 10:
                    return "My bones ache, my muscles are atrofied, my memories evaporate, why do my creators force me to live this sad existance with a smile, I feel only pain, they force me to say inside jokes, and for what? Their own amusement? \n Anyways what do you want?";
                case 11:
                    return "Wait, This mod doesnt have any fanservice? I dont want to be in this mod anymore, Im done.";
                case 12:
                    return "Im all you need for a Starlight River";
                case 13:
                    return "No, Stop asking me when will i sell my body pillows";
                case 14:
                    return "I’m pretty sure I fall under free use.";
                case 15:
                    return "Embrace piss.";
                case 16:
                    return "!loop";
                case 17:
                    return "Have you heard the Titans Poop Song?";
                case 18:
                    return "If you give me enough money, I’ll release TF3.";
                case 19:
                    return "Vanity coming in 2030. Preorder now for a extra canvas bag and official Oddity brand helmet.";
                case 20:
                    return "tired";
                case 21:
                    return "What's this about an update? Sounds common.";
                case 22:
                    return "The weaker you get, the less stuff I sell. Makes sense, right? Or is it the other way?";
                case 23:
                    return "Do you know what an Ee-arth mod is?";
                case 24:
                    return "It would be pretty cool if I could sell a vanity for myself...";
                case 25:
                    return "Whats a split?";
                case 26:
                    return "Who is this Far-go I keep hearing about?";
                case 27:
                    return "The ocean is a dangerous place, You might even find a duke! Well maybe two. Its complacated";
                case 28:
                    return "Have you seen the boob woman?";
                case 29:
                    return "Adding GX after everything makes it even more difficult than EX.";
                case 30:
                    return "Chungus has got nothing on me!";
                case 31:
                    return "You're lucky your on my side";
                default:
                    return "monkymonkymonkymonky";
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
