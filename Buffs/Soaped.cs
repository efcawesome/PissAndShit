using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace PissAndShit.Buffs
{
    public class Soaped : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Soaped");
            Description.SetDefault("You are covered in soap");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<PaSPlayer>().soaped = true;
        }
    }
}
