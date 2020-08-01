using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    class JarOfMoonMilk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jar of Moon Milk");
            Tooltip.SetDefault("Milk of the Moon Lord *UwU*");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.rare = ItemRarityID.Red;
        }
    }
}
