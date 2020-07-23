using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CringeMod.Items.Weapons
{
    class BulletRainOfSans : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("80% chance to not consume ammo.");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 16;
            item.damage = 325;
            item.ranged = true;
            item.useTime = 2;
            item.useAnimation = 2;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 1);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.Item40;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Bullet;
            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.noMelee = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
        {
            /*Code is made by berberborscing*/
            int spread = 100; //The angle of random spread.
            float spreadMult = 0.1f; //Multiplier for bullet spread, set it higher and it will make for some outrageous spread.
            for (int i = 0; i < 3; i++)
            {
                float vX = speedX + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                float vY = speedY + (float)Main.rand.Next(-spread, spread + 1) * spreadMult;
                Projectile.NewProjectile(position.X, position.Y, vX, vY, type, damage, knockBack, Main.myPlayer);
            }
            return false; //Makes sure to not spawn the original projectile
        }

        public override bool ConsumeAmmo(Player p)
        {
            int rand = Main.rand.Next(1, 6);
            if (rand == 1)
            {
                return false;
            }
            else if (rand == 2)
            {
                return false;
            }
            else if (rand == 3)
            {
                return false;
            }
            else if (rand == 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
