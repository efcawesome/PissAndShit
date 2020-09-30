using PissAndShit.Items.Armor.DevSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit
{
    class PaSGlobalItem : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if(Main.rand.NextBool(15) && Main.hardMode)
            {
                int devSetType = Main.rand.Next(3);
                switch(devSetType)
                {
                    case 0:
                        player.QuickSpawnItem(ItemType<GodSlimeCostumeHead>(), 1);
                        player.QuickSpawnItem(ItemType<GodSlimeCostumeBody>(), 1);
                        player.QuickSpawnItem(ItemType<GodSlimeCostumeLegs>(), 1);
                        player.QuickSpawnItem(ItemType<FlyingCross>(), 1);
                        break;
                    case 1:
                        player.QuickSpawnItem(ItemType<DevShardionHat>(), 1);
                        player.QuickSpawnItem(ItemType<DevShardionSuit>(), 1);
                        player.QuickSpawnItem(ItemType<DevShardionLegs>(), 1);
                        break;
                    case 2:
                        player.QuickSpawnItem(ItemType<ExitiumHead>(), 1);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
