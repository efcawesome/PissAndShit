using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace PissAndShit.Items.Consumables
{
    public class TerraWater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra water");
            Tooltip.SetDefault("1 of the 4 terra potion materials, this can't be good for you");
        }
        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.UseSound = SoundID.Item3;
            item.width = 24;
            item.buffType = (BuffID.Stoned);
            item.buffTime = 1800;
            item.height = 38;
            item.width = 20;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 30;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<TrueNocturnalOoze>());
            recipe.AddIngredient(ItemType<TrueSparklyWater>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }

    }
}
