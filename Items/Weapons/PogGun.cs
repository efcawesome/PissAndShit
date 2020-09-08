using Microsoft.Xna.Framework;
using PissAndShit.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Weapons
{
    public class PogGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pogket Launcher");
            Tooltip.SetDefault("'Prepare thine buttocks' - Ryan");
        }
        public override void SetDefaults()
        {
            item.damage = 5;
            item.ranged = true;
            item.width = 44;
            item.height = 32;
            item.useTime = 2;
            item.useAnimation = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Pog");
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.value = 23000;
            item.rare = ItemRarityID.LightPurple;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<PogChamp>();
            item.shootSpeed = 19f;
        }
        public override void AddRecipes()
        {
            ModRecipe shitRecipes = new ModRecipe(mod);
            shitRecipes.AddIngredient(ItemID.DirtBlock, 999);
            shitRecipes.AddIngredient(ItemID.StoneBlock, 999);
            shitRecipes.AddIngredient(ItemID.SandBlock, 999);
            shitRecipes.AddIngredient(ItemID.MudBlock, 999);
            shitRecipes.AddTile(TileID.Painting2X3);
            shitRecipes.SetResult(this);
            shitRecipes.AddRecipe();
        }
    }
}
