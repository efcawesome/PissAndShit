using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    class BadTimeMedallion : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;

            item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.statLife > player.statLifeMax/4)
            {
                player.allDamageMult = 1.15f;
            }
            else if(player.statLife <= player.statLifeMax/4)
            {
                player.allDamageMult = 1.3f;
            }
        }
    }
}
