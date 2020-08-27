using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class LegendaryBooze : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Legendary Booze");
            Tooltip.SetDefault("Grants several buffs\nEndurance, Featherfall, Gills, Heartreach, Ironskin, Mining, Night Owl, Regeneration, Shine, Swiftness, Thorns\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 55;
            item.height = 60;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Endurance, 1, false);
            player.AddBuff(BuffID.Featherfall, 1, false);
            player.AddBuff(BuffID.Gills, 1, false);
            player.AddBuff(BuffID.Heartreach, 1, false);
            player.AddBuff(BuffID.Ironskin, 1, false);
            player.AddBuff(BuffID.Mining, 1, false);
            player.AddBuff(BuffID.NightOwl, 1, false);
            player.AddBuff(BuffID.Regeneration, 1, false);
            player.AddBuff(BuffID.Shine, 1, false);
            player.AddBuff(BuffID.Swiftness, 1, false);
            player.AddBuff(BuffID.Thorns, 1, false);
        }
    }
}
