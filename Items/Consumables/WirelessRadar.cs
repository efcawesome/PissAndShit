using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace PissAndShit.Items.Consumables
{
    public class WirelessRadar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wireless Radar");
            Tooltip.SetDefault("'Look, you're on it! ...that could be bad.'\nDeath Himself, God of Universes, Extinguisher of Souls, Obliterator of the Foolish");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 11;
            item.maxStack = 999;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = true;
            item.value = Item.buyPrice(1);
        }

        public override bool UseItem(Player player)
        {
	    NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("DeathItself"));
            return true;
        }
    }
}
