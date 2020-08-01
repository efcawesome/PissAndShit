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
    public class BigSword: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Sword");
            Tooltip.SetDefault("L a r g e");
        }
        public override void SetDefaults()
        {
            item.width = 150;
            item.height = 150;
            item.rare = 2;
            item.damage = 10;
            item.crit = 25;
            item.useStyle = 1;
            item.UseSound = SoundID.NPCHit41;
            item.useTime = 20;
            item.useAnimation = 20;
            item.autoReuse = true;
            item.melee = true;
            item.scale = 5;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<BigChunk>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
