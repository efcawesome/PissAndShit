using Microsoft.Xna.Framework;
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
    class SevenShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seven Dagger");
            Tooltip.SetDefault("Not all shortswords are bad");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;

            item.melee = true;
            item.damage = 600;
            item.knockBack = 2.5f;
            item.useTime = 1;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.Stabbing;

            item.autoReuse = true;
            item.rare = ItemRarityID.Red;
            item.shoot = mod.ProjectileType("SevenDaggerProj");
            item.shootSpeed = 12f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int spread = 30;
            float spreadMult = 0.1f;
            for (int i = 0; i < 7; i++)
            {
                float vX = speedX + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false;
        }
    }
}
