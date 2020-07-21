using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace PissAndShit.Items
{
    public class TrueSparklyWater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Sparkly Water");
            Tooltip.SetDefault("Sweet and sour");
        }
        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 2;
            item.UseSound = SoundID.Item3;
            item.width = 20;
            item.buffType = (BuffID.VortexDebuff);
            item.buffTime = 600;
            item.height = 36;
            item.width = 28;
            item.rare = 7;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<SparklyWater>());
            recipe.AddIngredient(ItemType<BrokenHeroBottle>());
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}