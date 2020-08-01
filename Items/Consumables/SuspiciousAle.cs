using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables
{
    class SuspiciousAle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspsicious Looking Ale");
            Tooltip.SetDefault("Summons the drunken shroom");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 79;
            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = true;
            item.rare = ItemRarityID.Red;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<boozeshrume>());
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<boozeshrume>());
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ale, 20);
            recipe.AddIngredient(ItemID.SoulofLight, 10);
            recipe.AddIngredient(ItemID.SoulofNight, 10);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
