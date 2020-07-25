using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;

namespace CringeMod.Projectiles
{
    class SevenProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("7");
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
        {
			projectile.width = 51;
			projectile.height = 51;
			projectile.hostile = true;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Skull;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 300;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;

			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				projectile.frame = ++projectile.frame % Main.projFrames[projectile.type];
			}
		}
    }
}
