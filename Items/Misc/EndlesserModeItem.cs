using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Misc
{
    public class EndlesserModeItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endlesser Mode");
            Tooltip.SetDefault("Use only if you are a true gamer\nMakes bosses even more difficult\nCan only be used while endless mode is active");
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
            if (!PaSWorld.endlesserModeSave)
            {
                PaSGlobalNPC.endlesserMode = PaSWorld.endlesserModeSave = true;
                Main.NewText("Turn back before its too late", 48, 0, 2);
            }
            else
            {
                PaSGlobalNPC.endlesserMode = PaSWorld.endlesserModeSave = false;
                Main.NewText("You may have strayed from the path, but you are back on it again", 212, 38, 45);
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
