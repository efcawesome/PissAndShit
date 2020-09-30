using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class AbyssalLens : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abyssal Lens");
            Tooltip.SetDefault("Grants permanent spelunker effect\nGives permanent obstructed\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 36;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Obstructed, 1, false);
            player.AddBuff(BuffID.Spelunker, 1, false);
        }
    }
}
