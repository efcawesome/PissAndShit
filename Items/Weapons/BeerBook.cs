using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace PissAndShit.Items.Weapons
{
    class BeerBook : ModItem

    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Beer Book");
            Tooltip.SetDefault("Use this to make your enemies drunk");
        }

		public override void SetDefaults()
		{
			item.damage = 44;
			item.width = 15;
			item.height = 15;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 8;
			item.value = 9200;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("beertwo");
			item.shootSpeed = 8f;
		}

		

	}
}
