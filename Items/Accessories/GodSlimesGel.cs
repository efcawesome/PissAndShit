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
    class GodSlimesGel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("God Slime's Gel");
            Tooltip.SetDefault("Makes you jump H I G H");
        }
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
            Player.jumpHeight += 400;
            Player.jumpSpeed += 50;
            player.noFallDmg = true;
        }
    }
}
