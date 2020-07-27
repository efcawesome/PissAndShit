using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace PissAndShit.Items
{
    public class Capitalism: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Capitalism");
            Tooltip.SetDefault("Big and shinny and strong and epic and shinny");
        }
        public override void SetDefaults()
        {
            item.width = 118;
            item.height = 118;
            item.rare = 7;
            item.damage = 100;
            item.crit = 25;
            item.useStyle = 1;
            item.UseSound = SoundID.Item4;
            item.useTime = 15;
            item.useAnimation = 15;
            item.scale = 2;
            item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Midas, 1200);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MoneyBar>(), 10);
            recipe.AddIngredient(ItemID.GoldCoin, 50);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
