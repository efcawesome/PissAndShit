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
    public class the7: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("7");
            Tooltip.SetDefault("7");
        }
        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 78;
            item.rare = 11;
            item.damage = 1000000000;
            item.crit = 1000;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.useTime = 3;
            item.useAnimation = 3;
            item.autoReuse = true;
            item.melee = true;
            item.scale = 3;
        }

    }
}
