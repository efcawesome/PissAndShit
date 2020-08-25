using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

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
            item.rare = ItemRarityID.Purple;
            item.maxStack = 999;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
            item.value = Item.buyPrice(1);
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<DeathItself>());
            return true;
        }
    }
}