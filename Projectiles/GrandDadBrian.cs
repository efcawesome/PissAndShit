using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    class GrandDadBrian : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GrandDadBrian");
        }
        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 92;
            projectile.aiStyle = 107;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
        }

        public override void AI()
        {
        //    projectile.CloneDefaults(ProjectileID.DesertDjinnCurse);
        }
    }
    //yes I like to put comments on every code I do
}
