using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class DeathHand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Death's Hand");
            Tooltip.SetDefault("'Everything is under your control'\nClick an enemy to get info and control aspects of it");
        }

        public override void SetDefaults()
        {
            item.damage = -1;
            item.width = 180;
            item.height = 180;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 99;
            item.value = Item.buyPrice(6, 24, 11, 2);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
    }
}