using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit
{
    class PaSGlobalProjectile : GlobalProjectile
    {
        public override void AI(Projectile projectile)
        {
            if(PaSWorld.endlessModeSave)
            {
                if(NPC.AnyNPCs(NPCID.DukeFishron))
                {
                    if(projectile.type == ProjectileID.Sharknado || projectile.type == ProjectileID.Cthulunado)
                    {
                        projectile.timeLeft++;
                    }
                }
            }
        }
    }
}
