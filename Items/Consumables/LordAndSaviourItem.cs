using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PissAndShit.Items.Consumables
{
    public class LordAndSaviourItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("???");
            Tooltip.SetDefault("Summons our Lord and Saviour");
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.width = 32;
            item.height = 32;
            item.rare = -12;
            item.consumable = true;
        }

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<LordAndSaviour>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}