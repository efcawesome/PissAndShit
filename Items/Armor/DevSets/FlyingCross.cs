using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Wings)]
    public class FlyingCross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flying Cross");
            Tooltip.SetDefault("Soar with holy power\nPart of efcawesome's dev set");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTimeMax = 240;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 2f;
            ascentWhenRising = 5f;
            maxCanAscendMultiplier = 3f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.5f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 30f;
            acceleration *= 4f;
        }
    }
}