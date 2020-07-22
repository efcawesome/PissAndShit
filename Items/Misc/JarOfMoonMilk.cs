using IL.Terraria.GameContent.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
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
