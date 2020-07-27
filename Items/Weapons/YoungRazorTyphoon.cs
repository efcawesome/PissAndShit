using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    class YoungRazorTyphoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whirlpool");
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.magic = true;
            item.width = 22;
            item.height = 24;
            item.useTime = 15;
            item.useAnimation = 45;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0.5f;
            item.value = Item.sellPrice(gold: 1, silver: 50);
            item.rare = ItemRarityID.Green;
            item.mana = 15;
            item.UseSound = SoundID.Item84;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("YoungTyphoon");
            item.shootSpeed = 6;
        }
    }
}

