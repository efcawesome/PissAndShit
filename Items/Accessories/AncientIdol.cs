using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class AncientIdol : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shoot golem beams after taking damage");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PaSPlayer>().ancientIdol = true;
        }
    }
}
