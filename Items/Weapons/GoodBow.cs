using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class GoodBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Good Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Tip: It's good\nDoes more than it says");
        }

        public override void SetDefaults()
        {
            item.damage = 1;
            item.ranged = true;
            item.width = 26;
            item.height = 26;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.channel = true; //Channel so that you can held the weapon [Important]
            item.knockBack = 8;
            item.autoReuse = true;
            item.value = Item.sellPrice(silver: 50000);
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item9;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 50);
            recipe.AddIngredient(ItemID.Phantasm, 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = 0;
            Vector2 perturbedSpeed = new Vector2(speedX, speedY); // 30 degree spread.
            int projectile = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Main.rand.Next(1, 711), 1500, knockBack, player.whoAmI);
            Main.projectile[projectile].hostile = false;
            Main.projectile[projectile].friendly = true;
            return true;
        }
    }
}