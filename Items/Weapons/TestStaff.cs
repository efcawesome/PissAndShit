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
    class TestStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Test Staff");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;

            item.damage = 0;
            item.knockBack = 2.5f;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Red;
        }
        public override bool UseItem(Player player)
        {
            for(int i = 0; i < 50; i++)
            {
                Vector2 position = player.Center + Vector2.UnitX.RotatedBy(MathHelper.ToRadians(360f / 50 * i)) * 30;
                Dust dust = Dust.NewDustPerfect(position, DustID.PurpleCrystalShard);
                dust.noGravity = true;
                dust.velocity = Vector2.Normalize(dust.position - player.Center) * 4;
                dust.noLight = false;
                dust.fadeIn = 1f;
            }
            return true;
            
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 25; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.screenPosition.X + Main.screenPosition.X / 2, Main.screenPosition.Y - 10), new Vector2(speedX, speedY), ProjectileID.Meteor1, damage, (int)knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
