using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PissAndShit
{
    public class PaSPlayer : ModPlayer
    {
		public bool kamra = false;

        public override void ResetEffects()
        {
            kamra = false;
        }

        public override void UpdateBadLifeRegen()
		{
			if (kamra)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 25;
            }
        }
	}
}
