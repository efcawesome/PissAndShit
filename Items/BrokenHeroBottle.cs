using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items
{
    public class BrokenHeroBottle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Hero Bottle");
            Tooltip.SetDefault("The bottle is broken, what more info do you need");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.rare = 6;
            item.width = 20;
            item.height = 26;

        }
    }
}