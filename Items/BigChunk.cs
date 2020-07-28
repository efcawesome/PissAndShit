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
    public class BigChunk : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Chunk");
            Tooltip.SetDefault("large");
        }
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.rare = 6;
            item.width = 26;
            item.height = 28;
            item.scale = 10;

        }
    }
}