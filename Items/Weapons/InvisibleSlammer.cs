using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class InvisibleSlammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Invisible Slammer");
            Tooltip.SetDefault("Now 100% invisible!");
        }

        public override void SetDefaults()
        {
            item.damage = 2;
            item.melee = true;
            item.width = 1;
            item.height = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 0;
            item.value = 9200;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.alpha = 255;
        }
    }
}