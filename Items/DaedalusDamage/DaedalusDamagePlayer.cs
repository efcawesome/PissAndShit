using Terraria;
using Terraria.ModLoader;

namespace PissAndShit.Items.DaedalusDamage
{
    class DaedalusDamagePlayer : ModPlayer
    {
        public static DaedalusDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<DaedalusDamagePlayer>();
        }

        public float daedalusDamageAdd;
		public float daedalusDamageMult = 1f;
        public float daedalusKnockback;
        public int daedalusCrit;

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

        private void ResetVariables()
        {
            daedalusDamageAdd = 0f;
            daedalusDamageMult = 1f;
            daedalusKnockback = 0f;
            daedalusCrit = 0;
        }
	}
}
