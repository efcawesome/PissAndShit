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


namespace PissAndShit.Items.Weapons
{
    public class StonePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone destruction tool");
            Tooltip.SetDefault("Made of stone");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.rare = 2;
            item.damage = 10;
            item.crit = 4;
            item.useStyle = 1;
            item.UseSound = SoundID.Item1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.melee = true;
            item.pick = 50;
            item.axe = 75;
            item.hammer = 75;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<StoneBar>(), 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
