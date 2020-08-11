using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent;
using static Terraria.ModLoader.ModContent;
using static Terraria.ModLoader.NPCLoader;
using static Terraria.Projectile;
using PissAndShit.Projectiles;

namespace PissAndShit.Items
{
	public class InfernalNightmare : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
		}
		public override void SetDefaults()
		{
			item.damage = 82;
			item.melee = true;
			item.height = 66;
			item.width = 60;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 4;
			item.rare = 11;
			item.value = 300000;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			
		}
		public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit) 
		{   
		//Adds oiled debuff to target
			target.AddBuff(204, 600);
			 
            
		}
		
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MagmaShardBall>()] < 1)
			{
		
		
				Main.PlaySound(SoundID.Item14, (int)target.Center.X, (int)target.Center.Y);
			
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<MagmaShardBall>(), 64, 0f, Main.myPlayer, 0f, 0f);
			}
			
		}
	}
	
}
			