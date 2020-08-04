using PissAndShit.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables
{
    class YoungWorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Truffle Larva");
            Tooltip.SetDefault("use at the ocean unless you have a deathwish");
        }
        public override void SetDefaults()
        {
            item.width = 198;
            item.height = 51;
            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = true;
            item.rare = ItemRarityID.Green;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<YoungDuke>());
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<YoungDuke>());
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(154,20);
            recipe.AddIngredient(183,20);
            recipe.AddTile(77);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}