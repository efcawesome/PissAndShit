using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class AllSeeingEyes : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("All-Seeing Mechanical Eyes");
            Tooltip.SetDefault("Grants Spelunker, Hunter, and Dangersense effects\nGives obstructed\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 91;
            item.height = 59;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Spelunker, 1, false);
            player.AddBuff(BuffID.Dangersense, 1, false);
            player.AddBuff(BuffID.Hunter, 1, false);
            player.AddBuff(BuffID.Obstructed, 1, false);
        }
    }
}
