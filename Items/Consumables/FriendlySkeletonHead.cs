using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Consumables
{
    public class FriendlySkeletonHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Friendly Skeleton Head");
            Tooltip.SetDefault("Summons a dungeon guardian to *protect* you");
        }

        public override void SetDefaults()
        {
            item.width = 14;
            item.height = 20;
            item.maxStack = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTime = 45;
            item.useAnimation = 45;
            item.consumable = true;
            item.rare = ItemRarityID.Gray;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(NPCID.DungeonGuardian);
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.DungeonGuardian);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 100);
            recipe.AddIngredient(ItemID.ObsidianSkull, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}