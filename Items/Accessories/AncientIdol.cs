using PissAndShit.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    class AncientIdol : ModItem
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
            item.rare = TomatoLib.Core.TomatoLoader.RarityType<EndlessRarity>();
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<PaSPlayer>().ancientIdol = true;
        }
    }
}
