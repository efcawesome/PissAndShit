using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class BeeBasher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bee Basher");
            Tooltip.SetDefault("Bonk");
        }

        public override void SetDefaults()
        {
            item.damage = 5000;
            item.melee = true;
            item.width = 180;
            item.height = 180;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 99;
            item.value = 9200;
            item.rare = ItemRarityID.Pink;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
    }
}