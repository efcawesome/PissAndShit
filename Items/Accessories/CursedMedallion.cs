using PissAndShit.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Items.Accessories
{
    public class CursedMedallion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Cursed souls have a chance to spawn on enemy deaths\nWhen killed you regenerate 25 life\nEndless Drop");
        }

        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 56;
            item.rare = ItemRarityID.Expert;

            item.value = Item.buyPrice(gold: 15);
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            PaSGlobalNPC.cursedMedallionSpawn = player.GetModPlayer<PaSPlayer>().cursedMedallion = true;
        }
    }
}
