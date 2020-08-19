using Microsoft.Xna.Framework;
using PissAndShit.NPCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    class EndlesserModeItem : ModItem
    {
        private static bool difficultyActive = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endlesser Mode");
            Tooltip.SetDefault("Use only if you are a true gamer");
        }
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = false;
            item.rare = ItemRarityID.Red;
        }
        public override bool CanUseItem(Player player)
        {
            return PaSWorld.endlessModeSave;
        }
        public override bool UseItem(Player player)
        {
            if (difficultyActive == false)
            {
                difficultyActive = true;
                PaSWorld.endlesserModeSave = true;
                AGLobalNPC.endlesserModeBool = PaSWorld.endlesserModeSave;
                Main.NewText("Turn back before its too late", 0, 0, 0);
            }
            else
            {
                difficultyActive = false;
                PaSWorld.endlesserModeSave = false;
                AGLobalNPC.endlesserModeBool = PaSWorld.endlesserModeSave;
                Main.NewText("You may have strayed from the path, but you are back on it again", 255, 255, 255);
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
