using PissAndShit.Items.Misc;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.NPCs
{
    public class AGLobalNPC : GlobalNPC
    {
        public override void AI(NPC npc)
        {
            if (npc.type == NPCID.Zombie && Main.rand.Next(2) == 0)
            {
                switch (Main.rand.Next(4))
                {
                    case 0:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie1").WithPitchVariance(.45f), npc.position);
                        break;
                    case 1:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie2").WithPitchVariance(.45f), npc.position);
                        break;
                    case 2:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie3").WithPitchVariance(.45f), npc.position);
                        break;
                    case 3:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie4").WithPitchVariance(.45f), npc.position);
                        break;

                    default:
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Zombie5").WithPitchVariance(.45f), npc.position);
                        break;
                }
            }
        }
    }
}
