using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor.DevSets
{
    [AutoloadEquip(EquipType.Head)]
    public class GodSlimeCostumeHead : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("God Slime Veil");
            Tooltip.SetDefault("Now you can look like a GOD\nPart of efcawesome's dev set");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.rare = ItemRarityID.Red;
            item.maxStack = 1;
            item.vanity = true;
        }

        public override bool DrawHead()
        {
            return false;
        }

        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<GodSlimeCostumeBody>() && legs.type == ModContent.ItemType<GodSlimeCostumeLegs>();
        }

        public override void UpdateArmorSet(Player player)
        {
            Main.NewText("Full Armor Set");
        }
    }
}