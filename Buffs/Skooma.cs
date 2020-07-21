using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace testmod.Buffs
{
	public class Skooma : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("s k o o m a");
			Description.SetDefault("Absolutely mental khajiit inhales 250 skooma and then dies");
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			for (int i = 0; i < 9; i++)
			{
				player.velocity.X *= 1.10f;
				player.moveSpeed *= 1.10f;
				player.maxRunSpeed *= 1.10f;
			}
		}
	}
}
