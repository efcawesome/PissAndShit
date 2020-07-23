using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles { 
	public class YoungSharknadoBolt : ModProjectile
	{




		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("YoungSharknadoBolt");
		}

		public override void SetDefaults()
		{
			projectile.width = 30;
			projectile.height = 30;
			projectile.hostile = true;
			projectile.penetrate = -1;
			projectile.aiStyle = 65;
			projectile.alpha = 255;
			projectile.timeLeft = 300;
			aiType = ProjectileID.SharknadoBolt;
			
		}

        public override void AI()
        {
		}
	}
    }
