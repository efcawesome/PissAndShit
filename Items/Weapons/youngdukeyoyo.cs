using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Weapons
{
    public class youngdukeyoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hurricane");
            Tooltip.SetDefault("Incredible Speed and Strength, Also Wet.");

            // These are all related to gamepad controls and don't seem to affect anything else
            ItemID.Sets.Yoyo[item.type] = true;
            ItemID.Sets.GamepadExtraRange[item.type] = 15;
            ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.width = 26;
            item.height = 30;
            item.useAnimation = 25;
            item.useTime = 20;
            item.shootSpeed = 16f;
            item.knockBack = 4.5f;
            item.damage = 40;
            item.rare = ItemRarityID.Orange;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.noUseGraphic = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.sellPrice(silver: 0);
            item.shoot = ModContent.ProjectileType<youngdukeyoyoproj>();
        }
    }
}