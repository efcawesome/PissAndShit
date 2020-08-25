using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class DaedalusSevenbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Not a Daedelus Stormbow nockoff.");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(16, 27);
            item.damage = 900;
            item.ranged = true;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 2.3f;
            item.value = Item.sellPrice(gold: 15);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 11f;
            item.noMelee = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 20 + Main.rand.Next(5);
            for (int index = 0; index < numberProjectiles; ++index)
            {
                Vector2 vector2_1 = new Vector2((float)(player.position.X + player.width * 0.5 + Main.rand.Next(201) * -player.direction + (Main.mouseX + (double)Main.screenPosition.X - player.position.X)), (float)(player.position.Y + player.height * 0.5 - 600.0));
                vector2_1.X = (float)((vector2_1.X + (double)player.Center.X) / 2.0) + Main.rand.Next(-200, 201);
                vector2_1.Y -= 100 * index;
                float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if (num13 < 0.0)
                {
                    num13 *= -1f;
                }

                if (num13 < 20.0)
                {
                    num13 = 20f;
                }

                float num14 = (float)Math.Sqrt(num12 * (double)num12 + num13 * (double)num13);
                float num15 = item.shootSpeed / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = num16 + Main.rand.Next(-5, 6) * 0.02f;
                float SpeedY = num17 + Main.rand.Next(-5, 6) * 0.02f;
                Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, Main.rand.Next(5));
            }
            return false;
        }

        public override bool ConsumeAmmo(Player p)
        {
            return !Main.rand.NextBool(3);
        }
    }
}