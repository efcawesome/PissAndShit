using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class ExoskeletonMkII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exoskeleton Mk. II");
            Tooltip.SetDefault("20 defense\n10% increased damage reduction\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 20;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense += 35;
            player.endurance += 0.2f;
            player.GetModPlayer<PaSPlayer>().exoskeletonGood = true;
        }
    }
}
