using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class Exoskeleton : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exoskeleton");
            Tooltip.SetDefault("20 defense\n10% increased damage reduction\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 18;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 20;
            player.endurance += 0.1f;
            player.GetModPlayer<PaSPlayer>().exoskeletonBad = true;
        }
    }
}
