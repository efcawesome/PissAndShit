using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PissAndShit.Buffs
{
    public class Kamra : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Kamra");
            Description.SetDefault("You feel your sins crawling on your back");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PaSPlayer>().kamra = true;
        }
    }
}
