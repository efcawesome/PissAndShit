using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CringeMod.Items.Weapons
{
    class YoungRazorTyphoon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Young Razorblade Typhoon");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.magic = true;
            item.width = 22;
            item.height = 24;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 0.5f;
            item.value = Item.sellPrice(gold: 1, silver: 50);
            item.rare = ItemRarityID.Green;
            item.mana = 8;
            item.UseSound = SoundID.Item84;
            item.autoReuse = true;
            item.shoot = ProjectileID.Typhoon;
            item.shootSpeed = 6;
        }
    }
}
