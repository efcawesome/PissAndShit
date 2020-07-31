using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FesteringBreastPlate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Festering Breastplate");
            Tooltip.SetDefault("it smells like poop."
                + "\nGives a ton of DR and defense'");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = 10000;
            item.rare = ItemRarityID.Purple;
            item.defense = 60;
        }

        public override void UpdateEquip(Player player)
        {
            player.statDefense += 150;
            player.endurance += 130;
        }
    }
}
