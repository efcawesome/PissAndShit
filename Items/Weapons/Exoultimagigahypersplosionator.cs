using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PissAndShit.Items.Weapons
{
    public class Exoultimagigahypersplosionator : ModItem
    {
        private int splodinatorFired = 0;
        private int splodinatorOffset = -1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exoultimagigahypersplosionator");
            Tooltip.SetDefault("A weapon so ridiculously overpowered it could kill death himself\n'Better stock up on rockets'");
        }
        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 78;
            item.rare = ItemRarityID.Expert;
            item.damage = 1250000;
            item.crit = 1000;
            item.useStyle = 5;
            item.UseSound = SoundID.Item11;
            item.noMelee = true;
            item.useTime = 2;
            item.useAnimation = 2;
            item.autoReuse = true;
            item.ranged = true;
            item.scale = 1;
            item.expert = true;
            item.useAmmo = AmmoID.Rocket;
            item.shoot = ModContent.ProjectileType<Projectiles.SplosionatorRocket>();
            item.shootSpeed = 5f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 29f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            type = ModContent.ProjectileType<Projectiles.SplosionatorRocket>();

            if (splodinatorFired > 2)
            {
                splodinatorFired = 0;
            }
            if (splodinatorFired == 0)
            {
                splodinatorOffset = -4;
            }
            else if (splodinatorFired == 1)
            {
                splodinatorOffset = 0;
            }
            else if (splodinatorFired == 2)
            {
                splodinatorOffset = 4;
            }

            if (player.direction == 1)
            {

                // how to choose position:
                // on X: if looking right, -22 X
                // on Y: -4 Y

                Projectile.NewProjectile(position.X - 22, position.Y - 4 + splodinatorOffset, speedX, speedY, type, damage, knockBack, player.whoAmI);//front
                Projectile.NewProjectile(position.X - 3 - splodinatorOffset, position.Y - 28, speedX - 5, speedY - 5, type, damage, knockBack, player.whoAmI);//top
                Projectile.NewProjectile(position.X - 6, position.Y + 9, speedX - 1f, speedY - 5f, type, damage, knockBack, player.whoAmI);//top angled
                Projectile.NewProjectile(position.X + 6, position.Y - 9, speedX + 10f, speedY + 15f, type, damage, knockBack, player.whoAmI);//bottom angled
                Projectile.NewProjectile(position.X - 3, position.Y + 9, speedX - 5f, speedY + 5f, type, damage, knockBack, player.whoAmI);//bottom
            }
            else
            {
                Projectile.NewProjectile(position.X, position.Y - 4 - splodinatorOffset, speedX, speedY, type, damage, knockBack, player.whoAmI);//front
                Projectile.NewProjectile(position.X + 19 + splodinatorOffset, position.Y - 28, speedX + 5, speedY - 5, type, damage, knockBack, player.whoAmI);//top
                Projectile.NewProjectile(position.X - 2, position.Y + 9, speedX + 1f, speedY + 5f, type, damage, knockBack, player.whoAmI);//top angled
                Projectile.NewProjectile(position.X + 2, position.Y - 9, speedX - 10f, speedY - 15f, type, damage, knockBack, player.whoAmI);//bottom angled
                Projectile.NewProjectile(position.X + 19, position.Y + 13, speedX + 5f, speedY + 5f, type, damage, knockBack, player.whoAmI);//bottom
            }
            splodinatorFired++;

            return false; // return false because we don't want tmodloader to shoot projectile
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-22, -4);
        }
    }
}
