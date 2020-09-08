using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
    class TerraHawk : DaedalusDamageItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Use to call upon a terra hawk");
        }
        public override void SafeSetDefaults()
        {
            item.width = 32;
            item.height = 56;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.damage = 80;
            item.knockBack = 1.2f;
            item.maxStack = 1;
            item.shoot = ModContent.ProjectileType<TerraHawkProj>();
            item.shootSpeed = 5;
            item.rare = ItemRarityID.Yellow;
            item.crit = 4;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(new Vector2(Main.screenPosition.X, Main.screenPosition.Y + 20), new Vector2(5, 0), type, 0, knockBack, Main.myPlayer);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PoisonedKnife, 100);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
