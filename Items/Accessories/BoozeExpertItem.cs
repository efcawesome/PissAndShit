using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    class BoozeExpertItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Terra Ale of Truth and Power 2: Revenge of the Sith");
            Tooltip.SetDefault("Just dont get hit lol");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 30;

            item.value = Item.buyPrice(gold: 25);
            item.rare = ItemRarityID.Expert;
            item.accessory = true;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamageMult *= 10;
            if (player.statLife < player.statLifeMax)
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " got too drunk"), 10000, 1, false);
            }
        }
    }
}
