using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class BloodyBrainTome : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Brain's Tome");
            Tooltip.SetDefault("30% increased magic damage\n15% decreased mana usage\n20% reduced damage resistance\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 50);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamageMult *= 1.3f;
            player.manaCost *= 0.85f;
            player.endurance *= 0.8f;
        }
    }
}
