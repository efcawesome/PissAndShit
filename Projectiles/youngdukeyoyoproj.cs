using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PissAndShit.Projectiles
{
    public class youngdukeyoyoproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 8f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 2f;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(10))
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, ProjectileID.None, 50, projectile.knockBack, Main.myPlayer);
            }
        }

        public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(10))
            {
                n.AddBuff(20, 180);
            }
        }
    }
}