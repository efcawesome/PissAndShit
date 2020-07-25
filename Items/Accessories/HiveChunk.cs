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
    class HiveChunk : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;

            item.value = Item.buyPrice(gold: 50);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Honey, 10);
        }
    }
}
