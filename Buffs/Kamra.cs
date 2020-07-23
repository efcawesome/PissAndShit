  using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PissAndShit.Buffs
{
	public class Kamra : ModBuff
	{
        public override void SetDefaults() {
            DisplayName.SetDefault("Kamra");
            Description.SetDefault("i'll be 'frank' with you. as much as i like putting hot dogs on your head... thirty is just an excessive number. twenty-nine, now that's fine, but thirty... does it look like my arms can reach that high?");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<PaSPlayer>().kamra = true;
		}
    }
}